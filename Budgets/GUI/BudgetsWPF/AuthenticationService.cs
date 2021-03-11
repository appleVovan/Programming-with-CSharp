using System;

namespace AV.ProgrammingWithCSharp.Budgets.GUI.WPF
{
    public class AuthenticationService
    {
        public User Authenticate(AuthenticationUser authUser)
        {
            if (String.IsNullOrWhiteSpace(authUser.Login) || String.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or Password is Empty");
            //Todo Call method for user login and password validation and retrieve user from storage
            return new User(Guid.NewGuid(), "Volodymyr", "Yablonskyi", "yablonskyi.v.reg@gmail.com", "apple");
        }
    }
}
