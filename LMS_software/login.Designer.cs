namespace LMS_software
{
    partial class login
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
			panel1 = new Panel();
			label3 = new Label();
			panel2 = new Panel();
			button1 = new Button();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			label2 = new Label();
			label1 = new Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ActiveCaptionText;
			panel1.Controls.Add(label3);
			panel1.Location = new Point(-2, -2);
			panel1.Name = "panel1";
			panel1.Size = new Size(317, 391);
			panel1.TabIndex = 0;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = SystemColors.ControlLightLight;
			label3.Location = new Point(14, 163);
			label3.Name = "label3";
			label3.Size = new Size(277, 45);
			label3.TabIndex = 0;
			label3.Text = "Welcome To LMS";
			// 
			// panel2
			// 
			panel2.Controls.Add(button1);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(textBox2);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(label1);
			panel2.Location = new Point(312, -2);
			panel2.Name = "panel2";
			panel2.Size = new Size(448, 391);
			panel2.TabIndex = 1;
			panel2.Paint += panel2_Paint;
			// 
			// button1
			// 
			button1.BackColor = SystemColors.ActiveCaptionText;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			button1.ForeColor = SystemColors.ButtonFace;
			button1.Location = new Point(110, 240);
			button1.Name = "button1";
			button1.Size = new Size(244, 45);
			button1.TabIndex = 5;
			button1.Text = "Login";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// textBox1
			// 
			textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			textBox1.Location = new Point(110, 116);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(244, 44);
			textBox1.TabIndex = 4;
			textBox1.TextChanged += textBox1_TextChanged;
			// 
			// textBox2
			// 
			textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			textBox2.Location = new Point(110, 181);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(244, 44);
			textBox2.TabIndex = 3;
			textBox2.TextChanged += textBox2_TextChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(110, 163);
			label2.Name = "label2";
			label2.Size = new Size(57, 15);
			label2.TabIndex = 1;
			label2.Text = "Password";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(110, 98);
			label1.Name = "label1";
			label1.Size = new Size(36, 15);
			label1.TabIndex = 0;
			label1.Text = "Email";
			// 
			// login
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLightLight;
			ClientSize = new Size(759, 390);
			ControlBox = false;
			Controls.Add(panel2);
			Controls.Add(panel1);
			Name = "login";
			Text = "Login";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
        private Panel panel2;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private Label label3;
    }
}
