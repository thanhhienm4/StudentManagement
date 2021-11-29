
namespace StudentManagement
{
    partial class FormFeeByClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFeeByClass));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcFee = new DevExpress.XtraGrid.GridControl();
            this.gvFee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cBYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textLop = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.textMaLop = new DevExpress.XtraLayout.LayoutControlItem();
            this.comboBox = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cbHocKy = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDone = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMaLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHocKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.gcFee);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.comboBoxEdit2);
            this.layoutControl1.Controls.Add(this.cBYear);
            this.layoutControl1.Controls.Add(this.textLop);
            this.layoutControl1.Location = new System.Drawing.Point(0, -3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(805, 452);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcFee
            // 
            this.gcFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFee.Location = new System.Drawing.Point(12, 60);
            this.gcFee.MainView = this.gvFee;
            this.gcFee.Name = "gcFee";
            this.gcFee.Size = new System.Drawing.Size(781, 380);
            this.gcFee.TabIndex = 8;
            this.gcFee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFee});
            // 
            // gvFee
            // 
            this.gvFee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridName,
            this.gridFee,
            this.gridDone});
            this.gvFee.GridControl = this.gcFee;
            this.gvFee.Name = "gvFee";
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSearch.ImageOptions.SvgImage")));
            this.btnSearch.Location = new System.Drawing.Point(602, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 44);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.Location = new System.Drawing.Point(468, 12);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit2.Size = new System.Drawing.Size(130, 22);
            this.comboBoxEdit2.StyleController = this.layoutControl1;
            this.comboBoxEdit2.TabIndex = 6;
            // 
            // cBYear
            // 
            this.cBYear.Location = new System.Drawing.Point(274, 12);
            this.cBYear.Name = "cBYear";
            this.cBYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBYear.Size = new System.Drawing.Size(131, 22);
            this.cBYear.StyleController = this.layoutControl1;
            this.cBYear.TabIndex = 5;
            // 
            // textLop
            // 
            this.textLop.Location = new System.Drawing.Point(71, 12);
            this.textLop.Name = "textLop";
            this.textLop.Size = new System.Drawing.Size(140, 22);
            this.textLop.StyleController = this.layoutControl1;
            this.textLop.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.textMaLop,
            this.comboBox,
            this.cbHocKy,
            this.layoutControlItem5,
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(805, 452);
            this.Root.TextVisible = false;
            // 
            // textMaLop
            // 
            this.textMaLop.Control = this.textLop;
            this.textMaLop.CustomizationFormText = "Mã lớp";
            this.textMaLop.Location = new System.Drawing.Point(0, 0);
            this.textMaLop.Name = "textMaLop";
            this.textMaLop.Size = new System.Drawing.Size(203, 48);
            this.textMaLop.StartNewLine = true;
            this.textMaLop.Text = "Mã lớp";
            this.textMaLop.TextSize = new System.Drawing.Size(56, 17);
            // 
            // comboBox
            // 
            this.comboBox.Control = this.cBYear;
            this.comboBox.Location = new System.Drawing.Point(203, 0);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(194, 48);
            this.comboBox.Text = "Niên khóa";
            this.comboBox.TextSize = new System.Drawing.Size(56, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSearch;
            this.layoutControlItem4.Location = new System.Drawing.Point(590, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(94, 48);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // cbHocKy
            // 
            this.cbHocKy.Control = this.comboBoxEdit2;
            this.cbHocKy.Location = new System.Drawing.Point(397, 0);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(193, 48);
            this.cbHocKy.Text = "Học kì";
            this.cbHocKy.TextSize = new System.Drawing.Size(56, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gcFee;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(785, 384);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Location = new System.Drawing.Point(696, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(97, 44);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "In";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnPrint;
            this.layoutControlItem1.Location = new System.Drawing.Point(684, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(101, 48);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridName
            // 
            this.gridName.Caption = "Họ và tên";
            this.gridName.FieldName = "HOTEN";
            this.gridName.MinWidth = 25;
            this.gridName.Name = "gridName";
            this.gridName.Visible = true;
            this.gridName.VisibleIndex = 0;
            this.gridName.Width = 94;
            // 
            // gridFee
            // 
            this.gridFee.Caption = "Học phí";
            this.gridFee.DisplayFormat.FormatString = "n0";
            this.gridFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridFee.FieldName = "HOCPHI";
            this.gridFee.MinWidth = 25;
            this.gridFee.Name = "gridFee";
            this.gridFee.Visible = true;
            this.gridFee.VisibleIndex = 1;
            this.gridFee.Width = 94;
            // 
            // gridDone
            // 
            this.gridDone.Caption = "Đã đóng";
            this.gridDone.DisplayFormat.FormatString = "n0";
            this.gridDone.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridDone.FieldName = "SOTIENDONG";
            this.gridDone.MinWidth = 25;
            this.gridDone.Name = "gridDone";
            this.gridDone.Visible = true;
            this.gridDone.VisibleIndex = 2;
            this.gridDone.Width = 94;
            // 
            // FormFeeByClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormFeeByClass";
            this.Text = "FormFeeByClass";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMaLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHocKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gcFee;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFee;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.ComboBoxEdit cBYear;
        private DevExpress.XtraEditors.TextEdit textLop;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem textMaLop;
        private DevExpress.XtraLayout.LayoutControlItem comboBox;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem cbHocKy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridName;
        private DevExpress.XtraGrid.Columns.GridColumn gridFee;
        private DevExpress.XtraGrid.Columns.GridColumn gridDone;
    }
}