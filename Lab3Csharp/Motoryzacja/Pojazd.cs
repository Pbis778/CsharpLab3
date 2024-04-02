using System;
using System.Collections.Generic;

namespace Motoryzacja
{
    struct RejestrNazw
    {
        public DateTime DataModyfikacji { get; set; }
        public string Nazwa { get; set; }

        public RejestrNazw(DateTime dataModyfikacji, string nazwa)
        {
            DataModyfikacji = dataModyfikacji;
            Nazwa = nazwa;
        }

        public override string ToString()
        {
            return $"{DataModyfikacji}: {Nazwa}";
        }
    }

    public class Pojazd
    {
        public string Nazwa { get; set; }
        private int liczbaKol;
        private double predkosc;
        public int Lp { get; }

        private static int liczbaPojazdow = 0;
        private List<RejestrNazw> HistoriaNazw { get; set; }

        public Pojazd()
        {
            Lp = liczbaPojazdow++;
            HistoriaNazw = new List<RejestrNazw>();
        }

        public int LiczbaKol
        {
            get { return this.liczbaKol; }
            set
            {
                if (value < 2)
                {
                    throw new ArgumentException();
                }
                else { this.liczbaKol = value; };
            }
        }

        public double Predkosc
        {
            get { return predkosc; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else { this.predkosc = value; };
            }
        }

        public Pojazd(string nazwa, int liczbaKol, double predkosc) : this()
        {
            Nazwa = nazwa;
            LiczbaKol = liczbaKol;
            Predkosc = predkosc;
            DodajDoHistorii();
        }

        public Pojazd(string nazwa, double predkosc) : this(nazwa, 4, predkosc) { }

        public void DodajDoHistorii()
        {
            HistoriaNazw.Add(new RejestrNazw(DateTime.Now, Nazwa));
        }

        public List<string> PobierzHistorie()
        {
            List<string> historia = new List<string>();
            foreach (var rejestrNazw in HistoriaNazw)
            {
                historia.Add(rejestrNazw.ToString());
            }
            return historia;
        }

        public override string ToString()
        {
            return $"Liczba pojazdów: {Lp + 1}/{liczbaPojazdow}, Nazwa: {Nazwa}, Liczba kół: {liczbaKol}, Prędkość: {predkosc}";
        }
    }

    public class PojazdMechaniczny : Pojazd
    {
        public double MocSilnika { get; set; }

        public PojazdMechaniczny(string nazwa, int liczbaKol, double predkosc, double mocSilnika) : base(nazwa, liczbaKol, predkosc)
        {
            MocSilnika = mocSilnika;
        }

        public override string ToString()
        {
            return base.ToString() + $", Moc silnika: {MocSilnika}";
        }
    }

    public class Samochod : PojazdMechaniczny
    {
        public int LiczbaPasazerow { get; set; }
        public string Marka { get; set; }

        public Samochod(string nazwa, int liczbaKol, double predkosc, double mocSilnika, int liczbaPasazerow, string marka) : base(nazwa, liczbaKol, predkosc, mocSilnika)
        {
            LiczbaPasazerow = liczbaPasazerow;
            Marka = marka;
        }

        public override string ToString()
        {
            return base.ToString() + $", Liczba pasazerow: {LiczbaPasazerow}, Marka samochodu: {Marka}";
        }
    }
}
