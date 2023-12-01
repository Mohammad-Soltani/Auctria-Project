using AutoMapper;
using AuctriaProject.Application.Models;
using AuctriaProject.Domain.Entities;

namespace AuctriaProject.Application.Common
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<Item, ItemViewModel>();
            CreateMap<ItemViewModel, Item>();
            CreateMap<UserLogin, UserLoginViewModel>();
            CreateMap<UserLoginViewModel, UserLogin>();
            CreateMap<ShoppingItem, ShoppingCardViewModel>();
            CreateMap<ShoppingCardViewModel, ShoppingItem>();
        }
    }
}
