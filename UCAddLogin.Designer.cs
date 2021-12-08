
namespace StudentManagement
{
    partial class UCAddLogin
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
            this.lkGiangVien = new DevExpress.XtraEditors.LookUpEdit();
            this.cbxRole = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Tạo = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lbGiangVien = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tePW = new DevExpress.XtraEditors.TextEdit();
            this.teLogin = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkGiangVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lkGiangVien
            // 
            this.lkGiangVien.Location = new System.Drawing.Point(312, 179);
            this.lkGiangVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lkGiangVien.Name = "lkGiangVien";
            this.lkGiangVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkGiangVien.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MAGV", "MAGV"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HOTEN", "HOTEN")});
            this.lkGiangVien.Properties.DisplayMember = "HOTEN";
            this.lkGiangVien.Properties.NullText = "";
            this.lkGiangVien.Properties.ValueMember = "MAGV";
            this.lkGiangVien.Size = new System.Drawing.Size(184, 22);
            this.lkGiangVien.TabIndex = 21;
            // 
            // cbxRole
            // 
            this.cbxRole.Location = new System.Drawing.Point(312, 227);
            this.cbxRole.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxRole.Name = "cbxRole";
            this.cbxRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxRole.Size = new System.Drawing.Size(184, 22);
            this.cbxRole.TabIndex = 20;
            // 
            // Tạo
            // 
            this.Tạo.Location = new System.Drawing.Point(312, 310);
            this.Tạo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Tạo.Name = "Tạo";
            this.Tạo.Size = new System.Drawing.Size(184, 29);
            this.Tạo.TabIndex = 19;
            this.Tạo.Text = "Tạo tài khoản";
            this.Tạo.Click += new System.EventHandler(this.Tạo_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(103, 230);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 17);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "Quyền";
            // 
            // lbGiangVien
            // 
            this.lbGiangVien.Location = new System.Drawing.Point(103, 184);
            this.lbGiangVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbGiangVien.Name = "lbGiangVien";
            this.lbGiangVien.Size = new System.Drawing.Size(62, 17);
            this.lbGiangVien.TabIndex = 17;
            this.lbGiangVien.Text = "Đối tượng";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(103, 135);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 17);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(103, 83);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 17);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Tên đăng nhập";
            // 
            // tePW
            // 
            this.tePW.Location = new System.Drawing.Point(312, 129);
            this.tePW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tePW.Name = "tePW";
            this.tePW.Properties.UseSystemPasswordChar = true;
            this.tePW.Size = new System.Drawing.Size(184, 22);
            this.tePW.TabIndex = 14;
            // 
            // teLogin
            // 
            this.teLogin.Location = new System.Drawing.Point(312, 80);
            this.teLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.teLogin.Name = "teLogin";
            this.teLogin.Size = new System.Drawing.Size(184, 22);
            this.teLogin.TabIndex = 13;
            // 
            // UCAddLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lkGiangVien);
            this.Controls.Add(this.cbxRole);
            this.Controls.Add(this.Tạo);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbGiangVien);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tePW);
            this.Controls.Add(this.teLogin);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "UCAddLogin";
            this.Size = new System.Drawing.Size(598, 418);
            ((System.ComponentModel.ISupportInitialize)(this.lkGiangVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lkGiangVien;
        private DevExpress.XtraEditors.ComboBoxEdit cbxRole;
        private DevExpress.XtraEditors.SimpleButton Tạo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lbGiangVien;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tePW;
        private DevExpress.XtraEditors.TextEdit teLogin;
    }
}
