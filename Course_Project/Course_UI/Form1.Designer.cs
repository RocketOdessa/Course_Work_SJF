namespace Course_UI
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
            this.components = new System.ComponentModel.Container();
            this.static_Init = new System.Windows.Forms.Button();
            this.add_process = new System.Windows.Forms.Button();
            this.begin_Init = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.processID_Text = new System.Windows.Forms.TextBox();
            this.processName_Text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Timer_Label = new System.Windows.Forms.Label();
            this.timer_tick = new System.Windows.Forms.Timer(this.components);
            this.processDataGridView = new System.Windows.Forms.DataGridView();
            this.process_Name_gridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process_ID_gridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrival_time_gridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completiom_time_gridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.burst_time_gridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priority_gridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state_gridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interup_butt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // static_Init
            // 
            this.static_Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.static_Init.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.static_Init.Location = new System.Drawing.Point(31, 436);
            this.static_Init.Name = "static_Init";
            this.static_Init.Size = new System.Drawing.Size(123, 55);
            this.static_Init.TabIndex = 0;
            this.static_Init.Text = "Static Initialization";
            this.static_Init.UseVisualStyleBackColor = true;
            this.static_Init.Click += new System.EventHandler(this.static_Init_Click);
            // 
            // add_process
            // 
            this.add_process.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_process.ForeColor = System.Drawing.Color.Red;
            this.add_process.Location = new System.Drawing.Point(59, 327);
            this.add_process.Name = "add_process";
            this.add_process.Size = new System.Drawing.Size(97, 55);
            this.add_process.TabIndex = 1;
            this.add_process.Text = "Add Process";
            this.add_process.UseVisualStyleBackColor = true;
            this.add_process.Click += new System.EventHandler(this.add_process_Click);
            // 
            // begin_Init
            // 
            this.begin_Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.begin_Init.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.begin_Init.Location = new System.Drawing.Point(160, 436);
            this.begin_Init.Name = "begin_Init";
            this.begin_Init.Size = new System.Drawing.Size(124, 55);
            this.begin_Init.TabIndex = 2;
            this.begin_Init.Text = "Begin Initialization";
            this.begin_Init.UseVisualStyleBackColor = true;
            this.begin_Init.Click += new System.EventHandler(this.begin_Init_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aqua;
            this.panel1.Controls.Add(this.add_process);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.processID_Text);
            this.panel1.Controls.Add(this.processName_Text);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(31, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 382);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(0, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Process ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(0, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Process Name";
            // 
            // processID_Text
            // 
            this.processID_Text.Location = new System.Drawing.Point(3, 185);
            this.processID_Text.Name = "processID_Text";
            this.processID_Text.Size = new System.Drawing.Size(100, 27);
            this.processID_Text.TabIndex = 2;
            // 
            // processName_Text
            // 
            this.processName_Text.Location = new System.Drawing.Point(3, 132);
            this.processName_Text.Name = "processName_Text";
            this.processName_Text.Size = new System.Drawing.Size(100, 27);
            this.processName_Text.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Process";
            // 
            // Timer_Label
            // 
            this.Timer_Label.AutoSize = true;
            this.Timer_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Timer_Label.Location = new System.Drawing.Point(256, 13);
            this.Timer_Label.Name = "Timer_Label";
            this.Timer_Label.Size = new System.Drawing.Size(127, 32);
            this.Timer_Label.TabIndex = 4;
            this.Timer_Label.Text = "00:00:00";
            // 
            // timer_tick
            // 
            this.timer_tick.Enabled = true;
            this.timer_tick.Interval = 1000;
            this.timer_tick.Tick += new System.EventHandler(this.timer_tick_Tick);
            // 
            // processDataGridView
            // 
            this.processDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.process_Name_gridView,
            this.process_ID_gridView,
            this.arrival_time_gridView,
            this.completiom_time_gridView,
            this.burst_time_gridView,
            this.priority_gridView,
            this.state_gridView});
            this.processDataGridView.Location = new System.Drawing.Point(262, 48);
            this.processDataGridView.Name = "processDataGridView";
            this.processDataGridView.RowTemplate.Height = 24;
            this.processDataGridView.Size = new System.Drawing.Size(950, 382);
            this.processDataGridView.TabIndex = 5;
            // 
            // process_Name_gridView
            // 
            this.process_Name_gridView.HeaderText = "Process Name";
            this.process_Name_gridView.Name = "process_Name_gridView";
            this.process_Name_gridView.ReadOnly = true;
            // 
            // process_ID_gridView
            // 
            this.process_ID_gridView.HeaderText = "Process ID";
            this.process_ID_gridView.Name = "process_ID_gridView";
            this.process_ID_gridView.ReadOnly = true;
            // 
            // arrival_time_gridView
            // 
            this.arrival_time_gridView.HeaderText = "Arrival Time";
            this.arrival_time_gridView.Name = "arrival_time_gridView";
            this.arrival_time_gridView.ReadOnly = true;
            // 
            // completiom_time_gridView
            // 
            this.completiom_time_gridView.HeaderText = "Completion Time";
            this.completiom_time_gridView.Name = "completiom_time_gridView";
            this.completiom_time_gridView.ReadOnly = true;
            // 
            // burst_time_gridView
            // 
            this.burst_time_gridView.HeaderText = "Burst Time";
            this.burst_time_gridView.Name = "burst_time_gridView";
            this.burst_time_gridView.ReadOnly = true;
            // 
            // priority_gridView
            // 
            this.priority_gridView.HeaderText = "Priority";
            this.priority_gridView.Name = "priority_gridView";
            this.priority_gridView.ReadOnly = true;
            // 
            // state_gridView
            // 
            this.state_gridView.HeaderText = "State";
            this.state_gridView.Name = "state_gridView";
            this.state_gridView.ReadOnly = true;
            // 
            // interup_butt
            // 
            this.interup_butt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interup_butt.Location = new System.Drawing.Point(1082, 436);
            this.interup_butt.Name = "interup_butt";
            this.interup_butt.Size = new System.Drawing.Size(118, 55);
            this.interup_butt.TabIndex = 6;
            this.interup_butt.Text = "Stop";
            this.interup_butt.UseVisualStyleBackColor = true;
            this.interup_butt.Click += new System.EventHandler(this.interup_butt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 519);
            this.Controls.Add(this.interup_butt);
            this.Controls.Add(this.processDataGridView);
            this.Controls.Add(this.Timer_Label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.begin_Init);
            this.Controls.Add(this.static_Init);
            this.Name = "Form1";
            this.Text = "SJF";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button static_Init;
        private System.Windows.Forms.Button add_process;
        private System.Windows.Forms.Button begin_Init;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox processID_Text;
        private System.Windows.Forms.TextBox processName_Text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Timer_Label;
        private System.Windows.Forms.Timer timer_tick;
        private System.Windows.Forms.DataGridView processDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn process_Name_gridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn process_ID_gridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrival_time_gridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn completiom_time_gridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn burst_time_gridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn priority_gridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn state_gridView;
        private System.Windows.Forms.Button interup_butt;
    }
}

