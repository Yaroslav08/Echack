using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.EntityFramework.Context;
using Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Infrastructure.Data.Repositories.EF
{
    public class EFTestDataRepository : ITestDataRepository
    {
        private readonly EreceiptContext db;
        public EFTestDataRepository(EreceiptContext _db)
        {
            db = _db;
        }

        public async Task<string> LoadTestDataAsync(string[] products)
        {
            if (!db.HasAnyData())
            {
                try
                {
                    var user1 = await db.Users.AddAsync(new User
                    {
                        Login = "yaroslav.mudryk@gmail.com",
                        PasswordHash = PasswordManager.GeneratePasswordHash("SomePassword"),
                        Name = "Yaroslav Mudryk",
                        Role = "Admin",
                        CreatedAt = DateTime.UtcNow
                    });
                    var user2 = await db.Users.AddAsync(new User
                    {
                        Login = "nikita.jove28@gmail.com",
                        PasswordHash = PasswordManager.GeneratePasswordHash("Nikita266210"),
                        Name = "Nikita Medko",
                        Role = "User",
                        CreatedAt = DateTime.UtcNow
                    });
                    var user3 = await db.Users.AddAsync(new User
                    {
                        Login = "ZhdanCreator@gmail.com",
                        PasswordHash = PasswordManager.GeneratePasswordHash("Zhdan2002"),
                        Name = "Zhdan Chernavskiy",
                        Role = "User",
                        CreatedAt = DateTime.UtcNow
                    });
                    await db.SaveChangesAsync();
                    var userIds = new int[] { user1.Entity.Id, user2.Entity.Id, user3.Entity.Id };



                    var group1 = await db.Groups.AddAsync(new Group
                    {
                        Name = $"GroupOfUser_{user1.Entity.Id}",
                        Color = "#fff",
                        Desc = $"Created at {DateTime.UtcNow.ToLocalTime().ToString("D")}"
                    });
                    await db.SaveChangesAsync();

                    var member1 = await db.GroupMembers.AddAsync(new GroupMember
                    {
                        UserId = user1.Entity.Id,
                        GroupId = group1.Entity.Id,
                        Title = "Creator",
                        CreatedAt = DateTime.UtcNow,
                        IsCreator = true,
                        CanAddMember = true,
                        CanControlBudget = true,
                        CanEditGroup = true,
                        CanRemoveMember = true,
                        CanRemoveReceipt = true
                    });
                    var member2 = await db.GroupMembers.AddAsync(new GroupMember
                    {
                        UserId = user2.Entity.Id,
                        GroupId = group1.Entity.Id,
                        Title = "Member",
                        CreatedAt = DateTime.UtcNow,
                        IsCreator = false,
                        CanAddMember = false,
                        CanControlBudget = false,
                        CanEditGroup = false,
                        CanRemoveMember = false,
                        CanRemoveReceipt = false
                    });
                    var member3 = await db.GroupMembers.AddAsync(new GroupMember
                    {
                        UserId = user3.Entity.Id,
                        GroupId = group1.Entity.Id,
                        Title = "Member",
                        CreatedAt = DateTime.UtcNow,
                        IsCreator = false,
                        CanAddMember = false,
                        CanControlBudget = false,
                        CanEditGroup = false,
                        CanRemoveMember = false,
                        CanRemoveReceipt = false
                    });
                    await db.SaveChangesAsync();


                    var receipts = new List<Receipt>();
                    for (int i = 0; i < 10; i++)
                    {
                        receipts.Add(new Receipt
                        {
                            ShopName = i % 2 == 0 ? "Сільпо" : "Велика Кишеня",
                            UserId = userIds[new Random().Next(0, 2)],
                            ReceiptType = Domain.Models.ReceiptType.Internal,
                            IsImportant = i % 2 == 0 ? false : true,
                            CanEdit = true,
                            Products = products[i],
                            GroupId = i % 2 == 0 ? group1.Entity.Id : null,
                            CreatedAt = DateTime.UtcNow,
                            Comments = i % 2 == 0 ? new List<Comment>
                            {
                                new Comment
                                {
                                    UserId = new Random().Next(0,2),
                                    CreatedAt = DateTime.UtcNow,
                                    CreatedBy = "1",
                                    CreatedFromIP = "::1",
                                    Text = $"Hello {i}"
                                },
                                new Comment
                                {
                                    UserId = new Random().Next(0,2),
                                    CreatedAt = DateTime.UtcNow,
                                    CreatedBy = "1",
                                    CreatedFromIP = "::1",
                                    Text = $"Hello {i}"
                                }
                            } : null
                        });
                    }
                    await db.Receipts.AddRangeAsync(receipts);
                    await db.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
                return "OK";
            }
            return "OK";
        }
    }
}