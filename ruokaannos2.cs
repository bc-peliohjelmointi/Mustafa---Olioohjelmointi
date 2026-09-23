using System;
using System.Collections.Generic;

class Program
{
    enum PaaRaakaAine
    {
        Nautaa = 1,
        Kanaa,
        Kasviksia
    }

    enum Lisuke
    {
        Perunaa = 1,
        Riisia,
        Pastaa
    }

    enum Kastike
    {
        Curry = 1,
        Hapanimela,
        Pippuri,
        Chili
    }

    class Ateria
    {
        public PaaRaakaAine Paa { get; set; }
        public Lisuke Lisuke { get; set; }
        public Kastike Kastike { get; set; }

        public override string ToString()
        {
            return $"{Paa.ToString().ToLower()} ja {Lisuke.ToString().ToLower()} {Kastike.ToString().ToLower()}-kastikkeella";
        }
    }

    static void Main()
    {
        List<Ateria> annokset = new List<Ateria>();

        for (int i = 1; i <= 3; i++) 
        {
            Console.WriteLine($"\nValitse annos {i}:");

            PaaRaakaAine paa = (PaaRaakaAine)KysyValinta<PaaRaakaAine>("Pääraaka-aine");
            Lisuke lisuke = (Lisuke)KysyValinta<Lisuke>("Lisuke");
            Kastike kastike = (Kastike)KysyValinta<Kastike>("Kastike");

            annokset.Add(new Ateria { Paa = paa, Lisuke = lisuke, Kastike = kastike });
        }

        Console.WriteLine("\nValitsemasi annokset:");
        foreach (var ateria in annokset)
        {
            Console.WriteLine(ateria);
        }
    }

    static int KysyValinta<T>(string otsikko) where T : Enum
    {
        Console.WriteLine(otsikko + ":");
        foreach (var arvo in Enum.GetValues(typeof(T)))
        {
            Console.WriteLine($"{(int)arvo} = {arvo}");
        }

        int valinta;
        while (true)
        {
            Console.Write("Valintasi: ");
            if (int.TryParse(Console.ReadLine(), out valinta) &&
                Enum.IsDefined(typeof(T), valinta))
            {
                return valinta;
            }
            Console.WriteLine("Virheellinen valinta, yritä uudelleen.");
        }
    }
}
