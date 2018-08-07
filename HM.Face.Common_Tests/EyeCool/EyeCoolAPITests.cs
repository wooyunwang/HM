using Microsoft.VisualStudio.TestTools.UnitTesting;
using HM.Face.Common_.EyeCool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using HM.Utils_;
using System.IO;

namespace HM.Face.Common_.EyeCool.Tests
{
    [TestClass()]
    public class EyeCoolAPITests
    {
        EyeCoolAPI api { get; set; }
        public EyeCoolAPITests()
        {
            SetZhCnCulturInfo();
            api = new EyeCoolAPI("192.168.1.180", 8080);
        }
        /// <summary>
        /// 中文区域性初始化
        /// </summary>
        void SetZhCnCulturInfo()
        {
            CultureInfo cultureInfo = new CultureInfo("zh-CN");
            cultureInfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            cultureInfo.DateTimeFormat.LongDatePattern = "yyyy-MM-dd HH:mm:ss";
            cultureInfo.DateTimeFormat.ShortTimePattern = "HH:mm";
            cultureInfo.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        [TestMethod()]
        public void PeopleCreateTest()
        {
            var input = new PeopleCreateInput()
            {
                activeTime = DateTime.Now.AddHours(1),
                birthday = DateTime.Now,
                cardNo = Guid.Empty.ToString(),
                cid = CertificateType.业主卡,
                cNO = "1",
                crowd_name = "00000000",
                fNo = "506",
                people_id = "",
                people_name = "蔡泽智",
                phone = "15112296572",
                rctype = RCType.手动注册,
                sex = 1,
                tip = "拥有"
            };
            var result = api.PeopleCreate(input).Result;
        }

        [TestMethod()]
        public void CheckingTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Picture", "male.jpg");
            if (File.Exists(path))
            {
                var input = new CheckingInput()
                {
                    face_id = RandomGenerator.SequentialGuid(),
                    file = Image_.ImageToBase64(path),
                    rctype = RCType.手动注册,
                    tip = "单元测试"
                };
                var result = api.Checking(input).Result;
            }
            else
            {
                Assert.Fail("找不到测试图片");
            }
        }

        [TestMethod()]
        public void PeopleAddTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Picture", "male.jpg");
            if (File.Exists(path))
            {
                var input0 = new PeopleCreateInput()
                {
                    activeTime = DateTime.Now.AddHours(1),
                    birthday = DateTime.Now,
                    cardNo = Guid.Empty.ToString(),
                    cid = CertificateType.业主卡,
                    cNO = "1",
                    crowd_name = "00000000",
                    fNo = "506",
                    people_id = "",
                    people_name = "蔡泽智",
                    phone = "15112296572",
                    rctype = RCType.手动注册,
                    sex = 1,
                    tip = "拥有"
                };
                var result0 = api.PeopleCreate(input0).Result;
                if (result0.res_code_enum == ResponseCode._0000)
                {
                    var input1 = new CheckingInput()
                    {
                        face_id = RandomGenerator.SequentialGuid(),
                        file = Image_.ImageToBase64(path),
                        rctype = RCType.手动注册,
                        tip = "单元测试"
                    };
                    var result1 = api.Checking(input1).Result;
                    if (result1.res_code_enum == ResponseCode._0000)
                    {
                        if (result1.face != null && result1.face.Any())
                        {
                            var result2 = api.PeopleAdd(new PeopleAddInput()
                            {
                                face_id = result1.face[0].face_id,
                                is_audit = true,
                                people_id = result0.people_id
                            }).Result;
                            if (result2.res_code_enum == ResponseCode._0000)
                            {

                            }
                            else
                            {
                                Assert.Fail(result2.res_msg);
                            }
                        }
                        else
                        {
                            Assert.Fail("图片检查返回结果缺少face信息！");
                        }
                    }
                    else
                    {
                        Assert.Fail(result1.res_msg);
                    }
                }
                else
                {
                    Assert.Fail(result0.res_msg);
                }
            }
            else
            {
                Assert.Fail("找不到测试图片");
            }
        }

        [TestMethod()]
        public void CrowdCreateTest()
        {
            var input = new CrowdCreateInput()
            {
                crowd_name = "00000000",
                tip = "单元测试项目"
            };
            var result = api.CrowdCreate(input).Result;
        }

        [TestMethod()]
        public void CrowdAddTest()
        {
            var input0 = new PeopleCreateInput()
            {
                activeTime = DateTime.Now.AddHours(1),
                birthday = DateTime.Now,
                cardNo = Guid.Empty.ToString(),
                cid = CertificateType.业主卡,
                cNO = "1",
                crowd_name = "00000000",
                fNo = "506",
                people_id = "",
                people_name = "蔡泽智",
                phone = "15112296572",
                rctype = RCType.手动注册,
                sex = 1,
                tip = "拥有"
            };
            var result0 = api.PeopleCreate(input0).Result;
            if (result0.res_code_enum == ResponseCode._0000)
            {
                var input1 = new CrowdAddInput()
                {
                    crowd_name = "00000000",
                    people_id = result0.people_id
                };
                //crowd_name为空字符串时：“API接口错误:Index: 0, Size: 0”
                //people_id为空字符串时：“API接口错误:Index: 0, Size: 0”
                //重复执行时，达到期望
                var result1 = api.CrowdAdd(input1).Result;

                if (result1.res_code_enum == ResponseCode._0000)
                {
                    Assert.IsTrue(result1.res_code_enum == ResponseCode._0000);
                }
                else
                {
                    Assert.Fail(result1.res_msg);
                }
            }
            else
            {
                Assert.Fail(result0.res_msg);
            }
        }

