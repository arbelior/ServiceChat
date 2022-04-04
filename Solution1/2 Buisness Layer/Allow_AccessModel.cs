using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallFlow
{
   public class Allow_AccessModel
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? status { get; set; }


        public Allow_AccessModel()  { }

        public Allow_AccessModel(AccessAllow AllowAccessDB)
        {
            id        = AllowAccessDB.Id;
            firstName = AllowAccessDB.FirstName;
            lastName  = AllowAccessDB.LastName;
            userName  = AllowAccessDB.UserName;
            password  = AllowAccessDB.Password;
            status    = AllowAccessDB.Status; 
        }

   }
}
