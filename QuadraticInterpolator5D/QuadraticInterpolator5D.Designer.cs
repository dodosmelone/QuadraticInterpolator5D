﻿namespace QuadraticInterplator5D
{
    partial class QuadraticInterpolator5D
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "a1",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("a2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("a3");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("a4");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("a5");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("a6");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("a7");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("a8");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("a9");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("a10");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("a11");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("a12");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("a13");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("a14");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("a15");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("a16");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("a17");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("a18");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("a19");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("a20");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuadraticInterpolator5D));
            this.btnLoadSamplingPoints = new System.Windows.Forms.Button();
            this.gbSamplingPoints = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lvSamplingPoints = new System.Windows.Forms.ListView();
            this.columnHeaderX1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderX2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderX3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderX4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderX5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbWhichX = new System.Windows.Forms.GroupBox();
            this.rbComputeForX5 = new System.Windows.Forms.RadioButton();
            this.rbComputeForX4 = new System.Windows.Forms.RadioButton();
            this.rbComputeForX3 = new System.Windows.Forms.RadioButton();
            this.rbComputeForX2 = new System.Windows.Forms.RadioButton();
            this.rbComputeForX1 = new System.Windows.Forms.RadioButton();
            this.gbCoefficients = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.lvCoefficients = new System.Windows.Forms.ListView();
            this.chCoefficient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPolyConcrete = new System.Windows.Forms.Label();
            this.lbPolyAbstract = new System.Windows.Forms.Label();
            this.columnHeaderX6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbComputeForX6 = new System.Windows.Forms.RadioButton();
            this.gbSamplingPoints.SuspendLayout();
            this.gbWhichX.SuspendLayout();
            this.gbCoefficients.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadSamplingPoints
            // 
            this.btnLoadSamplingPoints.Location = new System.Drawing.Point(261, 462);
            this.btnLoadSamplingPoints.Name = "btnLoadSamplingPoints";
            this.btnLoadSamplingPoints.Size = new System.Drawing.Size(98, 36);
            this.btnLoadSamplingPoints.TabIndex = 0;
            this.btnLoadSamplingPoints.Text = "Load Sampling Points";
            this.btnLoadSamplingPoints.UseVisualStyleBackColor = true;
            this.btnLoadSamplingPoints.Click += new System.EventHandler(this.btnLoadSamplingPoints_Click);
            // 
            // gbSamplingPoints
            // 
            this.gbSamplingPoints.Controls.Add(this.btnClear);
            this.gbSamplingPoints.Controls.Add(this.btnLoadSamplingPoints);
            this.gbSamplingPoints.Controls.Add(this.lvSamplingPoints);
            this.gbSamplingPoints.Location = new System.Drawing.Point(12, 9);
            this.gbSamplingPoints.Name = "gbSamplingPoints";
            this.gbSamplingPoints.Size = new System.Drawing.Size(620, 504);
            this.gbSamplingPoints.TabIndex = 1;
            this.gbSamplingPoints.TabStop = false;
            this.gbSamplingPoints.Text = "Sampling Points";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(516, 462);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 36);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear Sampling Points";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lvSamplingPoints
            // 
            this.lvSamplingPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderX1,
            this.columnHeaderX2,
            this.columnHeaderX3,
            this.columnHeaderX4,
            this.columnHeaderX5,
            this.columnHeaderX6});
            this.lvSamplingPoints.HideSelection = false;
            this.lvSamplingPoints.Location = new System.Drawing.Point(6, 20);
            this.lvSamplingPoints.Name = "lvSamplingPoints";
            this.lvSamplingPoints.Size = new System.Drawing.Size(608, 436);
            this.lvSamplingPoints.TabIndex = 1;
            this.lvSamplingPoints.UseCompatibleStateImageBehavior = false;
            this.lvSamplingPoints.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderX1
            // 
            this.columnHeaderX1.Text = "X1";
            this.columnHeaderX1.Width = 100;
            // 
            // columnHeaderX2
            // 
            this.columnHeaderX2.Text = "X2";
            this.columnHeaderX2.Width = 100;
            // 
            // columnHeaderX3
            // 
            this.columnHeaderX3.Text = "X3";
            this.columnHeaderX3.Width = 100;
            // 
            // columnHeaderX4
            // 
            this.columnHeaderX4.Text = "X4";
            this.columnHeaderX4.Width = 100;
            // 
            // columnHeaderX5
            // 
            this.columnHeaderX5.Text = "X5";
            this.columnHeaderX5.Width = 100;
            // 
            // gbWhichX
            // 
            this.gbWhichX.Controls.Add(this.rbComputeForX6);
            this.gbWhichX.Controls.Add(this.rbComputeForX5);
            this.gbWhichX.Controls.Add(this.rbComputeForX4);
            this.gbWhichX.Controls.Add(this.rbComputeForX3);
            this.gbWhichX.Controls.Add(this.rbComputeForX2);
            this.gbWhichX.Controls.Add(this.rbComputeForX1);
            this.gbWhichX.Location = new System.Drawing.Point(644, 9);
            this.gbWhichX.Name = "gbWhichX";
            this.gbWhichX.Size = new System.Drawing.Size(125, 221);
            this.gbWhichX.TabIndex = 3;
            this.gbWhichX.TabStop = false;
            this.gbWhichX.Text = "Compute for which?";
            // 
            // rbComputeForX5
            // 
            this.rbComputeForX5.AutoSize = true;
            this.rbComputeForX5.Location = new System.Drawing.Point(45, 154);
            this.rbComputeForX5.Name = "rbComputeForX5";
            this.rbComputeForX5.Size = new System.Drawing.Size(38, 17);
            this.rbComputeForX5.TabIndex = 4;
            this.rbComputeForX5.Text = "X5";
            this.rbComputeForX5.UseVisualStyleBackColor = true;
            // 
            // rbComputeForX4
            // 
            this.rbComputeForX4.AutoSize = true;
            this.rbComputeForX4.Location = new System.Drawing.Point(45, 124);
            this.rbComputeForX4.Name = "rbComputeForX4";
            this.rbComputeForX4.Size = new System.Drawing.Size(38, 17);
            this.rbComputeForX4.TabIndex = 3;
            this.rbComputeForX4.Text = "X4";
            this.rbComputeForX4.UseVisualStyleBackColor = true;
            this.rbComputeForX4.CheckedChanged += new System.EventHandler(this.rbComputeForXCheckedChanged);
            // 
            // rbComputeForX3
            // 
            this.rbComputeForX3.AutoSize = true;
            this.rbComputeForX3.Location = new System.Drawing.Point(45, 93);
            this.rbComputeForX3.Name = "rbComputeForX3";
            this.rbComputeForX3.Size = new System.Drawing.Size(38, 17);
            this.rbComputeForX3.TabIndex = 2;
            this.rbComputeForX3.Text = "X3";
            this.rbComputeForX3.UseVisualStyleBackColor = true;
            this.rbComputeForX3.CheckedChanged += new System.EventHandler(this.rbComputeForXCheckedChanged);
            // 
            // rbComputeForX2
            // 
            this.rbComputeForX2.AutoSize = true;
            this.rbComputeForX2.Location = new System.Drawing.Point(45, 63);
            this.rbComputeForX2.Name = "rbComputeForX2";
            this.rbComputeForX2.Size = new System.Drawing.Size(38, 17);
            this.rbComputeForX2.TabIndex = 1;
            this.rbComputeForX2.Text = "X2";
            this.rbComputeForX2.UseVisualStyleBackColor = true;
            this.rbComputeForX2.CheckedChanged += new System.EventHandler(this.rbComputeForXCheckedChanged);
            // 
            // rbComputeForX1
            // 
            this.rbComputeForX1.AutoSize = true;
            this.rbComputeForX1.Location = new System.Drawing.Point(45, 32);
            this.rbComputeForX1.Name = "rbComputeForX1";
            this.rbComputeForX1.Size = new System.Drawing.Size(38, 17);
            this.rbComputeForX1.TabIndex = 0;
            this.rbComputeForX1.Text = "X1";
            this.rbComputeForX1.UseVisualStyleBackColor = true;
            this.rbComputeForX1.CheckedChanged += new System.EventHandler(this.rbComputeForXCheckedChanged);
            // 
            // gbCoefficients
            // 
            this.gbCoefficients.Controls.Add(this.btnExport);
            this.gbCoefficients.Controls.Add(this.lvCoefficients);
            this.gbCoefficients.Location = new System.Drawing.Point(779, 9);
            this.gbCoefficients.Name = "gbCoefficients";
            this.gbCoefficients.Size = new System.Drawing.Size(263, 221);
            this.gbCoefficients.TabIndex = 2;
            this.gbCoefficients.TabStop = false;
            this.gbCoefficients.Text = "Coefficients";
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(85, 177);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(98, 36);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export Coefficients";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lvCoefficients
            // 
            this.lvCoefficients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCoefficient,
            this.chValue});
            this.lvCoefficients.HideSelection = false;
            this.lvCoefficients.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20});
            this.lvCoefficients.Location = new System.Drawing.Point(6, 19);
            this.lvCoefficients.Name = "lvCoefficients";
            this.lvCoefficients.Size = new System.Drawing.Size(251, 152);
            this.lvCoefficients.TabIndex = 1;
            this.lvCoefficients.UseCompatibleStateImageBehavior = false;
            this.lvCoefficients.View = System.Windows.Forms.View.Details;
            // 
            // chCoefficient
            // 
            this.chCoefficient.Text = "Coefficient";
            this.chCoefficient.Width = 65;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 163;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPolyConcrete);
            this.groupBox1.Controls.Add(this.lbPolyAbstract);
            this.groupBox1.Location = new System.Drawing.Point(638, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 277);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Computed polynomial";
            // 
            // lbPolyConcrete
            // 
            this.lbPolyConcrete.AutoSize = true;
            this.lbPolyConcrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPolyConcrete.Location = new System.Drawing.Point(12, 131);
            this.lbPolyConcrete.MaximumSize = new System.Drawing.Size(380, 0);
            this.lbPolyConcrete.Name = "lbPolyConcrete";
            this.lbPolyConcrete.Size = new System.Drawing.Size(332, 128);
            this.lbPolyConcrete.TabIndex = 1;
            this.lbPolyConcrete.Text = resources.GetString("lbPolyConcrete.Text");
            // 
            // lbPolyAbstract
            // 
            this.lbPolyAbstract.AutoSize = true;
            this.lbPolyAbstract.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPolyAbstract.Location = new System.Drawing.Point(12, 23);
            this.lbPolyAbstract.Name = "lbPolyAbstract";
            this.lbPolyAbstract.Size = new System.Drawing.Size(366, 80);
            this.lbPolyAbstract.TabIndex = 0;
            this.lbPolyAbstract.Text = resources.GetString("lbPolyAbstract.Text");
            // 
            // columnHeaderX6
            // 
            this.columnHeaderX6.Text = "X6";
            this.columnHeaderX6.Width = 100;
            // 
            // rbComputeForX6
            // 
            this.rbComputeForX6.AutoSize = true;
            this.rbComputeForX6.Checked = true;
            this.rbComputeForX6.Location = new System.Drawing.Point(45, 183);
            this.rbComputeForX6.Name = "rbComputeForX6";
            this.rbComputeForX6.Size = new System.Drawing.Size(38, 17);
            this.rbComputeForX6.TabIndex = 5;
            this.rbComputeForX6.Text = "X6";
            this.rbComputeForX6.UseVisualStyleBackColor = true;
            // 
            // QuadraticInterpolator5D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 525);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbCoefficients);
            this.Controls.Add(this.gbWhichX);
            this.Controls.Add(this.gbSamplingPoints);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "QuadraticInterpolator5D";
            this.Text = "Quadratic Interpolator 5D";
            this.gbSamplingPoints.ResumeLayout(false);
            this.gbWhichX.ResumeLayout(false);
            this.gbWhichX.PerformLayout();
            this.gbCoefficients.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadSamplingPoints;
        private System.Windows.Forms.GroupBox gbSamplingPoints;
        private System.Windows.Forms.ListView lvSamplingPoints;
        private System.Windows.Forms.ColumnHeader columnHeaderX1;
        private System.Windows.Forms.ColumnHeader columnHeaderX2;
        private System.Windows.Forms.ColumnHeader columnHeaderX3;
        private System.Windows.Forms.GroupBox gbWhichX;
        private System.Windows.Forms.RadioButton rbComputeForX3;
        private System.Windows.Forms.RadioButton rbComputeForX2;
        private System.Windows.Forms.RadioButton rbComputeForX1;
        private System.Windows.Forms.GroupBox gbCoefficients;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ListView lvCoefficients;
        private System.Windows.Forms.ColumnHeader chCoefficient;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbPolyConcrete;
        private System.Windows.Forms.Label lbPolyAbstract;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ColumnHeader columnHeaderX4;
        private System.Windows.Forms.RadioButton rbComputeForX4;
        private System.Windows.Forms.ColumnHeader columnHeaderX5;
        private System.Windows.Forms.RadioButton rbComputeForX5;
        private System.Windows.Forms.ColumnHeader columnHeaderX6;
        private System.Windows.Forms.RadioButton rbComputeForX6;
    }
}

