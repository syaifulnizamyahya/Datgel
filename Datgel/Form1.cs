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
		string log = default(string);
		//log = log + "" + "\n";

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
			log = log + "Line 1 (" + line.Point1.X + ", " + line.Point1.Y + ") (" + line.Point2.X + ", " + line.Point2.Y + ")\n";

			line = new Line();
			line.Point1 = Points[1];
			line.Point2 = Points[2];
			Lines.Add(line);
			log = log + "Line 2 (" + line.Point1.X + ", " + line.Point1.Y + ") (" + line.Point2.X + ", " + line.Point2.Y + ")\n";

			line = new Line();
			line.Point1 = Points[2];
			line.Point2 = Points[3];
			Lines.Add(line);
			log = log + "Line 3 (" + line.Point1.X + ", " + line.Point1.Y + ") (" + line.Point2.X + ", " + line.Point2.Y + ")\n";

			line = new Line();
			line.Point1 = Points[3];
			line.Point2 = Points[4];
			Lines.Add(line);
			log = log + "Line 4 (" + line.Point1.X + ", " + line.Point1.Y + ") (" + line.Point2.X + ", " + line.Point2.Y + ")\n";

			line = new Line();
			line.Point1 = Points[4];
			line.Point2 = Points[5];
			Lines.Add(line);
			log = log + "Line 5 (" + line.Point1.X + ", " + line.Point1.Y + ") (" + line.Point2.X + ", " + line.Point2.Y + ")\n";

			logRichTextBox.Text = log;
		}

		public List<PointF> Points { get; set; } = new List<PointF>();
		float minX, maxX;
		float minY, maxY;

		private void InitializePoints()
		{
			BindingList<PointF> bindingList;
			BindingSource source;

			Points.Add(new Point(32, 100));
			Points.Add(new Point(44, 94));
			Points.Add(new Point(46, 97));
			Points.Add(new Point(56, 110));
			Points.Add(new Point(70, 114));
			Points.Add(new Point(83, 99));

			bindingList = new BindingList<PointF>(Points);
			source = new BindingSource(bindingList, null);
			pointsGridView.DataSource = source;

			minX = maxX = Points[0].X;
			minY = maxY = Points[0].Y;

			for (int i = 1; i < Points.Count; i++)
			{
				if (Points[i].X < minX)
				{
					minX = Points[i].X;
				}
				else if (Points[i].X > maxX)
				{
					maxX = Points[i].X;
				}

				if (Points[i].Y < minY)
				{
					minY = Points[i].Y;
				}
				else if (Points[i].Y > maxY)
				{
					maxY = Points[i].Y;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		//http://paulbourke.net/geometry/pointlineplane/
		public static bool DoLinesIntersect(Line Line1, Line Line2, ref PointF Intersection, ref string log)
		{
			// Denominator for ua and ub are the same, so store this calculation
			float Denominator =
			   (Line2.Point2.Y - Line2.Point1.Y) * (Line1.Point2.X - Line1.Point1.X)
			   -
			   (Line2.Point2.X - Line2.Point1.X) * (Line1.Point2.Y - Line1.Point1.Y);

			log = log + "Denominator : " + Denominator + "\n";

			//n_a and n_b are calculated as seperate values for readability
			float Numerator1 =
			   (Line2.Point2.X - Line2.Point1.X) * (Line1.Point1.Y - Line2.Point1.Y)
			   -
			   (Line2.Point2.Y - Line2.Point1.Y) * (Line1.Point1.X - Line2.Point1.X);
			log = log + "Numerator1 : " + Numerator1 + "\n";

			float Numerator2 =
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
			float Unknown1 = Numerator1 / Denominator;
			log = log + "Unknown1 : " + Unknown1 + "\n";
			float Unknown2 = Numerator2 / Denominator;
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
			float x = default(float);
			float y = default(float);

			bool isXFloat;
			bool isYFloat;

			PointF intersection = default(PointF);

			// get values from textbox
			if (float.TryParse(xTextBox.Text, out x))
			{
				//log = log + "x is a float" + "\n";
				isXFloat = true;
			}
			else
			{
				log = log + "x is not a float" + "\n";
				isXFloat = false;
			}

			if (float.TryParse(yTextBox.Text, out y))
			{
				//log = log + "y is a float" + "\n";
				isYFloat = true;
			}
			else
			{
				log = log + "y is not a float" + "\n";
				isYFloat = false;
			}

			if (isXFloat && isYFloat)
			{
				// x and y are float
				log = log + "x and y are float" + "\n";


			}
			else if (isXFloat && !isYFloat)
			{
				// only x is float
				log = log + "only x is float" + "\n";

				// calculate new line ( 2 points)
				var line = new Line();
				line.Point1 = new PointF(x, minY);
				line.Point2 = new PointF(x, maxY);

				// for each line in polyline
				for (int i = 0; i < Lines.Count; i++)
				{
					if(DoLinesIntersect(line, Lines[i], ref intersection, ref log))
					{
						log = log + "Intersect at line " + i + "\n";
						xTextBox.Text = intersection.X.ToString();
						yTextBox.Text = intersection.Y.ToString();
						break;
					}
				}
			}
			else if (!isXFloat && isYFloat)
			{
				// only y is float
				log = log + "only y is float" + "\n";

				// calculate new line ( 2 points)
				var line = new Line();
				line.Point1 = new PointF(minX, y);
				line.Point2 = new PointF(maxX, y);

				// for each line in polyline
				for (int i = 0; i < Lines.Count; i++)
				{
					if (DoLinesIntersect(line, Lines[i], ref intersection, ref log))
					{
						log = log + "Intersect at line " + i + "\n";
						xTextBox.Text = intersection.X.ToString();
						yTextBox.Text = intersection.Y.ToString();
						break;
					}
				}
			}
			else if (!isXFloat && !isYFloat)
			{
				// none are float
				log = log + "none are float" + "\n";

				// show dialog box
				MessageBox.Show("One coordinate must be provided", "No coordinate found");
			}

			logRichTextBox.Text = log;
		}
	}
}
