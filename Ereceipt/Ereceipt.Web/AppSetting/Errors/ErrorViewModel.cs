using System;

namespace Ereceipt.Web.AppSetting.Errors
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string code, string category, string descriptionEN, string descriptionUA, string descriptionRU)
        {
            Id = Guid.NewGuid().ToString("N");
            Code = code;
            Category = category;
            DescriptionEN = descriptionEN;
            DescriptionUA = descriptionUA;
            DescriptionRU = descriptionRU;
            CreatedAt = DateTime.UtcNow;
        }

        public string Id { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionUA { get; set; }
        public string DescriptionRU { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
