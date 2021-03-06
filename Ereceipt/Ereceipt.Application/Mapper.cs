using AutoMapper;
using Ereceipt.Application.ViewModels.Chack;
using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Ereceipt.Application
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Chack, ChackViewModel>()
                .ForMember(d => d.Products, s => s.MapFrom(d => GetProducts(d.Products)))
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group))
                .ForMember(d => d.User, s => s.MapFrom(d => d.User));
            CreateMap<Chack, ChackGroupViewModel>()
                .ForMember(d => d.Products, s => s.MapFrom(d => GetProducts(d.Products)))
                .ForMember(d => d.User, s => s.MapFrom(d => d.User));

            CreateMap<User, UserViewModel>();
            CreateMap<User, UserChackViewModel>();


            CreateMap<Group, GroupViewModel>();
            CreateMap<Group, GroupChackViewModel>();
        }


        private List<ProductViewModel> GetProducts(string value)
        {
            return JsonSerializer.Deserialize<List<ProductViewModel>>(value);
        }
    }
}