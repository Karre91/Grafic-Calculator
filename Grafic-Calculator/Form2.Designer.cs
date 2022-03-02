namespace Grafic_Calculator
{
    partial class Form2
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
            this.label_Head = new System.Windows.Forms.Label();
            this.listView_History = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label_Head
            // 
            this.label_Head.AutoSize = true;
            this.label_Head.Font = new System.Drawing.Font("ROG Fonts", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Head.Location = new System.Drawing.Point(39, 30);
            this.label_Head.Name = "label_Head";
            this.label_Head.Size = new System.Drawing.Size(114, 20);
            this.label_Head.TabIndex = 0;
            this.label_Head.Text = "Historik";
            // 
            // listView_History
            // 
            this.listView_History.HideSelection = false;
            this.listView_History.Location = new System.Drawing.Point(26, 63);
            this.listView_History.Name = "listView_History";
            this.listView_History.Size = new System.Drawing.Size(322, 365);
            this.listView_History.TabIndex = 1;
            this.listView_History.UseCompatibleStateImageBehavior = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 450);
            this.Controls.Add(this.listView_History);
            this.Controls.Add(this.label_Head);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Head;
        public System.Windows.Forms.ListView listView_History;


    }
}