using HM.DTO;
using HM.DTO.FacePlatform;
using HM.FacePlatform.Model;
using HM.Form_;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using HM.Form_.Old;
using HM.Enum_.FacePlatform;
using System.Threading.Tasks;

namespace HM.FacePlatform.Forms
{
    public partial class MapBuildingFrm : FrmBase
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

            if (buildingForMapDto.has_map)
            {
                cells["col_has_map_text"].Value = "是";
            }
            else
            {
                cells["col_has_map_text"].Value = "否";
            }
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
                            mao_id = _mao.id,
                            change_time = DateTime.Now,
                            create_time = DateTime.Now,
                            is_del = IsDelType.否
                        });
                    }
                    else
                    {
                        lstToDel.Add(buildingForMapDto.building_code);
                    }
                }
            }

            ActionResult ar = new ActionResult();
            if (lstToAdd.Any())
            {
                hasChange = true;
                var result = _maoBuildingBLL.AddOrUpdate(it => new { it.building_code, it.mao_id },
                    lstToAdd.ToArray());
                if (result.IsSuccess)
                {
                    //将新增楼栋相关的已注册的人脸信息，添加到此人脸一体机中
                }
                ar.Add(result);
            }
            if (lstToDel.Any())
            {
                hasChange = true;
                var result = _maoBuildingBLL.SoftDelete(_mao.id, lstToDel);
                if (result.IsSuccess)
                {
                    //将已注册成功，或待审核的人脸信息，从此人脸一体机中删除
                }
                ar.Add(result);
            }
            if (hasChange)
            {
                if (ar.IsSuccess)
                {
                    //if (lstToAdd.Any())
                    //{
                    //    var editResult = new BLL.MaoBLL().Edit(it => it.id == _mao.id, it => new Mao()
                    //    {
                    //        is_init = false
                    //    });
                    //    HMMessageBox.Show(this, "您已关联了新的楼栋，请重新初始化");
                    //}
                    Task.Run(() =>
                    {
                        InitJob job = new InitJob(_mao);
                        job.MapBuilding(lstToAdd, lstToDel);
                    });
                    HMMessageBox.Show(this, "关联变更成功，相关设备数据同步中，请参考右下角同步结果！");
                    PagerBuilding.Bind();
                }
                else
                {
                    HMMessageBox.Show(this, ar.ToAlertString());
                }
            }
            else
            {
                _Tip.ShowItTop(BtnBatchMap, "未有变更");
            }
        }

        private void MapBuildingFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;//界面需要重新加载数据
        }
    }
}
