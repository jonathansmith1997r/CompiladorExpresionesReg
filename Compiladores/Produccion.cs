using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Compiladores
{
    class Produccion
    {
        //Inicializamos las variables que se ocupan en la produccion
        public string Encabezado { set; get; }
        public string Cuerpo { set; get; }
        public List<string> Primeros { set; get; }
        public List<string> Siguientes { set; get; }
        public int numeroProduccion { set; get; }
        public bool PuntoFinal { set; get; }
 
        public Produccion()
        {
            //Valores estandar de las producciones
            Encabezado = "";
            Cuerpo = "";
            PuntoFinal = false;
        }


        public void ponPunto()
        {
            Cuerpo = Cuerpo.Insert(0, ".");
        }
        public string MuevePunto()
        {
            
            string cuerpoPunto = Cuerpo;
            string[] listaCuerpo = cuerpoPunto.Split();
            
            if (PuntoFinal)
                return null;
            int indice = 0;
            cuerpoPunto = "";
            
            for (int i = 0; i < listaCuerpo.Count(); i++)
            {
               
                if (listaCuerpo[i].Contains('.'))
                {
                    indice = i + 1;
                    listaCuerpo[i] = listaCuerpo[i].Replace(".", "");
                }
            }
            if (indice < listaCuerpo.Count())
                listaCuerpo[indice] = "." + listaCuerpo[indice];
            
            else
                PuntoFinal = true;
            for (int i = 0; i < listaCuerpo.Count(); i++)
            {
                if (i + 1 < listaCuerpo.Count())
                    cuerpoPunto += listaCuerpo[i] + " ";
                else
                    cuerpoPunto += listaCuerpo[i];

                if (PuntoFinal)
                    cuerpoPunto = cuerpoPunto.Replace(".", " ");
            }
            return cuerpoPunto;
        }
    }
}