        [TestMethod()]
        public void GetRegisterDataTest()
        {
            var input0 = new GetRegisterDataInput()
            {
                crowd_name = "00000000",
                dataType = null,
                pageNumber = 1,
                pageSize = 50,
                endtime = null,
                rctype = null,
                updateTime = DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd")
            };
            var result0 = api.GetRegisterData(input0).Result;

            var input1 = new GetRegisterDataInput()
            {
                //0 -注册审核已通过数据，1-注册审核未通过数据，2-注册待审核数据
                crowd_name = null,
                dataType = new List<int>() { 0, 1, 2 }.ToArray(),
                pageNumber = 1,
                pageSize = 50,
                endtime = null,
                rctype = RCType.手动注册,
                updateTime = DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd")
            };
            var result1 = api.GetRegisterData(input1).Result;
        }

        [TestMethod()]
        public void ReviewPeopleTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Picture", "male.jpg");
            if (File.Exists(path))
            {
                var input0 = new PeopleCreateInput()
                {
                    activeTime = DateTime.Now.AddHours(1),
                    birthday = DateTime.Now,
                    cardNo = Guid.Empty.ToString(),
                    cid = CertificateType.业主卡,
                    cNO = "1",
                    crowd_name = "00000000",
                    fNo = "506",
                    people_id = "",
                    people_name = "蔡泽智",
                    phone = "15112296572",
                    rctype = RCType.手动注册,
                    sex = 1,
                    tip = "拥有"
                };
                var result0 = api.PeopleCreate(input0).Result;
                if (result0.res_code_enum == ResponseCode._0000)
                {
                    var input1 = new CheckingInput()
                    {
                        face_id = RandomGenerator.SequentialGuid(),
                        file = Image_.ImageToBase64(path),
                        rctype = RCType.手动注册,
                        tip = "单元测试"
                    };
                    var result1 = api.Checking(input1).Result;
                    if (result1.res_code_enum == ResponseCode._0000)
                    {
                        if (result1.face != null && result1.face.Any())
                        {
                            var result2 = api.PeopleAdd(new PeopleAddInput()
                            {
                                face_id = result1.face[0].face_id,
                                is_audit = true,
                                people_id = result0.people_id
                            }).Result;
                            if (result2.res_code_enum == ResponseCode._0000)
                            {
                                var result3 = api.ReviewPeople(new ReviewPeopleInput()
                                {
                                    comments = "单元测试",
                                    crowd_name = "",
                                    people_id = result0.people_id,
                                    state = ReviewState.不通过
                                }).Result;

                                if (result3.res_code_enum == ResponseCode._0000)
                                {
                                    Assert.IsTrue(result3.res_code_enum == ResponseCode._0000);
                                }
                                else
                                {
                                    Assert.Fail(result3.res_msg);
                                }
                            }
                            else
                            {
                                Assert.Fail(result2.res_msg);
                            }
                        }
                        else
                        {
                            Assert.Fail("图片检查返回结果缺少face信息！");
                        }
                    }
                    else
                    {
                        Assert.Fail(result1.res_msg);
                    }
                }
                else
                {
                    Assert.Fail(result0.res_msg);
                }
            }
            else
            {
                Assert.Fail("找不到测试图片");
            }
        }

        [TestMethod()]
        public void ReviewPeopleTest2()
        {
            var result4 = api.ReviewPeople(new ReviewPeopleInput()
            {
                comments = "单元测试1",
                crowd_name = "",
                people_id = "e8cfc9b179b44bd1a1e5f4eb673a05b6",
                state = ReviewState.待审核
            }).Result;
        }



        [TestMethod()]
        public void CurrentDetailTest()
        {
            var input = new CurrentDetailInput()
            {
                updateTime = DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd"),
                endtime = DateTime.Now.ToString("yyyy-MM-dd"),
                pageNumber = 1,
                pageSize = 50,
                crowdname = ""
            };
            var result = api.CurrentDetail(input).Result;
        }

        [TestMethod()]
        public void PeopleDeleteTest()
        {
            var input = new PeopleDeleteInput()
            {
                people_id = "5708314bf980474a978b68e436d55944"
            };
            var result1 = api.PeopleDelete(input).Result;

            var result2 = api.PeopleDelete(input, false).Result;
        }

        [TestMethod()]
        public void PeopleRemoveTest()
        {
            var input = new PeopleRemoveInput()
            {
                people_id = "e8cfc9b179b44bd1a1e5f4eb673a05b6",
                faceIds = new List<string>() { "e2080713-3532-44f2-a619-24acf3f1ab03" }
            };
            var result1 = api.PeopleRemove(input).Result;

            var result2 = api.PeopleRemove(input, false).Result;
        }

        [TestMethod()]
        public void PeopleUpdateTest()
        {
            var input = new PeopleUpdateInput()
            {
                people_id = "e8cfc9b179b44bd1a1e5f4eb673a05b6",
                activeTime = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd 23:59:59"),
                phone = "15112296571"
            };
            var result1 = api.PeopleUpdate(input).Result;
        }

        [TestMethod()]
        public void MatchCompareTest()
        {
            var input = new MatchCompareInput()
            {
                face_id1 = "be3912ee-98ae-40c0-8c02-717bb1515751",
                face_id2 = "0b4c487c0c894421984da11b06ce0f0f",
            };
            var result1 = api.MatchCompare(input).Result;
        }

        [TestMethod()]
        public void PersonCardSnapshotTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Picture", "male.jpg");
            if (File.Exists(path))
            {
                var input = new PersonCardSnapshotInput(path);
                var result1 = api.PersonCardSnapshot(input).Result;
            }
            else
            {
                Assert.Fail("找不到单元测试所需图片");
            }
        }
    }
}