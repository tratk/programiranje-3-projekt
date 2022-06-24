
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
            this.graham = new System.Windows.Forms.Button();
            this.st_tock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.jarvis = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.hitrost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // graham
            // 
            this.graham.Location = new System.Drawing.Point(68, 226);
            this.graham.Name = "graham";
            this.graham.Size = new System.Drawing.Size(75, 23);
            this.graham.TabIndex = 0;
            this.graham.Text = "Graham";
            this.graham.UseVisualStyleBackColor = true;
            this.graham.Click += new System.EventHandler(this.graham_Click);
            // 
            // st_tock
            // 
            this.st_tock.Location = new System.Drawing.Point(68, 77);
            this.st_tock.Name = "st_tock";
            this.st_tock.Size = new System.Drawing.Size(100, 20);
            this.st_tock.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Število točk:";
            // 
            // jarvis
            // 
            this.jarvis.Location = new System.Drawing.Point(175, 225);
            this.jarvis.Name = "jarvis";
            this.jarvis.Size = new System.Drawing.Size(75, 23);
            this.jarvis.TabIndex = 3;
            this.jarvis.Text = "Jarvis";
            this.jarvis.UseVisualStyleBackColor = true;
            this.jarvis.Click += new System.EventHandler(this.jarvis_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(13, 13);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 9;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Zacetna hitrost [ms]:";
            // 
            // hitrost
            // 
            this.hitrost.Location = new System.Drawing.Point(217, 76);
            this.hitrost.Name = "hitrost";
            this.hitrost.Size = new System.Drawing.Size(100, 20);
            this.hitrost.TabIndex = 11;
            // 
            // Okno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.hitrost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.start);
            this.Controls.Add(this.jarvis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.st_tock);
            this.Controls.Add(this.graham);
            this.Name = "Okno";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Okno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button graham;
        private System.Windows.Forms.TextBox st_tock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button jarvis;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hitrost;
    }
}

