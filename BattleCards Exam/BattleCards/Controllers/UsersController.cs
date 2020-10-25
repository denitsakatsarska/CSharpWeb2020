using BattleCards.Services;
using BattleCards.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        // GET -> login
        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }


        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId == null)
            {
                // ако е null имаме неуспешно логване, заради грешен потребител или парола
                return this.Error("Invalid username or password");
            }

            // ако не е null – login + redirect
            this.SignIn(userId);
            return this.Redirect("/Cards/All");
        }


        // GET
        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }


        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(input.Username) || input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters");
            }

            //if (input.Username == null || input.Username.Length < 5 || input.Username.Length > 20)

            if (!Regex.IsMatch(input.Username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed.");
            }

            if (string.IsNullOrWhiteSpace(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Email is required.");
            }

            if (input.Password == null || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords do not match.");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already taken.");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email already taken.");
            }

            this.usersService.Create(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }


        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Error("Only logged-in users can logout.");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}