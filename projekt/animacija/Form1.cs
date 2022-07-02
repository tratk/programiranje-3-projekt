using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tocke;
using Graham;

namespace animacija
{
    public partial class Okno : Form
    {
        List<Tocka> tocke = new List<Tocka>();
        List<Tocka> rob = new List<Tocka>();
        string algoritem = ""; //da vem, kateri algoritem se izvaja
        int graham_stevec = 2; //stevec korakov pri alg graham scan
        Graphics platno;
        bool tece = false; //da vem, ali teče kak algoritem
        bool graham_vmesni = false; //
        bool graham_izbrisal = false;

        int jarvis_stevec = 0; //stevec korakov pri iskanju naslednje točke v jarvis march
        Tocka jarvis_q = new Tocka(0, 0);
        Tocka jarvis_r = new Tocka(0, 0);
        bool jarvis_sprememba = false;
        Tocka jarvis_prejsnji_q = new Tocka(0, 0);

        bool izbiraj_tocke = false;
        public Okno()
        {
            InitializeComponent();
        }

        private void Okno_Load(object sender, EventArgs e)
        {
            start.Hide();
            pospesi.Hide();
            upocasni.Hide();
            zacetek.Hide();
            korak.Hide();
            opozorilo.Hide();
            stevec_tock.Hide();
            label1.Hide();
        }

        /// <summary>
        /// Generira začetne točke v mejah.
        /// </summary>
        private void Generiraj()
        {

            int stevilo_tock = int.Parse(st_tock.Text);
            int zg_meja_x = 97;
            int zg_meja_y = 59;
            Random r = new Random();
            for (int i = 0; i < stevilo_tock; i++)
            {
                this.tocke.Add(new Tocka(r.Next(1, zg_meja_x) * 10, r.Next(9, zg_meja_y) * 10, i+1));
            }
        }

        /// <summary>
        /// Skrije ali prikaže začetno stran.
        /// </summary>
        /// <param name="skrij"></param>
        private void Skrij_zacetno_stran(bool skrij)
        {
            if (skrij)
            {
                st_tock_label.Hide();
                st_tock_label1.Hide();
                st_tock.Hide();
                hitrost_label.Hide();
                hitrost_label1.Hide();
                hitrost.Hide();
                gen_label.Hide();
                gen_box.Hide();
                alg_label.Hide();
                alg_box.Hide();
                zacni.Hide();
                opozorilo.Hide();
                start.Show();
                zacetek.Show();
                korak.Show();
                
            }
            else
            {
                start.Hide();
                this.platno.Clear(SystemColors.Control);
                st_tock_label.Show();
                st_tock.Show();
                st_tock_label1.Show();
                hitrost_label.Show();
                hitrost_label1.Show();
                hitrost.Show();
                gen_label.Show();
                gen_box.Show();
                alg_label.Show();
                alg_box.Show();
                zacni.Show();
                zacetek.Hide();
                korak.Hide();
                upocasni.Hide();
                pospesi.Hide();
            }
        }

        /// <summary>
        /// Preveri vnešene podatke.
        /// </summary>
        /// <returns></returns>
        private string Preveri_podatke()
        {
            try
            {
                int st = int.Parse(st_tock.Text);
                if (st < 4 || st > 100)
                {
                    return "Število točk mora biti med 4 in 100!";
                }
            }
            catch (Exception)
            {
                return "Število točk mora biti celo število!";
            }

            try
            {
                int v = int.Parse(hitrost.Text);
                if (v < 100 || v > 2000)
                {
                    return "Hitrost mora biti med 100 in 2000!";
                }
            }
            catch (Exception)
            {
                return "Hitrost mora biti celo število!";
            }

            if (gen_box.SelectedIndex == -1)
            {
                return "Izbrati moraš način generacije točk!";
            }

            if (alg_box.SelectedIndex == -1)
            {
                return "Izbrati moraš algoritem!";
            }
            return "OK";
            
        }

