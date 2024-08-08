using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruitment.API.Models
{
    public class Website
    {
        public int WebsiteId { get; set; }

        [Column(TypeName = "ntext")]
        public string Banner { get; set; }

        [MaxLength(255)]
        public string Facebook { get; set; }

        [MaxLength(255)]
        public string Youtube { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Column(TypeName = "ntext")]
        public string Banner2 { get; set; }
        
         [Column(TypeName = "ntext")]
        public string Banner3 { get; set; }
    }
}