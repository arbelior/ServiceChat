using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallFlow
{
    public class Contact_Now_Model
    {
        public int Id { get; set; }

        public string? userName { get; set; }

        public string? isType { get; set; } 

        public DateTime? Date { get; set; }


        public Contact_Now_Model()  { }

        public Contact_Now_Model(Contact_Now UserOnline)
        {
            Id       = UserOnline.id;
            userName = UserOnline.UserName;
            isType   = UserOnline.IsType;
            Date     = UserOnline.date;
        }

        public Contact_Now ConvertToModel()
        {
            Contact_Now AddNewUser = new Contact_Now
            {
                id = Id,
                UserName = userName,
                IsType = isType,
                date = Date
            };

            return AddNewUser;
        }


    }
}
