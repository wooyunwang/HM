using HM.DTO;
using HM.DTO.FaceForm;
using HM.FacePlatform.Model;
using HM.Form_;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using HM.Form_.Old;

namespace HM.FacePlatform.Forms
{
    public partial class MapBuildingFrm : HM.Form_.HMForm
    {
        VankeBalloonToolTip _Tip;//提示
        BLL.BuildingBLL _buildingBLL = new BLL.BuildingBLL();
        BLL.MaoBuildingBLL _maoBuildingBLL = new BLL.MaoBuildingBLL();

        Mao _mao { get; set; }
        public MapBuildingFrm(Mao mao)
        {
            InitializeComponent();
            _Tip = new VankeBalloonToolTip(this);
            _mao = mao;
        }

        private void MapBuildingFrm_Load(object sender, EventArgs e)
        {
            LblMaoInfo.Text = $"猫信息：编号【{_mao.mao_no}】名称【{_mao.mao_name}】IP【{_mao.GetIP()}】端口【{_mao.port}】";
            PagerBuilding.Bind();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int PagerBuilding_EventPaging(Form_.EventPagingArg e)
        {
            string buildingName = TxtBuildingName.Text.Trim();
            bool? hasMap = null;
            if (RbnAll.Checked) hasMap = null;
            else if (RbnHasMap.Checked) hasMap = true;
            else if (RbnNoMap.Checked) hasMap = false;

            var result = _buildingBLL.GetBuildingForMap(PagerBuilding.PageIndex, PagerBuilding.PageSize, Program._Mainform._ProjectCode, _mao.id, buildingName, hasMap);
            if (!result.IsSuccess)
            {
                HMMessageBox.Show(this, result.ToAlertString());
                result.Obj = new PagerData<BuildingForMapDto>()
                {
                    pages = 0,
                    rows = new List<BuildingForMapDto>(),
                    total = 0
                };
            }
            foreach (var row in result.Obj.rows)
            {
                row.is_selected = row.has_map;
            }
            //绑定分页控件
            PagerBuilding.bsPager.DataSource = result.Obj.rows;
            PagerBuilding.bnPager.BindingSource = PagerBuilding.bsPager;
            //分页控件绑定DataGridView
            DgvBuilding.DataSource = PagerBuilding.bsPager;
            //返回总记录数
            return result.Obj.total;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PagerBuilding.Bind();
        }

        private void DgvBuilding_RowPrePaint(object sender, System.Windows.Forms.DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HMDataGridView hmDGV = (HMDataGridView)sender;
            var cells = hmDGV.Rows[e.RowIndex].Cells;
            BuildingForMapDto buildingForMapDto = hmDGV.Rows[e.RowIndex].DataBoundItem as BuildingForMapDto;

            //if (buildingForMapDto.has_map)
            //{
            //    cells["col_has_map"].Value = "是";
            //}
            //else
            //{
            //    cells["col_has_map"].Value = "否";
            //}
        }
        /// <summary>
        /// 是否有变更
        /// </summary>
        bool hasChange = false;
        private void BtnBatchMap_Click(object sender, EventArgs e)
        {
            List<string> lstToDel = new List<string>();
            List<MaoBuilding> lstToAdd = new List<MaoBuilding>();
            foreach (DataGridViewRow row in DgvBuilding.Rows)
            {
                BuildingForMapDto buildingForMapDto = row.DataBoundItem as BuildingForMapDto;
                if (buildingForMapDto.is_selected != buildingForMapDto.has_map)
                {
                    if (buildingForMapDto.is_selected)
                    {
                        lstToAdd.Add(new MaoBuilding()
                        {
                            building_code = buildingForMapDto.building_code,
                            mao_id = _mao.id
                        });
                    }
                    else
                    {
                        lstToDel.Add(buildingForMapDto.building_code);
                    }
                }
            }
            if (lstToAdd.Any())
            {
                _maoBuildingBLL.Add(lstToAdd);
            }
            if (lstToDel.Any())
            {
                _maoBuildingBLL.Delete(it => it.mao_id == _mao.id && lstToDel.Contains(it.building_code));
            }
            _Tip.ShowItTop(BtnBatchMap, "批量处理成功");
            hasChange = true;
        }

        private void MapBuildingFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;//界面需要重新加载数据
        }
    }
}
