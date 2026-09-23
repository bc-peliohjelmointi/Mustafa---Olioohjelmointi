using System;

struct Koordinaatti
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Koordinaatti(int x, int y)
    {
        X = x;
        Y = y;
    }

    
    public bool OnVierekkaen(Koordinaatti toinen)
    {
       
        return (Math.Abs(this.X - toinen.X) == 1 && this.Y == toinen.Y)
            || (Math.Abs(this.Y - toinen.Y) == 1 && this.X == toinen.X);
    }

    public override string ToString()
    {
        return $"({X},{Y})";
    }
}

class Program
{
    static void Main()
    {
        Koordinaatti k1 = new Koordinaatti(2, 3);
        Koordinaatti k2 = new Koordinaatti(3, 3);
        Koordinaatti k3 = new Koordinaatti(2, 4);
        Koordinaatti k4 = new Koordinaatti(5, 5);

        Console.WriteLine($"{k1} ja {k2} vierekkäin? {k1.OnVierekkaen(k2)}");
        Console.WriteLine($"{k1} ja {k3} vierekkäin? {k1.OnVierekkaen(k3)}");
        Console.WriteLine($"{k1} ja {k4} vierekkäin? {k1.OnVierekkaen(k4)}");
    }
}
