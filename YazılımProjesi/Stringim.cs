using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazılımProjesi
{
    public class Stringim
    {
        Hepsiburada hb;

        public Stringim(Hepsiburada hb)
        {
            this.hb = hb;
        }

        public void boslukKarakteriniArtiYap()
        {
            hb.aranacakUrunSetGet = hb.aranacakUrunSetGet.Replace(" ", "+");
        }

        public void stringBirlestir()
        {
            hb.urunAramaAdresiSetGet += hb.aranacakUrunSetGet;
        }

        public void turkceKarakterSorunuDuzelt()
        {
            hb.donenUrunAdiSetGet = hb.donenUrunAdiSetGet.Replace("#231;", "ç").Replace("#199;", "Ç").Replace("#252;", "ü").Replace("#220;", "Ü").Replace("#246;", "ö").Replace("#214;", "Ö");
        }

        public void virguldenSonraKirp()
        {
            hb.donenUrunFiyatiSetGet = hb.donenUrunFiyatiSetGet.Substring(0, hb.donenUrunFiyatiSetGet.IndexOf(","));
        }
    }
}
