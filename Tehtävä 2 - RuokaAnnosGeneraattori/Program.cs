namespace RuokaAnnos
{
    internal class Program
    {
        enum Pääraaka { nautaa, kanaa, kasviksia }
        enum Lisuke { perunaa, riisiä, pastaa }
        enum Kastike { curry, hapanimelä, pippuri, chili }
        class Ateria
        {
            public Pääraaka pääraaka;
            public Lisuke lisuke;
            public Kastike kastike;
        }
        static void Main(string[] args)
        {
            List<Ateria> aterialista = new List<Ateria>();
            for (int i = 0; i < 3; i++)
            {
                Ateria uusiAteria = new Ateria();
                Console.Write("Pääraaka-aine (nautaa, kanaa, kasviksia): ");
                string syote1 = Console.ReadLine();
                uusiAteria.pääraaka = (Pääraaka)Enum.Parse(typeof(Pääraaka), syote1);
                Console.Write("Lisukkeet (perunaa, riisiä, pastaa): ");
                string syote2 = Console.ReadLine();
                uusiAteria.lisuke = (Lisuke)Enum.Parse(typeof(Lisuke), syote2);
                Console.Write("Kastike (curry, hapanimelä, pippuri, chili): ");
                string syote3 = Console.ReadLine();
                uusiAteria.kastike = (Kastike)Enum.Parse(typeof(Kastike), syote3);
                aterialista.Add(uusiAteria);
            }
            foreach (Ateria a in aterialista)
            {
                Console.WriteLine(a.pääraaka + " ja " + a.lisuke + " " + a.kastike + "-kastikkeella");
            }
        }
    }
}