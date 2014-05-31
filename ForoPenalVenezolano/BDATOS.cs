using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace ForoPenalVenezolano {
    class BDATOS {
        string nomDB;
        OleDbConnection db;
        OleDbDataAdapter da;
        OleDbCommand com;
        DataTable dt, st;
        DataSet ds;

        //.\\ALQUILERDECARROS.accdb
        public BDATOS(string bdatos) {
            this.nomDB = bdatos;
        }

        public bool conectar(string bd) {
            this.db = new OleDbConnection();
            this.db.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.4.0;Data Source=" + bd;
            try {
                this.db.Open();
                return true;
            } catch(OleDbException ex) { MessageBox.Show(ex.Message); }
            return false;
        }

        public void cerrar() {
            this.db.Close();
        }

        public void limpiar() {
            this.db.Dispose();
        }

        public DataTable buscar(string campo, string tabla, string condicion) {
            dt = new DataTable();
            ds = new DataSet();
            ds.Tables.Add(dt);
            string sql = "SELECT " + campo + " FROM " + tabla + " " + condicion;
            sql = sql.Trim();
            sql += ";";
            try {
                da = new OleDbDataAdapter(sql, db);
                da.Fill(dt);
                return dt;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public bool insertar(string tabla, string valores) {//tabla en la que se va a guardar y cadena de lalores a guardar separados por ","
            conectar(nomDB);//conectar a la bas e de datos
            //se inicializa variables
            string val1 = "", val2 = "";
            string[] d1 = valores.Split(',');
            st = new DataTable();
            //se obtiene el esquema de la tabla para colocar los campos en la sentencia
            st = db.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new Object[] { null, null, tabla, null });
            string[] dc = new string[st.Rows.Count];//contiene los nombres de los campos
            string[] d2 = new string[dc.Length];//contiene los nombres de los campos con "@" delante

            for(int i = 0; i < st.Rows.Count; i++) {//se recorre el esquema obtenido para sacar los nombre de campos
                dc[i] = st.Rows[i].ItemArray[3].ToString();
                val1 += dc[i] + ',';//campos del VALUE
                d2[i] = "@" + dc[i];//campos de las ocurrencias
                val2 += d2[i] + ',';
            }

            val1 = val1.Trim(',');//se limpia el string de los campos del value
            val2 = val2.Trim(',');//se limpia el string de los campos de las ocurrencias

            string sql = "INSERT INTO [" + tabla + "] (" + val1 + ") VALUES (" + val2 + ");";//se unen los string para crear la sentencia SQL
            try {
                paramEmpleados(sql, d1, d2, dc.Length);//se cargan los paramateros en el conector
                com.ExecuteNonQuery();//se ejecuta una consulta si respuesta
                return true;
            } catch(Exception ex) { MessageBox.Show(ex.Message); } finally { db.Close(); com.Dispose(); }
            return false;
        }

        private void paramEmpleados(string sql, string[] d1, string[] d2, int x) {//carga las valiables en la sentencia SQL
            try {
                com = new OleDbCommand(sql, this.db);

                for(int i = 0; i < x; i++) {
                    if(i == 5 || i == 6)
                        com.Parameters.AddWithValue(d2[i], Convert.ToDateTime(d1[i]));
                    else if(i == 10)
                        com.Parameters.AddWithValue(d2[i], Convert.ToDouble(d1[i]));
                    else
                        com.Parameters.AddWithValue(d2[i], d1[i]);
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
