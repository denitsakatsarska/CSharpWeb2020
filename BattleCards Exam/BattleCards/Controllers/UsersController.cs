using BattleCards.Services;
using BattleCards.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {

            return this.View();

            //var userId = this.usersService.GetUserId(input.Username, input.Password);


            //if (userId == null)
            //{
            //    return this.Error("Invalid username or password");
            //}

            //this.SignIn(userId);
            //return this.Redirect("/Trips/All");
        }


        public HttpResponse Register()
        {
            return this.View();
        }


        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Username) || input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Error("Email is required.");
            }

            if (string.IsNullOrWhiteSpace(input.Password) || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters.");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords do not match.");
            }

            this.usersService.Create(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }
    }
}