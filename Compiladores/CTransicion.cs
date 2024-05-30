using System;
using System.Collections.Generic;
using System.Text;

namespace Compiladores
{
    public class CTransicion
    {
        #region Variables 
   
        public CEstado origen
        {
            get; 
            set;
        }
        public CEstado destino
        {
            get; 
            set;
        }
   
        public string letra { 
            get;
            set; 
        }
        #endregion

        #region Constructores

        public CTransicion()
        {
            origen = new CEstado();
            destino = new CEstado();
            letra = "ε";
        }
        #endregion
    }
}
