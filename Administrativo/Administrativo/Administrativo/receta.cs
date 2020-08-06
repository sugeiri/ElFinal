using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrativo
{
    public partial class receta : Form
    {
        string sql = "";
        string aa_modo = "";
        string Id = "";
        Clases.EReceta aa_EReceta = new Clases.EReceta();
        string FileName = "";
        public receta(string ii_modo,string ii_id)
        {
            InitializeComponent();
            aa_modo = ii_modo;
            Id = ii_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            C_Pant_Gen CP = new C_Pant_Gen("e", "Tipo_receta", "TIPO RECETA");
            CP.ShowDialog();
            string id = CP.Id.ToString().Trim();
            string descr = CP.aa_Descr.ToString().Trim();
            if (id.Trim() != "0")
            {
                TTipo.Text = id;
                if (string.IsNullOrWhiteSpace(descr.Trim()))
                {
                    MessageBox.Show("No Existe este Dato en la Base de Datos");
                    return;
                }

                TDescr_T.Text = descr.ToString().Trim().ToUpper();
            }
        }

        private void tid_Leave(object sender, EventArgs e)
        {
            if (tid.Text.ToString().Trim() != "")
            {
                if (tid.Text.ToString().Trim() == "*")
                {

                    tid.Text = funciones.Prox_Codigo("receta").ToString("######");
                }
                else
                {
                    Llena_Datos();
                }
            }
        }
        void Llena_Datos()
        {
            aa_EReceta = funciones.Lee_Receta(tid.Text.ToString().Trim());
            Byte[] ImageByte;

            if (aa_EReceta != null)
            {
                aa_modo = "m";
                tdescr.Text = aa_EReceta.descripcion;
                TTipo.Text = aa_EReceta.tipo;
                if (aa_EReceta.estado.ToUpper() == "A")
                    cb_estado.SelectedIndex = 0;
                else
                    cb_estado.SelectedIndex = 1;
                PB_Foto.SizeMode = PictureBoxSizeMode.Zoom;
                if (aa_EReceta.foto!=null)
                {
                    byte[] image = aa_EReceta.foto;
                    MemoryStream ms = new MemoryStream(image);
                    Image img = Image.FromStream(ms);
                    PB_Foto.Image = img;
                }
                TPorcion.Text = aa_EReceta.porcion.ToString().Trim();
                TDuracion.Text = aa_EReceta.duracion.ToString().Trim();
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
            if (string.IsNullOrWhiteSpace(TTipo.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(TTipo, mensaje);
                TTipo.Focus();
            }
            if (string.IsNullOrWhiteSpace(TDuracion.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(TDuracion, mensaje);
                TDuracion.Focus();
            }
            
            if (aa_modo.ToUpper().Trim() == "A")
            {
                if (cb_estado.SelectedIndex != 0)
                {
                    MessageBox.Show("NO PUEDE REGISTRAR CON ESTADO DIFERENTE DE ACTIVO");
                    return;

                }
            }
            aa_EReceta = new Clases.EReceta();
            aa_EReceta.id = tid.Text;
            aa_EReceta.descripcion = tdescr.Text;
            aa_EReceta.estado= cb_estado.SelectedItem.ToString().Trim().ToUpper().Substring(0, 1);
            aa_EReceta.tipo = TTipo.Text;
            aa_EReceta.duracion = Convert.ToDecimal(TDuracion.Text.ToString());
            aa_EReceta.porcion = int.Parse(TPorcion.Text.ToString());
            if (!funciones.Inserta_Receta(aa_modo,aa_EReceta,FileName, ref Error))
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
            TTipo.Text = "";
            TDescr_T.Text = "";
            TPorcion.Text = "1";
            TDuracion.Text = "";
        }

        private void Tunidad_Leave(object sender, EventArgs e)
        {
            if(TTipo.Text.ToString().Trim()!="")
            {
                string descr = funciones.Lee_Descr_TipoReceta(TTipo.Text.ToString().Trim());
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

        private void receta_Load(object sender, EventArgs e)
        {
            TPorcion.Text = "1";
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

        private void PB_Foto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files(*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    PB_Foto.SizeMode = PictureBoxSizeMode.Zoom;
                    PB_Foto.Image = Image.FromFile(openFileDialog1.FileName);
                    FileName = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
