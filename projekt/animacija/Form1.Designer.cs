
namespace animacija
{
    partial class Okno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.st_tock = new System.Windows.Forms.TextBox();
            this.st_tock_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.start = new System.Windows.Forms.Button();
            this.hitrost_label = new System.Windows.Forms.Label();
            this.hitrost = new System.Windows.Forms.TextBox();
            this.upocasni = new System.Windows.Forms.Button();
            this.pospesi = new System.Windows.Forms.Button();
            this.zacetek = new System.Windows.Forms.Button();
            this.korak = new System.Windows.Forms.Button();
            this.hitrost_label1 = new System.Windows.Forms.Label();
            this.alg_label = new System.Windows.Forms.Label();
            this.gen_label = new System.Windows.Forms.Label();
            this.alg_box = new System.Windows.Forms.ListBox();
            this.gen_box = new System.Windows.Forms.ListBox();
            this.zacni = new System.Windows.Forms.Button();
            this.opozorilo = new System.Windows.Forms.Label();
            this.st_tock_label1 = new System.Windows.Forms.Label();
            this.stevec_tock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // st_tock
            // 
            this.st_tock.Location = new System.Drawing.Point(71, 171);
            this.st_tock.Name = "st_tock";
            this.st_tock.Size = new System.Drawing.Size(100, 20);
            this.st_tock.TabIndex = 1;
            // 
            // st_tock_label
            // 
            this.st_tock_label.AutoSize = true;
            this.st_tock_label.Location = new System.Drawing.Point(68, 142);
            this.st_tock_label.Name = "st_tock_label";
            this.st_tock_label.Size = new System.Drawing.Size(66, 13);
            this.st_tock_label.TabIndex = 2;
            this.st_tock_label.Text = "Število točk,";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(94, 13);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 9;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // hitrost_label
            // 
            this.hitrost_label.AutoSize = true;
            this.hitrost_label.Location = new System.Drawing.Point(217, 142);
            this.hitrost_label.Name = "hitrost_label";
            this.hitrost_label.Size = new System.Drawing.Size(198, 13);
            this.hitrost_label.TabIndex = 10;
            this.hitrost_label.Text = "Zacetna hitrost [ms, min 100, max 2000],";
            // 
            // hitrost
            // 
            this.hitrost.Location = new System.Drawing.Point(217, 171);
            this.hitrost.Name = "hitrost";
            this.hitrost.Size = new System.Drawing.Size(100, 20);
            this.hitrost.TabIndex = 11;
            // 
            // upocasni
            // 
            this.upocasni.Location = new System.Drawing.Point(94, 42);
            this.upocasni.Name = "upocasni";
            this.upocasni.Size = new System.Drawing.Size(75, 23);
            this.upocasni.TabIndex = 12;
            this.upocasni.Text = "Upočasni";
            this.upocasni.UseVisualStyleBackColor = true;
            this.upocasni.Click += new System.EventHandler(this.upocasni_Click);
            // 
            // pospesi
            // 
            this.pospesi.Location = new System.Drawing.Point(175, 42);
            this.pospesi.Name = "pospesi";
            this.pospesi.Size = new System.Drawing.Size(75, 23);
            this.pospesi.TabIndex = 13;
            this.pospesi.Text = "Pospeši";
            this.pospesi.UseVisualStyleBackColor = true;
            this.pospesi.Click += new System.EventHandler(this.pospesi_Click);
            // 
            // zacetek
            // 
            this.zacetek.Location = new System.Drawing.Point(13, 13);
            this.zacetek.Name = "zacetek";
            this.zacetek.Size = new System.Drawing.Size(75, 23);
            this.zacetek.TabIndex = 14;
            this.zacetek.Text = "Začetek";
            this.zacetek.UseVisualStyleBackColor = true;
            this.zacetek.Click += new System.EventHandler(this.zacetek_Click);
            // 
            // korak
            // 
            this.korak.Location = new System.Drawing.Point(175, 13);
            this.korak.Name = "korak";
            this.korak.Size = new System.Drawing.Size(75, 23);
            this.korak.TabIndex = 15;
            this.korak.Text = "Korak";
            this.korak.UseVisualStyleBackColor = true;
            this.korak.Click += new System.EventHandler(this.korak_Click);
            // 
            // hitrost_label1
            // 
            this.hitrost_label1.AutoSize = true;
            this.hitrost_label1.Location = new System.Drawing.Point(217, 155);
            this.hitrost_label1.Name = "hitrost_label1";
            this.hitrost_label1.Size = new System.Drawing.Size(115, 13);
            this.hitrost_label1.TabIndex = 18;
            this.hitrost_label1.Text = "se zaokroži na 100 ms.";
            // 
            // alg_label
            // 
            this.alg_label.AutoSize = true;
            this.alg_label.Location = new System.Drawing.Point(68, 274);
            this.alg_label.Name = "alg_label";
            this.alg_label.Size = new System.Drawing.Size(80, 13);
            this.alg_label.TabIndex = 19;
            this.alg_label.Text = "Izberi algoritem:";
            // 
            // gen_label
            // 
            this.gen_label.AutoSize = true;
            this.gen_label.Location = new System.Drawing.Point(68, 221);
            this.gen_label.Name = "gen_label";
            this.gen_label.Size = new System.Drawing.Size(85, 13);
            this.gen_label.TabIndex = 20;
            this.gen_label.Text = "Generacija točk:";
            // 
            // alg_box
            // 
            this.alg_box.FormattingEnabled = true;
            this.alg_box.Items.AddRange(new object[] {
            "Jarvis march",
            "Graham scan"});
            this.alg_box.Location = new System.Drawing.Point(71, 290);
            this.alg_box.Name = "alg_box";
            this.alg_box.Size = new System.Drawing.Size(88, 30);
            this.alg_box.TabIndex = 21;
            // 
            // gen_box
            // 
            this.gen_box.FormattingEnabled = true;
            this.gen_box.Items.AddRange(new object[] {
            "Naključna",
            "Izberi sam"});
            this.gen_box.Location = new System.Drawing.Point(71, 238);
            this.gen_box.Name = "gen_box";
            this.gen_box.Size = new System.Drawing.Size(100, 30);
            this.gen_box.TabIndex = 22;
            // 
            // zacni
            // 
            this.zacni.Location = new System.Drawing.Point(71, 363);
            this.zacni.Name = "zacni";
            this.zacni.Size = new System.Drawing.Size(75, 23);
            this.zacni.TabIndex = 23;
            this.zacni.Text = "Začni";
            this.zacni.UseVisualStyleBackColor = true;
            this.zacni.Click += new System.EventHandler(this.zacni_Click);
            // 
            // opozorilo
            // 
            this.opozorilo.AutoSize = true;
            this.opozorilo.Location = new System.Drawing.Point(172, 363);
            this.opozorilo.Name = "opozorilo";
            this.opozorilo.Size = new System.Drawing.Size(35, 13);
            this.opozorilo.TabIndex = 24;
            this.opozorilo.Text = "label1";
            // 
            // st_tock_label1
            // 
            this.st_tock_label1.AutoSize = true;
            this.st_tock_label1.Location = new System.Drawing.Point(71, 155);
            this.st_tock_label1.Name = "st_tock_label1";
            this.st_tock_label1.Size = new System.Drawing.Size(81, 13);
            this.st_tock_label1.TabIndex = 26;
            this.st_tock_label1.Text = "min 4, max 100:";
            // 
            // stevec_tock
            // 
            this.stevec_tock.AutoSize = true;
            this.stevec_tock.Location = new System.Drawing.Point(142, 77);
            this.stevec_tock.Name = "stevec_tock";
            this.stevec_tock.Size = new System.Drawing.Size(39, 13);
            this.stevec_tock.TabIndex = 27;
            this.stevec_tock.Text = "stevec";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Izbrati moraš še toliko točk:";
            // 
            // Okno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stevec_tock);
            this.Controls.Add(this.st_tock_label1);
            this.Controls.Add(this.opozorilo);
            this.Controls.Add(this.zacni);
            this.Controls.Add(this.gen_box);
            this.Controls.Add(this.alg_box);
            this.Controls.Add(this.gen_label);
            this.Controls.Add(this.alg_label);
            this.Controls.Add(this.hitrost_label1);
            this.Controls.Add(this.korak);
            this.Controls.Add(this.zacetek);
            this.Controls.Add(this.pospesi);
            this.Controls.Add(this.upocasni);
            this.Controls.Add(this.hitrost);
            this.Controls.Add(this.hitrost_label);
            this.Controls.Add(this.start);
            this.Controls.Add(this.st_tock_label);
            this.Controls.Add(this.st_tock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Okno";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Okno_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Okno_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox st_tock;
        private System.Windows.Forms.Label st_tock_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label hitrost_label;
        private System.Windows.Forms.TextBox hitrost;
        private System.Windows.Forms.Button upocasni;
        private System.Windows.Forms.Button pospesi;
        private System.Windows.Forms.Button zacetek;
        private System.Windows.Forms.Button korak;
        private System.Windows.Forms.Label hitrost_label1;
        private System.Windows.Forms.Label alg_label;
        private System.Windows.Forms.Label gen_label;
        private System.Windows.Forms.ListBox alg_box;
        private System.Windows.Forms.ListBox gen_box;
        private System.Windows.Forms.Button zacni;
        private System.Windows.Forms.Label opozorilo;
        private System.Windows.Forms.Label st_tock_label1;
        private System.Windows.Forms.Label stevec_tock;
        private System.Windows.Forms.Label label1;
    }
}

