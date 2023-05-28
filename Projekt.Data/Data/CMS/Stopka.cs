using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projekt.Data.Data.CMS
{
    public class Stopka : TEntity
    {
        [Key] //klucz podstawowy
        public int IdStopka { get; set; }

        [Display(Name = "Kontakt")]
        public string Kontakt { get; set; }
        [Required(ErrorMessage = "Lokalizacja jest wymagana")]
        [MaxLength(15, ErrorMessage = "Lokalizacja może zawierać max 15 znaków")]
        public string Lokalizacja { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagana")]
        [MaxLength(12, ErrorMessage = "Lokalizacja może zawierać max 12 znaków")]
        public string NrTelefonu { get; set; }

        [Required(ErrorMessage = "Adres mailowy jest wymagany")]
        [MaxLength(20, ErrorMessage = "Lokalizacja może zawierać max 20 znaków")]
        public string AdresEmail { get; set; }

        [Display(Name = "Opis")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Opis jest wymagana")]
        [MaxLength(15, ErrorMessage = "Opis może zawierać max 15 znaków")]
        public string Tresc { get; set; }

        [Display(Name = "Godziny otwarcia")]
        public string GodzinyOtwarcia { get; set; }
        [Required(ErrorMessage = "Godziny otwarcia są wymagane")]
        [MaxLength(20, ErrorMessage = "Godziny otwarcia mogą zawierać max 20 znaków")]
        public string Godziny { get; set; }


    }
}
