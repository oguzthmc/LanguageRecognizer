/**   
 * @file  		Program.cs
 * @description L=(aab)*(a+aba)* regüler ifadesiyle sunulan dil için bir dil tanıyıcı program yazma
 * @course  	Biçimsel Diller ve Soyut Makineler
 * @assignment  01
 * @date  		28.11.2019
 * @authors  	Oguzhan Tohumcu	oguzhan.tohumcu@ogr.sakarya.edu.tr
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageRecognizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //No parameter contructor ile dil tanıyıcı örneği oluşturalım
            RegExControl lr = new RegExControl();

            //Örnek üzerinden sonucu yazdırma metodunu çağıralım
            lr.PrintResult();

            //Konsol ekranını bekletme
            Console.ReadLine();
        }
    }
}
