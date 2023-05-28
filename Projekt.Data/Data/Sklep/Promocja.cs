using System.ComponentModel.DataAnnotations;

namespace Projekt.Data.Data.Sklep
{
    public class Promocja : TEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(15, ErrorMessage = "Nazwa może zawierać max 15 znaków")] // maksymalna długość nazwy
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Opus jest wymagany")]
        [MaxLength(30, ErrorMessage = "Opis może zawierać max 30 znaków")] // maksymalna długość nazwy
        public string Opis { get; set; }
        public string FotoURL { get; set; }
        public bool CzyAktywna { get; set; }
    }
}
