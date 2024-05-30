
namespace Compiladores
{
    partial class Analizador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPosfija = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bExprReg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExprReg = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAFN = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.tbIdentificador = new System.Windows.Forms.TextBox();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tbValidar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dgvlr0 = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dGVtokens = new System.Windows.Forms.DataGridView();
            this.tbTiny = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvAFD = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvAFN = new System.Windows.Forms.DataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.lb_out = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlr0)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVtokens)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFD)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFN)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 249);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "Abrir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(4, 1);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(339, 258);
            this.textBox1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(354, 316);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(346, 288);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Avance 0";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbPosfija);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.bExprReg);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tbExprReg);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(346, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Avance 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Implicita";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(336, 23);
            this.textBox2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Lopez Melo Luis Fernando";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rangel Tapia Jonathan Smith";
            // 
            // tbPosfija
            // 
            this.tbPosfija.Location = new System.Drawing.Point(3, 167);
            this.tbPosfija.Name = "tbPosfija";
            this.tbPosfija.Size = new System.Drawing.Size(336, 23);
            this.tbPosfija.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Posfija:";
            // 
            // bExprReg
            // 
            this.bExprReg.Location = new System.Drawing.Point(220, 47);
            this.bExprReg.Name = "bExprReg";
            this.bExprReg.Size = new System.Drawing.Size(119, 23);
            this.bExprReg.TabIndex = 1;
            this.bExprReg.Text = "Convertir a Posfija";
            this.bExprReg.UseVisualStyleBackColor = true;
            this.bExprReg.Click += new System.EventHandler(this.bExprReg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Expresion regular:";
            // 
            // tbExprReg
            // 
            this.tbExprReg.Location = new System.Drawing.Point(3, 18);
            this.tbExprReg.Name = "tbExprReg";
            this.tbExprReg.Size = new System.Drawing.Size(336, 23);
            this.tbExprReg.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // btnAFN
            // 
            this.btnAFN.Location = new System.Drawing.Point(368, 326);
            this.btnAFN.Name = "btnAFN";
            this.btnAFN.Size = new System.Drawing.Size(113, 28);
            this.btnAFN.TabIndex = 4;
            this.btnAFN.Text = "AFN";
            this.btnAFN.UseVisualStyleBackColor = true;
            this.btnAFN.Click += new System.EventHandler(this.btnAFN_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "AFD";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbIdentificador
            // 
            this.tbIdentificador.Location = new System.Drawing.Point(646, 333);
            this.tbIdentificador.Name = "tbIdentificador";
            this.tbIdentificador.Size = new System.Drawing.Size(114, 23);
            this.tbIdentificador.TabIndex = 7;
            // 
            // tbNum
            // 
            this.tbNum.Location = new System.Drawing.Point(646, 365);
            this.tbNum.Name = "tbNum";
            this.tbNum.Size = new System.Drawing.Size(114, 23);
            this.tbNum.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(798, 333);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 27);
            this.button3.TabIndex = 9;
            this.button3.Text = "CLASIFICAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(566, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Identificador";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(583, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Número";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(16, 328);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 12;
            // 
            // tbValidar
            // 
            this.tbValidar.Location = new System.Drawing.Point(122, 328);
            this.tbValidar.Name = "tbValidar";
            this.tbValidar.Size = new System.Drawing.Size(75, 23);
            this.tbValidar.TabIndex = 13;
            this.tbValidar.Text = "Validar";
            this.tbValidar.UseVisualStyleBackColor = true;
            this.tbValidar.Click += new System.EventHandler(this.button4_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(798, 363);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Construir LR0";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.listBox1);
            this.tabPage6.Controls.Add(this.dgvlr0);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(666, 287);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Colección Canonica";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(291, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(372, 274);
            this.listBox1.TabIndex = 1;
            // 
            // dgvlr0
            // 
            this.dgvlr0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlr0.Location = new System.Drawing.Point(3, 3);
            this.dgvlr0.Name = "dgvlr0";
            this.dgvlr0.RowTemplate.Height = 25;
            this.dgvlr0.Size = new System.Drawing.Size(282, 281);
            this.dgvlr0.TabIndex = 0;
            this.dgvlr0.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dGVtokens);
            this.tabPage5.Controls.Add(this.tbTiny);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(666, 287);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Tiny";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dGVtokens
            // 
            this.dGVtokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVtokens.Location = new System.Drawing.Point(407, 0);
            this.dGVtokens.Name = "dGVtokens";
            this.dGVtokens.RowTemplate.Height = 25;
            this.dGVtokens.Size = new System.Drawing.Size(256, 281);
            this.dGVtokens.TabIndex = 1;
            // 
            // tbTiny
            // 
            this.tbTiny.Location = new System.Drawing.Point(2, 2);
            this.tbTiny.Multiline = true;
            this.tbTiny.Name = "tbTiny";
            this.tbTiny.Size = new System.Drawing.Size(248, 281);
            this.tbTiny.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvAFD);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(666, 287);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "AFD";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvAFD
            // 
            this.dgvAFD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAFD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAFD.Location = new System.Drawing.Point(3, 3);
            this.dgvAFD.Name = "dgvAFD";
            this.dgvAFD.RowTemplate.Height = 25;
            this.dgvAFD.Size = new System.Drawing.Size(660, 281);
            this.dgvAFD.TabIndex = 0;
            this.dgvAFD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvAFN);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(666, 287);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "AFN";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvAFN
            // 
            this.dgvAFN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAFN.Location = new System.Drawing.Point(3, 3);
            this.dgvAFN.Name = "dgvAFN";
            this.dgvAFN.RowTemplate.Height = 25;
            this.dgvAFN.Size = new System.Drawing.Size(660, 281);
            this.dgvAFN.TabIndex = 3;
            this.dgvAFN.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAFN_CellContentClick);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Location = new System.Drawing.Point(368, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(674, 315);
            this.tabControl2.TabIndex = 5;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dgvTabla);
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(666, 287);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Tabla LR0";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dgvTabla
            // 
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabla.Location = new System.Drawing.Point(3, 3);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.RowTemplate.Height = 25;
            this.dgvTabla.Size = new System.Drawing.Size(660, 281);
            this.dgvTabla.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.treeView1);
            this.tabPage8.Location = new System.Drawing.Point(4, 24);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(666, 287);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "Arbol de análisis sintáctico";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(660, 281);
            this.treeView1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(798, 398);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "label9";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(908, 329);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 55);
            this.button5.TabIndex = 17;
            this.button5.Text = "Analizar gramatica TINY";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lb_out
            // 
            this.lb_out.AutoSize = true;
            this.lb_out.Location = new System.Drawing.Point(368, 398);
            this.lb_out.Name = "lb_out";
            this.lb_out.Size = new System.Drawing.Size(38, 15);
            this.lb_out.TabIndex = 18;
            this.lb_out.Text = "label8";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(16, 363);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(343, 49);
            this.listBox2.TabIndex = 19;
            // 
            // Analizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 422);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.lb_out);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tbValidar);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbNum);
            this.Controls.Add(this.tbIdentificador);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.btnAFN);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Analizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compiladores - FunTec";
            this.Load += new System.EventHandler(this.Analizador_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlr0)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVtokens)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFD)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFN)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbExprReg;
        private System.Windows.Forms.Button bExprReg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbPosfija;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAFN;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbIdentificador;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button tbValidar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dgvlr0;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dGVtokens;
        private System.Windows.Forms.TextBox tbTiny;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvAFD;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvAFN;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView dgvTabla;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lb_out;
        private System.Windows.Forms.ListBox listBox2;
    }
}

