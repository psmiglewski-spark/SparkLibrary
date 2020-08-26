using System.Collections.Generic;
using System.Text;

namespace Spark.Bussiness.Library
{


    //Example of use
    //    float kwotaDec = 852.94f;
    //    int zlote = (int)kwotaDec;
    //    int grosze = (int)(100 * kwotaDec) % 100;
    //    Console.WriteLine(String.Format("{0} {1}, {2} {3}",
    //    KwotaSlownie.LiczbaSlownie(zlote),
    //    KwotaSlownie.WalutaSlownie(zlote, "PLN"),
    //    KwotaSlownie.LiczbaSlownie(grosze),
    //    KwotaSlownie.WalutaSlownie(grosze, ".PLN")));
    ////osiemset pięćdziesiąt dwa złote, dziewięćdziesiąt cztery grosze
    

    class KwotaSlownie
    {
        private static string _zero = "zero";
        private static string[] _jednosci = { "", " jeden ", " dwa ", " trzy ",
        " cztery ", " pięć ", " sześć ", " siedem ", " osiem ", " dziewięć " };
        private static string[] _dziesiatki = { "", " dziesięć ", " dwadzieścia ",
        " trzydzieści ", " czterdzieści ", " pięćdziesiąt ",
        " sześćdziesiąt ", " siedemdziesiąt ", " osiemdziesiąt ",
        " dziewięćdziesiąt "};
        private static string[] _nascie = { "dziesięć", " jedenaście ", " dwanaście ",
        " trzynaście ", " czternaście ", " piętnaście ", " szesnaście ",
        " siedemnaście ", " osiemnaście ", " dziewiętnaście "};
        private static string[] _setki = { "", " sto ", " dwieście ", " trzysta ",
        " czterysta ", " pięćset ", " sześćset ",
        " siedemset ", " osiemset ", " dziewięćset " };
        private static string[,] _rzedy = {{" tysiąc ", " tysiące ", " tysięcy "},
                            {" milion ", " miliony ", " milionów "},
                            {" miliard ", " miliardy ", " miliardów "}};

        private static Dictionary<string, string[]> _waluty = new Dictionary<string, string[]>() {
        //Formy podawane według wzorca: jeden-dwa-pięć, np.
        //(jeden) złoty, (dwa) złote, (pięć) złotych
        { "PLN", new string[]{ "złoty", "złote", "złotych" } },
       // { "RUB", new string[]{ "rubel", "ruble", "rubli" } },
       // { "USD", new string[]{ "dolar", "dolary", "dolarów" } },
        { ".PLN", new string[]{ "grosz", "grosze", "groszy" } }
    };

        public static string LiczbaSlownie(int liczba)
        {
            return LiczbaSlownieBase(liczba).Replace("  ", " ").Trim();
        }

        public static string WalutaSlownie(int liczba, string kodWaluty)
        {
            var key = _waluty[kodWaluty];
            return key[DeklinacjaWalutyIndex(liczba)];
        }

        private static string LiczbaSlownieBase(int wartosc)
        {
            StringBuilder sb = new StringBuilder();
            //0-999
            if (wartosc == 0)
                return _zero;
            int jednosc = wartosc % 10;
            int para = wartosc % 100;
            int set = (wartosc % 1000) / 100;
            if (para > 10 && para < 20)
                sb.Insert(0, _nascie[jednosc]);
            else
            {
                sb.Insert(0, _jednosci[jednosc]);
                sb.Insert(0, _dziesiatki[para / 10]);
            }
            sb.Insert(0, _setki[set]);

            //Pozostałe rzędy wielkości
            wartosc = wartosc / 1000;
            int rzad = 0;
            while (wartosc > 0)
            {
                jednosc = wartosc % 10;
                para = wartosc % 100;
                set = (wartosc % 1000) / 100;
                bool rzadIstnieje = wartosc % 1000 != 0;
                if ((wartosc % 1000) / 10 == 0)
                {
                    //nie ma dziesiątek i setek
                    if (jednosc == 1)
                        sb.Insert(0, _rzedy[rzad, 0]);
                    else if (jednosc >= 2 && jednosc <= 4)
                        sb.Insert(0, _rzedy[rzad, 1]);
                    else if (rzadIstnieje)
                        sb.Insert(0, _rzedy[rzad, 2]);
                    if (jednosc > 1)
                        sb.Insert(0, _jednosci[jednosc]);
                }
                else
                {
                    if (para >= 10 && para < 20)
                    {
                        sb.Insert(0, _rzedy[rzad, 2]);
                        sb.Insert(0, _nascie[para % 10]);
                    }
                    else
                    {
                        if (jednosc >= 2 && jednosc <= 4)
                            sb.Insert(0, _rzedy[rzad, 1]);
                        else if (rzadIstnieje)
                            sb.Insert(0, _rzedy[rzad, 2]);
                        sb.Insert(0, _jednosci[jednosc]);
                        sb.Insert(0, _dziesiatki[para / 10]);
                    }
                    sb.Insert(0, _setki[set]);
                }
                rzad++;
                wartosc = wartosc / 1000;
            }
            return sb.ToString();
        }

        private static int DeklinacjaWalutyIndex(int liczba)
        {
            if (liczba == 1)
                return 0;

            int para = liczba % 100;
            if (para >= 10 && para < 20)
                return 2;

            int jednosc = liczba % 10;
            if (jednosc >= 2 && jednosc <= 4)
                return 1;

            return 2;
        }
    }
}