namespace Ereceipt.Application.ViewModels.Authentication
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public string Error { get; set; }
        public bool IsError => string.IsNullOrEmpty(Error) ? false : true;

        public LoginViewModel(string error) => Error = error;
        public LoginViewModel() { }

        public LoginViewModel(int id, string name, string username, string role, string avatar)
        {
            Id = id;
            Name = name;
            Username = username;
            Role = role;
            Avatar = avatar;
        }
    }
}