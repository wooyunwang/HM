using AutoMapper;
using HM.Face.Common_.EyeCool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Face.Common_
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<EyeCoolDtoMappingProfile>());
            Mapper.AssertConfigurationIsValid();
        }
    }
}
