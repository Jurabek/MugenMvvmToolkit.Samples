﻿namespace ApiExamples.Views
{
    partial class ContentFormContentManager
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
            this.viewBinder = new ApiExamples.ViewBinder(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // viewBinder
            // 
            this.viewBinder.Bindings = "<Bindings>\n  <ContentFormContentManager Content=\"ViewModel\"  ContentViewManager=\"" +
    "$contentViewManager\" />\n</Bindings>";
            this.viewBinder.ContainerControl = this;
            this.viewBinder.IgnoreControlException = true;
            this.viewBinder.RootTagName = "Bindings";
            // 
            // ContentFormContentManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "ContentFormContentManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContentForm";
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ViewBinder viewBinder;
    }
}