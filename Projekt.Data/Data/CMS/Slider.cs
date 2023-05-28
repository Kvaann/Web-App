using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data.Data.CMS
{
    public class Slider : TEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(15, ErrorMessage = "Nazwa może zawierać max 15 znaków")] // maksymalna długość nazwy
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        [MaxLength(30, ErrorMessage = "Opis może zawierać max 30 znaków")] // maksymalna długość nazwy
        public string Opis { get; set; }
        public bool CzyAktywna { get; set; }
    }
}
