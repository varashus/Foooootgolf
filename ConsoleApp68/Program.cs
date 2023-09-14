using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA230914_01
{
    class Program
    {
        static void Main()
        {
            var versenyzok = new List<Versenyzo>();
            using var sr = new StreamReader(
                @"..\..\..\src\fob2016.txt",
                Encoding.UTF8);
            while (!sr.EndOfStream) versenyzok.Add(new Versenyzo(sr.ReadLine()));

            Console.WriteLine($"3. feladat: Versenyzők száma: {versenyzok.Count}");

            int nokSzama = versenyzok.Count(v => !v.Kategoria);
            float nokAranya = nokSzama / (float)versenyzok.Count * 100;
            Console.WriteLine($"4. feladat: Női versenyzpők aránya: {nokAranya:0.00}%");
            Console.WriteLine("6. feladat: A bajnok női verszenyző");

            var noiBajnok = versenyzok
                .Where(v => !v.Kategoria)
                .OrderBy(v => v.Osszpont)
                .Last();
            Console.WriteLine($"\tNév: {noiBajnok.Nev}");
            Console.WriteLine($"\tEgyesület: {noiBajnok.Egyesulet}");
            Console.WriteLine($"\tKözpont: {noiBajnok.Osszpont}");


            using var sw = new StreamWriter(
                path: @"..\..\..\src\osszpontszam.txt",
                append: false,
                encoding: Encoding.UTF8);
            foreach (var v in versenyzok)
            {
                if (v.Kategoria)
                {
                    sw.WriteLine($"{v.Nev};{v.Osszpont}");
                }
            }
                            

                

            Console.ReadKey();
        }

    }
}
