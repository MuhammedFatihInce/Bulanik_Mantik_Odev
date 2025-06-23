using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulanik_Mantik_Odev
{
	public class Centroid
	{
		ArrayList integral;
		private Points point = new Points();

		public void sınır(double[] max, double a, double b, double c)
		{
			if (max[0] != 0)
			{
				PointF pt1 = new PointF(0f, (float)max[0]);
				integral.Add(pt1);

				if (max[0] > max[1])
				{
					PointF pt2 = new PointF(point.Nokta_x(a, 1, b, 0, max[0]), (float)max[0]);
					integral.Add(pt2);

					integral.Add(pt2);
					PointF pt3 = new PointF(point.Nokta_x(a, 1, b, 0, max[1]), (float)max[1]);
					integral.Add(pt3);
				}
				else
				{
					PointF pt4 = new PointF(point.Nokta_x(a, 0, c, 1, max[0]), (float)max[0]);
					integral.Add(pt4);
				}
			}
		}

		public void sınır(double[] max, int i, double a, double b, double c, double d, double e)
		{
			if (max[i] != 0)
			{
				PointF pt;

				if (max[i] > max[i - 1])
				{
					pt = new PointF(point.Nokta_x(a, 0, b, 1, max[i - 1]), (float)max[i - 1]);
					integral.Add(pt);

					pt = new PointF(point.Nokta_x(a, 0, b, 1, max[i]), (float)max[i]);
					integral.Add(pt);

					integral.Add(pt);
				}
				else
				{
					pt = new PointF(point.Nokta_x(a, 1, c, 0, max[i]), (float)max[i]);
					integral.Add(pt);
				}

				if (max[i] > max[i + 1])
				{
					pt = new PointF(point.Nokta_x(b, 1, d, 0, max[i]), (float)max[i]);
					integral.Add(pt);

					integral.Add(pt);
					pt = new PointF(point.Nokta_x(b, 1, d, 0, max[i + 1]), (float)max[i + 1]);
					integral.Add(pt);
				}
				else
				{
					pt = new PointF(point.Nokta_x(e, 0, d, 1, max[i]), (float)max[i]);
					integral.Add(pt);
				}
			}
		}

		public void sınır1(double[] max, int i, double a, double b, double c, double d, int son)
		{
			if (max[i] != 0)
			{
				PointF pt;

				if (max[i] > max[i - 1])
				{
					pt = new PointF(point.Nokta_x(a, 0, b, 1, max[i - 1]), (float)max[i - 1]);
					integral.Add(pt);

					pt = new PointF(point.Nokta_x(a, 0, b, 1, max[i]), (float)max[i]);
					integral.Add(pt);

					integral.Add(pt);
				}
				else
				{
					pt = new PointF(point.Nokta_x(c, 1, d, 0, max[i]), (float)max[i]);
					integral.Add(pt);
				}

				pt = new PointF(son, (float)max[i]);
				integral.Add(pt);
			}
		}

		public double INTEGRAL()
		{
			double pay = 0;
			double payda = 0;

			for (int i = 0; i < integral.Count; i += 2)
			{
				PointF pt1 = (PointF)integral[i];
				PointF pt2 = (PointF)integral[i + 1];

				if (pt1.X != pt2.X)
				{
					if (pt1.Y == pt2.Y) 
					{
						pay += pt2.Y * Math.Pow(pt2.X, 2) / 2 - pt1.Y * Math.Pow(pt1.X, 2) / 2;

						payda += pt2.Y * (pt2.X - pt1.X);
					}
					else   
					{
						pay += (((pt1.Y - pt2.Y) / (pt1.X - pt2.X)) * (Math.Pow(pt2.X, 3) / 3 - pt1.X * Math.Pow(pt2.X, 2) / 2) + pt1.Y * Math.Pow(pt2.X, 2) / 2) -
						       (((pt1.Y - pt2.Y) / (pt1.X - pt2.X)) * (Math.Pow(pt1.X, 3) / 3 - pt1.X * Math.Pow(pt1.X, 2) / 2) + pt1.Y * Math.Pow(pt1.X, 2) / 2);

						payda += (((pt1.Y - pt2.Y) / (pt1.X - pt2.X)) * (Math.Pow(pt2.X, 2) / 2 - pt1.X * pt2.X) + pt1.Y * pt2.X) -
						         (((pt1.Y - pt2.Y) / (pt1.X - pt2.X)) * (Math.Pow(pt1.X, 2) / 2 - pt1.X * pt1.X) + pt1.Y * pt1.X);
					}
				}
			}
			return pay / payda;
		}
		
		public (string DonusHızı, string Sure, string Deterjan) Hesapla(double[] max_dönüşHızı, double[] max_süre, double[] max_deterjan)   
		{

			integral = new ArrayList();
			sınır(max_dönüşHızı, 0.5, 1.5, 2.75);
			sınır(max_dönüşHızı, 1, 0.5, 2.75, 1.5, 5, 2.75);
			sınır(max_dönüşHızı, 2, 2.75, 5, 5, 7.25, 5);
			sınır(max_dönüşHızı, 3, 5, 7.25, 7.25, 9.5, 8.5);
			sınır1(max_dönüşHızı, 4, 8.5, 9.5, 7.25, 9.5, 10);
			string DonusHızı = INTEGRAL().ToString();

			integral = new ArrayList();
			sınır(max_süre, 22.3, 39.9, 39.9);
			sınır(max_süre, 1, 22.3, 39.9, 39.9, 57.5, 39.9);
			sınır(max_süre, 2, 39.9, 57.5, 57.5, 75.1, 57.5);
			sınır(max_süre, 3, 57.5, 75.1, 75.1, 92.7, 75);
			sınır1(max_süre, 4, 75, 92.7, 75.1, 92.7, 100);
			string Sure = INTEGRAL().ToString();

			integral = new ArrayList();
			sınır(max_deterjan, 20, 85, 85);
			sınır(max_deterjan, 1, 20, 85, 85, 150, 85);
			sınır(max_deterjan, 2, 85, 150, 150, 215, 150);
			sınır(max_deterjan, 3, 150, 215, 215, 280, 215);
			sınır1(max_deterjan, 4, 215, 280, 280, 300, 300);
			string Deterjan = INTEGRAL().ToString();

			return (DonusHızı, Sure, Deterjan);
		}


	}
}
