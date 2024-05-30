using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiladores
{
    public class AFN
    {
        public List<CEstado> Estados;
        public List<CTransicion> trans;
        public AFN()
        {
            Estados = new List<CEstado>();
            trans = new List<CTransicion>();
        }
        public AFN(AFN izquierda, AFN derecha, string accion)
        {
        
            Estados = new List<CEstado>();
            trans = new List<CTransicion>();
            if (accion == "*")
            {
                
                CEstado inicio = new CEstado();
                CEstado aceptacion = new CEstado();
               
                inicio.tipo = 0;
                aceptacion.tipo = 2;
                foreach (CEstado e in izquierda.Estados)
                {
                    if (e.tipo == 0)
                    {
                        inicio = e;
                    }
                    else if (e.tipo == 2)
                    {
                        aceptacion = e;
                    }
                }
                
                CTransicion paTraz = new CTransicion();
                paTraz.origen = aceptacion;
                paTraz.destino = inicio;
                this.trans.Add(paTraz);
                
                inicio = new CEstado();
                aceptacion = new CEstado();
                inicio.tipo = 0;
                aceptacion.tipo = 2;
                
                CTransicion epcilon = new CTransicion();
                epcilon.origen = inicio;
                epcilon.destino = aceptacion;
                this.trans.Add(epcilon);
               
                foreach (CEstado e in izquierda.Estados)
                {
                    if (e.tipo == 0) 
                    {
                        CTransicion NP = new CTransicion();
                        NP.origen = inicio;
                        NP.destino = e;
                        e.tipo = 1;
                        this.trans.Add(NP);
                    }
                    else if (e.tipo == 2)
                    {
                        CTransicion NF = new CTransicion();
                        NF.destino = aceptacion;
                        NF.origen = e;
                        e.tipo = 1;
                        this.trans.Add(NF);
                    }
                }
                
                this.Estados.Add(inicio);
                this.Estados.Add(aceptacion);
                this.trans.AddRange(izquierda.trans);
                this.Estados.AddRange(izquierda.Estados);
            }
            if (accion == "+")
            {
                
                CEstado inicio = new CEstado();
                CEstado aceptacion = new CEstado();
                inicio.tipo = 0;
                aceptacion.tipo = 2;
                
                foreach (CEstado e in izquierda.Estados)
                {
                    if (e.tipo == 0)
                    {
                        inicio = e;
                    }
                    else if (e.tipo == 2)
                    {
                        aceptacion = e;
                    }
                }
                
                CTransicion paTraz = new CTransicion();
                paTraz.origen = aceptacion;
                paTraz.destino = inicio;
                this.trans.Add(paTraz);
                inicio = new CEstado();
                aceptacion = new CEstado();
                inicio.tipo = 0;
                aceptacion.tipo = 2;

                foreach (CEstado e in izquierda.Estados)
                {
                    if (e.tipo == 0)
                    {
                        CTransicion NP = new CTransicion();
                        NP.origen = inicio;
                        NP.destino = e;
                        e.tipo = 1;
                        this.trans.Add(NP);
                    }
                    else if (e.tipo == 2)
                    {
                        CTransicion NF = new CTransicion();
                        NF.destino = aceptacion;
                        NF.origen = e;
                        e.tipo = 1;
                        this.trans.Add(NF);
                    }
                }
                
                this.Estados.Add(inicio);
                this.Estados.Add(aceptacion);
                this.trans.AddRange(izquierda.trans);
                this.Estados.AddRange(izquierda.Estados);
            }
            if (accion == "?")
            {
                
                CEstado inicio = new CEstado();
                CEstado aceptacion = new CEstado();
                
                inicio.tipo = 0;
                aceptacion.tipo = 2;
                
                CTransicion epcilon = new CTransicion();
                epcilon.origen = inicio;
                epcilon.destino = aceptacion;
                this.trans.Add(epcilon);

                foreach (CEstado e in izquierda.Estados)
                {
                    if (e.tipo == 0)
                    {
                        CTransicion NP = new CTransicion();
                        NP.origen = inicio;
                        NP.destino = e;
                        e.tipo = 1;
                        this.trans.Add(NP);
                    }
                    else if (e.tipo == 2)
                    {
                        CTransicion NF = new CTransicion();
                        NF.destino = aceptacion;
                        NF.origen = e;
                        e.tipo = 1;
                        this.trans.Add(NF);
                    }
                }
               
                this.Estados.Add(inicio);
                this.Estados.Add(aceptacion);
                this.trans.AddRange(izquierda.trans);
                this.Estados.AddRange(izquierda.Estados);
            }
            if (accion == "union")
            {
                
                CEstado inicio = new CEstado();
                CEstado aceptacion = new CEstado();
               
                inicio.tipo = 0;
                aceptacion.tipo = 2;
                
                foreach (CTransicion t in derecha.trans)
                {
                    this.trans.Add(t);
                }
                foreach (CEstado e in derecha.Estados)
                {
                    this.Estados.Add(e);
                }
                foreach (CTransicion t in izquierda.trans)
                {
                    this.trans.Add(t);
                }
                foreach (CEstado e in izquierda.Estados)
                {
                    this.Estados.Add(e);
                }
                
                foreach (CEstado e in this.Estados)
                {
                    if (e.tipo == 0)
                    {
                        CTransicion NP = new CTransicion();
                        NP.origen = inicio;
                        NP.destino = e;
                        e.tipo = 1;
                        this.trans.Add(NP);
                    }
                    else if (e.tipo == 2)
                    {
                        CTransicion NF = new CTransicion();
                        NF.destino = aceptacion;
                        NF.origen = e;
                        e.tipo = 1;
                        this.trans.Add(NF);
                    }
                }
                this.Estados.Add(inicio);
                this.Estados.Add(aceptacion);
            }
            if (accion == "concatenacion")
            {
                
                Estados = new List<CEstado>();
                trans = new List<CTransicion>();
                int comienzo;
               
                for (comienzo = 0; comienzo < derecha.Estados.Count; comienzo++)
                {
                    if (derecha.Estados[comienzo].tipo == 0)
                    {
                        
                        for (int i = izquierda.trans.Count - 1; i >= 0; i--)
                        {
                            if (izquierda.trans[i].destino.tipo == 2)
                            {
                                izquierda.trans[i].destino = derecha.Estados[comienzo];
                            }
                        }
                        break;
                    }
                }
                derecha.Estados[comienzo].tipo = 1;
                for (int i = 0; i < izquierda.Estados.Count; i++)
                {
                    if (izquierda.Estados[i].tipo == 2)
                    {
                        izquierda.Estados.RemoveAt(i);
                        break;
                    }
                }
             
                foreach (CEstado e in derecha.Estados)
                    this.Estados.Add(e);
                foreach (CTransicion t in derecha.trans)
                    this.trans.Add(t);
                foreach (CEstado e in izquierda.Estados)
                    this.Estados.Add(e);
                foreach (CTransicion t in izquierda.trans)
                    this.trans.Add(t);
            }
        }
        public void Genera_VAFN(string transicion)
        {
            CEstado origen = new CEstado();
            CEstado destino = new CEstado();
            origen.tipo = 0;
            destino.tipo = 2;
            Estados.Add(origen);
            Estados.Add(destino);

            CTransicion nueva = new CTransicion();
            nueva.origen = origen;
            nueva.destino = destino;
            nueva.letra = transicion;
            trans.Add(nueva);
        }
        public int EAceptacion()
        {
            foreach (CEstado es in Estados)
            {
                if (es.tipo == 2)
                    return es.id;
            }
            return -1;
        }
    }
}
