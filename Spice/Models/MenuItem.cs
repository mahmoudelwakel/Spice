using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spice.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Spicyness { get; set; }
        public enum Espicy { NA=0,Spicy=1,NotSpicy=2,VerySpicy=3 }
        [Display(Name="Category")]
        public int CateogryId { get; set; }
        [ForeignKey("CateogryId")]
        public Category Category { get; set; }
        [Display(Name ="SubCategory")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }
    }
}
