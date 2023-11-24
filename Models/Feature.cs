using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_Crud2.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]

        public string Image { get; set; }
        public string Description { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }

        [NotMapped]
        public IFormFile ? FileImage { get; set; }
    }
}
