namespace Ereceipt.Application.ViewModels.Authentication
{
    public class RegisterViewModel
    {
        public RegisterViewModel(string error)
        {
            Error = error;
            IsOK = false;
        }
        public RegisterViewModel()
        {
            IsOK = true;
            Error = null;
        }

        public bool IsOK { get; set; }
        public string Error { get; set; }
        public bool IsError => !string.IsNullOrEmpty(Error) ? true : false;
    }
}