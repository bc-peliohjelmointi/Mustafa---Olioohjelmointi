using System;

class Program
{
    enum KarjenTyyppi
    {
        Puu = 1,
        Teras,
        Timantti
    }

    enum SulanTyyppi
    {
        Lehti = 1,
        Kanansulka,
        Kotkansulka
    }

    class Nuoli
    {
        // Yksityiset kentät
        private KarjenTyyppi karjenTyyppi;
        private SulanTyyppi suloTyyppi;
        private int pituus;

        // Properties (getter + setter)
        public KarjenTyyppi Karjen => karjenTyyppi;
        public SulanTyyppi Sulka => suloTyyppi;
        public int Pituus => pituus;

        // Konstruktori
        public Nuoli(KarjenTyyppi karjenTyyppi, SulanTyyppi suloTyyppi, int pituus)
        {
            this.karjenTyyppi = karjenTyyppi;
            this.suloTyyppi = suloTyyppi;
            this.pituus = pituus;
        }

        // Metodi hinnan laskemiseen
        public int PalautaHinta()
        {
            int hinta = 0;

            // Kärjen hinta
            switch (karjenTyyppi)
            {
                case KarjenTyyppi.Puu: hinta += 3; break;
                case KarjenTyyppi.Teras: hinta += 5; break;
                case KarjenTyyppi.Timantti: hinta += 50; break;
            }

            // Sulan hinta
            switch (suloTyyppi)
            {
                case SulanTyyppi.Lehti: hinta += 0; break;
                case SulanTyyppi.Kanansulka: hinta += 5; break;
                case SulanTyyppi.Kotkansulka: hinta += 10; break;
            }

            // Varren hinta (per cm)
            hinta += pituus * 1;

            return hinta;
        }
    }

    static void Main()
    {
        Console.WriteLine("Minkälainen kärki (1=Puu, 2=Teräs, 3=Timantti)?: ");
        KarjenTyyppi karjen = (KarjenTyyppi)LueValinta(1, 3);

        Console.WriteLine("Minkälaiset sulat (1=Lehti, 2=Kanansulka, 3=Kotkansulka)?: ");
        SulanTyyppi sulka = (SulanTyyppi)LueValinta(1, 3);

        Console.WriteLine("Nuolen pituus sentteinä (60-100): ");
        int pituus = LueValinta(60, 100);

        Nuoli nuoli = new Nuoli(karjen, sulka, pituus);

        Console.WriteLine($"Tämän nuolen hinta on {nuoli.PalautaHinta()} kultarahaa.");
    }

    static int LueValinta(int min, int max)
    {
        int arvo;
        while (true)
        {
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out arvo) && arvo >= min && arvo <= max)
                return arvo;
            Console.WriteLine($"Anna luku väliltä {min}-{max}.");
        }
    }
}
