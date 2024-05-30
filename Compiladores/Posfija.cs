using System;
using System.Collections.Generic;
using System.Text;

namespace Compiladores
{
    class Posfija
    {
        public char cerrP = '+';//Cerradura Positiva
        public char cerrK = '*';//Cerradura de Kleen
        public char coriz = '[';//Corchete izquierdo
        public char parentiz = '(';//Parentesis izquierdo
        public char parentdr = ')';//Parentesis derecho
        public char punto = '.';//Cualquier caracter
        public char interroga = '?';//Cero y una instancia
        public char amper = '&';
        public char linea = '|';//Seleccion de alternativas
        public char cordr = ']';//Corchete derecho
        public char guion = '-';
        public int letra;//Es el contador de números de Letras de la cadena
        public int i;//Valor para recorrer los Letras en un for
        public bool cad = true;//Bander para saber si la cadena se va a poder convertir a postfija
        public bool bande = true;
        public char[] pila; // Inicializamos la pila utilizada para la conversion
        public int contV = 0;//Inicializamos el tope de la pila
        public string posfija; //Inicializamos la cadena donde guardamos modo posfija
        public string pos; //Inicializamos la cadena donde guardamos modo posfija
        public char esp = ' ';
        public int x = 0;
        public int c = 0;
        public string cadenita;
        public int z = 0;
        public string pos2;







        /*
        private bool prioridad(string operador , string tope)
        {
            bool aux = false;
            int o = lsOperadores.IndexOf(operador);
            int t = lsOperadores.IndexOf(tope);
            //Si el operador actual tiene mayor prioridad que el tope de la pila
            if (o < t)
            {
                aux = true;
            }
            return aux;
        }
        */
        /*
        private void listToString(List<string> aux)
        {
            foreach(var item in aux)
            {
                sPosfija += item;
                sPosfija += ' ';
            }
        }
        */

