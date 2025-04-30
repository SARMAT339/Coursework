using System;
using CaesarCipherApp.Models;
using Coursework.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaesarCipherApp.Controllers
{
    public class CaesarController : Controller
    {
        public ActionResult Index()
        {
            return View(new Caesar());
        }

        [HttpPost]
        public ActionResult Index(Caesar model, string action)
        {
            if (action == "encrypt")
            {
                model.OutputText = EncryptDecrypt(model.InputText, model.Key, true);
            }
            else if (action == "decrypt")
            {
                model.OutputText = EncryptDecrypt(model.InputText, model.Key, false);
            }
            else
            {
                model.OutputText = "Ошибка: выберите действие.";
            }

            return View(model);
        }

        private string EncryptDecrypt(string text, int key, bool encrypt)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            // Определяем алфавит (латиница или кириллица)
            bool isRussian = text.Any(c => "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя".Contains(c));
            int alphabetSize = isRussian ? 33 : 26;
            char firstUpper = isRussian ? 'А' : 'A';
            char firstLower = isRussian ? 'а' : 'a';

            key = encrypt ? key : -key; // Для дешифровки сдвигаем в обратную сторону

            string result = "";
            foreach (char ch in text)
            {
                if (!char.IsLetter(ch))
                {
                    result += ch;
                    continue;
                }

                char firstChar = char.IsUpper(ch) ? firstUpper : firstLower;
                int offset = (ch - firstChar + key) % alphabetSize;
                if (offset < 0) offset += alphabetSize; // Корректировка отрицательного сдвига
                result += (char)(firstChar + offset);
            }

            return result;
        }
    }
}