using System;

class Program
{
   
    interface IRobottiKäsky
    {
        void Suorita(Robotti robotti);
    }

    
    class Robotti
    {
        private bool käynnissä;
        private int x;
        private int y;
        public IRobottiKäsky[] Käskyt { get; set; }

        public Robotti()
        {
            käynnissä = false;
            x = 0;
            y = 0;
        }

        public void Käynnistä()
        {
            käynnissä = true;
            Console.WriteLine("Robotti käynnistyi.");
        }

        public void Sammuta()
        {
            käynnissä = false;
            Console.WriteLine("Robotti sammui.");
        }

        public bool OnKäynnissä() => käynnissä;

        public void Liiku(int dx, int dy)
        {
            if (!käynnissä) return;
            x += dx;
            y += dy;
            Console.WriteLine($"Robotti siirtyi kohtaan ({x},{y}).");
        }

        public void Suorita()
        {
            foreach (var käsky in Käskyt)
            {
                käsky.Suorita(this);
            }
        }
    }

   
    class KäynnistäKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            robotti.Käynnistä();
        }
    }

    class SammutaKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            robotti.Sammuta();
        }
    }

    class YlösKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            robotti.Liiku(0, 1);
        }
    }

    class AlasKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            robotti.Liiku(0, -1);
        }
    }

    class VasenKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            robotti.Liiku(-1, 0);
        }
    }

    class OikeaKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            robotti.Liiku(1, 0);
        }
    }

    static void Main()
    {
        Robotti robotti = new Robotti();
        robotti.Käskyt = new IRobottiKäsky[3];

        Console.WriteLine("Anna 3 käskyä (käynnistä, sammuta, ylös, alas, vasen, oikea):");

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"{i + 1}. käsky: ");
            string syöte = Console.ReadLine().Trim().ToLower();

            switch (syöte)
            {
                case "käynnistä": robotti.Käskyt[i] = new KäynnistäKäsky(); break;
                case "sammuta": robotti.Käskyt[i] = new SammutaKäsky(); break;
                case "ylös": robotti.Käskyt[i] = new YlösKäsky(); break;
                case "alas": robotti.Käskyt[i] = new AlasKäsky(); break;
                case "vasen": robotti.Käskyt[i] = new VasenKäsky(); break;
                case "oikea": robotti.Käskyt[i] = new OikeaKäsky(); break;
                default:
                    Console.WriteLine("Tuntematon käsky, yritä uudelleen.");
                    i--;
                    break;
            }
        }

        Console.WriteLine("\nSuoritetaan käskyt:");
        robotti.Suorita();
    }
}
