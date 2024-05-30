using System;
using System.Collections.Generic;
using System.Text;

namespace Compiladores
{
    public class CEstado
    {
        #region Variables
        
        public int id
        {
            get; set;
        }
        //Lista de relaciones
        public List<List<int>> Tr;
        public int tipo { get; set; }
        #endregion

        #region Constructores
        public CEstado()
        {
            id = -1;
            tipo = 0;
            Tr = new List<List<int>>();

        }

        public CEstado(int id)
        {
            this.id = id;
        }
        #endregion
    }
}
