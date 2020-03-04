using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneticAl
{
    public class Chromosome
    {
        Random ran = new Random();
        static int limit_Chroms = 10;
        int bit_digit = 4, bin_max = 15;
        int[] chromse_dec = new int[limit_Chroms];
        string[] chromse_bin = new string[limit_Chroms];
        int[] finess = new int[limit_Chroms];
        int[] r_qi = new int[limit_Chroms + 1];
        double finess_total = 0;
        double[] pselect = new double[limit_Chroms];
        double[] expected = new double[limit_Chroms];
        double[] qi = new double[limit_Chroms];
        double qi_total = 0;
        double[] r = new double[limit_Chroms];
        
        public void randomNum()
        {
            for (int i = 0; i < limit_Chroms; i++)
            {
                chromse_dec[i] = ran.Next(0, bin_max);
            }
        }

        public string[] createChroms(int[] c) // สร้างโคโมโซม
        {
            for (int i = 0; i < limit_Chroms; i++)
            {
                string bit = Convert.ToString(Convert.ToInt32(c[i].ToString(), 10), 2);
                bit = bit.PadLeft(bit_digit, '0');
                chromse_bin[i] = bit;

            }
            return chromse_bin;
        }

        public void totalFiness() // ค่าความเหมาะสมทั้ใหมด
        {
            for (int i = 0; i < limit_Chroms; i++)
            {
                finess_total += finess[i];
            }
        }

        public double[] getR() // สุ่มค่า r (0.0 - 1.0) และเลือกลำดับโคโมโซม
        {
            for (int i = 0; i < limit_Chroms; i++)
            {
                r[i] = ran.NextDouble();
                if (r[i] < qi[i])
                {
                    r_qi[i] = i;
                }
                else
                {
                    r_qi[i] = ran.Next(0, limit_Chroms - 1);
                }
            }
            return r;
        }

        public int[] getRqi() // คืนค่าลำดับที่เลือก
        {
            return r_qi;
        }

        public int[] getX()
        {
            return chromse_dec;
        }

        public int[] getFiness(int[] c)
        {
            for (int i = 0; i < limit_Chroms; i++)
            {
                finess[i] = (15 * c[i]) - (c[i] * c[i]); // ค่าความดหมาะสม y=15x-x^2
            }
            return finess;
        }

        public double[] getPselect()
        {
            for (int i = 0; i < limit_Chroms; i++)
            {
                pselect[i] = finess[i] / finess_total; // เก็บความน่าจะเป็น
                expected[i] = pselect[i] * limit_Chroms; // จำนวนที่คาดหวัง
            }
            return pselect;
        }

        public double[] getQi() // ความถี่สะสมความน่าจะเป็น
        {
            qi_total = 0;
            for (int i = 0; i < limit_Chroms; i++)
            {

                qi_total += pselect[i];
                qi[i] = qi_total;

            }
            return qi;
        }

        public double[] getExpected() // จำนวนที่คาดหวัง
        {
            return expected;
        }

    }
}