using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CAPA_ENTIDAD;

namespace CapaNegocios
{
 public   class CNExamen
    {


        CapaDatos.CDExamen objExamen = new CapaDatos.CDExamen();


        public List<CEEXAMEN> Consulta(CEEXAMEN objInput) {

            return objExamen.Consulta(objInput);
        }

        public bool insertar(CEEXAMEN objInput)
        {
            return objExamen.insertar(objInput);

        }


        public bool actualizar(CEEXAMEN objInput)
        {
            return objExamen.actualizar(objInput);
        }

        public bool eliminar(CEEXAMEN objInput)
        {
            return objExamen.eliminar(objInput);
        }

        //eliminar(CEESTUDIANTE pobjProceso)

    }
}