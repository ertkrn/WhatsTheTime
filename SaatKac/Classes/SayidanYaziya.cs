using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SaatKac.Classes
{
    public class SayidanYaziya
    {
        public string rakamlar(int i)
        {
            switch (i)
            {
                case 0 :
                    return "sıfır";
                case 1 :
                    return "bir";
                case 2:
                    return "iki";
                case 3:
                    return "üç";
                case 4:
                    return "dört";
                case 5:
                    return "beş";
                case 6:
                    return "altı";
                case 7:
                    return "yedi";
                case 8:
                    return "sekiz";
                case 9:
                    return "dokuz";
                default:
                    return "on";
            }
        }
        public string ondalik(int i)
        {
            switch (i)
            {
                case 1:
                    return "on";
                case 2:
                    return "yirmi";
                case 3:
                    return "otuz";
                case 4:
                    return "kırk";
                case 5:
                    return "elli";
                case 6:
                    return "altmış";
                case 7:
                    return "yetmiş";
                case 8:
                    return "seksen";
                case 9:
                    return "doksan";
                default:
                    return "sıfır";
            }
        }
        public string ihaleki(string i)
        {
            if (i == "mi" || i == "ki" || i == "li" || i == "di")
            {
                return "yi";
            }
            else if (i == "tı")
            {
                return "yı";
            }
            else if (i == "an" || i == "ış" || i == "uz" || i == "ır" || i == "rk" || i == "on")
            {
                return "ı";
            }
            //else if(i == "en" || i == "iş" || i == "iz" || i == "ir" || i == "rt")
            else
            {
                return "i";
            }
        }
        public string ehaleki(string i)
        {
            if (i == "mi" || i == "ki" || i == "li" || i == "di")
            {
                return "ye";
            }
            else if (i == "tı")
            {
                return "ya";
            }
            else if (i == "an" || i == "ış" || i == "uz" || i == "ır" || i == "rk" || i == "on")
            {
                return "a";
            }
            //else if (i == "en" || i == "iş" || i == "iz" || i == "ir" || i == "rt")
            else
            {
                return "e";
            }
        }
        public string esonikiharf(string yazi)
        {
            var ikili = yazi.Substring(yazi.Length - 2);
            return ehaleki(ikili);
        }
        public string isonikiharf(string yazi)
        {
            var ikili = yazi.Substring(yazi.Length - 2);
            return ihaleki(ikili);
        }
        public string cevir(int deger)
        {
            StringBuilder yazi = new StringBuilder();
            if (deger > 10)
            {
                yazi.Append(ondalik(deger / 10));
                if (deger % 10 != 0)
                {
                    yazi.Append(rakamlar(deger % 10));
                }
            }
            else
            {
                yazi.Append(rakamlar(deger));
            }
            return yazi.ToString();
        }
    }
}