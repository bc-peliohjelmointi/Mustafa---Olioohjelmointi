﻿namespace Tehtävä_6___Ruudukko
{
    internal class Program
    {
        struct Koordinaatti
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Koordinaatti(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool OnVieressä(Koordinaatti toinen)
            {
                int xEro = Math.Abs(X - toinen.X);
                int yEro = Math.Abs(Y - toinen.Y);
                return xEro <= 1 && yEro <= 1 && !(xEro == 0 && yEro == 0);
            }
        }

        static void Main(string[] args)
        {
            Koordinaatti kohde = new Koordinaatti(0, 0);

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Koordinaatti testi = new Koordinaatti(x, y);
                    if (testi.OnVieressä(kohde))
                        Console.WriteLine("Annettu koordinaatti " + x + "," + y + " on koordinaatin 0,0 vieressä.");
                    else
                        Console.WriteLine("Annettu koordinaatti " + x + "," + y + " on koordinaatissa 0,0.");
                }
            }
        }
    }
}
