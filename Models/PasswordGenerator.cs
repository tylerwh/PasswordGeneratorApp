using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorApp.Models
{
    public class PasswordGenerator
    {
        private string _LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
        private string _UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string _NUMBERS = "0123456789";
        private string _SPECIALCHARS = "@%+!#$^?:.(){}[]~-_`";
        [Required(ErrorMessage = "Must enter number between 6 and 15.")]
        [Range(6,15)]
        [Display(Name = "Password Size")]
        public int PasswordSize { get; set; }
        [Display(Name = "Lower Case")]
        public bool UseLower { get; set; }
        [Display(Name = "Upper Case")]
        public bool UseUpper { get; set; }
        [Display(Name = "Numbers")]
        public bool UseNumbers { get; set; }
        [Display(Name = "Special Characters (@%+!#$^?:.(){}[]~-_`)")]
        public bool UseSpecialChars { get; set; }
        private string _excludedChars { get; set; }
        public string ExcludedChars
        {
            get => _excludedChars;
            set 
            {
                if (UseSpecialChars)
                {
                    _excludedChars = value;
                }
                else
                {
                    _excludedChars = "";
                }
            }
        }
        public string GeneratedPassword =>
            GeneratePassword(PasswordSize, UseLower, UseUpper, UseNumbers, UseSpecialChars, _excludedChars);

        private string GeneratePassword(int passwordSize, bool useLower, bool useUpper, bool useNumbers, bool useSpecialChars, string excludedChars = "")
        {
            char[] _password = new char[passwordSize];
            string charSet = ""; // Initialise to blank
            System.Random _random = new Random();
            int counter = 0;

            
            if (useLower)
            {
                _password[counter] = _LOWERCASE[_random.Next(_LOWERCASE.Length - 1)];
                counter++;
                charSet += _LOWERCASE;
                
            }

            if (useUpper)
            {
                _password[counter] = _UPPERCASE[_random.Next(_UPPERCASE.Length - 1)];
                counter++;
                charSet += _UPPERCASE;
                
            }

            if (useNumbers)
            {
                _password[counter] = _NUMBERS[_random.Next(_NUMBERS.Length - 1)];
                counter++;
                charSet += _NUMBERS;
                
            }

            if (useSpecialChars)
            {
                var specialChars = new StringBuilder(_SPECIALCHARS);
                string exclude = excludedChars;
                

                if(!string.IsNullOrEmpty(exclude))
                {
                    // if characters are excluded
                    char[] arr = exclude.ToCharArray();

                    for (int i = 0; i < specialChars.Length; i++)
                    {
                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (specialChars[i] == arr[j])
                            {
                                specialChars.Remove(i, 1);
                            }
                        }
                    }
                }

                _password[counter] = specialChars[_random.Next(specialChars.Length - 1)];
                counter++;
                charSet += specialChars;
                
            }

            if (!string.IsNullOrEmpty(charSet))
            {
                for (int i = counter; i < passwordSize; i++)
                {
                    _password[i] = charSet[_random.Next(charSet.Length - 1)];
                }

                return String.Join(null, _password);
            }
            else
            {
                return charSet;
            }

            
        }
    }
}
