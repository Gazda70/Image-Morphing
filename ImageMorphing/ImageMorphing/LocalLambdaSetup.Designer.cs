
using System;

namespace ImageMorphing
{
    partial class LocalLambdaSetup
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
            this.localLambdaInfoLabel = new System.Windows.Forms.Label();
            this.localLambdaValueTrackBar = new System.Windows.Forms.TrackBar();
            this.localLambdaValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.localLambdaValueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // localLambdaInfoLabel
            // 
            this.localLambdaInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.localLambdaInfoLabel.Location = new System.Drawing.Point(49, 125);
            this.localLambdaInfoLabel.Name = "localLambdaInfoLabel";
            this.localLambdaInfoLabel.Size = new System.Drawing.Size(702, 55);
            this.localLambdaInfoLabel.TabIndex = 0;
            this.localLambdaInfoLabel.Text = "Choose lambda value for this point";
            // 
            // localLambdaValueTrackBar
            // 
            this.localLambdaValueTrackBar.Location = new System.Drawing.Point(239, 218);
            this.localLambdaValueTrackBar.Name = "localLambdaValueTrackBar";
            this.localLambdaValueTrackBar.Size = new System.Drawing.Size(288, 56);
            this.localLambdaValueTrackBar.TabIndex = 1;
            this.localLambdaValueTrackBar.Scroll += new System.EventHandler(this.localLambdaValueTrackBar_Scroll);
            // 
            // localLambdaValueLabel
            // 
            this.localLambdaValueLabel.Location = new System.Drawing.Point(239, 309);
            this.localLambdaValueLabel.Name = "localLambdaValueLabel";
            this.localLambdaValueLabel.Size = new System.Drawing.Size(288, 77);
            this.localLambdaValueLabel.TabIndex = 2;
            // 
            // LocalLambdaSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.localLambdaValueLabel);
            this.Controls.Add(this.localLambdaValueTrackBar);
            this.Controls.Add(this.localLambdaInfoLabel);
            this.Name = "LocalLambdaSetup";
            this.Text = "LocalLambdaSetup";
            ((System.ComponentModel.ISupportInitialize)(this.localLambdaValueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void localLambdaValueTrackBar_Scroll(object sender, EventArgs e)
        {
            parentForm.addNewLocalLambda(System.Convert.ToDouble(System.Convert.ToDouble(localLambdaValueTrackBar.Value)
                        / System.Convert.ToDouble(this.localLambdaValueTrackBar.Maximum)));
        }
        public void setLocalLambda(Form1 newParentForm)
        {
            this.parentForm = newParentForm;
        }

        Form1 parentForm;
        private System.Windows.Forms.Label localLambdaInfoLabel;
        private System.Windows.Forms.TrackBar localLambdaValueTrackBar;
        private System.Windows.Forms.Label localLambdaValueLabel;
    }
}