namespace bigproject
{
    partial class User_borrow_return
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comb_format = new System.Windows.Forms.ComboBox();
            this.btn_borrow = new System.Windows.Forms.Button();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.txt_page = new System.Windows.Forms.TextBox();
            this.txt_publisher = new System.Windows.Forms.TextBox();
            this.txt_author = new System.Windows.Forms.TextBox();
            this.txt_bookName = new System.Windows.Forms.TextBox();
            this.txt_bookNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_return = new System.Windows.Forms.Button();
            this.txt_borrow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(271, 178);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 21);
            this.dateTimePicker1.TabIndex = 61;
            // 
            // comb_format
            // 
            this.comb_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_format.FormattingEnabled = true;
            this.comb_format.Items.AddRange(new object[] {
            "4",
            "8",
            "16",
            "32",
            "40",
            "42",
            "44",
            "50",
            "64"});
            this.comb_format.Location = new System.Drawing.Point(86, 137);
            this.comb_format.Name = "comb_format";
            this.comb_format.Size = new System.Drawing.Size(100, 20);
            this.comb_format.TabIndex = 55;
            // 
            // btn_borrow
            // 
            this.btn_borrow.Location = new System.Drawing.Point(210, 214);
            this.btn_borrow.Name = "btn_borrow";
            this.btn_borrow.Size = new System.Drawing.Size(75, 23);
            this.btn_borrow.TabIndex = 62;
            this.btn_borrow.Text = "借阅";
            this.btn_borrow.UseVisualStyleBackColor = true;
            this.btn_borrow.Click += new System.EventHandler(this.btn_borrow_Click);
            // 
            // txt_price
            // 
            this.txt_price.Location = new System.Drawing.Point(86, 178);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(100, 21);
            this.txt_price.TabIndex = 58;
            // 
            // txt_page
            // 
            this.txt_page.Location = new System.Drawing.Point(271, 135);
            this.txt_page.Name = "txt_page";
            this.txt_page.Size = new System.Drawing.Size(100, 21);
            this.txt_page.TabIndex = 56;
            // 
            // txt_publisher
            // 
            this.txt_publisher.Location = new System.Drawing.Point(271, 92);
            this.txt_publisher.Name = "txt_publisher";
            this.txt_publisher.Size = new System.Drawing.Size(100, 21);
            this.txt_publisher.TabIndex = 53;
            // 
            // txt_author
            // 
            this.txt_author.Location = new System.Drawing.Point(86, 91);
            this.txt_author.Name = "txt_author";
            this.txt_author.Size = new System.Drawing.Size(100, 21);
            this.txt_author.TabIndex = 51;
            // 
            // txt_bookName
            // 
            this.txt_bookName.Location = new System.Drawing.Point(271, 50);
            this.txt_bookName.Name = "txt_bookName";
            this.txt_bookName.Size = new System.Drawing.Size(100, 21);
            this.txt_bookName.TabIndex = 48;
            // 
            // txt_bookNo
            // 
            this.txt_bookNo.Enabled = false;
            this.txt_bookNo.Location = new System.Drawing.Point(86, 50);
            this.txt_bookNo.Name = "txt_bookNo";
            this.txt_bookNo.Size = new System.Drawing.Size(110, 21);
            this.txt_bookNo.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 60;
            this.label8.Text = "入馆时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 59;
            this.label7.Text = "价格";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(231, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 57;
            this.label6.Text = "页数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 54;
            this.label5.Text = "开本";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "出版社";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 49;
            this.label3.Text = "作者";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "书名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "书号";
            // 
            // btn_return
            // 
            this.btn_return.Location = new System.Drawing.Point(308, 214);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(75, 23);
            this.btn_return.TabIndex = 63;
            this.btn_return.Text = "归还";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // txt_borrow
            // 
            this.txt_borrow.Location = new System.Drawing.Point(86, 216);
            this.txt_borrow.Name = "txt_borrow";
            this.txt_borrow.Size = new System.Drawing.Size(100, 21);
            this.txt_borrow.TabIndex = 64;
            // 
            // User_borrow_return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_borrow);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comb_format);
            this.Controls.Add(this.btn_borrow);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.txt_page);
            this.Controls.Add(this.txt_publisher);
            this.Controls.Add(this.txt_author);
            this.Controls.Add(this.txt_bookName);
            this.Controls.Add(this.txt_bookNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "User_borrow_return";
            this.Size = new System.Drawing.Size(433, 286);
            this.Load += new System.EventHandler(this.User_borrow_return_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comb_format;
        private System.Windows.Forms.Button btn_borrow;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.TextBox txt_page;
        private System.Windows.Forms.TextBox txt_publisher;
        private System.Windows.Forms.TextBox txt_author;
        private System.Windows.Forms.TextBox txt_bookName;
        private System.Windows.Forms.TextBox txt_bookNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.TextBox txt_borrow;
    }
}
