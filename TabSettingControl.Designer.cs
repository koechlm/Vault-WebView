namespace VaultWebView
{
    partial class TabSettingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.m_tabNameTextBox = new System.Windows.Forms.TextBox();
            this.m_urlTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_entCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tab Name:";
            // 
            // m_tabNameTextBox
            // 
            this.m_tabNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabNameTextBox.Location = new System.Drawing.Point(77, 9);
            this.m_tabNameTextBox.Name = "m_tabNameTextBox";
            this.m_tabNameTextBox.Size = new System.Drawing.Size(289, 20);
            this.m_tabNameTextBox.TabIndex = 1;
            // 
            // m_urlTextBox
            // 
            this.m_urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_urlTextBox.Location = new System.Drawing.Point(77, 35);
            this.m_urlTextBox.Name = "m_urlTextBox";
            this.m_urlTextBox.Size = new System.Drawing.Size(289, 20);
            this.m_urlTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Entity Types:";
            // 
            // m_entCheckedListBox
            // 
            this.m_entCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_entCheckedListBox.CheckOnClick = true;
            this.m_entCheckedListBox.FormattingEnabled = true;
            this.m_entCheckedListBox.IntegralHeight = false;
            this.m_entCheckedListBox.Location = new System.Drawing.Point(77, 61);
            this.m_entCheckedListBox.Name = "m_entCheckedListBox";
            this.m_entCheckedListBox.Size = new System.Drawing.Size(289, 234);
            this.m_entCheckedListBox.TabIndex = 5;
            // 
            // TabSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_entCheckedListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_urlTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_tabNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "TabSettingControl";
            this.Size = new System.Drawing.Size(369, 298);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_tabNameTextBox;
        private System.Windows.Forms.TextBox m_urlTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox m_entCheckedListBox;
    }
}