        /// <summary>
        /// Nariše legendo v zgornjem delu okna.
        /// </summary>
        private void Narisi_legendo()
        {
            //ozadje legende
            Pen svincnik = new Pen(Color.Black, 1);
            SolidBrush copic = new SolidBrush(SystemColors.Control);
            this.platno.FillRectangle(copic, 0, 0, this.Width, 90);

            
            //ločna črta med legendo in točkami
            SolidBrush pisalo = new SolidBrush(Color.Black);
            this.platno.DrawLine(svincnik, 0, 90, this.Width, 90);

            Font font = new Font("Arial", 8);

            //risanje legend vseh vrst točk
            copic = new SolidBrush(Color.Red);
            this.platno.FillEllipse(copic, this.Width - 170, 10, 10, 10);
            this.platno.DrawString("Točke že v robu", font, pisalo, this.Width - 155, 8);

            copic = new SolidBrush(Color.Blue);
            this.platno.FillEllipse(copic, this.Width - 170, 25, 10, 10);
            this.platno.DrawString("Zadnja točka v robu", font, pisalo, this.Width - 155, 23);

            copic = new SolidBrush(Color.Violet);
            this.platno.FillEllipse(copic, this.Width - 170, 40, 10, 10);
            this.platno.DrawString("Kandidat za naslednjo", font, pisalo, this.Width - 155, 38);

            copic = new SolidBrush(Color.Green);
            this.platno.FillEllipse(copic, this.Width - 170, 55, 10, 10);
            this.platno.DrawString("Preverjalna točka", font, pisalo, this.Width - 155, 53);

            copic = new SolidBrush(Color.Black);
            this.platno.FillEllipse(copic, this.Width - 170, 70, 10, 10);
            this.platno.DrawString("Ostale točke", font, pisalo, this.Width - 155, 68);
        }


        /// <summary>
        /// Nariše točke, rob in iskalne točke
        /// </summary>
        /// <param name="tocke"></param>
        /// <param name="rob"></param>
        /// <param name="pqr"></param>
        private void Risi_tocke( List<Tocka> pqr)
        {

            SolidBrush pisalo = new SolidBrush(Color.White);
            Font font = new Font("Arial", 5);
            SolidBrush copic = new SolidBrush(Color.Black);
            
            foreach(Tocka t in this.tocke)
            {
                if (!this.rob.Contains(t) && !pqr.Contains(t)) //točke, ki niso v robu ali iskalne
                {
                    this.platno.FillEllipse(copic, t.x, t.y, 10, 10);
                    if (t.stevka < 10) //napiše števke v točke
                    {
                        this.platno.DrawString($"{t.stevka}", font, pisalo, t.x + 2, t.y + 2);
                    }
                    else
                    {
                        this.platno.DrawString($"{t.stevka}", font, pisalo, t.x, t.y + 2);
                    }
                    
                }
            }
            copic = new SolidBrush(Color.Red);
            foreach (Tocka t in this.rob)
            {
                if (!pqr.Contains(t)) //točke v robu
                {
                    this.platno.FillEllipse(copic, t.x, t.y, 10, 10);
                    if (t.stevka < 10) //napiše števke v točke
                    {
                        this.platno.DrawString($"{t.stevka}", font, pisalo, t.x + 2, t.y + 2);
                    }
                    else
                    {
                        this.platno.DrawString($"{t.stevka}", font, pisalo, t.x, t.y + 2);
                    }
                }
            }

            if (pqr.Count != 0) //iskalne točke
            {
                copic = new SolidBrush(Color.Blue);
                this.platno.FillEllipse(copic, pqr[0].x, pqr[0].y, 10, 10);
                
                copic = new SolidBrush(Color.Purple);
                this.platno.FillEllipse(copic, pqr[1].x, pqr[1].y, 10, 10);

                copic = new SolidBrush(Color.Green);
                this.platno.FillEllipse(copic, pqr[2].x, pqr[2].y, 10, 10);

                foreach (Tocka t in pqr)
                {
                    if (t.stevka < 10) //napiše števke v točke
                    {
                        this.platno.DrawString($"{t.stevka}", font, pisalo, t.x + 2, t.y + 2);
                    }
                    else
                    {
                        this.platno.DrawString($"{t.stevka}", font, pisalo, t.x, t.y + 2);
                    }
                }
            }
        }

