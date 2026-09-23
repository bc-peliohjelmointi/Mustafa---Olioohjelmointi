namespace kertaus10101- Ovi
﻿{
    internal class Program
{
    enum Oventila { Lukossa, Kiinni, Auki }
    static void Main(string[] args)
    {
        Oventila ovi = Oventila.Lukossa;

        while (true)
        {
            Console.WriteLine("Ovi on nyt:" + ovi);
            Console.WriteLine("Mitä haluat tehdä (avaa lukko, avaa, sulje, lukitse, lopeta): ");
            string komento = Console.ReadLine().ToLower();

            if (komento == "lopeta") break;
            else if (komento == "avaa lukko" && ovi == Oventila.Lukossa) ovi = Oventila.Kiinni;
            else if (komento == "avaa" && ovi == Oventila.Kiinni) ovi = Oventila.Auki;
            else if (komento == "sulje" && ovi == Oventila.Auki) ovi = Oventila.Kiinni;
            else if (komento == "lukitse" && ovi == Oventila.Kiinni) ovi = Oventila.Lukossa;
            else Console.WriteLine("Komentoa ei pysty tehdä");
        }
    }
}
}