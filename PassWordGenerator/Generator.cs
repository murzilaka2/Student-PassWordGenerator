using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassWordGenerator
{
    class Generator
    {
        public Generator(int length, bool[] options)
        {
            Length = length;
            Options = options;
        }
        int length;
        public int Length { get => length; set => length = value > 0 ? value : 1; }
        public bool[] Options { get; private set; }
        public string Generate()
        {
            string password = Options[4] ? GeneratorWithNoRepetitions() : GeneratorWithRepetitions();
            return password;
        }
        string GeneratorWithNoRepetitions()
        {
            string password = String.Empty;
            Random r = new Random();
            for (int i = 0; i < Length;)
            {               
                switch (r.Next(1, 5))
                {
                    case 1:
                        {
                            if (Options[0]) { password += GetNumber(r); i++; }
                            break;
                        }
                    case 2:
                        {
                            if (Options[1]) { password += GetLowerLetter(r); i++; }
                            break;
                        }
                    case 3:
                        {
                            if (Options[2]) { password += GetUpperLetter(r); i++; }
                            break;
                        }
                    case 4:
                        {
                            if (Options[3]) { password += GetSpecialSymbol(r); i++; }
                            break;
                        }
                }
                if (password.Length > 1)
                {
                    char c = password[password.Length - 1];
                    for (int j = 0; j < password.Length - 1; j++)
                    {
                        if (password[j].Equals(c))
                        {
                            i--;
                            password = password.Remove(password.Length - 1, 1);
                            break;
                        }
                    }
                }
            }
            return password;
        }
        string GeneratorWithRepetitions()
        {
            string password = default;
            Random r = new Random();
            for (int i = 0; i < Length; i++)
            {
                switch (r.Next(1, 5))
                {
                    case 1:
                        {
                            if (Options[0]) password += GetNumber(r);
                            else i--;
                            break;
                        }
                    case 2:
                        {
                            if (Options[1]) password += GetLowerLetter(r);
                            else i--;
                            break;
                        }
                    case 3:
                        {
                            if (Options[2]) password += GetUpperLetter(r);
                            else i--;
                            break;
                        }
                    case 4:
                        {
                            if (Options[3]) password += GetSpecialSymbol(r);
                            else i--;
                            break;
                        }
                }
            }
            return password;
        }
        string GetNumber(Random r) => char.ConvertFromUtf32(r.Next(48, 58));
        string GetUpperLetter(Random r) => char.ConvertFromUtf32(r.Next(65, 91));
        string GetLowerLetter(Random r) => char.ConvertFromUtf32(r.Next(97, 123));
        string GetSpecialSymbol(Random r) => char.ConvertFromUtf32(r.Next(33, 48));
    }
}