        /// <summary>
        /// Nariše črte med točkami v robu in iskalnimi točkami.
        /// </summary>
        /// <param name="rob"></param>
        /// <param name="pqr"></param>
        public void Risi_crte(List<Tocka> pqr)
        {
            Pen svincnik = new Pen(Color.Red, 1);
            if (this.rob.Count >= 2) //črte med točkami v robu
            {
                
                for (int i = 0; i < this.rob.Count - 1; i++)
                {
                    this.platno.DrawLine(svincnik, this.rob[i].x + 5, this.rob[i].y + 5, this.rob[i + 1].x + 5, this.rob[i + 1].y + 5);
                }
                this.platno.DrawLine(svincnik, this.rob[this.rob.Count - 1].x + 5, this.rob[this.rob.Count - 1].y + 5, this.rob[0].x + 5, this.rob[0].y + 5);
            }
            
            if (pqr.Count != 0) //črte med iskalnimi točkami
            {
                svincnik = new Pen(Color.Blue, 1);
                this.platno.DrawLine(svincnik, pqr[0].x + 5, pqr[0].y + 5, pqr[1].x + 5, pqr[1].y + 5);
                svincnik = new Pen(Color.Green, 1);
                this.platno.DrawLine(svincnik, pqr[1].x + 5, pqr[1].y + 5, pqr[2].x + 5, pqr[2].y + 5);
            }
        }

        /// <summary>
        /// Pobriše črte med predzadnjo in zadnjo točko ter zadnjo in prvo točko v robu
        /// in pobriše črte med iskalnimi točkami
        /// </summary>
        /// <param name="rob"></param>
        /// <param name="pqr"></param>
        /// <param name="izbrisi_rob"></param>
        public void Brisi_crte(List<Tocka> pqr, bool izbrisi_rob)
        {
            Pen svincnik = new Pen(Color.White, 1);
            if (izbrisi_rob) //briše zadnji dve črti v robu
            {
                int n = rob.Count;
                this.platno.DrawLine(svincnik, this.rob[n - 2].x + 5, this.rob[n - 2].x + 5, this.rob[n - 1].x + 5, this.rob[n - 1].y + 5);
                this.platno.DrawLine(svincnik, this.rob[n - 1].x + 5, this.rob[n - 1].y + 5, this.rob[0].x + 5, this.rob[0].y + 5);
            }
            //briše črte med iskalnimi točkami
            if (pqr.Count != 0)
            {
                this.platno.DrawLine(svincnik, pqr[0].x + 5, pqr[0].y + 5, pqr[1].x + 5, pqr[1].y + 5);
                this.platno.DrawLine(svincnik, pqr[1].x + 5, pqr[1].y + 5, pqr[2].x + 5, pqr[2].y + 5);
            }
            
        }

        /// <summary>
        /// Kliknili na gumb za algoritem graham scan, pripravi vse potrebno za izvajanje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graham_Click(object sender, EventArgs e)
        {
            Generiraj();
            //poišče začetno točko
            Tocka min_tocka = new Tocka(float.MaxValue, float.MaxValue);
            foreach (Tocka t in this.tocke)
            {
                if (t < min_tocka)
                {
                    min_tocka = t;
                }
            }
            //uredi točke glede na začetno
            this.tocke = Graham.Graham.Uredi_kot(this.tocke, min_tocka);
            //popravi števke točk
            for (int i = 0; i < this.tocke.Count; i++)
            {
                this.tocke[i] = new Tocka(this.tocke[i].x, this.tocke[i].y, i + 1);
            }

            //priprava za začetek izvajanja
            this.rob.Add(this.tocke[0]);
            this.rob.Add(this.tocke[1]);
            this.algoritem = "Graham";
            this.graham_stevec = 2;

            Skrij_zacetno_stran(true);
            this.platno = this.CreateGraphics();
            this.platno.Clear(Color.White);
            Narisi_legendo();

            Risi_tocke(new List<Tocka> { });
            Risi_crte(new List<Tocka> {});
        }

