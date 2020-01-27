using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class CDGeneral
    {

        public string  conexion { get; set; }


        public CDGeneral()
        {


            //conexion = @"Data Source=VOLCANO\CRISTHIAN;Initial Catalog=entrevista;Integrated Security=True"; ;
            //VOLCANO\CRISTHIAN
            conexion = @"Data Source=VOLCANO\CRISTHIAN;Initial Catalog=entrevista;User ID=sa;Password=cristhian";
        }




    }
}
