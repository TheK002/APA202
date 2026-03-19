//1
//static double a(double n, double m, char simvol)
//{
//    if (simvol == '+')
//    {
//        return n + m;
//    }
//    else if (simvol == '-')
//    {
//        return n - m;
//    }
//    else if (simvol == '/')
//    {
//        return n / m;
//    }
//    else if (simvol == '*')
//    {
//        return n * m;
//    }
//    else
//    {
//        Console.WriteLine("Simvolu düzgün daxil edin");
//        return 0;
//    }
//}
//double netice = a(10, 5, '*');
//Console.WriteLine(netice);

//Metod - a n dəyəri göndəriləcək.metod 1-dən n-dək olan cüt ədədlərin cəmini qaytaracaq

//2.Verilen arqumentlere uygun tek ve cut edeleri tapan method yazin.(14, 20, 35, 40, 57, 60, 100)

//static void a(int[] ededler, int[] tek, int[] cut)
//{
//    int t = 0;
//    int c = 0;

//    for (int i = 0; i < ededler.Length; i++)
//    {
//        if (ededler[i] % 2 == 0)
//        {
//            cut[c++] = ededler[i];
//        }
//        else
//        {
//            tek[c++] = ededler[i];
//        }
//    }
//}
//int[] ededler = { 14, 20, 35, 40, 57, 60, 100 };
//int[] tek = new int[ededler.Length];
//int[] cut = new int[ededler.Length];
//a(ededler, tek, cut);

//Console.WriteLine(string.Join(" ", tek));
//Console.WriteLine(string.Join(" ", cut));

//3.Verilmis arreyde elementlerin həm 4-ə, həm də 5-ə bölününen elementlerin cemini tapin.[14, 20, 35, 40, 57, 60, 100]

//static void a(int[] ededler)
//{
//    int cem = 0;
//    for (int i = 0; i < ededler.Length; i++)
//    {
//        if (ededler[i] % 4 == 0 && ededler[i] % 5 == 0)
//        {
//            cem += ededler[i];
//        }
//    }
//    Console.WriteLine(cem);
//}
//int[] ededler = { 14, 20, 35, 40, 57, 60, 100 };
//a(ededler);

//4.Daxil edilmiş cümlədə daxil edilmis simvoldan nece eded olduğunu tapan Proqramın alqoritmini yazin.(Cumle serbestdir).

static void a(string soz, char herf)
{
    int eded = 0;
    for (int i = 0; i < soz.Length; i++)
    {
        if (soz[i] == herf)
        {
            eded++;
        }
    }
    Console.WriteLine(eded);
}

string soz = "aabdbdcbasjdlqwa";
a(soz, 'b');
