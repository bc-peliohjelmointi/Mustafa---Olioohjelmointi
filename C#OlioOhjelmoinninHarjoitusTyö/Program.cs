internal class Program
{
    class Pelaaja
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pelaaja(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Kolikko
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Kerätty { get; set; }

        public Kolikko(int x, int y)
        {
            X = x;
            Y = y;
            Kerätty = false;
        }
    }

    class Kenttä
    {
        public int Leveys { get; }
        public int Korkeus { get; }
        public Pelaaja Pelaaja { get; }
        public List<Kolikko> Kolikot { get; }
        private int siirrot = 0;

        public Kenttä(int leveys, int korkeus)
        {
            Leveys = leveys;
            Korkeus = korkeus;
            Pelaaja = new Pelaaja(0, 0);
            Kolikot = new List<Kolikko>();

            Random random = new Random();
            int kolikkoMäärä = 7;
            int lisätty = 0;

            while (lisätty < kolikkoMäärä)
            {
                int x = random.Next(0, leveys);
                int y = random.Next(0, korkeus);

                bool onJo = false;
                foreach (Kolikko k in Kolikot)
                {
                    if (k.X == x && k.Y == y) onJo = true;
                }

                if (!onJo && !(x == 0 && y == 0))
                {
                    Kolikot.Add(new Kolikko(x, y));
                    lisätty++;
                }
            }
        }

        public void TulostaPelikenttä()
        {
            Console.Clear();
            for (int y = 0; y < Korkeus; y++)
            {
                for (int x = 0; x < Leveys; x++)
                {
                    if (Pelaaja.X == x && Pelaaja.Y == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[P]");
                    }
                    else
                    {
                        bool onKolikko = false;
                        foreach (Kolikko k in Kolikot)
                        {
                            if (k.X == x && k.Y == y && !k.Kerätty)
                            {
                                onKolikko = true;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("[C]");
                            }
                        }
                        if (!onKolikko)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("[ ]");
                        }
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            int kerätty = 0;
            foreach (Kolikko k in Kolikot)
            {
                if (k.Kerätty) kerätty++;
            }

            Console.WriteLine("Kolikot: " + kerätty + "/" + Kolikot.Count + " | Siirrot: " + siirrot);
            Console.Write("Move (W/A/S/D) or 'Q' to quit: ");
        }

        public bool LiikutaPelaaja(char suunta)
        {
            int uusiX = Pelaaja.X;
            int uusiY = Pelaaja.Y;

            if (suunta == 'w') uusiY--;
            else if (suunta == 's') uusiY++;
            else if (suunta == 'a') uusiX--;
            else if (suunta == 'd') uusiX++;

            if (uusiX >= 0 && uusiX < Leveys && uusiY >= 0 && uusiY < Korkeus)
            {
                Pelaaja.X = uusiX;
                Pelaaja.Y = uusiY;
                siirrot++;

                foreach (Kolikko k in Kolikot)
                {
                    if (k.X == Pelaaja.X && k.Y == Pelaaja.Y && !k.Kerätty)
                    {
                        k.Kerätty = true;
                    }
                }
            }

            return true;
        }

        public bool KaikkiKerätty()
        {
            foreach (Kolikko k in Kolikot)
            {
                if (!k.Kerätty) return false;
            }
            return true;
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Anna kentän leveys: ");
        int leveys = int.Parse(Console.ReadLine());

        Console.Write("Anna kentän korkeus: ");
        int korkeus = int.Parse(Console.ReadLine());

        Kenttä kenttä = new Kenttä(leveys, korkeus);

        while (true)
        {
            kenttä.TulostaPelikenttä();

            if (kenttä.KaikkiKerätty())
            {
                Console.WriteLine("\nKeräsit kaikki kolikot! Peli loppui!");
                break;
            }

            char syote = char.ToLower(Console.ReadKey(true).KeyChar);

            if (syote == 'q') break;

            kenttä.LiikutaPelaaja(syote);
        }
    }
}
