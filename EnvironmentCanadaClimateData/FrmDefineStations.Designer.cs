namespace HAWKLORRY
{
    partial class FrmDefineStations
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
            this.tbByName = new System.Windows.Forms.TabPage();
            this.tbFromMap = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBrowse = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.bAddAll = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbByName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbByName);
            this.tabControl1.Controls.Add(this.tbBrowse);
            this.tabControl1.Controls.Add(this.tbFromMap);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(511, 486);
            this.tabControl1.TabIndex = 0;
            // 
            // tbByName
            // 
            this.tbByName.Controls.Add(this.bAddAll);
            this.tbByName.Controls.Add(this.listView1);
            this.tbByName.Controls.Add(this.button1);
            this.tbByName.Controls.Add(this.label1);
            this.tbByName.Controls.Add(this.txtStationName);
            this.tbByName.Location = new System.Drawing.Point(4, 22);
            this.tbByName.Name = "tbByName";
            this.tbByName.Padding = new System.Windows.Forms.Padding(3);
            this.tbByName.Size = new System.Drawing.Size(503, 460);
            this.tbByName.TabIndex = 0;
            this.tbByName.Text = "By Name";
            this.tbByName.UseVisualStyleBackColor = true;
            // 
            // tbFromMap
            // 
            this.tbFromMap.Location = new System.Drawing.Point(4, 22);
            this.tbFromMap.Name = "tbFromMap";
            this.tbFromMap.Padding = new System.Windows.Forms.Padding(3);
            this.tbFromMap.Size = new System.Drawing.Size(503, 460);
            this.tbFromMap.TabIndex = 1;
            this.tbFromMap.Text = "From Map";
            this.tbFromMap.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Size = new System.Drawing.Size(656, 486);
            this.splitContainer1.SplitterDistance = 511;
            this.splitContainer1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(141, 486);
            this.listBox1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(656, 572);
            this.splitContainer2.SplitterDistance = 486;
            this.splitContainer2.TabIndex = 2;
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(97, 13);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(303, 20);
            this.txtStationName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Station Name";
            // 
            // tbBrowse
            // 
            this.tbBrowse.Location = new System.Drawing.Point(4, 22);
            this.tbBrowse.Name = "tbBrowse";
            this.tbBrowse.Size = new System.Drawing.Size(503, 460);
            this.tbBrowse.TabIndex = 2;
            this.tbBrowse.Text = "Browse";
            this.tbBrowse.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(23, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(458, 378);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // bAddAll
            // 
            this.bAddAll.Location = new System.Drawing.Point(23, 431);
            this.bAddAll.Name = "bAddAll";
            this.bAddAll.Size = new System.Drawing.Size(75, 23);
            this.bAddAll.TabIndex = 4;
            this.bAddAll.Text = "Use All";
            this.bAddAll.UseVisualStyleBackColor = true;
            // 
            // FrmDefineStations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 572);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FrmDefineStations";
            this.Text = "Define Stations";
            this.tabControl1.ResumeLayout(false);
            this.tbByName.ResumeLayout(false);
            this.tbByName.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbByName;
        private System.Windows.Forms.TabPage tbFromMap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.TabPage tbBrowse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bAddAll;
        private System.Windows.Forms.ListView listView1;
    }
}