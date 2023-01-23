using AutoMapper;
using DTO;
using Entities;

namespace myWebApp
{
    public class Mapper:Profile
    {

        public Mapper()
        {
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.CategoryName));
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<Category, CategoryDTO>();
            
         }

        }

}
