namespace Ereceipt.Web.Models
{
    public class ValidationModel
    {
        public ValidationModel(string name, string error)
        {
            Name = name;
            Error = error;
        }

        public string Name { get; set; }
        public string Error { get; set; }
    }
}