using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using HM.Common_;

namespace HM.FacePlatform.Server
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException();
            }

            string comparePassword = GeneratePassword.GeneratePasswordByUserName(userName);

            if (comparePassword != password)
            {
                throw new FaultException("Unknown Username or Incorrect Password");
            }
        }
    }
}
