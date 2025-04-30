using System.ComponentModel.DataAnnotations;

namespace CaesarCipherApp.Models
{
    public class Caesar
    {
        [Required(ErrorMessage = "Введите текст")]
        public string InputText { get; set; }

        [Required(ErrorMessage = "Введите ключ")]
        [Range(1, 33, ErrorMessage = "Ключ должен быть от 1 до 33")]
        public int Key { get; set; }

        public string OutputText { get; set; }
    }
}