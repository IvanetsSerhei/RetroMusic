using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace RetroMusicSite.WebUI.Infrastructure.Identity
{
    public class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string pass)
        {
            List<string> errors = new List<string>();

            string passPattern = @"^[a-zA-Z0-9а-яА-Я]+$";

            if (String.IsNullOrEmpty(pass))
                errors.Add("Пароль не может быть пустым,");

            else
            {
                if (pass.Contains("12345"))
                {
                    errors.Add("Пароль не должен содержать последовательности чисел.");
                }

                if (pass.Contains("qwert") || pass.Contains("Qwert") || pass.Contains("QWERT"))
                {
                    errors.Add("Пароль не должен содержать последовательности букв <qwert>.");
                }

                if (!Regex.IsMatch(pass, passPattern))
                    errors.Add("В пароле разрешается указывать " +
                               "буквы английского или русского языков, и цифры. ");

                if (pass.Length < 6)
                    errors.Add("Пароль должен быть не меньше 6 символов");

                if(pass.Equals(pass.ToLowerInvariant()))
                     errors.Add("Пароль должен содержать хотябы 1 заглавный символ");          
            }

            if (errors.Count > 0)
                return IdentityResult.Failed(errors.ToArray());

            return IdentityResult.Success;
        }
    }
}