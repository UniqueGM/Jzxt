using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Jzxt.Model
{
    public class Orgnization
    {
        public string orgnization_id { get; set; }

        public string father_id { get; set; }
        public string orgnization_father_name { get; set; }
        public string name { get; set; }

        public string descripe { get; set; }

        public string orgnization_type_id { get; set; }

        public string orgnization_type_name { get; set; }

        public string note { get; set; }

        public string sub_system { get; set; }

        public string organization_level_id { get; set; }
        public string organization_level_name { get; set; }
    }
}
