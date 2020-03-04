using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneticAl
{
    public class Mutation
    {
        Random ran = new Random();
        static int limit_Chroms = 10;
        static int bit_digit = 4;
        string[] mutation = new string[limit_Chroms];
        double[] r_mu = new double[bit_digit];

        public Mutation(string[] mu)
        {
            mutation = mu;
        }

        public string getR()             // สุ่มค่า r ห้าค่า
        {
            string r = "";

            for (int i = 0; i < bit_digit; i++)
            {
                r_mu[i] = ran.NextDouble();

                if (i != 0)
                {
                    r += " | ";
                }
                r += r_mu[i].ToString("0.0000");
            }

            return r;
        }

        public string getMutation(double muRate, int index)
        {
            string mutation = "";
            char[] chroms = this.mutation[index].ToCharArray();

            for (int j = 0; j < bit_digit; j++)
            {
                if (r_mu[j] < muRate)
                {
                    if (chroms[j] == '1')
                    {
                        chroms[j] = '0';
                    }
                    else if (chroms[j] == '0')
                    {
                        chroms[j] = '1';
                    }
                }
                mutation += chroms[j];
            }
            return mutation;
        }

        public int getF(string f)
        {
            string str_muF = Convert.ToString(Convert.ToInt32(f, 2), 10);
            int mu_f = (15 * Convert.ToInt32(str_muF)) - (Convert.ToInt32(str_muF) * Convert.ToInt32(str_muF));
            return mu_f;
        }

    }
}