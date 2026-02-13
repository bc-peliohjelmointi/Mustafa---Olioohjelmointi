using System;

public class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }

    public Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }

    public override string ToString()
    {
        return "Tavara";
    }
}

public class Miekka : Tavara
{
    public Miekka() : base(5.0, 3.0) { }
    public override string ToString() => "Miekka";
}

public class Kirves : Tavara
{
    public Kirves() : base(6.0, 3.5) { }
    public override string ToString() => "Kirves";
}

public class VaritettyTavara<T>
{
    public T Tavara { get; }
    public ConsoleColor Vari { get; }

    public VaritettyTavara(T tavara, ConsoleColor vari)
    {
        Tavara = tavara;
        Vari = vari;
    }

    public void NaytaTavara()
    {
        var alkuperainenVari = Console.ForegroundColor;
        Console.ForegroundColor = Vari;
        Console.WriteLine(Tavara.ToString());
        Console.ForegroundColor = alkuperainenVari;
    }
}

class Program
{
    static void Main()
    {
        var punainenMiekka = new VaritettyTavara<Miekka>(new Miekka(), ConsoleColor.Red);
        var sininenKirves = new VaritettyTavara<Kirves>(new Kirves(), ConsoleColor.Blue);

        punainenMiekka.NaytaTavara();
        sininenKirves.NaytaTavara();
    }
}
