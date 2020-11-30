namespace ImageMorphing
{
    partial class NotSameDimensionsPopup
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(161, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Images not of the same size!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Convert to first image size";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(handleSecondNotMatching);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Convert to second image size";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(handleFirstNotMatching);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(532, 221);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Abort";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(handleAbort);
            // 
            // PopupOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "PopupOne";
            this.Text = "PopupOne";
            this.ResumeLayout(false);

        }

        #endregion
        private void handleSecondNotMatching(object sender, System.EventArgs e) { 
            setConvertSecondToFirst(true);
            this.Close();
        }

        private void handleFirstNotMatching(object sender, System.EventArgs e) {
            setConvertFirstToSecond(true);
            this.Close();
        }

        private void handleAbort(object sender, System.EventArgs e) { this.Close(); }

        private void setConvertFirstToSecond(bool newValue) { this.convertFirstToSecond = newValue; }
        private void setConvertSecondToFirst(bool newValue) { this.convertSecondToFirst = newValue; }

        public bool getConvertFirstToSecond() { return this.convertFirstToSecond; }

        public bool getConvertSecondToFirst() { return this.convertSecondToFirst; }

        private bool convertSecondToFirst = false;
        private bool convertFirstToSecond = false;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}