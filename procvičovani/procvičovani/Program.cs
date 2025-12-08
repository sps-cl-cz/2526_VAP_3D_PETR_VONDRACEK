/*

using System.Globalization;

if (1 < 2)
    Console.WriteLine();

void print(params string[] messages)
{
    foreach (string message in messages)
    {
        Console.WriteLine(message);
    }
}

string input(params string[] messages)
{
    foreach (string message in messages)
    {
        Console.WriteLine(message);
    }
    return Console.ReadLine();
}

(int, int) getMinMax(params int[] numbers)
{
    if (numbers.Length == 0) return (0, 0);

    int min = numbers[0];
    int max = numbers[0];

    for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] < min)
            min = numbers[i];

        if (numbers[i] > max)
            max = numbers[i];
    }

    return (min, max);
}


//procvičování funkcí

// 1. úloha
double ObsahTrojuhelniku(double zakladna, double vyska)
{
    return 0.5 * zakladna * vyska;
}

// 2. úloha
string FormatujCislo(double cislo)
{
    string text = cislo.ToString();
    string[] casti = text.Split(',');
    string celaCast = casti[0];
    string desetinnaCast = "";
    if (casti.Length > 1)
        desetinnaCast += casti[1];
    string vysledek = "";

    return celaCast;

}


string name = input("Zadej název souboru:");
(int min, int max) = getMinMax(1, 2, 4, 5, 6, 7);

print(name, min.ToString(), max.ToString());



// 3. úloha

int CifernySoucet(int cislo)
{
    string num = cislo.ToString();
    int res = 0;
    foreach (char c in num )
    {
        int i = int.Parse(c.ToString());
        res += i;
    }
    return res;
}


int CifernySoucet2(int cislo)
{
    string num = cislo.ToString();
    int res = 0;
    foreach (char c in num)
    {
        int i = int.Parse(c.ToString());
        res += i;
    }
    return res;
}

*/


string JePalindrom(string slovo)
{
    int left = 0;
    int right = slovo.Length - 1;

    while (left < right)
    {
        if (slovo[left] != slovo[right])
            return "false";

        left++;
        right--;
    }
    
    return "true";
 }

Console.WriteLine(JePalindrom("ahoj"));  
Console.WriteLine(JePalindrom("madam"));

{
    List <double> vysledek = new List<double>();
foreach (double c in vysledek)
{
    if (c > 0) vysledek.Add(c);
}
    return vysledek;

}

T Vetsi<T>(T jedna, T dva) where T : IComparable
{
    if (jedna.CompareTo(dva) > 0)
        return dva;
    return jedna;
}

string vetsiText = Vetsi<String>("123", "456");
int vetsiCislo = Vetsi(123, 456);

Action<string> a = (text) =>
{
    Console.WriteLine(text);
}

