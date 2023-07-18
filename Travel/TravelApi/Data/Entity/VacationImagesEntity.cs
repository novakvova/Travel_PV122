using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelApi.Data.Entity
{
    [Table("tblVacationImage")]
    public class VacationImagesEntity
    {
            [Key]
            public int Id { get; set; }
            [Required, StringLength(255)]
            public string Name { get; set; }
            public int Priority { get; set; }
            public bool IsDelete { get; set; }

            [ForeignKey("Vacation")]
            public int? VacationId { get; set; }
            public virtual VacationEntity Vacation { get; set; }
        
    }
}
