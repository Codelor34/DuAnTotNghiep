using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class Gio_Hang
    {
        [Key]
        public Guid ID_Gio_Hang { get; set; }
        public Guid ID_User { get; set; }

    }
}
