using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tocke;

namespace Jarvis
{
    public class Jarvis
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
        /// Poišče naslednjo točko v robu.
        /// </summary>
        /// <param name="tocke"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Tocka Naslednja(List<Tocka> tocke, Tocka p)
        {
            Tocka q = p;
            foreach (Tocka r in tocke)
            {
                if (r.Equals(p)) // r ne sme biti enak p
                {
                    continue;
                }
                if (Rotacija(p, q, r) <= 0) //rotacija v desno, spremeni q
                {
                    q = r;
                }
            }
            return q;
        }

        /// <summary>
        /// Glavni algoritem.
        /// </summary>
        /// <param name="sez_tock"></param>
        /// <returns></returns>
        public static List<Tocka> Jarvis_march(List<Tocka> sez_tock)
        {
            //poišče začetno točko
            Tocka min_tocka = new Tocka(float.MaxValue, float.MaxValue);
            foreach (Tocka t in sez_tock)
            {
                if (t < min_tocka)
                {
                    min_tocka = t;
                }
            }
            //doda začetno v rob
            List<Tocka> rob = new List<Tocka>();
            rob.Add(min_tocka);

            int i= 0;
            while (true)// išče naslednje točke, dokler naslednja ni že v robu
            {
                Tocka t = Naslednja(sez_tock, rob[i]);
                if (rob.Contains(t))
                {
                    break;
                }
                i++;
                rob.Add(t);
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
            List<Tocka> tt = new List<Tocka>()
            { 
                new Tocka(6, 6)
            };
            List<Tocka> ttt = new List<Tocka>()
            {
                new Tocka(7, 7)
            };
            t.AddRange(tt);
            t.AddRange(ttt);
            foreach (Tocka t1 in t)
            {
                Console.WriteLine(t1.ToString());
            }
        }
    }
}
