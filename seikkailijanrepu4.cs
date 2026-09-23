using System;
using System.Linq;

class Program
{
    
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

    
    static void Main(string[] args)
        {
            Reppu reppu = new Reppu(10, 30, 20);

            Console.WriteLine(reppu.ToString());

            while (true)
            {
                reppu.TulostaStatus();
                Console.WriteLine("Mitä haluat lisätä?");
                Console.WriteLine("1 - Nuoli");
                Console.WriteLine("2 - Jousi");
                Console.WriteLine("3 - Köysi");
                Console.WriteLine("4 - Vettä");
                Console.WriteLine("5 - Ruokaa");
                Console.WriteLine("6 - Miekka");

                string syote = Console.ReadLine();

                Tavara valittu = null;
                if (syote == "1") valittu = new Nuoli();
                else if (syote == "2") valittu = new Jousi();
                else if (syote == "3") valittu = new Köysi();
                else if (syote == "4") valittu = new Vesi();
                else if (syote == "5") valittu = new Ruoka();
                else if (syote == "6") valittu = new Miekka();

                if (valittu != null)
                {
                    bool onnistui = reppu.Lisää(valittu);
                    if (!onnistui)
                        Console.WriteLine("Reppu on täynnä, tavara ei mahdu!");
                }

                Console.WriteLine(reppu.ToString());
            }
        }
    }
}
