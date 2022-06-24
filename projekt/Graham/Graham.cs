using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tocke;

namespace Graham
{
    public class Graham
    {
        /// <summary>
        /// Izračuna, kako rotacijo predstavlja zaporedje točk p1, p2, p3.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public static double Rotacija(Tocka p1, Tocka p2, Tocka p3)
        {
            return (p2.x - p1.x) * (p3.y - p1.y) - (p3.x - p1.x) * (p2.y - p1.y);
        }

        /// <summary>
        /// Iračuna razdaljo med dvema točkama.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double Razdalja(Tocka p1, Tocka p2)
        {
            //ne koreni, ker potrebuje razdaljo samo za primerjavo
            return Math.Pow((p1.x - p2.x), 2) + Math.Pow((p1.y - p2.y), 2);
        }

        /// <summary>
        /// Izračuna kot med abscisno osjo ter daljico med točkama p1 in p2.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double Kot(Tocka p1, Tocka p2)
        {
            return Math.Atan2(p1.y - p2.y, p1.x - p2.x);
        }

        /// <summary>
        /// Uredi točke glede na razdaljo do začetne točke (merge sort).
        /// </summary>
        /// <param name="tocke"></param>
        /// <param name="zacetna"></param>
        /// <returns></returns>
        public static List<Tocka> Uredi_razdalja(List<Tocka> tocke, Tocka zacetna)
        {
            if (tocke.Count <= 1)
            {
                return tocke;
            }
            List<Tocka> manj = new List<Tocka>();
            List<Tocka> enako = new List<Tocka>();
            List<Tocka> vec = new List<Tocka>();

            Random r = new Random();
            double razdalja = Razdalja(tocke[r.Next(tocke.Count - 1)], zacetna);
            foreach (Tocka t in tocke) //uredi ostale glede na izbrano
            {
                double razdalja_tocke = Razdalja(t, zacetna);
                if (razdalja_tocke > razdalja)
                {
                    vec.Add(t);
                }
                else if (razdalja_tocke < razdalja)
                {
                    manj.Add(t);
                }
                else
                {
                    enako.Add(t);
                }
            }
            //združi urejene podtabele
            List<Tocka> manj1 = Uredi_razdalja(manj, zacetna);
            manj1.AddRange(enako);
            manj1.AddRange(Uredi_razdalja(vec, zacetna));
            return manj1;
        }

        /// <summary>
        /// Uredi točke glede na kot z začetno točko (merge sort).
        /// </summary>
        /// <param name="tocke"></param>
        /// <param name="zacetna"></param>
        /// <returns></returns>
        public static List<Tocka> Uredi_kot(List<Tocka> tocke, Tocka zacetna)
        {
            if (tocke.Count <= 1)
            {
                return tocke;
            }
            List<Tocka> manj = new List<Tocka>();
            List<Tocka> enako = new List<Tocka>();
            List<Tocka> vec = new List<Tocka>();

            Random r = new Random();
            Tocka izbrana = tocke[r.Next(tocke.Count - 1)];
            double kot = Kot(izbrana, zacetna);
            foreach (Tocka t in tocke) //uredi ostale glede na izbrano
            {
                double kot_tocke = Kot(t, zacetna);
                if (kot_tocke < kot)
                {
                    manj.Add(t);
                }
                else if (kot_tocke > kot)
                {
                    vec.Add(t);
                }
                else
                {
                    enako.Add(t);
                }
            }
            //združi urejene podtabele
            List<Tocka> manj1 = Uredi_kot(manj, zacetna);
            manj1.AddRange(Uredi_razdalja(enako, zacetna)); //tiste, ki imajo enak kot, uredi po razdalji do začetne
            manj1.AddRange(Uredi_kot(vec, zacetna));
            return manj1;
        }

        /// <summary>
        /// Glavni algoritem
        /// </summary>
        /// <param name="tocke"></param>
        /// <returns></returns>
        public static List<Tocka> Graham_scan(List<Tocka> tocke)
        {
            if (tocke.Count <= 3)
            {
                return tocke;
            }
            //poišče začetno točko
            Tocka min_tocka = new Tocka(float.MaxValue, float.MaxValue);
            foreach (Tocka t in tocke)
            {
                if (t < min_tocka)
                {
                    min_tocka = t;
                }
            }

            List<Tocka> urejene = Uredi_kot(tocke, min_tocka);
            List<Tocka> rob = new List<Tocka>() { urejene[0], urejene[1] };

            for (int i = 2; i < urejene.Count; i++)
            {
                while (Rotacija(rob[rob.Count - 2], rob[rob.Count - 1], urejene[i]) <= 0) //rotacija v desno, izbriše zadnjo točko v robu
                {
                    rob.RemoveAt(rob.Count - 1);
                    if (rob.Count < 2)
                    {
                        break;
                    }
                }
                rob.Add(urejene[i]);
            }
            return rob;
        }

        static void Main(string[] args)
        {
            List<Tocka> t = new List<Tocka>()
            {
                new Tocka(0, 0),
                new Tocka(4, 0),
                new Tocka(4, 4),
                new Tocka(0, 4),
                new Tocka(2, 2),
                new Tocka(1, 1),
                new Tocka(3, 3),
            };
            List<Tocka> tt = Graham_scan(t);
            Console.WriteLine("rezultat");
            foreach (Tocka t1 in tt)
            {
                Console.WriteLine(t1.ToString());
            }

            
        }
    }
}
