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
    public partial class Grupo_art : Form
    {
        string sql = "";
        string aa_modo = "";
        string Id = "";
        Clases.EGrupo_art aa_EGrupo_art = new Clases.EGrupo_art();
        string FileName = "";
        string ii_foto = "";
        public Grupo_art(string ii_modo, string ii_id)
        {
            InitializeComponent();
            aa_modo = ii_modo;
            Id = ii_id;
        }

        private void tid_Leave(object sender, EventArgs e)
        {
            if (tid.Text.ToString().Trim() != "")
            {
                if (tid.Text.ToString().Trim() == "*")
                {

                    tid.Text = funciones.Prox_Codigo("Grupo_art").ToString("######");
                }
                else
                {
                    Llena_Datos();
                }
            }
        }
        void Llena_Datos()
        {
            aa_EGrupo_art = funciones.Lee_Grupo_art(tid.Text.ToString().Trim());

            if (aa_EGrupo_art != null)
            {
                aa_modo = "m";
                tdescr.Text = aa_EGrupo_art.descripcion;
                if (aa_EGrupo_art.estado.ToUpper() == "A")
                    cb_estado.SelectedIndex = 0;
                else
                    cb_estado.SelectedIndex = 1;
                PB_Foto.SizeMode = PictureBoxSizeMode.Zoom;
                if (aa_EGrupo_art.foto != "")
                {
                    PB_Foto.Image = funciones.Base64ToImage(aa_EGrupo_art.foto);
                }
                ii_foto = aa_EGrupo_art.foto;
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
          

            if (aa_modo.ToUpper().Trim() == "A")
            {
                if (cb_estado.SelectedIndex != 0)
                {
                    MessageBox.Show("NO PUEDE REGISTRAR CON ESTADO DIFERENTE DE ACTIVO");
                    return;

                }
            }
            aa_EGrupo_art = new Clases.EGrupo_art();
            aa_EGrupo_art.id = tid.Text;
            aa_EGrupo_art.descripcion = tdescr.Text;
            aa_EGrupo_art.estado = cb_estado.SelectedItem.ToString().Trim().ToUpper().Substring(0, 1);
            if (aa_modo.ToString().Trim().ToUpper() != "A")
                aa_EGrupo_art.foto = ii_foto;
            if (!funciones.Inserta_Grupo_art(aa_modo, aa_EGrupo_art, FileName, ref Error))
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
            PB_Foto = new PictureBox();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grupo_art_Load(object sender, EventArgs e)
        {
             cb_estado.Items.Add("A");
            cb_estado.Items.Add("I");
            cb_estado.SelectedIndex = 0;
            if (aa_modo.ToString().ToUpper() == "M")
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
