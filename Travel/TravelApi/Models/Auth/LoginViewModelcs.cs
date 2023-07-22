namespace TravelApi.Models.Auth
{
    public class LoginViewModelcs
    {
        public class LoginViewModel
        {
            /// <summary>
            /// Електронна пошта
            /// </summary>
            /// <example>admin@gmail.com</example>
            public string Email { get; set; }
            /// <summary>
            /// Пароль
            /// </summary>
            /// <example>123456</example>
            public string Password { get; set; }
        }
    }
}
