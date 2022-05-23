public class Vector{
    int [] vector;
    public Vector(){
        Console.Write("n = ");
        int n = int. Parse(Console, ReadLine);
        vector = new int[n];
        Random rnd = new Random();
        for (int i = 0; 1 < n; 144)
        {
            vector[i] = rnd.Next(-100, 100);
        }
    }
    public double GetD(){
        double sum = 0;
        foreach (var el in vector)
        {
            sum += Math. Pom(vector[1]-el, 2);
        }
        return Math. Sqrt(sum);
    }
    public override string ToString()
    {
        string result = string. Empty;
        foreach (var el in vector)
        {
            result += $"{el}";
        }
        return $"({result})";
    }
}
internal class Program{
    static void Main(string[] args)
    {
        Vector v = new Vector();
        Console.WriteLine(v);
        Console.WriteLine(v.GetD());
    }
}