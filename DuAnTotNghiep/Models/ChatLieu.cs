using System.ComponentModel.DataAnnotations;

namespace Du_An_Tot_Nghiep.Models
{
    public class ChatLieu
    {
        [Key]
        public Guid ID_ChatLieu { get; set; }
        public string? Chatlieu { get; set; }
    }
}
