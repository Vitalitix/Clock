using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Clock {
	public partial class ClockForm : Form {
		private enum TimeMode {
			Clock,
			Stopwatch
		}
		private bool mouseDown = false;
		private Point lastPos;
		private TimeMode timeMode = TimeMode.Clock;
		private DateTime startTime;
		//Change Icon
		private readonly Brush iconBbrush = new SolidBrush(Color.White);
		private readonly Bitmap iconBitmap =  new(16, 16);
		private readonly Font iconFont = new(FontFamily.GenericSansSerif, 10);
		private readonly Graphics iconGraphics = null!;

		public ClockForm() {
			SetStartup(!Debugger.IsAttached);
			InitializeComponent();
			iconGraphics = Graphics.FromImage(iconBitmap);
			Timer1.Interval = 1000;
			Timer1.Tick += Timer1_Tick;
			Timer1.Start();
		}
		void ShowTime(string tm) {
			if (Visible) {
				lblTime.Text = tm;
			} else {
				SetIcon(tm.Substring(tm.Length - 2));
				notifyIcon1.Text = tm;
			}
		}

		private void Timer1_Tick(object sender, EventArgs e) {
			ShowTime(timeMode switch {
				TimeMode.Clock => DateTime.Now.ToString("HH:mm:ss"),
				TimeMode.Stopwatch => (DateTime.Now - startTime).ToString(@"hh\:mm\:ss\.ff"),
				_ => throw new NotImplementedException()
			});
		}

		private void SetStartup(bool set) {
			var rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			if (rk is not null) {
				if (set)
					rk.SetValue("Clock", Application.ExecutablePath.ToString());
				else
					rk.DeleteValue("Clock", false);
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		extern static bool DestroyIcon(IntPtr handle);
		IntPtr hIcon;
		private void SetIcon(string text) {
			DestroyIcon(hIcon);
			iconGraphics.Clear(Color.Transparent);
			iconGraphics.DrawString(text, iconFont, iconBbrush, 0, 0);
			hIcon = iconBitmap.GetHicon();
			notifyIcon1.Icon = Icon.FromHandle(hIcon);
		}

		private void LblTime_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				if (timeMode == TimeMode.Clock) {
					timeMode = TimeMode.Stopwatch;
					Timer1.Interval = 100;
					startTime = DateTime.Now;
				} else {
					timeMode = TimeMode.Clock;
					Timer1.Interval = 1000;
				}
			}
			if (e.Button == MouseButtons.Left) {
				lastPos = e.Location;
				mouseDown = true;
			}
		}

		private void LblTime_MouseMove(object sender, MouseEventArgs e) {
			if (mouseDown) {
				Point cur = PointToScreen(e.Location);
				Location = new Point(cur.X - lastPos.X, cur.Y - lastPos.Y);
			}
		}

		private void LblTime_MouseUp(object sender, MouseEventArgs e) {
			mouseDown = false;
		}

		private void BnClose_Click(object sender, EventArgs e) {
			Hide();
		}

		private void NotifyIcon1_Click(object sender, EventArgs e) {
			if (Visible) {
				Hide();
			} else {
				Show();
				notifyIcon1.Icon = Icon;
			}
		}
	}
}
