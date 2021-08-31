using System;


namespace oyun
{
    class Program
    {
        public static bool gecerlikart = false;
        public static bool pcoyun = false;
        public static string kartim, son = "yok";
        public static int turDurum = 0,ilkoyuncu = 0,baslangic=1;
        static void Main(string[]args)
        {
            Random r = new Random();
            string[] kartlar = { "k1", "k2", "k3", "k4", "k5", "m1", "m2", "m3", "m4", "m5", "s1", "s2", "s3", "s4", "s5", "rd", "rd", "rd" };
            string[] oyuncu1 = new string[6];
            string[] oyuncu2 = new string[6];
            string[] oyuncu3 = new string[6];
            int a = 0, b = 0, c = 0, tur = 1;
            while (true)
            {
                if (a < 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int deste = r.Next(0, 18);
                        if (kartlar[deste] != "bos")
                        {
                            oyuncu1[a] = kartlar[deste];
                            kartlar[deste] = "bos";
                            a++;
                        }
                        else
                        {
                            i--;
                        }
                    }
                }
                else if (b < 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int deste = r.Next(0, 18);
                        if (kartlar[deste] != "bos")
                        {
                            oyuncu2[b] = kartlar[deste];
                            kartlar[deste] = "bos";
                            b++;
                        }
                        else
                        {
                            i--;
                        }
                    }
                }

