using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;

namespace YazılımProjesi
{
    public class Hepsiburada
    {
        private Stringim stringim;
        private string siteAdi = "HEPSIBURADA";
        private string siteLogo = "http://images.hepsiburada.net/assets/hepsiburada-logo.png";
        private string urunAramaAdresi = "http://www.hepsiburada.com/ara?q=";
        private string aranacakUrun = "";
        private string donenUrunAdi = "";
        private string donenUrunFiyati = "";
        private string donenUrunResimAdresi = "http:";
        private string donenUrunLinki = "";

        private HtmlWeb htmlWeb = new HtmlWeb();
        private HtmlDocument htmlDocument = new HtmlDocument();


        public Hepsiburada()
        {
            stringim = new Stringim(this);
        }

        public Hepsiburada(string aranacakUrun)
        {
            this.aranacakUrun = aranacakUrun;
            stringim = new Stringim(this);
        }

        public Task asenkronArama()
        {
            return Task.Factory.StartNew(() =>
            {
                ara();
                sonucAyikla();
            });
        }
        public void ara()
        {
            stringim.boslukKarakteriniArtiYap();
            stringim.stringBirlestir();
            htmlDocument = htmlWeb.Load(urunAramaAdresi);
        }

        public void sonucAyikla()
        {
 
            //htmlyi her seferinde ayrıstırma bi kere yapsın unutma yap onu gereken kısmı kırp bikere
            HtmlNode urunAdDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='box product no-hover']//img[@class='product-image']").First();
            HtmlNode urunFiyatDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='box product no-hover']//span[@class='price product-price']").First();
            HtmlNode urunResimDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='box product no-hover']//img[@class='product-image']").First();
            HtmlNode urunLinkDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='box product no-hover']//a").First();

            donenUrunAdi = urunAdDugumu.Attributes["alt"].Value.ToString();

            donenUrunFiyati = urunFiyatDugumu.InnerHtml.ToString();
            stringim.virguldenSonraKirp();


            donenUrunResimAdresi += urunResimDugumu.Attributes["src"].Value.ToString();
            donenUrunLinki += urunLinkDugumu.Attributes["href"].Value.ToString();

            stringim.turkceKarakterSorunuDuzelt();
        }

        public string urunAramaAdresiSetGet
        {
            get { return urunAramaAdresi; }
            set { urunAramaAdresi = value; }
        }

        public string aranacakUrunSetGet
        {
            get { return aranacakUrun; }
            set { aranacakUrun = value; }
        }

        public string donenUrunAdiSetGet
        {
            get { return donenUrunAdi; }
            set { donenUrunAdi = value; }
        }

        public string donenUrunFiyatiSetGet
        {
            get { return donenUrunFiyati; }
            set { donenUrunFiyati = value; }
        }

        public string donenUrunResimAdresiSetGet
        {
            get { return donenUrunResimAdresi; }
            set { donenUrunResimAdresi = value; }
        }

        public string donenUrunLinkAdresiSetGet
        {
            get { return donenUrunLinki; }
            set { donenUrunLinki = value; }
        }

        public string siteAdiSetGet
        {
            get { return siteAdi; }
            set { siteAdi = value; }
        }

        public string siteLogoSetGet
        {
            get { return siteLogo; }
            set { siteLogo = value; }
        }
    }
}
