using System.ComponentModel.DataAnnotations;
namespace onlineBookstore.Models{
public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public String Name { get; set; }
    public int DisplayOrder { get; set; }

}
}
