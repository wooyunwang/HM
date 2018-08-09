using Microsoft.VisualStudio.TestTools.UnitTesting;
using HM.Face.Common_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HM.Utils_;

namespace HM.Face.Common_.Tests
{
    [TestClass()]
    public class EyeCoolFaceTests
    {
        Face api { get; set; }
        public EyeCoolFaceTests()
        {
            log4net.Config.XmlConfigurator.Configure();
            api = FaceFactory.CreateFace("192.168.1.180", 8080, FaceVender.EyeCool);
        }

        [TestMethod()]
        public void CheckingTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Picture", "male.jpg");
            if (File.Exists(path))
            {
                var result = api.Checking(
                    RandomGenerator.SequentialGuid(),
                    RegisterType.手动注册,
                    Image_.ImageToBase64(path),
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