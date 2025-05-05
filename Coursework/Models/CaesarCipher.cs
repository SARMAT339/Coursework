using System.Text;

namespace Coursework.Models
{
    public class CaesarCipher
    {
        public static string Encrypt(string input, int key)
        {
            return ShiftText(input, key);
        }

        public static string Decrypt(string input, int key)
        {
            return ShiftText(input, -key);
        }

        public static string ShiftText(string input, int shift)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'А' : 'а';
                    char shifted = (char)((((c - baseChar) + shift + 33) % 33) + baseChar);
                    result.Append(shifted);
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
