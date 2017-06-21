namespace InvoiceTemplateTestHarness
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbHeader = new System.Windows.Forms.TextBox();
            this.txbBody = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbFooter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateInvoice = new System.Windows.Forms.Button();
            this.txbOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnHeaderOpen = new System.Windows.Forms.Button();
            this.btnBodyOpen = new System.Windows.Forms.Button();
            this.btnFooterOpen = new System.Windows.Forms.Button();
            this.btnSetLocation = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txbTemplateOption = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Header";
            // 
            // txbHeader
            // 
            this.txbHeader.Location = new System.Drawing.Point(102, 40);
            this.txbHeader.Name = "txbHeader";
            this.txbHeader.Size = new System.Drawing.Size(551, 20);
            this.txbHeader.TabIndex = 1;
            // 
            // txbBody
            // 
            this.txbBody.Location = new System.Drawing.Point(102, 97);
            this.txbBody.Name = "txbBody";
            this.txbBody.Size = new System.Drawing.Size(551, 20);
            this.txbBody.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Body";
            // 
            // txbFooter
            // 
            this.txbFooter.Location = new System.Drawing.Point(102, 154);
            this.txbFooter.Name = "txbFooter";
            this.txbFooter.Size = new System.Drawing.Size(551, 20);
            this.txbFooter.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Footer";
            // 
            // btnCreateInvoice
            // 
            this.btnCreateInvoice.Location = new System.Drawing.Point(439, 332);
            this.btnCreateInvoice.Name = "btnCreateInvoice";
            this.btnCreateInvoice.Size = new System.Drawing.Size(141, 23);
            this.btnCreateInvoice.TabIndex = 6;
            this.btnCreateInvoice.Text = "Create Invoice";
            this.btnCreateInvoice.UseVisualStyleBackColor = true;
            this.btnCreateInvoice.Click += new System.EventHandler(this.btnCreateInvoice_Click);
            // 
            // txbOutput
            // 
            this.txbOutput.Location = new System.Drawing.Point(102, 271);
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.Size = new System.Drawing.Size(551, 20);
            this.txbOutput.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output Location";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnHeaderOpen
            // 
            this.btnHeaderOpen.Location = new System.Drawing.Point(659, 40);
            this.btnHeaderOpen.Name = "btnHeaderOpen";
            this.btnHeaderOpen.Size = new System.Drawing.Size(75, 23);
            this.btnHeaderOpen.TabIndex = 9;
            this.btnHeaderOpen.Text = "Find File";
            this.btnHeaderOpen.UseVisualStyleBackColor = true;
            this.btnHeaderOpen.Click += new System.EventHandler(this.btnHeaderOpen_Click);
            // 
            // btnBodyOpen
            // 
            this.btnBodyOpen.Location = new System.Drawing.Point(659, 97);
            this.btnBodyOpen.Name = "btnBodyOpen";
            this.btnBodyOpen.Size = new System.Drawing.Size(75, 23);
            this.btnBodyOpen.TabIndex = 10;
            this.btnBodyOpen.Text = "Find File";
            this.btnBodyOpen.UseVisualStyleBackColor = true;
            this.btnBodyOpen.Click += new System.EventHandler(this.btnBodyOpen_Click);
            // 
            // btnFooterOpen
            // 
            this.btnFooterOpen.Location = new System.Drawing.Point(659, 154);
            this.btnFooterOpen.Name = "btnFooterOpen";
            this.btnFooterOpen.Size = new System.Drawing.Size(75, 23);
            this.btnFooterOpen.TabIndex = 11;
            this.btnFooterOpen.Text = "Find File";
            this.btnFooterOpen.UseVisualStyleBackColor = true;
            this.btnFooterOpen.Click += new System.EventHandler(this.btnFooterOpen_Click);
            // 
            // btnSetLocation
            // 
            this.btnSetLocation.Location = new System.Drawing.Point(659, 271);
            this.btnSetLocation.Name = "btnSetLocation";
            this.btnSetLocation.Size = new System.Drawing.Size(75, 23);
            this.btnSetLocation.TabIndex = 12;
            this.btnSetLocation.Text = "Set Location";
            this.btnSetLocation.UseVisualStyleBackColor = true;
            this.btnSetLocation.Click += new System.EventHandler(this.btnSetLocation_Click);
            // 
            // txbTemplateOption
            // 
            this.txbTemplateOption.Location = new System.Drawing.Point(102, 203);
            this.txbTemplateOption.Name = "txbTemplateOption";
            this.txbTemplateOption.Size = new System.Drawing.Size(908, 20);
            this.txbTemplateOption.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "TemplateOptions";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 229);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(908, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "[{\'HeaderHeight\':120,\'FooterHeight\':null,\'PageMargin\':{\'LeftMargin\':50,\'TopMargin" +
    "\':10,\'RightMargin\':10,\'BottomMargin\':3,\'Color\':\'White\'},\'IsLandscapeOrientation\'" +
    ":true}]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 382);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txbTemplateOption);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSetLocation);
            this.Controls.Add(this.btnFooterOpen);
            this.Controls.Add(this.btnBodyOpen);
            this.Controls.Add(this.btnHeaderOpen);
            this.Controls.Add(this.txbOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCreateInvoice);
            this.Controls.Add(this.txbFooter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbBody);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbHeader);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Invoice Template Test Harness";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbHeader;
        private System.Windows.Forms.TextBox txbBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbFooter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateInvoice;
        private System.Windows.Forms.TextBox txbOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnHeaderOpen;
        private System.Windows.Forms.Button btnBodyOpen;
        private System.Windows.Forms.Button btnFooterOpen;
        private System.Windows.Forms.Button btnSetLocation;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txbTemplateOption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
    }
}

