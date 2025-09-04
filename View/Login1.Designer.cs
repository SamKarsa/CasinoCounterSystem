namespace CasinoCounterSystem.View
{
    partial class Login1
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
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            uiButton1 = new Sunny.UI.UIButton();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiTextBox2 = new Sunny.UI.UITextBox();
            panel1 = new Panel();
            uiTextBox4 = new Sunny.UI.UITextBox();
            uiTextBox3 = new Sunny.UI.UITextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(144, 34);
            label3.Name = "label3";
            label3.Size = new Size(103, 40);
            label3.TabIndex = 8;
            label3.Text = "Log In";
            label3.Click += label3_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.Navy;
            linkLabel1.Location = new Point(228, 236);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(125, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forgot the password?";
            // 
            // uiButton1
            // 
            uiButton1.BackColor = Color.White;
            uiButton1.FillColor = Color.Navy;
            uiButton1.FillColor2 = Color.Navy;
            uiButton1.Font = new Font("Microsoft Sans Serif", 12F);
            uiButton1.Location = new Point(25, 236);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(123, 36);
            uiButton1.TabIndex = 10;
            uiButton1.Text = "Join";
            uiButton1.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiTextBox1
            // 
            uiTextBox1.BackColor = Color.White;
            uiTextBox1.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox1.Location = new Point(29, 98);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(328, 47);
            uiTextBox1.TabIndex = 9;
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "👤 Username";
            uiTextBox1.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox1.WatermarkColor = SystemColors.GrayText;
            // 
            // uiTextBox2
            // 
            uiTextBox2.BackColor = Color.White;
            uiTextBox2.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox2.Location = new Point(29, 155);
            uiTextBox2.Margin = new Padding(4, 5, 4, 5);
            uiTextBox2.MinimumSize = new Size(1, 16);
            uiTextBox2.Name = "uiTextBox2";
            uiTextBox2.Padding = new Padding(5);
            uiTextBox2.ShowText = false;
            uiTextBox2.Size = new Size(328, 47);
            uiTextBox2.TabIndex = 9;
            uiTextBox2.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox2.Watermark = "🔒 Password";
            uiTextBox2.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox2.WatermarkColor = SystemColors.GrayText;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(uiTextBox4);
            panel1.Controls.Add(uiTextBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(uiButton1);
            panel1.Controls.Add(linkLabel1);
            panel1.Location = new Point(32, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(380, 307);
            panel1.TabIndex = 1;
            // 
            // uiTextBox4
            // 
            uiTextBox4.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox4.Location = new Point(25, 168);
            uiTextBox4.Margin = new Padding(4, 5, 4, 5);
            uiTextBox4.MinimumSize = new Size(1, 16);
            uiTextBox4.Name = "uiTextBox4";
            uiTextBox4.Padding = new Padding(5);
            uiTextBox4.ShowText = false;
            uiTextBox4.Size = new Size(328, 47);
            uiTextBox4.TabIndex = 12;
            uiTextBox4.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox4.Watermark = "🔒 Password";
            uiTextBox4.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox4.WatermarkColor = SystemColors.GrayText;
            // 
            // uiTextBox3
            // 
            uiTextBox3.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox3.Location = new Point(25, 101);
            uiTextBox3.Margin = new Padding(4, 5, 4, 5);
            uiTextBox3.MinimumSize = new Size(1, 16);
            uiTextBox3.Name = "uiTextBox3";
            uiTextBox3.Padding = new Padding(5);
            uiTextBox3.ShowText = false;
            uiTextBox3.Size = new Size(328, 47);
            uiTextBox3.TabIndex = 11;
            uiTextBox3.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox3.Watermark = "👤 Username";
            uiTextBox3.WatermarkActiveColor = SystemColors.GrayText;
            uiTextBox3.WatermarkColor = SystemColors.GrayText;
            uiTextBox3.TextChanged += uiTextBox3_TextChanged;
            // 
            // Login1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(443, 365);
            Controls.Add(panel1);
            Name = "Login1";
            Text = "Login1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private LinkLabel linkLabel1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UITextBox uiTextBox2;
        private Panel panel1;
        private Sunny.UI.UITextBox uiTextBox4;
        private Sunny.UI.UITextBox uiTextBox3;
    }
}