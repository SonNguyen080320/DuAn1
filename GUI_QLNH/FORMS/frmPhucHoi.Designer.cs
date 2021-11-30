
namespace GUI_QLNH.FORMS
{
    partial class frmPhucHoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhucHoi));
            this.txtMa = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPhucHoi = new Guna.UI2.WinForms.Guna2Button();
            this.lbMa = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbTilte = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbTen = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbEmail = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtgvPhucHoi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhucHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMa
            // 
            this.txtMa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMa.DefaultText = "";
            this.txtMa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMa.DisabledState.Parent = this.txtMa;
            this.txtMa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMa.FocusedState.Parent = this.txtMa;
            this.txtMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMa.HoverState.Parent = this.txtMa;
            this.txtMa.Location = new System.Drawing.Point(226, 124);
            this.txtMa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMa.Name = "txtMa";
            this.txtMa.PasswordChar = '\0';
            this.txtMa.PlaceholderText = "";
            this.txtMa.SelectedText = "";
            this.txtMa.ShadowDecoration.Parent = this.txtMa;
            this.txtMa.Size = new System.Drawing.Size(257, 44);
            this.txtMa.TabIndex = 2;
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.CheckedState.Parent = this.btnPhucHoi;
            this.btnPhucHoi.CustomImages.Parent = this.btnPhucHoi;
            this.btnPhucHoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhucHoi.ForeColor = System.Drawing.Color.White;
            this.btnPhucHoi.HoverState.Parent = this.btnPhucHoi;
            this.btnPhucHoi.Location = new System.Drawing.Point(769, 204);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.ShadowDecoration.Parent = this.btnPhucHoi;
            this.btnPhucHoi.Size = new System.Drawing.Size(153, 45);
            this.btnPhucHoi.TabIndex = 3;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // lbMa
            // 
            this.lbMa.BackColor = System.Drawing.Color.Transparent;
            this.lbMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMa.Location = new System.Drawing.Point(35, 141);
            this.lbMa.Name = "lbMa";
            this.lbMa.Size = new System.Drawing.Size(46, 27);
            this.lbMa.TabIndex = 4;
            this.lbMa.Text = "Mã :";
            // 
            // lbTilte
            // 
            this.lbTilte.BackColor = System.Drawing.Color.Transparent;
            this.lbTilte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTilte.Location = new System.Drawing.Point(385, 46);
            this.lbTilte.Name = "lbTilte";
            this.lbTilte.Size = new System.Drawing.Size(87, 27);
            this.lbTilte.TabIndex = 5;
            this.lbTilte.Text = "Phục hồi";
            // 
            // lbTen
            // 
            this.lbTen.BackColor = System.Drawing.Color.Transparent;
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen.Location = new System.Drawing.Point(35, 221);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(54, 27);
            this.lbTen.TabIndex = 7;
            this.lbTen.Text = "Tên :";
            // 
            // txtTen
            // 
            this.txtTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTen.DefaultText = "";
            this.txtTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTen.DisabledState.Parent = this.txtTen;
            this.txtTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTen.FocusedState.Parent = this.txtTen;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTen.HoverState.Parent = this.txtTen;
            this.txtTen.Location = new System.Drawing.Point(226, 204);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtTen.Name = "txtTen";
            this.txtTen.PasswordChar = '\0';
            this.txtTen.PlaceholderText = "";
            this.txtTen.SelectedText = "";
            this.txtTen.ShadowDecoration.Parent = this.txtTen;
            this.txtTen.Size = new System.Drawing.Size(257, 44);
            this.txtTen.TabIndex = 6;
            // 
            // lbEmail
            // 
            this.lbEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(528, 141);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(69, 27);
            this.lbEmail.TabIndex = 9;
            this.lbEmail.Text = "Email :";
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.Parent = this.txtEmail;
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.FocusedState.Parent = this.txtEmail;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.HoverState.Parent = this.txtEmail;
            this.txtEmail.Location = new System.Drawing.Point(604, 124);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.Parent = this.txtEmail;
            this.txtEmail.Size = new System.Drawing.Size(389, 44);
            this.txtEmail.TabIndex = 8;
            // 
            // dtgvPhucHoi
            // 
            this.dtgvPhucHoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPhucHoi.BackgroundColor = System.Drawing.Color.White;
            this.dtgvPhucHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPhucHoi.Location = new System.Drawing.Point(35, 306);
            this.dtgvPhucHoi.Name = "dtgvPhucHoi";
            this.dtgvPhucHoi.RowHeadersWidth = 51;
            this.dtgvPhucHoi.RowTemplate.Height = 24;
            this.dtgvPhucHoi.Size = new System.Drawing.Size(958, 254);
            this.dtgvPhucHoi.TabIndex = 10;
            this.dtgvPhucHoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPhucHoi_CellContentClick_1);
            this.dtgvPhucHoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPhucHoi_CellContentClick_1);
            // 
            // frmPhucHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1038, 648);
            this.Controls.Add(this.dtgvPhucHoi);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lbTilte);
            this.Controls.Add(this.lbMa);
            this.Controls.Add(this.btnPhucHoi);
            this.Controls.Add(this.txtMa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhucHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phục hồi";
            this.Load += new System.EventHandler(this.frmPhucHoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhucHoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtMa;
        private Guna.UI2.WinForms.Guna2Button btnPhucHoi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbMa;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTilte;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTen;
        private Guna.UI2.WinForms.Guna2TextBox txtTen;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.DataGridView dtgvPhucHoi;
    }
}