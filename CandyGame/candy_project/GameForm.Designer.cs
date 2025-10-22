namespace candy_project
{
    partial class GameForm
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
            this.game_timer = new System.Windows.Forms.Timer(this.components);
            this.timer_label = new System.Windows.Forms.Label();
            this.point_label = new System.Windows.Forms.Label();
            this.start_btn = new System.Windows.Forms.Button();
            this.time_value = new System.Windows.Forms.NumericUpDown();
            this.point_value = new System.Windows.Forms.NumericUpDown();
            this.reset_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.time_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.point_value)).BeginInit();
            this.SuspendLayout();
            // 
            // game_timer
            // 
            this.game_timer.Interval = 1000;
            this.game_timer.Tick += new System.EventHandler(this.game_timer_Tick);
            // 
            // timer_label
            // 
            this.timer_label.AutoSize = true;
            this.timer_label.Location = new System.Drawing.Point(12, 9);
            this.timer_label.Name = "timer_label";
            this.timer_label.Size = new System.Drawing.Size(71, 25);
            this.timer_label.TabIndex = 0;
            this.timer_label.Text = "Time: ";
            // 
            // point_label
            // 
            this.point_label.AutoSize = true;
            this.point_label.Location = new System.Drawing.Point(12, 34);
            this.point_label.Name = "point_label";
            this.point_label.Size = new System.Drawing.Size(73, 25);
            this.point_label.TabIndex = 0;
            this.point_label.Text = "Point: ";
            // 
            // start_btn
            // 
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.start_btn.Location = new System.Drawing.Point(420, 12);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 31);
            this.start_btn.TabIndex = 1;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // time_value
            // 
            this.time_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.time_value.Location = new System.Drawing.Point(249, 13);
            this.time_value.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.time_value.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.time_value.Name = "time_value";
            this.time_value.Size = new System.Drawing.Size(75, 21);
            this.time_value.TabIndex = 2;
            this.time_value.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // point_value
            // 
            this.point_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.point_value.Location = new System.Drawing.Point(249, 39);
            this.point_value.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.point_value.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.point_value.Name = "point_value";
            this.point_value.Size = new System.Drawing.Size(75, 21);
            this.point_value.TabIndex = 2;
            this.point_value.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // reset_button
            // 
            this.reset_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.reset_button.Location = new System.Drawing.Point(339, 13);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(75, 31);
            this.reset_button.TabIndex = 1;
            this.reset_button.Text = "Reset";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 538);
            this.Controls.Add(this.point_value);
            this.Controls.Add(this.time_value);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.point_label);
            this.Controls.Add(this.timer_label);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.time_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.point_value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer game_timer;
        private System.Windows.Forms.Label timer_label;
        private System.Windows.Forms.Label point_label;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.NumericUpDown time_value;
        private System.Windows.Forms.NumericUpDown point_value;
        private System.Windows.Forms.Button reset_button;
    }
}

