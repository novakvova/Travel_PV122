using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Data.Entity;
using TravelApi.Data;
using TravelApi.Models;
using System.Drawing;
using TravelApi.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppEFContext _appEFContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CategoriesController(AppEFContext appEFContext, IConfiguration configuration, IMapper mapper)
        {
            _appEFContext = appEFContext;
            _configuration = configuration;
            
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _appEFContext.Categories
                .Select(x => _mapper.Map<CategoryItemViewModel>(x))
                .ToListAsync();
            return Ok(result);
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
                    string[] sizes = ((string)_configuration.GetValue<string>("ImageSizes")).Split(" ");
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _appEFContext.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound();

            var dirSave = Path.Combine(Directory.GetCurrentDirectory(), "images");
            string[] sizes = ((string)_configuration.GetValue<string>("ImageSizes")).Split(" ");
            foreach (var s in sizes)
            {
                var imgDelete = Path.Combine(dirSave, s + "_" + category.Image);
                if (System.IO.File.Exists(imgDelete))
                {
                    System.IO.File.Delete(imgDelete);
                }
            }
            _appEFContext.Categories.Remove(category);
            await _appEFContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _appEFContext.Categories
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<CategoryItemViewModel>(x))
                .ToListAsync();
            if (result.Count > 0)
            {
                return Ok(result[0]);
            }
            else
            { return NotFound(); }
        }
    }
}
