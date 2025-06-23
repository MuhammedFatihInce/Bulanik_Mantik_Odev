using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulanik_Mantik_Odev
{
	public class Agirlikli_Ortalama
	{
		public (string label18, string label16, string label15) Islem(double[] max_dönüşHızı, double[] max_süre, double[] max_deterjan)
		{
			double pay_deterjan = 0;
			double pay_dönüşHızı = 0;
			double pay_süre = 0;
			double payda_deterjan = 0;
			double payda_dönüşHızı = 0;
			double payda_süre = 0;

			pay_dönüşHızı = max_dönüşHızı[0] * 0.514 +
			                max_dönüşHızı[1] * 2.75 +
			                max_dönüşHızı[2] * 5 +
			                max_dönüşHızı[3] * 7.25 +
			                max_dönüşHızı[4] * 9.5;

			pay_süre = max_süre[0] * 22.3 +
			           max_süre[1] * 39.9 +
			           max_süre[2] * 57.5 +
			           max_süre[3] * 75.1 +
			           max_süre[4] * 92.7;

			pay_deterjan = max_deterjan[0] * 20 +
			               max_deterjan[1] * 85 +
			               max_deterjan[2] * 150 +
			               max_deterjan[3] * 215 +
			               max_deterjan[4] * 270;

			for (int i = 0; i < max_dönüşHızı.Length; ++i) payda_dönüşHızı += max_dönüşHızı[i];
			for (int i = 0; i < max_süre.Length; ++i) payda_süre += max_süre[i];
			for (int i = 0; i < max_deterjan.Length; ++i) payda_deterjan += max_deterjan[i];

			double Gerçek_Deterjan = pay_deterjan / payda_deterjan;
			double Gerçek_DönüşHızı = pay_dönüşHızı / payda_dönüşHızı;
			double Gerçek_Süre = pay_süre / payda_süre;


			return (Gerçek_DönüşHızı.ToString(), Gerçek_Süre.ToString(), Gerçek_Deterjan.ToString());

		}
	}
}
