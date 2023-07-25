using Microsoft.AspNetCore.Http;

namespace TravelApi.Models
{
    /// <summary>
    /// Завантаження фото на сервер
    /// </summary>
    public class VacationUploadImageViewModel
    {
        public IFormFile Image { get; set; }
    }
}
