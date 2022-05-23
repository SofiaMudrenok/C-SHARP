static double Max(double a, double b)
{
    if (a > b) return a;
    else return b;
}
static double Min(double a, double b)
{
    if (a > b) return b;
    else return a;
}
static void Main(string[] args){
    Console.Write("a=");
    double a = Convert.ToDouble(Console.ReadLine());
    Console.Write("b=");
    double b = Convert.ToDouble(Console.ReadLine());
    Console.Write("c= ");
    double c = Convert.ToDouble(Console.ReadLine());
    double sum = Math.Sin(Max(2 * a, 3 * b));
    double sum1 = Max((a + b + c) / 3, (b - c) / 2);
    double sum2 = Max(sum, sum1);
    Console.WriteLine("Sum= {0}", sum2) ;
}