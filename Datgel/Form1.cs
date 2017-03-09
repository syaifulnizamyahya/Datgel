using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
			InitializeLine();
		}

		public List<Line> Lines { get; set; } = new List<Line>();
		private void InitializeLine()
		{
			Line line;

			line = new Line();
			line.Point1 = Points[0];
			line.Point2 = Points[1];
			Lines.Add(line);

			line = new Line();
			line.Point1 = Points[1];
			line.Point2 = Points[2];
			Lines.Add(line);

			line = new Line();
			line.Point1 = Points[2];
			line.Point2 = Points[3];
			Lines.Add(line);

			line = new Line();
			line.Point1 = Points[3];
			line.Point2 = Points[4];
			Lines.Add(line);

			line = new Line();
			line.Point1 = Points[4];
			line.Point2 = Points[5];
			Lines.Add(line);

			line = new Line();
			line.Point1 = Points[5];
			line.Point2 = Points[6];
			Lines.Add(line);
			
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

		//http://paulbourke.net/geometry/pointlineplane/
		public static bool DoLinesIntersect(Line Line1, Line Line2, ref Point Intersection, ref string log)
		{
			// Denominator for ua and ub are the same, so store this calculation
			double Denominator =
			   (Line2.Point2.Y - Line2.Point1.Y) * (Line1.Point2.X - Line1.Point1.X)
			   -
			   (Line2.Point2.X - Line2.Point1.X) * (Line1.Point2.Y - Line1.Point1.Y);

			log = log + "Denominator : " + Denominator + "\n";

			//n_a and n_b are calculated as seperate values for readability
			double Numerator1 =
			   (Line2.Point2.X - Line2.Point1.X) * (Line1.Point1.Y - Line2.Point1.Y)
			   -
			   (Line2.Point2.Y - Line2.Point1.Y) * (Line1.Point1.X - Line2.Point1.X);
			log = log + "Numerator1 : " + Numerator1 + "\n";

			double Numerator2 =
			   (Line1.Point2.X - Line1.Point1.X) * (Line1.Point1.Y - Line2.Point1.Y)
			   -
			   (Line1.Point2.Y - Line1.Point1.Y) * (Line1.Point1.X - Line2.Point1.X);
			log = log + "Numerator2 : " + Numerator2 + "\n";

			// Make sure there is not a division by zero - this also indicates that
			// the lines are parallel.  
			// If n_a and n_b were both equal to zero the lines would be on top of each 
			// other (coincidental).  This check is not done because it is not 
			// necessary for this implementation (the parallel check accounts for this).
			if (Denominator == 0)
				return false;

			// Calculate the intermediate fractional point that the lines potentially intersect.
			double Unknown1 = Numerator1 / Denominator;
			log = log + "Unknown1 : " + Unknown1 + "\n";
			double Unknown2 = Numerator2 / Denominator;
			log = log + "Unknown2 : " + Unknown2 + "\n";

			// The fractional point will be between 0 and 1 inclusive if the lines
			// intersect.  If the fractional calculation is larger than 1 or smaller
			// than 0 the lines would need to be longer to intersect.
			if (Unknown1 >= 0d && Unknown1 <= 1d && Unknown2 >= 0d && Unknown2 <= 1d)
			{
				Intersection.X = Line1.Point1.X + (Unknown1 * (Line1.Point2.X - Line1.Point1.X));
				log = log + "Intersection.X : " + Intersection.X + "\n";
				Intersection.Y = Line1.Point1.Y + (Unknown1 * (Line1.Point2.Y - Line1.Point1.Y));
				log = log + "Intersection.Y : " + Intersection.Y + "\n";
				return true;
			}
			return false;
		}

		private void calculateButton_Click(object sender, EventArgs e)
		{
			// get values from textbox

		}
	}
}
