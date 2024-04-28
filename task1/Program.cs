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
