//hodnotové datové typy

//ciselne datove typy
byte b = 0; // 0 - 255
ushort us = 65535;

short s = 1; // 16 bitove cislo - 65536
int i = 0; // 32 bitove cislo
uint ui = 0;

long l = 0;// 64 bitove cislo
ulong ul = 0;

//32 bitova promenna s plovouci radovou carkou
float f = 0.1f;
//64 bitova promenna s plovouci radovou carkou
double d = 0.1;
//128 bitova promenna s plovouci carkou a
//desitkovym kodovanim
decimal dec = 0.1m + 0.2m;

bool boolean = true;

if (boolean)
{

}

char c = '1';

//referencni datoví typy
string str = "abc";

int[] ints = new int[20];
for (int j = 0; j < ints.Length; j++)
{
    ints[j] = j + 1;
}

int[][] matrix = new int[20][];
for (int j = 0; j < matrix.Length; j++)
{
    matrix[j] = new int[20];
    for (int k = 0; k < 20; k++)
    {
        matrix[j][k] = k + 1 + j * 20;
    }
}

int[,] matrix2 = new int[20, 20];
for (int j = 0; j < matrix2.GetLength(1); j++)
{
    for (int k = 0; k < matrix2.GetLength(1); k++)
    {
        matrix2[j, k] = k + 1 + j * 20;
    }
}

List<int> list = new List<int>();
for (int j = 0; j < 20; j++)
{
    list.Add(j + 1);
}


list.RemoveAt(19);
int count = list.Count;


string input = Console.ReadLine();
string[] parts = input.Split (';');
for (int j = 0; j < parts.Length; j++)
{
    Console.WriteLine(input[0]);
}



