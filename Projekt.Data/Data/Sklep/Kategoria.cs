using System.ComponentModel.DataAnnotations;

namespace Projekt.Data.Data.Sklep
{
    public class Kategoria : TEntity
    {
        [Key]
        public int IdKategorii { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(10, ErrorMessage = "Nazwa może zawierać max 30 znaków")] // maksymalna długość nazwy
        public string Nazwa { get; set; }
        public string Opis { get; set; }



    }
}
