using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallFlow
{
   public class Logic: Base_Logic
    {
        public Allow_AccessModel Check_User_Access(Creditionals creditionals)
        {
            return DB.AccessAllows.Where(x => x.UserName == creditionals.Username && x.Password == creditionals.Pass).Select(p => new Allow_AccessModel(p)).SingleOrDefault();
        }

        public Allow_AccessModel UpdateTologin(Creditionals creditionals)
        {
            AccessAllow User = DB.AccessAllows.Where(p => p.UserName == creditionals.Username && p.Password == creditionals.Pass).SingleOrDefault();

            User.Status = "Login";

            DB.AccessAllows.Update(User);
            DB.SaveChanges();
            return DB.AccessAllows.Where(p => p.UserName == creditionals.Username && p.Password == creditionals.Pass).Select(p => new Allow_AccessModel(p)).SingleOrDefault();
        }

        public Allow_AccessModel UpdateToLogout(string Username)
        {
            AccessAllow User = DB.AccessAllows.Where(x => x.UserName == Username).SingleOrDefault();
            User.Status = null;

            DB.AccessAllows.Update(User);
            DB.SaveChanges();

            return DB.AccessAllows.Where(p => p.UserName == Username).Select(p => new Allow_AccessModel(p)).SingleOrDefault();
            
        }

        public Allow_AccessModel CheckIfLogin(string User_Name)
        {
            return DB.AccessAllows.Where(x => x.UserName == User_Name).Select(p => new Allow_AccessModel(p)).SingleOrDefault();
        }

        public List<Allow_AccessModel> ShowContactsUsers()
        {
            return DB.AccessAllows.Where(p => p.Status == "Login").Select(p => new Allow_AccessModel(p)).ToList();
        }

        public List<ChatModels> GetAllMessages()
        {
            return DB.ChatMessages.Select(p => new ChatModels(p)).ToList();
        }

        public ChatModels AddMessage(ChatModels New_Message)
        {
            ChatMessage Message = New_Message.ConvertToChatModel();
            DB.ChatMessages.Add(Message);
            DB.SaveChanges();
            New_Message.id = Message.Id;

            return New_Message;

        }

        public List<Contact_Now_Model> GetAllUsers()
        {
            return DB.Contact_Now.Select(p => new Contact_Now_Model(p)).ToList();
        }

        public Contact_Now_Model New_UserTo_Online(Contact_Now_Model New_Online_User)
        {

            Contact_Now NewUserContact = New_Online_User.ConvertToModel();
            NewUserContact.IsType = null;
            NewUserContact.date   = null;
            DB.Contact_Now.Add(NewUserContact);
            DB.SaveChanges();
            New_Online_User.isType = null;
            New_Online_User.Date = null;
            New_Online_User.Id = NewUserContact.id;

            return New_Online_User;
        }

        public Contact_Now_Model FindUserContact(string firstname)
        {
            return DB.Contact_Now.Where(p => p.UserName == firstname).Select(p => new Contact_Now_Model(p)).SingleOrDefault();
        }

        public Contact_Now_Model UpdateIfType(string firstname)
        {
            Contact_Now user = DB.Contact_Now.Where(p => p.UserName == firstname).SingleOrDefault();
            user.IsType = "Type";
            user.date = DateTime.Now;
            DB.SaveChanges();

            Contact_Now_Model updateUserModel = DB.Contact_Now.Where(p => p.UserName == firstname).Select(p => new Contact_Now_Model(p)).SingleOrDefault();
            updateUserModel.isType = user.IsType;
            updateUserModel.Date = user.date;
            updateUserModel.Id = user.id;

            return updateUserModel;
        }

        public Contact_Now_Model UpdateIfNotType(string firstname)
        {
            Contact_Now user = DB.Contact_Now.Where(p => p.UserName == firstname).SingleOrDefault();
            user.IsType = null;
            user.date = null;
            DB.SaveChanges();

            Contact_Now_Model updateUserModel = DB.Contact_Now.Where(p => p.UserName == firstname).Select(p => new Contact_Now_Model(p)).SingleOrDefault();
            updateUserModel.isType = user.IsType;
            updateUserModel.Date = user.date;
            updateUserModel.Id = user.id;

            return updateUserModel;
        }
    }
}

