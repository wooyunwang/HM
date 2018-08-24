using AutoMapper;
using HM.Enum_.FacePlatform;
using HM.Face.Common_.EyeCool;
using HM.Utils_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HM.Face.Common_.Tests
{
    [TestClass()]
    public class EyeCoolFaceTests
    {
        Face api { get; set; }
        IMapper mapper;

        public EyeCoolFaceTests()
        {
            log4net.Config.XmlConfigurator.Configure();
            Mapper.Reset();
            AutoMapperConfiguration.Configure();

            api = FaceFactory.CreateFace("192.168.1.180", 8080, FaceVender.EyeCool);
            bool isNetOK = api.VisualTelnet("192.168.1.180", 8080);
            if (!isNetOK)
            {
                Assert.Fail("目标网络端口不通畅，测了也是白测");
            }
        }

        [TestMethod()]
        public void CheckingTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Picture", "male.jpg");
            if (File.Exists(path))
            {
                var result = api.Checking(
                    Key_.SequentialGuid(),
                    RegisterType.手动注册,
                    path,
                    "单元测试"
                    );
            }
            else
            {
                Assert.Fail("找不到测试图片");
            }
        }

        [TestMethod()]
        public void MatchCompareTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MatchCompare1Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MatchCompare2Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RegisterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetRegisterPageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReviewTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetFacePassDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FaceDelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateActiveTimeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PersonCardSnapshotTest()
        {
            Assert.Fail();
        }
    }
}