using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Jzxt.Model
{
    public  class User
    {
        public string user_id { get; set; }
        
        public string nick_name { get; set; }

        public string user_pwd { get; set; }

        public string email { get; set; }

        public string phone { get; set; }
        
        public string user_type_id { get; set; }

        public string note { get; set; }

        public DateTime register_date { get; set; }

        public DateTime last_login_date { get; set; }
        
    }
}
