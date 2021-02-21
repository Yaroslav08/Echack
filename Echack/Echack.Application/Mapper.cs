using AutoMapper;
using Echack.Application.ViewModels.Chack;
using Echack.Application.ViewModels.Group;
using Echack.Application.ViewModels.User;
using Echack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Echack.Application
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Chack, ChackViewModel>()
                .ForMember(d => d.Products, s => s.MapFrom(d => GetProducts(d.Products)))
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group))
                .ForMember(d => d.User, s => s.MapFrom(d => d.User));
            CreateMap<Chack, ChackGroupViewModel>();

            CreateMap<User, UserViewModel>();
            CreateMap<User, UserChackViewModel>();


            CreateMap<Group, GroupViewModel>();
        }


        private List<ProductViewModel> GetProducts(string value)
        {
            return JsonSerializer.Deserialize<List<ProductViewModel>>(value);
        }
    }
}