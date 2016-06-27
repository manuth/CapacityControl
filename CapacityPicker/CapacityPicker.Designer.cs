namespace CapacityPicker
{
    partial class CapacityPicker
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.valueUpDown = new System.Windows.Forms.NumericUpDown();
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.capacityUnitSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacityUnitSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainPanel.Controls.Add(this.valueUpDown, 0, 0);
            this.mainPanel.Controls.Add(this.unitComboBox, 1, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 1;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Size = new System.Drawing.Size(229, 27);
            this.mainPanel.TabIndex = 0;
            // 
            // valueUpDown
            // 
            this.valueUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.valueUpDown.DecimalPlaces = 2;
            this.valueUpDown.Location = new System.Drawing.Point(3, 3);
            this.valueUpDown.Maximum = new decimal(new int[] {
            -1511828489,
            2147483,
            0,
            0});
            this.valueUpDown.Name = "valueUpDown";
            this.valueUpDown.Size = new System.Drawing.Size(131, 20);
            this.valueUpDown.TabIndex = 1;
            this.valueUpDown.ThousandsSeparator = true;
            this.valueUpDown.ValueChanged += new System.EventHandler(this.valueUpDown_ValueChanged);
            // 
            // unitComboBox
            // 
            this.unitComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unitComboBox.DataSource = this.capacityUnitSource;
            this.unitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitComboBox.FormattingEnabled = true;
            this.unitComboBox.Location = new System.Drawing.Point(140, 3);
            this.unitComboBox.Name = "unitComboBox";
            this.unitComboBox.Size = new System.Drawing.Size(86, 21);
            this.unitComboBox.TabIndex = 2;
            this.unitComboBox.SelectedValueChanged += new System.EventHandler(this.unitComboBox_SelectedValueChanged);
            // 
            // CapacityPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CapacityPicker";
            this.Size = new System.Drawing.Size(229, 27);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.valueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacityUnitSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.NumericUpDown valueUpDown;
        private System.Windows.Forms.ComboBox unitComboBox;
        private System.Windows.Forms.BindingSource capacityUnitSource;
    }
}
