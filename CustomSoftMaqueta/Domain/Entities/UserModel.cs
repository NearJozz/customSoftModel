using System.ComponentModel;
using System.Xml.Linq;

namespace CustomSoftMaqueta.Domain.Entities
{
    public class UserModel
    {
        public Guid Ide { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private bool? HasWritePermissions { get; set; }

        public UserModel() { }
        public UserModel(Guid Ide, string Name, string Email, string Password)
        {
            this.Ide = Ide;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;

            this.HasWritePermissions = false;
        }
        public UserModel(string Name, string Email, string Password)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
     
            this.HasWritePermissions =  false;
        }
        public UserModel(string Name, string Email, string Password, DateTime? CreatedDate,bool? HasWritePermissions)
        {
            this.Name = Name;
            this.Email = Email; 
            this.Password = Password;

            this.HasWritePermissions = HasWritePermissions ?? false;
        }
        
        public void UpdateName(string _name)
        {
            this.Name = _name;
   
        }
        public void UpdateEmail(string _email) { 
            this.Email = _email;
    
        }
        public void UpdatePassword (string _pass){
            this.Password = _pass;
       
        }
        public void SetWritePermission(Boolean _perm = false)
        {
            this.HasWritePermissions = _perm;
          
        }
    }
}
