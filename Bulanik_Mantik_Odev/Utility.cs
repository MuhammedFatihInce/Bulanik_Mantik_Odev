

namespace Bulanik_Mantik_Odev
{
	public static class Utility
	{

		public static void CizimFonksiyonu(PaintEventArgs e, TrackBar trackBar, string[] etiketler, Color[] renkler, float ölçek, float sıfır, float bir, string grafikName)
		{
			Pen pen = new Pen(Color.Black, 1.5f);
			Font font = new Font("Verdana", 7);
			Brush brush = Brushes.Black;

			float a = grafikName.Contains("Kirlilik") ? 4.5f : 4f;

			// Üyelik fonksiyonlarını çiz
			for (int i = 0; i < etiketler.Length; i++)
			{
				pen.Color = renkler[i];
				float xOffset = 0;
				switch (i)
				{
					case 0: xOffset = 2 * ölçek - 25; break;
					case 1: xOffset = 5 * ölçek; break;
					case 2: xOffset = 8 * ölçek + 25; break;
				}

				e.Graphics.DrawString(etiketler[i], font, brush, xOffset, bir - 15);

				if (i == 0)
				{
					e.Graphics.DrawLine(pen, 18, bir, 18 + 2 * ölçek, bir);
					e.Graphics.DrawLine(pen, 18 + 2 * ölçek, 50, 18 + a * ölçek, sıfır);
				}
				else if (i == 1)
				{
					e.Graphics.DrawLine(pen, 18 + 3 * ölçek, sıfır, 18 + 5 * ölçek, bir);
					e.Graphics.DrawLine(pen, 18 + 5 * ölçek, bir, 18 + 7 * ölçek, sıfır);
				}
				else if (i == 2)
				{
					e.Graphics.DrawLine(pen, 18 + 5.5f * ölçek, sıfır, 18 + 8 * ölçek, bir);
					e.Graphics.DrawLine(pen, 18 + 8 * ölçek, bir, 18 + 10 * ölçek, bir);
				}
			}

			// TrackBar çizgisi
			pen.Width = 1;
			pen.Color = Color.Red;
			e.Graphics.DrawLine(pen, 18 + trackBar.Value * 2.73f, 10, 18 + trackBar.Value * 2.73f, 120);
		}

		
	}
}
