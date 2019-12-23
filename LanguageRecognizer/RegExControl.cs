/**   
 * @file  		LanguageRecognizer.cs
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
    class RegExControl
    {
        public RegExControl() { }     //No parameter constructor

        private string testString;          //regüler ifade katarı

        //Parametreli constructor yazılmadı. Çünkü kullanıcı girişi konsoldan yapılmıştır.

        //Konsoldan girdi alan metot
        private void ReadRegularExpression()
        {
            Console.Write("\nEnter a string containing only a and b (press e or E to exit) : ");
            testString = Console.ReadLine();
        }

        //Girilen regüler ifadeyi kontrol eden metot
        private bool CheckRegularExpression()
        {
            bool isValid = false;
            string state = "q0";

            //E veya e katarı girilmesi halinde programdan çıkılır.
            if (testString == "E" || testString == "e")
            {
                Environment.Exit(0);
            }
            //Boş katar girişi kontrolü
            else if (string.IsNullOrEmpty(testString))
            {
                isValid = true;
            }
            else
            {
                for (int i = 0; i < testString.Length; i++)
                {
                    //a, b karakterlerinden farklı bir karakter ise dile uymadığı için hata fırlattım.
                    if (testString[i] != 'a' && testString[i] != 'b')
                    {
                        throw new ArgumentOutOfRangeException(testString, "The regular expression must be a and b characters or empty string!!");
                    }
                    else
                    {
                        //başlangıç durumu
                        if (state == "q0")
                        {
                            //kabul durumu
                            if (testString[i] == 'a')
                            {
                                state = "q1";       //bir sonraki duruma geç
                                isValid = true;     //ifade geçerli
                            }
                            //ölü durum (b)
                            else
                            {
                                state = "q4";       //ölü duruma git
                                isValid = false;    //ifade geçerli değil
                            }
                        }
                        //1. durum
                        else if (state == "q1")
                        {
                            //kabul durumu
                            if (testString[i] == 'a')
                            {
                                state = "q2";       //bir sonraki duruma geç
                                isValid = true;
                            }
                            //red durumu (b)
                            else
                            {
                                state = "q3";
                                isValid = false;    //reddet
                            }
                        }
                        //2. durum
                        else if (state == "q2")
                        {
                            //kabul durumu
                            if (testString[i] == 'a')
                            {
                                state = "q2";       //kendisine gitsin
                                isValid = true;
                            }
                            //b gelmesi durumu
                            else
                            {
                                state = "q0";      //başlangıç durumuna git
                                isValid = true;
                            }
                        }
                        //3. durum
                        else if (state == "q3")
                        {
                            //kabul durumu
                            if (testString[i] == 'a')
                            {
                                state = "q0";       //başlangıç durumuna git
                                isValid = true;     //ifadeyi kabul et
                            }
                            //b gelmesi durumu
                            else
                            {
                                state = "q4";       //ölü duruma git
                                isValid = false;    //ifadeyi kabul etme
                            }
                        }
                        //Ölü durum
                        //Ölü durumda hiçbir ifade kabul edilmez ve a, b geldiğinde kendisine döner.
                        else if (state == "q4")
                        {
                            if (testString[i] == 'a')
                            {
                                state = "q4";
                                isValid = false;
                            }
                            //b gelmesi durumu
                            else
                            {
                                state = "q4";
                                isValid = false;
                            }
                        }
                        //5 durumdan başka bir durum olamayacağı için hata fırlattım.
                        else
                        {
                            throw new InvalidOperationException("The states consist of q0, q1, q2, q3 and q4!");
                        }
                    }
                }
            }

            return isValid;
        }

        //Sonucun yazdırıldığı metot
        public void PrintResult()
        {
            //Karşılama ekranı
            Console.WriteLine("\t\t----------------------------------------------");
            Console.WriteLine("\t\t|\t\t\t\t\t     |");
            Console.WriteLine("\t\t| LANGUAGE RECOGNIZER for REGULAR EXPRESSION |");
            Console.WriteLine("\t\t|\t\t\t\t\t     |");
            Console.WriteLine("\t\t----------------------------------------------");

            //Çıkış yapılmadığı (E veya e'ye basılmadığı) sürece regüler ifade girişi alınır.
            do
            {
                //Fırlatılan exceptionlar yakalanarak, gereken hata mesajları ekrana yazdırılır.
                try
                {
                    ReadRegularExpression();
                    bool control = CheckRegularExpression();

                    if (control == true)
                    {
                        Console.WriteLine("{0} is valid expression.", testString);
                    }
                    else
                    {
                        Console.WriteLine("{0} is not invalid expression!!!", testString);
                    }
                }
                catch (ArgumentOutOfRangeException outOfRange)
                {
                    Console.WriteLine("Error : {0}", outOfRange.Message);
                }
                catch (InvalidOperationException invalidOp)
                {
                    Console.WriteLine("Error: {0}", invalidOp.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            } while (true);
        }
    }
}
