using System.Collections.Generic;

namespace Obywatelf
{
    public class Obywatel
    {
        private string nazwisko;
        private string pesel;

        public static List<Obywatel> Obywatele = new List<Obywatel>();

        public Obywatel(string nazwisko, string pesel)
        {
            this.nazwisko = nazwisko;
            this.pesel = pesel;
            Obywatele.Add(this);
        }

        public override string ToString()
        {
            return $"Nazwisko: {nazwisko}, PESEL: {pesel}";
        }
    }
}
