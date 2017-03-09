using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datgel
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			InitializePoints();
		}

		public List<Point> Points { get; set; } = new List<Point>();

		private void InitializePoints()
		{
			Points.Add(new Point(32, 100));
			Points.Add(new Point(44, 94));
			Points.Add(new Point(46, 97));
			Points.Add(new Point(56, 110));
			Points.Add(new Point(70, 114));
			Points.Add(new Point(83, 99));

			var bindingList = new BindingList<Point>(Points);
			var source = new BindingSource(bindingList, null);
			pointsGridView.DataSource = source;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
