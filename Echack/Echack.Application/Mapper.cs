using AutoMapper;
using Echack.Application.ViewModels.Chack;
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
                .ForMember(d => d.Products, s => s.MapFrom(d => GetProducts(d.Products)));
        }


        private List<ProductViewModel> GetProducts(string value)
        {
            return JsonSerializer.Deserialize<List<ProductViewModel>>(value);
        }
    }
}