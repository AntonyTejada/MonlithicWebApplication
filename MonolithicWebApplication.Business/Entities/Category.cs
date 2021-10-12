using System.ComponentModel.DataAnnotations;

namespace MonolithicWebApplication.Business.Entities
{
    public class Category
    {
        [Key]
        public int IdCategory { set; get; }
        [MaxLength(50)]
        [Required(ErrorMessage = "La descrisción es requerida")]
        public string NameCategory { set; get; }
        [MaxLength(100)]
        public string DescriptionCategory { set; get; }
    }
}
