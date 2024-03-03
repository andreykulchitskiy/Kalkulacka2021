using System;
using System.Collections.Generic;
using System.Linq;
namespace kalkulacka
{
    public class kalkulacka
    {
        //funkce "kontrola1" složi k tomu aby zkontrolovat první vstup od uživatelé.
        public static double kontrola1(int number)//proměnu "number" jsem použil aby poslat signál funkci,že máme výjimku.
        {
            double cislo;//lokální proměna místo globální "prvnicislo".
            bool jdeto;//proměna typu bool nutná k metodě TryParse.
            do
            {
                Console.WriteLine("Zadejte první číslo:");
                jdeto = double.TryParse(Console.ReadLine(), out cislo);
                if (number == 1 && cislo < 0)//další ošetření vstupu v jedine výjimce pro operator "√".
                {
                    jdeto = false;
                    Console.WriteLine("Máte chybu,zadejte kladné číslo!");
                }

            }
            while (jdeto == false);
            return cislo;
        }
        //Kontrola2 kontroluje druhý vstup od uzivatele.
        public static double kontrola2(int number)//proměna "number" taky posílá signál,že máme výjimku jestli operator je dělení.
        {
            double cislo;//tady postup je stejný.
            bool jdeto;
            do
            {
                Console.WriteLine("Zadejte druhé číslo:");
                jdeto = double.TryParse(Console.ReadLine(), out cislo);
                if (number == 1 && cislo == 0)
                {
                    jdeto = false;
                    Console.WriteLine("Máte chybu,nemužete dělit nulou!");
                }
            }
            while (jdeto == false);
            return cislo;
        }
        //ješte jedna kontrola,ale s intervalem pro všechny vybery v menu(použiváme ji dvakrát).
        public static int kontrola3(int min, int max)
        {
            int cislo;
            bool jdeto;
            do
            {
                jdeto = int.TryParse(Console.ReadLine(), out cislo);
                if (cislo < min || cislo > max)
                {
                    jdeto = false;
                    Console.WriteLine("Mate chybu zadejte cislo v zvolenem intervalu");
                }
            }
            while (jdeto == false);
            return cislo;
        }
        //funkce pro součet,součin,rozdíl a tak dál.
        public static double Soucet(double prvnicislo, double druhecislo)
        {
            return prvnicislo + druhecislo;
        }
        public static double Soucin(double prvnicislo, double druhecislo)
        {
            return prvnicislo * druhecislo;
        }
        public static double Rozdil(double prvnicislo, double druhecislo)
        {
            return prvnicislo - druhecislo;
        }
        public static double Deleni(double prvnicislo, double druhecislo)
        {

            return prvnicislo / druhecislo;
        }
        public static double Stupen(double prvnicislo, double druhecislo)
        {
            return Math.Pow(prvnicislo, druhecislo);
        }
        public static double Sqrt(double prvnicislo)
        {
            return Math.Pow(prvnicislo, 0.5);
        }
        //zde začíná hlavní prográm.
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Vítám Vás na moje kalkulačce,přeju hezké počítání");
            Console.ReadKey();
            double prvnicislo = 0;//tyto tři proměny říka samy za sebe.
            double druhecislo = 0;
            double vysledek = 0;
            double[] vysledky;//to pole jsem použil,aby uložit všechny vysledky a zjistit M+ M-.
            vysledky = new double[100];//myslím,že 100 by stačilo.
            int i = 0;//tato proměna nutná pro uložení vysledků v pole "vysledky".
            bool konec = false;//tuto proměnu jsem udělal,aby uživatel se mohl vrátit na začátek a spočitat něco znovu pomocí cyklu do while.
            double mr = 0;//proměnu "mr" potřebujeme až na konci programu pro operator "MR".
            bool znak = true;//tuto proměnu jsem potřeboval,aby v if´u program zjistil jaké znaménko má "M" plus nebo minus.
            do//použiváme cykl do while,aby nedělat žadnou funkce.
            {
                Console.Clear();
                //Začináme z vyběru operátora.
                int operator1;
                Console.WriteLine("Vybeřte prosím operatora:");
                Console.WriteLine("Pro operátor |+| stiskněte:|1|");
                Console.WriteLine("Pro operátor |-| stiskněte:|2|");
                Console.WriteLine("Pro operátor |*| stiskněte:|3|");
                Console.WriteLine("Pro operátor |/| stiskněte:|4|");
                Console.WriteLine("Pro operátor |^| stiskněte:|5|");
                Console.WriteLine("Pro operátor |√| stiskněte:|6|");
                operator1 = kontrola3(1, 6);//Ušetríme vstup v interválu od 1 do 6.
                Console.Clear();
                if (operator1 == 6)//jestli vybrán operátor "√" posíláme signál funkci.
                {
                    prvnicislo = kontrola1(1);//v tomto případě "1" znamená kolik máme výjimek v ošetření.
                    Console.Clear();//pro operátor "√" nepotřebujeme druhé číslo.
                }
                else
                {
                    prvnicislo = kontrola1(0);//jestli operátor jiný tak máme 0 výjimek.
                    if (operator1 == 4)
                    {
                        druhecislo = kontrola2(1);//pro operátor dělení máme 1 výjimku ve druhém vstupu.
                    }
                    else
                    {
                        druhecislo = kontrola2(0);//pro ostatní nemáme.
                    }
                    Console.Clear();
                }
                //Počitáme.
                switch (operator1)
                {
                    case 1:
                        Console.WriteLine("{0} + {1} = {2}", prvnicislo, druhecislo, vysledek = Soucet(prvnicislo, druhecislo));
                        break;
                    case 2:
                        Console.WriteLine("{0} - {1} = {2}", prvnicislo, druhecislo, vysledek = Rozdil(prvnicislo, druhecislo));
                        break;
                    case 3:
                        Console.WriteLine("{0} x {1} = {2}", prvnicislo, druhecislo, vysledek = Soucin(prvnicislo, druhecislo));
                        break;
                    case 4:
                        Console.WriteLine("{0} / {1} = {2}", prvnicislo, druhecislo, vysledek = Deleni(prvnicislo, druhecislo));
                        break;
                    case 5:
                        Console.WriteLine("{0} ^ {1} = {2}", prvnicislo, druhecislo, vysledek = Stupen(prvnicislo, druhecislo));
                        break;
                    case 6:
                        Console.WriteLine("√{0} = {1}", prvnicislo, vysledek = Sqrt(prvnicislo));
                        break;

                }
                //proměna prodlouzeni říká sama za sebe.
                int prodlouzeni;
                Console.WriteLine("{0,-20} {1,4}", "Pro operátor |M+| stiskněte:", "|1|");
                Console.WriteLine("{0,-20} {1,4}", "Pro operátor |M-| stiskněte:", "|2|");
                Console.WriteLine("{0,-20} {1,4}", "Pro operátor |MR| stiskněte:", "|3|");
                Console.WriteLine("{0,-20} {1,4}", "Pro operátor |MC| stiskněte:", "|4|");
                Console.WriteLine("{0,-20} {1,3}", "\nPro dalsí počítání stiskněte:", "|5|");
                Console.WriteLine("{0,-20} {1,3}", "Pro konec počítání stiskněte:", "|6|");
                prodlouzeni = kontrola3(1, 6);
                Console.SetCursorPosition(0, Console.CursorTop - 1);//toto jsem udělal,aby uživatel neviděl svůj vstup.
                Console.WriteLine(" ");
                switch (prodlouzeni)
                {
                    case 1:
                        znak = true;//tady definujeme proměnu "znak",kde "true" znamená plus,"false" minus u M'ka.
                        vysledky[i] = vysledek;//každý další vstup bude zapsan v pole "vysledky".
                        i++;
                        break;
                    case 2:
                        znak = false;//tady je to uplně stejně,ale označím minus.
                        vysledky[i] = vysledek;
                        i++;
                        break;
                    case 3:
                        if (znak == true)//a tady už "znak" použiváme.
                        {
                            vysledky[i] = vysledek;
                            mr = vysledky.ToArray().Sum();//pro MR po M+ použiváme součet všech čísel v pole "vysledky".
                            Console.WriteLine("\nVysledek je: " + mr);
                            Console.ReadKey();
                            mr = 0;//dál musíme všechno nastavit na nulu.
                            i = 0;
                            vysledek = 0;
                            vysledky = new double[100];
                        }
                        else if (znak == false)
                        {
                            vysledky[i] = vysledek;
                            mr = vysledky[0];
                            for (i = 1; i < 10; i++)//tady mám 10,myslím,že to by stačilo,aĺe může tady být víc.
                            {
                                mr = mr - vysledky[i];
                            }
                            Console.WriteLine("\nVysledek je: " + mr);
                            Console.ReadKey();
                            mr = 0;//taky na nulu
                            i = 0;
                            vysledek = 0;
                            vysledky = new double[100];
                        }
                        break;
                    case 4:
                        mr = 0;
                        i = 0;
                        vysledek = 0;
                        vysledky = new double[100];
                        break;
                    case 5:
                        mr = 0;
                        i = 0;
                        vysledek = 0;
                        vysledky = new double[100];
                        break;
                    case 6:
                        konec = true;
                        break;
                }
            } while (konec == false);//děkuju za pozornost.
        }
    }
}

