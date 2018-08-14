using HM.Form_;
using HM.Form_.Old;
using HM.Utils_;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

namespace HM.FacePlatform
{
    public partial class UcCount : HMUserControl
    {
        private float AngleIn = 20;
        private float AngleOut = 34;

        public DateTime searchBegTime;
        public DateTime searchEndTime;
        public DateTime searchBegTimeB;
        public DateTime searchEndTimeB;
        private VankeBalloonToolTip m_Tip;//提示

        public UcCount()
        {
            InitializeComponent();

            m_Tip = new VankeBalloonToolTip(this);

            dgIn.AllowUserToAddRows = false;
            dgIn.AutoGenerateColumns = false;
            dgIn.RowHeadersVisible = false;


            this.tabControl1.SelectedIndexChanged += new System.EventHandler(Load_Data);//标签切换时显示(刷新)
        }

        void Load_Data(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 0)
            {
                btnThisMonth_Click(sender, e);
            }
            else
                if (((TabControl)sender).SelectedIndex == 1)
            {
                btnThisMonthB_Click(sender, e);
            }
        }

        private void Count_Load(object sender, EventArgs e)
        {
            btnThisMonth_Click(sender, e);//页面第一次加载时显示第一项页面的数据
            //btnThisMonthB_Click(sender, e);

            //LoadData();
        }

