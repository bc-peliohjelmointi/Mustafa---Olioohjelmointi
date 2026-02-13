using System;
using System.Linq;

class Program
{
    // ---------------- ENUMS & BASE CLASS ----------------
    class Tavara
    {
        public double Paino { get; }
        public double Tilavuus { get; }

        public Tavara(double paino, double tilavuus)
        {
            Paino = paino;
            Tilavuus = tilavuus;
        }

        public override string ToString()
        {
            return "Tavara";
        }
    }

    // ---------------- ITEM CLASSES ----------------
    class Miekka : Tavara
    {
        public Miekka() : base(5.0, 3.0) { }
        public override string ToString() => "Miekka";
    }

    class Jousi : Tavara
    {
        public Jousi() : base(2.0, 2.5) { }
        public override string ToString() => "Jousi";
    }

    class Köysi : Tavara
    {
        public Köysi() : base(1.5, 1.0) { }
        public override string ToString() => "Köysi";
    }

    class Vesi : Tavara
    {
        public Vesi() : base(1.0, 1.0) { }
        public override string ToString() => "Vesi";
    }

    // ---------------- BACKPACK CLASS ----------------
    class Reppu
    {
        private Tavara[] tavarat;
        private int tavaroidenLkm;
        public int MaksimiMaara { get; }
        public double MaksimiPaino { get; }
        public double MaksimiTilavuus { get; }

        public int TavaroidenLkm => tavaroidenLkm;
        public double NykyPaino => tavarat.Take(tavaroidenLkm).Sum(t => t.Paino);
        public double NykyTilavuus => tavarat.Take(tavaroidenLkm).Sum(t => t.Tilavuus);

        public Reppu(int maxMaara, double maxPaino, double maxTilavuus)
        {
            MaksimiMaara = maxMaara;
            MaksimiPaino = maxPaino;
            MaksimiTilavuus = maxTilavuus;
            tavarat = new Tavara[maxMaara];
            tavaroidenLkm = 0;
        }

        public bool Lisää(Tavara tavara)
        {
            if (tavaroidenLkm >= MaksimiMaara) return false;
            if (NykyPaino + tavara.Paino > MaksimiPaino) return false;
            if (NykyTilavuus + tavara.Tilavuus > MaksimiTilavuus) return false;

            tavarat[tavaroidenLkm++] = tavara;
            return true;
        }

        public override string ToString()
        {
            if (tavaroidenLkm == 0)
                return "Reppu on tyhjä.";
            return "Reppussa on seuraavat tavarat: " +
                   string.Join(", ", tavarat.Take(tavaroidenLkm).Select(t => t.ToString()));
        }
    }

    // ---------------- MAIN ----------------
    static void Main()
    {
        Reppu reppu = new Reppu(5, 15.0, 10.0);

        while (true)
        {
            Console.WriteLine("\n" + reppu);
            Console.WriteLine($"Tavaroita: {reppu.TavaroidenLkm}/{reppu.MaksimiMaara}, Paino: {reppu.NykyPaino}/{reppu.MaksimiPaino}, Tilavuus: {reppu.NykyTilavuus}/{reppu.MaksimiTilavuus}");
            Console.WriteLine("\nValitse lisättävä tavara:");
            Console.WriteLine("1) Miekka");
            Console.WriteLine("2) Jousi");
            Console.WriteLine("3) Köysi");
            Console.WriteLine("4) Vesi");
            Console.WriteLine("0) Lopeta");

            Console.Write("> ");
            string valinta = Console.ReadLine();

            if (valinta == "0")
                break;

            Tavara uusiTavara = null;
            switch (valinta)
            {
                case "1": uusiTavara = new Miekka(); break;
                case "2": uusiTavara = new Jousi(); break;
                case "3": uusiTavara = new Köysi(); break;
                case "4": uusiTavara = new Vesi(); break;
                default: Console.WriteLine("Virheellinen valinta."); continue;
            }

            if (!reppu.Lisää(uusiTavara))
                Console.WriteLine("Tavaraa ei voi lisätä, kapasiteetti ylittyy.");
            else
                Console.WriteLine($"{uusiTavara} lisätty reppuun.");
        }
    }
}
