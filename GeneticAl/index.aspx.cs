using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneticAl
{
    public partial class index : System.Web.UI.Page
    {

        Chromosome chromosome = new Chromosome();
        Random ran = new Random();

        List<int> genChromse = new List<int>();
        List<int> max_f = new List<int>();
        List<TableCell> tb1Cell = new List<TableCell>();
        List<TableCell> tb2Cell = new List<TableCell>();
        List<TableCell> tb3Cell = new List<TableCell>();


        char dbcod = '"';
        double per;
        double gen;
        double loop;
        int pos;
        int f1, f2;
        int[] finess = new int[limit_Chroms];
        int[] r_qi = new int[limit_Chroms];
        int[] r_qi2 = new int[limit_Chroms];
        int[] mu_f = new int[limit_Chroms];
        int[] chromse_dec = new int[limit_Chroms];
        double[] qi = new double[limit_Chroms];
        double[] r = new double[limit_Chroms];
        double[] pselect = new double[limit_Chroms];
        double[] expected = new double[limit_Chroms];    
        static int limit_Chroms = 10;
        string x1, x2;
        string[] chromse_bin = new string[limit_Chroms];       
        string[] befor_cross = new string[2];
        string[] after_cross = new string[2];
        string[] mating_pool = new string[limit_Chroms];
        string[] befor_mu = new string[limit_Chroms];
        string[] after_mu = new string[limit_Chroms];  
        bool cross;
        bool start;

        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            genChromse.Clear();
            max_f.Clear();

           
            per = double.Parse(Session["per"].ToString());
            process.Attributes["style"] = "width: " + per + "%;";
            lbl_process.Text = string.Format("{0:0.0}", per)+"%";

            Table1.Rows.Clear();
            Table2.Rows.Clear();
            Table3.Rows.Clear();
            tb1Cell.Clear();
            tb2Cell.Clear();
            tb3Cell.Clear();

            geneticStart();

            lbl_loop.Text = Session["loop"].ToString();
            loop = int.Parse(lbl_loop.Text);

            if (loop == int.Parse(txb_gen.Text))
            {
                Session.Abandon();
                Timer1.Enabled = false;
                btn_gen.Text = "   Auto   ";
                btn_cencle.Text = "Reset";
                btn_gen.Enabled = true;
                btn_next.Enabled = true;
                imgLoop.Src = "images/ezgif.com-crop_1.png";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "success('" + lbl_max_X.Text + "');", true);
            }

            loop++;
            Session["loop"] = loop;
            gen = double.Parse(txb_gen.Text.ToString());
            per = loop / gen * 100;
            Session["per"] = per;
        }

        protected void btn_gen_Click(object sender, EventArgs e)
        {
            if (txb_gen.Text == "0")
            {
                txb_gen.Focus();
                return;
            }

            genChromse.Clear();
            max_f.Clear();

            imgLoop.Src = "images/ezgif.com-crop.gif";

            loop = 1;           
            Session["loop"] = loop;

            gen = double.Parse(txb_gen.Text.ToString());
            per = loop / gen * 100;
            Session["per"] = per;

            btn_gen.Text = "Generate..";
            btn_gen.Enabled = false;
            btn_next.Enabled = false;
            btn_cencle.Text = "Cencle";
            start = true;
            Session["start"] = start;
            Timer1.Enabled = true;
        }

        protected void btn_next_Click(object sender, EventArgs e)
        {
            if (Session["loop"] == null)
            {
                loop = 1;
                Session["loop"] = loop;
                lbl_max_X.Text = "";
                gen = int.Parse(txb_gen.Text.ToString());
                per = loop / gen * 100;
                Session["per"] = per;
            }

            genChromse.Clear();
            max_f.Clear();

            imgLoop.Src = "images/ezgif.com-crop.gif";

            btn_gen.Enabled = false;
            btn_next.Enabled = true;
            btn_cencle.Text = "Cencle";
            btn_next.Text = "Next Steps";
            start = true;
            Session["start"] = start;

            per = double.Parse(Session["per"].ToString());
            process.Attributes["style"] = "width: " + per + "%;";
            lbl_process.Text = string.Format("{0:0.0}", per)+"%";

            Table1.Rows.Clear();
            Table2.Rows.Clear();
            Table3.Rows.Clear();
            tb1Cell.Clear();
            tb2Cell.Clear();
            tb3Cell.Clear();

            geneticStart();

            lbl_loop.Text = Session["loop"].ToString();
            loop = int.Parse(lbl_loop.Text);

            if (loop == int.Parse(txb_gen.Text))
            {
                Session.Abandon();
                btn_cencle.Text = "Reset";
                btn_next.Text = "Manual";
                btn_gen.Enabled = true;
                btn_next.Enabled = true;
                imgLoop.Src = "images/ezgif.com-crop_1.png";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "success('" + lbl_max_X.Text + "');", true);
            }

            loop++;
            Session["loop"] = loop;
            gen = double.Parse(txb_gen.Text.ToString());
            per = loop / gen * 100;
            Session["per"] = per;
        }

        protected void btn_cencle_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect(Request.RawUrl);
        }

        private void geneticStart()
        {
            /*********************** Chromosomse *******************************/
            start = bool.Parse(Session["start"].ToString());
            if (start)
            {
                chromosome.randomNum();  // random ค่า 0-15 
                chromse_dec = chromosome.getX();
                start = false;
                Session["start"] = start;
            }else
            {
                chromse_dec = (int[])Session["chromse_dec"];
            }


            for (int i = 0; i < limit_Chroms; i++)
            {
                genChromse.Add(chromse_dec[i]);
            }

            chromse_bin = chromosome.createChroms(chromse_dec);                   // เก็บโคโมโซม  4 bit           
            finess = chromosome.getFiness(chromse_dec);                          //เก็บค่าความเหมาะสม

            for (int i = 0; i < limit_Chroms; i++)
            {
                max_f.Add(finess[i]);
            }

            chromosome.totalFiness();                                              // ผลรวมความเหมาะสมทั้งหมด
            pselect = chromosome.getPselect();                                     // ความน่าจะเป็น
            expected = chromosome.getExpected();                                    // จำนวนที่คาดหวัง
            qi = chromosome.getQi();                                               // ความถี่สะสมความน่าจะเป็น
            r = chromosome.getR();                                                 // เก็บค่าจำนวนจริว r
            r_qi = chromosome.getRqi();                                            // ลำดับที่เลือก

            for (int r = 0; r < limit_Chroms; r++)
            {
                TableRow row = new TableRow();
                for (int c = 0; c < 9; c++)
                {
                    if (c == 0)
                    {
                        tb1Cell.Clear();
                        for (int i = 0; i < 9; i++)
                        {
                            TableCell cell = new TableCell();

                            if (i == 0) cell.Text = (r + 1).ToString();
                            if (i == 1) cell.Text = chromse_bin[r];
                            if (i == 2) cell.Text = chromse_dec[r].ToString();
                            if (i == 3) cell.Text = finess[r].ToString();
                            if (i == 4) cell.Text = pselect[r].ToString("0.0000");
                            if (i == 5) cell.Text = expected[r].ToString("0.0000");
                            if (i == 6) cell.Text = qi[r].ToString("0.0000");
                            if (i == 7) cell.Text = this.r[r].ToString("0.0000");
                            if (i == 8) cell.Text = (r_qi[r] + 1).ToString();

                            tb1Cell.Add(cell);
                        }
                    }               
                    row.Cells.Add(tb1Cell[c]);
                }
                Table1.Rows.Add(row);
                Table1.Rows[r].Cells[0].Style.Add(HtmlTextWriterStyle.Width, "8%");
                Table1.Rows[r].Cells[1].Style.Add(HtmlTextWriterStyle.Width, "12%");
                Table1.Rows[r].Cells[2].Style.Add(HtmlTextWriterStyle.Width, "7%");
                Table1.Rows[r].Cells[4].Style.Add(HtmlTextWriterStyle.Width, "12%");
                Table1.Rows[r].Cells[5].Style.Add(HtmlTextWriterStyle.Width, "12%");
                Table1.Rows[r].Cells[7].Style.Add(HtmlTextWriterStyle.Width, "13%");
                Table1.Rows[r].Cells[8].Style.Add(HtmlTextWriterStyle.Width, "12%");
            }                
            /*********************** Crossover *******************************/

            Crossover cros = new Crossover(chromse_bin, r_qi);

            mating_pool = cros.getMatingPool(); // เก็บ mating pool
            r_qi2 = cros.getRqi();           // ลำดับการคัดเลือก

            for (int r = 0; r < limit_Chroms; r++)
            {
                TableRow row = new TableRow();
                for (int c = 0; c < 10; c++)
                {
                    if (c == 0)
                    {
                        tb2Cell.Clear();
                        for (int i = 0; i < 10; i++)
                        {
                            TableCell cell = new TableCell();

                            if (i == 0) cell.Text = (r_qi2[r] + 1).ToString();
                            if (i == 1) cell.Text = mating_pool[r];
                            if (i == 2) cell.Text = "-";
                            if (i == 3) cell.Text = "-";
                            if (i == 4) cell.Text = "-";
                            if (i == 5) cell.Text = "-";
                            if (i == 6) cell.Text = "-";
                            if (i == 7) cell.Text = "-";
                            if (i == 8) cell.Text = "-";
                            if (i == 9) cell.Text = (r + 1).ToString();

                            tb2Cell.Add(cell);
                        }
                    }
                    row.Cells.Add(tb2Cell[c]);
                }
                Table2.Rows.Add(row);
                Table2.Rows[r].Cells[0].Style.Add(HtmlTextWriterStyle.Width, "8%");
                Table2.Rows[r].Cells[1].Style.Add(HtmlTextWriterStyle.Width, "10%");
                Table2.Rows[r].Cells[2].Style.Add(HtmlTextWriterStyle.Width, "10%");
                Table2.Rows[r].Cells[3].Style.Add(HtmlTextWriterStyle.Width, "10%");
                Table2.Rows[r].Cells[4].Style.Add(HtmlTextWriterStyle.Width, "14%");
                Table2.Rows[r].Cells[5].Style.Add(HtmlTextWriterStyle.Width, "16%");
                Table2.Rows[r].Cells[6].Style.Add(HtmlTextWriterStyle.Width, "10%");
                Table2.Rows[r].Cells[7].Style.Add(HtmlTextWriterStyle.Width, "9%");
                Table2.Rows[r].Cells[9].Style.Add(HtmlTextWriterStyle.Width, "9%");
            }

            for (int i = 0; i < limit_Chroms; i += 2)
            {

                // สุ่ม พ่อ - แม่
                int parents1 = Convert.ToInt32(Table2.Rows[ran.Next(0, 9)].Cells[0].Text);
                int parents2 = Convert.ToInt32(Table2.Rows[ran.Next(0, 9)].Cells[0].Text);

                Table2.Rows[i].Cells[2].Text = parents1 + "," + parents2;

                befor_cross[0] = chromse_bin[parents1 - 1];
                befor_cross[1] = chromse_bin[parents2 - 1];

                string coss_rate = "";
                string n_pos = "";
                double r2 = ran.NextDouble();

                if (r2 <= Convert.ToDouble(txb_coss_rate.Text))
                {
                    cross = true;
                    Session["cross"] = cross;
                    pos = ran.Next(1, 5);
                    coss_rate = "<=" + txb_coss_rate.Text;
                    after_cross = cros.getCross(befor_cross, pos); // call crossover
                    x1 = Convert.ToString(Convert.ToInt32(after_cross[0].ToString(), 2), 10);
                    x2 = Convert.ToString(Convert.ToInt32(after_cross[1].ToString(), 2), 10);
                    cros.setF(Convert.ToInt32(x1), Convert.ToInt32(x2));
                    // ค่าความเหมาะสม
                    f1 = cros.getF1();
                    f2 = cros.getF2();
                    // มิวเตชัน
                    befor_mu[i] = after_cross[0];
                    befor_mu[i + 1] = after_cross[1];
                }
                else
                {
                    cross = false;
                    Session["cross"] = cross;
                    coss_rate = ">" + txb_coss_rate.Text;
                    n_pos = "ไม่ครอสโอเวอร์";
                    x1 = Convert.ToString(Convert.ToInt32(befor_cross[0].ToString(), 2), 10);
                    x2 = Convert.ToString(Convert.ToInt32(befor_cross[1].ToString(), 2), 10);
                    cros.setF(Convert.ToInt32(x1), Convert.ToInt32(x2));
                    // ค่าความเหมาะสม
                    f1 = cros.getF1();
                    f2 = cros.getF2();
                    // มิวเตชัน
                    befor_mu[i] = befor_cross[0];
                    befor_mu[i + 1] = befor_cross[1];
                }

                Table2.Rows[i].Cells[3].Text = r2.ToString("0.0000");
                Table2.Rows[i + 1].Cells[3].Text = coss_rate;

                cross = bool.Parse(Session["cross"].ToString());

                if (cross) // ไม่ครอสโอเวอร์
                {
                    // ก่อนครอสโอเวอร์
                    Table2.Rows[i].Cells[4].Text = befor_cross[0];
                    Table2.Rows[i + 1].Cells[4].Text = befor_cross[1];
                    Table2.Rows[i].Cells[5].Text = pos.ToString();
                    //หลังครอสโอเวอร์
                    Table2.Rows[i].Cells[6].Text = after_cross[0];
                    Table2.Rows[i + 1].Cells[6].Text = after_cross[1];                    
                }
                else
                {
                    Table2.Rows[i].Cells[5].Text = n_pos;
                    Table2.Rows[i].Cells[6].Text = befor_cross[0];
                    Table2.Rows[i + 1].Cells[6].Text = befor_cross[1];
                }

                // ค่า X, F
                Table2.Rows[i].Cells[7].Text = x1;
                Table2.Rows[i + 1].Cells[7].Text = x2;
                Table2.Rows[i].Cells[8].Text = f1.ToString();
                Table2.Rows[i + 1].Cells[8].Text = f2.ToString();

            }

            /******************************** Mutation *******************************/

            Mutation mu = new Mutation(befor_mu);
            string r_mu;

            for (int r = 0; r < limit_Chroms; r++)
            {
                r_mu = mu.getR();                                                                 // เก็บค่าซุ่ม r 5 ค่า
                after_mu[r] = mu.getMutation(Convert.ToDouble(txb_mu_rate.Text), r);                    // เก็บค่า Mutation
                int mu_x = Convert.ToInt32(Convert.ToString(Convert.ToInt32(after_mu[r], 2), 10));
                mu_f[r] = mu.getF(after_mu[r]);      // หาค่า F
                genChromse.Add(mu_x);
                max_f.Add(mu_f[r]);

                TableRow row = new TableRow();
                for (int c = 0; c < 6; c++)
                {
                    if (c == 0)
                    {
                        tb3Cell.Clear();
                        for (int i = 0; i < 6; i++)
                        {
                            TableCell cell = new TableCell();

                            if (i == 0) cell.Text = (r + 1).ToString();
                            if (i == 1) cell.Text = befor_mu[r];
                            if (i == 2) cell.Text = r_mu;
                            if (i == 3) cell.Text = after_mu[r];
                            if (i == 4) cell.Text = mu_x.ToString();
                            if (i == 5) cell.Text = mu_f[r].ToString();

                            tb3Cell.Add(cell);
                        }
                    }
                    row.Cells.Add(tb3Cell[c]);
                }
                Table3.Rows.Add(row);
                Table3.Rows[r].Cells[0].Style.Add(HtmlTextWriterStyle.Width, "8%");
                Table3.Rows[r].Cells[2].Style.Add(HtmlTextWriterStyle.Width, "50%");
                Table3.Rows[r].Cells[4].Style.Add(HtmlTextWriterStyle.Width, "6%");
                Table3.Rows[r].Cells[5].Style.Add(HtmlTextWriterStyle.Width, "10%");
            }

            genChromse.Sort();       
            genChromse.Reverse();    
            max_f.Sort();               
            max_f.Reverse();           

            int index = 0, k = 0;
            while (index < 10)
            {
                if (index == 10)
                {
                    break;
                }
                int y = (15 * genChromse[k]) - (genChromse[k] * genChromse[k]);
                if (y == max_f[0])
                {
                    chromse_dec[index] = genChromse[k];                    
                    genChromse.RemoveAt(k);
                    max_f.RemoveAt(0);
                    k = 0;
                    index++;
                }
                else
                {
                    k++;
                }
            }
            Session["chromse_dec"] = chromse_dec;
            lbl_max_X.Text = chromse_dec[0].ToString();        // ค่าสูงสุด
        }

    }
}