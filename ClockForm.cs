using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Clock {
	public partial class ClockForm : Form {
		private enum TimeMode {
			Clock,
			Stopwatch
		}
		private bool mouseDown = false;
		private Point lastPos;
		private readonly System.Threading.Timer clockTimer;
		private TimeMode timeMode = TimeMode.Clock;
		private DateTime startTime;
		private static readonly Brush iconBbrush = new SolidBrush(Color.White);
		private static readonly Bitmap iconBitmap = new(16, 16);
		private static readonly Graphics iconGraphics = Graphics.FromImage(iconBitmap);
		private static readonly Font iconFont = new(FontFamily.GenericSansSerif, 10);

		public ClockForm() {
			SetStartup(!Debugger.IsAttached);
			InitializeComponent();
			//int ticks = 0;
			clockTimer = new System.Threading.Timer(q => {
				var tm = timeMode switch {
					TimeMode.Clock => DateTime.Now.ToString("HH:mm:ss"),
					TimeMode.Stopwatch => (DateTime.Now - startTime).ToString(@"hh\:mm\:ss\.ff"),
					_ => throw new NotImplementedException()
				};
				if (lblTime.InvokeRequired) {
					lblTime.Invoke(new MethodInvoker(() => {
						showTime(tm);
					}));
				} else {
					showTime(tm);
				}
				/*if (ticks++ % 100 == 0) {
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}*/
			}, this, 0, 1000);

			void showTime(string tm) {
				lblTime.Text = tm;
				notifyIcon1.Text = tm;
				SetIcon(tm.Substring(tm.Length - 2));
			}
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

		private void SetIcon(string text) {
			iconGraphics.Clear(Color.Transparent);
			iconGraphics.DrawString(text, iconFont, iconBbrush, 0, 0);
			var icon = Icon.FromHandle(iconBitmap.GetHicon());
			notifyIcon1.Icon = icon;
			icon.Dispose();
		}

		private void lblTime_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				if (timeMode == TimeMode.Clock) {
					timeMode = TimeMode.Stopwatch;
					clockTimer.Change(0, 100);
					startTime = DateTime.Now;
				} else {
					timeMode = TimeMode.Clock;
					clockTimer.Change(3000, 1000);
				}
			}
			if (e.Button == MouseButtons.Left) {
				lastPos = e.Location;
				mouseDown = true;
			}
		}

		private void lblTime_MouseMove(object sender, MouseEventArgs e) {
			if (mouseDown) {
				Point cur = PointToScreen(e.Location);
				Location = new Point(cur.X - lastPos.X, cur.Y - lastPos.Y);
			}
		}

		private void lblTime_MouseUp(object sender, MouseEventArgs e) {
			mouseDown = false;
		}

		private void bnClose_Click(object sender, EventArgs e) {
			Hide();
		}

		private void notifyIcon1_Click(object sender, EventArgs e) {
			if (Visible) {
				Hide();
			} else {
				Show();
			}
		}
	}
}
