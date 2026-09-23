namespace NuoliKauppa
{
    internal class Program
    {
        enum Kärki { puu, teräs, timantti }
        enum Perä { lehti, kanansulka, kotkansulka }
        class Nuoli
        {
            private Kärki kärki;
            private Perä perä;
            private int pituus;
            public Kärki HaeKärki() { return kärki; }
            public Perä HaePerä() { return perä; }
            public int HaePituus() { return pituus; }
            public void AsetaKärki(Kärki k) { kärki = k; }
            public void AsetaPerä(Perä p) { perä = p; }
            public void AsetaPituus(int pit) { pituus = pit; }
            public double PalautaHinta()
            {
                double hinta = 0;
                if (kärki == Kärki.puu) hinta += 3;
                else if (kärki == Kärki.teräs) hinta += 5;
                else if (kärki == Kärki.timantti) hinta += 50;
                if (perä == Perä.lehti) hinta += 0;
                else if (perä == Perä.kanansulka) hinta += 1;
                else if (perä == Perä.kotkansulka) hinta += 5;
                hinta += pituus * 0.05;
                return hinta;
            }
        }
        static void Main(string[] args)
        {
            Nuoli nuoli = new Nuoli();
            Console.Write("Minkälainen kärki (puu, teräs, timantti)?: ");
            string syote1 = Console.ReadLine();
            nuoli.AsetaKärki((Kärki)Enum.Parse(typeof(Kärki), syote1));
            Console.Write("Minkälaiset sulat (lehti, kanansulka, kotkansulka)?: ");
            string syote2 = Console.ReadLine();
            nuoli.AsetaPerä((Perä)Enum.Parse(typeof(Perä), syote2));
            Console.Write("Nuolen pituus sentteinä (60-100): ");
            nuoli.AsetaPituus(int.Parse(Console.ReadLine()));
            Console.WriteLine("Tämän nuolen hinta on " + nuoli.PalautaHinta() + " kultarahaa.");
        }
    }
}
