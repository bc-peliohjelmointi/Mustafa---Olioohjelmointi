namespace VäritetytTavarat
{
    internal class Program
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
        }
        class Miekka : Tavara
        {
            public Miekka() : base(5, 3) { }
            public override string ToString() { return "Miekka"; }
        }
        class Jousi : Tavara
        {
            public Jousi() : base(1, 4) { }
            public override string ToString() { return "Jousi"; }
        }
        class Kirves : Tavara
        {
            public Kirves() : base(3, 2) { }
            public override string ToString() { return "Kirves"; }
        }
        class VäritettyTavara<T>
        {
            public T Tavara { get; }
            public ConsoleColor Väri { get; }
            public VäritettyTavara(T tavara, ConsoleColor väri)
            {
                Tavara = tavara;
                Väri = väri;
            }
            public void NäytäTavara()
            {
                Console.ForegroundColor = Väri;
                Console.WriteLine(Tavara.ToString());
                Console.ResetColor();
            }
        }
        static void Main(string[] args)
        {
            VäritettyTavara<Miekka> väritettyMiekka = new VäritettyTavara<Miekka>(new Miekka(), ConsoleColor.Red);
            VäritettyTavara<Jousi> väritettyJousi = new VäritettyTavara<Jousi>(new Jousi(), ConsoleColor.Green);
            VäritettyTavara<Kirves> väritettyKirves = new VäritettyTavara<Kirves>(new Kirves(), ConsoleColor.Yellow);
            väritettyMiekka.NäytäTavara();
            väritettyJousi.NäytäTavara();
            väritettyKirves.NäytäTavara();
        }
    }
}