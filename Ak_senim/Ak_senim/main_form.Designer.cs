namespace Ak_senim
{
    partial class main_form
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.service_tab = new System.Windows.Forms.TabPage();
            this.report_tab = new System.Windows.Forms.TabPage();
            this.settings_tab = new System.Windows.Forms.TabPage();
            this.booking_tab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.service_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.service_tab);
            this.tabControl1.Controls.Add(this.booking_tab);
            this.tabControl1.Controls.Add(this.report_tab);
            this.tabControl1.Controls.Add(this.settings_tab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(971, 642);
            this.tabControl1.TabIndex = 0;
            // 
            // service_tab
            // 
            this.service_tab.Controls.Add(this.groupBox2);
            this.service_tab.Controls.Add(this.groupBox1);
            this.service_tab.Controls.Add(this.button2);
            this.service_tab.Controls.Add(this.button1);
            this.service_tab.Controls.Add(this.dataGridView1);
            this.service_tab.Location = new System.Drawing.Point(4, 29);
            this.service_tab.Name = "service_tab";
            this.service_tab.Padding = new System.Windows.Forms.Padding(3);
            this.service_tab.Size = new System.Drawing.Size(963, 609);
            this.service_tab.TabIndex = 0;
            this.service_tab.Text = "Service";
            this.service_tab.UseVisualStyleBackColor = true;
            // 
            // report_tab
            // 
            this.report_tab.Location = new System.Drawing.Point(4, 29);
            this.report_tab.Name = "report_tab";
            this.report_tab.Padding = new System.Windows.Forms.Padding(3);
            this.report_tab.Size = new System.Drawing.Size(963, 609);
            this.report_tab.TabIndex = 1;
            this.report_tab.Text = "Report";
            this.report_tab.UseVisualStyleBackColor = true;
            // 
            // settings_tab
            // 
            this.settings_tab.Location = new System.Drawing.Point(4, 29);
            this.settings_tab.Name = "settings_tab";
            this.settings_tab.Padding = new System.Windows.Forms.Padding(3);
            this.settings_tab.Size = new System.Drawing.Size(963, 609);
            this.settings_tab.TabIndex = 2;
            this.settings_tab.Text = "Settings";
            this.settings_tab.UseVisualStyleBackColor = true;
            // 
            // booking_tab
            // 
            this.booking_tab.Location = new System.Drawing.Point(4, 29);
            this.booking_tab.Name = "booking_tab";
            this.booking_tab.Padding = new System.Windows.Forms.Padding(3);
            this.booking_tab.Size = new System.Drawing.Size(963, 609);
            this.booking_tab.TabIndex = 3;
            this.booking_tab.Text = "Booking";
            this.booking_tab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(524, 531);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(9, 544);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(348, 549);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 57);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(548, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 175);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(548, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 192);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service";
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 642);
            this.Controls.Add(this.tabControl1);
            this.Name = "main_form";
            this.Text = "main_form";
            this.tabControl1.ResumeLayout(false);
            this.service_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage service_tab;
        private System.Windows.Forms.TabPage report_tab;
        private System.Windows.Forms.TabPage booking_tab;
        private System.Windows.Forms.TabPage settings_tab;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}