using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace onlineBookstore.Models{
public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Category Name")]
    public String? Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1,100,ErrorMessage ="The range should be between 1-100")]
    public int DisplayOrder { get; set; }

}
}
