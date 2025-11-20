//hodnotové datové typy
double a = 0;
double b = 0;
double vysledek = 0;

//boolovská proměnná pro kontrolu platnosti operátoru
bool platnyOper = true;

//zadání vstupů od uživatele
Console.WriteLine("Zadej první číslo:");
a = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Zadej operátor (+, -, *, /):");
string op = Console.ReadLine();

Console.WriteLine("Zadej druhé číslo:");
b = Convert.ToDouble(Console.ReadLine());

//výpočet podle zvoleného operátoru
if (op == "+")
{
    vysledek = a + b;
}
else if (op == "-")
{
    vysledek = a - b;
}
else if (op == "*")
{
    vysledek = a * b;
}
else if (op == "/")
{
    if (b == 0)
    {
        Console.WriteLine("Chyba: nelze dělit nulou!");
        platnyOper = false;
    }
    else
    {
        vysledek = a / b;
    }
}
else
{
    Console.WriteLine("Chyba: neznámý operátor!");
    platnyOper = false;
}

//výpis výsledku
if (platnyOper)
{
    Console.WriteLine("Výsledek: " + vysledek);
}

Console.WriteLine("\nStiskni libovolnou klávesu pro ukončení...");
Console.ReadKey();
