namespace DemoDoAn.ChildPage
{
    partial class UC_GM_ROOM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_GM_ROOM));
            this.pnl_ThanhNgang_TitlePage = new System.Windows.Forms.Panel();
            this.lbl_QuanLiPhong = new System.Windows.Forms.Label();
            this.lbl_DanhMucPhongHoc = new System.Windows.Forms.Label();
            this.fLPnl_TrangThai = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_TrangThaiTitle = new System.Windows.Forms.Panel();
            this.pnl_ThanhNgangTrangThai = new System.Windows.Forms.Panel();
            this.btn_TrangThai = new System.Windows.Forms.Button();
            this.btn_TT_HoatDong = new System.Windows.Forms.Button();
            this.btn_TT_DaDay = new System.Windows.Forms.Button();
            this.timer_LoadTrangThai = new System.Windows.Forms.Timer(this.components);
            this.dataGrView_DSPhongHoc = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnl_Search = new System.Windows.Forms.Panel();
            this.pnl_ThanhDungSearch = new System.Windows.Forms.Panel();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.pBox_Search = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnReset = new CustomControls.RJControls.RJButton();
            this.btnTaoPhongMoi = new CustomControls.RJControls.RJButton();
            this.btnTimKiem = new CustomControls.RJControls.RJButton();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fLPnl_TrangThai.SuspendLayout();
            this.pnl_TrangThaiTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrView_DSPhongHoc)).BeginInit();
            this.pnl_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_ThanhNgang_TitlePage
            // 
            this.pnl_ThanhNgang_TitlePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(127)))), ((int)(((byte)(245)))));
            this.pnl_ThanhNgang_TitlePage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_ThanhNgang_TitlePage.Location = new System.Drawing.Point(50, 59);
            this.pnl_ThanhNgang_TitlePage.Name = "pnl_ThanhNgang_TitlePage";
            this.pnl_ThanhNgang_TitlePage.Size = new System.Drawing.Size(153, 1);
            this.pnl_ThanhNgang_TitlePage.TabIndex = 13;
            // 
            // lbl_QuanLiPhong
            // 
            this.lbl_QuanLiPhong.AutoSize = true;
            this.lbl_QuanLiPhong.Font = new System.Drawing.Font("SFU Futura", 10.98305F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuanLiPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_QuanLiPhong.Location = new System.Drawing.Point(41, 29);
            this.lbl_QuanLiPhong.Name = "lbl_QuanLiPhong";
            this.lbl_QuanLiPhong.Size = new System.Drawing.Size(220, 27);
            this.lbl_QuanLiPhong.TabIndex = 14;
            this.lbl_QuanLiPhong.Text = "QUẢN LÍ PHÒNG HỌC";
            // 
            // lbl_DanhMucPhongHoc
            // 
            this.lbl_DanhMucPhongHoc.AutoSize = true;
            this.lbl_DanhMucPhongHoc.Font = new System.Drawing.Font("SFU Futura", 9.152542F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DanhMucPhongHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_DanhMucPhongHoc.Location = new System.Drawing.Point(46, 65);
            this.lbl_DanhMucPhongHoc.Name = "lbl_DanhMucPhongHoc";
            this.lbl_DanhMucPhongHoc.Size = new System.Drawing.Size(146, 21);
            this.lbl_DanhMucPhongHoc.TabIndex = 15;
            this.lbl_DanhMucPhongHoc.Text = "Danh mục phòng học";
            // 
            // fLPnl_TrangThai
            // 
            this.fLPnl_TrangThai.BackColor = System.Drawing.Color.White;
            this.fLPnl_TrangThai.Controls.Add(this.pnl_TrangThaiTitle);
            this.fLPnl_TrangThai.Controls.Add(this.btn_TT_HoatDong);
            this.fLPnl_TrangThai.Controls.Add(this.btn_TT_DaDay);
            this.fLPnl_TrangThai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fLPnl_TrangThai.Location = new System.Drawing.Point(448, 139);
            this.fLPnl_TrangThai.MaximumSize = new System.Drawing.Size(200, 135);
            this.fLPnl_TrangThai.MinimumSize = new System.Drawing.Size(200, 46);
            this.fLPnl_TrangThai.Name = "fLPnl_TrangThai";
            this.fLPnl_TrangThai.Size = new System.Drawing.Size(200, 46);
            this.fLPnl_TrangThai.TabIndex = 12;
            this.fLPnl_TrangThai.Visible = false;
            // 
            // pnl_TrangThaiTitle
            // 
            this.pnl_TrangThaiTitle.Controls.Add(this.pnl_ThanhNgangTrangThai);
            this.pnl_TrangThaiTitle.Controls.Add(this.btn_TrangThai);
            this.pnl_TrangThaiTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TrangThaiTitle.Location = new System.Drawing.Point(0, 0);
            this.pnl_TrangThaiTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_TrangThaiTitle.Name = "pnl_TrangThaiTitle";
            this.pnl_TrangThaiTitle.Size = new System.Drawing.Size(200, 45);
            this.pnl_TrangThaiTitle.TabIndex = 0;
            // 
            // pnl_ThanhNgangTrangThai
            // 
            this.pnl_ThanhNgangTrangThai.BackColor = System.Drawing.Color.White;
            this.pnl_ThanhNgangTrangThai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_ThanhNgangTrangThai.Location = new System.Drawing.Point(0, 44);
            this.pnl_ThanhNgangTrangThai.Name = "pnl_ThanhNgangTrangThai";
            this.pnl_ThanhNgangTrangThai.Size = new System.Drawing.Size(200, 1);
            this.pnl_ThanhNgangTrangThai.TabIndex = 8;
            // 
            // btn_TrangThai
            // 
            this.btn_TrangThai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(135)))), ((int)(((byte)(239)))));
            this.btn_TrangThai.FlatAppearance.BorderSize = 0;
            this.btn_TrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TrangThai.Font = new System.Drawing.Font("SFU Futura", 10.98305F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TrangThai.ForeColor = System.Drawing.Color.White;
            this.btn_TrangThai.Image = global::DemoDoAn.Properties.Resources.angle_down;
            this.btn_TrangThai.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TrangThai.Location = new System.Drawing.Point(0, 3);
            this.btn_TrangThai.Name = "btn_TrangThai";
            this.btn_TrangThai.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btn_TrangThai.Size = new System.Drawing.Size(200, 45);
            this.btn_TrangThai.TabIndex = 11;
            this.btn_TrangThai.Text = "Trạng Thái";
            this.btn_TrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TrangThai.UseVisualStyleBackColor = false;
            this.btn_TrangThai.Click += new System.EventHandler(this.btn_TrangThai_Click);
            // 
            // btn_TT_HoatDong
            // 
            this.btn_TT_HoatDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(177)))), ((int)(((byte)(247)))));
            this.btn_TT_HoatDong.FlatAppearance.BorderSize = 0;
            this.btn_TT_HoatDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TT_HoatDong.Font = new System.Drawing.Font("SFU Futura", 9.152542F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TT_HoatDong.ForeColor = System.Drawing.Color.White;
            this.btn_TT_HoatDong.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TT_HoatDong.Location = new System.Drawing.Point(0, 45);
            this.btn_TT_HoatDong.Margin = new System.Windows.Forms.Padding(0);
            this.btn_TT_HoatDong.Name = "btn_TT_HoatDong";
            this.btn_TT_HoatDong.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.btn_TT_HoatDong.Size = new System.Drawing.Size(200, 45);
            this.btn_TT_HoatDong.TabIndex = 11;
            this.btn_TT_HoatDong.Text = "Hoạt Động";
            this.btn_TT_HoatDong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TT_HoatDong.UseVisualStyleBackColor = false;
            this.btn_TT_HoatDong.Click += new System.EventHandler(this.btn_TT_HoatDong_Click);
            // 
            // btn_TT_DaDay
            // 
            this.btn_TT_DaDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(177)))), ((int)(((byte)(247)))));
            this.btn_TT_DaDay.FlatAppearance.BorderSize = 0;
            this.btn_TT_DaDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TT_DaDay.Font = new System.Drawing.Font("SFU Futura", 9.152542F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TT_DaDay.ForeColor = System.Drawing.Color.White;
            this.btn_TT_DaDay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TT_DaDay.Location = new System.Drawing.Point(0, 90);
            this.btn_TT_DaDay.Margin = new System.Windows.Forms.Padding(0);
            this.btn_TT_DaDay.Name = "btn_TT_DaDay";
            this.btn_TT_DaDay.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.btn_TT_DaDay.Size = new System.Drawing.Size(200, 45);
            this.btn_TT_DaDay.TabIndex = 12;
            this.btn_TT_DaDay.Text = "Đã Đầy";
            this.btn_TT_DaDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TT_DaDay.UseVisualStyleBackColor = false;
            this.btn_TT_DaDay.Click += new System.EventHandler(this.btn_TT_DaDay_Click);
            // 
            // timer_LoadTrangThai
            // 
            this.timer_LoadTrangThai.Interval = 1;
            this.timer_LoadTrangThai.Tick += new System.EventHandler(this.timer_LoadTrangThai_Tick);
            // 
            // dataGrView_DSPhongHoc
            // 
            this.dataGrView_DSPhongHoc.AllowUserToAddRows = false;
            this.dataGrView_DSPhongHoc.BackgroundColor = System.Drawing.Color.White;
            this.dataGrView_DSPhongHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrView_DSPhongHoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGrView_DSPhongHoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(135)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SFU Futura", 9.152542F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(135)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrView_DSPhongHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrView_DSPhongHoc.ColumnHeadersHeight = 50;
            this.dataGrView_DSPhongHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrView_DSPhongHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Phong,
            this.TrangThai});
            this.dataGrView_DSPhongHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lato", 9.152543F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(177)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrView_DSPhongHoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrView_DSPhongHoc.EnableHeadersVisualStyles = false;
            this.dataGrView_DSPhongHoc.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrView_DSPhongHoc.Location = new System.Drawing.Point(46, 250);
            this.dataGrView_DSPhongHoc.Name = "dataGrView_DSPhongHoc";
            this.dataGrView_DSPhongHoc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lato", 9.152543F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(177)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrView_DSPhongHoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrView_DSPhongHoc.RowHeadersWidth = 50;
            this.dataGrView_DSPhongHoc.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGrView_DSPhongHoc.RowTemplate.Height = 40;
            this.dataGrView_DSPhongHoc.RowTemplate.ReadOnly = true;
            this.dataGrView_DSPhongHoc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrView_DSPhongHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrView_DSPhongHoc.Size = new System.Drawing.Size(1362, 514);
            this.dataGrView_DSPhongHoc.TabIndex = 20;
            this.dataGrView_DSPhongHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrView_DSPhongHoc_CellClick);
            this.dataGrView_DSPhongHoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGrView_DSPhongHoc_RowPostPaint);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.FillWeight = 239.3617F;
            this.dataGridViewImageColumn1.HeaderText = "Sửa";
            this.dataGridViewImageColumn1.Image = global::DemoDoAn.Properties.Resources.refresh;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn2.FillWeight = 82.57979F;
            this.dataGridViewImageColumn2.HeaderText = "Xóa";
            this.dataGridViewImageColumn2.Image = global::DemoDoAn.Properties.Resources.delete;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // pnl_Search
            // 
            this.pnl_Search.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Search.BackgroundImage = global::DemoDoAn.Properties.Resources.BG_Search_1_3x;
            this.pnl_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Search.Controls.Add(this.pnl_ThanhDungSearch);
            this.pnl_Search.Controls.Add(this.txt_Search);
            this.pnl_Search.Controls.Add(this.pBox_Search);
            this.pnl_Search.Location = new System.Drawing.Point(46, 116);
            this.pnl_Search.Name = "pnl_Search";
            this.pnl_Search.Size = new System.Drawing.Size(396, 96);
            this.pnl_Search.TabIndex = 16;
            // 
            // pnl_ThanhDungSearch
            // 
            this.pnl_ThanhDungSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(127)))), ((int)(((byte)(245)))));
            this.pnl_ThanhDungSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_ThanhDungSearch.Location = new System.Drawing.Point(73, 71);
            this.pnl_ThanhDungSearch.Name = "pnl_ThanhDungSearch";
            this.pnl_ThanhDungSearch.Size = new System.Drawing.Size(250, 1);
            this.pnl_ThanhDungSearch.TabIndex = 8;
            // 
            // txt_Search
            // 
            this.txt_Search.BackColor = System.Drawing.Color.White;
            this.txt_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Search.Font = new System.Drawing.Font("SFU Futura", 9.762712F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.ForeColor = System.Drawing.Color.Silver;
            this.txt_Search.Location = new System.Drawing.Point(75, 36);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(259, 24);
            this.txt_Search.TabIndex = 1;
            this.txt_Search.Text = "Search...";
            this.txt_Search.Click += new System.EventHandler(this.txt_Search_Click);
            // 
            // pBox_Search
            // 
            this.pBox_Search.BackColor = System.Drawing.Color.Transparent;
            this.pBox_Search.Image = global::DemoDoAn.Properties.Resources.search;
            this.pBox_Search.Location = new System.Drawing.Point(38, 31);
            this.pBox_Search.Name = "pBox_Search";
            this.pBox_Search.Size = new System.Drawing.Size(35, 35);
            this.pBox_Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pBox_Search.TabIndex = 5;
            this.pBox_Search.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "bạn đang tải lại thông tin";
            this.notifyIcon1.BalloonTipTitle = "Tải thông tin";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIconLoad";
            this.notifyIcon1.Visible = true;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(101)))), ((int)(((byte)(110)))));
            this.btnReset.BorderRadius = 5;
            this.btnReset.BorderSize = 2;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("SFU Futura", 9.152542F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Transparent;
            this.btnReset.Image = global::DemoDoAn.Properties.Resources.reset;
            this.btnReset.Location = new System.Drawing.Point(720, 138);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 43);
            this.btnReset.TabIndex = 18;
            this.btnReset.TextColor = System.Drawing.Color.Transparent;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTaoPhongMoi
            // 
            this.btnTaoPhongMoi.BackColor = System.Drawing.Color.White;
            this.btnTaoPhongMoi.BackgroundColor = System.Drawing.Color.White;
            this.btnTaoPhongMoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(172)))), ((int)(((byte)(80)))));
            this.btnTaoPhongMoi.BorderRadius = 5;
            this.btnTaoPhongMoi.BorderSize = 2;
            this.btnTaoPhongMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoPhongMoi.FlatAppearance.BorderSize = 0;
            this.btnTaoPhongMoi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTaoPhongMoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTaoPhongMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoPhongMoi.Font = new System.Drawing.Font("Lato", 9.152543F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPhongMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(172)))), ((int)(((byte)(80)))));
            this.btnTaoPhongMoi.Image = global::DemoDoAn.Properties.Resources.plus;
            this.btnTaoPhongMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoPhongMoi.Location = new System.Drawing.Point(1221, 139);
            this.btnTaoPhongMoi.Name = "btnTaoPhongMoi";
            this.btnTaoPhongMoi.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnTaoPhongMoi.Size = new System.Drawing.Size(171, 43);
            this.btnTaoPhongMoi.TabIndex = 19;
            this.btnTaoPhongMoi.Text = "Thêm Phòng";
            this.btnTaoPhongMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaoPhongMoi.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(172)))), ((int)(((byte)(80)))));
            this.btnTaoPhongMoi.UseVisualStyleBackColor = false;
            this.btnTaoPhongMoi.Click += new System.EventHandler(this.btnTaoPhongMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(132)))), ((int)(((byte)(233)))));
            this.btnTimKiem.BorderRadius = 5;
            this.btnTimKiem.BorderSize = 2;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("SFU Futura", 9.152542F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.Image = global::DemoDoAn.Properties.Resources.search2;
            this.btnTimKiem.Location = new System.Drawing.Point(669, 138);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(45, 43);
            this.btnTimKiem.TabIndex = 17;
            this.btnTimKiem.TextColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 123;
            // 
            // Phong
            // 
            this.Phong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Phong.DataPropertyName = "Phong";
            this.Phong.FillWeight = 82.57979F;
            this.Phong.HeaderText = "Tên phòng học";
            this.Phong.MinimumWidth = 6;
            this.Phong.Name = "Phong";
            // 
            // TrangThai
            // 
            this.TrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.FillWeight = 82.57979F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            // 
            // UC_GM_ROOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnTaoPhongMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.pnl_Search);
            this.Controls.Add(this.fLPnl_TrangThai);
            this.Controls.Add(this.pnl_ThanhNgang_TitlePage);
            this.Controls.Add(this.lbl_QuanLiPhong);
            this.Controls.Add(this.lbl_DanhMucPhongHoc);
            this.Controls.Add(this.dataGrView_DSPhongHoc);
            this.Name = "UC_GM_ROOM";
            this.Size = new System.Drawing.Size(1456, 902);
            this.Load += new System.EventHandler(this.UC_GM_ROOM_Load);
            this.fLPnl_TrangThai.ResumeLayout(false);
            this.pnl_TrangThaiTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrView_DSPhongHoc)).EndInit();
            this.pnl_Search.ResumeLayout(false);
            this.pnl_Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnl_ThanhNgang_TitlePage;
        private System.Windows.Forms.Label lbl_QuanLiPhong;
        private System.Windows.Forms.Label lbl_DanhMucPhongHoc;
        private System.Windows.Forms.Panel pnl_Search;
        private System.Windows.Forms.Panel pnl_ThanhDungSearch;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.PictureBox pBox_Search;
        private System.Windows.Forms.FlowLayoutPanel fLPnl_TrangThai;
        private System.Windows.Forms.Panel pnl_TrangThaiTitle;
        private System.Windows.Forms.Panel pnl_ThanhNgangTrangThai;
        private System.Windows.Forms.Button btn_TrangThai;
        private System.Windows.Forms.Button btn_TT_HoatDong;
        private System.Windows.Forms.Button btn_TT_DaDay;
        private CustomControls.RJControls.RJButton btnTimKiem;
        private CustomControls.RJControls.RJButton btnReset;
        private CustomControls.RJControls.RJButton btnTaoPhongMoi;
        private System.Windows.Forms.Timer timer_LoadTrangThai;
        private System.Windows.Forms.DataGridView dataGrView_DSPhongHoc;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}
