using System;
using System.Data;

namespace ForoPenalVenezolano {
    class USUARIOS : PERSONAS {
        public string 
            user,
            clave;
        string[] datos;
        BDATOS db;
        DataTable dt;

        public USUARIOS(string ci, string nom, string ape, string sex, DateTime f_nac, string dir, string tlf, string user, string clave) : base(ci, nom, ape, sex, f_nac, dir, tlf) {
            this.user = user;
            this.clave = clave;
        }

        public USUARIOS() { }

        //|DataDirectory|
        public Boolean Buscar(string ci) {
            int i = 0;
            db = new BDATOS(".\\FPVDB.mdb");
            datos = new string[11];
            dt = db.buscar("*", "PERSONAS INNER JOIN USUARIOS", "ON PERSONAS.ci = USUARIOS.ci");
            foreach(DataRow dr in dt.Rows) {
                datos[i] = dr[i].ToString();
                i++;
            }
            try {
                return true;
            } catch {
                return false;
            }
        }
    }
}
