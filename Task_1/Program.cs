/* Имеется массив из n элементов. Неоходимо найти максимальную сумму трёх чисел из массива. 
// array - 10
// m - 3
i   v                               это цикл foh по i
   [8, 9, 7, 8, 8, 9, 9, 1, 7, 5]
j   ^  ^  ^                         это цикл for по j                          
*/
using System.Diagnostics; // это всё читает время 
internal class Program
{
    private static void Main(string[] args)
    {
        int size = 1_0;
        int m = 3;
        int[] array = Enumerable.Range(1, size)
                                 .Select(item => Random.Shared.Next(10))
                                 .ToArray();
        Console.WriteLine($"[{string.Join(", ", array)}]");
        Stopwatch sw = new(); // это всё читает время 
        sw.Start(); // это всё читает время 
        int max = 0;
        for (int i = 0; i < array.Length - m; i++) // - m что бы не вывалиться за массив, т.к. цикл по j проходит по 3м элементам 
        {
            int t = 0;
            for (int j = i; j < i + m; j++)
            {
                t = t + array[j];
            }
            if (t > max) max = t;
        }
        sw.Stop();
        Console.WriteLine($"time = {sw.ElapsedMilliseconds}");
        Console.WriteLine($"Способ 1: {max}");
        // второй способ в разы эффективней 
        nt max1 = 0;
        for (int j = 0; j < m; j++) max1 += array[j];
        int t1 = max1;
        for (int i = 1; i < array.Length - m; i++)
        {
            t1 = t1 - array[i - 1] + array[i + (m - 1)];
            if (t1 > max1) max1 = t1;
        }
        Console.WriteLine($"Способ 2: {max1}");
    }
}