using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneticAl
{
    public class Crossover
    {
        Random ran = new Random();
        int bit_digit = 4;
        int f1, f2;
        int[] r_qi = new int[limit_Chroms];
        static int limit_Chroms = 10;
        string[] cross = new string[2];
        string[] mating_pool = new string[limit_Chroms];
        double[] r = new double[limit_Chroms / 2];
        
        public Crossover(string[] chroms, int[] r_qi)
        {
            this.r_qi = r_qi;
            setMatingPool(chroms, r_qi);
        }

        private void setMatingPool(string[] chroms, int[] r) 
        {
            for (int i = 0; i < limit_Chroms; i++)
            {
                int index = r[i];
                mating_pool[i] = chroms[index];
            }
        }

        public void setF(int x1, int x2)
        {
            f1 = (15 * x1) - (x1 * x1);
            f2 = (15 * x2) - (x2 * x2);
        }

        public int[] getRqi()              //ลำดับที่คัดเลือก
        {
            return r_qi;
        }

        public string[] getMatingPool()    // โคโมโซมที่ถูกเลือก
        {
            return mating_pool;
        }

        public double[] getR()             // คืนค่า r ที่สุ่ม            
        {
            for (int i = 0; i < limit_Chroms / 2; i++)
            {
                r[i] = ran.NextDouble();

            }
            return r;
        }

        public string[] getCross(string[] cross, int pos) // Crossover
        {
            this.cross[0] = cross[0].Substring(0, pos).ToString() + cross[1].Substring(pos, bit_digit - pos);
            this.cross[1] = cross[1].Substring(0, pos).ToString() + cross[0].Substring(pos, bit_digit - pos);

            return this.cross;
        }

        public int getF1()
        {
            return f1;
        }

        public int getF2()
        {
            return f2;
        }

    }
}