        /// <summary>
        /// Kliknili na gumb za algoritem jarvis march, pripravi vse potrebno za izvajanje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jarvis_Click(object sender, EventArgs e)
        {
            Generiraj();
            //poišče začetno točko
            Tocka min_tocka = new Tocka(float.MaxValue, float.MaxValue);
            foreach (Tocka t in this.tocke)
            {
                if (t < min_tocka)
                {
                    min_tocka = t;
                }
            }

            //priprava za začetek izvajanja
            this.rob.Add(min_tocka);
            this.algoritem = "Jarvis";
            this.jarvis_stevec = 0;

            Skrij_zacetno_stran(true);
            this.platno = this.CreateGraphics();
            this.platno.Clear(Color.White);
            Narisi_legendo();
            Risi_tocke(new List<Tocka> { });
        }

        /// <summary>
        /// Naredi en korak v algoritmu.
        /// </summary>
        /// <param name="tocke"></param>
        /// <param name="rob"></param>
        public void Graham_korak()
        {
            int n = this.rob.Count();
            if (Graham.Graham.Rotacija(this.rob[n-2], this.rob[n-1], this.tocke[this.graham_stevec]) <= 0) //rotacija v desno, moram izbrisat
            {
                this.rob.RemoveAt(n - 1);
                if (this.rob.Count == 1) //samo se ena točka, dodam točko, ki jo preverjam
                {
                    this.rob.Add(tocke[this.graham_stevec]);
                    this.graham_stevec++;
                }
            }
            else
            {
                //konec brisanja, dodam točko, ki jo preverjam
                this.rob.Add(this.tocke[this.graham_stevec]);
                this.graham_stevec++;
            }
        }

        /// <summary>
        /// Korak v jarvis algoritmu, trenutno ni uporabljena
        /// </summary>
        /// <param name="tocke"></param>
        /// <param name="p"></param>
        public void Jarvis_naslednja(List<Tocka> tocke, Tocka p)
        {
            if (this.tocke[this.jarvis_stevec + 1] == p)
            {
                this.jarvis_stevec = this.jarvis_stevec + 2;
            }
            else
            {
                this.jarvis_stevec++;
            }
            if (this.jarvis_stevec != this.tocke.Count)
            {
                this.jarvis_r = this.tocke[this.jarvis_stevec];
                if (Jarvis.Jarvis.Rotacija(p, this.jarvis_q, this.jarvis_r) <= 0)
                {
                    this.jarvis_q = this.jarvis_r;
                }
            }
            else
            {
                this.jarvis_stevec--;
            }
        }

        /// <summary>
        /// Narise naslednji korak pri algoritmu Graham scan.
        /// </summary>
        private void Graham_risi_korak()
        {
            List<Tocka> pqr = new List<Tocka> { this.rob[this.rob.Count - 2], this.rob[this.rob.Count - 1], this.tocke[this.graham_stevec] };
            if (this.graham_vmesni) //dodal točko, nariše vmesno stanje
            {
                Risi_crte(pqr);
                Risi_tocke(pqr);
                this.graham_vmesni = false;
            }
            else if (this.graham_izbrisal) //izbrisal točko, nariše vmesno stanje
            {
                Risi_crte(pqr);
                Risi_tocke(pqr);
                this.graham_izbrisal = false;
            }
            else
            {
                Brisi_crte(pqr, true);
                //Narisi_legendo();

                int st = this.graham_stevec;
                int dolzina = rob.Count();
                Graham_korak();
                if (dolzina == rob.Count + 1) //izbrisal točko, v naslednjem koraku nariše vmesno stanje
                {
                    Risi_crte(new List<Tocka> { });
                    Risi_tocke(new List<Tocka> { });
                    this.graham_izbrisal = true;
                }
                else
                {
                    if (st == this.graham_stevec) //nariše ta korak
                    {
                        Risi_crte(pqr);
                        Risi_tocke(pqr);
                    }
                    else //dodali novo točko v rob, v naslednjem koraku vmesno stanje
                    {
                        Risi_crte(new List<Tocka> { });
                        Risi_tocke(new List<Tocka> { });
                        this.graham_vmesni = true;
                    }
                }
            }

            if (this.graham_stevec == tocke.Count) //prišli do konca, ustavi izvajanje
            {
                timer1.Stop();
                pospesi.Hide();
                upocasni.Hide();
                this.tece = false;
                start.Hide();
                start.Text = "Start";
                korak.Hide();
            }
        }

