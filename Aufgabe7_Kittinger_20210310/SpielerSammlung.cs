using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Aufgabe7_Kittinger_20210310
{
    class SpielerSammlung
    {
        private List<Spieler> spielerSammlung = new List<Spieler>();
        private static int naechsteID = 1000;

        public SpielerSammlung()
        {
            ladeAusDatei();
        }
        public Spieler this[int index]
        {
            get { return spielerSammlung[index]; }
            set
            {
                if(spielerSammlung[index] == null)
                {
                    spielerSammlung[index] = value;
                }
                else
                {
                    for (int i = 0; i < 100; i++)
                    {
                        if (spielerSammlung[index] == null)
                        {
                            spielerSammlung[index] = value;
                            return;
                        }
                    }
                }
            }
        }
        public static int getNaechsteID
        {
            get 
            {
                naechsteID++;
                return naechsteID - 1 ;
            }
        }
        public int Count { get { return spielerSammlung.Count; } }
        public void Add(Spieler wert)
        {
           spielerSammlung.Add(wert);
           speichereInDatei(wert);
        }

        private void ladeAusDatei()
        {
            StreamReader leser = new StreamReader("Spieler.txt");
            string zeile;        
            while (leser.EndOfStream == false)
            {
                zeile = leser.ReadLine();
                string[] zeilenelemente = zeile.Split(';');
                if(zeile != null)
                {
                    spielerSammlung.Add(new Spieler(zeilenelemente[0], int.Parse(zeilenelemente[1]), char.Parse(zeilenelemente[2])));
                }
            }
            leser.Close();
        }
        private void speichereInDatei(Spieler spieler)
        {
            StreamWriter schreiber = new StreamWriter("Spieler.txt", true);
            schreiber.WriteLine(spieler.getName + ";" + spieler.getAlter + ";" + spieler.getGeschlecht);
            schreiber.Close();
        }

    }
}
