using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Compiladores
{
    class CLR0
    {

        public List<Produccion> Producciones { get; set; }
        public List<List<Produccion>> Estados { get; set; }
        public List<string> SimbolosGramaticales { get; set; }
        public List<CTransicion> lr0 { get; set; }
        public List<Produccion> GramaticaTiny;
        public List<string> Terminales { get; set; }
        public List<string> NoTerminales { get; set; }

        public CLR0()
        {
            Producciones = new List<Produccion>();
            Estados = new List<List<Produccion>>();
            SimbolosGramaticales = new List<string>();
            GramaticaTiny = new List<Produccion>();
            Terminales = new List<string>();
            lr0 = new List<CTransicion>();
            Produccion temp = new Produccion();

            GeneraGramatica();
            SimbolosGramaticales.Clear();
            NoTerminales = new List<string>();
            PreparaTiny();
            Producciones = GramaticaTiny;


        }

        public void PreparaTiny()
        {
            string[] q1 = { "-", "(", ")", "*", ":=", "/", ";", "+", "<", "=", ">" };
            string[] q2 = { "identificador", "read", "end", "if", "numero", "repeat", "else", "then", "until", "write" };
            string[] q3 = {"sent-if","sent-repeat","sent-assign","sent-read","exp","factor","sent-write","exp-simple",
                "op-comp","opsuma","term","opmult","programa","secuencia-sent","sentencia"};
            foreach (string st in q1)
                SimbolosGramaticales.Add(st);

            foreach (string st in q2)
                SimbolosGramaticales.Add(st);
            foreach (string sim in SimbolosGramaticales)
                Terminales.Add(sim);
            Terminales.Add("$");
            foreach (string sim in q3)
                SimbolosGramaticales.Add(sim);
            foreach (string sim in SimbolosGramaticales)
            {
                if (!Terminales.Contains(sim))
                {
                    NoTerminales.Add(sim);
                }
            }
        }

        public string[][] TablaIr_A()
        {
            string[][] ir_A = new string[Estados.Count][];
            int k = 0;
            
            foreach (List<Produccion> I in Estados)
            {
                ir_A[k] = new string[NoTerminales.Count];
                
                foreach (Produccion i in I)
                {
                    foreach (CTransicion trans in lr0)
                    {
                        foreach (string NTerminal in NoTerminales)
                        {
                            if (trans.letra == NTerminal && trans.origen.id == Estados.IndexOf(I))
                            {
                                ir_A[k][NoTerminales.IndexOf(NTerminal)] = trans.destino.id.ToString();
                            }
                        }
                    }
                }
                k++;
            }

            for (int i = 0; i < ir_A.Length; i++)
            {
                for (int j = 0; j < ir_A[i].Length; j++)
                {
                    if (ir_A[i][j] == null)
                    {
                        ir_A[i][j] = "N";
                    }
                }
            }
            return ir_A;
        }

        public string[][] TablaAccion()
        {
           
            List<string> accion = new List<string>();
            string[][] Accion = new string[Estados.Count][];
            int k = 0;
            foreach (List<Produccion> I in Estados)
            {
                Accion[k] = new string[Terminales.Count];
                foreach (Produccion i in I)
                {
                    int c = 0;
                    if (i.Cuerpo.Contains("."))
                        foreach (string a in Terminales)
                        {

                            if (a == "exp" && i.Cuerpo.Contains(".exp-simple")) ;
                            else if (i.Cuerpo.Contains("." + a))
                            {
                                foreach (CTransicion trans in lr0)
                                {
                                    if (trans.origen.id == Estados.IndexOf(I) && trans.letra == a)
                                    {
                                        //Generamos el desplazar
                                        Accion[k][c] = "d" + trans.destino.id;
                                    }
                                }
                            }

                            c++;
                        }
                    //Generamos el Reducir
                    else if (i.PuntoFinal && i.Encabezado != "S'")
                    {
                        foreach (string s in i.Siguientes)
                        {

                            Accion[k][Terminales.IndexOf(s)] = "r" + i.numeroProduccion;
                        }

                    }
                    //Generamos el AC
                    else if (i.Encabezado == "S'" && i.PuntoFinal)
                    {
                        Accion[k][Terminales.Count - 1] = "ac";
                    }
                }
                k++;
            }
            //Sino es ninguno de los anteriores
            for (int i = 0; i < Accion.Length; i++)
            {
                for (int j = 0; j < Accion[i].Length; j++)
                {
                    if (Accion[i][j] == null)
                    {
                        Accion[i][j] = "N";
                    }
                }
            }
            return Accion;
        }

        public void GeneraAFDLR0()
        {
            //Generamos la produccion aumentada
            Produccion pAumentada = new Produccion();
            pAumentada.Encabezado = "S'";
            pAumentada.Cuerpo = ".programa";
            List<Produccion> I0 = new List<Produccion>();
            I0.Add(pAumentada);
            Estados.Add(Cerradura(I0));
            //generamos un ciclo que nos permite ir iterando entre ir_A y todos los simbolos gramaticales
            for (int I = 0; I < Estados.Count; I++)
            {
                //para cada simbolo gramatical hacemos una iteracion
                foreach (string X in SimbolosGramaticales)
                {
                    Ir_A(Estados[I], X);
                }
            }
        }

        public void Ir_A(List<Produccion> I, string X)
        {
            
            List<Produccion> J = new List<Produccion>();
           
            bool contiene = false;
            
            foreach (Produccion produccion in I)
            {
                
                if (X == "exp" && produccion.Cuerpo.Contains(".exp-simple")) ;
                
                else if (produccion.Cuerpo.Contains("." + X))
                {
                    
                    J.Add(ProduccionAux(produccion));
                    
                    J.Last().Cuerpo = J.Last().MuevePunto();
                    contiene = true;
                }
            }
            
            if (!contiene)
                return;
            
            List<bool> yaExite = new List<bool>();

            
            List<Produccion> nuevoEstado = Cerradura(J);
            
            for (int i = 0; i < nuevoEstado.Count(); i++)
                yaExite.Add(false);
            
            foreach (List<Produccion> estados in Estados)
            {

                for (int i = 0; i < nuevoEstado.Count(); i++)
                    yaExite[i] = false;
                foreach (Produccion produccion in estados)
                {
                    int i = 0;
                    
                    foreach (Produccion produaux in nuevoEstado)
                    {
                        
                        if (produccion.Encabezado == produaux.Encabezado && produccion.Cuerpo == produaux.Cuerpo)
                        {
                            yaExite[i] = true;
                            break;
                        }
                        i++;
                    }
                }
                bool existe = true;
                
                foreach (bool igual in yaExite)
                {
                    if (!igual)
                        existe = false;
                }
                
                if (existe)
                {
                    
                    CTransicion trans = new CTransicion();
                    trans.letra = X;
                    trans.origen = new CEstado(Estados.IndexOf(I));
                    trans.destino = new CEstado(Estados.IndexOf(estados));
                    lr0.Add(trans);
                    return;
                }
            }
            
            Estados.Add(nuevoEstado);
            CTransicion tran = new CTransicion();
            tran.letra = X;
            tran.origen = new CEstado(Estados.IndexOf(I));
            tran.destino = new CEstado(Estados.IndexOf(Estados.Last()));
            lr0.Add(tran);
        }

        public List<Produccion> Cerradura(List<Produccion> I)
        {
            
            List<Produccion> J = new List<Produccion>();
           
            foreach (Produccion produccion in I)
            {
               
                J.Add(ProduccionAux(produccion));
            }
            
            for (int i = 0; i < J.Count; i++)
            {
                
                if (J[i].PuntoFinal)

                    continue;
                
                foreach (Produccion produccion in Producciones)
                {
                    
                    string encuentra = "." + produccion.Encabezado;
                    if (encuentra == ".exp" && J[i].Cuerpo.Contains(".exp-simple")) ;
                    
                    else if (J[i].Cuerpo.Contains(encuentra))
                    {
                        
                        foreach (Produccion produccion1 in Producciones)
                        {
                            
                            if (produccion.Encabezado == produccion1.Encabezado)
                            {
                                bool ExisteProduccion = false;
                               
                                foreach (Produccion prodExiste in J)
                                {
                                    if (prodExiste.Encabezado == produccion1.Encabezado &&
                                        prodExiste.Cuerpo == "." + produccion1.Cuerpo)
                                    {
                                        ExisteProduccion = true;
                                        break;
                                    }
                                }
                                
                                if (!ExisteProduccion)
                                {
                                    J.Add(ProduccionAux(produccion1));
                                    J.Last().ponPunto();
                                }
                            }
                        }
                    }
                }
            }
            return J;
        }

        public Produccion ProduccionAux(Produccion p)
        {
            //igualacion de la produccion a una variable auxilia
            Produccion aux = new Produccion();
            aux.Encabezado = p.Encabezado;
            aux.Cuerpo = p.Cuerpo;
            aux.Primeros = p.Primeros;
            aux.Siguientes = p.Siguientes;
            aux.numeroProduccion = p.numeroProduccion;
            aux.numeroProduccion = p.numeroProduccion;
            aux.PuntoFinal = p.PuntoFinal;
            return aux;
        }

        void GeneraGramatica()
        {
            GramaticaTiny = new List<Produccion>();

            //programa -> secuencia-sent
            Produccion produccion = new Produccion();
            produccion.numeroProduccion = 1;
            produccion.Encabezado = "programa";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "secuencia-sent";
            List<string> primeros = new List<string>();
            primeros.Add("if");
            primeros.Add("repeat");
            primeros.Add("identificador");
            primeros.Add("read");
            primeros.Add("write");
            produccion.Primeros = primeros;
            List<string> siguientes = new List<string>();
            siguientes.Add("$");
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //secuencia-sent -> secuencia-sent ; sentencia | sentencia
            produccion = new Produccion();
            produccion.numeroProduccion = 2;
            produccion.Encabezado = "secuencia-sent";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "secuencia-sent ; sentencia";
            produccion.Primeros = primeros;
            siguientes = new List<string>();
            siguientes.Add("$");
            siguientes.Add(";");
            siguientes.Add("end");
            siguientes.Add("else");
            siguientes.Add("until");
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 3;
            produccion.Encabezado = "secuencia-sent";

            produccion.Cuerpo = "sentencia";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //sentencia -> sent-if | sent-repeat | sent-assign | sent-read | sent-write
            produccion = new Produccion();
            produccion.numeroProduccion = 4;
            produccion.Encabezado = "sentencia";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "sent-if";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 5;
            produccion.Encabezado = "sentencia";
            produccion.Cuerpo = "sent-repeat";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 6;
            produccion.Encabezado = "sentencia";
            produccion.Cuerpo = "sent-assign";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 7;
            produccion.Encabezado = "sentencia";
            produccion.Cuerpo = "sent-read";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 8;
            produccion.Encabezado = "sentencia";
            produccion.Cuerpo = "sent-write";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //sent-if -> if exp then secuencia-sent end | if exp then secuencia-sent else secuencia-sent end
            produccion = new Produccion();
            produccion.numeroProduccion = 9;
            produccion.Encabezado = "sent-if";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "if exp then secuencia-sent end";
            primeros = new List<string>();
            primeros.Add("if");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 10;
            produccion.Encabezado = "sent-if";
            produccion.Cuerpo = "if exp then secuencia-sent else secuencia-sent end";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //sent-repeat -> repeat secuencia-sent until exp
            produccion = new Produccion();
            produccion.numeroProduccion = 11;
            produccion.Encabezado = "sent-repeat";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "repeat secuencia-sent until exp";
            primeros = new List<string>();
            primeros.Add("repeat");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //sent-assign -> identificador := exp
            produccion = new Produccion();
            produccion.numeroProduccion = 12;
            produccion.Encabezado = "sent-assign";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "identificador := exp";
            primeros = new List<string>();
            primeros.Add("identificador");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //sent-read -> read identificador
            produccion = new Produccion();
            produccion.numeroProduccion = 13;
            produccion.Encabezado = "sent-read";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "read identificador";
            primeros = new List<string>();
            primeros.Add("read");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //sent-write -> write exp
            produccion = new Produccion();
            produccion.numeroProduccion = 14;
            produccion.Encabezado = "sent-write";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "write exp";
            primeros = new List<string>();
            primeros.Add("write");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //exp -> exp-simple op-comp exp-simple | exp-simple
            produccion = new Produccion();
            produccion.numeroProduccion = 15;
            produccion.Encabezado = "exp";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "exp-simple op-comp exp-simple";
            primeros = new List<string>();
            primeros.Add("(");
            primeros.Add("numero");
            primeros.Add("identificador");
            siguientes = new List<string>();
            siguientes.Add("then");
            siguientes.Add("$");
            siguientes.Add(";");
            siguientes.Add("end");
            siguientes.Add("else");
            siguientes.Add("until");
            siguientes.Add(")");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 16;
            produccion.Encabezado = "exp";
            produccion.Cuerpo = "exp-simple";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //op-comp -> < | > | =
            produccion = new Produccion();
            produccion.numeroProduccion = 17;
            produccion.Encabezado = "op-comp";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "<";
            primeros = new List<string>();
            primeros.Add("<");
            primeros.Add(">");
            primeros.Add("=");
            siguientes = new List<string>();
            siguientes.Add("(");
            siguientes.Add("numero");
            siguientes.Add("identificador");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 18;
            produccion.Encabezado = "op-comp";
            produccion.Cuerpo = ">";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 19;
            produccion.Encabezado = "op-comp";
            produccion.Cuerpo = "=";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //exp-simple -> exp-simple opsuma term | term
            produccion = new Produccion();
            produccion.numeroProduccion = 20;
            produccion.Encabezado = "exp-simple";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "exp-simple opsuma term";
            primeros = new List<string>();
            primeros.Add("(");
            primeros.Add("numero");
            primeros.Add("identificador");
            siguientes = new List<string>();
            siguientes.Add("<");
            siguientes.Add(">");
            siguientes.Add("=");
            siguientes.Add("then");
            siguientes.Add("$");
            siguientes.Add(";");
            siguientes.Add("end");
            siguientes.Add("else");
            siguientes.Add("until");
            siguientes.Add(")");
            siguientes.Add("+");
            siguientes.Add("-");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 21;
            produccion.Encabezado = "exp-simple";
            produccion.Cuerpo = "term";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //opsuma -> + | -
            produccion = new Produccion();
            produccion.numeroProduccion = 22;
            produccion.Encabezado = "opsuma";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "+";
            primeros = new List<string>();
            primeros.Add("+");
            primeros.Add("-");
            siguientes = new List<string>();
            siguientes.Add("(");
            siguientes.Add("numero");
            siguientes.Add("identificador");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 23;
            produccion.Encabezado = "opsuma";
            produccion.Cuerpo = "-";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //term -> term opmult factor | factor
            produccion = new Produccion();
            produccion.numeroProduccion = 24;
            produccion.Encabezado = "term";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "term opmult factor";
            primeros = new List<string>();
            primeros.Add("(");
            primeros.Add("numero");
            primeros.Add("identificador");
            siguientes = new List<string>();
            siguientes.Add("<");
            siguientes.Add(">");
            siguientes.Add("=");
            siguientes.Add("then");
            siguientes.Add("$");
            siguientes.Add(";");
            siguientes.Add("end");
            siguientes.Add("else");
            siguientes.Add("until");
            siguientes.Add(")");
            siguientes.Add("+");
            siguientes.Add("-");
            siguientes.Add("*");
            siguientes.Add("/");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 25;
            produccion.Encabezado = "term";
            produccion.Cuerpo = "factor";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //opmult -> * | /
            produccion = new Produccion();
            produccion.numeroProduccion = 26;
            produccion.Encabezado = "opmult";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "*";
            primeros = new List<string>();
            primeros.Add("*");
            primeros.Add("/");
            siguientes = new List<string>();
            siguientes.Add("(");
            siguientes.Add("numero");
            siguientes.Add("identificador");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 27;
            produccion.Encabezado = "opmult";
            produccion.Cuerpo = "/";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);

            //factor -> ( exp ) | numero | identificador
            produccion = new Produccion();
            produccion.numeroProduccion = 28;
            produccion.Encabezado = "factor";
            SimbolosGramaticales.Add(produccion.Encabezado);
            produccion.Cuerpo = "( exp )";
            primeros = new List<string>();
            primeros.Add("(");
            primeros.Add("numero");
            primeros.Add("identificador");
            siguientes = new List<string>();
            siguientes.Add("<");
            siguientes.Add(">");
            siguientes.Add("=");
            siguientes.Add("then");
            siguientes.Add("$");
            siguientes.Add(";");
            siguientes.Add("end");
            siguientes.Add("else");
            siguientes.Add("until");
            siguientes.Add(")");
            siguientes.Add("+");
            siguientes.Add("-");
            siguientes.Add("*");
            siguientes.Add("/");
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 29;
            produccion.Encabezado = "factor";
            produccion.Cuerpo = "numero";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
            produccion = new Produccion();
            produccion.numeroProduccion = 30;
            produccion.Encabezado = "factor";
            produccion.Cuerpo = "identificador";
            produccion.Primeros = primeros;
            produccion.Siguientes = siguientes;
            GramaticaTiny.Add(produccion);
        }
    }


}

