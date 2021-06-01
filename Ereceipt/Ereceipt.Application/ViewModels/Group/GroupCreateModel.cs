using System.ComponentModel.DataAnnotations;

namespace Ereceipt.Application.ViewModels.Group
{
    public class GroupCreateModel : RequestModel
    {
        [Required(ErrorMessage = "Name is required"), MinLength(1, ErrorMessage = "Min length of name is 1 symbol"), MaxLength(100, ErrorMessage = "Max length of name is 100 symbols")]
        public string Name { get; set; }
        [MinLength(2, ErrorMessage = "Min length of color is 2 symbols"), MaxLength(25, ErrorMessage = "Max length of color is 25 symbols")]
        public string Color { get; set; }
        [MinLength(10, ErrorMessage = "Min length of desc is 10 symbols"), MaxLength(250, ErrorMessage = "Max length of desc is 250 symbols")]
        public string Desc { get; set; }
    }
}