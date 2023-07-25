using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
    public class VacationUpdateViewModel
    {
        [StringLength(255, ErrorMessage = "Назва повинна не перевищувати 255 символів")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Ціна повинна бути більше 0")]
        public decimal Price { get; set; }

        [StringLength(4000, ErrorMessage = "Опис повинен не перевищувати 4000 символів")]
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
