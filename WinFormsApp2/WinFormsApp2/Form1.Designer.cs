namespace WinFormsApp2
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOtvet = new System.Windows.Forms.TextBox();
            this.buttonSpisok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEiler = new System.Windows.Forms.TextBox();
            this.buttonEilerVicheclit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(49, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "вычислить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Из какой вершины ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(320, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(468, 359);
            this.dataGridView1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.Location = new System.Drawing.Point(425, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(279, 29);
            this.button2.TabIndex = 8;
            this.button2.Text = "Вывод Матрциы Смежности";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Название Алгоритма";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ответ";
            // 
            // textBoxOtvet
            // 
            this.textBoxOtvet.Location = new System.Drawing.Point(66, 374);
            this.textBoxOtvet.Name = "textBoxOtvet";
            this.textBoxOtvet.Size = new System.Drawing.Size(200, 27);
            this.textBoxOtvet.TabIndex = 10;
            // 
            // buttonSpisok
            // 
            this.buttonSpisok.Location = new System.Drawing.Point(427, 413);
            this.buttonSpisok.Name = "buttonSpisok";
            this.buttonSpisok.Size = new System.Drawing.Size(277, 25);
            this.buttonSpisok.TabIndex = 12;
            this.buttonSpisok.Text = "Вывод Списка Смежности";
            this.buttonSpisok.UseVisualStyleBackColor = true;
            this.buttonSpisok.Click += new System.EventHandler(this.buttonSpisok_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = " Эйлеровый цикл";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Из какой вершины ";
            // 
            // textBoxEiler
            // 
            this.textBoxEiler.Location = new System.Drawing.Point(174, 273);
            this.textBoxEiler.Name = "textBoxEiler";
            this.textBoxEiler.Size = new System.Drawing.Size(113, 27);
            this.textBoxEiler.TabIndex = 15;
            this.textBoxEiler.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEiler_KeyPress);
            // 
            // buttonEilerVicheclit
            // 
            this.buttonEilerVicheclit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonEilerVicheclit.Location = new System.Drawing.Point(49, 318);
            this.buttonEilerVicheclit.Name = "buttonEilerVicheclit";
            this.buttonEilerVicheclit.Size = new System.Drawing.Size(151, 29);
            this.buttonEilerVicheclit.TabIndex = 16;
            this.buttonEilerVicheclit.Text = "вычислить";
            this.buttonEilerVicheclit.UseVisualStyleBackColor = false;
            this.buttonEilerVicheclit.Click += new System.EventHandler(this.buttonEilerVicheclit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEilerVicheclit);
            this.Controls.Add(this.textBoxEiler);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSpisok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxOtvet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private DataGridView dataGridView1;
        private Button button2;
        private Label label1;
        private Label label3;
        private TextBox textBoxOtvet;
        private Button buttonSpisok;
        private Label label4;
        private Label label5;
        private TextBox textBoxEiler;
        private Button buttonEilerVicheclit;
    }
}