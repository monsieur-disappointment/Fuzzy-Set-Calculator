namespace FuzzySetCalc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.FuzzySetA = new System.Windows.Forms.DataGridView();
            this.alphaLevels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuzzySetB = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuzzySetC = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executeButton = new System.Windows.Forms.Button();
            this.operationSelector = new System.Windows.Forms.ComboBox();
            this.Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.FuzzySetA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuzzySetB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuzzySetC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
            this.SuspendLayout();
            // 
            // FuzzySetA
            // 
            this.FuzzySetA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FuzzySetA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alphaLevels,
            this.lowBorder,
            this.highBorder});
            this.FuzzySetA.Location = new System.Drawing.Point(12, 12);
            this.FuzzySetA.Name = "FuzzySetA";
            this.FuzzySetA.Size = new System.Drawing.Size(269, 150);
            this.FuzzySetA.TabIndex = 0;
            // 
            // alphaLevels
            // 
            this.alphaLevels.HeaderText = "Alpha levels";
            this.alphaLevels.Name = "alphaLevels";
            this.alphaLevels.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.alphaLevels.Width = 75;
            // 
            // lowBorder
            // 
            this.lowBorder.HeaderText = "Low border";
            this.lowBorder.Name = "lowBorder";
            this.lowBorder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lowBorder.Width = 75;
            // 
            // highBorder
            // 
            this.highBorder.HeaderText = "High border";
            this.highBorder.Name = "highBorder";
            this.highBorder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.highBorder.Width = 75;
            // 
            // FuzzySetB
            // 
            this.FuzzySetB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FuzzySetB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.FuzzySetB.Location = new System.Drawing.Point(12, 168);
            this.FuzzySetB.Name = "FuzzySetB";
            this.FuzzySetB.Size = new System.Drawing.Size(269, 150);
            this.FuzzySetB.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Alpha levels";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Low border";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "High border";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // FuzzySetC
            // 
            this.FuzzySetC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FuzzySetC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.FuzzySetC.Location = new System.Drawing.Point(12, 324);
            this.FuzzySetC.Name = "FuzzySetC";
            this.FuzzySetC.Size = new System.Drawing.Size(269, 150);
            this.FuzzySetC.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Alpha levels";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Low border";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "High border";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 75;
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(175, 480);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(106, 61);
            this.executeButton.TabIndex = 3;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // operationSelector
            // 
            this.operationSelector.FormattingEnabled = true;
            this.operationSelector.Items.AddRange(new object[] {
            "Add",
            "Substract",
            "Multiply",
            "Devide",
            "Compare"});
            this.operationSelector.Location = new System.Drawing.Point(12, 501);
            this.operationSelector.Name = "operationSelector";
            this.operationSelector.Size = new System.Drawing.Size(157, 21);
            this.operationSelector.TabIndex = 4;
            // 
            // Graph
            // 
            chartArea2.Name = "ChartArea1";
            this.Graph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Graph.Legends.Add(legend2);
            this.Graph.Location = new System.Drawing.Point(287, 12);
            this.Graph.Name = "Graph";
            series4.BorderWidth = 5;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "A";
            series5.BorderWidth = 5;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "B";
            series6.BorderWidth = 5;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "C";
            this.Graph.Series.Add(series4);
            this.Graph.Series.Add(series5);
            this.Graph.Series.Add(series6);
            this.Graph.Size = new System.Drawing.Size(501, 510);
            this.Graph.TabIndex = 5;
            this.Graph.Text = "Graph";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.operationSelector);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.FuzzySetC);
            this.Controls.Add(this.FuzzySetB);
            this.Controls.Add(this.FuzzySetA);
            this.Name = "Form1";
            this.Text = "Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.FuzzySetA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuzzySetB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuzzySetC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FuzzySetA;
        private System.Windows.Forms.DataGridView FuzzySetB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView FuzzySetC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn alphaLevels;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowBorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn highBorder;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.ComboBox operationSelector;
        private System.Windows.Forms.DataVisualization.Charting.Chart Graph;
    }
}

