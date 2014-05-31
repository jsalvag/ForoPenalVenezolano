using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace ForoPenalVenezolano {
    public partial class DatosTodo : Form {
        OleDbConnection con;
        OleDbDataAdapter da;
        DataSet ds;
        public DatosTodo(string tabla) {
            InitializeComponent();
            this.Text = tabla;
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FPVDB.mdb");
            da = new OleDbDataAdapter("SELECT * FROM PERSONAS INNER JOIN " + tabla + " ON PERSONAS.ci = " + tabla + ".ci;", con);
            ds = new DataSet();
            da.Fill(ds, tabla);
            dgv.DataSource = ds.Tables[tabla];
        }

    }
}
