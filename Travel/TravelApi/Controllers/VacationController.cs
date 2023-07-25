using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using TravelApi.Data;
using TravelApi.Data.Entity;
using TravelApi.Helpers;
using TravelApi.Models;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly AppEFContext _appContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public VacationController(AppEFContext appEFContext, IConfiguration configuration, IMapper mapper)
        {
            _appContext = appEFContext;
            _configuration = configuration;
            _mapper = mapper;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVacation(int id)
        {
            var vacation = await _appContext.Vacation
                .Include(p => p.VacationImages)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (vacation == null)
                return NotFound();

            var vacationViewModel = _mapper.Map<VacationViewModel>(vacation);
            return Ok(vacationViewModel);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] VacationCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vacation = _mapper.Map<VacationEntity>(model);
            vacation.DateCreated = DateTime.UtcNow;

            _appContext.Vacation.Add(vacation);
            await _appContext.SaveChangesAsync();

            var vacationViewModel = _mapper.Map<VacationViewModel>(vacation);
            return CreatedAtAction(nameof(GetVacation), new { id = vacation.Id }, vacationViewModel);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] VacationUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vacation = await _appContext.Vacation
                .SingleOrDefaultAsync(p => p.Id == id);

            if (vacation == null)
                return NotFound();

            _mapper.Map(model, vacation);
            await _appContext.SaveChangesAsync();

            var vacationViewModel = _mapper.Map<VacationViewModel>(vacation);
            return Ok(vacationViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var vacation = await _appContext.Vacation
                .SingleOrDefaultAsync(p => p.Id == id);

            if (vacation == null)
                return NotFound();

            _appContext.Vacation.Remove(vacation);
            await _appContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("uploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] VacationUploadImageViewModel model)
        {

            string imageName = string.Empty;
            if (model.Image != null)
            {
                var fileExp = Path.GetExtension(model.Image.FileName);
                var dirSave = Path.Combine(Directory.GetCurrentDirectory(), "images");
                imageName = Path.GetRandomFileName() + fileExp;
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
                var entity = new VacationImagesEntity();
                entity.Name = imageName;

                _appContext.VacationImages.Add(entity);
                _appContext.SaveChanges();
                return Ok(_mapper.Map<VacationImageItemViewModel>(entity));

            }
            return BadRequest();
        }

        [HttpDelete("RemoveImage/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _appContext.VacationImages.SingleOrDefaultAsync(x => x.Id == id);
            if (image == null)
                return NotFound();

            var dirSave = Path.Combine("images");
            string[] sizes = ((string)_configuration.GetValue<string>("ImageSizes")).Split(" ");
            foreach (var s in sizes)
            {
                var imgDelete = Path.Combine(dirSave, s + "_" + image.Name);
                if (System.IO.File.Exists(imgDelete))
                {
                    System.IO.File.Delete(imgDelete);
                }
            }
            _appContext.VacationImages.Remove(image);
            await _appContext.SaveChangesAsync();
            return Ok();
        }

    }
}
