using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassBook
{
    class Save
    {
        public string app_name { get; set; }
        public string app_link { get; set; }
        public string username { get; set; }
        public string pass { get;set; }
        public string email { get; set; }
        public string note { get; set; }
        

    }
    class Authorization
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
        public string TempKEY { get; set; }

    }
}
