using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe7_Kittinger_20210310
{
    class Spieler
    {
        private int spielerID;
        private string name;
        private int alter;
        private char geschlecht;

        public Spieler(string name, int alter, char geschlecht)
        {
            this.spielerID = SpielerSammlung.getNaechsteID;
            this.name = name;
            this.alter = alter;
            this.geschlecht = geschlecht;
        }

        public int getSpielerID
        {
            get { return spielerID; }
        }

        public string getName
        {
            get { return name; }
        }

        public int getAlter
        {
            get { return alter; }
        }

        public char getGeschlecht
        {
            get { return geschlecht; }
        }

    }
}
