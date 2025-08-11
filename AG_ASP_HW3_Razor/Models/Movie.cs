using System.ComponentModel.DataAnnotations;

namespace AP_Films.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения.")]
        [StringLength(100, ErrorMessage = "Название не может содержать более 100 символов.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле 'Режиссер' обязательно для заполнения.")]
        [StringLength(100, ErrorMessage = "Имя режиссера не может содержать более 100 символов.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Поле 'Жанр' обязательно для заполнения.")]
        [StringLength(50, ErrorMessage = "Название жанра не может содержать более 50 символов.")]
        public string Genre { get; set; }

        [YearRange(1933, 2100, ErrorMessage = "Год должен быть в диапазоне от 1933 до 2100.")]
        public int Year { get; set; }

        public string Poster { get; set; }

        [Required(ErrorMessage = "Поле 'Описание' обязательно для заполнения.")]
        [StringLength(1000, ErrorMessage = "Описание не может содержать более 1000 символов.")]
        public string Description { get; set; }
    }
}
