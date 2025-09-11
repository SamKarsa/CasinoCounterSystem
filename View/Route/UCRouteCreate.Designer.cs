using Sunny.UI;

namespace CasinoCounterSystem.View.Route
{
    partial class UCRouteCreate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            imgLogo = new PictureBox();
            labelTitle = new Sunny.UI.UILabel();
            textBoxRoute = new Sunny.UI.UITextBox();
            btnSaveRoute = new Sunny.UI.UIButton();
            btnCancelRoute = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            SuspendLayout();
            // 
            // imgLogo
            // 
            imgLogo.BackColor = Color.Transparent;
            imgLogo.Image = Properties.Resources.logoCltElectronic;
            imgLogo.Location = new Point(764, 620);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(89, 86);
            imgLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            imgLogo.TabIndex = 14;
            imgLogo.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Britannic Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Navy;
            labelTitle.Location = new Point(273, 197);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(302, 50);
            labelTitle.TabIndex = 15;
            labelTitle.Text = "Create Route";
            // 
            // textBoxRoute
            // 
            textBoxRoute.ButtonRectColor = Color.Navy;
            textBoxRoute.ButtonRectHoverColor = Color.FromArgb(30, 58, 138);
            textBoxRoute.ButtonRectPressColor = Color.FromArgb(37, 99, 235);
            textBoxRoute.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxRoute.Location = new Point(237, 261);
            textBoxRoute.Margin = new Padding(4, 5, 4, 5);
            textBoxRoute.MinimumSize = new Size(1, 16);
            textBoxRoute.Name = "textBoxRoute";
            textBoxRoute.Padding = new Padding(12, 5, 12, 5);
            textBoxRoute.Radius = 6;
            textBoxRoute.RectColor = Color.Navy;
            textBoxRoute.RectSize = 2;
            textBoxRoute.ShowText = false;
            textBoxRoute.Size = new Size(368, 71);
            textBoxRoute.TabIndex = 16;
            textBoxRoute.TextAlignment = ContentAlignment.MiddleLeft;
            textBoxRoute.Watermark = "Enter route name (e.g., Route A)";
            textBoxRoute.WatermarkActiveColor = SystemColors.GrayText;
            textBoxRoute.WatermarkColor = SystemColors.GrayText;
            textBoxRoute.TabStop = false;
            // 
            // btnSaveRoute
            // 
            btnSaveRoute.BackColor = Color.White;
            btnSaveRoute.FillColor = Color.Navy;
            btnSaveRoute.FillColor2 = Color.Navy;
            btnSaveRoute.FillDisableColor = Color.FromArgb(229, 231, 235);
            btnSaveRoute.FillHoverColor = Color.FromArgb(30, 58, 138);
            btnSaveRoute.FillPressColor = Color.FromArgb(0, 0, 102);
            btnSaveRoute.FillSelectedColor = Color.FromArgb(30, 64, 175);
            btnSaveRoute.Font = new Font("Microsoft Sans Serif", 12F);
            btnSaveRoute.ForeDisableColor = Color.FromArgb(156, 163, 175);
            btnSaveRoute.Location = new Point(237, 358);
            btnSaveRoute.MinimumSize = new Size(1, 1);
            btnSaveRoute.Name = "btnSaveRoute";
            btnSaveRoute.RectColor = Color.Navy;
            btnSaveRoute.RectDisableColor = Color.FromArgb(209, 213, 219);
            btnSaveRoute.RectHoverColor = Color.FromArgb(30, 58, 138);
            btnSaveRoute.RectPressColor = Color.FromArgb(0, 0, 102);
            btnSaveRoute.RectSelectedColor = Color.FromArgb(30, 64, 175);
            btnSaveRoute.Size = new Size(155, 50);
            btnSaveRoute.TabIndex = 17;
            btnSaveRoute.Text = "➕ Save";
            btnSaveRoute.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnSaveRoute.Click += BtnSave_Click;
            // 
            // btnCancelRoute
            // 
            btnCancelRoute.BackColor = Color.White;
            btnCancelRoute.FillColor = Color.FromArgb(229, 231, 235);
            btnCancelRoute.FillColor2 = Color.FromArgb(229, 231, 235);
            btnCancelRoute.FillDisableColor = Color.FromArgb(243, 244, 246);
            btnCancelRoute.FillHoverColor = Color.FromArgb(209, 213, 219);
            btnCancelRoute.FillPressColor = Color.FromArgb(156, 163, 175);
            btnCancelRoute.FillSelectedColor = Color.FromArgb(209, 213, 219);
            btnCancelRoute.Font = new Font("Microsoft Sans Serif", 12F);
            btnCancelRoute.ForeColor = Color.Navy;
            btnCancelRoute.ForeDisableColor = Color.FromArgb(156, 163, 175);
            btnCancelRoute.ForeHoverColor = Color.Navy;
            btnCancelRoute.ForePressColor = Color.Navy;
            btnCancelRoute.ForeSelectedColor = Color.Navy;
            btnCancelRoute.Location = new Point(450, 358);
            btnCancelRoute.MinimumSize = new Size(1, 1);
            btnCancelRoute.Name = "btnCancelRoute";
            btnCancelRoute.RectColor = Color.FromArgb(209, 213, 219);
            btnCancelRoute.RectDisableColor = Color.FromArgb(229, 231, 235);
            btnCancelRoute.RectHoverColor = Color.FromArgb(156, 163, 175);
            btnCancelRoute.RectPressColor = Color.FromArgb(107, 114, 128);
            btnCancelRoute.RectSelectedColor = Color.FromArgb(156, 163, 175);
            btnCancelRoute.Size = new Size(155, 50);
            btnCancelRoute.TabIndex = 18;
            btnCancelRoute.Text = "🗑️ Cancel";
            btnCancelRoute.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnCancelRoute.Click += BtnCancel_Click;
            // 
            // UCRouteCreate
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(btnCancelRoute);
            Controls.Add(btnSaveRoute);
            Controls.Add(textBoxRoute);
            Controls.Add(labelTitle);
            Controls.Add(imgLogo);
            MaximumSize = new Size(863, 712);
            MinimumSize = new Size(863, 712);
            Name = "UCRouteCreate";
            Size = new Size(863, 712);
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox imgLogo;
        private Sunny.UI.UILabel labelTitle;
        private Sunny.UI.UITextBox textBoxRoute;
        private Sunny.UI.UIButton btnSaveRoute;
        private Sunny.UI.UIButton btnCancelRoute;
    }
}
