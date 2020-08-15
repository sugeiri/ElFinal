using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo
{
    public class Clases
    {
        public static string aa_usuario = "";
        public class ETipo
        {
            public string id = "";
            public string descripcion = "";
            public string estado = "";
            public bool Tipo_PK_int = true;
        }
        public class ETipo_Articulo
        {
            public string id = "";
            public string descripcion = "";
            public string estado = "";
            public string unidad = "";
        }
        public class EArticulo
        {
            public string id_articulo = "";
            public string descr_articulo = "";
            public string estado_articulo = "";
            public string id_cat_articulo = "";
            public string id_gart_articulo = "";
            public string id_tart_articulo = "";
            public string aplica_inv_articulo = "";
            public string foto_articulo = "";
            public decimal contenido = 0;
        }
        public class EReceta
        {
            public string id = "";
            public string descripcion = "";
            public string estado = "";
            public string tipo = "";
            public string foto = "";
            public int porcion = 0;
            public decimal duracion = 0;
        }
        public class EFormula
        {
            public string ID_Receta = "";
            public string ID_Articulo = "";
            public string id_unidad = "";
            public decimal cantidad = 0;
            public string obligatorio = "";
        }
        public class EGrupo_art
        {
            public string id = "";
            public string descripcion = "";
            public string estado = "";
            public string foto = "";

        }

    }
}