        bool firstLoadB = true;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (firstLoadB)//第一次加载
                {
                    firstLoadB = false;

                    ////LoadDataB();
                    //Thread thread1 = new Thread(new ThreadStart(run_B));
                    //thread1.Start();
                    run_B();
                }
            }
        }

        #region time
        private DateTime theDate = DateTime.Now;
        private int byWeekOrMonthOrYear;
        private int byWeekOrMonthOrYearB;

        #region 注册的
        private void btnThisWeek_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            theDate = DateTime.Now;
            DateTime_.GetThisWeekDate(theDate, out beg, out end);
            end = DateTime.Now;
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();
            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYear = (int)ByWeekOrMonthE.ByWeek;

            tbBegReg.Value = searchBegTime;
            tbEndReg.Value = searchEndTime;
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            DateTime begTemp;
            DateTime endTemp;
            DateTime_.GetThisWeekDate(DateTime.Now, out begTemp, out endTemp);

            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByMonth || byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByYear)
            {
                theDate = DateTime.Now;
            }
            if (searchEndTime.AddDays(7) < endTemp)
            {
                DateTime_.GetNextWeekDate(ref theDate, out beg, out end);
                searchBegTime = beg;
                searchEndTime = end;
            }
            else
            {
                theDate = DateTime.Now;
                DateTime_.GetThisWeekDate(theDate, out beg, out end);
                end = DateTime.Now;
                searchBegTime = beg;
                searchEndTime = end;
                m_Tip.ShowIt(btnThisWeek, "所选日期不能超过当前时间！");

            }
            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYear = (int)ByWeekOrMonthE.ByWeek;

            tbBegReg.Value = searchBegTime;
            tbEndReg.Value = searchEndTime;
        }

        private void btnPreWeek_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByMonth || byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByYear)
            {
                theDate = DateTime.Now;
            }
            DateTime_.GetPreWeekDate(ref theDate, out beg, out end);
            searchBegTime = beg;
            searchEndTime = end;
            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYear = (int)ByWeekOrMonthE.ByWeek;

            tbBegReg.Value = searchBegTime;
            tbEndReg.Value = searchEndTime;
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByWeek || byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByYear)
            {
                theDate = DateTime.Now;
            }
            if (searchEndTime.Month < DateTime.Now.Month)
            {
                DateTime_.GetNexMonthDate(ref theDate, out beg, out end);
                searchBegTime = beg;
                searchEndTime = end;
            }
            else
            {
                DateTime_.GetThisMonthDate(theDate, out beg, out end);
                end = DateTime.Now;
                searchBegTime = beg;
                searchEndTime = end;
                m_Tip.ShowIt(btnThisMonth, "所选日期不能超过当前时间！");

            }

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYear = (int)ByWeekOrMonthE.ByMonth;

            tbBegReg.Value = searchBegTime;
            tbEndReg.Value = searchEndTime;
        }

        private void btnPreMonth_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByWeek || byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByYear)
            {
                theDate = DateTime.Now;
            }
            DateTime_.GetPreMonthDate(ref theDate, out beg, out end);
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYear = (int)ByWeekOrMonthE.ByMonth;

            tbBegReg.Value = searchBegTime;
            tbEndReg.Value = searchEndTime;
        }

        public void btnThisMonth_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            theDate = DateTime.Now;
            DateTime_.GetThisMonthDate(theDate, out beg, out end);
            end = DateTime.Now;
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();



            byWeekOrMonthOrYear = (int)ByWeekOrMonthE.ByMonth;

            tbBegReg.Value = searchBegTime;
            tbEndReg.Value = searchEndTime;
        }

        private void btnThisYear_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            theDate = DateTime.Now;
            DateTime_.GetThisYearDate(ref theDate, out beg, out end);
            end = DateTime.Now;
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYear = (int)ByWeekOrMonthE.ByYear;

            tbBegReg.Value = searchBegTime;
            tbEndReg.Value = searchEndTime;
        }

        private void btnPreYear_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByWeek || byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByMonth)
            {
                theDate = DateTime.Now;
            }
            DateTime_.GetPreYearDate(ref theDate, out beg, out end);
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYear = (int)ByWeekOrMonthE.ByYear;

            tbBegReg.Value = searchBegTime;
            tbEndReg.Value = searchEndTime;
        }

        private void btnNextYear_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByWeek || byWeekOrMonthOrYear == (int)ByWeekOrMonthE.ByMonth)
            {
                theDate = DateTime.Now;
            }
            if (searchEndTime.Year < DateTime.Now.Year)
            {
                DateTime_.GetNextYearDate(ref theDate, out beg, out end);
                searchBegTime = beg;
                searchEndTime = end;
            }
            else
            {
                DateTime_.GetThisYearDate(ref theDate, out beg, out end);
                end = DateTime.Now;
                searchBegTime = beg;
                searchEndTime = end;
                m_Tip.ShowIt(btnThisYear, "所选日期不能超过当前时间！");
            }
            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYear = (int)ByWeekOrMonthE.ByYear;

            tbBegReg.Value = searchBegTime;
            tbEndReg.Value = searchEndTime;
        }



        private void tbBegReg_ValueChanged(object sender, EventArgs e)
        {
            searchBegTime = tbBegReg.Value;
        }

        private void tbEndReg_ValueChanged(object sender, EventArgs e)
        {
            searchEndTime = tbEndReg.Value;
        }
        #endregion

        #region 通行的
        private void btnThisWeekB_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            theDate = DateTime.Now;
            DateTime_.GetThisWeekDate(theDate, out beg, out end);
            end = DateTime.Now;
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYearB = (int)ByWeekOrMonthE.ByWeek;

            tbBegRegB.Value = searchBegTime;
            tbEndRegB.Value = searchEndTime;
        }

        private void btnNextWeekB_Click(object sender, EventArgs e)
        {
            DateTime begTemp;
            DateTime endTemp;
            DateTime_.GetThisWeekDate(DateTime.Now, out begTemp, out endTemp);

            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByMonth || byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByYear)
            {
                theDate = DateTime.Now;
            }
            if (searchEndTime.AddDays(7) < endTemp)
            {
                DateTime_.GetNextWeekDate(ref theDate, out beg, out end);
                searchBegTime = beg;
                searchEndTime = end;
            }
            else
            {
                theDate = DateTime.Now;
                DateTime_.GetThisWeekDate(theDate, out beg, out end);
                end = DateTime.Now;
                searchBegTime = beg;
                searchEndTime = end;
                m_Tip.ShowIt(btnThisWeek, "所选日期不能超过当前时间！");

            }
            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYearB = (int)ByWeekOrMonthE.ByWeek;

            tbBegRegB.Value = searchBegTime;
            tbEndRegB.Value = searchEndTime;
        }

        private void btnPreWeekB_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByMonth || byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByYear)
            {
                theDate = DateTime.Now;
            }
            DateTime_.GetPreWeekDate(ref theDate, out beg, out end);
            searchBegTime = beg;
            searchEndTime = end;
            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            //Thread t2 = new Thread(() =>
            //{
            //    LoadData("");
            //});
            //t2.Start();

            byWeekOrMonthOrYearB = (int)ByWeekOrMonthE.ByWeek;

            tbBegRegB.Value = searchBegTime;
            tbEndRegB.Value = searchEndTime;
        }

        private void btnNextMonthB_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByWeek || byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByYear)
            {
                theDate = DateTime.Now;
            }
            if (searchEndTime.Month < DateTime.Now.Month)
            {
                DateTime_.GetNexMonthDate(ref theDate, out beg, out end);
                searchBegTime = beg;
                searchEndTime = end;
            }
            else
            {
                DateTime_.GetThisMonthDate(theDate, out beg, out end);
                end = DateTime.Now;
                searchBegTime = beg;
                searchEndTime = end;
                m_Tip.ShowIt(btnThisMonth, "所选日期不能超过当前时间！");

            }

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYearB = (int)ByWeekOrMonthE.ByMonth;

            tbBegRegB.Value = searchBegTime;
            tbEndRegB.Value = searchEndTime;
        }

        private void btnPreMonthB_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByWeek || byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByYear)
            {
                theDate = DateTime.Now;
            }
            DateTime_.GetPreMonthDate(ref theDate, out beg, out end);
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYearB = (int)ByWeekOrMonthE.ByMonth;

            tbBegRegB.Value = searchBegTime;
            tbEndRegB.Value = searchEndTime;
        }

        public void btnThisMonthB_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            theDate = DateTime.Now;
            DateTime_.GetThisMonthDate(theDate, out beg, out end);
            end = DateTime.Now;
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYearB = (int)ByWeekOrMonthE.ByMonth;

            tbBegRegB.Value = searchBegTime;
            tbEndRegB.Value = searchEndTime;
        }

        private void btnThisYearB_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            theDate = DateTime.Now;
            DateTime_.GetThisYearDate(ref theDate, out beg, out end);
            end = DateTime.Now;
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYearB = (int)ByWeekOrMonthE.ByYear;

            tbBegRegB.Value = searchBegTime;
            tbEndRegB.Value = searchEndTime;
        }

        private void btnPreYearB_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByWeek || byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByMonth)
            {
                theDate = DateTime.Now;
            }
            DateTime_.GetPreYearDate(ref theDate, out beg, out end);
            searchBegTime = beg;
            searchEndTime = end;

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYearB = (int)ByWeekOrMonthE.ByYear;

            tbBegRegB.Value = searchBegTime;
            tbEndRegB.Value = searchEndTime;
        }

        private void btnNextYearB_Click(object sender, EventArgs e)
        {
            DateTime beg;
            DateTime end;
            if (byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByWeek || byWeekOrMonthOrYearB == (int)ByWeekOrMonthE.ByMonth)
            {
                theDate = DateTime.Now;
            }
            if (searchEndTime.Year < DateTime.Now.Year)
            {
                DateTime_.GetNextYearDate(ref theDate, out beg, out end);
                searchBegTime = beg;
                searchEndTime = end;
            }
            else
            {
                DateTime_.GetThisYearDate(ref theDate, out beg, out end);
                end = DateTime.Now;
                searchBegTime = beg;
                searchEndTime = end;
                m_Tip.ShowIt(btnThisYear, "所选日期不能超过当前时间！");
            }
            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();

            byWeekOrMonthOrYearB = (int)ByWeekOrMonthE.ByYear;

            tbBegRegB.Value = searchBegTime;
            tbEndRegB.Value = searchEndTime;
        }




        private void tbBegRegB_ValueChanged(object sender, EventArgs e)
        {
            searchBegTimeB = tbBegRegB.Value;
        }

        private void tbEndRegB_ValueChanged(object sender, EventArgs e)
        {
            searchEndTimeB = tbEndRegB.Value;
        }

        #endregion

        #endregion

        #region 注册统计
        private void btnSelectReg_Click(object sender, EventArgs e)
        {
            TimeSpan ts = tbBegReg.Value.Subtract(tbEndReg.Value);
            if (ts.Days > 31)
            {
                m_Tip.ShowItTop(tbEndReg, "相差时间不能大于一个月");
                return;
            }

            ////LoadData();
            //Thread thread1 = new Thread(new ThreadStart(run));
            //thread1.Start();

            Thread t2 = new Thread(() =>
            {
                LoadData("");
            });
            t2.Start();
        }

        //private void run()
        //{
        //pager1.Invoke(Loading_Data, new object[] { "" });
        //}

        private void LoadData(string var)//uu
        {
            try
            {
                //CreateChart(gcbUserAll); 
                this.UIThread(() =>
                {
                    picLoading.Visible = true;
                });

                //DataTable dtB = faceBLL.ListRegAnalysis_B();
                //BindUserALL(dtB);
                //BindRegType(dtB);
                //BindRoleReg(dtB);

                //DataTable dtZ = faceBLL.ListRegAnalysis_Z();
                //BindBuildingReg(dtZ);

                //DataSet dsX = faceBLL.ListRegAnalysis_X(searchBegTime, searchEndTime);
                //BindLine(dsX.Tables[0], dsX.Tables[1], dsX.Tables[2]);

                //DataSet ds = faceBLL.ListRegAnalysis(searchBegTime, searchEndTime);
                //if (ds != null)
                //{
                //    if (ds.Tables.Count > 3)
                //    {
                //        BindUserALL(ds.Tables[0]);
                //        BindRegType(ds.Tables[0]);
                //        BindRoleReg(ds.Tables[0]);
                //        BindBuildingReg(ds.Tables[1]);

                //        BindLine(ds.Tables[2], ds.Tables[3], ds.Tables[4]);
                //    }
                //}
            }
            catch
            {

            }
            finally
            {
                this.UIThread(() =>
                {
                    picLoading.Visible = false;
                });
            }
        }


        //delegate void dgvDelegate(DataSet ds);
        //private void SetDgvDataSource(DataSet ds)
        //{
        //    if (gcbUserAll.InvokeRequired)
        //    {
        //        Invoke(new dgvDelegate(SetDgvDataSource), new object[] { ds });
        //    }
        //    else
        //    {
        //        if (ds != null)
        //        {
        //            if (ds.Tables.Count > 3)
        //            {
        //                BindUserALL(ds.Tables[0]);
        //                BindRegType(ds.Tables[0]);
        //                BindRoleReg(ds.Tables[0]);
        //                BindBuildingReg(ds.Tables[1]);

        //                BindLine(ds.Tables[2], ds.Tables[3], ds.Tables[4]);
        //            }
        //        }
        //    }
        //}



        private void BindLine(DataTable clientCountByDayDT, DataTable WechatCountByDayDT, DataTable cardCountByDayDT)
        {
            #region 数据
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("theDay", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("clientCountByDay", System.Type.GetType("System.String")));//PC注册
            dt.Columns.Add(new DataColumn("WechatCountByDay", System.Type.GetType("System.String")));//微信
            dt.Columns.Add(new DataColumn("cardCountByDay", System.Type.GetType("System.String")));//刷卡

            DateTime beg = searchBegTime.Date;
            DateTime end = searchEndTime.Date;

            while (beg <= end)
            {
                try
                {
                    DataRow drVar = dt.NewRow();
                    drVar["theDay"] = beg.ToString("yyyy-MM-dd");
                    DataRow[] rowsClient = clientCountByDayDT.Select(string.Format("theDay='{0}'", drVar["theDay"].ToString().Replace("'", "''")));
                    DataRow[] rowsWechat = WechatCountByDayDT.Select(string.Format("theDay='{0}'", drVar["theDay"].ToString().Replace("'", "''")));
                    DataRow[] rowsCard = cardCountByDayDT.Select(string.Format("theDay='{0}'", drVar["theDay"].ToString().Replace("'", "''")));

                    if (rowsClient.Length > 0)
                    {
                        drVar["clientCountByDay"] = rowsClient[0]["clientCountByDay"].ToString();
                    }
                    else
                    {
                        drVar["clientCountByDay"] = "0";
                    }

                    if (rowsWechat.Length > 0)
                    {
                        drVar["WechatCountByDay"] = rowsWechat[0]["WechatCountByDay"].ToString();
                    }
                    else
                    {
                        drVar["WechatCountByDay"] = "0";
                    }

                    if (rowsCard.Length > 0)
                    {
                        drVar["cardCountByDay"] = rowsCard[0]["cardCountByDay"].ToString();
                    }
                    else
                    {
                        drVar["cardCountByDay"] = "0";
                    }

                    dt.Rows.Add(drVar);
                }
                catch
                { }
                finally
                {
                    beg = beg.AddDays(1);
                }
            }
            #endregion



            zgc.GraphPane.CurveList.Clear();

            GraphPane myPane = zgc.GraphPane;

            //设置标题
            myPane.Title.Text = "注册人数统计";
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //XY轴标题的字体
            myPane.XAxis.Title.Text = "时间";
            myPane.XAxis.Title.FontSpec.Size = 18f;
            myPane.XAxis.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);
            myPane.YAxis.Title.Text = "人数";
            myPane.YAxis.Title.FontSpec.Size = 18f;
            myPane.YAxis.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //XY轴值的字体
            myPane.XAxis.Scale.FontSpec.Size = 18f;
            myPane.XAxis.Scale.FontSpec.FontColor = Color.FromArgb(67, 152, 237);
            myPane.YAxis.Scale.FontSpec.Size = 18f;
            myPane.YAxis.Scale.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            myPane.Legend.FontSpec.Size = 18f;
            myPane.Legend.FontSpec.FontColor = Color.FromArgb(67, 152, 237);


            //设置外边框颜色
            myPane.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置最底下边框颜色
            myPane.Legend.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置内边框颜色
            myPane.Chart.Border.Color = Color.FromArgb(67, 152, 237);


            PointPairList clientList = new PointPairList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double x = i;
                clientList.Add(x, Convert.ToDouble(dt.Rows[i]["clientCountByDay"]));
            }

            PointPairList WechatList = new PointPairList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double x = i;
                WechatList.Add(x, Convert.ToDouble(dt.Rows[i]["WechatCountByDay"]));
            }

            PointPairList cardList = new PointPairList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double x = i;
                cardList.Add(x, Convert.ToDouble(dt.Rows[i]["cardCountByDay"]));
            }


            // 用list1生产一条曲线，标注是“东航”
            LineItem clientCurve = myPane.AddCurve("平台注册", clientList, Color.Green, SymbolType.Star);
            LineItem WechattCurve = myPane.AddCurve("微信注册", WechatList, Color.Black, SymbolType.Star);
            LineItem cardCurve = myPane.AddCurve("刷卡注册", cardList, Color.Blue, SymbolType.Star);

            //填充图表颜色
            myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);

            //以上生成的图标X轴为数字，下面将转换为日期的文本
            string[] labels = new string[dt.Rows.Count];
            DateTime strSub;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSub = Convert.ToDateTime(dt.Rows[i]["theDay"]);
                labels[i] = strSub.Month.ToString() + "\r\n月\r\n" + strSub.Day.ToString() + "\r\n日";
            }

            myPane.XAxis.Scale.TextLabels = labels; //X轴文本取值
            myPane.XAxis.Type = AxisType.Text;   //X轴类型


            // 设置背景色
            myPane.Chart.Fill = new Fill(Color.White, Color.White, 45.0F);
            myPane.Fill = new Fill(Color.White);

            //画到zedGraphControl1控件中，此句必加
            zgc.AxisChange();

            //重绘控件
            Refresh();


        }

        private void BindUserALL(DataTable table)
        {
            if (table == null) return;

            gcbUserAll.GraphPane.CurveList.Clear();
            gcbUserAll.GraphPane.GraphObjList.Clear();
            gcbUserAll.GraphPane.Title.Text = "人脸注册概况";
            gcbUserAll.GraphPane.Title.FontSpec.Size = 24f;//标题字体
            gcbUserAll.GraphPane.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //最底下的字体
            gcbUserAll.GraphPane.Legend.FontSpec.Size = 18f;
            gcbUserAll.GraphPane.Legend.FontSpec.FontColor = Color.DarkBlue; //Color.FromArgb(67, 152, 237);


            //gcbUserAll.GraphPane.Chart.Fill.IsVisible = false;
            //设置外边框颜色
            gcbUserAll.GraphPane.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置最底下边框颜色
            gcbUserAll.GraphPane.Legend.Border = new Border(Color.FromArgb(224, 224, 224), 2);

            double HaveRegPre = Math.Round(Convert.ToDouble(table.Rows[0]["HaveRegPre"]), 2);

            PieItem segment1 = gcbUserAll.GraphPane.AddPieSlice(HaveRegPre, Color.Green, Color.Black, 45f, 0, "已注册" + HaveRegPre.ToString() + "%");
            PieItem segment2 = gcbUserAll.GraphPane.AddPieSlice(100 - HaveRegPre, Color.Gray, Color.White, 45f, 0, "未注册" + (100 - HaveRegPre).ToString() + "%");

            //设置提示字体大小
            segment1.LabelDetail.FontSpec.Size = 16f;
            segment1.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment1.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            segment2.LabelDetail.FontSpec.Size = 16f;
            segment2.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment2.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);


            // 设置背景色
            gcbUserAll.GraphPane.Chart.Fill = new Fill(Color.White, Color.White, 45.0F);
            gcbUserAll.GraphPane.Fill = new Fill(Color.White);
            //gcbUserAll.GraphPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 1200F);
            //gcbUserAll.GraphPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            gcbUserAll.GraphPane.Legend.Position = LegendPos.BottomCenter;
            gcbUserAll.GraphPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.AxisXY2Scale, AlignH.Center, AlignV.Bottom);

            gcbUserAll.AxisChange();
            gcbUserAll.Refresh();

        }


        private void BindRegType(DataTable table)
        {
            if (table == null) return;

            gcbRegType.GraphPane.CurveList.Clear();
            gcbRegType.GraphPane.GraphObjList.Clear();
            gcbRegType.GraphPane.Title.Text = "注册方式占比";
            gcbRegType.GraphPane.Title.FontSpec.Size = 24f;//标题字体
            gcbRegType.GraphPane.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //最底下的字体
            gcbRegType.GraphPane.Legend.FontSpec.Size = 18f;
            gcbRegType.GraphPane.Legend.FontSpec.FontColor = Color.DarkBlue;

            //设置外边框颜色
            gcbRegType.GraphPane.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置最底下边框颜色
            gcbRegType.GraphPane.Legend.Border = new Border(Color.FromArgb(224, 224, 224), 2);


            double ClientRegPre = Math.Round(Convert.ToDouble(table.Rows[0]["ClientRegPre"]), 2);
            double WechatRegPre = Math.Round(Convert.ToDouble(table.Rows[0]["WechatRegPre"]), 2);
            double ReadCardRegPre = Math.Round(Convert.ToDouble(table.Rows[0]["ReadCardRegPre"]), 2);
            //ClientRegPre = 10;
            //WechatRegPre = 50;
            //ReadCardRegPre = 80;
            PieItem segment1 = gcbRegType.GraphPane.AddPieSlice(ClientRegPre, Color.LightBlue, Color.White, 45f, 0, "平台注册" + ClientRegPre.ToString() + "%");
            PieItem segment2 = gcbRegType.GraphPane.AddPieSlice(WechatRegPre, Color.LimeGreen, Color.White, 45f, 0, "微信注册" + WechatRegPre.ToString() + "%");
            PieItem segment3 = gcbRegType.GraphPane.AddPieSlice(ReadCardRegPre, Color.Purple, Color.White, 45f, 0, "刷卡注册" + ReadCardRegPre.ToString() + "%");

            //设置提示字体大小
            segment1.LabelDetail.FontSpec.Size = 16f;
            segment1.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment1.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            segment2.LabelDetail.FontSpec.Size = 16f;
            segment2.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment2.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            segment3.LabelDetail.FontSpec.Size = 16f;
            segment3.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment3.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);

            #region
            //double theDisplacement = 0;
            //string strSub;
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        theDisplacement = 0;
            //    }
            //    else
            //    {
            //        theDisplacement = 0.2;
            //    }

            //    strSub = table.Rows[i]["theTile"].ToString().Trim();
            //    if (strSub.Length > 12)
            //    {
            //        gcbRegType.GraphPane.AddPieSlice(Convert.ToDouble(table.Rows[i]["theValue"]), getRandomColor(), Color.White, 45f, theDisplacement, strSub.Substring(0, 12) + "...");
            //    }
            //    else
            //    {
            //        gcbRegType.GraphPane.AddPieSlice(Convert.ToDouble(table.Rows[i]["theValue"]), getRandomColor(), Color.White, 45f, theDisplacement, strSub);
            //    }
            //}
            #endregion

            // 设置背景色
            gcbRegType.GraphPane.Chart.Fill = new Fill(Color.White, Color.White, 45.0F);
            gcbRegType.GraphPane.Fill = new Fill(Color.White);
            //gcbRegType.GraphPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 1200F);
            //gcbRegType.GraphPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            gcbRegType.GraphPane.Legend.Position = LegendPos.BottomCenter;
            gcbRegType.GraphPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.AxisXY2Scale, AlignH.Center, AlignV.Bottom);



            gcbRegType.AxisChange();
            gcbRegType.Refresh();
        }

        private void BindRoleReg(DataTable table)
        {
            if (table == null) return;

            gcRoleRegPre.GraphPane.CurveList.Clear();
            gcRoleRegPre.GraphPane.GraphObjList.Clear();
            gcRoleRegPre.GraphPane.Title.Text = "角色比例";
            gcRoleRegPre.GraphPane.Title.FontSpec.Size = 24f;//标题字体
            gcRoleRegPre.GraphPane.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //最底下的字体
            gcRoleRegPre.GraphPane.Legend.FontSpec.Size = 18f;
            gcRoleRegPre.GraphPane.Legend.FontSpec.FontColor = Color.DarkBlue;

            //设置外边框颜色
            gcRoleRegPre.GraphPane.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置最底下边框颜色
            gcRoleRegPre.GraphPane.Legend.Border = new Border(Color.FromArgb(224, 224, 224), 2);

            double userRegPre = Math.Round(Convert.ToDouble(table.Rows[0]["userRegPre"]), 2);
            double mangRegPre = Math.Round(Convert.ToDouble(table.Rows[0]["mangRegPre"]), 2);
            double customRegPre = Math.Round(Convert.ToDouble(table.Rows[0]["customRegPre"]), 2);
            double fimRegPre = Math.Round(Convert.ToDouble(table.Rows[0]["fimRegPre"]), 2);

            //userRegPre =60;
            //mangRegPre = 5;
            //customRegPre = 10;
            //fimRegPre = 25;

            PieItem segment1 = gcRoleRegPre.GraphPane.AddPieSlice(userRegPre, Color.LimeGreen, Color.White, 45f, 0, "业主" + userRegPre.ToString() + "%");
            PieItem segment2 = gcRoleRegPre.GraphPane.AddPieSlice(mangRegPre, Color.LightBlue, Color.White, 45f, 0, "物业管理" + mangRegPre.ToString() + "%");
            PieItem segment3 = gcRoleRegPre.GraphPane.AddPieSlice(customRegPre, Color.Purple, Color.White, 45f, 0, "访客" + customRegPre.ToString() + "%");
            PieItem segment4 = gcRoleRegPre.GraphPane.AddPieSlice(fimRegPre, Color.Navy, Color.White, 45f, 0, "家庭成员" + fimRegPre.ToString() + "%");

            //设置提示字体大小
            segment1.LabelDetail.FontSpec.Size = 16f;
            segment1.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment1.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            segment2.LabelDetail.FontSpec.Size = 16f;
            segment2.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment2.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            segment3.LabelDetail.FontSpec.Size = 16f;
            segment3.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment3.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            segment4.LabelDetail.FontSpec.Size = 16f;
            segment4.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment4.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);

            // 设置背景色
            gcRoleRegPre.GraphPane.Chart.Fill = new Fill(Color.White, Color.White, 45.0F);
            gcRoleRegPre.GraphPane.Fill = new Fill(Color.White);
            //gcRoleRegPre.GraphPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 1200F);
            //gcRoleRegPre.GraphPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            gcRoleRegPre.GraphPane.Legend.Position = LegendPos.BottomCenter;
            gcRoleRegPre.GraphPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.AxisXY2Scale, AlignH.Center, AlignV.Bottom);



            gcRoleRegPre.AxisChange();
            gcRoleRegPre.Refresh();
        }

        private void BindBuildingReg(DataTable table)
        {
            //有数据的显示。。。
            if (table == null) return;
            this.gcBuildingReg.GraphPane.CurveList.Clear();
            GraphPane mypane = this.gcBuildingReg.GraphPane;

            //mypane.BarSettings.ClusterScaleWidthAuto = false;
            //mypane.BarSettings.ClusterScaleWidth = 2.5;

            mypane.Title.Text = "各楼栋业主注册概况";
            mypane.Title.FontSpec.Size = 12f;//标题字体
            mypane.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //X轴标题的字体
            mypane.XAxis.Title.Text = "";
            mypane.XAxis.Title.FontSpec.Size = 9f;
            mypane.XAxis.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //Y轴标题的字体
            mypane.YAxis.Title.Text = "注\n册\n比\n率\nn%";
            mypane.YAxis.Title.FontSpec.Size = 9f;//标题字体
            mypane.YAxis.Title.FontSpec.Angle = 90;//设置Y标题顺时针旋转90度
            mypane.YAxis.Scale.MajorStep = 10;//Y的刻度 10%

            //XY轴值的字体
            mypane.XAxis.Scale.FontSpec.Size = 9f; //X的字体大小 10
            mypane.XAxis.Scale.FontSpec.FontColor = Color.FromArgb(67, 152, 237);
            mypane.YAxis.Scale.FontSpec.Size = 9f; //X的字体大小 10
            mypane.YAxis.Scale.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //最底下的字体
            mypane.Legend.FontSpec.Size = 9f;
            mypane.Legend.FontSpec.FontColor = Color.DarkBlue;

            mypane.YAxis.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);


            //设置外边框颜色
            mypane.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置最底下边框颜色
            mypane.Legend.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置内边框颜色
            mypane.Chart.Border.Color = Color.FromArgb(67, 152, 237);


            int n = table.Rows.Count;
            if (n > 25)
            {
                n = 25;
            }

            string[] labels = new string[n];
            string strSub;
            for (int i = 0; i < n; i++)
            {
                strSub = table.Rows[i]["building_name"].ToString().Trim();

                char[] charArr = strSub.ToCharArray();
                StringBuilder sb = new StringBuilder();
                foreach (char c in charArr)
                {
                    if (c != '(' && c != ')' && c != '（' && c != '）')
                    {
                        sb.Append(c);
                        sb.Append("\r\n");
                    }
                }
                labels[i] = sb.ToString();
                //labels[i] = "我\r\n们\r\n开\r\n始\r\n投\r\n票";////让X坐标名字竖着显示  
            }


            for (int i = 0; i < n; i++)
            {
                double[] yy = new double[n];
                double[] xx = new double[n];
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        yy[j] = Convert.ToDouble(table.Rows[i]["buildingRegUserPre"]);
                    }
                    else
                    {
                        yy[j] = 0;
                    }
                }
                Color theColor = getRandomColor();
                BarItem myBar;
                strSub = table.Rows[i]["building_name"].ToString().Trim();
                if (strSub.Length > 12)
                {
                    myBar = mypane.AddBar(strSub.Substring(0, 12) + "...", null, yy, theColor);
                }
                else
                {
                    myBar = mypane.AddBar(strSub, null, yy, theColor);
                }
                myBar.Bar.Fill = new Fill(theColor, Color.White, theColor);
            }

            #region 为每个“柱子”上方添加值标签
            for (int i = 0; i < n; i++)
            {
                double Y = Math.Round(Convert.ToDouble(table.Rows[i]["buildingRegUserPre"]), 2);
                if (Y > 0)
                {
                    TextObj text = new TextObj(Y.ToString() + "%", (i + 1), Y + 0.5);

                    text.FontSpec.Border.IsVisible = false;
                    text.FontSpec.Fill.IsVisible = false;
                    text.FontSpec.FontColor = Color.DarkBlue;

                    mypane.GraphObjList.Add(text);
                }
            }
            mypane.BarSettings.Type = BarType.SortedOverlay;
            #endregion

            // 设置背景色
            mypane.Chart.Fill = new Fill(Color.White, Color.White, 45.0F);
            mypane.Fill = new Fill(Color.White);
            //mypane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 1200F);
            //mypane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            mypane.Legend.Position = LegendPos.BottomCenter;
            mypane.Legend.Location = new Location(0.95f, 0.15f, CoordType.AxisXY2Scale, AlignH.Center, AlignV.Bottom);

            mypane.BarSettings.ClusterScaleWidth = 80;
            // Bars are stacked
            mypane.BarSettings.Type = ZedGraph.BarType.Overlay;


            mypane.XAxis.MajorTic.IsBetweenLabels = true;
            mypane.XAxis.Scale.TextLabels = labels;
            mypane.XAxis.Type = AxisType.Text;
            mypane.XAxis.Scale.MajorStep = 1;
            mypane.XAxis.Scale.MinorStep = 1;

            gcBuildingReg.AxisChange();
            gcBuildingReg.Refresh();
        }
        #endregion


        #region 通行统计
        private void btnSelectRegB_Click(object sender, EventArgs e)
        {
            TimeSpan ts = tbBegRegB.Value.Subtract(tbEndRegB.Value);
            if (System.Math.Abs(ts.Days) > 31)
            {
                m_Tip.ShowItTop(tbEndRegB, "相差时间不能大于一个月");
                return;
            }
            ////LoadDataB();
            ////this.pager1.FirstBind();
            //Thread thread1 = new Thread(new ThreadStart(run_B));
            //thread1.Start();
            run_B();

        }

        private void run_B()
        {
            //pager1.Invoke(Loading_Data_B, new object[] { "" });
            Thread t2 = new Thread(() =>
            {
                LoadDataB(string.Empty);
            });
            t2.Start();
        }
        private void LoadDataB(string var)//uu
        {
            try
            {
                this.UIThread(() =>
                {
                    picLoading2.Visible = true;
                });

                //DataSet ds = faceBLL.ListInAnalysis(searchBegTimeB, searchEndTimeB);
                //if (ds != null)
                //{
                //    if (ds.Tables.Count == 3)
                //    {
                //        BindInType(ds.Tables[0]);
                //        BindLineInByDay(ds.Tables[1], ds.Tables[2]);
                //    }
                //}

                this.pager1.Bind();
            }
            catch
            {

            }
            finally
            {
                this.UIThread(() =>
                {
                    picLoading2.Visible = false;
                });
            }
        }


        private void BindInType(DataTable table)
        {
            if (table == null) return;

            gcInType.GraphPane.CurveList.Clear();
            gcInType.GraphPane.GraphObjList.Clear();

            //设置标题
            gcInType.GraphPane.Title.Text = "刷脸开门占比";
            gcInType.GraphPane.Title.FontSpec.Size = 18f;//标题字体
            gcInType.GraphPane.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //最底下的字体
            gcInType.GraphPane.Legend.FontSpec.Size = 14f;
            gcInType.GraphPane.Legend.FontSpec.FontColor = Color.DarkBlue;


            //设置外边框颜色
            gcInType.GraphPane.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置最底下边框颜色
            gcInType.GraphPane.Legend.Border = new Border(Color.FromArgb(224, 224, 224), 2);



            double FaceOpenPre = Math.Round(Convert.ToDouble(table.Rows[0]["FaceOpenPre"]), 2);
            double ReadCardOpenPre = Math.Round(Convert.ToDouble(table.Rows[0]["ReadCardOpenPre"]), 2);
            //FaceOpenPre = 60;
            PieItem segment1 = gcInType.GraphPane.AddPieSlice(FaceOpenPre, Color.LightBlue, Color.White, 45f, 0, "人脸识别" + FaceOpenPre.ToString() + "%");
            PieItem segment2 = gcInType.GraphPane.AddPieSlice(100 - FaceOpenPre, Color.LimeGreen, Color.White, 45f, 0, "刷卡开门" + ReadCardOpenPre.ToString() + "%");

            //设置提示字体大小
            segment1.LabelDetail.FontSpec.Size = 12f;
            segment1.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment1.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            segment2.LabelDetail.FontSpec.Size = 12f;
            segment2.LabelDetail.FontSpec.FontColor = Color.DarkBlue;
            segment2.LabelDetail.FontSpec.Border = new Border(Color.FromArgb(224, 224, 224), 2);


            // 设置背景色
            gcInType.GraphPane.Chart.Fill = new Fill(Color.White, Color.White, 45.0F);
            gcInType.GraphPane.Fill = new Fill(Color.White);
            //gcInType.GraphPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 1200F);
            //gcInType.GraphPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            gcInType.GraphPane.Legend.Position = LegendPos.BottomCenter;
            gcInType.GraphPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.AxisXY2Scale, AlignH.Center, AlignV.Bottom);

            gcInType.AxisChange();
            gcInType.Refresh();

        }

        private void BindLineInByDay(DataTable faceOpenCountByDayDT, DataTable readCardOpenCountByDayDT)
        {
            #region 数据
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("theDay", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("faceOpenCountByDay", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("readCardOpenCountByDay", System.Type.GetType("System.String")));

            DateTime beg = searchBegTime.Date;
            DateTime end = searchEndTime.Date;

            while (beg <= end)
            {
                try
                {
                    DataRow drVar = dt.NewRow();
                    drVar["theDay"] = beg.ToString("yyyy-MM-dd");
                    DataRow[] rowsFace = faceOpenCountByDayDT.Select(string.Format("theDay='{0}'", drVar["theDay"].ToString().Replace("'", "''")));
                    DataRow[] rowsCard = readCardOpenCountByDayDT.Select(string.Format("theDay='{0}'", drVar["theDay"].ToString().Replace("'", "''")));

                    if (rowsFace.Length > 0)
                    {
                        drVar["faceOpenCountByDay"] = rowsFace[0]["faceOpenCountByDay"].ToString();
                    }
                    else
                    {
                        drVar["faceOpenCountByDay"] = "0";
                    }

                    if (rowsCard.Length > 0)
                    {
                        drVar["readCardOpenCountByDay"] = rowsCard[0]["readCardOpenCountByDay"].ToString();
                    }
                    else
                    {
                        drVar["readCardOpenCountByDay"] = "0";
                    }

                    dt.Rows.Add(drVar);
                }
                catch
                { }
                finally
                {
                    beg = beg.AddDays(1);
                }
            }
            #endregion



            gcInByDay.GraphPane.CurveList.Clear();

            GraphPane myPane = gcInByDay.GraphPane;

            //设置标题
            myPane.Title.Text = "开门方式统计";
            myPane.Title.FontSpec.Size = 18f;
            myPane.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);


            //XY轴标题
            myPane.XAxis.Title.Text = "时间";
            myPane.XAxis.Title.FontSpec.Size = 12f;
            myPane.XAxis.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);
            myPane.YAxis.Title.Text = "人次";
            myPane.YAxis.Title.FontSpec.Size = 12f;
            myPane.YAxis.Title.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //XY轴值的字体
            myPane.XAxis.Scale.FontSpec.Size = 12f;
            myPane.XAxis.Scale.FontSpec.FontColor = Color.FromArgb(67, 152, 237);
            myPane.YAxis.Scale.FontSpec.Size = 12f;
            myPane.YAxis.Scale.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //最底下的字体
            myPane.Legend.FontSpec.Size = 12f;
            myPane.Legend.FontSpec.FontColor = Color.FromArgb(67, 152, 237);

            //设置外边框颜色
            myPane.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置最底下边框颜色
            myPane.Legend.Border = new Border(Color.FromArgb(224, 224, 224), 2);
            //设置内边框颜色
            myPane.Chart.Border.Color = Color.FromArgb(67, 152, 237);

            PointPairList faceList = new PointPairList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double x = i;
                faceList.Add(x, Convert.ToDouble(dt.Rows[i]["faceOpenCountByDay"]));
            }

            PointPairList cardList = new PointPairList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double x = i;
                cardList.Add(x, Convert.ToDouble(dt.Rows[i]["readCardOpenCountByDay"]));
            }


            // 用list1生产一条曲线，标注是“东航”
            LineItem faceCurve = myPane.AddCurve("刷脸开门", faceList, Color.Green, SymbolType.Star);
            LineItem cardCurve = myPane.AddCurve("刷卡开门", cardList, Color.Blue, SymbolType.Plus);

            //填充图表颜色
            myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);

            //以上生成的图标X轴为数字，下面将转换为日期的文本
            string[] labels = new string[dt.Rows.Count];
            DateTime strSub;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSub = Convert.ToDateTime(dt.Rows[i]["theDay"]);
                labels[i] = strSub.Month.ToString() + "\r\n月\r\n" + strSub.Day.ToString() + "\r\n日";
            }

            myPane.XAxis.Scale.TextLabels = labels; //X轴文本取值
            myPane.XAxis.Type = AxisType.Text;   //X轴类型

            // 设置背景色
            myPane.Chart.Fill = new Fill(Color.White, Color.White, 45.0F);
            myPane.Fill = new Fill(Color.White);

            //画到zedGraphControl1控件中，此句必加
            gcInByDay.AxisChange();

            //重绘控件
            Refresh();


        }
        #endregion

        #region 业主人脸注册分页
        int pager1_getNMaxEvent()
        {
            //return faceBLL.ListInCount(searchBegTimeB, searchEndTimeB);
            return 0;
        }

        DataTable pager1_getPageingEvent(int pageIndex, int pageSize)
        {
            DataTable table = null;
            //try
            //{
            //    table = faceBLL.ListIn(pageIndex, pageSize, searchBegTimeB, searchEndTimeB);
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.Error(ex);
            //}
            return table;
        }

        #endregion 分页


        #region 颜色
        Random random = new Random();
        private Color getRandomColor()
        {
            int i, j, k;

            return Color.FromArgb(i = random.Next(0, 255), j = random.Next(0, 255), k = random.Next(0, 255));
        }
        #endregion

        #region
        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((System.Windows.Forms.Panel)sender).ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
            //ControlPaint.DrawBorder(e.Graphics, ((Panel)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }
        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((System.Windows.Forms.Panel)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((System.Windows.Forms.Panel)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((System.Windows.Forms.Panel)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((System.Windows.Forms.Panel)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((System.Windows.Forms.Panel)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((System.Windows.Forms.Panel)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }
        #endregion


    }

    public enum ByWeekOrMonthE
    {
        ByWeek = 1,
        ByMonth = 2,
        ByYear = 3
    }
}
