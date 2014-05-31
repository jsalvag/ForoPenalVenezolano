using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ForoPenalVenezolano {
    public partial class F2 : Form {
        string btnMenu, accion;
        string[] datos;
        //USUARIOS user;

        public F2() {
            InitializeComponent();
            Star();
        }

        private void F2_FormClosed(object sender, FormClosedEventArgs e) { Application.Exit(); }

        private void _KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)(Keys.Enter)) { e.Handled = true; SendKeys.Send("{TAB}"); }
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e) {
            TextBox tb = (TextBox)sender;
            tb.BackColor = System.Drawing.Color.White;
            if(Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if(Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if(Char.IsPunctuation(e.KeyChar))
                e.Handled = false;
            else {
                e.Handled = true;
                tb.BackColor = System.Drawing.Color.Red;
            }

            if(e.KeyChar == (char)(Keys.Enter)) {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void limpuarDatosG() {
            pan_datosG.Hide();
            buscar_ci.Clear();
            nom.Clear();
            ape.Clear();
            sexM.Checked = true;
            sexF.Checked = false;
            edad.Clear();
            dir.Clear();
            btn_elim.Enabled = false;
            btn_master.Enabled = false;
        }

        private void limparDatosAd() {
            pan_datosAd.Hide();
            ad1.Hide(); ad1.Clear();
            ad2.Hide(); ad2.Clear();
            ad3.Hide(); ad3.Clear();
            ad4.Hide(); ad4.Clear();
            ad5.Hide(); ad5.Clear();
            ad6.Hide(); ad6.Clear();
            lb_1.Hide();
            lb_2.Hide();
            lb_3.Hide();
            lb_4.Hide();
            lb_5.Hide();
            lb_6.Hide();
        }

        private void Star() {
            buscarMj.Hide();
            pan_datos.Hide();
            limpuarDatosG();
            limparDatosAd();
        }

        private void Menu_Click(object sender, EventArgs e) {
            Star();
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            btnMenu = btn.Name;
            int i = btnMenu.Length - 3;
            accion = btnMenu.Substring(i).ToLower();
            switch(accion) {
                case "bus":
                    CajasBus();
                    pan_datos.Show(); buscar_ci.Focus();
                    btn_master.Show(); btn_master.Enabled = true; btn_master.Text = "Modificar";
                    btn_elim.Show(); btn_elim.Enabled = true;
                    break;
                case "reg":
                    CajasReg();
                    pan_datos.Show(); buscar_ci.Focus();
                    btn_master.Show(); btn_master.Enabled = true; btn_master.Text = "Registrar";
                    break;
                case "ver":
                    Data();
                    break;
                case "lir": Application.Exit(); break;
            }
        }

        private void CajasReg() {
            nom.Enabled = true;
            ape.Enabled = true;
            sexM.Enabled = true;
            sexF.Enabled = true;
            edad.Enabled = true;
            ad1.Enabled = true;
            ad2.Enabled = true;
            ad3.Enabled = true;
            ad4.Enabled = true;
            ad5.Enabled = true;
            ad6.Enabled = true;
            btn_elim.Hide();
        }

        private void CajasBus() {
            nom.Enabled = false;
            ape.Enabled = false;
            sexM.Enabled = false;
            sexF.Enabled = false;
            edad.Enabled = false;
            ad1.Enabled = false;
            ad2.Enabled = false;
            ad3.Enabled = false;
            ad4.Enabled = false;
            ad5.Enabled = false;
            ad6.Enabled = false;
            btn_elim.Show();
        }

        private void DibujarCajas() {
            switch(btnMenu) {
                case "smAbBus":
                case "smAbReg":
                    LB(lb_1, "INPRE:", ad1, false);
                    LB(lb_2, "Especialidad:", ad2, false);
                    LB(lb_3, "Teléfono\r\nOficina:", ad3, false);
                    LB(lb_4, "Dirección\r\nOficina:", ad4, true);
                    LB(lb_5, "x", ad5, false);
                    LB(lb_6, "x", ad6, false);
                    break;
                case "smDetBus":
                case "smDetReg":
                    LB(lb_1, "Juez:", ad1, false);
                    LB(lb_2, "Abogado:", ad2, false);
                    LB(lb_3, "Fecha:", ad3, false);
                    LB(lb_4, "Descripción\r\ndel Hecho:", ad4, false);
                    LB(lb_5, "Lugar Detención:", ad5, false);
                    LB(lb_6, "Lugar Reclusíon:", ad6, false);
                    break;
                case "smDetnBus":
                case "smDetnReg":
                    LB(lb_1, "Juez:", ad1, false);
                    LB(lb_2, "Abogado:", ad2, false);
                    LB(lb_3, "Fecha:", ad3, false);
                    LB(lb_4, "Descripción\r\ndel Hecho:", ad4, true);
                    LB(lb_5, "x", ad5, false);
                    LB(lb_6, "x", ad6, false);
                    break;
                case "smDenBus":
                case "smDenReg":
                    LB(lb_1, "Abogado:", ad1, false);
                    LB(lb_2, "Fecha:", ad2, false);
                    LB(lb_3, "Caso:", ad3, true);
                    LB(lb_4, "x", ad4, false);
                    LB(lb_5, "x", ad5, false);
                    LB(lb_6, "x", ad6, false);
                    break;
                case "smEvalBus":
                case "smEvalReg":
                    LB(lb_1, "Médico:", ad1, false);
                    LB(lb_2, "Informe:", ad2, true);
                    LB(lb_3, "x", ad3, false);
                    LB(lb_4, "x", ad4, false);
                    LB(lb_5, "x", ad5, false);
                    LB(lb_6, "x", ad6, false);
                    break;
                case "smDocBus":
                case "smDocReg":
                    LB(lb_1, "Licencia:", ad1, false);
                    LB(lb_2, "Especialidad:", ad2, false);
                    LB(lb_3, "x", ad3, false);
                    LB(lb_4, "x", ad4, false);
                    LB(lb_5, "x", ad5, false);
                    LB(lb_6, "x", ad6, false);
                    break;
                case "smJueBus":
                case "smJueReg":
                    LB(lb_1, "Licencia:", ad1, false);
                    LB(lb_2, "Especialidad:", ad2, false);
                    LB(lb_3, "x", ad3, false);
                    LB(lb_4, "x", ad4, false);
                    LB(lb_5, "x", ad5, false);
                    LB(lb_6, "x", ad6, false);
                    break;
                case "smUsBus":
                case "smUsReg":
                    LB(lb_1, "Usuario:", ad1, false);
                    LB(lb_2, "Clave:", ad2, false);
                    LB(lb_3, "Confirmar:", ad3, false);
                    LB(lb_4, "x", ad4, false);
                    LB(lb_5, "x", ad5, false);
                    LB(lb_6, "x", ad6, false);
                    if(accion == "bus") {
                        LB(lb_2, "x", ad2, false);
                        LB(lb_3, "x", ad3, false);
                    }
                    break;
            }
            pan_datosAd.Show();
        }

        private void btn_buscar_Click(object sender, EventArgs e) {
            //user = new USUARIOS();
            //user.Buscar(buscar_ci.Text);
            bool des = true;
            if(des) {
                buscarMj.ForeColor = System.Drawing.Color.LightGreen;
                buscarMj.Text = "Cedula Encontrada";
                pan_datosG.Show();
                DibujarCajas();
                buscarMj.Show();
            } else {
                buscarMj.ForeColor = System.Drawing.Color.Red;
                buscarMj.Text = "Ceudla no encontrada";
                buscarMj.Show();
            }
        }

        void LB(Label lb, string tex, TextBox tb, bool ml) {
            if(tex != "x") {
                int x = lb.Location.X;
                int anc = lb.Size.Width;
                lb.Text = tex;
                int nanc = lb.Size.Width;
                tb.Multiline = ml;
                if(ml) {
                    tb.Height = 100;
                } else {
                    tb.Height = 23;
                }
                lb.Show(); tb.Show();
                lb.Location = new Point(lb.Location.X - (nanc - anc), lb.Location.Y);
            } else { lb.Hide(); tb.Hide(); }
        }

        private void btn_limpiar_Click(object sender, EventArgs e) {
            buscar_ci.Clear();
            buscar_ci.Focus();
            limparDatosAd();
            limpuarDatosG();
            buscarMj.Hide();
        }

        private void lenarDatos() {
            datos = new string[3];
        }

        private void Data() {
            string nTab = "ABOGADOS";
            switch(btnMenu) {
                case "abVer": nTab = "ABOGADOS"; break;
                case "docVer": nTab = "DOCTORES"; break;
                case "impVer": nTab = "IMPLICADOS"; break;
                case "juVer": nTab = "JUECES"; break;
                case "usVer": nTab = "USUARIOS"; break;
            }
            DatosTodo data = new DatosTodo(nTab);
            data.Show();
        }

        private void btn_registrar_Click(object sender, EventArgs e) {
            //Menu_Click(
        }
    }
}
