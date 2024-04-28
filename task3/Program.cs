using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
Dictionary<char,int> uniques(char[] str)
{
    Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in str)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }
    return charCount;
}
char[] rev(char[] arr)
{
    char a;
    for (int i = 0; i < arr.Length / 2; i++)
    {
        a = arr[i];
        arr[i] = arr[arr.Length - i - 1];
        arr[arr.Length - i - 1] = a;
    }
    return arr;
}
char[] myarr = Console.ReadLine().ToCharArray();
char[] input = new char[myarr.Length];
char[] glas = ['a','e','i','o','u','y'];
Dictionary<char,int> res = new Dictionary<char, int>();;
myarr.CopyTo(input,0);
int min = 'a';
int max = 'z';

char[] errors = new char[input.Length];
int n = 0;
for (int i = 0; i < input.Length; i++)
{
    int chr = input[i];
    if(chr < min || chr>max)
    {
       errors[n]=(myarr[i]);
        n++;
    }
}
if (n==0)
    {
        if (myarr.Length % 2 == 0)
    {
        char[] seg1 = rev(new ArraySegment<char>(myarr, 0, myarr.Length / 2).ToArray());
        char[] seg2 = rev(new ArraySegment<char>(myarr, myarr.Length / 2, myarr.Length / 2).ToArray());
        Console.Write(seg1);
        Console.WriteLine(seg2);
        char[] combined = new char[seg1.Length + seg2.Length];
        seg1.CopyTo(combined,0); seg2.CopyTo(combined,seg1.Length);
        res = uniques(combined);
    }
    else
    {
        char[] initital = new char[myarr.Length];
        myarr.CopyTo(initital, 0);
        Console.Write(rev(myarr));
        Console.WriteLine(initital);
        char[] combined = new char[initital.Length * 2];
        myarr.CopyTo(combined,0); initital.CopyTo(combined,myarr.Length);
        res = uniques(combined);
    }
    Console.WriteLine("Количество вхождений каждого символа:");
    foreach (var pair in res)
    {
        Console.WriteLine($"Символ '{pair.Key}': {pair.Value} раз");
    }
}
else
{
    char[] result = new ArraySegment<char>(errors, 0, n).ToArray();
    Console.Write("Были введены следующие неподходящие символы: ");Console.Write(result);
}