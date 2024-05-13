using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class Users
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }    
    }
}
