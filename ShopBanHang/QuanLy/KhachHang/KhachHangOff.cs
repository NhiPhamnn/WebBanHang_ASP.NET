﻿using DevExpress.XtraBars;
using Newtonsoft.Json;
using QuanLy.BanHang;
using QuanLy.Model;
using QuanLy.Model.DonHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy.KhachHang
{
    public partial class KhachHangOff : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Session sess;
        Session Sess
        {
            get { return sess; }
            set { sess = value; }
        }
        public KhachHangOff(Session sess)
        {
            InitializeComponent();
            this.sess = sess;
            loadData();
        }
        public void loadData()
        {
            string baseURL = "http://apidnh.somee.com/api/KhachHang/getAll";
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers.Add("Authorization", "Bearer " + sess.token);
                    var json = wc.DownloadString(baseURL);

                    var data = JsonConvert.DeserializeObject<List<ModelKhachHang>>(json);


                    dataGridView1.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            GlobalData.makh = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            TaoCTHDTG f = new TaoCTHDTG(Sess);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            GlobalData.makh = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            string url = "http://apidnh.somee.com/api/DHOfline/TaoHDOffline?makh=" + GlobalData.makh;
            Services.POST(url, sess.token);            
            GlobalData.madh = Services.GET("http://apidnh.somee.com/api/DHOfline/getlastdh", sess.token);
            TaoHDOff f = new TaoHDOff(Sess);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        public void loadDataTK(string tensp)
        {
            string baseURL = "http://apidnh.somee.com/api/KhachHang/GetKhachHang?sodt=" + tensp;
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers.Add("Authorization", "Bearer " + sess.token);
                    var json = wc.DownloadString(baseURL);

                    var data = JsonConvert.DeserializeObject<List<ModelKhachHang>>(json);


                    dataGridView1.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sdt = txtsdt.Text;
            loadDataTK(sdt);
        }
    }
}