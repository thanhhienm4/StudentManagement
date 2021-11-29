
namespace StudentManagement
{
    partial class ucUpdateGrade
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
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.beFaculty = new DevExpress.XtraBars.BarEditItem();
            this.lkFaculty = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.beSchoolYear = new DevExpress.XtraBars.BarEditItem();
            this.cbxSchoolYear = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.beSemester = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.beLoadData = new DevExpress.XtraBars.BarButtonItem();
            this.beSave = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcCreditClass = new DevExpress.XtraGrid.GridControl();
            this.gvCreditClass = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MALTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUpdateGrade = new DevExpress.XtraGrid.GridControl();
            this.gvUpdateGrade = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MASV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DIEM_CC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DIEM_GK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DIEM_CK = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFaculty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCreditClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCreditClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUpdateGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUpdateGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.beSchoolYear,
            this.beSemester,
            this.beLoadData,
            this.beSave,
            this.beFaculty});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbxSchoolYear,
            this.repositoryItemSpinEdit1,
            this.lkFaculty});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beFaculty, "", false, true, true, 84),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beSchoolYear, "", false, true, true, 103),
            new DevExpress.XtraBars.LinkPersistInfo(this.beSemester),
            new DevExpress.XtraBars.LinkPersistInfo(this.beLoadData),
            new DevExpress.XtraBars.LinkPersistInfo(this.beSave)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // beFaculty
            // 
            this.beFaculty.Caption = "Khoa";
            this.beFaculty.Edit = this.lkFaculty;
            this.beFaculty.Id = 5;
            this.beFaculty.Name = "beFaculty";
            this.beFaculty.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.beFaculty.EditValueChanged += new System.EventHandler(this.beFaculty_EditValueChanged);
            // 
            // lkFaculty
            // 
            this.lkFaculty.AutoHeight = false;
            this.lkFaculty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkFaculty.Name = "lkFaculty";
            this.lkFaculty.NullText = "";
            // 
            // beSchoolYear
            // 
            this.beSchoolYear.Caption = "Niên khóa";
            this.beSchoolYear.Edit = this.cbxSchoolYear;
            this.beSchoolYear.Id = 1;
            this.beSchoolYear.Name = "beSchoolYear";
            this.beSchoolYear.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // cbxSchoolYear
            // 
            this.cbxSchoolYear.AutoHeight = false;
            this.cbxSchoolYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxSchoolYear.Name = "cbxSchoolYear";
            // 
            // beSemester
            // 
            this.beSemester.Caption = "HocKy";
            this.beSemester.Edit = this.repositoryItemSpinEdit1;
            this.beSemester.Id = 2;
            this.beSemester.Name = "beSemester";
            this.beSemester.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // beLoadData
            // 
            this.beLoadData.Caption = "Tải dữ liệu";
            this.beLoadData.Id = 3;
            this.beLoadData.ImageOptions.SvgImage = global::StudentManagement.Properties.Resources.actions_refresh;
            this.beLoadData.Name = "beLoadData";
            this.beLoadData.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.beLoadData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.beLoadData_ItemClick);
            // 
            // beSave
            // 
            this.beSave.Caption = "Lưu";
            this.beSave.Id = 4;
            this.beSave.ImageOptions.SvgImage = global::StudentManagement.Properties.Resources.save_as;
            this.beSave.Name = "beSave";
            this.beSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.beSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.beSave_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(932, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 549);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(932, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 515);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(932, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 515);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // bar4
            // 
            this.bar4.BarName = "Main menu";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.FloatLocation = new System.Drawing.Point(242, 164);
            this.bar4.OptionsBar.MultiLine = true;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Main menu";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(3, 40);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcCreditClass);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcUpdateGrade);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(917, 484);
            this.splitContainerControl1.SplitterPosition = 197;
            this.splitContainerControl1.TabIndex = 4;
            // 
            // gcCreditClass
            // 
            this.gcCreditClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCreditClass.Location = new System.Drawing.Point(0, 0);
            this.gcCreditClass.MainView = this.gvCreditClass;
            this.gcCreditClass.MenuManager = this.barManager1;
            this.gcCreditClass.Name = "gcCreditClass";
            this.gcCreditClass.Size = new System.Drawing.Size(917, 197);
            this.gcCreditClass.TabIndex = 1;
            this.gcCreditClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCreditClass});
            // 
            // gvCreditClass
            // 
            this.gvCreditClass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MALTC,
            this.MAMH,
            this.TENMH,
            this.MAGV,
            this.NHOM,
            this.TENGV});
            this.gvCreditClass.GridControl = this.gcCreditClass;
            this.gvCreditClass.Name = "gvCreditClass";
            this.gvCreditClass.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCreditClass_FocusedRowChanged_1);
            // 
            // MALTC
            // 
            this.MALTC.Caption = "Mã lớp";
            this.MALTC.FieldName = "MALTC";
            this.MALTC.MinWidth = 30;
            this.MALTC.Name = "MALTC";
            this.MALTC.Visible = true;
            this.MALTC.VisibleIndex = 0;
            this.MALTC.Width = 112;
            // 
            // MAMH
            // 
            this.MAMH.Caption = "Mã môn học";
            this.MAMH.FieldName = "MAMH";
            this.MAMH.MinWidth = 30;
            this.MAMH.Name = "MAMH";
            this.MAMH.Visible = true;
            this.MAMH.VisibleIndex = 1;
            this.MAMH.Width = 112;
            // 
            // TENMH
            // 
            this.TENMH.Caption = "Tên môn học";
            this.TENMH.FieldName = "TENMH";
            this.TENMH.MinWidth = 30;
            this.TENMH.Name = "TENMH";
            this.TENMH.Visible = true;
            this.TENMH.VisibleIndex = 2;
            this.TENMH.Width = 112;
            // 
            // MAGV
            // 
            this.MAGV.Caption = "mã giảng viên";
            this.MAGV.FieldName = "MAGV";
            this.MAGV.MinWidth = 30;
            this.MAGV.Name = "MAGV";
            this.MAGV.Visible = true;
            this.MAGV.VisibleIndex = 3;
            this.MAGV.Width = 112;
            // 
            // NHOM
            // 
            this.NHOM.Caption = "gridColumn1";
            this.NHOM.FieldName = "NHOM";
            this.NHOM.MinWidth = 30;
            this.NHOM.Name = "NHOM";
            this.NHOM.Visible = true;
            this.NHOM.VisibleIndex = 4;
            this.NHOM.Width = 112;
            // 
            // TENGV
            // 
            this.TENGV.Caption = "Tên giảng viên";
            this.TENGV.FieldName = "TENGV";
            this.TENGV.MinWidth = 30;
            this.TENGV.Name = "TENGV";
            this.TENGV.Visible = true;
            this.TENGV.VisibleIndex = 5;
            this.TENGV.Width = 112;
            // 
            // gcUpdateGrade
            // 
            this.gcUpdateGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUpdateGrade.Location = new System.Drawing.Point(0, 0);
            this.gcUpdateGrade.MainView = this.gvUpdateGrade;
            this.gcUpdateGrade.MenuManager = this.barManager1;
            this.gcUpdateGrade.Name = "gcUpdateGrade";
            this.gcUpdateGrade.Size = new System.Drawing.Size(917, 272);
            this.gcUpdateGrade.TabIndex = 0;
            this.gcUpdateGrade.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUpdateGrade});
            // 
            // gvUpdateGrade
            // 
            this.gvUpdateGrade.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MASV,
            this.TENSV,
            this.DIEM_CC,
            this.DIEM_GK,
            this.DIEM_CK});
            this.gvUpdateGrade.GridControl = this.gcUpdateGrade;
            this.gvUpdateGrade.Name = "gvUpdateGrade";
            this.gvUpdateGrade.OptionsView.ShowGroupPanel = false;
            this.gvUpdateGrade.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvUpdateGrade_FocusedRowChanged);
            // 
            // MASV
            // 
            this.MASV.Caption = "Mã sinh viên";
            this.MASV.FieldName = "MASV";
            this.MASV.MinWidth = 30;
            this.MASV.Name = "MASV";
            this.MASV.Visible = true;
            this.MASV.VisibleIndex = 0;
            this.MASV.Width = 112;
            // 
            // TENSV
            // 
            this.TENSV.Caption = "Tên sinh viên";
            this.TENSV.FieldName = "TENSV";
            this.TENSV.MinWidth = 30;
            this.TENSV.Name = "TENSV";
            this.TENSV.Visible = true;
            this.TENSV.VisibleIndex = 1;
            this.TENSV.Width = 112;
            // 
            // DIEM_CC
            // 
            this.DIEM_CC.Caption = "Điểm chuyên cần";
            this.DIEM_CC.FieldName = "DIEM_CC";
            this.DIEM_CC.MinWidth = 30;
            this.DIEM_CC.Name = "DIEM_CC";
            this.DIEM_CC.Visible = true;
            this.DIEM_CC.VisibleIndex = 2;
            this.DIEM_CC.Width = 112;
            // 
            // DIEM_GK
            // 
            this.DIEM_GK.Caption = "Điểm giữa kì";
            this.DIEM_GK.FieldName = "DIEM_GK";
            this.DIEM_GK.MinWidth = 30;
            this.DIEM_GK.Name = "DIEM_GK";
            this.DIEM_GK.Visible = true;
            this.DIEM_GK.VisibleIndex = 3;
            this.DIEM_GK.Width = 112;
            // 
            // DIEM_CK
            // 
            this.DIEM_CK.Caption = "Điểm cuối kì";
            this.DIEM_CK.FieldName = "DIEM_CK";
            this.DIEM_CK.MinWidth = 30;
            this.DIEM_CK.Name = "DIEM_CK";
            this.DIEM_CK.Visible = true;
            this.DIEM_CK.VisibleIndex = 4;
            this.DIEM_CK.Width = 112;
            // 
            // ucUpdateGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucUpdateGrade";
            this.Size = new System.Drawing.Size(932, 569);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFaculty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCreditClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCreditClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUpdateGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUpdateGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarEditItem beSchoolYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbxSchoolYear;
        private DevExpress.XtraBars.BarEditItem beSemester;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.BarButtonItem beLoadData;
        private DevExpress.XtraBars.BarButtonItem beSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarEditItem beFaculty;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkFaculty;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcUpdateGrade;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUpdateGrade;
        private DevExpress.XtraGrid.Columns.GridColumn MASV;
        private DevExpress.XtraGrid.Columns.GridColumn TENSV;
        private DevExpress.XtraGrid.Columns.GridColumn DIEM_CC;
        private DevExpress.XtraGrid.Columns.GridColumn DIEM_GK;
        private DevExpress.XtraGrid.Columns.GridColumn DIEM_CK;
        private DevExpress.XtraGrid.GridControl gcCreditClass;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCreditClass;
        private DevExpress.XtraGrid.Columns.GridColumn MALTC;
        private DevExpress.XtraGrid.Columns.GridColumn MAMH;
        private DevExpress.XtraGrid.Columns.GridColumn TENMH;
        private DevExpress.XtraGrid.Columns.GridColumn MAGV;
        private DevExpress.XtraGrid.Columns.GridColumn NHOM;
        private DevExpress.XtraGrid.Columns.GridColumn TENGV;
    }
}
