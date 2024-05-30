using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Compiladores
{
    class AFD2
    {
        
        public List<CEstado> Estados;
        public List<CTransicion> trans;
        AFN aux;
        public AFD2(AFN aux)
        {
            this.aux = aux;
            Estados = new List<CEstado>();
            trans = new List<CTransicion>();
        }
        
        public void GeneraAFD(string posfija)
        {
            #region
            string l = posfija;
            l = l.Replace("&", "");
            l = l.Replace("|", "");
            l = l.Replace("?", "");
            l = l.Replace("+", "");
            l = l.Replace("*", "");
            var lenguajetemp = new HashSet<char>(l);
            #endregion
            List<CTransicion> Transiciones = new List<CTransicion>();
            List<List<int>> DEstados = new List<List<int>>();
            List<int> T = new List<int>();
            DEstados.Add(T);
            T.Add(0);
            CeEp(aux, 0, T);
            List<List<int>> auxDEstados = new List<List<int>>();
            CEstado nuevoEstado;
            while (DEstados.Count > 0)
            {
                auxDEstados.Add(DEstados[0]);
                nuevoEstado = new CEstado();
                nuevoEstado.id = DEstados[0][0];
                Estados.Add(nuevoEstado);
                DEstados.RemoveAt(0);
                foreach (char c in lenguajetemp)
                {
                    List<int> resMover = mov(auxDEstados.Last(), c);
                    int contador = 0;
                    if (resMover.Count > 0)
                    {
                        contador++;
                        List<int> U = new List<int>();
                        foreach (int mov in resMover)
                        {
                            U.Add(mov);
                            CeEp(aux, mov, U);
                        }
                        if (!exEs(auxDEstados, U) && !exEs(DEstados, U))
                        {
                            DEstados.Add(U);
                        }
                        CTransicion nuevaTransicion = new CTransicion();
                        nuevaTransicion.origen.id = auxDEstados.Last()[0];
                        nuevaTransicion.destino.id = U[0];
                        nuevaTransicion.letra = c.ToString();
                        trans.Add(nuevaTransicion);
                    }
                }
            }
            int indiceAceptacion = aux.EAceptacion();
            foreach (List<int> unEstado in auxDEstados)
            {
                foreach (int unId in unEstado)
                {
                    if (unId == indiceAceptacion)
                    {
                        foreach (CEstado a in Estados)
                        {
                            if (unEstado[0] == a.id)
                                a.tipo = 2;
                        }
                        break;
                    }
                }
            }
        }
        void CeEp(AFN ax, int inicio, List<int> T)
        {
           
            foreach (CTransicion a in ax.trans)
            {
                if (a.origen.id == inicio && a.letra == "ε")
                {
                    if (!T.Contains(a.destino.id))
                    {
                        T.Add(a.destino.id);
                        CeEp(ax, a.destino.id, T);
                    }
                }
            }
        }
        List<int> mov(List<int> T, char simbolo)
        {
            List<int> conjunto = new List<int>();

            foreach (int inicio in T)
            {
                foreach (CTransicion a in aux.trans)
                {
                    if (a.letra == simbolo.ToString() && a.origen.id == inicio)
                    {
                        conjunto.Add(a.destino.id);

                    }
                }
            }
            return conjunto;
        }

        Boolean exEs(List<List<int>> Estados, List<int> U)
        {
            List<int> auxU = new List<int>();
            foreach (int u in U)
                auxU.Add(u);
            auxU = auxU.OrderBy(x => x).ToList();
            foreach (List<int> es in Estados)
            {
                List<int> temp = new List<int>();
                foreach (int e in es)
                    temp.Add(e);
                temp = temp.OrderBy(x => x).ToList();
                if (temp.Count == auxU.Count)
                {
                    bool comprueba = true;
                    for (int i = 0; i < auxU.Count; i++)
                    {
                        if (temp[i] != auxU[i])
                        {
                            comprueba = false;
                            break;
                        }
                    }
                    if (comprueba)
                        return true;
                }
            }
            return false;
        }
        public bool Valida(string cadena)
        {
            
            CEstado origen;
            bool next = false;
            
            origen = trans[0].origen;
            
            for (int cont = 0; cont < cadena.Length; cont++)
            {
                next = false;
                
                foreach (CTransicion t in trans)
                {

                    if (origen.id == t.origen.id && t.letra == cadena[cont].ToString())
                    {
                        origen = t.destino;
                        next = true;
                        if (cont == cadena.Length - 1)
                        {
                            foreach (CEstado e in Estados)
                            {
                                if (t.destino.id == e.id && e.tipo == 2)
                                    return true;
                            }
                        }
                        break;
                    }
                }
                if (!next)
                    return false;
            }
            return false;
        }
        
    }

}
