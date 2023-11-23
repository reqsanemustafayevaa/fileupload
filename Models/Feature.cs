using System.ComponentModel.DataAnnotations;

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
        public string Description { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }
    }
}
