﻿namespace RPGAdventure
{
    partial class TradeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradeScreen));
            this.lbMyInventory = new System.Windows.Forms.Label();
            this.lbVendorInventory = new System.Windows.Forms.Label();
            this.dgvMyItems = new System.Windows.Forms.DataGridView();
            this.dgvVendorItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMyInventory
            // 
            this.lbMyInventory.AutoSize = true;
            this.lbMyInventory.Location = new System.Drawing.Point(99, 13);
            this.lbMyInventory.Name = "lbMyInventory";
            this.lbMyInventory.Size = new System.Drawing.Size(68, 13);
            this.lbMyInventory.TabIndex = 2;
            this.lbMyInventory.Text = "My Inventory";
            // 
            // lbVendorInventory
            // 
            this.lbVendorInventory.AutoSize = true;
            this.lbVendorInventory.Location = new System.Drawing.Point(349, 13);
            this.lbVendorInventory.Name = "lbVendorInventory";
            this.lbVendorInventory.Size = new System.Drawing.Size(95, 13);
            this.lbVendorInventory.TabIndex = 3;
            this.lbVendorInventory.Text = "Vendor\'s Inventory";
            // 
            // dgvMyItems
            // 
            this.dgvMyItems.AllowUserToAddRows = false;
            this.dgvMyItems.AllowUserToDeleteRows = false;
            this.dgvMyItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyItems.Location = new System.Drawing.Point(13, 43);
            this.dgvMyItems.Name = "dgvMyItems";
            this.dgvMyItems.ReadOnly = true;
            this.dgvMyItems.Size = new System.Drawing.Size(240, 216);
            this.dgvMyItems.TabIndex = 0;
            // 
            // dgvVendorItems
            // 
            this.dgvVendorItems.AllowUserToAddRows = false;
            this.dgvVendorItems.AllowUserToDeleteRows = false;
            this.dgvVendorItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorItems.Location = new System.Drawing.Point(276, 43);
            this.dgvVendorItems.Name = "dgvVendorItems";
            this.dgvVendorItems.ReadOnly = true;
            this.dgvVendorItems.Size = new System.Drawing.Size(240, 216);
            this.dgvVendorItems.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(441, 274);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TradeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 310);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvVendorItems);
            this.Controls.Add(this.dgvMyItems);
            this.Controls.Add(this.lbVendorInventory);
            this.Controls.Add(this.lbMyInventory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TradeScreen";
            this.Text = "Trade";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMyInventory;
        private System.Windows.Forms.Label lbVendorInventory;
        private System.Windows.Forms.DataGridView dgvMyItems;
        private System.Windows.Forms.DataGridView dgvVendorItems;
        private System.Windows.Forms.Button btnClose;
    }
}