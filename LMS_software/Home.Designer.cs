namespace LMS_software
{
    partial class Home
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
			panel1 = new Panel();
			panel2 = new Panel();
			tableLayoutPanel1 = new TableLayoutPanel();
			panel3 = new Panel();
			button5 = new Button();
			button4 = new Button();
			button3 = new Button();
			button2 = new Button();
			button1 = new Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(panel2);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(800, 450);
			panel1.TabIndex = 0;
			// 
			// panel2
			// 
			panel2.Controls.Add(tableLayoutPanel1);
			panel2.Controls.Add(panel3);
			panel2.Location = new Point(3, 3);
			panel2.Name = "panel2";
			panel2.Size = new Size(785, 435);
			panel2.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel1.ColumnCount = 4;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			tableLayoutPanel1.Location = new Point(288, 9);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Size = new Size(494, 423);
			tableLayoutPanel1.TabIndex = 1;
			tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
			// 
			// panel3
			// 
			panel3.BackColor = SystemColors.ActiveCaptionText;
			panel3.Controls.Add(button5);
			panel3.Controls.Add(button4);
			panel3.Controls.Add(button3);
			panel3.Controls.Add(button2);
			panel3.Controls.Add(button1);
			panel3.Dock = DockStyle.Left;
			panel3.Location = new Point(0, 0);
			panel3.Name = "panel3";
			panel3.Size = new Size(282, 435);
			panel3.TabIndex = 0;
			// 
			// button5
			// 
			button5.BackColor = SystemColors.ButtonHighlight;
			button5.Font = new Font("Segoe UI", 14.25F);
			button5.Location = new Point(23, 356);
			button5.Name = "button5";
			button5.Size = new Size(234, 46);
			button5.TabIndex = 4;
			button5.Text = "Exit";
			button5.UseVisualStyleBackColor = false;
			button5.Click += button5_Click;
			// 
			// button4
			// 
			button4.BackColor = SystemColors.ButtonHighlight;
			button4.Font = new Font("Segoe UI", 14.25F);
			button4.Location = new Point(23, 283);
			button4.Name = "button4";
			button4.Size = new Size(234, 46);
			button4.TabIndex = 3;
			button4.Text = "Return Book";
			button4.UseVisualStyleBackColor = false;
			button4.Click += button4_Click;
			// 
			// button3
			// 
			button3.BackColor = SystemColors.ButtonHighlight;
			button3.Font = new Font("Segoe UI", 14.25F);
			button3.Location = new Point(23, 212);
			button3.Name = "button3";
			button3.Size = new Size(234, 46);
			button3.TabIndex = 2;
			button3.Text = "Issue Book";
			button3.UseVisualStyleBackColor = false;
			button3.Click += button3_Click;
			// 
			// button2
			// 
			button2.BackColor = SystemColors.ButtonHighlight;
			button2.Font = new Font("Segoe UI", 14.25F);
			button2.Location = new Point(23, 135);
			button2.Name = "button2";
			button2.Size = new Size(234, 46);
			button2.TabIndex = 1;
			button2.Text = "Members";
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			// 
			// button1
			// 
			button1.BackColor = SystemColors.ButtonHighlight;
			button1.Font = new Font("Segoe UI", 14.25F);
			button1.Location = new Point(23, 62);
			button1.Name = "button1";
			button1.Size = new Size(234, 46);
			button1.TabIndex = 0;
			button1.Text = "Books";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// Home
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panel1);
			Name = "Home";
			Text = "Home";
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel3.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}