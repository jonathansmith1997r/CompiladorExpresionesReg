using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Compiladores
{
    public partial class Analizador : Form
    {
        AFN1 afn;//Variable para generar el AFN
        AFD2 afd;//Variable para generar el AFD

        List<string> Reservadas = new List<string>();
        List<string> Simbolos = new List<string>();
        List<Produccion> Producciones;
        List<List<Produccion>> Estados;
        // List<CTransicion> lr0;
        List<Produccion> gTiny;
        List<string> sGram;
        List<string> nTerm;
        List<string> Term;
        CLR0 lr0;
        List<string> lexico;





        bool archivoOp;

        public Analizador()
        {
            InitializeComponent();

        }

        /*----------------------------------------------------------------------------------------
         *Avance de proyecto 0
         */
        /*
         * Boton "abrir" sirve para abrir un archivo el cual se selecciona desde una ventana emergente
         * y se despliega el contenido dentro un textbox
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string sPFN;//Variable para guardar el pathfile
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "Archivo de texto (*.txt)|*.txt";
            DialogResult win = oFile.ShowDialog();
            if (win == DialogResult.OK)
            {
                sPFN = oFile.FileName;
                tbExprReg.Text = File.ReadAllText(sPFN);
                archivoOp = true;
            }
            //tbExprReg.ReadOnly = true;
        }

        /*----------------------------------------------------------------------------------------
         *Avance de proyecto 1
         */

        private void bExprReg_Click(object sender, EventArgs e)
        {
            string temp;
            string newString;
            string lacadena;


            Posfija expR = new Posfija();
            temp = tbExprReg.Text;
            newString = temp.Replace(" ", String.Empty);
            lacadena = Regex.Replace(newString, @"\)\[", ") [");

            expR.ConvierteExplicita(lacadena);
            expR.ConviertePosfija();
            textBox2.Text = expR.pos.ToString();
            tbPosfija.Text = expR.posfija.ToString();


            //tbPosfija.Text = expR.getPosfija;
        }

        private void tbPosfija_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAFN_Click(object sender, EventArgs e)
        {
            afn = new AFN1();
            afn.buscaCaracter(tbPosfija.Text);
            afn.AsignaNum();
            afn.otr(tbPosfija.Text);
            LLenaT(afn);
        }
        public void LLenaT(AFN1 afn)
        {
            dgvAFN.DataSource = null;
            dgvAFN.Rows.Clear();
            dgvAFN.Columns.Clear();
            //Reemplazamos todos los operadores por espacios 
            #region Reemplazamos
            string lr = tbPosfija.Text.Replace("&", "");
            lr = lr.Replace("|", "");
            lr = lr.Replace("?", "");
            lr = lr.Replace("+", "");
            lr = lr.Replace("*", "");
            lr += "ε";
            var lenguajetemp = new HashSet<char>(lr);
            #endregion
            //ciclo para poner cuales son las transiciones
            dgvAFN.Columns.Add("Estado", "Estado/TR");
            foreach (char c in lenguajetemp)
            {
                dgvAFN.Columns.Add(c.ToString(), c.ToString());

            }

            //Ciclo para llenar cada uno de los campos con las tranciones 
            foreach (CEstado estado in afn.pilaR[0].Estados)
            {
                List<string> fila = new List<string>();
                fila.Add(estado.id.ToString());
                foreach (List<int> conjunto in estado.Tr)
                {
                    string temp = "{";
                    foreach (int elemento in conjunto)
                    {
                        if (temp != "{")
                            temp += ",";
                        temp += elemento.ToString();
                    }
                    if (temp == "{")
                    {
                        fila.Add("Φ");
                    }
                    else
                    {
                        temp += "}";
                        fila.Add(temp);
                    }
                }
                dgvAFN.Rows.Add(fila.ToArray());
            }
            int elementos = lenguajetemp.Count * afn.pilaR[0].Estados.Count;
            dgvAFN.AutoResizeColumns();

        }

        private void dgvAFN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            afd = new AFD2(afn.pilaR.Last());
            afd.GeneraAFD(tbPosfija.Text);
            llenaDGVAFD(afd);
        }
        string traduce(int cont)
        {
            string letra;

            letra = (Convert.ToChar(65 + cont).ToString());

            return letra;
        }
        private void llenaDGVAFD(AFD2 afn)
        {
            dgvAFD.DataSource = null;
            dgvAFD.Rows.Clear();
            dgvAFD.Columns.Clear();

            string lr = tbPosfija.Text.Replace("&", "");
            lr = lr.Replace("|", "");
            lr = lr.Replace("?", "");
            lr = lr.Replace("+", "");
            lr = lr.Replace("*", "");
            var lenguajetemp = new HashSet<char>(lr);
            string ordenado = new String(lenguajetemp.OrderBy(x => x).ToArray());
            dgvAFD.Columns.Add("Estado", "Estado/TR");
            foreach (char c in ordenado)
            {
                dgvAFD.Columns.Add(c.ToString(), c.ToString());
            }
            int cont = 0;
            string etiqueta;
            foreach (CEstado estado in afn.Estados)
            {
                etiqueta = traduce(cont);
                cont++;
                List<string> fila = new List<string>();
                fila.Add(etiqueta);//estado.id.ToString());
                foreach (char c in ordenado)
                {
                    string temp = "0";
                    foreach (CTransicion transicion in afn.trans)
                    {

                        if (estado.id == transicion.origen.id && transicion.letra == c.ToString())
                        {
                            for (int i = 0; i < afn.Estados.Count; i++)
                            {
                                if (transicion.destino.id == afn.Estados[i].id)
                                {
                                    temp = traduce(i);
                                    break;
                                }
                            }
                        }
                    }
                    fila.Add(temp);
                }
                dgvAFD.Rows.Add(fila.ToArray());
            }
            //int elementos = lenguajetemp.Count * afn.pilaR[0].LEstados.Count;

            dgvAFD.AutoResizeColumns();
        }
        public string buildGramatica()
        {
            string lenguaje = tbTiny.Text.Replace(Environment.NewLine, " ");
            foreach (string s in Simbolos)
            {
                if (s != "=")
                    lenguaje = lenguaje.Replace(s, " " + s + " ");
                else
                    lenguaje = lenguaje.Replace(s, s + " ");
            }
            string lenguaje2 = "";
            for (int i = 0; i < lenguaje.Length; i++)
            {
                if (lenguaje[i] != ' ')
                {
                    if (lenguaje[i] == '=' && lenguaje2.Length > 0)
                    {
                        if (lenguaje2[lenguaje2.Length - 1] != ':' && lenguaje2[lenguaje2.Length - 1] != ' ')
                            lenguaje2 += " ";
                    }
                    lenguaje2 += lenguaje[i];
                }
                else if (lenguaje[i] == ' ' && lenguaje2.Length > 0)
                {
                    if (lenguaje2[lenguaje2.Length - 1] != ' ')
                        lenguaje2 += " ";
                }

            }
            string[] progra = lenguaje2.Trim().Split();
            lenguaje2 = "";
            foreach (string s in progra)
            {
                if (s.Trim() != "")
                    lenguaje2 += s.Trim() + " ";
            }
            return lenguaje2.Trim();
        }

        private void Analizador_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             lexico = new List<string>();
            CargaListas();
            string[] codelx = buildGramatica().Split();
            foreach (string palabra in codelx)
            {
                if (Reservadas.Contains(palabra))
                {
                    lexico.Add(palabra);
                }
                else if (Simbolos.Contains(palabra))
                {
                    lexico.Add(palabra);
                }
                else if (Validar(palabra, tbIdentificador.Text))
                {
                    lexico.Add("identificador");

                }
                else if (Validar(palabra, tbNum.Text))
                {
                    lexico.Add("numero");
                }
                else
                {
                    lexico.Add("Error léxico");
                }
            }
            llenaTokens(codelx, lexico);

        }
        public void CargaListas()
        {
            Reservadas.Add("if");
            Reservadas.Add("then");
            Reservadas.Add("else");
            Reservadas.Add("end");
            Reservadas.Add("repeat");
            Reservadas.Add("until");
            Reservadas.Add("read");
            Reservadas.Add("write");
            Simbolos.Add("+");
            Simbolos.Add("-");
            Simbolos.Add("*");
            Simbolos.Add("/");
            Simbolos.Add("=");
            Simbolos.Add("<");
            Simbolos.Add(">");
            Simbolos.Add("(");
            Simbolos.Add(")");
            Simbolos.Add(";");
            Simbolos.Add(":=");
        }
        public bool Validar(string pr, string exPR)
        {
            Posfija posf = new Posfija();
            posf.pos2 = exPR;
            posf.ConvierteExplicita(posf.pos2);
            posf.ConviertePosfija();
            string postfija2 = "";
            postfija2 = posf.posfija;
            AFN1 afn = new AFN1();
            afn.buscaCaracter(postfija2);
            afn.AsignaNum();
            afn.otr(postfija2);
            AFD2 afd = new AFD2(afn.pilaR.Last());
            afd.GeneraAFD(postfija2);
            if (afd.Valida(pr))
                return true;
            else
                return false;

        }
        public void llenaTokens(string[] programa, List<string> lexico)
        {
            dGVtokens.DataSource = null;
            dGVtokens.Rows.Clear();
            dGVtokens.Columns.Clear();
            dGVtokens.Columns.Add("Nombre", "Nombre");
            dGVtokens.Columns.Add("Lexema", "Lexema");
            int x = 0;
            for (int i = 0; i < programa.Length; i++)
            {
                dGVtokens.Rows.Add(lexico[i], programa[i]);
                x++;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (tbValidar.Text != "")
            {
                string temp;
                string newString;
                string lacadena;


                Posfija expR = new Posfija();
                temp = tbExprReg.Text;
                newString = temp.Replace(" ", String.Empty);
                lacadena = Regex.Replace(newString, @"\)\[", ") [");

                expR.ConvierteExplicita(lacadena);
                expR.ConviertePosfija();
                textBox2.Text = expR.pos.ToString();
                tbPosfija.Text = expR.posfija.ToString();

                afn = new AFN1();
                afn.buscaCaracter(tbPosfija.Text);
                afn.AsignaNum();
                afn.otr(tbPosfija.Text);
                LLenaT(afn);

                afd = new AFD2(afn.pilaR.Last());
                afd.GeneraAFD(tbPosfija.Text);
                llenaDGVAFD(afd);

                if (afd.Valida(tbValidar.Text))
                {
                    MessageBox.Show("Si Pertenece al lenguaje");
                }
                else
                {
                    MessageBox.Show("No pertenece al lenguaje");
                }

            }
            else
            {
                MessageBox.Show("Inserte un lexema valido");
            }



        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            lr0 = new CLR0();
            lr0.GeneraAFDLR0();
            listBox1.Items.Clear();
            foreach (List<Produccion> estado in lr0.Estados)
            {

                listBox1.Items.Add("\t\t\t" + "I" + lr0.Estados.IndexOf(estado).ToString() + "\n");
                //x cada estado
                foreach (Produccion produccion in estado)
                {
                    if (produccion.Cuerpo.Contains("."))
                    {
                        count++;
                        
                        listBox1.Items.Add(produccion.Encabezado + "->" + produccion.Cuerpo);
                    }
                    else
                    {
                        count++;
                        listBox1.Items.Add(produccion.Encabezado + "->" + produccion.Cuerpo + ".");
                    }
                }
                listBox1.Items.Add("----------------------------------------- ");
            }
            label9.Text = count.ToString();
            LlenaDGVTR();
            //LlenaDGVLR0();
            LLenaTablaAccion();
            LLenaTablaIrA();

        }

        private void LR0build()
        {

        }
        /*
        public void PreparaTiny()
        {
            string[] q1 = { "-","(",")","*",":=","/",";","+","<","=",">",
            "identificador","read","end","if","numero","repeat","else","then","until","write"};
            foreach (string s in q1)
                sGram.Add(s);
            foreach (string sim in sGram)
                Term.Add(sim);
            Term.Add("$");
            string[] q2 = {"sent-if","sent-repeat","sent-assign","sent-read","exp","factor","sent-write","exp-simple",
                "op-comp","opsuma","term","opmult","programa","secuencia-sent","sentencia"};
            foreach (string s in q2)
                sGram.Add(s);
            foreach(string sim in sGram)
            {
                if (!Term.Contains(sim))
                    nTerm.Add(sim);
            }
        }
*/
        

        public void LlenaDGVTR()
        {
            dgvlr0.DataSource = null;
            dgvlr0.Rows.Clear();
            dgvlr0.Columns.Clear();

            dgvlr0.Columns.Add("Estado", "Estado");
            foreach (string c in lr0.SimbolosGramaticales)
            {
                dgvlr0.Columns.Add(c.ToString(), c.ToString());
            }

            List<string> fila = new List<string>();
            for (int i = 0; i < lr0.Estados.Count; i++)
            {
                fila.Clear();
                fila.Add("I" + i.ToString());
                foreach (string c in lr0.SimbolosGramaticales)
                {
                    string llenado = "";
                    foreach (CTransicion trans in lr0.lr0)
                    {
                        if (trans.origen.id == i && trans.letra == c)
                            llenado =""+ trans.destino.id;
                    }
                    if (llenado == "")
                        fila.Add("Φ");
                    else
                        fila.Add(llenado);

                }

                dgvlr0.Rows.Add(fila.ToArray());
            }
            dgvlr0.AutoResizeColumns();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        

        public void LLenaTablaAccion()
        {
            dgvTabla.DataSource = null;
            dgvTabla.Rows.Clear();
            dgvTabla.Columns.Clear();

            string[][] Accion = lr0.TablaAccion();
            string[][] ir_A = lr0.TablaIr_A();

            dgvTabla.Columns.Add("Estado", "Estado");
            foreach (string c in lr0.SimbolosGramaticales)
            {
                dgvTabla.Columns.Add(c.ToString(), c.ToString());
            }

            List<string> fila = new List<string>();
            for (int i = 0; i < lr0.Estados.Count; i++)
            {
                fila.Clear();
                fila.Add("I" + i.ToString());
                foreach (string c in lr0.SimbolosGramaticales)
                {
                    string llenado = "";
                    foreach (CTransicion trans in lr0.lr0)
                    {
                        if (trans.origen.id == i && trans.letra == c)
                            llenado = "I" + trans.destino.id;
                    }
                    if (llenado == "")
                        fila.Add("0");
                    else
                        fila.Add(llenado);
                }

                dgvTabla.Rows.Add(fila.ToArray());
            }
            dgvTabla.AutoResizeColumns();
        }
        public void LLenaTablaIrA()
        {
            dgvTabla.DataSource = null;
            dgvTabla.Rows.Clear();
            dgvTabla.Columns.Clear();

            string[][] Accion = lr0.TablaAccion();
            string[][] ir_A = lr0.TablaIr_A();

            dgvTabla.Columns.Add("Estado", "Estado");
            foreach (string c in lr0.Terminales)
            {
                dgvTabla.Columns.Add(c.ToString(), c.ToString());
            }
            foreach (string c in lr0.NoTerminales)
            {
                dgvTabla.Columns.Add(c.ToString(), c.ToString());
            }

            List<string> fila = new List<string>();
            for (int i = 0; i < Accion.Length; i++)
            {
                fila.Clear();
                fila.Add("I" + i.ToString());
                foreach (string accion in Accion[i])
                {
                    if (accion == "N")
                        fila.Add("0");
                    else
                        fila.Add(accion);
                }
                foreach (string ira in ir_A[i])
                {
                    if (ira == "N")
                        fila.Add("0");
                    else
                        fila.Add(ira);
                }
                dgvTabla.Rows.Add(fila.ToArray());
            }
            dgvTabla.AutoResizeColumns();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] Lexema = buildGramatica().Split();
            Analisis_Sintactico();
            List<string> Nombre = lexico;///Analisis lexico
            if (Nombre.Contains("Error léxico"))
            {
                lb_out.Text = "Se encontró uno o más\n errores en el programa.";
                lb_out.ForeColor = Color.Red;

                for (int j = 0; j < tbTiny.Lines.Length; j++)
                {
                    foreach (string aux in tbTiny.Lines[j].Split())
                    {
                        for (int i = 0; i < Nombre.Count; i++)
                        {
                            if (aux == Lexema[i] && Nombre[i] == "Error léxico")
                            {
                                listBox2.Items.Add("Línea " + (j + 1).ToString() + ". " + Lexema[i] + " no se reconoce.");
                                break;
                            }
                        }
                    }
                }
                return;
            }

            lb_out.Text = "El programa no contiene errores";
            lb_out.ForeColor = Color.Black;

            
            AnalisisSintactico(Nombre);
            
        }
        public void AnalisisSintactico(List<string> asAux)
        {

            List<Produccion> ProduAuxi = new List<Produccion>();
            treeView1.Nodes.Clear();

            int s = 0;
            string a = "";
            List<int> pila = new List<int>();
            pila.Add(0);
            string[][] Accion = lr0.TablaAccion();
            string[][] ir_A = lr0.TablaIr_A();
            MessageBox.Show(lexico.ToString());
            lexico.Add("$");
            a = lexico.First();
            int cont = 0;
            int band = 0;

            while (true)
            {
                int t;

                s = pila.Last();
               // MessageBox.Show(Accion[s][lr0.Terminales.IndexOf(a)].ToString());
                if (Accion[s][lr0.Terminales.IndexOf(a)].Contains("d"))
                {
                    t = int.Parse(Accion[s][lr0.Terminales.IndexOf(a)].Replace("d", ""));
                    pila.Add(t);
                    cont++;
                    a = asAux[cont];

                }
            
                else if (Accion[s][lr0.Terminales.IndexOf(a)].Contains("r"))
                {
                    Produccion A = lr0.Producciones[int.Parse(Accion[s][lr0.Terminales.IndexOf(a)].Replace("r", "")) - 1];
                    t = A.Cuerpo.Split().Length;
                    for (int i = 0; i < t; i++)

                        pila.RemoveAt(pila.Count - 1);
                    t = pila.Last();
                    pila.Add(int.Parse(ir_A[t][lr0.NoTerminales.IndexOf(A.Encabezado)]));
                    ProduAuxi.Add(A);
                }
                //Si encuentra la acetacion rompe el ciclo infinito
                else if (Accion[s][lr0.Terminales.IndexOf(a)].Contains("ac"))
                {


                    break;
                }
                ///Si  tiene un error
                else
                {
                    band = 1;
                    MessageBox.Show("Error Sintactico");
                    break;
                }
            }
            if (band != 1)
            {
                treeView1.Nodes.Clear();
                List<TreeNode> ln = new List<TreeNode>();
                //Ciclo para buscar las producciones 
                foreach (Produccion p in ProduAuxi)
                {
                    ///El arbol se genera iniciando por la cabecera del la produccion
                    TreeNode node = new TreeNode(p.Encabezado);
                    ///Quitamos el cuerpo de cada produccion
                    string[] cuerpo = p.Cuerpo.Split();
                    foreach (string c in cuerpo)
                    {
                        node.Nodes.Add(c);
                    }

                    if (ln.Count == 0)
                    {
                        ln.Add(node);
                        continue;
                    }
                    ///Ciclo que nos permite agregar los nodos al arbol y removerlos de la lista
                    for (int j = node.Nodes.Count - 1; j >= 0; j--)
                    {
                        for (int i = ln.Count - 1; i >= 0; i--)
                        {
                            if (node.Nodes[j].Text == ln[i].Text && node.Nodes[j].GetNodeCount(true) == 0)
                            {
                                foreach (TreeNode n in ln[i].Nodes)
                                    node.Nodes[j].Nodes.Add(n);
                                ln.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    ln.Add(node);

                }
                foreach (TreeNode n in ln)
                    treeView1.Nodes.Add(n);
                treeView1.ExpandAll();
            }


        }
        /*
        public void BuildTree(List<Produccion> pAux)
        {

            treeView1.Nodes.Clear();
            List<TreeNode> ln = new List<TreeNode>();
            foreach (Produccion p in pAux)
            {
                TreeNode node = new TreeNode(p.Encabezado);
                string[] cuerpo = p.Cuerpo.Split();
                foreach (string c in cuerpo)
                {
                    node.Nodes.Add(c);
                }
                if(ln.Count == 0)
                {
                    ln.Add(node);
                    continue;
                }
                for (int j = node.Nodes.Count - 1; j >= 0; j--)
                {
                    for (int i = ln.Count - 1; i >= 0; i--)
                    {
                        if (node.Nodes[j].Text == ln[i].Text && node.Nodes[j].GetNodeCount(true) == 0)
                        {
                            foreach (TreeNode n in ln[i].Nodes)
                                node.Nodes[j].Nodes.Add(n);
                            ln.RemoveAt(i);
                            break;
                        }
                    }
                }
                ln.Add(node);
            }
            foreach (TreeNode n in ln)
                treeView1.Nodes.Add(n);
            treeView1.ExpandAll();
        }
        */
        public void Analisis_Sintactico()
        {
            int counts = 0;
            lr0 = new CLR0();
            lr0.GeneraAFDLR0();
            listBox1.Items.Clear();
            foreach (List<Produccion> estado in lr0.Estados)
            {

                listBox1.Items.Add("\t\t\t" + "I" + lr0.Estados.IndexOf(estado).ToString() + "\n");
                //x cada estado
                foreach (Produccion produccion in estado)
                {
                    if (produccion.Cuerpo.Contains("."))
                    {
                        counts++;

                        listBox1.Items.Add(produccion.Encabezado + "->" + produccion.Cuerpo);
                    }
                    else
                    {
                        counts++;
                        listBox1.Items.Add(produccion.Encabezado + "->" + produccion.Cuerpo + ".");
                    }
                }
                listBox1.Items.Add("----------------------------------------- ");
            }
            label9.Text = counts.ToString();
            LlenaDGVTR();
            //LlenaDGVLR0();
            LLenaTablaAccion();
            LLenaTablaIrA();
        }

    } 

} 

