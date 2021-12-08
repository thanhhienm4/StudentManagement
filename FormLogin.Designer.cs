
namespace StudentManagement
{
    partial class FormLogin
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
            this.cbx = new System.Windows.Forms.ComboBox();
            this.tbLogin = new DevExpress.XtraEditors.TextEdit();
            this.tbPassword = new DevExpress.XtraEditors.TextEdit();
            this.lbUsername = new DevExpress.XtraEditors.LabelControl();
            this.lbPassword = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.lbMessage = new DevExpress.XtraEditors.LabelControl();
            this.cbxRole = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRole.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx
            // 
            this.cbx.FormattingEnabled = true;
            this.cbx.Location = new System.Drawing.Point(514, 44);
            this.cbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx.Name = "cbx";
            this.cbx.Size = new System.Drawing.Size(193, 24);
            this.cbx.TabIndex = 1;
            this.cbx.Text = "      ";
            this.cbx.SelectedValueChanged += new System.EventHandler(this.cbx_SelectedValueChanged);
            // 
            // tbLogin
            // 
            this.tbLogin.EditValue = "ptl";
            this.tbLogin.Location = new System.Drawing.Point(160, 46);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(291, 22);
            this.tbLogin.TabIndex = 2;
            // 
            // tbPassword
            // 
            this.tbPassword.EditValue = "123456";
            this.tbPassword.Location = new System.Drawing.Point(160, 84);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Properties.UseSystemPasswordChar = true;
            this.tbPassword.Size = new System.Drawing.Size(291, 22);
            this.tbPassword.TabIndex = 3;
            // 
            // lbUsername
            // 
            this.lbUsername.Location = new System.Drawing.Point(37, 48);
            this.lbUsername.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(93, 17);
            this.lbUsername.TabIndex = 4;
            this.lbUsername.Text = "Tên đăng nhập";
            this.lbUsername.Click += new System.EventHandler(this.lbUsername_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.Location = new System.Drawing.Point(37, 86);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(56, 17);
            this.lbPassword.TabIndex = 5;
            this.lbPassword.Text = "Mật khẩu";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(160, 122);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(107, 28);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.Location = new System.Drawing.Point(514, 86);
            this.lbMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(24, 16);
            this.lbMessage.TabIndex = 7;
            this.lbMessage.Text = "      ";
            // 
            // cbxRole
            // 
            this.cbxRole.Location = new System.Drawing.Point(514, 84);
            this.cbxRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxRole.Name = "cbxRole";
            this.cbxRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxRole.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxRole.Size = new System.Drawing.Size(193, 22);
            this.cbxRole.TabIndex = 8;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 186);
            this.Controls.Add(this.cbxRole);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.cbx);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)(this.tbLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRole.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx;
        private DevExpress.XtraEditors.TextEdit tbLogin;
        private DevExpress.XtraEditors.TextEdit tbPassword;
        private DevExpress.XtraEditors.LabelControl lbUsername;
        private DevExpress.XtraEditors.LabelControl lbPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.LabelControl lbMessage;
        private DevExpress.XtraEditors.ComboBoxEdit cbxRole;
    }
}

