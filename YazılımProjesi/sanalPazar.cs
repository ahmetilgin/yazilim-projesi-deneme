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
using System.IO;
public class sanalPazar
{

    private string siteAdi = "N11";
    private string siteLogo = "http://cdn1.n11.com.tr/a1/org/15/11/30/54/12/08/66/82/53/32/07/07/87650256438692757713.png";
    private string urunAramaAdresi = "http://www.n11.com/arama?q=";
    private string aranacakUrun = "";
    private string donenUrunAdi = "";
    private string donenUrunFiyati = "";
    private string donenUrunResimAdresi = "http:";
    private string donenUrunLinki = "";

 
    public List<string> hepsiBuradaSitesiUzerindeAramaYap(string aranacakSiteLinki)
    {

        //Bağlanılacak Site
        Uri url = new Uri(aranacakSiteLinki);
        // Web istemcisi oluştur
        System.Net.WebClient client = new WebClient();


        // html kodları indiriyoruz.
        string html = client.DownloadString(url);


        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
        // html kodlarını bir HtmlDocment nesnesine yüklüyoruz.

        //Document içerisinde tüm html kodları bulunmaktadır.


        document.LoadHtml(html);

        HtmlNodeCollection cekilecekTag1 = document.DocumentNode.SelectNodes("//a[@class='sp-font-14-b-black']");
        List<string> tagdenGelenVeriler = new List<string>();

        foreach (var baslik in cekilecekTag1)
        {
            tagdenGelenVeriler.Add(baslik.InnerText);
            //Parse ettiğimiz linklerin üzerinde yazan yazılar dizi halinde listeye ekleniyor...
        }

        return tagdenGelenVeriler;

    }
}
