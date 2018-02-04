namespace CaritasManager
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.ts_Tools = new System.Windows.Forms.ToolStrip();
			this.btn_NewCustomer = new System.Windows.Forms.ToolStripButton();
			this.btn_Settings = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.dg_DataTable = new System.Windows.Forms.DataGridView();
			this.ch_CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_jovedelemig = new System.Windows.Forms.DataGridViewImageColumn();
			this.ch_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_PlaceOfResidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_DateAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_LastSupport = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_AddSupport = new System.Windows.Forms.DataGridViewButtonColumn();
			this.tt_Tooltip = new CaritasManager.uc_Tooltip();
			this.t_Timer = new System.Windows.Forms.Timer(this.components);
			this.btn_Exit = new System.Windows.Forms.ToolStripButton();
			this.btn_DatabaseBackup = new System.Windows.Forms.ToolStripButton();
			this.ts_Tools.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dg_DataTable)).BeginInit();
			this.SuspendLayout();
			// 
			// ts_Tools
			// 
			this.ts_Tools.AutoSize = false;
			this.ts_Tools.BackColor = System.Drawing.Color.Transparent;
			this.ts_Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts_Tools.ImageScalingSize = new System.Drawing.Size(40, 40);
			this.ts_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_NewCustomer,
            this.btn_Exit,
            this.btn_Settings,
            this.btn_DatabaseBackup,
            this.toolStripButton1});
			this.ts_Tools.Location = new System.Drawing.Point(0, 0);
			this.ts_Tools.Name = "ts_Tools";
			this.ts_Tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts_Tools.Size = new System.Drawing.Size(1049, 50);
			this.ts_Tools.TabIndex = 0;
			this.ts_Tools.Text = "toolStrip1";
			// 
			// btn_NewCustomer
			// 
			this.btn_NewCustomer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_NewCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btn_NewCustomer.Image")));
			this.btn_NewCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_NewCustomer.Name = "btn_NewCustomer";
			this.btn_NewCustomer.Size = new System.Drawing.Size(133, 47);
			this.btn_NewCustomer.Text = "Új Ügyfél";
			// 
			// btn_Settings
			// 
			this.btn_Settings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Settings.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.btn_Settings.Image = ((System.Drawing.Image)(resources.GetObject("btn_Settings.Image")));
			this.btn_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Settings.Name = "btn_Settings";
			this.btn_Settings.Size = new System.Drawing.Size(146, 47);
			this.btn_Settings.Text = "Beállítások";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(232, 47);
			this.toolStripButton1.Text = "Adatlap Szerkesztése";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 402);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1049, 97);
			this.panel1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(109, 58);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dg_DataTable
			// 
			this.dg_DataTable.AllowUserToAddRows = false;
			this.dg_DataTable.AllowUserToDeleteRows = false;
			this.dg_DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_DataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ch_CustomerName,
            this.ch_jovedelemig,
            this.ch_ID,
            this.ch_PlaceOfResidence,
            this.ch_State,
            this.ch_DateAdded,
            this.ch_LastSupport,
            this.ch_AddSupport});
			this.dg_DataTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dg_DataTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dg_DataTable.Location = new System.Drawing.Point(0, 50);
			this.dg_DataTable.Name = "dg_DataTable";
			this.dg_DataTable.ReadOnly = true;
			this.dg_DataTable.RowHeadersVisible = false;
			this.dg_DataTable.Size = new System.Drawing.Size(1049, 352);
			this.dg_DataTable.TabIndex = 2;
			this.dg_DataTable.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
			this.dg_DataTable.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_DataTable_CellMouseLeave);
			// 
			// ch_CustomerName
			// 
			this.ch_CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ch_CustomerName.HeaderText = "Ügyfél Név";
			this.ch_CustomerName.Name = "ch_CustomerName";
			this.ch_CustomerName.ReadOnly = true;
			// 
			// ch_jovedelemig
			// 
			this.ch_jovedelemig.HeaderText = "J";
			this.ch_jovedelemig.Name = "ch_jovedelemig";
			this.ch_jovedelemig.ReadOnly = true;
			this.ch_jovedelemig.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ch_jovedelemig.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ch_jovedelemig.Width = 22;
			// 
			// ch_ID
			// 
			this.ch_ID.HeaderText = "Azonosító";
			this.ch_ID.Name = "ch_ID";
			this.ch_ID.ReadOnly = true;
			// 
			// ch_PlaceOfResidence
			// 
			this.ch_PlaceOfResidence.HeaderText = "Lakhely";
			this.ch_PlaceOfResidence.Name = "ch_PlaceOfResidence";
			this.ch_PlaceOfResidence.ReadOnly = true;
			// 
			// ch_State
			// 
			this.ch_State.HeaderText = "Állapot";
			this.ch_State.Name = "ch_State";
			this.ch_State.ReadOnly = true;
			// 
			// ch_DateAdded
			// 
			this.ch_DateAdded.HeaderText = "Felvétel Dátuma";
			this.ch_DateAdded.Name = "ch_DateAdded";
			this.ch_DateAdded.ReadOnly = true;
			// 
			// ch_LastSupport
			// 
			this.ch_LastSupport.HeaderText = "Legutóbbi Támogatás időpontja";
			this.ch_LastSupport.Name = "ch_LastSupport";
			this.ch_LastSupport.ReadOnly = true;
			// 
			// ch_AddSupport
			// 
			this.ch_AddSupport.HeaderText = "Támogatás";
			this.ch_AddSupport.Name = "ch_AddSupport";
			this.ch_AddSupport.ReadOnly = true;
			// 
			// tt_Tooltip
			// 
			this.tt_Tooltip.BackColor = System.Drawing.Color.LightYellow;
			this.tt_Tooltip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tt_Tooltip.font = null;
			this.tt_Tooltip.Location = new System.Drawing.Point(-100, -100);
			this.tt_Tooltip.Name = "tt_Tooltip";
			this.tt_Tooltip.position = new System.Drawing.Point(0, 0);
			this.tt_Tooltip.Size = new System.Drawing.Size(10, 10);
			this.tt_Tooltip.TabIndex = 3;
			this.tt_Tooltip.text = null;
			this.tt_Tooltip.title = null;
			// 
			// t_Timer
			// 
			this.t_Timer.Tick += new System.EventHandler(this.t_Timer_Tick);
			// 
			// btn_Exit
			// 
			this.btn_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Exit.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
			this.btn_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Exit.Name = "btn_Exit";
			this.btn_Exit.Size = new System.Drawing.Size(116, 47);
			this.btn_Exit.Text = "Kilépés";
			// 
			// btn_DatabaseBackup
			// 
			this.btn_DatabaseBackup.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_DatabaseBackup.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.btn_DatabaseBackup.Image = ((System.Drawing.Image)(resources.GetObject("btn_DatabaseBackup.Image")));
			this.btn_DatabaseBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_DatabaseBackup.Name = "btn_DatabaseBackup";
			this.btn_DatabaseBackup.Size = new System.Drawing.Size(210, 47);
			this.btn_DatabaseBackup.Text = "Biztonsági Mentés";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1049, 499);
			this.Controls.Add(this.tt_Tooltip);
			this.Controls.Add(this.dg_DataTable);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ts_Tools);
			this.Name = "Form1";
			this.Text = "Caritas Manager";
			this.ts_Tools.ResumeLayout(false);
			this.ts_Tools.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dg_DataTable)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts_Tools;
		private System.Windows.Forms.ToolStripButton btn_NewCustomer;
		private System.Windows.Forms.ToolStripButton btn_Settings;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.DataGridView dg_DataTable;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_CustomerName;
		private System.Windows.Forms.DataGridViewImageColumn ch_jovedelemig;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_PlaceOfResidence;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_State;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_DateAdded;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_LastSupport;
		private System.Windows.Forms.DataGridViewButtonColumn ch_AddSupport;
		private System.Windows.Forms.Button button1;
		private uc_Tooltip tt_Tooltip;
		private System.Windows.Forms.Timer t_Timer;
		private System.Windows.Forms.ToolStripButton btn_Exit;
		private System.Windows.Forms.ToolStripButton btn_DatabaseBackup;
	}
}

