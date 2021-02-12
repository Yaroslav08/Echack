﻿using Echack.Domain.Interfaces;
using Echack.Domain.Models;
using Echack.Infrastructure.Data.Context;
using EFRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Infrastructure.Data.Repositories
{
    public class ChackRepository : CRUDRepository<Chack, Guid, EchackContext>, IChackRepository
    {
        private EchackContext db;
        public ChackRepository(EchackContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<Chack>> GetChacksByMounthAsync(int ownerId, int mounth)
        {
            return await db.Chacks.AsNoTracking()
                .Where(d => d.UserId == ownerId && d.CreatedAt.Month == mounth && d.CreatedAt.Year == DateTime.Now.Year)
                .ToListAsync();
        }

        public async Task<List<Chack>> GetChacksByShopNameAsync(int ownerId, string shopName, int skip = 0)
        {
            if (skip == 0)
                return await db.Chacks.AsNoTracking().Where(d => d.UserId == ownerId && d.ShopName.Contains(shopName))
                    .Take(20)
                    .ToListAsync();
            return await db.Chacks.AsNoTracking().Where(d => d.UserId == ownerId && d.ShopName.Contains(shopName))
                    .Take(20)
                    .Skip(skip)
                    .ToListAsync();
        }

        public async Task<List<Chack>> GetChacksByTimeAsync(int ownerId, DateTime from, DateTime to)
        {
            return await db.Chacks.AsNoTracking()
                .Where(d => d.UserId == ownerId && d.CreatedAt >= from && d.CreatedAt <= to)
                .ToListAsync();
        }
    }
}