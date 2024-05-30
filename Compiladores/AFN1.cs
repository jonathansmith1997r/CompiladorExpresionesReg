using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores
{
    public class AFN1
    {
        #region
        //Lista necesaria para le automata
        public List<AFN> pilaR;

        public AFN1()
        {

            pilaR = new List<AFN>();
        }
        #endregion
        public void buscaCaracter(string exprecionPostfija)
        {
            //segun los contadores vemos que tiene y mandamos a la operacion 
            foreach (char caracter in exprecionPostfija)
            {
                //Caso de la carradura Klenne
                if (caracter == '*')
                {
                    CerraduradeKleene();
                }
                //caso de la cerradura positiva
                else if (caracter == '+')
                {
                    CerraduraPositiva();
                }
                //Caso de cero y una instancia
                else if (caracter == '?')
                {
                    CeroInstancia();
                }
                //Caso de Or
                else if (caracter == '|')
                {
                    Genera_Union();
                }
                //Caso de la Concatenación 
                else if (caracter == '&')
                {
                    Concatenacion();
                }
                //En caso de no haber encontrado nada mete directamente al Automata
                else
                {
                    AFN nuevo = new AFN();
                    nuevo.Genera_VAFN(caracter.ToString());
                    pilaR.Add(nuevo);
                }
            }
        }

        public void CerraduradeKleene()
        {
            int topePila = pilaR.Count - 1;
            AFN tope = pilaR[topePila];
            AFN nuevo = new AFN(tope, null, "*");
            pilaR.RemoveAt(topePila);
            pilaR.Add(nuevo);
        }

        public void CerraduraPositiva()
        {
            int topePila = pilaR.Count - 1;
            AFN tope = pilaR[topePila];
            AFN nuevo = new AFN(tope, null, "+");
            pilaR.RemoveAt(topePila);
            pilaR.Add(nuevo);
        }

        public void CeroInstancia()
        {
            int topePila = pilaR.Count - 1;
            AFN tope = pilaR[topePila];
            AFN nuevo = new AFN(tope, null, "?");
            pilaR.RemoveAt(topePila);
            pilaR.Add(nuevo);
        }

        void Genera_Union()
        {
            int topePila = pilaR.Count - 1;
            AFN derecha = pilaR[topePila];
            AFN izquierda = pilaR[topePila - 1];

            AFN nuevo = new AFN(izquierda, derecha, "union");

            pilaR.RemoveAt(topePila);
            pilaR.RemoveAt(topePila - 1);
            pilaR.Add(nuevo);
        }

        void Concatenacion()
        {
            int topePila = pilaR.Count - 1;
            AFN derecha = pilaR[topePila];
            AFN izquierda = pilaR[topePila - 1];
            AFN nuevo = new AFN(izquierda, derecha, "concatenacion");
            pilaR.RemoveAt(topePila);
            pilaR.RemoveAt(topePila - 1);
            pilaR.Add(nuevo);
        }

        public void AsignaNum()
        {
            int cont = 0;
            //Recorremos el ciclo para asignale el numero a cada una de las bolitas dek AFN que se generaron
            foreach (CEstado es in pilaR[0].Estados)
            {
                if (es.tipo == 0)
                {
                    es.id = 0;
                    continue;
                }
                if (es.tipo == 2)
                {
                    es.id = pilaR[0].Estados.Count - 1;
                    continue;
                }
                else
                {
                    es.id = ++cont;
                }
            }
            //Ordenamos por el numero de id
            pilaR[0].Estados = pilaR[0].Estados.OrderBy(x => x.id).ToList();
        }

        public void otr(string exprecion)
        {
            #region
            string l = exprecion.Replace("&", "");
            l = l.Replace("|", "");
            l = l.Replace("?", "");
            l = l.Replace("+", "");
            l = l.Replace("*", "");
            l += "ε";
            var lt = new HashSet<char>(l);

            AFN lastAFN = pilaR[0];
            #endregion
            foreach (CEstado es in lastAFN.Estados)
            {
                foreach (char unCaracter in lt)
                {
                    List<int> temp = new List<int>();
                    foreach (CTransicion tr in lastAFN.trans)
                    {
                        if (tr.letra == unCaracter.ToString())
                        {
                            if (es.id == tr.origen.id)
                            {
                                temp.Add(tr.destino.id);
                            }
                        }
                    }
                    es.Tr.Add(temp);
                }
            }
        }
    }
}
