namespace DemoDoAn.HOCVIEN
{
    partial class F_TKB_THANHTOAN
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
            this.components = new System.ComponentModel.Container();
            this.txt_VND = new System.Windows.Forms.TextBox();
            this.txt_TienDong = new System.Windows.Forms.TextBox();
            this.picBox_HocPhi = new System.Windows.Forms.PictureBox();
            this.pnl_TienDong = new System.Windows.Forms.Panel();
            this.timer_LoadTrangThai = new System.Windows.Forms.Timer(this.components);
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pBox_Title = new System.Windows.Forms.PictureBox();
            this.pnl_Title = new System.Windows.Forms.Panel();
            this.txt_ChonLopHoc = new System.Windows.Forms.TextBox();
            this.pnl_QLTienHP = new System.Windows.Forms.Panel();
            this.lbl_TienHP = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbb_ChonLopHoc = new DemoDoAn.Custom_Control.RJComboBox();
            this.cbb_ChonKhoaHoc = new DemoDoAn.Custom_Control.RJComboBox();
            this.btn_HoanThanh = new CustomControls.RJControls.RJButton();
            this.btn_TienHP = new CustomControls.RJControls.RJButton();
            this.btn_TienDong = new CustomControls.RJControls.RJButton();
            this.btn_Huy = new CustomControls.RJControls.RJButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_ConNo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rjButton1 = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_HocPhi)).BeginInit();
            this.pnl_TienDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Title)).BeginInit();
            this.pnl_Title.SuspendLayout();
            this.pnl_QLTienHP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_VND
            // 
            this.txt_VND.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(54)))), ((int)(((byte)(96)))));
            this.txt_VND.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_VND.Font = new System.Drawing.Font("SFU Futura", 9.762712F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_VND.ForeColor = System.Drawing.Color.Silver;
            this.txt_VND.Location = new System.Drawing.Point(309, 23);
            this.txt_VND.Name = "txt_VND";
            this.txt_VND.Size = new System.Drawing.Size(43, 24);
            this.txt_VND.TabIndex = 22;
            this.txt_VND.Text = "VNĐ";
            // 
            // txt_TienDong
            // 
            this.txt_TienDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(54)))), ((int)(((byte)(96)))));
            this.txt_TienDong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TienDong.Font = new System.Drawing.Font("SFU Futura", 9.762712F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TienDong.ForeColor = System.Drawing.Color.Silver;
            this.txt_TienDong.Location = new System.Drawing.Point(69, 23);
            this.txt_TienDong.Name = "txt_TienDong";
            this.txt_TienDong.Size = new System.Drawing.Size(270, 24);
            this.txt_TienDong.TabIndex = 22;
            this.txt_TienDong.Text = "Nhập số tiền...";
            // 
            // picBox_HocPhi
            // 
            this.picBox_HocPhi.BackColor = System.Drawing.Color.Transparent;
            this.picBox_HocPhi.Image = global::DemoDoAn.Properties.Resources.calendar_light1;
            this.picBox_HocPhi.Location = new System.Drawing.Point(15, 17);
            this.picBox_HocPhi.Name = "picBox_HocPhi";
            this.picBox_HocPhi.Size = new System.Drawing.Size(35, 35);
            this.picBox_HocPhi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBox_HocPhi.TabIndex = 23;
            this.picBox_HocPhi.TabStop = false;
            // 
            // pnl_TienDong
            // 
            this.pnl_TienDong.Controls.Add(this.txt_VND);
            this.pnl_TienDong.Controls.Add(this.txt_TienDong);
            this.pnl_TienDong.Controls.Add(this.picBox_HocPhi);
            this.pnl_TienDong.Controls.Add(this.btn_TienDong);
            this.pnl_TienDong.Location = new System.Drawing.Point(84, 359);
            this.pnl_TienDong.Name = "pnl_TienDong";
            this.pnl_TienDong.Size = new System.Drawing.Size(371, 71);
            this.pnl_TienDong.TabIndex = 36;
            // 
            // timer_LoadTrangThai
            // 
            this.timer_LoadTrangThai.Interval = 1;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("SFU Futura", 10.98305F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(44, 11);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(212, 26);
            this.lbl_Title.TabIndex = 17;
            this.lbl_Title.Text = "THANH TOÁN HỌC PHÍ";
            // 
            // pBox_Title
            // 
            this.pBox_Title.BackColor = System.Drawing.Color.Transparent;
            this.pBox_Title.Image = global::DemoDoAn.Properties.Resources.QLChung_INFOMATION;
            this.pBox_Title.Location = new System.Drawing.Point(3, 8);
            this.pBox_Title.Name = "pBox_Title";
            this.pBox_Title.Size = new System.Drawing.Size(35, 35);
            this.pBox_Title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pBox_Title.TabIndex = 23;
            this.pBox_Title.TabStop = false;
            // 
            // pnl_Title
            // 
            this.pnl_Title.BackColor = System.Drawing.Color.SlateBlue;
            this.pnl_Title.Controls.Add(this.lbl_Title);
            this.pnl_Title.Controls.Add(this.pBox_Title);
            this.pnl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Title.Location = new System.Drawing.Point(0, 0);
            this.pnl_Title.Name = "pnl_Title";
            this.pnl_Title.Size = new System.Drawing.Size(525, 50);
            this.pnl_Title.TabIndex = 41;
            // 
            // txt_ChonLopHoc
            // 
            this.txt_ChonLopHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(99)))), ((int)(((byte)(173)))));
            this.txt_ChonLopHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ChonLopHoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_ChonLopHoc.Font = new System.Drawing.Font("SFU Futura", 10.98305F);
            this.txt_ChonLopHoc.ForeColor = System.Drawing.Color.Silver;
            this.txt_ChonLopHoc.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt_ChonLopHoc.Location = new System.Drawing.Point(95, 146);
            this.txt_ChonLopHoc.Name = "txt_ChonLopHoc";
            this.txt_ChonLopHoc.ReadOnly = true;
            this.txt_ChonLopHoc.Size = new System.Drawing.Size(145, 26);
            this.txt_ChonLopHoc.TabIndex = 35;
            this.txt_ChonLopHoc.TabStop = false;
            this.txt_ChonLopHoc.Text = "Chọn lớp học...";
            // 
            // pnl_QLTienHP
            // 
            this.pnl_QLTienHP.Controls.Add(this.lbl_TienHP);
            this.pnl_QLTienHP.Controls.Add(this.textBox2);
            this.pnl_QLTienHP.Controls.Add(this.pictureBox2);
            this.pnl_QLTienHP.Controls.Add(this.btn_TienHP);
            this.pnl_QLTienHP.Location = new System.Drawing.Point(84, 187);
            this.pnl_QLTienHP.Name = "pnl_QLTienHP";
            this.pnl_QLTienHP.Size = new System.Drawing.Size(371, 71);
            this.pnl_QLTienHP.TabIndex = 36;
            // 
            // lbl_TienHP
            // 
            this.lbl_TienHP.AutoSize = true;
            this.lbl_TienHP.Font = new System.Drawing.Font("SFU Futura", 9.762712F);
            this.lbl_TienHP.Location = new System.Drawing.Point(75, 22);
            this.lbl_TienHP.Name = "lbl_TienHP";
            this.lbl_TienHP.Size = new System.Drawing.Size(75, 24);
            this.lbl_TienHP.TabIndex = 24;
            this.lbl_TienHP.Text = "500.000";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(54)))), ((int)(((byte)(96)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("SFU Futura", 9.762712F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Silver;
            this.textBox2.Location = new System.Drawing.Point(309, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(43, 24);
            this.textBox2.TabIndex = 22;
            this.textBox2.Text = "VNĐ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::DemoDoAn.Properties.Resources.calendar_light1;
            this.pictureBox2.Location = new System.Drawing.Point(15, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // cbb_ChonLopHoc
            // 
            this.cbb_ChonLopHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(99)))), ((int)(((byte)(173)))));
            this.cbb_ChonLopHoc.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbb_ChonLopHoc.BorderSize = 1;
            this.cbb_ChonLopHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbb_ChonLopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbb_ChonLopHoc.Font = new System.Drawing.Font("SFU Futura", 9.762712F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_ChonLopHoc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbb_ChonLopHoc.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbb_ChonLopHoc.Items.AddRange(new object[] {
            "Anh van",
            "Toeic",
            "Noi ",
            "nghe"});
            this.cbb_ChonLopHoc.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(99)))), ((int)(((byte)(173)))));
            this.cbb_ChonLopHoc.ListTextColor = System.Drawing.Color.WhiteSmoke;
            this.cbb_ChonLopHoc.Location = new System.Drawing.Point(87, 134);
            this.cbb_ChonLopHoc.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbb_ChonLopHoc.Name = "cbb_ChonLopHoc";
            this.cbb_ChonLopHoc.Padding = new System.Windows.Forms.Padding(1);
            this.cbb_ChonLopHoc.Size = new System.Drawing.Size(348, 47);
            this.cbb_ChonLopHoc.TabIndex = 42;
            this.cbb_ChonLopHoc.Texts = "";
            this.cbb_ChonLopHoc.OnSelectedIndexChanged += new System.EventHandler(this.cbb_ChonLopHoc_OnSelectedIndexChanged);
            // 
            // cbb_ChonKhoaHoc
            // 
            this.cbb_ChonKhoaHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(99)))), ((int)(((byte)(173)))));
            this.cbb_ChonKhoaHoc.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbb_ChonKhoaHoc.BorderSize = 1;
            this.cbb_ChonKhoaHoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbb_ChonKhoaHoc.Cursor = System.Windows.Forms.Cursors.No;
            this.cbb_ChonKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbb_ChonKhoaHoc.Font = new System.Drawing.Font("SFU Futura", 9.762712F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_ChonKhoaHoc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbb_ChonKhoaHoc.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbb_ChonKhoaHoc.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(99)))), ((int)(((byte)(173)))));
            this.cbb_ChonKhoaHoc.ListTextColor = System.Drawing.Color.WhiteSmoke;
            this.cbb_ChonKhoaHoc.Location = new System.Drawing.Point(87, 81);
            this.cbb_ChonKhoaHoc.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbb_ChonKhoaHoc.Name = "cbb_ChonKhoaHoc";
            this.cbb_ChonKhoaHoc.Padding = new System.Windows.Forms.Padding(1);
            this.cbb_ChonKhoaHoc.Size = new System.Drawing.Size(348, 47);
            this.cbb_ChonKhoaHoc.TabIndex = 42;
            this.cbb_ChonKhoaHoc.Texts = "";
            this.cbb_ChonKhoaHoc.OnSelectedIndexChanged += new System.EventHandler(this.cbb_ChonKhoaHoc_OnSelectedIndexChanged);
            // 
            // btn_HoanThanh
            // 
            this.btn_HoanThanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_HoanThanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(172)))), ((int)(((byte)(80)))));
            this.btn_HoanThanh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(172)))), ((int)(((byte)(80)))));
            this.btn_HoanThanh.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_HoanThanh.BorderRadius = 5;
            this.btn_HoanThanh.BorderSize = 0;
            this.btn_HoanThanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_HoanThanh.FlatAppearance.BorderSize = 0;
            this.btn_HoanThanh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(216)))), ((int)(((byte)(75)))));
            this.btn_HoanThanh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_HoanThanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HoanThanh.Font = new System.Drawing.Font("Lato", 9.762711F);
            this.btn_HoanThanh.ForeColor = System.Drawing.Color.White;
            this.btn_HoanThanh.Location = new System.Drawing.Point(286, 453);
            this.btn_HoanThanh.Name = "btn_HoanThanh";
            this.btn_HoanThanh.Size = new System.Drawing.Size(150, 40);
            this.btn_HoanThanh.TabIndex = 40;
            this.btn_HoanThanh.Text = "Hoàn Thành";
            this.btn_HoanThanh.TextColor = System.Drawing.Color.White;
            this.btn_HoanThanh.UseVisualStyleBackColor = false;
            this.btn_HoanThanh.Click += new System.EventHandler(this.btn_HoanThanh_Click);
            // 
            // btn_TienHP
            // 
            this.btn_TienHP.BackColor = System.Drawing.Color.Transparent;
            this.btn_TienHP.BackgroundColor = System.Drawing.Color.Transparent;
            this.btn_TienHP.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_TienHP.BorderRadius = 0;
            this.btn_TienHP.BorderSize = 1;
            this.btn_TienHP.FlatAppearance.BorderSize = 0;
            this.btn_TienHP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_TienHP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_TienHP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TienHP.ForeColor = System.Drawing.Color.Transparent;
            this.btn_TienHP.Location = new System.Drawing.Point(7, 10);
            this.btn_TienHP.Name = "btn_TienHP";
            this.btn_TienHP.Size = new System.Drawing.Size(348, 50);
            this.btn_TienHP.TabIndex = 19;
            this.btn_TienHP.TextColor = System.Drawing.Color.Transparent;
            this.btn_TienHP.UseVisualStyleBackColor = false;
            // 
            // btn_TienDong
            // 
            this.btn_TienDong.BackColor = System.Drawing.Color.Transparent;
            this.btn_TienDong.BackgroundColor = System.Drawing.Color.Transparent;
            this.btn_TienDong.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_TienDong.BorderRadius = 0;
            this.btn_TienDong.BorderSize = 1;
            this.btn_TienDong.FlatAppearance.BorderSize = 0;
            this.btn_TienDong.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_TienDong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_TienDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TienDong.ForeColor = System.Drawing.Color.Transparent;
            this.btn_TienDong.Location = new System.Drawing.Point(7, 10);
            this.btn_TienDong.Name = "btn_TienDong";
            this.btn_TienDong.Size = new System.Drawing.Size(348, 50);
            this.btn_TienDong.TabIndex = 19;
            this.btn_TienDong.TextColor = System.Drawing.Color.Transparent;
            this.btn_TienDong.UseVisualStyleBackColor = false;
            // 
            // btn_Huy
            // 
            this.btn_Huy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Huy.BackColor = System.Drawing.Color.Transparent;
            this.btn_Huy.BackgroundColor = System.Drawing.Color.Transparent;
            this.btn_Huy.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_Huy.BorderRadius = 5;
            this.btn_Huy.BorderSize = 1;
            this.btn_Huy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Huy.FlatAppearance.BorderSize = 0;
            this.btn_Huy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(101)))), ((int)(((byte)(110)))));
            this.btn_Huy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(100)))), ((int)(((byte)(147)))));
            this.btn_Huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Huy.Font = new System.Drawing.Font("Lato", 9.762711F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Huy.Location = new System.Drawing.Point(88, 453);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(150, 40);
            this.btn_Huy.TabIndex = 39;
            this.btn_Huy.Text = "Thoát";
            this.btn_Huy.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Huy.UseVisualStyleBackColor = false;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(99)))), ((int)(((byte)(173)))));
            this.panel1.Location = new System.Drawing.Point(393, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(42, 47);
            this.panel1.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_ConNo);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.rjButton1);
            this.panel2.Location = new System.Drawing.Point(84, 276);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 71);
            this.panel2.TabIndex = 36;
            // 
            // lbl_ConNo
            // 
            this.lbl_ConNo.AutoSize = true;
            this.lbl_ConNo.Font = new System.Drawing.Font("SFU Futura", 9.762712F);
            this.lbl_ConNo.Location = new System.Drawing.Point(75, 22);
            this.lbl_ConNo.Name = "lbl_ConNo";
            this.lbl_ConNo.Size = new System.Drawing.Size(75, 24);
            this.lbl_ConNo.TabIndex = 24;
            this.lbl_ConNo.Text = "500.000";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(54)))), ((int)(((byte)(96)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("SFU Futura", 9.762712F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Silver;
            this.textBox1.Location = new System.Drawing.Point(309, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(43, 24);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "VNĐ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::DemoDoAn.Properties.Resources.calendar_light1;
            this.pictureBox1.Location = new System.Drawing.Point(15, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.Transparent;
            this.rjButton1.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 1;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rjButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.Transparent;
            this.rjButton1.Location = new System.Drawing.Point(7, 10);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(348, 50);
            this.rjButton1.TabIndex = 19;
            this.rjButton1.TextColor = System.Drawing.Color.Transparent;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // F_TKB_THANHTOAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 535);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_ChonLopHoc);
            this.Controls.Add(this.cbb_ChonLopHoc);
            this.Controls.Add(this.cbb_ChonKhoaHoc);
            this.Controls.Add(this.btn_HoanThanh);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_QLTienHP);
            this.Controls.Add(this.pnl_TienDong);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.pnl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_TKB_THANHTOAN";
            this.Text = "F_TKB_THANHTOAN";
            this.Load += new System.EventHandler(this.F_TKB_THANHTOAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_HocPhi)).EndInit();
            this.pnl_TienDong.ResumeLayout(false);
            this.pnl_TienDong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Title)).EndInit();
            this.pnl_Title.ResumeLayout(false);
            this.pnl_Title.PerformLayout();
            this.pnl_QLTienHP.ResumeLayout(false);
            this.pnl_QLTienHP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Custom_Control.RJComboBox cbb_ChonKhoaHoc;
        private CustomControls.RJControls.RJButton btn_HoanThanh;
        private System.Windows.Forms.TextBox txt_VND;
        private System.Windows.Forms.TextBox txt_TienDong;
        private System.Windows.Forms.PictureBox picBox_HocPhi;
        private CustomControls.RJControls.RJButton btn_TienDong;
        private System.Windows.Forms.Panel pnl_TienDong;
        private System.Windows.Forms.Timer timer_LoadTrangThai;
        private CustomControls.RJControls.RJButton btn_Huy;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pBox_Title;
        private System.Windows.Forms.Panel pnl_Title;
        private Custom_Control.RJComboBox cbb_ChonLopHoc;
        private System.Windows.Forms.TextBox txt_ChonLopHoc;
        private System.Windows.Forms.Panel pnl_QLTienHP;
        private System.Windows.Forms.Label lbl_TienHP;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private CustomControls.RJControls.RJButton btn_TienHP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_ConNo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJButton rjButton1;
    }
}