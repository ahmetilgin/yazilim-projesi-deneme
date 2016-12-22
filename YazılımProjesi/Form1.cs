using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YazılımProjesi {
    public partial class Form1 : MetroFramework.Forms.MetroForm {
        public Form1() {
            InitializeComponent();
        }

        Hepsiburada hb;
        double[] siraliFiyatDizi;
        string[] siraliSiteDizisi;



        private Task hepsiburadaAsenkronArama()
        {
            return Task.Factory.StartNew(() =>
            {
                hb.ara();
                hb.sonucAyikla();
            });
        }

        public void fiyataGoreSirala()
        {
            double[] fiyatDizisi = { Convert.ToDouble(hb.donenUrunFiyatiSetGet),2};
            string[] siteDizisi = { hb.siteAdiSetGet};

            for(int i=0;i<siteDizisi.Length;i++)
                for (int j = 0; j < siteDizisi.Length-i; j++)
                {
                    if (fiyatDizisi[j] < fiyatDizisi[j + 1])
                    {
                        double tempFiyat = fiyatDizisi[j];
                        string tempSite = siteDizisi[j];

                        fiyatDizisi[j] = fiyatDizisi[j + 1];
                        fiyatDizisi[j + 1] = tempFiyat;

                        siteDizisi[j] = siteDizisi[j + 1];
                        siteDizisi[j + 1] = tempSite;


                    }
                }          

            siraliFiyatDizi = fiyatDizisi;
            siraliSiteDizisi = siteDizisi;
        }

        public void siraliGoster()
        {
            for (int i = 0; i < siraliSiteDizisi.Length; i++)
            {
                if (siraliSiteDizisi[i].Equals("HEPSIBURADA")){
                    urunListesi.Items.Add(hb.donenUrunAdiSetGet);
                    if (i == 0)
                    {
                        pictureBox2.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 1)
                    {
                        pictureBox3.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 2)
                    {
                        pictureBox4.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 3)
                    {
                        pictureBox4.ImageLocation = hb.siteLogoSetGet;
                    }

                }
                 
                else if (siraliSiteDizisi[i].Equals("N11")){
                    urunListesi.Items.Add(hb.donenUrunAdiSetGet);
                    if (i == 0)
                    {
                        pictureBox2.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 1)
                    {
                        pictureBox3.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 2)
                    {
                        pictureBox4.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 3)
                    {
                        pictureBox4.ImageLocation = hb.siteLogoSetGet;
                    }
                }
                    
                else if (siraliSiteDizisi[i].Equals("SANALPAZAR")){
                    urunListesi.Items.Add(hb.donenUrunAdiSetGet);
                    if (i == 0)
                    {
                        pictureBox2.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 1)
                    {
                        pictureBox3.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 2)
                    {
                        pictureBox4.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 3)
                    {
                        pictureBox4.ImageLocation = hb.siteLogoSetGet;
                    }

                }

                else if (siraliSiteDizisi[i].Equals("WEBDENAL"))
                {
                    urunListesi.Items.Add(hb.donenUrunAdiSetGet);
                    if (i == 0)
                    {
                        pictureBox2.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 1)
                    {
                        pictureBox3.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 2)
                    {
                        pictureBox4.ImageLocation = hb.siteLogoSetGet;
                    }

                    else if (i == 3)
                    {
                        pictureBox4.ImageLocation = hb.siteLogoSetGet;
                    }
                }


                   

            }




        }

        public void linkResimFiyatGuncelle(int secilenUrununIndeksNumarası)
        {
            if (secilenUrununIndeksNumarası==-1)
                return;

            if (siraliSiteDizisi[secilenUrununIndeksNumarası].Equals("HEPSIBURADA")){

                metroLabel2.Text = hb.donenUrunFiyatiSetGet + "TL";
                pictureBox1.ImageLocation = hb.donenUrunResimAdresiSetGet;
                linkLabel1.Links.Clear();
                linkLabel1.Links.Add(6, 4, hb.donenUrunLinkAdresiSetGet);

            }
                
            else if (siraliSiteDizisi[secilenUrununIndeksNumarası].Equals("N11")){

                metroLabel2.Text = hb.donenUrunFiyatiSetGet + "TL";
                pictureBox1.ImageLocation = hb.donenUrunResimAdresiSetGet;
                linkLabel1.Links.Clear();
                linkLabel1.Links.Add(6, 4, hb.donenUrunLinkAdresiSetGet);



            }
                
            else if (siraliSiteDizisi[secilenUrununIndeksNumarası].Equals("SANALPAZAR")){

                metroLabel2.Text = hb.donenUrunFiyatiSetGet + "TL";
                pictureBox1.ImageLocation = hb.donenUrunResimAdresiSetGet;
                linkLabel1.Links.Clear();
                linkLabel1.Links.Add(6, 4, hb.donenUrunLinkAdresiSetGet);

            }
               
            else if (siraliSiteDizisi[secilenUrununIndeksNumarası].Equals("WEBDENAL")){

                metroLabel2.Text = hb.donenUrunFiyatiSetGet + "TL";
                pictureBox1.ImageLocation = hb.donenUrunResimAdresiSetGet;
                linkLabel1.Links.Clear();
                linkLabel1.Links.Add(6, 4, hb.donenUrunLinkAdresiSetGet);

            }
              

        }

        void formTemizle()
        {
            urunListesi.Items.Clear();
            linkLabel1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hb = new Hepsiburada();

        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {
            formTemizle();
            hb.aranacakUrunSetGet = arama.Text;
            metroProgressSpinner1.Visible = true;
            await hepsiburadaAsenkronArama();
            metroProgressSpinner1.Visible = false;
            linkLabel1.Visible = true;
            fiyataGoreSirala();
            siraliGoster();


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void urunListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkResimFiyatGuncelle(urunListesi.SelectedIndex);
        }


    }
}
