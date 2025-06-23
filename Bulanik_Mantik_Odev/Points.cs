using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulanik_Mantik_Odev
{
	public class Points
	{
		public void Nokta(float a, float b, float c, float y, SolidBrush brush, PointF[] points, float sifir, float bir, float olcek, PaintEventArgs e)
		{
			brush.Color = SystemColors.Info;
			points[0] = new PointF(18 + a * olcek, sifir);
			points[1] = new PointF(18 + Nokta_x(a, 0, b, 1, y) * olcek, sifir - (float)y * (sifir - bir));
			points[2] = new PointF(18 + Nokta_x(b, 1, c, 0, y) * olcek, sifir - (float)y * (sifir - bir));
			points[3] = new PointF(18 + c * olcek, sifir);
			e.Graphics.FillPolygon(brush, points);
			brush.Color = Color.Red;
		}
		public void Nokta(float a, float b, float c, float d, float y, SolidBrush brush, PointF[] points, float sifir, float bir, float olcek, PaintEventArgs e)
		{
			brush.Color = SystemColors.Info;
			points[0] = new PointF(18 + a * olcek, sifir);
			points[1] = new PointF(18 + Nokta_x(a, 0, b, 1, y) * olcek, sifir - (float)y * (sifir - bir));
			points[2] = new PointF(18 + Nokta_x(c, 1, d, 0, y) * olcek, sifir - (float)y * (sifir - bir));
			points[3] = new PointF(18 + d * olcek, sifir);
			e.Graphics.FillPolygon(brush, points);
			brush.Color = Color.Red;
		}

		public float Nokta_x(double x1, double y1, double x2, double y2, double y)
		{
			return (float)((y - y1) * (x1 - x2) / (y1 - y2) + x1);
		}
		
	}
}
