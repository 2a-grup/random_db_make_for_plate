﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

//BU GİTHUB KONTROL CÜMLESİDİR------------------2

namespace random_db_make_for_plate
{
    
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
            sqlDataSource1.Fill();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        
       
    
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Random hour = new Random();
            int hour_of_day = hour.Next(1, 24);


            Random minute = new Random();
            int minute_of_hour = minute.Next(1, 59);

            Random second = new Random();
            int second_of_minute = second.Next(5, 25);

            Random entrance = new Random();
            int entrance_def = entrance.Next(1, 5);

            Random exit = new Random();
            int exit_def = exit.Next(1, 3);

            Random end_of_plate = new Random();
            int plate_end = end_of_plate.Next(1, 9999);

            Random plate_alpha = new Random();
            int harf1 = plate_alpha.Next(65, 91);
            int harf2=plate_alpha.Next(65,91);
            int harf3 = plate_alpha.Next(65, 91);

            Random out_time_calc = new Random();
            int out_time = out_time_calc.Next(1, 5);



            labelControl1.Text =Convert.ToString( hour_of_day)+":"+ Convert.ToString(minute_of_hour)+ ":"+Convert.ToString(second_of_minute);
            labelControl5.Text= Convert.ToString(hour_of_day+ out_time) + ":" + Convert.ToString(minute_of_hour+ out_time) + ":" + Convert.ToString(second_of_minute+ out_time);
            labelControl6.Text = (out_time * 60)+out_time+(out_time/60)+"";
            SqlCommand komut = new SqlCommand("insert into entrance_exit_reading(plate,date_in,time_in,date_out,time_out,gate_in_id,gate_out_id,stay_time) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", "34" + Convert.ToChar(harf1) + Convert.ToChar(harf2) + Convert.ToChar(harf3) + Convert.ToString(plate_end));
            komut.Parameters.AddWithValue("@p2", dateEdit1.Text);
            komut.Parameters.AddWithValue("@p3", labelControl1.Text);
            komut.Parameters.AddWithValue("@p4", dateEdit1.Text);
           komut.Parameters.AddWithValue("@p5", labelControl5.Text);// çıkış saati
            komut.Parameters.AddWithValue("@p6", " Giriş"+Convert.ToString(entrance_def));
           komut.Parameters.AddWithValue("@p7", " ÇIKIŞ" + Convert.ToString(entrance_def));
            komut.Parameters.AddWithValue("@p8", (out_time * 60) + out_time + (out_time / 60)); //OTOPARKTA KALINAN SÜRE

            
            komut.ExecuteNonQuery();
            

            listele();
            


        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From entrance_exit_reading", bgl.baglanti());

            da.Fill(dt);
            gridControl1.DataSource = dt;
            
        }
        

        private void Form1_Load(object sender, EventArgs e)

        {
            // TODO: This line of code loads data into the 'license_plate_recognition_test_dbDataSet.entrance_exit_reading' table. You can move, or remove it, as needed.
            //this.entrance_exit_readingTableAdapter.Fill(this.license_plate_recognition_test_dbDataSet.entrance_exit_reading);
            dateEdit1.Properties.Mask.EditMask = "yyyy-MM -dd";

            listele();
            
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            //string FileName= "C:\Users\Ramazan\Desktop\reports\rapor";
            gridControl1.ExportToXlsx("dxrapor");

            string FileName = @"C:\Users\Ramazan\Desktop\reports\rapor.xls";
            gridControl1.ExportToXls(FileName);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
   
}

