namespace Prostopadloscianf
{
    public struct Prostopadloscian
    {
        private double wysokosc, szerokosc, grubosc;

        public Prostopadloscian(double wysokosc, double szerokosc, double grubosc)
        {
            this.wysokosc = wysokosc;
            this.szerokosc = szerokosc;
            this.grubosc = grubosc;
        }

        public Prostopadloscian(double bok) : this(bok, bok, bok) { }

        public override string ToString()
        {
            return $"Prostopadłościan → Wysokość: {wysokosc}, Szerokość: {szerokosc}, Grubość: {grubosc}";
        }
    }
}
