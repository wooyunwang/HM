using HM.Enum_.FacePlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO.FacePlatform
{
    public class CheckNoteDto
    {
        public string house_name { get; set; }

        public UserType user_type { get; set; }

        public string relation { get; set; }

        public string user_name { get; set; }
        public DateTime reg_time { get; set; }
        public string check_note { get; set; }

        public int check_by { get; set; }

        public string check_by_name { get; set; }

        public DateTime check_time { get; set; }
    }
}
