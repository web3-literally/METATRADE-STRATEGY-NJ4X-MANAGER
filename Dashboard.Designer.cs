namespace Nj4x_Manager
{
    partial class Dashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_GridViewNJ4XServer = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_GridViewMTAccount = new System.Windows.Forms.DataGridView();
            this.account_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.account_password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.platform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.server_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_lblStatusBar = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.broker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mTAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serveripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxterminalsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timesyncDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nJ4XServerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_GridViewNJ4XServer)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_GridViewMTAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nJ4XServerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.m_GridViewNJ4XServer);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 772);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NJ4X Servers";
            // 
            // m_GridViewNJ4XServer
            // 
            this.m_GridViewNJ4XServer.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_GridViewNJ4XServer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_GridViewNJ4XServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_GridViewNJ4XServer.AutoGenerateColumns = false;
            this.m_GridViewNJ4XServer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_GridViewNJ4XServer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_GridViewNJ4XServer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.serveripDataGridViewTextBoxColumn,
            this.serverportDataGridViewTextBoxColumn,
            this.maxterminalsDataGridViewTextBoxColumn,
            this.timesyncDataGridViewTextBoxColumn,
            this.status});
            this.m_GridViewNJ4XServer.DataSource = this.nJ4XServerBindingSource;
            this.m_GridViewNJ4XServer.GridColor = System.Drawing.Color.White;
            this.m_GridViewNJ4XServer.Location = new System.Drawing.Point(6, 25);
            this.m_GridViewNJ4XServer.Name = "m_GridViewNJ4XServer";
            this.m_GridViewNJ4XServer.ReadOnly = true;
            this.m_GridViewNJ4XServer.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_GridViewNJ4XServer.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.m_GridViewNJ4XServer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_GridViewNJ4XServer.Size = new System.Drawing.Size(673, 741);
            this.m_GridViewNJ4XServer.TabIndex = 0;
            this.m_GridViewNJ4XServer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.m_GridViewMTAccount);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(727, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 772);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MetaTrader Accounts";
            // 
            // m_GridViewMTAccount
            // 
            this.m_GridViewMTAccount.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_GridViewMTAccount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.m_GridViewMTAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_GridViewMTAccount.AutoGenerateColumns = false;
            this.m_GridViewMTAccount.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_GridViewMTAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_GridViewMTAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.account_number,
            this.account_password,
            this.platform,
            this.broker,
            this.plan,
            this.server_id,
            this.create_date});
            this.m_GridViewMTAccount.DataSource = this.mTAccountBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_GridViewMTAccount.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_GridViewMTAccount.GridColor = System.Drawing.Color.White;
            this.m_GridViewMTAccount.Location = new System.Drawing.Point(6, 25);
            this.m_GridViewMTAccount.Name = "m_GridViewMTAccount";
            this.m_GridViewMTAccount.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_GridViewMTAccount.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.m_GridViewMTAccount.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_GridViewMTAccount.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.m_GridViewMTAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_GridViewMTAccount.Size = new System.Drawing.Size(673, 741);
            this.m_GridViewMTAccount.TabIndex = 0;
            // 
            // account_number
            // 
            this.account_number.DataPropertyName = "account_number";
            this.account_number.HeaderText = "Account Number";
            this.account_number.Name = "account_number";
            this.account_number.ReadOnly = true;
            // 
            // account_password
            // 
            this.account_password.DataPropertyName = "account_password";
            this.account_password.HeaderText = "Account Password";
            this.account_password.Name = "account_password";
            this.account_password.ReadOnly = true;
            // 
            // platform
            // 
            this.platform.DataPropertyName = "platform";
            this.platform.HeaderText = "Platform";
            this.platform.Name = "platform";
            this.platform.ReadOnly = true;
            // 
            // server_id
            // 
            this.server_id.DataPropertyName = "server_id";
            this.server_id.HeaderText = "ServerID";
            this.server_id.Name = "server_id";
            this.server_id.ReadOnly = true;
            // 
            // create_date
            // 
            this.create_date.DataPropertyName = "create_date";
            this.create_date.HeaderText = "CreateDate";
            this.create_date.Name = "create_date";
            this.create_date.ReadOnly = true;
            // 
            // m_lblStatusBar
            // 
            this.m_lblStatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblStatusBar.AutoSize = true;
            this.m_lblStatusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblStatusBar.ForeColor = System.Drawing.Color.Yellow;
            this.m_lblStatusBar.Location = new System.Drawing.Point(19, 794);
            this.m_lblStatusBar.Name = "m_lblStatusBar";
            this.m_lblStatusBar.Size = new System.Drawing.Size(67, 20);
            this.m_lblStatusBar.TabIndex = 2;
            this.m_lblStatusBar.Text = "Ready...";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "broker";
            this.dataGridViewTextBoxColumn1.HeaderText = "Broker";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "plan";
            this.dataGridViewTextBoxColumn2.HeaderText = "Plan";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "broker";
            this.dataGridViewTextBoxColumn3.HeaderText = "Broker";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "plan";
            this.dataGridViewTextBoxColumn4.HeaderText = "Plan";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "broker";
            this.dataGridViewTextBoxColumn5.HeaderText = "Broker";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "plan";
            this.dataGridViewTextBoxColumn6.HeaderText = "Plan";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // broker
            // 
            this.broker.DataPropertyName = "broker";
            this.broker.HeaderText = "Broker";
            this.broker.Name = "broker";
            this.broker.ReadOnly = true;
            // 
            // plan
            // 
            this.plan.DataPropertyName = "plan";
            this.plan.HeaderText = "Plan";
            this.plan.Name = "plan";
            this.plan.ReadOnly = true;
            // 
            // mTAccountBindingSource
            // 
            this.mTAccountBindingSource.DataSource = typeof(Nj4x_Manager.MTAccount);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serveripDataGridViewTextBoxColumn
            // 
            this.serveripDataGridViewTextBoxColumn.DataPropertyName = "server_ip";
            this.serveripDataGridViewTextBoxColumn.HeaderText = "Server IP";
            this.serveripDataGridViewTextBoxColumn.Name = "serveripDataGridViewTextBoxColumn";
            this.serveripDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serverportDataGridViewTextBoxColumn
            // 
            this.serverportDataGridViewTextBoxColumn.DataPropertyName = "server_port";
            this.serverportDataGridViewTextBoxColumn.HeaderText = "Server Port";
            this.serverportDataGridViewTextBoxColumn.Name = "serverportDataGridViewTextBoxColumn";
            this.serverportDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maxterminalsDataGridViewTextBoxColumn
            // 
            this.maxterminalsDataGridViewTextBoxColumn.DataPropertyName = "max_terminals";
            this.maxterminalsDataGridViewTextBoxColumn.HeaderText = "MAX Terminals";
            this.maxterminalsDataGridViewTextBoxColumn.Name = "maxterminalsDataGridViewTextBoxColumn";
            this.maxterminalsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timesyncDataGridViewTextBoxColumn
            // 
            this.timesyncDataGridViewTextBoxColumn.DataPropertyName = "time_sync";
            this.timesyncDataGridViewTextBoxColumn.HeaderText = "Sync Time";
            this.timesyncDataGridViewTextBoxColumn.Name = "timesyncDataGridViewTextBoxColumn";
            this.timesyncDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nJ4XServerBindingSource
            // 
            this.nJ4XServerBindingSource.DataSource = typeof(Nj4x_Manager.NJ4XServer);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1424, 823);
            this.Controls.Add(this.m_lblStatusBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 862);
            this.MinimumSize = new System.Drawing.Size(1440, 862);
            this.Name = "Dashboard";
            this.Text = "NJ4X Manager";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_GridViewNJ4XServer)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_GridViewMTAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nJ4XServerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.BindingSource nJ4XServerBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label m_lblStatusBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        internal System.Windows.Forms.DataGridView m_GridViewNJ4XServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        internal System.Windows.Forms.BindingSource mTAccountBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        internal System.Windows.Forms.DataGridView m_GridViewMTAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn account_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn account_password;
        private System.Windows.Forms.DataGridViewTextBoxColumn platform;
        private System.Windows.Forms.DataGridViewTextBoxColumn broker;
        private System.Windows.Forms.DataGridViewTextBoxColumn plan;
        private System.Windows.Forms.DataGridViewTextBoxColumn server_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serveripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxterminalsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timesyncDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}

