using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ForoPenalVenezolano {
    public partial class Form1 : Form {
        OleDbConnection con;
        OleDbDataAdapter da;
        DataSet ds;
        DataTable dt;
        F2 f;
        public Form1() {
            InitializeComponent();

            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FPVDB.mdb");
            da = new OleDbDataAdapter("SELECT * FROM USUARIOS",con);
            ds = new DataSet();
            dt = new DataTable("USUARIOS");
            da.Fill(ds, "USUARIOS");
            dt = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            string us = usuario.Text.ToLower();
            string cl = clave.Text.ToLower();
            if(buscar(us, cl) == 1) {
                f = new F2();
                f.Show();
                this.Hide();
            } else {
                MessageBox.Show("Datos Incorrectos");
                clave.Clear();
                usuario.Clear();
                usuario.Focus();
            }

        }

        private void _KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)(Keys.Enter)) {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        public int buscar(string u, string p) {
            try {
                foreach(DataRow dr in dt.Rows)
                    if(dr[1].ToString() == u && dr[2].ToString() == p)
                        return 1;
                    else if(dr[1].ToString() == u)
                        return 2;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private void _Enter(object sender, EventArgs e) {
            TextBox tb = (TextBox)sender;
            if(tb.Focused)
                tb.SelectAll();
            if(tb.Name == "clave")
                tb.PasswordChar = '*';
        }
    }
}
