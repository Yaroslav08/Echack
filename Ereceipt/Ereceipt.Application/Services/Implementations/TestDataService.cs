using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Implementations
{
    public class TestDataService : ITestDataService
    {
        private readonly ITestDataRepository _testDataRepository;

        public TestDataService(ITestDataRepository testDataRepository)
        {
            _testDataRepository = testDataRepository;
        }

        public async Task<string> LoadAllTestData()
        {
            var products = new string[10];

            for (int i = 0; i < products.Length; i++)
            {
                var productsToDb = new List<ProductCreateViewModel>();
                for (int j = 0; j < new Random().Next(1,5); j++)
                {
                    var productId = Guid.NewGuid().ToString("N");
                    productsToDb.Add(new ProductCreateViewModel
                    {
                        CountWeight = new Random().Next(1,15),
                        Id = productId,
                        Name = $"Product_{productId}",
                        Price = new Random().Next(1,999)
                    });
                }
                products[i] = JsonSerializer.Serialize(productsToDb);
            }

            return await _testDataRepository.LoadTestDataAsync(products);
        }
    }
}