using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using CAPA_ENTIDAD;
using System.Data.SqlClient;



namespace CapaDatos
{
  public  class CDExamen : CDGeneral
    {


       public List<CEEXAMEN> Consulta(CEEXAMEN  objInput)
        {

            List <CEEXAMEN>   lsEstudiante = null;
            CEEXAMEN objEstudiante  =null;


            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_busca_estudiante", con);
                    cmd.Parameters.AddWithValue("@codigo", objInput.codigo);

                    cmd.CommandType = CommandType.StoredProcedure;
                    var lector = cmd.ExecuteReader();


                    lsEstudiante = new List<CEEXAMEN>();


                    while (lector.Read())
                    {
                        objEstudiante = new CEEXAMEN();
                        objEstudiante.codigo = Convert.ToInt32( lector["CODIGO"]);
                        objEstudiante.nombre = Convert.ToString (lector["NOMBRE"]);
                        objEstudiante.edad  =  Convert.ToInt32 (lector["EDAD"]);
                        //objEstudiante.fnacimiento = Convert.ToDateTime(lector["FNACIMIENTO"]);
                        objEstudiante.fnacimiento = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(lector["FNACIMIENTO"]));

                        lsEstudiante.Add(objEstudiante);
                        //objEstudiante.codigo = lector.GetInt32(0);
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }


            }  
 
            return lsEstudiante;

        }

        public bool insertar(CEEXAMEN pobjProceso)
        {

            bool salida = false;

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_insert_estudiante", cn);
                 cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo", pobjProceso.codigo);
                cmd.Parameters.AddWithValue("@nombre", pobjProceso.nombre);
                cmd.Parameters.AddWithValue("@edad", pobjProceso.edad);
                cmd.Parameters.AddWithValue("@fnacimiento", Convert.ToDateTime( pobjProceso.fnacimiento));

                cmd.ExecuteNonQuery();
                salida = true;
            }

            return salida;

        }


        public bool actualizar(CEEXAMEN pobjProceso)
        {

            bool salida = false;

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("[sp_actua_estudiante]", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo", pobjProceso.codigo);
                cmd.Parameters.AddWithValue("@nombre", pobjProceso.nombre);
                cmd.Parameters.AddWithValue("@edad", pobjProceso.edad);
                cmd.Parameters.AddWithValue("@fnacimiento", Convert.ToDateTime(pobjProceso.fnacimiento));

                cmd.ExecuteNonQuery();
                salida = true;
            }

            return salida;

        }

        public bool eliminar(CEEXAMEN pobjProceso)
        {

            bool salida = false;

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_elim_estudiante", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigo", pobjProceso.codigo);
                
                cmd.ExecuteNonQuery();
                salida = true;
            }

            return salida;

        }
        //proc_eliminar(v_codigo number)

    }
}
