namespace VaultWebView
{
    partial class ConfigDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigDialog));
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_tabsListBox = new RefreshingListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_addTabButton = new System.Windows.Forms.Button();
            this.m_deleteTabButton = new System.Windows.Forms.Button();
            this.m_tabSettingControl = new VaultWebView.TabSettingControl();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer)).BeginInit();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_okButton
            // 
            this.m_okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_okButton.Location = new System.Drawing.Point(278, 275);
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.Size = new System.Drawing.Size(75, 23);
            this.m_okButton.TabIndex = 9;
            this.m_okButton.Text = "OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.m_okButton_Click);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelButton.Location = new System.Drawing.Point(359, 275);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_cancelButton.TabIndex = 10;
            this.m_cancelButton.Text = "Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            this.m_cancelButton.Click += new System.EventHandler(this.m_cancelButton_Click);
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_splitContainer.Location = new System.Drawing.Point(12, 12);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_tabsListBox);
            this.m_splitContainer.Panel1.Controls.Add(this.label1);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_tabSettingControl);
            this.m_splitContainer.Size = new System.Drawing.Size(425, 257);
            this.m_splitContainer.SplitterDistance = 109;
            this.m_splitContainer.TabIndex = 12;
            // 
            // m_tabsListBox
            // 
            this.m_tabsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabsListBox.FormattingEnabled = true;
            this.m_tabsListBox.IntegralHeight = false;
            this.m_tabsListBox.Location = new System.Drawing.Point(6, 16);
            this.m_tabsListBox.Name = "m_tabsListBox";
            this.m_tabsListBox.Size = new System.Drawing.Size(100, 238);
            this.m_tabsListBox.TabIndex = 1;
            this.m_tabsListBox.SelectedIndexChanged += new System.EventHandler(this.m_tabsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Web View Tabs:";
            // 
            // m_addTabButton
            // 
            this.m_addTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_addTabButton.Location = new System.Drawing.Point(12, 275);
            this.m_addTabButton.Name = "m_addTabButton";
            this.m_addTabButton.Size = new System.Drawing.Size(75, 23);
            this.m_addTabButton.TabIndex = 13;
            this.m_addTabButton.Text = "Add Tab";
            this.m_addTabButton.UseVisualStyleBackColor = true;
            this.m_addTabButton.Click += new System.EventHandler(this.m_addTabButton_Click);
            // 
            // m_deleteTabButton
            // 
            this.m_deleteTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_deleteTabButton.Location = new System.Drawing.Point(93, 275);
            this.m_deleteTabButton.Name = "m_deleteTabButton";
            this.m_deleteTabButton.Size = new System.Drawing.Size(75, 23);
            this.m_deleteTabButton.TabIndex = 14;
            this.m_deleteTabButton.Text = "Delete Tab";
            this.m_deleteTabButton.UseVisualStyleBackColor = true;
            this.m_deleteTabButton.Click += new System.EventHandler(this.m_deleteTabButton_Click);
            // 
            // m_tabSettingControl
            // 
            this.m_tabSettingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabSettingControl.Location = new System.Drawing.Point(0, 0);
            this.m_tabSettingControl.Name = "m_tabSettingControl";
            this.m_tabSettingControl.Size = new System.Drawing.Size(312, 257);
            this.m_tabSettingControl.TabIndex = 0;
            // 
            // ConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 310);
            this.Controls.Add(this.m_deleteTabButton);
            this.Controls.Add(this.m_addTabButton);
            this.Controls.Add(this.m_splitContainer);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigDialog";
            this.Text = "Web View Configure";
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel1.PerformLayout();
            this.m_splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer)).EndInit();
            this.m_splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.SplitContainer m_splitContainer;
        private RefreshingListBox m_tabsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_addTabButton;
        private System.Windows.Forms.Button m_deleteTabButton;
        private TabSettingControl m_tabSettingControl;
    }
}