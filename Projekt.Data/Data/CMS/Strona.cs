using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Data.Data.CMS
{
    public class Strona : TEntity
    {
        [Key] //klucz podstawowy
        public int IdStrony { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")] // maksymalna długość tytułu
        [Display(Name = "Tytuł odnośnika do strony")]
        public string LinkTytulu { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytuł może zawierać max 30 znaków")] // maksymalna długość tytułu
        [Display(Name = "Tytuł strony")] // tą nazwę będzie widział użytkownik
        public string Tytul { get; set; }

        ///
        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")] // okresla jakiego typu to pole bedzie w bazie danych
        public string Tresc { get; set; }

        [Display(Name = "Pozycja wyświetlania")]
        [Required(ErrorMessage = "Pozycja jest wymagana")]
        public int Pozycja { get; set; }
        

    }
}
