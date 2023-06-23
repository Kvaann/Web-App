using System.ComponentModel.DataAnnotations;

namespace Projekt.Data.Data.Sklep
{
    public class ElementKoszyka
    {
        [Key]
        public int IdElementuKoszyka { get; set; }
        public string IdSesjiKoszyka { get; set; }
        public int IdDania { get; set; }
        public Danie Danie { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataUtworzenia { get; set; }
    }
}
