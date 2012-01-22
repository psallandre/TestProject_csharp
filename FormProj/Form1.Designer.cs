namespace FormProj
{
	partial class Form1
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataSet1 = new FormProj.DataSet1();
			this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.feuil1BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.feuil1_TableAdapter = new FormProj.DataSet1TableAdapters.Feuil1_TableAdapter();
			this.englishDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.frenchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.feuil1BindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.englishDataGridViewTextBoxColumn,
            this.frenchDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.feuil1BindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(23, 18);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(201, 172);
			this.dataGridView1.TabIndex = 0;
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "DataSet1";
			this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// dataSet1BindingSource
			// 
			this.dataSet1BindingSource.DataSource = this.dataSet1;
			this.dataSet1BindingSource.Position = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(290, 38);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(117, 35);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// feuil1BindingSource
			// 
			this.feuil1BindingSource.DataMember = "Feuil1$";
			this.feuil1BindingSource.DataSource = this.dataSet1BindingSource;
			// 
			// feuil1_TableAdapter
			// 
			this.feuil1_TableAdapter.ClearBeforeFill = true;
			// 
			// englishDataGridViewTextBoxColumn
			// 
			this.englishDataGridViewTextBoxColumn.DataPropertyName = "English";
			this.englishDataGridViewTextBoxColumn.HeaderText = "English";
			this.englishDataGridViewTextBoxColumn.Name = "englishDataGridViewTextBoxColumn";
			// 
			// frenchDataGridViewTextBoxColumn
			// 
			this.frenchDataGridViewTextBoxColumn.DataPropertyName = "French";
			this.frenchDataGridViewTextBoxColumn.HeaderText = "French";
			this.frenchDataGridViewTextBoxColumn.Name = "frenchDataGridViewTextBoxColumn";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 417);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.feuil1BindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource dataSet1BindingSource;
		private DataSet1 dataSet1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.BindingSource feuil1BindingSource;
		private DataSet1TableAdapters.Feuil1_TableAdapter feuil1_TableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn englishDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn frenchDataGridViewTextBoxColumn;
	}
}

