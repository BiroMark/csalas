using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celloveszetCLI
{
    public class Cellovo
    {
        public Cellovo(string sor)//3-4. feladat
        {
            string[] temp = sor.Split(';');
            Nev = temp[0];//.Split(' ')[1];
            EsloLoves = int.Parse(temp[1]);
            MasodikLoves = int.Parse(temp[2]);
            HarmadikLoves = int.Parse(temp[3]);
            NegyedikLoves = int.Parse(temp[4]);
        }

        //név,első lövés, második lövés, harmadik lövés, negyedik lövés,
        public string Nev { get;private set; }//2. feladat
        public int EsloLoves { get;private set; }
        public int MasodikLoves { get; private set; }
        public int HarmadikLoves { get; private set; }
        public int NegyedikLoves { get; private set; }
        
        //Osztályfg.
        public int Legnagyobb()
        {
            int[] lovesek = { EsloLoves, MasodikLoves, HarmadikLoves, NegyedikLoves };
            return lovesek.Max();//Array.IndexOf(lovesek, lovesek.Max())+1;
        }
        public int LegnagyobbIndex()
        {
            int[] lovesek = { EsloLoves, MasodikLoves, HarmadikLoves, NegyedikLoves };
            return Array.IndexOf(lovesek, lovesek.Max())+1;
        }
    }
}