                else if (c < 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int deste = r.Next(0, 18);
                        if (kartlar[deste] != "bos")
                        {
                            oyuncu3[c] = kartlar[deste];
                            kartlar[deste] = "bos";
                            c++;
                        }
                        else
                        {
                            i--;
                        }
                    }

                }
                else
                {
                    break;
                }
            }
            bool kartiste = true;
            Console.WriteLine("Desteniz:");
            
            foreach (var item in oyuncu1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(" ");
            Console.Write("1.Tur");
            while (kartiste==true)
            {
               if(baslangic==1)
                {
                    Console.WriteLine(" ");
                    destem(oyuncu1);
                    Console.WriteLine(" ");
                    Console.Write("-Kartınızı Atınız=");
                    kartim = Console.ReadLine();
                    if((kartim == "pas" || kartim == "rd") && turDurum <= 0)
                    {
                        Console.WriteLine("1. turda pas ve renk degistir kartini kullanamazsiniz!!!");
                        pcoyun = false;
                    }
                    else if(kartim=="pas")
                    {
                        pcoyun = true;
                        Console.WriteLine("pas verdiniz kart :" + son);
                    }
                    else if(kartim=="rd")
                    {
                        int rdyer = 0;
                        bool rdvaryok = false;
                        for(int rd=0;rd<6;rd++)
                        {
                            if (oyuncu1[rd] == "rd")
                            {
                                rdyer = rd;
                                rdvaryok = true;
                            }
                        }
                        if(rdvaryok == true)
                        {
                            while(true)
                            {
                                Console.Write("Lutfen Renk Belirleyiniz");
                                string yenirenk = Console.ReadLine();
                                if(yenirenk == "m")
                                {
                                    son = "m" + son.Substring(1, 1);
                                    Console.WriteLine("Mevcut Kart :" + son);
                                    oyuncu1[rdyer] = "yok";
                                    pcoyun = true;
                                    break;
                                }
                                else if(yenirenk=="k")
                                {
                                    son = "k" + son.Substring(1, 1);
                                    Console.WriteLine("Mevcut Kart :" + son);
                                    oyuncu1[rdyer] = "yok";
                                    pcoyun = true;
                                    break;
                                 }
                                else if(yenirenk=="s")
                                {
                                    son = "s" + son.Substring(1, 1);
                                    Console.WriteLine("Mevcut Kart :" + son);
                                    oyuncu1[rdyer] = "yok";
                                    pcoyun = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Yanlıs Renk Girdiniz");
                                    pcoyun = false;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Destenizde rd kartı bulunmamaktadır" + "yerdeki kart:"+son);
                            pcoyun = false;

                        }
                    }
                    else
                    {
                        if(turDurum>0)
                        {
                            for(int j=0;j<6;j++)
                            {
                                if(oyuncu1[j]==kartim)
                                {
                                    if(oyuncu1[j].Substring(0,1) == son.Substring(0,1) || oyuncu1[j].Substring(1,1) == son.Substring(1,1))
                                    {
                                        turDurum++;
                                        son = kartim;
                                        oyuncu1[j] = "yok";
                                        pcoyun = true;
                                        break;
                                    }
                                }
                            }
                            if(pcoyun==false)
                            {
                                Console.WriteLine("Destede olmayan veya uygunsuz bir kart attınız" + "yerdeki kart=" + son);
                                pcoyun = false;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 6; j++)
                            {

                                if (oyuncu1[j] == kartim)
                                {
                                    turDurum++;

                                    son = kartim;
                                    oyuncu1[j] = "yok";
                                    pcoyun = true;
                                    break;
                                }
                            }
                        }
                    }
                    bool kontrol = false;
                    kontrol = Bitis(oyuncu1);
                    if (kontrol == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Oyun Bitti kazanan SEN");
                        kalan(oyuncu1, oyuncu2, oyuncu3);
                        break;
                    }
                    if (pcoyun == true)
                    {
                        bilgisayaroyna(oyuncu2, "OYUNCU 2");
                        bool kontrol2 = false;
                        kontrol2 = Bitis(oyuncu2);
                        if (kontrol2 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Oyun Bitti kazanan 2.Oyuncu");
                            kalan(oyuncu1, oyuncu2, oyuncu3);
                            break;
                        }
                        bilgisayaroyna(oyuncu3, "OYUNCU 3");
                        bool kontrol3 = false;
                        kontrol3 = Bitis(oyuncu3);
                        if (kontrol3 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Oyun Bitti Kazanan 3.Oyuncu");
                            kalan(oyuncu1, oyuncu2, oyuncu3);
                            break;
                        }
                        pcoyun = false;
                        Console.WriteLine();
                        tur++;
                        Console.WriteLine((tur) + ".Tur");
                    }

                }

            }



        }
        public static void destem(string[] kart)
        {
            foreach (var item in kart)
            {
                Console.Write(item + " ");
            }
        }
        public static void kalan(string[] o1, string[] o2, string[] o3)
        {
            Console.WriteLine();
            Console.WriteLine("Senin kartların");
            foreach (var item in o1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2.Oyuncunun kartları");
            foreach (var item in o2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3.Oyuncunun kartları");
            foreach (var item in o3)
            {
                Console.Write(item + " ");
            }

        }
        public static bool Bitis(string[] kartDurum)
        {
            bool Bitti = false;
            int kartSayisi = 0;
            for (int i = 0; i < 6; i++)
            {
                if (kartDurum[i] == "yok")
                {
                    kartSayisi++;
                }
            }
            if (kartSayisi >= 6)
            {
                Bitti = true;
            }
            return Bitti;
        }
        public static void bilgisayaroyna(string[] pcKartlar, string pcOyuncu)
        {
            bool pcUygunKart = false, rdVarMi = false;
            int rdIndis = 0;
            if (son == "yok")
            {
                for (int i = 0; i < 6; i++)
                {
                    if (pcKartlar[i] != "rd")
                    {
                        Console.WriteLine(pcOyuncu + " " + pcKartlar[i]);
                        son = pcKartlar[i];
                        pcKartlar[i] = "yok";
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (pcKartlar[i].Substring(0, 1) == son.Substring(0, 1) || pcKartlar[i].Substring(1, 1) == son.Substring(1, 1))
                    {
                        pcUygunKart = true;
                        Console.WriteLine(pcOyuncu + " " + pcKartlar[i]);
                        son = pcKartlar[i];
                        pcKartlar[i] = "yok";
                        break;
                    }
                }
                if (pcUygunKart == false)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (pcKartlar[i] == "rd")
                        {
                            rdIndis = i;
                            rdVarMi = true;
                            break;
                        }
                    }

                    if (rdVarMi == true)
                    {
                        bool eldeRenkliKartYok = false;
                        for (int i = 0; i < 6; i++)
                        {
                            if (pcKartlar[i].Substring(0, 1) == "k")
                            {
                                son = "k" + son.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni kartı " + son + " yaptı");
                                pcKartlar[rdIndis] = "yok";
                                eldeRenkliKartYok = true;
                                break;
                            }
                            else if (pcKartlar[i].Substring(0, 1) == "m")
                            {
                                son = "m" + son.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni kartı " + son + " yaptı");
                                pcKartlar[rdIndis] = "yok";
                                eldeRenkliKartYok = true;
                                break;
                            }
                            else if (pcKartlar[i].Substring(0, 1) == "s")
                            {
                                son = "s" + son.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni kartı " + son + " yaptı");
                                pcKartlar[rdIndis] = "yok";
                                eldeRenkliKartYok = true;
                                break;
                            }
                        }
                        if (eldeRenkliKartYok == false)
                        {
                            Random r = new Random();
                            int renkUret = r.Next(0, 3);
                            if (renkUret == 0)
                            {
                                son = "m" + son.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni rengi " + son + " yaptı");

                            }
                            else if (renkUret == 1)
                            {
                                son = "k" + son.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni rengi " + son + " yaptı");

                            }
                            else if (renkUret == 2)
                            {
                                son = "s" + son.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni rengi " + son + " yaptı");

                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine(pcOyuncu + " Pas verdi " + son);
                    }

                }
            }

        }
        public static void kalanKartlar(string[] kart1, string[] kart2, string[] kart3)
        {
            Console.WriteLine();
            Console.WriteLine("Senin kartların");
            foreach (var item in kart1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2.Oyuncu kartları");
            foreach (var item in kart2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3.Oyuncu kartları");
            foreach (var item in kart3)
            {
                Console.Write(item + " ");
            }

        }






    }
    
}
 

