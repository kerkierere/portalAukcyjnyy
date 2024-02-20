using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    
    static List<KartaKredytowa> karty = new List<KartaKredytowa>
    {
        new KartaKredytowa("Visa", "0001", 100),
        new KartaKredytowa("Mastercard", "0002", 10000),
        new KartaKredytowa("American Express", "0003", 3000),
        new KartaKredytowa("Diners Club", "0004", 1000)
    };

    static void Main()
    {
        Console.WriteLine("Witaj w portalu aukcyjnym");

        while (true)
        {
            Console.WriteLine("\nWybierz opcję:");
            Console.WriteLine("1. Dostępne przedmioty");
            Console.WriteLine("2. Zakończ");

            int opcja = int.Parse(Console.ReadLine()!);

            switch (opcja)
            {
                case 1:
                    WyswietlDostepnePrzedmioty();
                    break;
                case 2:
                    Console.WriteLine("Dziękujemy za skorzystanie z portalu aukcyjnego. Do widzenia!");
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Proszę wybrać ponownie.");
                    break;
            }
        }
    }

    static void WyswietlDostepnePrzedmioty()
    {
        
        List<Przedmiot> listaPrzedmiotow = new List<Przedmiot>
        {
            new Przedmiot(1, "Bluza Adidas Męska Szara", "Odzież", 249, true),
            new Przedmiot(2, "Iphone 12 Pro", "Elektronika", 4600, true),
            new Przedmiot(3, "Basen ogrodowy Premium", "dom i ogród", 1199),
            new Przedmiot(4, "Konsola Playstation 5", "Elektronika", 2899),
            new Przedmiot(5, "Krzesło skandynawskie granatowe", "dom i ogród", 88),           
            new Przedmiot(6, "Spodnie Wrangler Arizona", "Odzież", 189),
            
        };

        
        var posortowanaLista = listaPrzedmiotow.OrderByDescending(p => p.Wyrozniony).ThenBy(p => p.Nazwa);

        
        Console.WriteLine("Lista dostępnych przedmiotów do zakupu:");
        foreach (var przedmiot in posortowanaLista)
        {
            if (przedmiot.Wyrozniony)
            {
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine($"{przedmiot.Numer}. {przedmiot.Nazwa} - {przedmiot.Kategoria} - {przedmiot.Cena} PLN");
                Console.ResetColor(); 
            }
            else
            {
                Console.WriteLine($"{przedmiot.Numer}. {przedmiot.Nazwa} - {przedmiot.Kategoria} - {przedmiot.Cena} PLN");
            }
        }

        
        Console.Write("\nPodaj ID przedmiotu, który chcesz zakupić: ");
        int idWybranegoPrzedmiotu = int.Parse(Console.ReadLine()!);

        
        Console.Write("Podaj numer karty kredytowej: ");
        string numerKarty = Console.ReadLine()!;

        
        KartaKredytowa wybranaKarta = karty.FirstOrDefault(k => k.Numer == numerKarty)!;
        if (wybranaKarta != null)
        {
            
            Przedmiot wybranyPrzedmiot = listaPrzedmiotow.FirstOrDefault(p => p.Numer == idWybranegoPrzedmiotu)!;


            if (wybranaKarta.DostepneSrodki >= wybranyPrzedmiot.Cena)
            {

                Console.WriteLine($"\nKupiłeś przedmiot {wybranyPrzedmiot.Nazwa}, cena {wybranyPrzedmiot.Cena} PLN, płatność: karta ({wybranaKarta.Typ}, {wybranaKarta.Numer}). Zakup opłacony.");
            }
            else
            {
                Console.WriteLine("Brak wystarczających środków na karcie. Proszę wybrać inną kartę lub przedmiot.");
            }
        }
        else
        {
            Console.WriteLine("Błędny numer karty kredytowej. Proszę sprawdzić i spróbować ponownie.");
        }
    }

    class Przedmiot
    {
        public int Numer { get; }
        public string Nazwa { get; }
        public string Kategoria { get; }
        public double Cena { get; }
        public bool Wyrozniony { get; }

        public Przedmiot(int numer, string nazwa, string kategoria, double cena, bool wyrozniony = false)
        {
            Numer = numer;
            Nazwa = nazwa;
            Kategoria = kategoria;
            Cena = cena;
            Wyrozniony = wyrozniony;
        }
    }

    class KartaKredytowa
    {
        public string Typ { get; }
        public string Numer { get; }
        public double DostepneSrodki { get; set; }

        public KartaKredytowa(string typ, string numer, double dostepneSrodki)
        {
            Typ = typ;
            Numer = numer;
            DostepneSrodki = dostepneSrodki;
        }
    }
}
