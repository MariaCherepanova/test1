using System.ComponentModel.DataAnnotations;
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
        Console.Write(seg2);
    }
    else
    {
        char[] initital = new char[myarr.Length];
        myarr.CopyTo(initital, 0);
        Console.Write(rev(myarr));
        Console.Write(initital);
    }
}
else
{
    char[] result = new ArraySegment<char>(errors, 0, n).ToArray();
    Console.Write("Были введены следующие неподходящие символы: ");Console.Write(result);
}

