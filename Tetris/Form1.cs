using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace Tetris
{
    public partial class Form1 : Form
    {
        PictureBox[,] polja=new PictureBox[18,10];
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        WindowsMediaPlayer bomba = new WindowsMediaPlayer();
        int[,] figura=new int[4,2];//[,0] za Y koordinate, [,1] za X koordinate
        
        bool prvi_put=true;
        bool dal_se_mozes_okretati = true;
        int opcija;
        int broj_punih_redova=0;
        bool lijevo, desno,gore,dole,space;
        bool muzikaUpaljena = false;
        int rezultat;
        int nivo = 0;
        int broj_okretaja_figure = 0;
        int tmpIntervalPad = 0;
        int tmpIntervalKretanje = 0;

        public Form1()
        {
            
            InitializeComponent();
            
          
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            int pozicijaX=0;
            int pozicijaY=0;

            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    polja[i, j] = new PictureBox();
                    polja[i, j].BackColor = Color.White;
                    polja[i, j].Size = new Size(30, 30);
                    polja[i, j].BorderStyle = BorderStyle.FixedSingle;
                    polja[i, j].Top = pozicijaY;
                    polja[i, j].Left = pozicijaX;

                    pozicijaX += 30;
                    this.Controls.Add(polja[i,j]);
                }
                pozicijaY += 30;
                pozicijaX = 0;
            }


           tmpIntervalPad = tajmerzaPad.Interval;
           tmpIntervalKretanje = tajmerzaKretanje.Interval;
           
            
        }

        private void tajmerzaPad_Tick(object sender, EventArgs e)
        {
            if (prvi_put==true)
            {
                izborFigure();
                labelaNivoa.Text = "1";
            }
            prvi_put = false;
            for (int i = 0; i < 4; i++)
            {
                if (figura[i,0] > 0)
                {
                    polja[figura[i,0] - 1, figura[i,1]].BackColor = Color.White;
                }

            }
            
                for (int i = 0; i < 4; i++)
                {
                    polja[figura[i, 0], figura[i, 1]].BackColor = Color.Red;
                }
            
            

            
            for (int i = 0; i < 4; i++)
            {
                if (i < 3)
                {
                    if (figura[i, 0] == 17 || polja[figura[i, 0] + 1, figura[i, 1]].BackColor != Color.White)
                    {

                        if (figura[i, 0] + 1 != figura[i + 1, 0])
                        {
                            space = false;
                            
                            broj_okretaja_figure = 0;
                            
                        punRed();
                       
                        saberiRezultatiNivo();
                        broj_punih_redova = 0;
                            izborFigure();

                            for (int j = 0; j < 4; j++)
                            {
                                if (polja[figura[j, 0], figura[j, 1]].BackColor != Color.White)
                                {
                                    tajmerzaPad.Stop();
                                    tajmerzaKretanje.Stop();
                                    
                                    MessageBox.Show("PUKO SI PURGERU");
                                    Application.Exit();

                                   
                                }
                            }
                            tajmerzaPad.Stop();
                            tajmerzaPad.Start();
                            
                        }
                    }
                }
                else
                {
                    if (figura[i, 0] == 17 || polja[figura[i, 0] + 1, figura[i, 1]].BackColor != Color.White)
                    {
                        space = false;
                        
                        broj_okretaja_figure = 0;
                        punRed();
                        
                        saberiRezultatiNivo();
                        broj_punih_redova = 0;
                            izborFigure();
                            for (int j = 0; j < 4; j++)
                            {
                                if (polja[figura[j, 0], figura[j, 1]].BackColor != Color.White)
                                {
                                    tajmerzaPad.Stop();
                                    tajmerzaKretanje.Stop();
                                   
                                    MessageBox.Show("PUKO SI PURGERU");
                                    Application.Exit();
                                    
                                }
                            }
                            tajmerzaPad.Stop();
                            tajmerzaPad.Start();
                           
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                figura[i, 0]++;
            }

            
        }

        private void dugmezaPocetak_Click(object sender, EventArgs e)
        {
            tajmerzaPad.Enabled = true;
            tajmerzaKretanje.Enabled = true;
            dugmezaPocetak.Dispose();
            jacinaZvuka.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                lijevo = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                desno = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                gore = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                dole = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
            {
                lijevo = false;
            }
            if (e.KeyData == Keys.Right)
            {
                desno = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                gore = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                dole = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = false;
            }
        }


        private void tajmerzaKretanje_Tick(object sender, EventArgs e)
        {
           
            int najdesniji = 0;
            int najljevlji = 10;
            int naj_l_index=0;
            int naj_d_index = 0;
            for (int i = 0; i < 4; i++)
            {
                
                if (figura[i, 1] >= najdesniji)
                {
                    najdesniji = figura[i,1];
                    naj_d_index = i;
                }
                if (figura[i, 1] <= najljevlji)
                {
                    najljevlji = figura[i, 1];
                    naj_l_index = i;
                }
            }
           


            if (lijevo == true && figura[naj_l_index,1]>0&&polja[figura[naj_l_index,0],figura[naj_l_index,1]-1].BackColor==Color.White)
            {
                tajmerzaPad.Stop();
                for (int i = 0; i < 4; i++)
                {
                    
                   
                        polja[figura[i, 0], figura[i, 1]].BackColor = Color.White;
                        if (figura[i, 0] > 0)
                        polja[figura[i, 0] - 1, figura[i, 1]].BackColor = Color.White;
                    
                }
                

                for (int i = 0; i < 4; i++)
                {
                    figura[i, 1]--;
                }
                for (int i = 0; i < 4; i++)
                {
                    polja[figura[i, 0], figura[i, 1]].BackColor = Color.Red;
                }
                tajmerzaPad.Start();
            }
            if (desno == true && figura[naj_d_index, 1] < 9 && polja[figura[naj_d_index, 0], figura[naj_d_index, 1] +1].BackColor == Color.White)
            {
                tajmerzaPad.Stop();
                for (int i = 0; i < 4; i++)
                {
                    
                    polja[figura[i, 0], figura[i, 1]].BackColor = Color.White;
                    if (figura[i, 0] > 0)
                    polja[figura[i, 0] - 1, figura[i, 1]].BackColor = Color.White;
                }


                for (int i = 0; i < 4; i++)
                {
                    figura[i, 1]++;
                }
                for (int i = 0; i < 4; i++)
                {
                    polja[figura[i, 0], figura[i, 1]].BackColor = Color.Red;
                }
                tajmerzaPad.Start();
            }

            if (figura[naj_l_index, 1] == 0||polja[figura[naj_l_index,0],figura[naj_l_index,1]-1].BackColor!=Color.White)//za okretanje kod lijeve ivice
            {
                switch (opcija)
                {
                    case 0:  //I tip figure
                        dal_se_mozes_okretati = false;
                        break;
                    case 1: //L tip figure
                        if (broj_okretaja_figure % 4 == 2)
                            dal_se_mozes_okretati = false;
                        break;

                    case 3://T tip figure
                        if (broj_okretaja_figure % 4 == 3)
                            dal_se_mozes_okretati = false;
                        break;
                    case 4://S tip figure
                        if (broj_okretaja_figure % 2 == 1)
                            dal_se_mozes_okretati = false;

                        break;
                    case 5://Z tip figure
                        if (broj_okretaja_figure % 2 == 1)
                            dal_se_mozes_okretati = false;
                        break;
                    case 6://J tip figure
                        if (broj_okretaja_figure % 4 == 2)
                            dal_se_mozes_okretati = false;
                        break;

                }
            }
            else if (figura[naj_d_index, 1] == 9 || polja[figura[naj_d_index, 0], figura[naj_d_index, 1] + 1].BackColor != Color.White)//za okretanje kod desne ivice
            {

                switch (opcija)
                {

                    case 1: //L tip figure
                        if (broj_okretaja_figure % 4 == 0 || broj_okretaja_figure % 4 == 2)
                            dal_se_mozes_okretati = false;
                        break;

                    case 3://T tip figure
                        if (broj_okretaja_figure % 4 == 1)
                            dal_se_mozes_okretati = false;
                        break;

                    case 5://Z tip figure
                        if (broj_okretaja_figure % 2 == 1)
                            dal_se_mozes_okretati = false;
                        break;
                    case 6://J tip figure
                        if (broj_okretaja_figure % 4 == 0)
                            dal_se_mozes_okretati = false;
                        break;

                }
            }
            else if (opcija == 0)
            {
                if (figura[naj_d_index, 1] >= 8)
                    dal_se_mozes_okretati = false;
            }
            else
            {
                dal_se_mozes_okretati = true;
            }




                if (gore == true&&dal_se_mozes_okretati==true)
                {
                    tajmerzaPad.Stop();
                    broj_okretaja_figure++;
                    int tmp_X;
                    int tmp_Y;
                    for (int i = 0; i < 4; i++)
                    {
                        if(figura[i,0]>0)
                        {
                        polja[figura[i, 0], figura[i, 1]].BackColor = Color.White;
                        polja[figura[i, 0] - 1, figura[i, 1]].BackColor = Color.White;
                        }
                    }
                    switch (opcija)
                    {
                        case 0:  //I tip figure
                            switch (broj_okretaja_figure % 2)
                            {

                                case 0:
                                    tmp_X = figura[2, 1];
                                    tmp_Y = figura[2, 0];

                                    for (int i = 0; i < 4; i++)
                                    {
                                        figura[i, 0] = tmp_Y - 3 + i;
                                        figura[i, 1] = tmp_X;
                                    }

                                    break;
                                case 1:
                                    tmp_X = figura[2, 1];
                                    tmp_Y = figura[2, 0];

                                    for (int i = 0; i < 4; i++)
                                    {
                                        figura[i, 0] = tmp_Y;
                                        figura[i, 1] = tmp_X + i - 1;
                                    }


                                    break;
                            }
                            break;
                        case 1: //L tip figure
                            switch (broj_okretaja_figure % 4)
                            {
                                case 0:

                                    figura[0, 0] = figura[2, 0] - 2;
                                    figura[0, 1] = figura[2, 1];
                                    figura[1, 0] = figura[2, 0] - 1;
                                    figura[1, 1] = figura[2, 1];

                                    break;
                                case 1:

                                    figura[3, 0]--;
                                    figura[0, 0]++;
                                    figura[0, 1] = figura[0, 1] + 2;

                                    break;
                                case 2:

                                    figura[0, 0]--;
                                    figura[0, 1] = figura[0, 1] - 2;

                                    tmp_X = figura[3, 1];
                                    tmp_Y = figura[0, 0];
                                    for (int i = 1; i < 4; i++)
                                    {
                                        figura[i, 0] = tmp_Y + i - 1;
                                        figura[i, 1] = tmp_X;
                                    }

                                    break;
                                case 3:


                                    figura[2, 0]++;
                                    figura[2, 1]--;
                                    figura[0, 0]++;
                                    figura[0, 1] = figura[0, 1] + 2;
                                    figura[1, 0] = figura[1, 0] + 2;
                                    figura[1, 1]++;


                                    break;

                            }

                            break;

                        case 3://T tip figure

                            switch (broj_okretaja_figure % 4)
                            {
                                case 0:
                                    figura[0, 0]++;
                                    figura[0, 1]--;
                                    figura[1, 1]++;
                                    figura[2, 0]--;
                                    figura[3, 0]++;
                                    figura[3, 1]--;
                                    break;
                                case 1:

                                    figura[1, 1]--;
                                    figura[1, 0]--;
                                    break;
                                case 2:
                                    figura[3, 0]--;
                                    figura[3, 1]++;

                                    break;
                                case 3:
                                   figura[0, 0]--;
                                    figura[0, 1]++;
                                    figura[1, 0]++;
                                    figura[2, 0]++;
                                    break;
                            }

                            break;
                        case 4://S tip figure
                            switch (broj_okretaja_figure % 2)
                            {
                                case 0:
                                    figura[0, 0] = figura[1, 0] + 1;
                                    figura[0, 1]--;
                                    figura[2, 0]++;
                                    figura[2, 1]--;
                                    figura[3, 0]--;
                                    break;
                                case 1:
                                    figura[0, 0] = figura[1, 0] - 1;
                                    figura[0, 1]++;
                                    figura[2, 0]--;
                                    figura[2, 1]++;
                                    figura[3, 0]++;
                                    break;
                            }

                            break;
                        case 5://Z tip figure
                            switch (broj_okretaja_figure % 2)
                            {
                                case 0:
                                    figura[0, 0]++;
                                    figura[0, 1]--;
                                    figura[2, 0]++;
                                    figura[2, 1]++;
                                    figura[3, 1] = figura[3, 1] + 2;
                                    break;
                                case 1:
                                    figura[0, 0]--;
                                    figura[0, 1]++;

                                    figura[2, 0]--;
                                    figura[2, 1]--;
                                    figura[3, 1] = figura[3, 1] - 2;
                                    break;
                            }
                            break;
                        case 6://J tip figure
                            switch (broj_okretaja_figure % 4)
                            {
                                case 0:
                                    figura[3, 1] = figura[3, 1] - 2;
                                    figura[2, 0]++;
                                    figura[2, 1]--;

                                    figura[0, 0]--;
                                    figura[0, 1] = figura[1, 1];
                                    break;
                                case 1:
                                    figura[0, 0]++;
                                    figura[0, 1]--;
                                    figura[1, 0]++;
                                    figura[1, 1]--;
                                    figura[3, 1] = figura[3, 1] + 2;
                                    break;
                                case 2:
                                    figura[3, 0] = figura[3, 0] - 2;
                                    for (int i = 0; i < 3; i++)
                                    {
                                        figura[i, 0] = figura[3, 0] + i;
                                        figura[i, 1] = figura[3, 1] - 1;
                                    }
                                    break;
                                case 3:
                                    figura[0, 0] = figura[1, 0];
                                    figura[0, 1] = figura[1, 1] - 1;
                                    figura[2, 0] = figura[1, 0];
                                    figura[2, 1] = figura[1, 1] + 1;
                                    figura[3, 0] = figura[2, 0] + 1;
                                    figura[3, 1] = figura[2, 1];
                                    break;
                            }
                            break;

                    }
                    
                        for (int i = 0; i < 4; i++)
                        {
                            polja[figura[i, 0], figura[i, 1]].BackColor = Color.Red;
                        }
                        

                        
                    tajmerzaPad.Start();
                }
            
          
            if (dole == true)
            {
                
                tajmerzaPad.Interval = tmpIntervalPad / 3;

            }
            else 
            {
                tajmerzaPad.Interval = tmpIntervalPad;
            }
            if (space == true)
            {
                tajmerzaPad.Interval = 1;
                tajmerzaKretanje.Interval = 1;
                
            }
            else
            {
                
                tajmerzaPad.Interval = tmpIntervalPad;
                tajmerzaKretanje.Interval=tmpIntervalKretanje;
            }
        }

        private void saberiRezultatiNivo()
        {
            switch (broj_punih_redova)
            {
                case 1:
                    rezultat += 40;
                    break;
                case 2:
                    rezultat += 100;
                    break;
                case 3:
                    rezultat += 300;
                    break;
                case 4:
                    rezultat += 1200;
                    break;
             
            }
            labelaRezultata.Text = rezultat.ToString();

            if (rezultat / 100 > nivo)
            {
                nivo++;
                tajmerzaPad.Interval = tmpIntervalPad - nivo*nivo;
                labelaNivoa.Text = nivo.ToString();
            }
        }
        private void punRed()
        {
            for (int i = 0; i < 18; i++)
            {
                bool pun_red = true;
                for (int j = 0; j < 10; j++)
                {
                    if (polja[i, j].BackColor == Color.White)
                    {
                        pun_red = false;
                    }

                }
                if (pun_red == true)
                {
                    bomba.URL = "bomba.mp3";
                    bomba.settings.volume = 30;
                    broj_punih_redova++;
                    for (int j = 0; j < 10; j++)
                    {
                        polja[i, j].BackColor = Color.White;
                    }

                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            polja[k, j].BackColor = polja[k - 1, j].BackColor;
                        }
                    }
                }

            }
        }
        private void izborFigure()
        {
            Random slucajna = new Random();
            opcija = slucajna.Next(0, 7);
            switch (opcija)
            {
                case 0:  //I tip figure
                    for (int i = 0; i < 4; i++)
                    {
                        figura[i, 0] = i;
                        figura[i, 1] = 4;
                    }
                        break;
                case 1: //L tip figure
                        for (int i = 0; i < 3; i++)
                        {
                            figura[i, 0] = i;
                            figura[i, 1] = 4;
                        }
                        figura[3, 0] = 2;
                        figura[3, 1] = 5;
                            break;
                case 2://O tip figure
                    figura[0, 0] = 0;
                    figura[0, 1] = 4;
                    figura[2, 0] = 0;
                    figura[2, 1] = 5;
                    figura[1, 0] = 1;
                    figura[1, 1] = 4;
                    figura[3, 0] = 1;
                    figura[3, 1] = 5;
                    break;
                case 3://T tip figure
                   
                    
                    figura[0, 0] = 0;
                    figura[0, 1] = 3;
                    figura[1, 0] = 0;
                    figura[1, 1] = 5;
                    figura[2, 0] = 0;
                    figura[2, 1] = 4;
                    figura[3, 0] = 1;
                    figura[3, 1] = 4;
                    break;
                case 4://S tip figure
                    figura[0, 0] = 1;
                    figura[0, 1] = 3;
                    figura[2, 0] = 1;
                    figura[2, 1] = 4;
                    figura[1, 0] = 0;
                    figura[1, 1] = 4;
                    figura[3, 0] = 0;
                    figura[3, 1] = 5;
                    
                    break;
                case 5://Z tip figure
                    figura[0, 0] = 0;
                    figura[0, 1] = 3;
                    figura[2, 0] = 1;
                    figura[2, 1] = 4;
                    figura[1, 0] = 0;
                    figura[1, 1] = 4;
                    figura[3, 0] = 1;
                    figura[3, 1] = 5;
                    break;
                case 6://J tip figure
                    for (int i = 0; i < 3; i++)
                    {
                        figura[i, 0] = i;
                        figura[i, 1] = 4;
                    }
                    figura[3, 0] = 2;
                    figura[3, 1] = 3;
                    break;
                   
            }

            
        }

        private void Muzika_Click(object sender, EventArgs e)
        {
            if (muzikaUpaljena == false)
            {
                player.URL = "tetris theme song.mp3";
                muzikaUpaljena = true;
                Muzika.ImageLocation = "ukljucenZvucnik.jpg";
                player.settings.volume = 5 * jacinaZvuka.Value;

                player.controls.play();
            }
            else
            {
                muzikaUpaljena = false;
                Muzika.ImageLocation = "iskljucenZvucnik.jpg";
                player.controls.stop();
            }
        }

        
        
        

      
    }
}
