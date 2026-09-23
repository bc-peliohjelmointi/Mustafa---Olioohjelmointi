namespace Tehtävä_5___Robotti
{
    internal class Program
    {
        interface IRobottiKäsky
        {
            void Suorita(Robotti robotti);
        }

        class Robotti
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool OnKäynnissä { get; set; }
            public IRobottiKäsky?[] Käskyt { get; } = new IRobottiKäsky?[3];

            public void Suorita()
            {
                foreach (IRobottiKäsky? käsky in Käskyt)
                {
                    käsky?.Suorita(this);
                    Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
                }
            }
        }

        class Käynnistä : IRobottiKäsky
        {
            public void Suorita(Robotti robotti) { robotti.OnKäynnissä = true; }
        }

        class Sammuta : IRobottiKäsky
        {
            public void Suorita(Robotti robotti) { robotti.OnKäynnissä = false; }
        }

        class YlösKäsky : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä) robotti.Y++;
            }
        }

        class AlasKäsky : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä) robotti.Y--;
            }
        }

        class OikeaKäsky : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä) robotti.X++;
            }
        }

        class VasenKäsky : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä) robotti.X--;
            }
        }

        static void Main(string[] args)
        {
            Robotti robotti = new Robotti();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Mitä komentoja syötetään robotille? Vaihtoehdot: Käynnistä, Sammuta, Ylös, Alas, Oikea, Vasen. ");
                string syote = Console.ReadLine();

                if (syote == "Käynnistä") robotti.Käskyt[i] = new Käynnistä();
                else if (syote == "Sammuta") robotti.Käskyt[i] = new Sammuta();
                else if (syote == "Ylös") robotti.Käskyt[i] = new YlösKäsky();
                else if (syote == "Alas") robotti.Käskyt[i] = new AlasKäsky();
                else if (syote == "Oikea") robotti.Käskyt[i] = new OikeaKäsky();
                else if (syote == "Vasen") robotti.Käskyt[i] = new VasenKäsky();
            }

            Console.WriteLine();
            Console.Write("Robotti: ");
            robotti.Suorita();
        }
    }
}
