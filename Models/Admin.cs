using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models;

public class Admin
{
    private string name = "";
    private string email = "";
    private string password = "";

    public string Name
        {
            get => name;

            set{
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ValidationException("Name cannot be empty");
                }
                name = value.Trim();
            }
        }
        public string Email    
        {
            get => email;

            set{
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ValidationException("Email cannot be empty");
                }
                email = value.Trim();
            }
        }
        public int Id{get;set;}
        public int StoreId{get;set;}
        public string Password
            {
            get => password;

            set{
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ValidationException("Password cannot be empty");
                }
                password = value.Trim();
            }
        }
        
} 