        public void ConvierteExplicita(string cadena)
        {
            letra = cadena.Length;
            i = 0;
            z = 0;
            c = 0;
            pos = null;
            while (i < letra)
            {
                if (cadena[i] == parentiz)
                {
                    pos = pos + parentiz;
                }
                if (cadena[i] == parentdr)
                {
                    pos = pos + parentdr;
                    if (i + 1 < cadena.Length)
                    {
                        if (cadena[i + 1] != parentdr && cadena[i + 1] != cerrK && cadena[i + 1] != cerrP && cadena[i + 1] != interroga && cadena[i + 1] != linea && cadena[i + 1] != parentiz && cadena[i + 1] != coriz)
                        {
                            pos = pos + amper;
                        }
                        if (cadena[i + 1] == coriz && cadena[i - 1] != linea || cadena[i + 1] == parentiz && cadena[i - 1] != linea)
                        {
                            pos = pos + amper;
                        }
                    }
                }
                if (cadena[i] == coriz)
                {
                    pos = pos + parentiz;
                    if (cadena[i + 2] != guion)
                    {
                        z = i + 1;
                        while (cadena[z] != cordr)
                        {

                            if (Char.IsLetter(cadena, z))
                            {
                                pos = pos + cadena[z];
                                if (cadena[z + 1] != cordr)
                                {
                                    pos = pos + linea;
                                }


                            }
                            if (Char.IsNumber(cadena, z))
                            {
                                pos = pos + cadena[z];
                                if (cadena[z + 1] != cordr)
                                {
                                    pos = pos + linea;
                                }
                            }

                            z++;
                        }
                        i = z;
                    }
                }
                if (cadena[i] == cordr)
                {
                    pos = pos + parentdr;
                    if (i < letra - 1)
                    {
                        if (cadena[i + 1] == coriz || cadena[i + 1] == parentiz)
                        {
                            pos = pos + amper;
                        }
                    }
                }
                if (cadena[i] == linea)
                {
                    pos = pos + linea;
                }
                if (cadena[i] == cerrP || cadena[i] == cerrK || cadena[i] == interroga)
                {
                    pos = pos + cadena[i];
                    if (i < letra - 1 && i > 0 && cadena[i + 1] != linea && cadena[i + 1] != parentdr && cadena[i + 1] != cordr)
                    {
                        pos = pos + amper;
                    }


                }
                if (cadena[i] == guion)
                {
                    numeracion(cadena[i - 1].ToString(), cadena[i + 1].ToString());
                }
                if (Char.IsLetter(cadena, i) || cadena[i] == punto)
                {
                    pos = pos + cadena[i];
                    if (i + 1 != cadena.Length)
                    {
                        if (Char.IsLetter(cadena, i + 1) || Char.IsNumber(cadena, i + 1) || cadena[i + 1] == parentiz || cadena[i + 1] == coriz || cadena[i + 1] == punto)
                        {
                            pos = pos + amper;
                        }
                    }
                }
                if (Char.IsNumber(cadena, i))
                {
                    pos = pos + cadena[i];
                    if (i + 1 != cadena.Length)
                    {
                        if (Char.IsLetter(cadena, i + 1) || Char.IsNumber(cadena, i + 1) || cadena[i + 1] == parentiz || cadena[i + 1] == coriz)
                        {
                            pos = pos + amper;
                        }
                    }
                }

                i++;
            }


        }
        public string numeracion(string c1, string c2)
        {
            int a = 0;
            int c = 0;
            char b = ' ';
            char d = ' ';
            if (Char.IsNumber(c1, 0))
            {
                a = int.Parse(c1);
                c = int.Parse(c2);
                a++;
                for (; a < c; a++)
                {
                    pos = pos + linea;
                    pos = pos + a.ToString();
                }
                pos = pos + linea;
            }


            if (Char.IsLetter(c1, 0))
            {
                b = char.Parse(c1);
                d = char.Parse(c2);
                b++;
                for (; b < d; b++)
                {
                    pos = pos + linea;
                    pos = pos + b.ToString();
                }
                pos = pos + linea;
            }
            return cadenita;
        }
        public void ConviertePosfija()
        {
            i = 0;
            c = 0;
            x = 0;
            int q = 0;
            posfija = null;
            pila = new char[pos.Length];
            for (int r = 0; r < pos.Length; r++)
            {
                pila[r] = esp;
            }
            while (x < pos.Length)
            {
                if (pos[x] == parentiz)
                {
                    if (z == 0)
                    {
                        pila[z] = parentiz;

                    }
                    if (z != 0 || pila[z] == parentiz)
                    {
                        z++;
                        pila[z] = parentiz;
                    }

                }
                if (pos[x] == parentdr)
                {
                    while (pila[z] != parentiz)
                    {
                        if (pila[z] != esp)
                        {
                            posfija = posfija + pila[z];
                        }
                        pila[z] = ' ';
                        z--;
                    }
                    if (pila[z] == parentiz)
                    {

                        pila[z] = ' ';
                        if (z > 0)
                        {
                            z--;
                        }
                    }
                }
                if (Char.IsLetter(pos, x) || Char.IsNumber(pos, x) || pos[x] == punto)
                {
                    posfija = posfija + pos[x];
                }
                if (pos[x] == cerrK || pos[x] == cerrP || pos[x] == interroga)
                {
                    if (pila[z] == esp || pila == null || pila[z] == parentiz || pila[z] == amper || pila[z] == linea)
                    {
                        if (pila[z] == esp)
                        {
                            pila[z] = pos[x];
                        }
                        else
                        {
                            z++;
                            pila[z] = pos[x];
                        }
                    }
                    else
                    {
                        if (pila[z] == cerrK || pila[z] == cerrP || pila[z] == interroga)
                        {
                            if (pila[z] != esp)
                            {
                                posfija = posfija + pila[z];
                            }
                            pila[z] = pos[x];
                        }
                        if (pila[z] == ' ' && pila[z - 1] != ' ')
                        {
                            posfija = posfija + pos[x];

                        }
                    }
                }
                if (pos[x] == amper)//Nivel 2
                {
                    if (pila[z] == esp || pila == null || pila[z] == parentiz || pila[z] == linea)
                    {
                        z++;
                        pila[z] = pos[x];

                    }
                    else
                    {
                        if (pila[z] == cerrK || pila[z] == cerrP || pila[z] == interroga || pila[z] == amper)
                        {
                            if (pila[z] != esp)
                            {
                                posfija = posfija + pila[z];
                            }
                            if (pila[z] == cerrK || pila[z] == cerrP || pila[z] == interroga)
                            {
                                if (z != 0 && pila[z - 1] == amper)
                                {
                                    posfija = posfija + amper;
                                    pila[z] = esp;
                                    z--;
                                }
                                else
                                {
                                    pila[z] = pos[x];
                                }
                            }
                            else
                            {
                                pila[z] = pos[x];

                            }
                        }
                    }
                }
                if (pos[x] == linea)//Nivel 2
                {
                    if (pila[z] == esp || pila == null || pila[z] == parentiz)
                    {

                        z++;
                        pila[z] = pos[x];
                    }
                    else
                    {
                        if (pila[z] == cerrK || pila[z] == cerrP || pila[z] == interroga || pila[z] == amper || pila[z] == linea)
                        {

                            if (pila[z - 1] == amper)
                            {
                                if (pila[z] != esp)
                                {
                                    posfija = posfija + pila[z];
                                }
                                z--;
                                if (pila[z] != esp)
                                {
                                    posfija = posfija + pila[z];
                                }
                                pila[z] = pos[x];
                            }
                            else
                            {
                                if (pila[z] == cerrK && pila[z - 1] == linea || pila[z] == cerrP && pila[z - 1] == linea || pila[z] == interroga && pila[z - 1] == linea)
                                {
                                    if (pila[z] != esp)
                                    {
                                        posfija = posfija + pila[z];
                                    }
                                    z--;
                                    if (pila[z] == linea)
                                    {
                                        if (pila[z] != esp)
                                        {
                                            posfija = posfija + pila[z];
                                        }
                                        pila[z] = pos[x];
                                    }
                                }
                                else
                                {
                                    if (pila[z] != esp)
                                    {
                                        posfija = posfija + pila[z];
                                    }
                                    pila[z] = pos[x];
                                }
                            }
                        }
                    }
                }

                x++;
            }
            while (z >= 0)
            {
                if (pila[z] != parentiz)
                {
                    if (pila[z] != esp)
                    {
                        posfija = posfija + pila[z];
                    }
                    z--;
                }
                else
                {
                    z--;
                }
            }
        }

    }
}