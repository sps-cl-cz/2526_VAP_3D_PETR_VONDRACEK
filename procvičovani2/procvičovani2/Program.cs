Stack<int> ObracenyZasobnik(Stack<int> vstup)
{
    Stack<int> vystup = new Stack<int>();
    foreach (int hodnota in vstup)
    {
    vystup.Push(hodnota);
    }
    return vystup;
}



HashSet<int> Prunik(HashSet<int> a, HashSet<int> b)
{
    HashSet<int> vysledek = new HashSet<int>();
    foreach(var hodnota in a)
    {
    if (b.Contains(hodnota))
        {
            vysledek.Add(hodnota);
        }
    }
    return vysledek;
}


Dictionary<string, int> PocetVyskutu(Stack<string> vstup)
{
    var vysledky = new Dictionary<string, int>();
    while (vstup.Count > 0)
    {
        var retezec = vstup.Pop();
        if (vysledky.ContainsKey(retezec))
        {
            vysledky[retezec]++;
        }
        else
        {
            vysledky[retezec] = 1;
        }
    }
    return vysledky;
}



List<int> cisla = new List<int>()
{
    0, 1, 2, 3, 4, 5, 6
};
List<int> cisla_delitelna_tremi = cisla.Where(x => x % 3 ==0).ToList();
int delitelnPeti = cisla.First(x => x % 5 ==0);

List<int> mocniny = cisla.Select(x => x + x).ToList();
int soucet = cisla.Aggregate((acc, cur) => acc + cur);
int soucet2 = cisla.Sum(x => x);
