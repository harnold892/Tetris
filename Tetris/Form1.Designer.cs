namespace Tetris
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tajmerzaPad = new System.Windows.Forms.Timer(this.components);
            this.dugmezaPocetak = new System.Windows.Forms.Button();
            this.tajmerzaKretanje = new System.Windows.Forms.Timer(this.components);
            this.labelaiznadRez = new System.Windows.Forms.Label();
            this.labelaRezultata = new System.Windows.Forms.Label();
            this.labelaNivoa = new System.Windows.Forms.Label();
            this.labelaiznadNivoa = new System.Windows.Forms.Label();
            this.Muzika = new System.Windows.Forms.PictureBox();
            this.jacinaZvuka = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.Muzika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jacinaZvuka)).BeginInit();
            this.SuspendLayout();
            // 
            // tajmerzaPad
            // 
            this.tajmerzaPad.Interval = 200;
            this.tajmerzaPad.Tick += new System.EventHandler(this.tajmerzaPad_Tick);
            // 
            // dugmezaPocetak
            // 
            this.dugmezaPocetak.AutoSize = true;
            this.dugmezaPocetak.BackColor = System.Drawing.Color.Red;
            this.dugmezaPocetak.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dugmezaPocetak.ForeColor = System.Drawing.Color.White;
            this.dugmezaPocetak.Location = new System.Drawing.Point(455, 513);
            this.dugmezaPocetak.Name = "dugmezaPocetak";
            this.dugmezaPocetak.Size = new System.Drawing.Size(75, 34);
            this.dugmezaPocetak.TabIndex = 0;
            this.dugmezaPocetak.Text = "Pocni";
            this.dugmezaPocetak.UseVisualStyleBackColor = false;
            this.dugmezaPocetak.Click += new System.EventHandler(this.dugmezaPocetak_Click);
            // 
            // tajmerzaKretanje
            // 
            this.tajmerzaKretanje.Interval = 50;
            this.tajmerzaKretanje.Tick += new System.EventHandler(this.tajmerzaKretanje_Tick);
            // 
            // labelaiznadRez
            // 
            this.labelaiznadRez.AutoSize = true;
            this.labelaiznadRez.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelaiznadRez.Location = new System.Drawing.Point(423, 206);
            this.labelaiznadRez.Name = "labelaiznadRez";
            this.labelaiznadRez.Size = new System.Drawing.Size(107, 29);
            this.labelaiznadRez.TabIndex = 1;
            this.labelaiznadRez.Text = "Rezultat";
            // 
            // labelaRezultata
            // 
            this.labelaRezultata.BackColor = System.Drawing.SystemColors.Info;
            this.labelaRezultata.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelaRezultata.Location = new System.Drawing.Point(370, 235);
            this.labelaRezultata.Name = "labelaRezultata";
            this.labelaRezultata.Size = new System.Drawing.Size(160, 23);
            this.labelaRezultata.TabIndex = 2;
            this.labelaRezultata.Text = "0";
            this.labelaRezultata.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelaNivoa
            // 
            this.labelaNivoa.BackColor = System.Drawing.SystemColors.Info;
            this.labelaNivoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelaNivoa.Location = new System.Drawing.Point(370, 311);
            this.labelaNivoa.Name = "labelaNivoa";
            this.labelaNivoa.Size = new System.Drawing.Size(160, 23);
            this.labelaNivoa.TabIndex = 4;
            this.labelaNivoa.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelaiznadNivoa
            // 
            this.labelaiznadNivoa.AutoSize = true;
            this.labelaiznadNivoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelaiznadNivoa.Location = new System.Drawing.Point(470, 277);
            this.labelaiznadNivoa.Name = "labelaiznadNivoa";
            this.labelaiznadNivoa.Size = new System.Drawing.Size(60, 34);
            this.labelaiznadNivoa.TabIndex = 3;
            this.labelaiznadNivoa.Text = "Nivo";
            this.labelaiznadNivoa.UseCompatibleTextRendering = true;
            // 
            // Muzika
            // 
            this.Muzika.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Muzika.BackgroundImage")));
            this.Muzika.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Muzika.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Muzika.Location = new System.Drawing.Point(470, 383);
            this.Muzika.Name = "Muzika";
            this.Muzika.Size = new System.Drawing.Size(60, 60);
            this.Muzika.TabIndex = 5;
            this.Muzika.TabStop = false;
            this.Muzika.Click += new System.EventHandler(this.Muzika_Click);
            // 
            // jacinaZvuka
            // 
            this.jacinaZvuka.Location = new System.Drawing.Point(360, 398);
            this.jacinaZvuka.Name = "jacinaZvuka";
            this.jacinaZvuka.Size = new System.Drawing.Size(104, 45);
            this.jacinaZvuka.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 559);
            this.Controls.Add(this.jacinaZvuka);
            this.Controls.Add(this.Muzika);
            this.Controls.Add(this.labelaNivoa);
            this.Controls.Add(this.labelaiznadNivoa);
            this.Controls.Add(this.labelaRezultata);
            this.Controls.Add(this.labelaiznadRez);
            this.Controls.Add(this.dugmezaPocetak);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Muzika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jacinaZvuka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tajmerzaPad;
        private System.Windows.Forms.Button dugmezaPocetak;
        private System.Windows.Forms.Timer tajmerzaKretanje;
        private System.Windows.Forms.Label labelaiznadRez;
        private System.Windows.Forms.Label labelaRezultata;
        private System.Windows.Forms.Label labelaNivoa;
        private System.Windows.Forms.Label labelaiznadNivoa;
        private System.Windows.Forms.PictureBox Muzika;
        private System.Windows.Forms.TrackBar jacinaZvuka;




    }
}

