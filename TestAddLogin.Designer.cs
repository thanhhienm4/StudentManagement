
namespace StudentManagement
{
    partial class TestAddLogin
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
            this.teLogin = new DevExpress.XtraEditors.TextEdit();
            this.tePW = new DevExpress.XtraEditors.TextEdit();
            this.teUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.teRole = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRole.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // teLogin
            // 
            this.teLogin.Location = new System.Drawing.Point(370, 86);
            this.teLogin.Name = "teLogin";
            this.teLogin.Size = new System.Drawing.Size(236, 26);
            this.teLogin.TabIndex = 0;
            // 
            // tePW
            // 
            this.tePW.Location = new System.Drawing.Point(370, 144);
            this.tePW.Name = "tePW";
            this.tePW.Size = new System.Drawing.Size(236, 26);
            this.tePW.TabIndex = 1;
            // 
            // teUser
            // 
            this.teUser.Location = new System.Drawing.Point(370, 207);
            this.teUser.Name = "teUser";
            this.teUser.Size = new System.Drawing.Size(236, 26);
            this.teUser.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(101, 89);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 19);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Login";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(101, 151);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 19);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Password";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(101, 210);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 19);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "UserName";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(101, 264);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(31, 19);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Role";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(370, 339);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(150, 34);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Nhấn vô đây";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // teRole
            // 
            this.teRole.Location = new System.Drawing.Point(368, 261);
            this.teRole.Name = "teRole";
            this.teRole.Size = new System.Drawing.Size(238, 26);
            this.teRole.TabIndex = 10;
            // 
            // TestAddLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 506);
            this.Controls.Add(this.teRole);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.teUser);
            this.Controls.Add(this.tePW);
            this.Controls.Add(this.teLogin);
            this.Name = "TestAddLogin";
            this.Text = "TestAddLogin";
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRole.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit teLogin;
        private DevExpress.XtraEditors.TextEdit tePW;
        private DevExpress.XtraEditors.TextEdit teUser;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit teRole;
    }
}