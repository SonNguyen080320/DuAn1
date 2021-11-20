
namespace GUI_QLNH.FORMS
{
    partial class frmthongketonghop
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
            this.dtgvThongKeTheoNgay = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeTheoNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvThongKeTheoNgay
            // 
            this.dtgvThongKeTheoNgay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvThongKeTheoNgay.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvThongKeTheoNgay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKeTheoNgay.Location = new System.Drawing.Point(56, 129);
            this.dtgvThongKeTheoNgay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtgvThongKeTheoNgay.Name = "dtgvThongKeTheoNgay";
            this.dtgvThongKeTheoNgay.RowHeadersWidth = 51;
            this.dtgvThongKeTheoNgay.RowTemplate.Height = 24;
            this.dtgvThongKeTheoNgay.Size = new System.Drawing.Size(736, 337);
            this.dtgvThongKeTheoNgay.TabIndex = 8;
            // 
            // frmthongketonghop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 596);
            this.Controls.Add(this.dtgvThongKeTheoNgay);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmthongketonghop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form thống kê tổng hợp";
            this.Load += new System.EventHandler(this.frmthongketonghop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeTheoNgay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvThongKeTheoNgay;
    }
}