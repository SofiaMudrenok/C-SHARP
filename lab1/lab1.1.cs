int a = int.Parse(Console.ReadLine());
int[] numbers = new int[4];
numbers[2]=(a/100)%10; 
numbers[1]=(a/10)%10;
Console.WriteLine(numbers[1]* numbers[2]);