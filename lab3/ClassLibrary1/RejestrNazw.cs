using System;
using System.Collections.Generic;


namespace Rejestr
{
    public struct RejestrNazw
    {
        public DateTime DataModyfikacji { get; set; }
        public string Nazwa { get; set; }

        public RejestrNazw(DateTime data, string nazwa)
        {
            DataModyfikacji = data;
            Nazwa = nazwa;
        }

        public override string ToString()
        {
            return $"{DataModyfikacji:G} → {Nazwa}";
        }
    }

  
}
