using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAPA_ENTIDAD;
using CapaDatos;
using CapaNegocios;
using OfficeOpenXml;
//Install-Package EPPlus -Version 4.5.3.1
using System.IO;
using System.Collections;


namespace ExamenASP_SQL
{
    public partial class Examen : System.Web.UI.Page
    {

        CEEXAMEN ceestudiante = new CEEXAMEN();



        public static List<CEEXAMEN> listadoExcel;

        [System.Web.Services.WebMethod]              // Marcamos el método como uno web
        public static List<CEEXAMEN> ConsultaAjax(string dato1)    // el método debe ser de static
        {
            CEEXAMEN ceestudiante = new CEEXAMEN();
            if (dato1 == "")
            {
                ceestudiante.codigo = 0;
            }
            else
            {
                ceestudiante.codigo = Convert.ToInt32(dato1);
            }
            CNExamen objNExamen = new CNExamen();
            List<CEEXAMEN> listado = objNExamen.Consulta(ceestudiante);
            listadoExcel = listado;

            //------------------------------------

            //var listadoSelect = (from model in listado select new { model.codigo,model.edad }).ToList();

            //------------------------------------------

            return listado;
        }


        [System.Web.Services.WebMethod]
        public static string insertAjax(string codigo, string nombre, string edad, string fecha)
        {
            string ind = "0";
            CNExamen objNExamen = new CNExamen();
            CEEXAMEN ceestudiante = new CEEXAMEN();
            ceestudiante.codigo = Convert.ToInt32(codigo);
            ceestudiante.nombre = nombre;
            ceestudiante.edad = Convert.ToInt32(edad);
            ceestudiante.fnacimiento = fecha;
            var rpt = objNExamen.insertar(ceestudiante);

            if (rpt)
            {
                ind = "1";
            }

            return ind;
        }



        [System.Web.Services.WebMethod]
        public static string updateAjax(string codigo, string nombre, string edad, string fecha)
        {

            string ind = "0";
            CNExamen objNExamen = new CNExamen();
            CEEXAMEN ceestudiante = new CEEXAMEN();
            ceestudiante.codigo = Convert.ToInt32(codigo);
            ceestudiante.nombre = nombre;
            ceestudiante.edad = Convert.ToInt32(edad);
            ceestudiante.fnacimiento = fecha;
            var rpt = objNExamen.actualizar(ceestudiante);
            if (rpt)
            {
                ind = "1";
            }
            return ind;
        }


        [System.Web.Services.WebMethod]
        public static string eliminarAjax(string codigo)
        {
            string ind = "0";
            CNExamen objNExamen = new CNExamen();
            CEEXAMEN ceestudiante = new CEEXAMEN();
            ceestudiante.codigo = Convert.ToInt32(codigo);
            var rpt = objNExamen.eliminar(ceestudiante);
            if (rpt)
            {
                ind = "1";
            }
            return ind;
        }



        //protected void btnConsultar_Click(object sender, EventArgs e)
        //{
        //    ceestudiante.codigo = Convert.ToInt32(txtcodigo.Text);
        //    GridView1.DataSource = cnestudinate.consultar(ceestudiante);
        //    GridView1.DataBind();
        //}

        //protected void btnListado_Click(object sender, EventArgs e)
        //{
        //    CNExamen objExamen = new CNExamen();

        //    ceestudiante.codigo = Convert.ToInt32(txtcodigo.Text);

        //    GridView1.DataSource = objExamen.Consulta(ceestudiante);


        //    GridView1.DataBind();
        //}





        public void excelGenerado(List<CEEXAMEN> listado)
        {

            Session["aa"] = "1";

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Hoja de Trabajo");

                List<string[]> headerRow = new List<string[]>()
              {
              new string[] { "ID", "First Name", "Last Name", "DOB" }
              };



                // Determine the header range (e.g. A1:D1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";


                var excelWorksheet = excel.Workbook.Worksheets["Hoja de Trabajo"];

                // Cabecera de la data
                excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

                excelWorksheet.Cells[headerRange].Style.Font.Bold = true;
                excelWorksheet.Cells[headerRange].Style.Font.Size = 14;
                excelWorksheet.Cells[headerRange].Style.Font.Color.SetColor(System.Drawing.Color.Blue);


                //excelWorksheet.Cells["A1"].Value = "Hello World!";



                //var cellData = new List<object[]>()
                //{
                //   new object[] {0, 0, 0, 1},
                //  new object[] {10,7.32,7.42,1}

                //};


                string excelName = "reportaje";
                excelWorksheet.Cells[2, 1].LoadFromCollection(listado);

                using (var memoryStream = new MemoryStream())
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + excelName + ".xlsx");
                    excel.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }





            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {


            if (listadoExcel != null)
            {

                if (listadoExcel.Count > 0)
                {

                    excelGenerado(listadoExcel);
                }
                else
                {
                    string script = @"<script type='text/javascript'>
                            alert('Se ha presionado el boton: 7');
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                }

            }
            else
            {

                string script = @"<script type='text/javascript'>
                            alert('Lista vacia');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            }


        }

    }
}