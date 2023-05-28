using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Data.Data.CMS
{
    public class ONas : TEntity
    {
        [Key] //klucz podstawowy
        public int IdONas { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytuł może zawierać max 10 znaków")] // maksymalna długość tytułu
        [Display(Name = "Tytuł o nas")]
        
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")] // okresla jakiego typu to pole bedzie w bazie danych
        public string Tresc { get; set; }

    }
}