        private void Jarvis_korak_risi()
        {
            Tocka p = this.rob[this.rob.Count - 1];
            if (this.jarvis_stevec == 0) //nastavi začeten q, r
            {
                //q, r ne smeta biti enaka p
                if (p != this.tocke[0])
                {
                    this.jarvis_q = tocke[0];
                    if (p != this.tocke[1])
                    {
                        this.jarvis_r = tocke[1];
                        jarvis_stevec = 0;
                    }
                    else
                    {
                        this.jarvis_r = tocke[2];
                        jarvis_stevec = 1;
                    }
                }
                else
                {
                    this.jarvis_q = tocke[1];
                    this.jarvis_r = tocke[2];
                    jarvis_stevec = 1;
                }

                Risi_crte(new List<Tocka> { p, this.jarvis_q, this.jarvis_r });
                Risi_tocke(new List<Tocka> { p, this.jarvis_q, this.jarvis_r });
            }

            if (this.jarvis_stevec == this.tocke.Count - 1)//prišli do konca z iskanjem naslednje točke
            {
                if (!this.rob.Contains(this.jarvis_q)) //ni še v robu, doda
                {
                    if (this.rob.Count >= 2) //ali zbriše črte roba ali ne
                    {
                        Brisi_crte(new List<Tocka> { p, this.jarvis_q, this.jarvis_r }, true);
                        //Narisi_legendo();
                    }
                    else
                    {
                        Brisi_crte(new List<Tocka> { p, this.jarvis_q, this.jarvis_r }, false);
                        //Narisi_legendo();
                    }


                    this.rob.Add(this.jarvis_q);
                    this.jarvis_stevec = 0;
                    Risi_crte(new List<Tocka>());
                    Risi_tocke(new List<Tocka>());
                }
                else //naslednja točka že v robu, konča izvajanje
                {
                    //nariše končno stanje
                    this.jarvis_stevec = 0;
                    Brisi_crte(new List<Tocka> { p, this.jarvis_q, this.jarvis_r }, true);
                    //Narisi_legendo();
                    Risi_crte(new List<Tocka>());
                    Risi_tocke(new List<Tocka>());

                    timer1.Stop();
                    pospesi.Hide();
                    upocasni.Hide();
                    this.tece = false;
                    start.Hide();
                    start.Text = "Start";
                    korak.Hide();
                }
            }
            else //še v procesu iskanja naslednje točke
            {
                if (this.jarvis_sprememba) //nariše vmesno stanje, ko se spremeni točka q
                {
                    this.jarvis_sprememba = false;
                    Brisi_crte(new List<Tocka> { p, this.jarvis_prejsnji_q, this.jarvis_q }, false);
                    //Narisi_legendo();
                }

                if (this.tocke[this.jarvis_stevec + 1] == p) //r bi bil enak p, kar ne sme biti
                {
                    if (this.jarvis_stevec + 2 != this.tocke.Count) //p ni zadnja točka v tabeli, lahko preskoči
                    {
                        Brisi_crte(new List<Tocka> { p, this.jarvis_q, this.jarvis_r }, false);
                        //Narisi_legendo();
                        //preskoči p
                        this.jarvis_stevec = this.jarvis_stevec + 2;
                        this.jarvis_r = this.tocke[this.jarvis_stevec];

                        Risi_crte(new List<Tocka> { p, this.jarvis_q, this.jarvis_r });
                        Risi_tocke(new List<Tocka> { p, this.jarvis_q, this.jarvis_r });

                        if (Jarvis.Jarvis.Rotacija(p, this.jarvis_q, this.jarvis_r) <= 0) //rotacija v desno, spremeni q, v naslednjem koraku vmesno stanje
                        {
                            this.jarvis_prejsnji_q = this.jarvis_q; //da ve v naslednjem koraku katere črte izbrisat
                            this.jarvis_sprememba = true;
                            this.jarvis_q = this.jarvis_r;

                        }

                    }
                    else //smo na kncu tabele, ustavim iskanje naslednje točke
                    {
                        Brisi_crte(new List<Tocka> { p, this.jarvis_q, this.jarvis_r }, false);
                        this.jarvis_stevec++;
                    }
                }
                else // r ne bi bil enak p
                {
                    Brisi_crte(new List<Tocka> { p, this.jarvis_q, this.jarvis_r }, false);
                    //Narisi_legendo();
                    this.jarvis_stevec++;
                    this.jarvis_r = this.tocke[this.jarvis_stevec];

                    Risi_crte(new List<Tocka> { p, this.jarvis_q, this.jarvis_r });
                    Risi_tocke(new List<Tocka> { p, this.jarvis_q, this.jarvis_r });
                    if (Jarvis.Jarvis.Rotacija(p, this.jarvis_q, this.jarvis_r) <= 0) //rotacija v desno, spremeni q, v naslednjem koraku vmesno stanje
                    {
                        this.jarvis_prejsnji_q = this.jarvis_q;
                        this.jarvis_sprememba = true;
                        this.jarvis_q = this.jarvis_r;

                    }

                }
            }

        }

