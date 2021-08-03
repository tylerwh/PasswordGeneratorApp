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
        [Range(6,15)]
        public int PasswordSize { get; set; }
        public bool UseLower { get; set; }
        public bool UseUpper { get; set; }
        public bool UseNumbers { get; set; }
        public bool UseSpecialChars { get; set; }
        public string ExcludedChars { get; set; }
        public string GeneratedPassword =>
            GeneratePassword(PasswordSize, UseLower, UseUpper, UseNumbers, UseSpecialChars, ExcludedChars);

        private string GeneratePassword(int passwordSize, bool useLower, bool useUpper, bool useNumbers, bool useSpecialChars, string excludedChars)
        {
            char[] _password = new char[passwordSize];
            string charSet = ""; // Initialise to blank
            System.Random _random = new Random();
            int counter = 0;

            // Build up the character set to choose from
            if (useLower)
            {
                _password[counter] = _LOWERCASE[_random.Next(_LOWERCASE.Length - 1)];
                counter++;
                charSet += _LOWERCASE;
                // Console.WriteLine("charSet in useLower: {0}", charSet);
            }

            if (useUpper)
            {
                _password[counter] = _UPPERCASE[_random.Next(_UPPERCASE.Length - 1)];
                counter++;
                charSet += _UPPERCASE;
                // Console.WriteLine("charSet in useUpper: {0}", charSet);
            }

            if (useNumbers)
            {
                _password[counter] = _NUMBERS[_random.Next(_NUMBERS.Length - 1)];
                counter++;
                charSet += _NUMBERS;
                // Console.WriteLine("charSet in useNumbers: {0}", charSet);
            }

            if (useSpecialChars)
            {
                var specialChars = new StringBuilder(_SPECIALCHARS);
                string exclude = excludedChars;
                char[] arr = exclude.ToCharArray();

                // Console.WriteLine("specialChars initial: {0}", specialChars);

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

                // Console.WriteLine("specialChars final: {0}", specialChars);

                _password[counter] = specialChars[_random.Next(specialChars.Length - 1)];
                counter++;
                charSet += specialChars;
                // Console.WriteLine("charSet in useSpecial: {0}", charSet);
            }

            for (int i = counter; i < passwordSize; i++)
            {
                _password[i] = charSet[_random.Next(charSet.Length - 1)];
            }

            return String.Join(null, _password);
        }
    }
}
