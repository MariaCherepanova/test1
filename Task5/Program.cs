using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml;
char[] removechar(char[] arr,int ind)
{
    char[] res = new char[arr.Length-1];
    for(int i = 0; i < ind;i++)
    {
        res[i] = arr[i];
    }
    for(int i = ind+1;i < arr.Length;i++)
    {
        res[i-1]=arr[i];
    }
    return res;
}
char[] TreeSort(char[] arr)
{
    ArrayList list = new ArrayList(arr);
    list.Sort();
    return (char[])list.ToArray(typeof(char));
}

char[] QuickSort(char[] arr, int low, int high)
{
    if (low < high)
    {
        int partitionIndex = Partition(arr, low, high);

        QuickSort(arr, low, partitionIndex - 1);
        QuickSort(arr, partitionIndex + 1, high);
    }

    return arr;
}

int Partition(char[] arr, int low, int high)
{
    char pivot = arr[high];
    int i = low - 1;

    for (int j = low; j < high; j++)
    {
        if (arr[j] < pivot)
        {
            i++;
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }

    (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
    return i + 1;
}
void Sort(char[] arr)
{
    Console.WriteLine("Выберите тип сортировки: Q - QuickSort, T - TreeSort");
    string choice = Console.ReadLine();
    while (true)
    {
        if(choice == "Q" || choice =="q")
        {
            Console.Write("Отсортированное значение: ");
            Console.WriteLine(QuickSort(arr,0,arr.Length-1)); break;}
        else if(choice == "T" || choice =="t")
        {
            Console.Write("Отсортированное значение: ");
            Console.WriteLine(TreeSort(arr)); break;}
        else{Console.WriteLine("Пожалуйста, введите корректный ответ");}
    }
    
}
char[] longest(char[] input)
{
    char[] seg = new char[0];
    char[] glas = ['a','e','i','o','u','y'];
    if (input.Length == 1){
        if (glas.Contains(input[0]))
        {
            return input;
        }
        else{return seg;}
    }
    else if (input.Length == 2)
    {
        if (glas.Contains(input[0]) && glas.Contains(input[1])){return input;}
        else if(glas.Contains(input[0])){return [input[0]];}
        else if(glas.Contains(input[1])){return [input[1]];}
        else{return seg;}
    }
    else{
        int a = -1;
        int b = -1;
        
        for (int i = 0; i < input.Length;i++)
        {
            if (glas.Contains(input[i]))
            {
                a = i;break;
            }
        }
        for (int i = input.Length-1; i >=0;i--)
        {
            if (glas.Contains(input[i]))
            {
                b = i;break;
            }
        }
        if (a!=-1 && b != -1)
        {
            if(a == b){return [input[a]];}
            else{
            seg = new ArraySegment<char>(input, a,b-1).ToArray();
            }
        }
        
        return seg;
    }
}
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
char[] Longest;
Dictionary<char,int> res = new Dictionary<char, int>();
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
        char[] combined = new char[seg1.Length + seg2.Length];
        seg1.CopyTo(combined,0); seg2.CopyTo(combined,seg1.Length);
        char[] reservecomb = new char[myarr.Length];
        combined.CopyTo(reservecomb,0);
        res = uniques(combined);
        Longest = longest(combined);
         Console.WriteLine(combined);
        Console.WriteLine("Количество вхождений каждого символа:");
        foreach (var pair in res)
        {
            Console.WriteLine($"Символ '{pair.Key}': {pair.Value} раз");
        }
        if (Longest.Length == 0){Console.WriteLine("Подходящей строки нет");}
        else{Console.Write("Наиболее длинная строка с гласной в начале и конце: ");Console.WriteLine(Longest);}
        Sort(combined);
    }
    else
    {
        char[] initital = new char[myarr.Length];
        
        myarr.CopyTo(initital, 0);
        Console.Write(rev(myarr));
        Console.WriteLine(initital);
        char[] combined = new char[initital.Length * 2];
        myarr.CopyTo(combined,0); initital.CopyTo(combined,myarr.Length);
        Console.WriteLine(combined);
        char[] reservecomb = new char[myarr.Length];
        combined.CopyTo(reservecomb,0);
        res = uniques(combined);
        Longest = longest(combined);
        Console.WriteLine("Количество вхождений каждого символа:");
        foreach (var pair in res)
        {
            Console.WriteLine($"Символ '{pair.Key}': {pair.Value} раз");
        }
        if (Longest.Length == 0){Console.WriteLine("Подходящей строки нет");}
        else{Console.Write("Наиболее длинная строка с гласной в начале и конце: ");Console.WriteLine(Longest);}
        Sort(combined);
    }
    
    
}
else
{
    char[] result = new ArraySegment<char>(errors, 0, n).ToArray();
    Console.Write("Были введены следующие неподходящие символы: ");Console.Write(result);
}