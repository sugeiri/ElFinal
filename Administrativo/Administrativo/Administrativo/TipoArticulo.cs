using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrativo
{
    public partial class TipoArticulo : Form
    {
        string sql = "";
        string aa_modo = "";
        string Id = "";
        Clases.ETipo_Articulo aa_ETipo = new Clases.ETipo_Articulo();
        public TipoArticulo(string ii_modo,string ii_id)
        {
            InitializeComponent();
            aa_modo = ii_modo;
            Id = ii_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            C_Pant_Gen CP = new C_Pant_Gen("e", "Unidad_Medida", "UNIDAD MEDIDA");
            CP.ShowDialog();
            string id = CP.Id.ToString().Trim();
            string descr = CP.aa_Descr.ToString().Trim();
            if (id.Trim() != "0")
            {
                Tunidad.Text = id;
                if (string.IsNullOrWhiteSpace(descr.Trim()))
                {
                    MessageBox.Show("No Existe este Dato en la Base de Datos");
                    return;
                }

                TDescr_unidad.Text = descr.ToString().Trim().ToUpper();
            }
        }

        private void tid_Leave(object sender, EventArgs e)
        {
            if (tid.Text.ToString().Trim() != "")
            {
                if (tid.Text.ToString().Trim() == "*")
                {

                    tid.Text = funciones.Prox_Codigo("TIPO_ARTICULO").ToString("######");
                }
                else
                {
                    Llena_Datos();
                }
            }
        }
        void Llena_Datos()
        {
            aa_ETipo = funciones.Lee_Tipo_Articulo(tid.Text.ToString().Trim());
            if (aa_ETipo != null)
            {
                aa_modo = "m";
                tdescr.Text = aa_ETipo.descripcion;
                Tunidad.Text = aa_ETipo.unidad;
                if (aa_ETipo.estado.ToUpper() == "A")
                    cb_estado.SelectedIndex = 0;
                else
                    cb_estado.SelectedIndex = 1;
            }
            else
            {
                Valida_codigo();
            }
        }
        bool Valida_codigo()
        {
            int id = 0;
            if (!int.TryParse(tid.Text.ToString(), out id))
            {
                MessageBox.Show("SOLO VALORES NUMERICOS");
                return false;
            }
            return true;

        }

        private void tid_TextChanged(object sender, EventArgs e)
        {
            if (tid.Text.ToString().IndexOf("*") < 0 && tid.Text.ToString().Trim() != "")
                Valida_codigo();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string sql = "";
            string Error = "";
            errorProvider1.Clear();
            string mensaje = "ESTE CAMPO NO PUEDE ESTAR EN BLANCO";
            if (string.IsNullOrWhiteSpace(tid.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(tid, mensaje);
                tid.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tdescr.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(tdescr, mensaje);
                tdescr.Focus();
            }
            if (string.IsNullOrWhiteSpace(Tunidad.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(Tunidad, mensaje);
                Tunidad.Focus();
            }
            if (aa_modo.ToUpper().Trim() == "A")
            {
                if (cb_estado.SelectedIndex != 0)
                {
                    MessageBox.Show("NO PUEDE REGISTRAR CON ESTADO DIFERENTE DE ACTIVO");
                    return;

                }
                sql = "INSERT INTO TIPO_ARTICULO VALUES('" + tid.Text.ToString() + "','" + 
                                                             tdescr.Text.ToString().Trim() + "','" +
                                                             cb_estado.SelectedItem.ToString().Trim() + "','" +
                                                             Tunidad.Text.ToString().Trim() + "')";

            }
            else
            {
                    sql = "UPDATE TIPO_ARTICULO SET " +
                            "descr_t_articulo ='" + tdescr.Text.ToUpper() + "'," +
                            "estado_t_articulo='" + cb_estado.SelectedItem.ToString().ToUpper() + "'," +
                            "id_unidad_t_articulo ='" + Tunidad.Text.ToUpper() + "'" +
                            " WHERE id_t_articulo='" + tid.Text.ToString().Trim() + "'";

                
            }
            if (!funciones.Inserta_Datos(sql, ref Error))
            {
                MessageBox.Show(Error);
                return;
            }
            if (aa_modo.Trim().ToLower() == "a")
            {
                Limpia();

            }
            else
            {
                this.DialogResult = DialogResult.OK;

            }
        }
        void Limpia()
        {
            tid.Text = "";
            tdescr.Text = "";
            cb_estado.SelectedIndex = 0;
            Tunidad.Text = "";
            TDescr_unidad.Text = "";
        }

        private void Tunidad_Leave(object sender, EventArgs e)
        {
            if(Tunidad.Text.ToString().Trim()!="")
            {
                string descr = funciones.Lee_Unidad(Tunidad.Text.ToString().Trim());
                if(descr.ToString().Trim() == "")
                {
                    MessageBox.Show("No se encontro este dato en la base de datos");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TipoArticulo_Load(object sender, EventArgs e)
        {
            cb_estado.Items.Add("A");
            cb_estado.Items.Add("I");
            cb_estado.SelectedIndex = 0;
            if (aa_modo.ToString().ToUpper()=="M")
            {
                tid.ReadOnly = true;
                tid.Text = Id;
                Llena_Datos();
            }
        }
    }
}
