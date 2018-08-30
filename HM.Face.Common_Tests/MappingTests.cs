using AutoMapper;
using HM.Enum_.FacePlatform;
using HM.Face.Common_;
using HM.Face.Common_.EyeCool;
using HM.Utils_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using HM.FacePlatform.Client;
using HM.FacePlatform.Server;

namespace HM.Face.Common_Tests
{


    [TestClass()]
    public class MappingTests
    {
        public MappingTests()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestMethod()]
        public void EyeCoolMappingValidTest()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EyeCoolDtoMappingProfile>();
            });
            Mapper.AssertConfigurationIsValid();
        }
        [TestMethod()]
        public void ClientMappingValidTest()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<FacePlatform.Client.DtoMappingProfile>();
            });
            Mapper.AssertConfigurationIsValid();
        }
        [TestMethod()]
        public void ServerMappingValidTest()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<FacePlatform.Server.DtoMappingProfile>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
