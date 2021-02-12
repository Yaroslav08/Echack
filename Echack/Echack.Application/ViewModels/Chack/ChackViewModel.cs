﻿using Echack.Application.ViewModels.Group;
using Echack.Application.ViewModels.User;
using Echack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Application.ViewModels.Chack
{
    public class ChackViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string ShopName { get; set; }
        public double TotalPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public bool IsImportant { get; set; }
        public bool CanEdit { get; set; }
        public ChackType ChackType { get; set; }
        public UserViewModel User { get; set; }
        public GroupViewModel Group { get; set; }
    }
}