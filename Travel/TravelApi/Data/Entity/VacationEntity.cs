using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApi.Data.Entity
{
    [Table("tblVacation")]
    public class VacationEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public bool IsHot { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }
        public virtual ICollection<VacationImagesEntity> ProductImages { get; set; }
    }
}


