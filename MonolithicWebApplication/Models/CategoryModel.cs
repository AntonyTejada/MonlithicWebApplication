using System.ComponentModel.DataAnnotations;

namespace MonolithicWebApplication.Models
{
    public class CategoryModel
    {
        [Key]
        public int IdCategory { set; get; }
        [MaxLength(50)]
        public string NameCategory { set; get; }
        [MaxLength(100)]
        public string DescriptionCategory { set; get; }
    }
}
