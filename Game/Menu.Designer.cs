namespace Game
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.button_Play = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Join = new System.Windows.Forms.Button();
            this.button_Create = new System.Windows.Forms.Button();
            this.button_Back2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_Sketch = new System.Windows.Forms.Button();
            this.button_Sonic = new System.Windows.Forms.Button();
            this.button_Back3 = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Back4 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Back5 = new System.Windows.Forms.Button();
            this.timer_sendNames = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Play
            // 
            this.button_Play.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Play.FlatAppearance.BorderSize = 20;
            this.button_Play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.button_Play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.button_Play.Location = new System.Drawing.Point(50, 50);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(200, 50);
            this.button_Play.TabIndex = 0;
            this.button_Play.Text = "Play";
            this.button_Play.UseVisualStyleBackColor = true;
            this.button_Play.Click += new System.EventHandler(this.button_Play_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Exit.FlatAppearance.BorderSize = 20;
            this.button_Exit.Location = new System.Drawing.Point(50, 200);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(200, 50);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button_Play);
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(244, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 300);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button_Join);
            this.groupBox2.Controls.Add(this.button_Create);
            this.groupBox2.Controls.Add(this.button_Back2);
            this.groupBox2.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox2.Location = new System.Drawing.Point(244, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 300);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.Visible = false;
            // 
            // button_Join
            // 
            this.button_Join.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Join.Font = new System.Drawing.Font("Bauhaus 93", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Join.Location = new System.Drawing.Point(50, 110);
            this.button_Join.Name = "button_Join";
            this.button_Join.Size = new System.Drawing.Size(200, 50);
            this.button_Join.TabIndex = 3;
            this.button_Join.Text = "Join the match";
            this.button_Join.UseVisualStyleBackColor = true;
            this.button_Join.Click += new System.EventHandler(this.button_Join_Click);
            // 
            // button_Create
            // 
            this.button_Create.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Create.FlatAppearance.BorderSize = 20;
            this.button_Create.Font = new System.Drawing.Font("Bauhaus 93", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Create.Location = new System.Drawing.Point(50, 50);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(200, 50);
            this.button_Create.TabIndex = 0;
            this.button_Create.Text = "Create a match";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // button_Back2
            // 
            this.button_Back2.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Back2.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Back2.Location = new System.Drawing.Point(50, 200);
            this.button_Back2.Name = "button_Back2";
            this.button_Back2.Size = new System.Drawing.Size(200, 50);
            this.button_Back2.TabIndex = 2;
            this.button_Back2.Text = "Back";
            this.button_Back2.UseVisualStyleBackColor = true;
            this.button_Back2.Click += new System.EventHandler(this.button_Back2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.button_Start);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Controls.Add(this.button_Sketch);
            this.groupBox3.Controls.Add(this.button_Sonic);
            this.groupBox3.Controls.Add(this.button_Back3);
            this.groupBox3.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox3.Location = new System.Drawing.Point(170, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 300);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            this.groupBox3.Visible = false;
            // 
            // button_Start
            // 
            this.button_Start.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Start.Location = new System.Drawing.Point(12, 151);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(200, 50);
            this.button_Start.TabIndex = 6;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Control;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 36;
            this.listBox1.Location = new System.Drawing.Point(227, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 148);
            this.listBox1.TabIndex = 5;
            // 
            // button_Sketch
            // 
            this.button_Sketch.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Sketch.Font = new System.Drawing.Font("Bauhaus 93", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Sketch.Location = new System.Drawing.Point(12, 95);
            this.button_Sketch.Name = "button_Sketch";
            this.button_Sketch.Size = new System.Drawing.Size(200, 50);
            this.button_Sketch.TabIndex = 3;
            this.button_Sketch.Text = "Sketch Turner";
            this.button_Sketch.UseVisualStyleBackColor = true;
            this.button_Sketch.Click += new System.EventHandler(this.button_Sketch_Click);
            // 
            // button_Sonic
            // 
            this.button_Sonic.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Sonic.Font = new System.Drawing.Font("Bauhaus 93", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Sonic.Location = new System.Drawing.Point(10, 39);
            this.button_Sonic.Name = "button_Sonic";
            this.button_Sonic.Size = new System.Drawing.Size(200, 50);
            this.button_Sonic.TabIndex = 0;
            this.button_Sonic.Text = "Sonic The Hedgehog";
            this.button_Sonic.UseVisualStyleBackColor = true;
            this.button_Sonic.Click += new System.EventHandler(this.button_Sonic_Click);
            // 
            // button_Back3
            // 
            this.button_Back3.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Back3.Location = new System.Drawing.Point(12, 226);
            this.button_Back3.Name = "button_Back3";
            this.button_Back3.Size = new System.Drawing.Size(200, 50);
            this.button_Back3.TabIndex = 2;
            this.button_Back3.Text = "Back";
            this.button_Back3.UseVisualStyleBackColor = true;
            this.button_Back3.Click += new System.EventHandler(this.button_Back3_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Name.Location = new System.Drawing.Point(50, 70);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(200, 54);
            this.textBox_Name.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.textBox_IP);
            this.groupBox4.Controls.Add(this.button_Connect);
            this.groupBox4.Controls.Add(this.button_Back4);
            this.groupBox4.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox4.Location = new System.Drawing.Point(244, 159);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 300);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            this.groupBox4.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 36);
            this.label2.TabIndex = 7;
            this.label2.Text = "Host\'s IP: ";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_IP.Location = new System.Drawing.Point(50, 70);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(200, 54);
            this.textBox_IP.TabIndex = 5;
            // 
            // button_Connect
            // 
            this.button_Connect.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Connect.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Connect.Location = new System.Drawing.Point(50, 118);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(200, 50);
            this.button_Connect.TabIndex = 3;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Back4
            // 
            this.button_Back4.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Back4.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Back4.Location = new System.Drawing.Point(50, 200);
            this.button_Back4.Name = "button_Back4";
            this.button_Back4.Size = new System.Drawing.Size(200, 50);
            this.button_Back4.TabIndex = 2;
            this.button_Back4.Text = "Back";
            this.button_Back4.UseVisualStyleBackColor = true;
            this.button_Back4.Click += new System.EventHandler(this.button_Back4_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.button_Next);
            this.groupBox5.Controls.Add(this.button_Back5);
            this.groupBox5.Controls.Add(this.textBox_Name);
            this.groupBox5.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox5.Location = new System.Drawing.Point(244, 159);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(300, 300);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            this.groupBox5.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter your name:";
            // 
            // button_Next
            // 
            this.button_Next.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Next.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Next.Location = new System.Drawing.Point(50, 118);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(200, 50);
            this.button_Next.TabIndex = 5;
            this.button_Next.Text = "Next";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_Back5
            // 
            this.button_Back5.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button_Back5.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Back5.Location = new System.Drawing.Point(50, 200);
            this.button_Back5.Name = "button_Back5";
            this.button_Back5.Size = new System.Drawing.Size(200, 50);
            this.button_Back5.TabIndex = 2;
            this.button_Back5.Text = "Back";
            this.button_Back5.UseVisualStyleBackColor = true;
            this.button_Back5.Click += new System.EventHandler(this.button_Back5_Click);
            // 
            // timer_sendNames
            // 
            this.timer_sendNames.Interval = 1000;
            this.timer_sendNames.Tick += new System.EventHandler(this.timer_sendNames_Tick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Play;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Join;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Button button_Back2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Button button_Sketch;
        private System.Windows.Forms.Button button_Sonic;
        private System.Windows.Forms.Button button_Back3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Back4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_Back5;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer_sendNames;
    }
}