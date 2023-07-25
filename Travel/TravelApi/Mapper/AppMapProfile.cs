using AutoMapper;
using TravelApi.Data.Entity;
using TravelApi.Models;

namespace TravelApi.Mapper
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<CategoryEntity, CategoryItemViewModel>()
                .ForMember(x => x.ParentName, opt => opt.MapFrom(x => x.Parent.Name));

            CreateMap<CategoryCreateViewModel, CategoryEntity>()
              .ForMember(x => x.ParentId, opt => opt.MapFrom(x => x.ParentId == 0 ? null : x.ParentId))
              .ForMember(x => x.Image, opt => opt.Ignore());


            CreateMap<VacationImagesEntity, VacationImageItemViewModel>();
        }
        
    }
}
