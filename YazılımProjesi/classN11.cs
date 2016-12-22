using System;
using HtmlAgilityPack;
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
    class classN11 {

        private string siteUrunIsimHtmlTag;
        private string siteUrunParaHtmlTag;
        private string ineHtmlKodlari;


        private List<string> tagdenGelenIsim = new List<string>();
        private List<string> tagdenGelenPara = new List<string>();
        private List<string> toplamVeri = new List<string>();

        public HtmlNodeCollection cekilecekIsim;
        public HtmlNodeCollection cekilecekPara;
        public HtmlNodeCollection sayfaSayisi;

        private HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

        private Uri aranacakSiteurl;
        private WebClient client = new WebClient();// Web istemcisi oluştur

        public classN11(string nesnedenGelenAramaLinki) {
            siteUrunIsimHtmlTag = "//a/h3";                      //Aranan kelime isimleri a/h3 te olduğundan
            siteUrunParaHtmlTag = "//ins[@itemprop='price']";    //Aranan para ins içindeki itemprop = price te olduğundan

            try {
                this.aranacakSiteurl = new Uri(nesnedenGelenAramaLinki); //Bağlanılacak Site
                this.ineHtmlKodlari = this.client.DownloadString(aranacakSiteurl);// html kodları indiriyoruz.

                // html kodlarını bir HtmlDocment nesnesine yüklüyoruz.
                this.document.LoadHtml(ineHtmlKodlari); //Document içerisinde tüm html kodları bulunmaktadır.

                this.cekilecekIsim = document.DocumentNode.SelectNodes(siteUrunIsimHtmlTag);
                this.cekilecekPara = document.DocumentNode.SelectNodes(siteUrunParaHtmlTag);
            } catch (Exception error) {
                MessageBox.Show("Hata : " + error);
            }
        }

        //Türkçe karakter sorunu için dönüşüm yapılıyor.
        public string replaceText(string _text) {
            _text = _text.Replace("Ä°", "İ").Replace("Ä±", "ı").Replace("Ã¼", "ü").Replace("ÅŸ", "ş").Replace("Å", "Ş").Replace("Ã§", "ç").Replace("Ã¶", "ö").Replace("ÄŸ", "ğ").Replace("Ã‡", "Ç").Replace("Ã–", "Ö").Replace("Ãœ", "Ü");
            return _text;
        }

        //Parse ettiğimiz linklerin üzerinde yazan isimler dizi halinde listeye ekleniyor...
        public void isimListesiniSetle() {
            foreach (var cekilenIsmiParcala in cekilecekIsim) {
                tagdenGelenIsim.Add(cekilenIsmiParcala.InnerText);
            }
        }

        //Parse ettiğimiz linklerin üzerinde yazan paralar dizi halinde listeye ekleniyor...
        public void paraListesiniSetle() {
            foreach (var cekilenParayiParcala in cekilecekPara) {
                tagdenGelenPara.Add(cekilenParayiParcala.InnerText);
            }
        }

        //Türkçe karakter sorunu giderilip, tek stringe çekiliyor ve stringlerin başında sonunda boşluk varsa siliniyor
        public void verileriTopla() {
            for (int i = 0; i < this.tagdenGelenPara.Count; i++)
                toplamVeri.Add(replaceText(this.tagdenGelenIsim[i].Trim()) + " --> " + replaceText(this.tagdenGelenPara[i].Trim()));
        }
        //Parse işlemi gerçekleştiriliyor.
        public List<string> parseN11() {
            isimListesiniSetle();
            paraListesiniSetle();
            verileriTopla();
            return toplamVeri;
        }
        public int arananUrunSayfaSayisi() {
            string geciciSayfaNo = "";
            int geciciSayfaNoDonusum;

            this.sayfaSayisi = document.DocumentNode.SelectNodes("//span[@class='pageCount']");
            foreach (var cekilenIsmiParcala in sayfaSayisi) {
                geciciSayfaNo = cekilenIsmiParcala.InnerText;
            }

            geciciSayfaNoDonusum = Convert.ToInt32(geciciSayfaNo);

            return geciciSayfaNoDonusum;
        }

    }
}
