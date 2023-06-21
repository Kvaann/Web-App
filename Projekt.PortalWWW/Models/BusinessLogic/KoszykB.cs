using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;
using Projekt.Data.Data.Sklep;

namespace Projekt.PortalWWW.Models.BusinessLogic
{
    //to jest klasa, ktora bedzie zawierala operacje biznesowe na koszyku
    public class KoszykB
    {
        #region Properties
        private readonly ProjektContext _context; // polaczenie do bazy danych
        public string IdSesjiKoszyka { get; set; } // Id sesji klienta
        #endregion

        #region Konstruktor
        public KoszykB(ProjektContext context, HttpContext httpContext)
        {
            _context = context;
            IdSesjiKoszyka = GetIdSesjiKoszyka(httpContext);
        }
        #endregion

        #region Metody

        //funkcja okreslajaca sesje
        private string GetIdSesjiKoszyka(HttpContext httpContext)
        {
            //jezeli w sesji IdSesji koszuka jest nullem, a wiec nie ma okreslonego identyfikatora przegladarki,
            // to najpierw sprawdzamy czy mozemy ten identyfikator przeczytac z Contextu. 

            if (httpContext.Session.GetString("IdSesjiKoszyka") == null)
            {
                if (!string.IsNullOrEmpty(httpContext.User.Identity.Name))
                {
                    // Jezeli w httpContex'ie name nie jest nullem to ten name staje sie Id sesji koszyka
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    // jezeli bedzie nullem wygenerujemy unikalny numer sesji przy pomocy guid'a
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    // i ustawiamy go do id sesji koszyka
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka").ToString();
        }

        // funkcja dodajaca nowe elementy do koszyka
        public void DodajDoKoszyka(Danie danie)
        {
            // sprawdzenie czy takie element juz nie istnieje w koszyku
            var elementKoszyka =
                (
                    from element in _context.ElementKoszyka
                    where element.IdSesjiKoszyka == this.IdSesjiKoszyka && element.IdDania == danie.IdDania
                    select element
                ).FirstOrDefault();
            if (elementKoszyka == null) //jezeli brak tego towaru w koszyku
            {
                //tworzymy element w koszyku
                elementKoszyka = new ElementKoszyka()
                {
                    IdSesjiKoszyka = this.IdSesjiKoszyka,
                    IdDania = danie.IdDania,
                    Danie = _context.Danie.Find(danie.IdDania),
                    Ilosc = 1,
                    DataUtworzenia = DateTime.Now
                };
                //dodajemy element koszyka do bazy danych
                _context.ElementKoszyka.Add(elementKoszyka);
            }
            else //jezeli ten element jest juz w koszuku to zwiekszamy go ++
            {
                elementKoszyka.Ilosc++;
            }
            // zapis zmiany do bazy danych
            _context.SaveChanges();
        }

        //funkcja pobiera wszystkie elementy koszyka danej przegladarki
        public async Task<List<ElementKoszyka>> GetElementyKoszyka()
        {
            return await _context.ElementKoszyka.Where(e => e.IdSesjiKoszyka == this.IdSesjiKoszyka).Include(e => e.Danie).ToListAsync();
        }
        // funkcja obliczajaca wartosc koszyka
        public async Task<decimal> GetRazem()
        {
            var items =
            (
                from element in _context.ElementKoszyka
                where element.IdSesjiKoszyka == this.IdSesjiKoszyka
                select (decimal?)element.Ilosc * element.Danie.Cena
            );
            return await items.SumAsync() ?? 0;
        }

        #endregion

    }
}
