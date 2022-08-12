namespace StudentManageApp
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.tbClass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSchool = new System.Windows.Forms.TextBox();
            this.tbMajor = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbHP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbFeature = new System.Windows.Forms.TextBox();
            this.tbCounsel = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMoveFirst = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnMoveLast = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.도구toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.백업ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.과정별학생관리프로그램도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(55, 342);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1444, 307);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(76, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "학생번호";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(76, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "이름";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(76, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "나이";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(76, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "과정명";
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbID.Location = new System.Drawing.Point(210, 47);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(142, 37);
            this.tbID.TabIndex = 5;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbName.Location = new System.Drawing.Point(210, 121);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(259, 37);
            this.tbName.TabIndex = 6;
            // 
            // tbAge
            // 
            this.tbAge.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbAge.Location = new System.Drawing.Point(210, 197);
            this.tbAge.Name = "tbAge";
            this.tbAge.Size = new System.Drawing.Size(142, 37);
            this.tbAge.TabIndex = 7;
            // 
            // tbClass
            // 
            this.tbClass.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbClass.Location = new System.Drawing.Point(210, 265);
            this.tbClass.Name = "tbClass";
            this.tbClass.Size = new System.Drawing.Size(259, 37);
            this.tbClass.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(558, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "대학교";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(558, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 30);
            this.label6.TabIndex = 10;
            this.label6.Text = "전공";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(558, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 30);
            this.label7.TabIndex = 11;
            this.label7.Text = "이메일";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(558, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 30);
            this.label8.TabIndex = 12;
            this.label8.Text = "전화번호";
            // 
            // tbSchool
            // 
            this.tbSchool.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSchool.Location = new System.Drawing.Point(672, 54);
            this.tbSchool.Name = "tbSchool";
            this.tbSchool.Size = new System.Drawing.Size(259, 37);
            this.tbSchool.TabIndex = 13;
            // 
            // tbMajor
            // 
            this.tbMajor.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMajor.Location = new System.Drawing.Point(672, 121);
            this.tbMajor.Name = "tbMajor";
            this.tbMajor.Size = new System.Drawing.Size(259, 37);
            this.tbMajor.TabIndex = 14;
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbEmail.Location = new System.Drawing.Point(672, 200);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(259, 37);
            this.tbEmail.TabIndex = 15;
            // 
            // tbHP
            // 
            this.tbHP.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbHP.Location = new System.Drawing.Point(672, 272);
            this.tbHP.Name = "tbHP";
            this.tbHP.Size = new System.Drawing.Size(259, 37);
            this.tbHP.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(1022, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 30);
            this.label9.TabIndex = 17;
            this.label9.Text = "특징";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(1022, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 30);
            this.label10.TabIndex = 18;
            this.label10.Text = "상담";
            // 
            // tbFeature
            // 
            this.tbFeature.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbFeature.Location = new System.Drawing.Point(1102, 61);
            this.tbFeature.Multiline = true;
            this.tbFeature.Name = "tbFeature";
            this.tbFeature.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFeature.Size = new System.Drawing.Size(326, 97);
            this.tbFeature.TabIndex = 19;
            // 
            // tbCounsel
            // 
            this.tbCounsel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCounsel.Location = new System.Drawing.Point(1102, 207);
            this.tbCounsel.Multiline = true;
            this.tbCounsel.Name = "tbCounsel";
            this.tbCounsel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCounsel.Size = new System.Drawing.Size(326, 97);
            this.tbCounsel.TabIndex = 20;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInsert.Location = new System.Drawing.Point(55, 698);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 50);
            this.btnInsert.TabIndex = 21;
            this.btnInsert.Text = "추가";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(176, 698);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 50);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(299, 698);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 50);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(417, 698);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 50);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnMoveFirst
            // 
            this.btnMoveFirst.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveFirst.Location = new System.Drawing.Point(593, 698);
            this.btnMoveFirst.Name = "btnMoveFirst";
            this.btnMoveFirst.Size = new System.Drawing.Size(100, 50);
            this.btnMoveFirst.TabIndex = 25;
            this.btnMoveFirst.Text = "처음";
            this.btnMoveFirst.UseVisualStyleBackColor = true;
            this.btnMoveFirst.Click += new System.EventHandler(this.btnMoveFirst_Click);
            // 
            // btnPre
            // 
            this.btnPre.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPre.Location = new System.Drawing.Point(720, 698);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(100, 50);
            this.btnPre.TabIndex = 26;
            this.btnPre.Text = "<<";
            this.btnPre.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNext.Location = new System.Drawing.Point(847, 698);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 50);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnMoveLast
            // 
            this.btnMoveLast.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveLast.Location = new System.Drawing.Point(979, 698);
            this.btnMoveLast.Name = "btnMoveLast";
            this.btnMoveLast.Size = new System.Drawing.Size(100, 50);
            this.btnMoveLast.TabIndex = 28;
            this.btnMoveLast.Text = "마지막";
            this.btnMoveLast.UseVisualStyleBackColor = true;
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox11.Location = new System.Drawing.Point(1145, 665);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(119, 37);
            this.textBox11.TabIndex = 29;
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox12.Location = new System.Drawing.Point(1145, 721);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(258, 37);
            this.textBox12.TabIndex = 30;
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMove.Location = new System.Drawing.Point(1303, 658);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(100, 50);
            this.btnMove.TabIndex = 31;
            this.btnMove.Text = "이동";
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(1430, 708);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 50);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일toolStripMenuItem1,
            this.도구toolStripMenuItem2,
            this.도움말toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1562, 33);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일toolStripMenuItem1
            // 
            this.파일toolStripMenuItem1.Name = "파일toolStripMenuItem1";
            this.파일toolStripMenuItem1.Size = new System.Drawing.Size(83, 29);
            this.파일toolStripMenuItem1.Text = "파일(&F)";
            // 
            // 도구toolStripMenuItem2
            // 
            this.도구toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.백업ToolStripMenuItem});
            this.도구toolStripMenuItem2.Name = "도구toolStripMenuItem2";
            this.도구toolStripMenuItem2.Size = new System.Drawing.Size(87, 29);
            this.도구toolStripMenuItem2.Text = "도구(&D)";
            // 
            // 백업ToolStripMenuItem
            // 
            this.백업ToolStripMenuItem.Name = "백업ToolStripMenuItem";
            this.백업ToolStripMenuItem.Size = new System.Drawing.Size(171, 34);
            this.백업ToolStripMenuItem.Text = "백업(&B)";
            // 
            // 도움말toolStripMenuItem3
            // 
            this.도움말toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.과정별학생관리프로그램도움말ToolStripMenuItem});
            this.도움말toolStripMenuItem3.Name = "도움말toolStripMenuItem3";
            this.도움말toolStripMenuItem3.Size = new System.Drawing.Size(105, 29);
            this.도움말toolStripMenuItem3.Text = "도움말(&H)";
            // 
            // 과정별학생관리프로그램도움말ToolStripMenuItem
            // 
            this.과정별학생관리프로그램도움말ToolStripMenuItem.Name = "과정별학생관리프로그램도움말ToolStripMenuItem";
            this.과정별학생관리프로그램도움말ToolStripMenuItem.Size = new System.Drawing.Size(384, 34);
            this.과정별학생관리프로그램도움말ToolStripMenuItem.Text = "과정별 학생관리 프로그램 도움말";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 780);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1562, 37);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslCount
            // 
            this.sslCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sslCount.Name = "sslCount";
            this.sslCount.Size = new System.Drawing.Size(79, 30);
            this.sslCount.Text = "등록수";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1562, 817);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.btnMoveLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnMoveFirst);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.tbCounsel);
            this.Controls.Add(this.tbFeature);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbHP);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbMajor);
            this.Controls.Add(this.tbSchool);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbClass);
            this.Controls.Add(this.tbAge);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "과정별 학생관리 프로그램";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAge;
        private System.Windows.Forms.TextBox tbClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSchool;
        private System.Windows.Forms.TextBox tbMajor;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbHP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbFeature;
        private System.Windows.Forms.TextBox tbCounsel;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnMoveFirst;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnMoveLast;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 도구toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 도움말toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 백업ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 과정별학생관리프로그램도움말ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslCount;
    }
}

