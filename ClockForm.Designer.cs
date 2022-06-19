namespace Clock {
	partial class ClockForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClockForm));
			this.lblTime = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.bnClose = new System.Windows.Forms.Button();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.BackColor = System.Drawing.Color.Transparent;
			this.lblTime.Font = new System.Drawing.Font("Algerian", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTime.Location = new System.Drawing.Point(0, 0);
			this.lblTime.Margin = new System.Windows.Forms.Padding(0);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(445, 106);
			this.lblTime.TabIndex = 0;
			this.lblTime.Text = "12:12:12";
			this.lblTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTime_MouseDown);
			this.lblTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblTime_MouseMove);
			this.lblTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblTime_MouseUp);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "Clock";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.Click += new System.EventHandler(this.NotifyIcon1_Click);
			// 
			// bnClose
			// 
			this.bnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.bnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bnClose.BackColor = System.Drawing.Color.Transparent;
			this.bnClose.Location = new System.Drawing.Point(422, -1);
			this.bnClose.Name = "bnClose";
			this.bnClose.Size = new System.Drawing.Size(24, 23);
			this.bnClose.TabIndex = 1;
			this.bnClose.TabStop = false;
			this.bnClose.Text = "-";
			this.bnClose.UseVisualStyleBackColor = false;
			this.bnClose.Click += new System.EventHandler(this.BnClose_Click);
			// 
			// ClockForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(445, 106);
			this.ControlBox = false;
			this.Controls.Add(this.bnClose);
			this.Controls.Add(this.lblTime);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ClockForm";
			this.Opacity = 0.6D;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Button bnClose;
		private System.Windows.Forms.Timer Timer1;
	}
}

