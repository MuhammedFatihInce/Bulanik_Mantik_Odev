using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulanik_Mantik_Odev
{
	public class Mamdani
	{

		private double üçgen(double a, double b, double c, double değer)
		{
			if (değer >= a && değer <= b)
			{
				return (değer - a) / (b - a);
			}
			else if (değer >= b && değer <= c)
			{
				return (değer - b) / (b - c) + 1;
			}
			else
			{
				return -1;
			}
		}

		private double yamuk(double a, double b, double c, double d, double değer)
		{
			if (değer >= a && değer <= b)
			{
				return (değer - a) / (b - a);
			}
			else if (değer >= b && değer <= c)
			{
				return 1;
			}
			else if (değer >= c && değer <= d)
			{
				return (değer - c) / (c - d) + 1;
			}
			else
			{
				return -1;
			}
		}

		private double fxHassaslık(string bulanık_küme)
		{
			double değer = Giris.Default.hassaslık;

			if (bulanık_küme == "sağlam")
			{
				return yamuk(-4, -1.5, 2, 4, değer);
			}
			else if (bulanık_küme == "orta")
			{
				return üçgen(3, 5, 7, değer);
			}
			else if (bulanık_küme == "hassas")
			{
				return yamuk(5.5, 8, 12.5, 14, değer);
			}
			else
			{
				return double.MaxValue;
			}
		}

		private double fxMiktar(string bulanık_küme)
		{
			double değer = Giris.Default.miktar;

			if (bulanık_küme == "küçük")
			{
				return yamuk(-4, -1.5, 2, 4, değer);
			}
			else if (bulanık_küme == "orta")
			{
				return üçgen(3, 5, 7, değer);
			}
			else if (bulanık_küme == "büyük")
			{
				return yamuk(5.5, 8, 12.5, 14, değer);
			}
			else
			{
				return double.MaxValue;
			}
		}

		private double fxKirlilik(string bulanık_küme)
		{
			double değer = Giris.Default.kirlilik;

			if (bulanık_küme == "küçük")
			{
				return yamuk(-4.5, -2.5, 2, 4.5, değer);
			}
			else if (bulanık_küme == "orta")
			{
				return üçgen(3, 5, 7, değer);
			}
			else if (bulanık_küme == "büyük")
			{
				return yamuk(5.5, 8, 12.5, 15, değer);
			}
			else
			{
				return double.MaxValue;
			}
		}

		public double[] min;

		public void Islem(DataRowCollection kural, ListBox listBox)
		{
			min = new double[kural.Count];

			for (int i = 0; i < kural.Count; ++i)
			{
				min[i] =
					Math.Min(Math.Min(fxHassaslık(kural[i][1].ToString()), fxMiktar(kural[i][2].ToString())),
						fxKirlilik(kural[i][3].ToString()));

			}

			listBox.Items.Clear();
			for (int i = 0; i < min.Length; ++i)
				listBox.Items.Add(min[i]);
		}

		
		public void max_bul(DataRowCollection kural, out double[] max_dönüşHızı, out double[] max_süre, out double[] max_deterjan)
		{
			max_dönüşHızı = new double[5];
			max_süre = new double[5];
			max_deterjan = new double[5];

			for (int i = 0; i < kural.Count; ++i)
			{
				string dönüş_hızı = kural[i][4].ToString();
				switch (dönüş_hızı)
				{
					case "hassas":
						if (max_dönüşHızı[0] < min[i]) max_dönüşHızı[0] = min[i];
						break;

					case "normal hassas":
						if (max_dönüşHızı[1] < min[i]) max_dönüşHızı[1] = min[i];
						break;

					case "orta":
						if (max_dönüşHızı[2] < min[i]) max_dönüşHızı[2] = min[i];
						break;

					case "normal güçlü":
						if (max_dönüşHızı[3] < min[i]) max_dönüşHızı[3] = min[i];
						break;

					case "güçlü":
						if (max_dönüşHızı[4] < min[i]) max_dönüşHızı[4] = min[i];
						break;
				}

				string süre = kural[i][5].ToString();
				switch (süre)
				{
					case "kısa":
						if (max_süre[0] < min[i]) max_süre[0] = min[i];
						break;

					case "normal kısa":
						if (max_süre[1] < min[i]) max_süre[1] = min[i];
						break;

					case "orta":
						if (max_süre[2] < min[i]) max_süre[2] = min[i];
						break;

					case "normal uzun":
						if (max_süre[3] < min[i]) max_süre[3] = min[i];
						break;

					case "uzun":
						if (max_süre[4] < min[i]) max_süre[4] = min[i];
						break;
				}


				string deterjan = kural[i][6].ToString();
				switch (deterjan)
				{
					case "çok az":
						if (max_deterjan[0] < min[i]) max_deterjan[0] = min[i];
						break;

					case "az":
						if (max_deterjan[1] < min[i]) max_deterjan[1] = min[i];
						break;

					case "orta":
						if (max_deterjan[2] < min[i]) max_deterjan[2] = min[i];
						break;

					case "fazla":
						if (max_deterjan[3] < min[i]) max_deterjan[3] = min[i];
						break;

					case "çok fazla":
						if (max_deterjan[4] < min[i]) max_deterjan[4] = min[i];
						break;
				}

			}

		}
	}
}
