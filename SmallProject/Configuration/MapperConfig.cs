using AutoMapper;
using SmallProject.DAL.ViewModels;
using SmallProject.DAL.Models;
using SmallProject.DAL.ViewModelsWithId;

namespace SmallProject.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<CategoryViewModel, Category>();
            CreateMap<CategoryProductViewModel,CategoryProduct>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<OrderViewModel,Order>();
            CreateMap<ProductOrderViewModel, ProductOrder>();
            CreateMap<ProductViewModelWithId, Product>();
            CreateMap<CategoryViewModelWithId, Category>();
            CreateMap<CategoryProductViewModelWithId, CategoryProduct>();
            CreateMap<OrderViewModelWithId, Order>();
            CreateMap<ProductOrderViewModelWithId, ProductOrder>();
        }
    }
}
