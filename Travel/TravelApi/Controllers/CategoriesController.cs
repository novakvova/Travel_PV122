using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Data.Entity;
using TravelApi.Data;
using TravelApi.Models;
using System.Drawing;
using TravelApi.Helpers;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppEFContext _appEFContext;
        private readonly IConfiguration _configuration;

        public CategoriesController(AppEFContext appEFContext, IConfiguration configuration)
        {
            _appEFContext = appEFContext;
            _configuration = configuration;
            
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateViewModel model)
        {
            String imageName = string.Empty;
            if (model.Image != null)
            {
                var fileExp = Path.GetExtension(model.Image.FileName);
                var dirSave = Path.Combine(Directory.GetCurrentDirectory(), "images");
                imageName = Path.GetRandomFileName() + fileExp;
                //using (var steam = System.IO.File.Create(Path.Combine(dirSave, imageName)))
                //{
                //    await model.Image.CopyToAsync(steam);
                //}
                using (var ms = new MemoryStream())
                {
                    await model.Image.CopyToAsync(ms);
                    var bmp = new Bitmap(Image.FromStream(ms));
                    string []sizes =((string)_configuration.GetValue<string>("ImageSizes")).Split(" ");
                    foreach (var s in sizes)
                    {
                        int size = Convert.ToInt32(s);
                        var saveImage = ImageWorker.CompressImage(bmp, size, size, false);
                        saveImage.Save(Path.Combine(dirSave, s + "_" + imageName));
                    }
                
                }
            }

            CategoryEntity category = new CategoryEntity
            {
                DateCreated = DateTime.UtcNow,
                Name = model.Name,
                Description = model.Description,
                Image = imageName,
                Priority = model.Priority,
                ParentId = model.ParentId == 0 ? null : model.ParentId,
            };
            await _appEFContext.AddAsync(category);
            await _appEFContext.SaveChangesAsync();
            return Ok(category);
        }
    }
}