        /// <summary>
        /// Timer ki izvaja korake algoritma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.algoritem == "Graham")
            {
                Graham_risi_korak();
            }
            else //izvaja jarvis
            {
                Jarvis_korak_risi();
            }
        }

        /// <summary>
        /// Začne izvajanje algoritma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_Click(object sender, EventArgs e)
        {
            if (!this.tece)
            {
                

                if (this.algoritem == "Graham") //nariše začetno stanje za graham
                {
                    Risi_tocke(new List<Tocka> { this.rob[this.rob.Count - 2], this.rob[this.rob.Count - 1], this.tocke[this.graham_stevec] });
                    Risi_crte(new List<Tocka> { this.rob[this.rob.Count - 2], this.rob[this.rob.Count - 1], this.tocke[this.graham_stevec] });
                }
                else //nariše začetno stanje za jarvis
                {
                    Risi_tocke(new List<Tocka> {});
                    Risi_crte(new List<Tocka> {  });
                }
                
                timer1.Interval = int.Parse(hitrost.Text);
                if (timer1.Interval != 100)
                {
                    pospesi.Show();
                }
                if (timer1.Interval != 2000)
                {
                    upocasni.Show();
                }

                var t = Task.Delay(timer1.Interval);
                t.Wait();
                
                this.tece = true;
            }

            if (start.Text == "Start") //začne izvajanje
            {
                timer1.Start();
                start.Text = "Stop";
                if (timer1.Interval != 100)
                {
                    pospesi.Show();
                }
                if (timer1.Interval != 2000)
                {
                    upocasni.Show();
                }
                korak.Hide();
            }
            else if (start.Text == "Stop") // vstavi izvajanje
            {
                timer1.Stop();
                start.Text = "Start";
                pospesi.Hide();
                upocasni.Hide();
                korak.Show();
            }
            
        }

        private void upocasni_Click(object sender, EventArgs e)
        {
            timer1.Interval = timer1.Interval + 100;
            if (timer1.Interval == 2000)
            {
                upocasni.Hide();
            }
            else if (timer1.Interval == 200)
            {
                pospesi.Show();
            }
        }

        private void pospesi_Click(object sender, EventArgs e)
        {
            timer1.Interval = timer1.Interval - 100;
            if (timer1.Interval == 100)
            {
                pospesi.Hide();
            }
            else if (timer1.Interval == 1900)
            {
                upocasni.Show();
            }
        }

