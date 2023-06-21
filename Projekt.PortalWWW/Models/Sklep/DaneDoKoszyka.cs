using Projekt.Data.Data.Sklep;

namespace Projekt.PortalWWW.Models.Sklep
{
    //Klasa pomocnicza, ktora bedzie sluzyla do wyswietlania koszyka
    public class DaneDoKoszyka
    {
        //w celu wyswietlenia koszyka mam liste elementow koszyka i sumaryczna wartosc
        public List<ElementKoszyka> ElementyKoszyka { get; set; }
        public decimal Razem { get; set; }

    }
}
