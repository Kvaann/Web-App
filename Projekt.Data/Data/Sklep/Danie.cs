using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projekt.Data.Data.Sklep
{
    public class Danie : TEntity
    {
        [Key]
        public int IdDania { get; set; }
        [Required(ErrorMessage = "Kod jest wymagany")]
        public string Kod { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa może zawierać max 30 znaków")] // maksymalna długość nazwy
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")] // okresla jakiego typu to pole bedzie w bazie danych
        public decimal Cena { get; set; }

        [Display(Name = "Wybierz zdjęcie")] // tą nazwę będzie widział użytkownik
        public byte[] FotoURL { get; set; }
        public string Opis { get; set; }

        //to jest realizacja klucza obcego
        public int KategoriaId { get; set; }
        public Kategoria Kategoria { get; set; }
    }
}