        private void zacetek_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.rob = new List<Tocka>();
            this.tocke = new List<Tocka>();
            start.Text = "Start";
            Skrij_zacetno_stran(false);
        }

        private void korak_Click(object sender, EventArgs e)
        {
            if (this.algoritem == "Graham")
            {
                Graham_risi_korak();
            }
            else
            {
                Jarvis_korak_risi();
            }
        }

        private void zacni_Click(object sender, EventArgs e)
        {
            string op = Preveri_podatke();
            if (op.Equals("OK"))
            {
                if (alg_box.SelectedIndex == 0)
                {
                    this.algoritem = "Jarvis";
                }
                else
                {
                    this.algoritem = "Graham";
                }

                if (gen_box.SelectedIndex == 0)
                {
                    Generiraj();

                    Tocka min_tocka = new Tocka(float.MaxValue, float.MaxValue);
                    foreach (Tocka t in this.tocke)
                    {
                        if (t < min_tocka)
                        {
                            min_tocka = t;
                        }
                    }

                    
                    if (this.algoritem == "Graham")
                    {
                        this.tocke = Graham.Graham.Uredi_kot(this.tocke, min_tocka);
                    }
                    for (int i = 0; i < tocke.Count; i++)
                    {
                        this.tocke[i] = new Tocka(this.tocke[i].x, this.tocke[i].y, i + 1);
                        
                    }
                    
                    if (this.algoritem == "Graham")
                    {
                        this.rob.Add(tocke[0]);
                        this.rob.Add(tocke[1]);
                    }
                    else
                    {
                        this.rob.Add(min_tocka);
                    }
                    this.graham_stevec = 2;
                    this.jarvis_stevec = 0;

                    Skrij_zacetno_stran(true);
                    this.platno = this.CreateGraphics();
                    this.platno.Clear(Color.White);
                    Narisi_legendo();
                    Risi_tocke(new List<Tocka>());
                    Risi_crte(new List<Tocka>());
                }
                else
                {
                    this.izbiraj_tocke = true;
                    label1.Show();
                    stevec_tock.Show();
                    stevec_tock.Text = st_tock.Text;
                    Skrij_zacetno_stran(true);
                    zacetek.Hide();
                    start.Hide();
                    korak.Hide();
                    this.platno = this.CreateGraphics();
                    this.platno.Clear(Color.White);
                    Narisi_legendo();
                }
            }
            else
            {
                opozorilo.Text = op;
                opozorilo.Show();
            }
        }

        private void Okno_MouseDown(object sender, MouseEventArgs e)
        {
            if (izbiraj_tocke)
            {
                if (e.Y > 90 && e.Y < 600 && e.X < 980)
                {
                    int st = int.Parse(stevec_tock.Text);
                    Tocka t = new Tocka(((int)e.X / 10)*10, ((int)e.Y / 10)*10, int.Parse(st_tock.Text) - st + 1);
                    if (!this.tocke.Contains(t))
                    {
                        this.tocke.Add(t);
                        Risi_tocke(new List<Tocka>());
                        st--;
                        stevec_tock.Text = st.ToString();
                        if (st == 0)
                        {
                            izbiraj_tocke = false;
                            label1.Hide();
                            stevec_tock.Hide();
                            zacetek.Show();
                            start.Show();
                            korak.Show();

                            Tocka min_tocka = new Tocka(float.MaxValue, float.MaxValue);
                            foreach (Tocka t1 in this.tocke)
                            {
                                if (t1 < min_tocka)
                                {
                                    min_tocka = t1;
                                }
                            }


                            if (this.algoritem == "Graham")
                            {
                                this.tocke = Graham.Graham.Uredi_kot(this.tocke, min_tocka);
                            }
                            for (int i = 0; i < tocke.Count; i++)
                            {
                                this.tocke[i] = new Tocka(this.tocke[i].x, this.tocke[i].y, i + 1);

                            }

                            if (this.algoritem == "Graham")
                            {
                                this.rob.Add(tocke[0]);
                                this.rob.Add(tocke[1]);
                            }
                            else
                            {
                                this.rob.Add(min_tocka);
                            }

                            this.graham_stevec = 2;
                            this.jarvis_stevec = 0;
                            Risi_tocke(new List<Tocka>());
                            Risi_crte(new List<Tocka>());
                        }
                    }
                }
            }
        }
    }
}
