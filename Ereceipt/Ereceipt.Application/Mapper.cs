using AutoMapper;
using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.GroupMember;
using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Application.ViewModels.User;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Ereceipt.Application
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Receipt, ReceiptViewModel>()
                .ForMember(d => d.TotalPrice, s => s.MapFrom(d => Math.Round(GetProducts(d.Products).Sum(d => d.Price), 2)))
                .ForMember(d => d.Products, s => s.MapFrom(d => GetProducts(d.Products)))
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group))
                .ForMember(d => d.User, s => s.MapFrom(d => d.User));
            CreateMap<Receipt, ReceiptGroupViewModel>()
                .ForMember(d => d.TotalPrice, s => s.MapFrom(d => Math.Round(GetProducts(d.Products).Sum(d => d.Price), 2)))
                .ForMember(d => d.Products, s => s.MapFrom(d => GetProducts(d.Products)))
                .ForMember(d => d.User, s => s.MapFrom(d => d.User));

            CreateMap<User, UserViewModel>();
            CreateMap<User, UserReceiptViewModel>();


            CreateMap<Group, GroupViewModel>();
            CreateMap<Group, GroupReceiptViewModel>();

            CreateMap<GroupMember, GroupMemberViewModel>()
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group))
                .ForMember(d => d.User, s => s.MapFrom(d => d.User));
        }


        private List<ProductViewModel> GetProducts(string value)
        {
            return JsonSerializer.Deserialize<List<ProductViewModel>>(value);
        }
    }
}