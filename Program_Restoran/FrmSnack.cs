﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Program_Restoran
{
    public partial class FrmSnack : Form
    {
        DataSet ds = new DataSet();
        string koneksi = "Provider = Microsoft.jet.oledb.4.0;Data source=" + Application.StartupPath + "/Restoran.mdb";
        private void tampil()
        {
            string sql = "select * from TB_Snack";
            OleDbConnection con = new OleDbConnection(koneksi);
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
            da.Fill(ds, "TB_Snack");
            con.Close();
            DG.DataSource = ds.Tables["TB_Snack"].DefaultView;
        }



        private void search()
        {
            string sql = "select * from TB_Snack where id='" + txtid.Text + "'";
            OleDbConnection con = new OleDbConnection(koneksi);
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
            ds.Clear();
            da.Fill(ds, "TB_Snack");
            con.Close();
            DG.DataSource = ds.Tables["TB_Snack"].DefaultView;
        }
        public FrmSnack()
        {
            InitializeComponent();
        }

        private void FrmSnack_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtharga.Text == "" || txtdes.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdes.Clear();
                txtharga.Clear();
                txtid.Clear();
                return;
            }

            try
            {
                string sql = string.Format("Update TB_Snack  set Nama_Item ='" + txtdes.Text + "',Harga='" + txtharga.Text + "' where id='" + txtid.Text + "'");
                OleDbConnection con = new OleDbConnection(koneksi);
                con.Open();
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Perubahan Data Tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds.Clear();
                tampil();
            }
            catch (OleDbException salah)
            {
                MessageBox.Show(salah.ToString());
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Yakin Hapus?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("delete * from TB_Snack where id='" + txtid.Text + "'");
                    OleDbConnection con = new OleDbConnection(koneksi);
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    tampil();
                }
            }

            catch (OleDbException salah)
            {
                MessageBox.Show(salah.ToString());
            }
        }

        private void btnew_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtharga.Text == "" || txtdes.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdes.Clear();
                txtharga.Clear();
                txtid.Clear();
            }


            try
            {
                string sql = string.Format("Insert into TB_Snack (ID,Nama_Item,Harga) Values('{0}','{1}','{2}')", txtid.Text, txtdes.Text, txtharga.Text);
                OleDbConnection con = new OleDbConnection(koneksi);
                con.Open();
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tampil();
            }
            catch (OleDbException salah)
            {
                MessageBox.Show(salah.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            tampil();
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DG.Rows[e.RowIndex];

                txtid.Text = row.Cells["ID"].Value.ToString();
                txtdes.Text = row.Cells["Nama_Item"].Value.ToString();
                txtharga.Text = row.Cells["Harga"].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtdes.Enabled = true;
            txtharga.Enabled = true;
            txtid.Enabled = true;

        }
    }
}
