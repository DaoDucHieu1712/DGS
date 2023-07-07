using AutoMapper;
using DGS.BusinessObjects.DTOs.Auth;
using DGS.BusinessObjects.DTOs.Category;
using DGS.BusinessObjects.DTOs.Order;
using DGS.BusinessObjects.DTOs.OrderDetail;
using DGS.BusinessObjects.DTOs.Product;
using DGS.BusinessObjects.DTOs.Size;
using DGS.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateUpdateDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderCreateUpdateDTO>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailCreateUpdateDTO>().ReverseMap();

            CreateMap<Size, SizeDTO>().ReverseMap();

            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
