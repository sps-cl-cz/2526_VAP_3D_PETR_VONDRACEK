//úkol 1
string VypocetPrumerneRychlosti(double vzdalenostKm, double casMin)
{
   
    if (vzdalenostKm < 0 || casMin < 0)
    {
        return "Neplatné hodnoty";
    }

    
    if (casMin == 0 && vzdalenostKm > 0)
    {
        return "Nelze vypočítat (dělení nulou)";
    }

    double casHod = casMin / 60.0;
    double prumernaRychlost = (casHod == 0) ? 0 : vzdalenostKm / casHod;

    return $"Průměrná rychlost: {prumernaRychlost:F2} km/h";
}

Console.WriteLine(VypocetPrumerneRychlosti(10, 30));  // Průměrná rychlost: 20,00 km/h
Console.WriteLine(VypocetPrumerneRychlosti(0, 45));   // Průměrná rychlost: 0,00 km/h
Console.WriteLine(VypocetPrumerneRychlosti(5, 0));    // Nelze vypočítat (dělení nulou)
Console.WriteLine(VypocetPrumerneRychlosti(-5, -1));  // Neplatné hodnoty


//úkol 2
int PocetSamohlasek(string text)
{
    if (string.IsNullOrEmpty(text))
        return 0;

    string samohlasky = "aáeěéiíoóuúůyý";

    int pocet = 0;
    foreach (char c in text.ToLower())
    {
        if (samohlasky.Contains(c))
        {
            pocet++;
        }
    }

    return pocet;
}

Console.WriteLine(PocetSamohlasek("Ahoj světe!")); // 4
Console.WriteLine(PocetSamohlasek("ČÁRY MÁRY"));    // 4
Console.WriteLine(PocetSamohlasek(null));           // 0
Console.WriteLine(PocetSamohlasek("AbC"));          // 1


//úkol 3
List<int> ZpracujPole(int[] pole)
{
    if (pole == null)
        return new List<int>();

    List<int> vysledek = new List<int>();

    
    foreach (int cislo in pole)
    {
        if (cislo >= 0 && !vysledek.Contains(cislo))
        {
            vysledek.Add(cislo);
        }
    }

    
    if (vysledek.Count == 0)
        return new List<int>();

    
    for (int i = 0; i < vysledek.Count - 1; i++)
    {
        for (int j = 0; j < vysledek.Count - i - 1; j++)
        {
            if (vysledek[j] > vysledek[j + 1])
            {
                
                int temp = vysledek[j];
                vysledek[j] = vysledek[j + 1];
                vysledek[j + 1] = temp;
            }
        }
    }

    return vysledek;
}

Console.WriteLine(string.Join(", ", ZpracujPole(new int[] { 3, -1, 3, 0, 5 })));

Console.WriteLine(string.Join(", ", ZpracujPole(null)));

Console.WriteLine(string.Join(", ", ZpracujPole(new int[] { -5, -1 })));

