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
    public partial class Formula : Form
    {
        Clases.EReceta aa_Receta = new Clases.EReceta();
        List<Clases.EFormula> aa_LEFormula = new List<Clases.EFormula>();
        string aa_id = "";
        string aa_modo = "";

        public Formula(string ii_modo, string ii_id)
        {
            InitializeComponent();
            aa_modo = ii_modo;
            aa_id = ii_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            C_Receta CP = new C_Receta("e");
            CP.ShowDialog();
            string id = CP.Id.ToString().Trim();
            string descr = CP.Descr.ToString().Trim();
            if (id.Trim() != "0")
            {
                tid.Text = id;
                if (string.IsNullOrWhiteSpace(descr.Trim()))
                {
                    MessageBox.Show("No Existe este Dato en la Base de Datos");
                    return;
                }

                tdescr.Text = descr.ToString().Trim().ToUpper();
                List<Clases.EFormula> ii_formula = funciones.Lee_Formula(id);
                if (ii_formula != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Ya Existe Asignacion de Articulos para esta Receta , Desea Modificar?", "Alerta", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        tid.Text = "";
                        return;

                    }
                    aa_modo = "m";
                    tid.Enabled = true;
                    aa_Receta.id = ii_formula[0].ID_Receta;
                    Pasa_Datos();
                }
            }
        }

        private void tid_Leave(object sender, EventArgs e)
        {
            if (tid.Text.ToString().Trim() != "")
            {
                
                string descr = funciones.Lee_Descr_Receta(tid.Text.ToString().Trim());
                if (descr.ToString().Trim() == "")
                {
                    MessageBox.Show("No se encontro este dato en la base de datos");
                }
                tdescr.Text = descr;
                aa_Receta.id = tid.Text;
                aa_Receta.descripcion = descr;
                List<Clases.EFormula> ii_formula = funciones.Lee_Formula(tid.Text);
                if (ii_formula != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Ya Existe Asignacion de Articulos para esta Receta, Desea Modificar?", "Alerta", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        tid.Text = "";
                        return;

                    }
                    aa_modo = "m";
                    tid.Enabled = true;
                    aa_Receta.id= ii_formula[0].ID_Receta;
                    Pasa_Datos();
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 && dataGridView1.Rows[e.RowIndex].Cells[0] != null && (e.RowIndex < dataGridView1.Rows.Count - 1))
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            int n = 0;
                            if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), out n))
                            {
                                if (int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString().Trim()) == n)
                                {
                                    MessageBox.Show("Ya Existe Este Articulo para la receta");
                                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("El Codigo es Numerico");
                                return;
                            }



                        }
                    }

                    string SelectedText = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Clases.EArticulo ii_articulo= funciones.Lee_Articulo(SelectedText);
                    if(ii_articulo==null)
                    {
                        MessageBox.Show("No Existe Este Articulo");
                        return;
                    }
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = int.Parse(SelectedText);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = ii_articulo.descr_articulo.ToUpper();
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = funciones.Lee_Unidad_Articulo(ii_articulo.id_tart_articulo);
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = "1";
                }
                else
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }

            }
        }
        void Agrega_Fila(string id)
        {

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Trim() == id.ToString().Trim())
                {
                    MessageBox.Show("Ya Existe Este Articulo para la receta");
                    return;
                }
            }

            DataGridViewRow ii_row = new DataGridViewRow();
            ii_row.CreateCells(dataGridView1);
            Clases.EArticulo ii_articulo = funciones.Lee_Articulo(id);
            if (ii_articulo == null)
            {
                MessageBox.Show("No Existe Este Articulo");
                return;
            }
            
            ii_row.Cells[0].Value = id;
            ii_row.Cells[1].Value = funciones.Lee_Descr_Articulo(id);
            ii_row.Cells[2].Value = funciones.Lee_Unidad_Articulo(ii_articulo.id_tart_articulo); ;
            ii_row.Cells[3].Value = "1";
            dataGridView1.Rows.Add(ii_row);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                C_Articulo form = new C_Articulo("e");
                form.ShowDialog();
                string id_T = form.Id.Trim();
                if (!string.IsNullOrWhiteSpace(id_T.Trim()))
                {
                    Agrega_Fila(id_T);
                }
            }
            else
            {
                if (e.ColumnIndex == 2)
                {
                    string unidad_ori = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                    string sql = "select * from Unidad_Medida " +
                                            " where id_unidad_m in(select id_unidad_2_equiv" +
                                                                        " from equivalencia" +
                                                                            "  where id_unidad_1_equiv = '"+ unidad_ori + "') or" +
                                                 "  id_unidad_m in(select id_unidad_1_equiv" +
                                                                      " from equivalencia" +
                                                                            " where id_unidad_2_equiv = '"+ unidad_ori + "')";
                    C_Pant_Gen CP = new C_Pant_Gen("e", "Unidad_Medida", "UNIDAD MEDIDA", sql);
                    CP.ShowDialog();
                    string id_T = CP.Id.Trim();
                    if (!string.IsNullOrWhiteSpace(id_T.Trim()))
                    {
                        string cant_ori = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = id_T;
                       
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = funciones.Calcula_Equivalencia(unidad_ori, cant_ori, id_T);
                    }
                }

            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                C_Articulo form = new C_Articulo("e");
                form.ShowDialog();
                string id_T = form.Id.Trim();
                if (!string.IsNullOrWhiteSpace(id_T.Trim()))
                {
                    Agrega_Fila(id_T);
                }
            }
            else
            {
                if (e.ColumnIndex == 2)
                {
                    string sql = "select * from Unidad_Medida " +
                                            " where id_unidad_m in(select id_unidad_2_equiv" +
                                                                        " from equivalencia" +
                                                                            "  where id_unidad_1_equiv = 'lb') or" +
                                                 "  id_unidad_m in(select id_unidad_1_equiv" +
                                                                      " from equivalencia" +
                                                                            " where id_unidad_2_equiv = 'lb')";
                    C_Pant_Gen CP = new C_Pant_Gen("e", "Unidad_Medida", "UNIDAD MEDIDA", sql);
                    CP.ShowDialog();
                    string id_T = CP.Id.Trim();
                    if (!string.IsNullOrWhiteSpace(id_T.Trim()))
                    {
                        string unidad_ori = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        string cant_ori = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = id_T;

                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = funciones.Calcula_Equivalencia(unidad_ori, cant_ori, id_T);
                    }
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Selected || dataGridView1.Rows[i].Cells[1].Selected)
                {
                    dataGridView1.Rows.RemoveAt(i);

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ESTA SEGURO DE QUERER LIMPIAR LOS DATOS DE PLANES?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            dataGridView1.Rows.Clear();
        }
        void Limpia_Datos()
        {
            aa_Receta = new Clases.EReceta();
            aa_id = "";
            aa_modo = "a";
            foreach (Control item in this.Controls)
            {
                try
                {
                    if (item is TextBox)
                    {
                        item.Text = "";

                    }

                }
                catch { }
            }

            dataGridView1.Rows.Clear();
            tid.Enabled = true;
        }

        private void Formula_Load(object sender, EventArgs e)
        {
            if (aa_modo.ToUpper() == "A")
            {
                tid.Enabled = true;

            }
            else
            {
                aa_Receta = funciones.Lee_Receta(aa_id.ToString());
                Pasa_Datos();


            }
        }
        bool Inserta_Formula()
        {
            string Error = "";
            List<Clases.EFormula> aa_LEFormulaAseg = new List<Clases.EFormula>();
            Clases.EFormula aa_EPlanAseg = new Clases.EFormula();
            for (int ii = 0; ii < dataGridView1.RowCount - 1; ii++)
            {
                aa_EPlanAseg = new Clases.EFormula();

                aa_EPlanAseg.ID_Receta = tid.Text;
                aa_EPlanAseg.ID_Articulo = dataGridView1.Rows[ii].Cells[0].Value.ToString().Trim();
                aa_EPlanAseg.id_unidad = dataGridView1.Rows[ii].Cells[2].Value.ToString().Trim();
                aa_EPlanAseg.cantidad = decimal.Parse(dataGridView1.Rows[ii].Cells[3].Value.ToString().Trim());
                bool obligatorio = Convert.ToBoolean(dataGridView1.Rows[ii].Cells[4].Value);
                if (obligatorio)
                    aa_EPlanAseg.obligatorio = "X";

                aa_LEFormulaAseg.Add(aa_EPlanAseg);
            }

            if (funciones.Inserta_Formula(aa_LEFormulaAseg, ref Error))
            {
                return true;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Error.Trim()))
                {
                    MessageBox.Show(Error.ToString().Trim());
                }
            }
            return false;
        }

        bool Valida_Datos()
        {
            errorProvider1.Clear();
            string Msj = "Este Campo No Puede Estar en Blanco";
            if (aa_modo.ToUpper() == "A")
            {

                if (tid.Text.ToString().Trim() == "")
                {
                    MessageBox.Show(Msj);
                    errorProvider1.SetError(tid, Msj);
                    return false;
                }


                if (dataGridView1.RowCount <= 1)
                {
                    MessageBox.Show("Debe Indicar Al menos Un Articulo");
                    return false;
                }



            }
            return true;
        }
        void Pasa_Datos()
        {
            tid.Text = aa_Receta.id.ToString();
            tdescr.Text = aa_Receta.descripcion.ToString().ToUpper();
            aa_LEFormula = new List<Clases.EFormula>();
            aa_LEFormula = funciones.Lee_Formula(aa_Receta.id);

            if (aa_LEFormula != null)
            {

                dataGridView1.Rows.Clear();
                foreach (var formula in aa_LEFormula)
                {

                    DataGridViewRow ii_row = new DataGridViewRow();
                    ii_row.CreateCells(dataGridView1);
                    ii_row.Cells[0].Value = formula.ID_Articulo.ToString().Trim();
                    ii_row.Cells[1].Value = funciones.Lee_Descr_Articulo(formula.ID_Articulo.ToString());
                    ii_row.Cells[2].Value = formula.id_unidad;
                    ii_row.Cells[3].Value = formula.cantidad;
                    if(formula.obligatorio.ToString().Trim().ToUpper()=="X")
                        ii_row.Cells[4].Value = true;    
                    dataGridView1.Rows.Add(ii_row);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Valida_Datos())
            {
                if (Inserta_Formula())
                {
                    Limpia_Datos();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
