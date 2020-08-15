using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrativo
{
    class funciones
    {
        static string nombre_db = "";
        static string Instancia_db = "";
        private static string ConnectionString = "";
        public static SqlConnection OpenC(ref string Error)
        {
            nombre_db = "db_ElFinal";
            Instancia_db = Environment.MachineName.ToString().Trim();
             ConnectionString = "Persist Security Info=False;User ID = ElFinal; Password=12345;Initial Catalog = " + nombre_db + "; Server=" + Instancia_db + ";database=" + nombre_db + "";
            //ConnectionString = "Persist Security Info=False;User ID = ElFinal; Password=12345;Initial Catalog = " + nombre_db + "; Server=173.249.57.62;database=" + nombre_db + "";

           
            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                Error = ex.Message.ToString();

            }
            finally
            {
                conexion.Close();
            }
            return conexion;


        }
        public static DataSet EjecutaSQL(string Sql, ref string Error)
        {

            DataSet dt = new DataSet();
            try
            {
                //DataTable dt = new DataTable();

                string consulta = Sql;
                SqlCommand comando = new SqlCommand(consulta, OpenC(ref Error));
                SqlDataAdapter adap = new SqlDataAdapter(comando);
                adap.Fill(dt);
                OpenC(ref Error).Close();
                return dt;
            }
            catch (Exception e)
            {
                Error = e.Message.ToString();
            }
            return dt;
        }

        public static bool Inserta_Datos(string SQl, ref string Error)
        {

            using (var Connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    Connection.Open();
                    var Command = Connection.CreateCommand();
                    Command.CommandText = SQl;

                    try
                    {
                        Command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex_01)
                    {
                        Error = ex_01.Message;
                        return false;
                    }
                }
                catch (Exception ex_01)
                {
                    Error = ex_01.Message;
                    return false;
                }
            }

        }
        public static bool TipoPK(string tabla)
        {
            string sql = "";
            DataSet DS = new DataSet();
            string Error = "";
            sql = "select COLUMN_NAME,DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + tabla + "' and ORDINAL_POSITION = 1";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                if (DS.Tables[0].Rows[0]["DATA_TYPE"].ToString().Trim().ToLower() == "int")
                    return true;

            }

            return false;

        }
        public static int Prox_Codigo(string tabla)
        {
            string sql = "";
            Clases.ETipo ii_Tipo = new Clases.ETipo();
            DataSet DS = new DataSet();
            string Error = "";
            string campo = "";
            string tipo = "";
            sql = "select COLUMN_NAME,DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + tabla + "' and ORDINAL_POSITION = 1";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                campo = DS.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
            }

            sql = "  SELECT isnull(MAX(" + campo + "),0) from  " + tabla;
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                return int.Parse(DS.Tables[0].Rows[0][0].ToString()) + 1;

            }
            return 0;

        }
        public static Clases.ETipo Lee_Tipo(string id, string tabla, string campo)
        {
            Clases.ETipo ii_Tipo = new Clases.ETipo();
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  SELECT * from  " + tabla + " WHERE  " + campo + " = '" + id + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                ii_Tipo.id = id;
                ii_Tipo.descripcion = DS.Tables[0].Rows[0][1].ToString();
                ii_Tipo.estado = DS.Tables[0].Rows[0][2].ToString();
                return ii_Tipo;

            }
            return null;

        }
        public static Clases.ETipo Lee_Tipo(string id, string tabla)
        {
            string sql = "";
            Clases.ETipo ii_Tipo = new Clases.ETipo();
            DataSet DS = new DataSet();
            string Error = "";
            string campo = "";
            string tipo = "";
            sql = "select COLUMN_NAME,DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + tabla + "' and ORDINAL_POSITION = 1";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                campo = DS.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
                tipo = DS.Tables[0].Rows[0]["DATA_TYPE"].ToString();
            }

            sql = "  SELECT * from  " + tabla + " WHERE  " + campo + " = '" + id + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                ii_Tipo.id = id;
                ii_Tipo.descripcion = DS.Tables[0].Rows[0][1].ToString();
                ii_Tipo.estado = DS.Tables[0].Rows[0][2].ToString();
                if (tipo.ToString().Trim().ToLower() == "int")
                    ii_Tipo.Tipo_PK_int = true;
                else
                    ii_Tipo.Tipo_PK_int = false;
                return ii_Tipo;

            }
            return null;

        }
        public static List<string> Lista_Estados(string ii_Tabla, string Campo)
        {
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "select distinct " + Campo + " from " + ii_Tabla;
            List<string> int_Lista = new List<string>();
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                int Count = DS.Tables[0].Rows.Count;
                for (int i = 0; i < Count; i++)
                {
                    int_Lista.Add(DS.Tables[0].Rows[i][0].ToString());

                }

                return int_Lista;

            }
            return null;
        }

        public static string Lee_Descr_Gen(string id, string tabla)
        {
            string sql = "";
            Clases.ETipo ii_Tipo = new Clases.ETipo();
            DataSet DS = new DataSet();
            string Error = "";
            string campo = "";
            string tipo = "";
            sql = "select COLUMN_NAME,DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + tabla + "' and ORDINAL_POSITION = 1";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                campo = DS.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
                tipo = DS.Tables[0].Rows[0]["DATA_TYPE"].ToString();
            }

            sql = "  SELECT * from  " + tabla + " WHERE  " + campo + " = '" + id + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                return DS.Tables[0].Rows[0][1].ToString();

            }
            return "";

        }
        public static Clases.ETipo_Articulo Lee_Tipo_Articulo(string id)
        {
            Clases.ETipo_Articulo ii_Tipo = new Clases.ETipo_Articulo();
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  SELECT * from TIPO_ARTICULO WHERE  id_t_articulo = '" + id + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                ii_Tipo.id = id;
                ii_Tipo.descripcion = DS.Tables[0].Rows[0][1].ToString();
                ii_Tipo.estado = DS.Tables[0].Rows[0][2].ToString();
                ii_Tipo.unidad = DS.Tables[0].Rows[0][3].ToString();
                return ii_Tipo;

            }
            return null;

        }
        public static string Lee_Unidad(string id)
        {
            string sql = "";
            DataSet DS = new DataSet();
            string Error = "";


            sql = "  SELECT descr_unidad_m from  Unidad_Medida WHERE  id_unidad_m = '" + id + "' AND estado_unidad_m='A'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {

                return DS.Tables[0].Rows[0]["descr_unidad_m"].ToString().ToUpper();

            }
            return "";

        }
        public static string Lee_Descr_Tipo_Articulo(string id)
        {
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  SELECT * from TIPO_ARTICULO WHERE  id_t_articulo = '" + id + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                return DS.Tables[0].Rows[0][1].ToString();

            }
            return "";

        }
        public static Clases.EArticulo Lee_Articulo(string id)
        {
            Clases.EArticulo ii_articulo = new Clases.EArticulo();
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  SELECT * from ARTICULO WHERE  id_articulo = '" + id + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {

                ii_articulo.id_articulo = id;
                ii_articulo.descr_articulo = DS.Tables[0].Rows[0][1].ToString();
                ii_articulo.estado_articulo = DS.Tables[0].Rows[0][2].ToString();
                ii_articulo.id_cat_articulo = DS.Tables[0].Rows[0][3].ToString();
                ii_articulo.id_gart_articulo = DS.Tables[0].Rows[0][4].ToString();
                ii_articulo.id_tart_articulo = DS.Tables[0].Rows[0][5].ToString();
                ii_articulo.aplica_inv_articulo = DS.Tables[0].Rows[0][6].ToString();
                if (DS.Tables[0].Rows[0][7].ToString() != "")
                    ii_articulo.foto_articulo = DS.Tables[0].Rows[0][7].ToString();
                ii_articulo.contenido =(decimal) DS.Tables[0].Rows[0][8];
                return ii_articulo;

            }
            return null;

        }
        public static string Lee_Descr_Articulo(string id)
        {
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  SELECT * from ARTICULO WHERE  id_articulo = '" + id + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                return DS.Tables[0].Rows[0][1].ToString();

            }
            return "";

        }
        public static Clases.EReceta Lee_Receta(string id)
        {
            Clases.EReceta ii_Receta = new Clases.EReceta();
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  SELECT * from RECETA WHERE  id_receta = '" + id + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                ii_Receta.id = id;
                ii_Receta.descripcion = DS.Tables[0].Rows[0][1].ToString();
                ii_Receta.estado = DS.Tables[0].Rows[0][2].ToString();
                ii_Receta.tipo = DS.Tables[0].Rows[0][3].ToString();
                if (DS.Tables[0].Rows[0][4].ToString() != "")
                    ii_Receta.foto = DS.Tables[0].Rows[0][4].ToString();
                ii_Receta.porcion = int.Parse(DS.Tables[0].Rows[0][5].ToString());
                ii_Receta.duracion = decimal.Parse(DS.Tables[0].Rows[0][6].ToString());
                return ii_Receta;

            }
            return null;

        }
        public static string Lee_Descr_TipoReceta(string id)
        {
            string sql = "";
            DataSet DS = new DataSet();
            string Error = "";


            sql = "  SELECT descr_t_receta from  Tipo_receta WHERE  id_t_receta = '" + id + "' AND estado_t_receta='A'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {

                return DS.Tables[0].Rows[0]["descr_t_receta"].ToString().ToUpper();

            }
            return "";

        }
        public static string Lee_Descr_Receta(string id)
        {
            string sql = "";
            DataSet DS = new DataSet();
            string Error = "";


            sql = "  SELECT descr_receta from  receta WHERE  id_receta = '" + id + "' AND estado_receta='A'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {

                return DS.Tables[0].Rows[0]["descr_receta"].ToString().ToUpper();

            }
            return "";

        }
        public static List<Clases.EFormula> Lee_Formula(string Receta)
        {
            List<Clases.EFormula> ii_LEFormula = new List<Clases.EFormula>();
            Clases.EFormula ii_EFormula = new Clases.EFormula();
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  SELECT * from Formula_receta WHERE id_receta_fr = '" + Receta + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ii_EFormula = new Clases.EFormula();
                    ii_EFormula.ID_Receta = DS.Tables[0].Rows[i]["id_receta_fr"].ToString();
                    ii_EFormula.ID_Articulo = DS.Tables[0].Rows[i]["id_articulo_fr"].ToString();
                    ii_EFormula.id_unidad = DS.Tables[0].Rows[i]["id_unidad_fr"].ToString();
                    ii_EFormula.cantidad = decimal.Parse(DS.Tables[0].Rows[i]["cant_art_fr"].ToString());
                    ii_EFormula.obligatorio = DS.Tables[0].Rows[i]["no_sust_art_fr"].ToString();
                    ii_LEFormula.Add(ii_EFormula);
                }
                return ii_LEFormula;
            }
            return null;

        }

        public static bool Inserta_Formula(List<Clases.EFormula> ii_LFormula, ref string Error)
        {
            string sql = "";
            sql = "DELETE Formula_receta WHERE id_receta_fr='" + ii_LFormula[0].ID_Receta + "'";
            if (!funciones.Inserta_Datos(sql, ref Error))
            {
                return false;
            }
            foreach (var ii in ii_LFormula)
            {
                sql = "INSERT INTO Formula_receta VALUES('" + ii.ID_Receta + "','" +
                                                             ii.ID_Articulo + "','" +
                                                             ii.id_unidad + "'," +
                                                             ii.cantidad + ",'" +
                                                             ii.obligatorio + "')";
                if (!funciones.Inserta_Datos(sql, ref Error))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool Inserta_Articulo(string ii_Modo, Clases.EArticulo ii_EArticulo, string ii_FileName, ref string Error)
        {
            Error = "";
            SqlConnection con = OpenC(ref Error);
            SqlCommand cmd;
            string base64data = "";
            try
            {

                if (ii_FileName.Length > 0)
                {
                    base64data = ImageToBase64(ii_FileName);
                    ii_EArticulo.foto_articulo = base64data;
                }


                string sql = "";
                if (ii_Modo.Trim().ToUpper() == "A")
                {
                    sql = "INSERT INTO ARTICULO VALUES(@id," +
                                                      "@descripcion," +
                                                      "@estado," +
                                                      "@cat," +
                                                      "@grup," +
                                                      "@tipo," +
                                                      "@aplica," +
                                                      "@foto," +
                                                      "@contenido," +
                                                      "@usuario," +
                                                      "@fecha," +
                                                      "@usuario," +
                                                      "@fecha)";
                }
                else
                {
                    sql = "UPDATE ARTICULO SET " +
                            "descr_articulo =@descripcion," +
                            "estado_articulo=@estado," +
                            "id_cat_articulo=@cat," +
                            "id_gart_articulo=@grup," +
                            "id_tart_articulo=@tipo," +
                            "aplica_inv_articulo=@aplica," +
                            "foto_articulo=@foto," +
                            "contenido_articulo=@contenido," +
                            "mod_p_articulo=@usuario," +
                            "fecha_m_articulo =@fecha" +
                            " WHERE id_articulo=@id";
                }
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@id", SqlDbType.Int, 8);
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 500);
                cmd.Parameters.Add("@estado", SqlDbType.Char, 1);
                cmd.Parameters.Add("@cat", SqlDbType.Int, 8);
                cmd.Parameters.Add("@grup", SqlDbType.Int, 8);
                cmd.Parameters.Add("@tipo", SqlDbType.Int, 8);
                cmd.Parameters.Add("@aplica", SqlDbType.Char, 1);
                cmd.Parameters.Add("@foto", SqlDbType.VarChar);
                cmd.Parameters.Add("@contenido", SqlDbType.Decimal);
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime, 4);

                cmd.Parameters["@id"].Value = ii_EArticulo.id_articulo;
                cmd.Parameters["@descripcion"].Value = ii_EArticulo.descr_articulo;
                cmd.Parameters["@estado"].Value = ii_EArticulo.estado_articulo;
                cmd.Parameters["@cat"].Value = ii_EArticulo.id_cat_articulo;
                cmd.Parameters["@grup"].Value = ii_EArticulo.id_gart_articulo;
                cmd.Parameters["@tipo"].Value = ii_EArticulo.id_tart_articulo;
                cmd.Parameters["@aplica"].Value = ii_EArticulo.aplica_inv_articulo;
                cmd.Parameters["@foto"].Value = ii_EArticulo.foto_articulo;
                cmd.Parameters["@contenido"].Value = ii_EArticulo.contenido;
                cmd.Parameters["@usuario"].Value = Clases.aa_usuario;
                cmd.Parameters["@fecha"].Value = DateTime.Now;

                con.Open();
                int RowsAffected = cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return true;
        }

        public static bool Inserta_Receta(string ii_Modo, Clases.EReceta ii_EReceta, string ii_FileName, ref string Error)
        {
            Error = "";
            SqlConnection con = OpenC(ref Error);
            SqlCommand cmd;
            FileStream fs;
            BinaryReader br;
            byte[] ImageData = null;
            string base64data = "";
            try
            {

                if (ii_FileName.Length > 0)
                {

                    base64data = ImageToBase64(ii_FileName);
                    ii_EReceta.foto = base64data;
                }


                string sql = "";
                if (ii_Modo.Trim().ToUpper() == "A")
                {
                    sql = "INSERT INTO RECETA VALUES(@id," +
                                                      "@descripcion," +
                                                      "@estado," +
                                                      "@tipo," +
                                                      "@foto," +
                                                      "@porcion," +
                                                      "@duracion)";
                }
                else
                {
                    sql = "UPDATE RECETA SET " +
                            "descr_receta =@descripcion," +
                            "estado_receta=@estado," +
                            "id_tipo_receta =@tipo," +
                            "foto_receta =@foto," +
                            "porcion_receta =@porcion," +
                            "tiempo_receta =@duracion" +
                            " WHERE id_receta=@id";
                }
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@id", SqlDbType.Int, 8);
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 500);
                cmd.Parameters.Add("@estado", SqlDbType.Char, 1);
                cmd.Parameters.Add("@tipo", SqlDbType.Int, 8);
                cmd.Parameters.Add("@foto", SqlDbType.VarChar);
                cmd.Parameters.Add("@porcion", SqlDbType.Int, 8);
                cmd.Parameters.Add("@duracion", SqlDbType.Decimal, 5);

                cmd.Parameters["@id"].Value = ii_EReceta.id;
                cmd.Parameters["@descripcion"].Value = ii_EReceta.descripcion;
                cmd.Parameters["@estado"].Value = ii_EReceta.estado;
                cmd.Parameters["@tipo"].Value = ii_EReceta.tipo;
                cmd.Parameters["@foto"].Value = ii_EReceta.foto;

                cmd.Parameters["@porcion"].Value = ii_EReceta.porcion;
                cmd.Parameters["@duracion"].Value = ii_EReceta.duracion;

                con.Open();
                int RowsAffected = cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return true;
        }
        public static string Lee_Unidad_Articulo(string id_tipo)
        {
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  SELECT * from Tipo_articulo WHERE  id_t_articulo = '" + id_tipo + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                return DS.Tables[0].Rows[0]["id_unidad_t_articulo"].ToString();

            }
            return "";

        }
        public static decimal Calcula_Equivalencia(string unidad_antes, string cant_antes, string unidad_nueva)
        {
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  select * from equivalencia where " +
                "                               id_unidad_1_equiv = '" + unidad_antes + "' and " +
                                              " id_unidad_2_equiv = '" + unidad_nueva + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                decimal cant_1 = Convert.ToDecimal(cant_antes);
                decimal cant_2 = (decimal)DS.Tables[0].Rows[0]["cant_equiv_2"];
                return (cant_1 * cant_2) / (decimal)DS.Tables[0].Rows[0]["cant_equiv_1"];

            }
            else
            {
                sql = "  select * from equivalencia where " +
                "                               id_unidad_1_equiv = '" + unidad_nueva + "' and " +
                                              " id_unidad_2_equiv = '" + unidad_antes + "'";
                DS = new DataSet();
                DS = funciones.EjecutaSQL(sql, ref Error);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    decimal cant_1 = (decimal)DS.Tables[0].Rows[0]["cant_equiv_1"] * Convert.ToDecimal(cant_antes);
                    decimal cant_2 = (decimal)DS.Tables[0].Rows[0]["cant_equiv_2"];
                    return cant_1 / cant_2;

                }
            }
            return 0;

        }

        public static string ImageToBase64(string ruta)
        {

            Image image = Image.FromFile(ruta);
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        public static string Lee_Unidad_TArticulo(string id_tipo)
        {
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  select id_unidad_m,descr_unidad_m from TIPO_ARTICULO inner join Unidad_Medida "+
                                    " on id_unidad_m = id_unidad_t_articulo "+
                         " where id_t_articulo = '" + id_tipo + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                return DS.Tables[0].Rows[0]["descr_unidad_m"].ToString();

            }
            return "";

        }

        public static Clases.EGrupo_art Lee_Grupo_art(string id)
        {
            Clases.EGrupo_art ii_Grupo_art = new Clases.EGrupo_art();
            DataSet DS = new DataSet();
            string Error = "";
            string sql = "  SELECT * from GRUPO_ARTICULO WHERE  id_g_articulo = '" + id + "'";
            DS = funciones.EjecutaSQL(sql, ref Error);
            if (DS.Tables[0].Rows.Count > 0)
            {
                ii_Grupo_art.id = id;
                ii_Grupo_art.descripcion = DS.Tables[0].Rows[0][1].ToString();
                ii_Grupo_art.estado = DS.Tables[0].Rows[0][2].ToString();
                ii_Grupo_art.foto = DS.Tables[0].Rows[0][3].ToString();
                return ii_Grupo_art;

            }
            return null;

        }
        public static bool Inserta_Grupo_art(string ii_Modo, Clases.EGrupo_art ii_EGrupo_art, string ii_FileName, ref string Error)
        {
            Error = "";
            SqlConnection con = OpenC(ref Error);
            SqlCommand cmd;
            FileStream fs;
            BinaryReader br;
            byte[] ImageData = null;
            string base64data = "";
            try
            {

                if (ii_FileName.Length > 0)
                {

                    base64data = ImageToBase64(ii_FileName);
                    ii_EGrupo_art.foto = base64data;
                }


                string sql = "";
                if (ii_Modo.Trim().ToUpper() == "A")
                {
                    sql = "INSERT INTO GRUPO_ARTICULO VALUES(@id," +
                                                      "@descripcion," +
                                                      "@estado," +
                                                      "@foto)";
                }
                else
                {
                    sql = "UPDATE GRUPO_ARTICULO SET " +
                            "descr_g_articulo =@descripcion," +
                            "estado_Grupo_art=@estado," +
                            "estado_g_articulo =@tipo," +
                            "foto_g_articulo =@foto" +
                            " WHERE id_g_articulo=@id";
                }
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@id", SqlDbType.Int, 8);
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 500);
                cmd.Parameters.Add("@estado", SqlDbType.Char, 1);
                cmd.Parameters.Add("@foto", SqlDbType.VarChar);
               
                cmd.Parameters["@id"].Value = ii_EGrupo_art.id;
                cmd.Parameters["@descripcion"].Value = ii_EGrupo_art.descripcion;
                cmd.Parameters["@estado"].Value = ii_EGrupo_art.estado;
                cmd.Parameters["@foto"].Value = ii_EGrupo_art.foto;

                con.Open();
                int RowsAffected = cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return true;
        }

    }
}
