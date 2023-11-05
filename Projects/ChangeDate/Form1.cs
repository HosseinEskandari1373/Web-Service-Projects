using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ChangeDate
{
    public partial class Form1 : Form
    {
        PersianCalendar pc = new PersianCalendar();
        string dt2;
        DateTime dt3;
        string year;
        string mounth;
        string day;
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {//تبدیل شمسی به میلادی

            year = dateTimePicker1.Value.ToShortDateString().Substring(6, 4);
            mounth = dateTimePicker1.Value.ToShortDateString().Substring(3, 2);
            day = dateTimePicker1.Value.ToShortDateString().Substring(0, 2);



            dt2 = dateTimePicker1.Value.ToString();
            dt3 = Convert.ToDateTime(dt2);

            lblDayofWeek.ForeColor = Color.Red;

            switch (dt3.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    lblDayofWeek.Text = "  شنبه  ";
                    break;
                case DayOfWeek.Sunday:
                    lblDayofWeek.Text = "  یکشنبه  ";
                    break;
                case DayOfWeek.Monday:
                    lblDayofWeek.Text = "  دوشنبه  ";
                    break;
                case DayOfWeek.Tuesday:
                    lblDayofWeek.Text = "  سه شنبه  ";
                    break;
                case DayOfWeek.Wednesday:
                    lblDayofWeek.Text = "  چهارشنبه  ";
                    break;
                case DayOfWeek.Thursday:
                    lblDayofWeek.Text = "  پنجشنبه  ";
                    break;
                case DayOfWeek.Friday:
                    lblDayofWeek.Text = "  جمـــعه  ";
                    break;
            }


            DateTime dt = pc.ToDateTime(int.Parse(year), int.Parse(mounth), int.Parse(day), 0, 0, 0, 0);
            lblDayofWeek.Text += dt.Day + "  " + "  ";
            switch (dt3.Month.ToString())
            {
                case "1":
                    lblDayofWeek.Text += "ژانویه";
                    break;
                case "2":
                    lblDayofWeek.Text += "فوریه";
                    break;
                case "3":
                    lblDayofWeek.Text += "مارس";
                    break;
                case "4":
                    lblDayofWeek.Text += "آوریل";
                    break;
                case "5":
                    lblDayofWeek.Text += "مه";
                    break;
                case "6":
                    lblDayofWeek.Text += "ژوئن";
                    break;
                case "7":
                    lblDayofWeek.Text += "ژوئیه";
                    break;
                case "8":
                    lblDayofWeek.Text += "اوت";
                    break;
                case "9":
                    lblDayofWeek.Text += "سپتامبر";
                    break;
                case "10":
                    lblDayofWeek.Text += "اکتبر";
                    break;
                case "11":
                    lblDayofWeek.Text += "نوامبر";
                    break;
                case "12":
                    lblDayofWeek.Text += "دسامبر";
                    break;
            }
            lblDayofWeek.Text += "  " + "سال"+" ";
            lblDayofWeek.Text += dt.Year;
            lblMiDate.Text = dt.Year + "/" + dt.Month + "/" + dt.Day;
            lblDayOfYear.Text = "تعداد روزهای گذشته از سال جاری میلادی ";
            lblDayOfYear.Text += " " + dt3.DayOfYear.ToString() + " " + "روز می باشد";
            lblDayOfYear3.Text = "تعداد روزهای گذشته از سال جاری شمسی" + " ";
            TimeSpan ts1 = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()) - Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString().Substring(6, 4) + "/ 01 / 01");
            string dayOfYear2 = ts1.ToString("dd");
            int intDay2 = Convert.ToInt32(dayOfYear2) + 1;
            lblDayOfYear3.Text += intDay2.ToString() + " " + "روز می باشد";
            lblDayOfYear.ForeColor = Color.Green;
           



        }





        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(maskedTextBox1.Text);
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
            var result = persianDate.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("fa-Ir"));
            lblShDate.Text = result.ToString();

           
            switch (persianDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    lblDayOfWeek2.Text = "  شنبه  ";
                    break;
                case DayOfWeek.Sunday:
                    lblDayOfWeek2.Text = "  یکشنبه  ";
                    break;
                case DayOfWeek.Monday:
                    lblDayOfWeek2.Text = "  دوشنبه  ";
                    break;
                case DayOfWeek.Tuesday:
                    lblDayOfWeek2.Text = "  سه شنبه  ";
                    break;
                case DayOfWeek.Wednesday:
                    lblDayOfWeek2.Text = "  چهارشنبه  ";
                    break;
                case DayOfWeek.Thursday:
                    lblDayOfWeek2.Text = "  پنجشنبه  ";
                    break;
                case DayOfWeek.Friday:
                    lblDayOfWeek2.Text = "  جمـــعه  ";
                    break;
            }
            if (lblShDate.Text.Substring(8, 1) != "0")
            {

                lblDayOfWeek2.Text += " " + lblShDate.Text.Substring(8, 2);
            }
            else
                lblDayOfWeek2.Text += " " + lblShDate.Text.Substring(9, 1);
            lblDayOfWeek2.Text += " ";

            switch (lblShDate.Text.Substring(5, 2))
            {
                case "01":
                    lblDayOfWeek2.Text += "فروردین";
                    break;
                case "02":
                    lblDayOfWeek2.Text += "اردیبهشت";
                    break;
                case "03":
                    lblDayOfWeek2.Text += "خرداد";
                    break;
                case "04":
                    lblDayOfWeek2.Text += "تیر";
                    break;
                case "05":
                    lblDayOfWeek2.Text += "مرداد";
                    break;
                case "06":
                    lblDayOfWeek2.Text += "شهریور";
                    break;
                case "07":
                    lblDayOfWeek2.Text += "مهر";
                    break;
                case "08":
                    lblDayOfWeek2.Text += "آبان";
                    break;
                case "09":
                    lblDayOfWeek2.Text += "آذر";
                    break;
                case "10":
                    lblDayOfWeek2.Text += "دی";
                    break;
                case "11":
                    lblDayOfWeek2.Text += "بهمن";
                    break;
                case "12":
                    lblDayOfWeek2.Text += "اسفند";
                    break;
            }
            lblDayOfWeek2.Text += " " + "ماه" +" "+"سال"+" ";
            lblDayOfWeek2.Text += lblShDate.Text.Substring(0, 4);
            lblDayOfYear2.Text = "تعداد روزهای گذشته از سال جاری شمسی ";
            TimeSpan ts = Convert.ToDateTime(lblShDate.Text) - Convert.ToDateTime(lblShDate.Text.Substring(0, 4) + "/ 01 / 01") ;
            string dayOfYear = ts.ToString("dd");

            int intDay = Convert.ToInt32(dayOfYear) + 1;
            
            lblDayOfYear2.Text += " " + intDay.ToString() + " " + "روز می باشد";
            lblDayOfWeek2.ForeColor = Color.Red;
            lblDayOfYear2.ForeColor = Color.Green;
            DateTime dt4 = Convert.ToDateTime(maskedTextBox1.Text);

            TimeSpan ts3 = dt4 - Convert.ToDateTime(dt4.ToString().Substring(6, 4) + "/01/01");
            string dayOfYear4 = ts3.ToString("dd");

            int intDay3 = Convert.ToInt32(dayOfYear4) + 1;
            lblDayOfYear4.Text = "تعداد روزهای گذشته از سال جاری میلادی " + intDay3.ToString() + " " + "روز می باشد";


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result2;
              result2=  MessageBox.Show("آیا می خواهید از برنامه خارج شوید؟", "اخطار!", MessageBoxButtons.OKCancel);
               if(result2==DialogResult.OK)
                {


                    Application.Exit();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }

        }
    }
}
