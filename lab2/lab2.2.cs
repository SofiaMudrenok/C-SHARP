Console.Write("m=");
int m = int. Parse(Console.ReadLine());
Console.Write("T=");
int T = int. Parse(Console.ReadLine()) ;
int n = 1;
int[,] matrix = new int[m, n];
Random rnd = new Random();
for (int i = 0; i < m; i++){
    for (int j = 0; j < n; j++){
        matrix[i, j] = rnd.Next (9);
        Console.WriteLine($"[{i}, {j}] {matrix[i, j]}");
    }
}
int[,] vector = new int[n,m];
for (int i = 0; i < n; i++){
    for (int j = 0; j < m; j++){
        vector[i, i] = rnd. Next(9);
        Console.WriteLine($"[{i}, {j}] {vector[i, j]}");
    }
}
int[,] y = new int[n, m];
for (int i = 0; i < m; i++){
    for (int j = 0; j < m; j++){
        y[i, j] =(int )Math. Pom (vector[0, j],T) * matrix[i,0];
        Console.WriteLine($"[{i}, {j}] {y[i,j]}");
    }
}
