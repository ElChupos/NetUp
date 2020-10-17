namespace NetUptimeMonitor
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SucceedLabel = new System.Windows.Forms.Label();
            this.FailedLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuccessRoot = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.LastSuccessLabel = new System.Windows.Forms.Label();
            this.FailRoot = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.LastFailLabel = new System.Windows.Forms.Label();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.startTestingLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuccessRoot.SuspendLayout();
            this.FailRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Testing";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Succeeded:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Failed:";
            // 
            // SucceedLabel
            // 
            this.SucceedLabel.AutoSize = true;
            this.SucceedLabel.Location = new System.Drawing.Point(74, 0);
            this.SucceedLabel.Name = "SucceedLabel";
            this.SucceedLabel.Size = new System.Drawing.Size(13, 13);
            this.SucceedLabel.TabIndex = 4;
            this.SucceedLabel.Text = "0";
            // 
            // FailedLabel
            // 
            this.FailedLabel.AutoSize = true;
            this.FailedLabel.Location = new System.Drawing.Point(47, 0);
            this.FailedLabel.Name = "FailedLabel";
            this.FailedLabel.Size = new System.Drawing.Size(13, 13);
            this.FailedLabel.TabIndex = 5;
            this.FailedLabel.Text = "0";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(3, 147);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.startTestingLabel);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.SuccessRoot);
            this.flowLayoutPanel1.Controls.Add(this.FailRoot);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(271, 254);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.SucceedLabel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 71);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(90, 13);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.FailedLabel);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 90);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(63, 13);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // SuccessRoot
            // 
            this.SuccessRoot.AutoSize = true;
            this.SuccessRoot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SuccessRoot.Controls.Add(this.label4);
            this.SuccessRoot.Controls.Add(this.LastSuccessLabel);
            this.SuccessRoot.Location = new System.Drawing.Point(3, 109);
            this.SuccessRoot.Name = "SuccessRoot";
            this.SuccessRoot.Size = new System.Drawing.Size(99, 13);
            this.SuccessRoot.TabIndex = 10;
            this.SuccessRoot.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Last Success:";
            // 
            // LastSuccessLabel
            // 
            this.LastSuccessLabel.AutoSize = true;
            this.LastSuccessLabel.Location = new System.Drawing.Point(83, 0);
            this.LastSuccessLabel.Name = "LastSuccessLabel";
            this.LastSuccessLabel.Size = new System.Drawing.Size(13, 13);
            this.LastSuccessLabel.TabIndex = 5;
            this.LastSuccessLabel.Text = "0";
            // 
            // FailRoot
            // 
            this.FailRoot.AutoSize = true;
            this.FailRoot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FailRoot.Controls.Add(this.label1);
            this.FailRoot.Controls.Add(this.LastFailLabel);
            this.FailRoot.Location = new System.Drawing.Point(3, 128);
            this.FailRoot.Name = "FailRoot";
            this.FailRoot.Size = new System.Drawing.Size(74, 13);
            this.FailRoot.TabIndex = 9;
            this.FailRoot.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Last Fail:";
            // 
            // LastFailLabel
            // 
            this.LastFailLabel.AutoSize = true;
            this.LastFailLabel.Location = new System.Drawing.Point(58, 0);
            this.LastFailLabel.Name = "LastFailLabel";
            this.LastFailLabel.Size = new System.Drawing.Size(13, 13);
            this.LastFailLabel.TabIndex = 5;
            this.LastFailLabel.Text = "0";
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(NetUptimeMonitor.Form1);
            // 
            // startTestingLabel
            // 
            this.startTestingLabel.AutoSize = true;
            this.startTestingLabel.Location = new System.Drawing.Point(3, 55);
            this.startTestingLabel.Name = "startTestingLabel";
            this.startTestingLabel.Size = new System.Drawing.Size(0, 13);
            this.startTestingLabel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 347);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "NetUp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.SuccessRoot.ResumeLayout(false);
            this.SuccessRoot.PerformLayout();
            this.FailRoot.ResumeLayout(false);
            this.FailRoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SucceedLabel;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.Label FailedLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel SuccessRoot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LastSuccessLabel;
        private System.Windows.Forms.FlowLayoutPanel FailRoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LastFailLabel;
        private System.Windows.Forms.Label startTestingLabel;
    }
}

