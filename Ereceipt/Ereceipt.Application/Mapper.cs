﻿using AutoMapper;
using Ereceipt.Application.ViewModels.Comment;
using Ereceipt.Application.ViewModels.Currency;
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

            CreateMap<Comment, CommentViewModel>()
                .ForMember(d => d.User, d => d.MapFrom(s => s.User))
                .ForMember(d => d.Receipt, d => d.MapFrom(s => s.Receipt));

            CreateMap<Group, GroupViewModel>();
            CreateMap<Group, GroupReceiptViewModel>();

            CreateMap<GroupMember, GroupMemberViewModel>()
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group))
                .ForMember(d => d.User, s => s.MapFrom(d => d.User));

            CreateMap<Currency, CurrencyViewModel>();
            CreateMap<Currency, CurrencyRootViewModel>();
            CreateMap<CurrencyCreateModel, Currency>().ReverseMap();
            CreateMap<CurrencyEditModel, Currency>().ReverseMap();
        }


        private List<ProductViewModel> GetProducts(string value) => JsonSerializer.Deserialize<List<ProductViewModel>>(value);
    }
}