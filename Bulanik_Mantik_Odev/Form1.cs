using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Bulanik_Mantik_Odev
{
	public partial class Form1 : Form
	{
		static string connectionString = "Server=LAPTOP-F5NS8T2U\\MSSQLSERVER_22;Database=BulanikMantikDB;User Id=SA;Password=MyFf@tih1234;";
		SqlConnection con = new SqlConnection(connectionString);

		Points noktalar = new Points();

		private static SolidBrush brush = new SolidBrush(Color.Red);
		Pen pen = new Pen(brush);
		Font font = new Font("Verdana", 7);

		private static Mamdani mamdani = new Mamdani();
		private Agirlikli_Ortalama agirlikliOrtalama = new Agirlikli_Ortalama();
		Centroid centroid = new Centroid();

		float sifir = 120;
		float bir = 50;
		float olcek = 27.3f;

		private double[] max_d�n��H�z�;
		private double[] max_s�re;
		private double[] max_deterjan;

		string[] Bulan�kDe�erH = { "Sa�lam" };
		string[] Bulan�kDe�erK = { "K���k" };
		string[] Bulan�kDe�erM = { "K���k" };



		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				con.Open();
				SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kurallar", con);
				DataSet ds = new DataSet();
				da.Fill(ds);
				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns[0].Width = 30;
				dataGridView1.Columns[1].Width = 60;
				dataGridView1.Columns[2].Width = 50;
				dataGridView1.Columns[3].Width = 50;
				dataGridView1.Columns[4].Width = 90;
				dataGridView1.Columns[5].Width = 90;

				dataGridView1.Columns[1].HeaderText = "Hassasl�k";
				dataGridView1.Columns[2].HeaderText = "Miktar";
				dataGridView1.Columns[3].HeaderText = "Kirlilik";
				dataGridView1.Columns[4].HeaderText = "D�n�� H�z�";
				dataGridView1.Columns[5].HeaderText = "S�re";
				dataGridView1.Columns[6].HeaderText = "Deterjan";

				dataGridView1.Font = new Font("Verdana", 7);

				for (int i = 0; i < dataGridView1.Rows.Count; ++i)
					dataGridView1.Rows[i].Height = 15;
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				throw;
			}
			finally
			{
				con.Close();
			}
			
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			trackBar_Hassaslik.Focus();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			trackBar_Miktar.Focus();
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			trackBar_Kirlilik.Focus();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			string[] etiketler = new[] { "SA�LAM", "ORTA", "HASSAS" };
			Color[] renkler = new[] { Color.Blue, Color.DarkGreen, Color.Orchid };
			Utility.CizimFonksiyonu(e, trackBar_Hassaslik, etiketler, renkler, olcek, sifir, bir, "Hassal�k");
		}
		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
			string[] etiketler = new[] { "K���K", "ORTA", "B�Y�K" };
			Color[] renkler = new[] { Color.Blue, Color.DarkGreen, Color.Orchid };
			Utility.CizimFonksiyonu(e, trackBar_Miktar, etiketler, renkler, olcek, sifir, bir, "Miktar");
		}

		private void pictureBox3_Paint(object sender, PaintEventArgs e)
		{
			string[] etiketler = new[] { "K���K", "ORTA", "B�Y�K" };
			Color[] renkler = new[] { Color.Blue, Color.DarkGreen, Color.Orchid };
			Utility.CizimFonksiyonu(e, trackBar_Kirlilik, etiketler, renkler, olcek, sifir, bir, "Kirlilik");
		}
		private void trackBar_Hassaslik_ValueChanged(object sender, EventArgs e)
		{
			numericUpDown_Hassaslik.Value = (decimal)(trackBar_Hassaslik.Value) / 10;
		}
		private void trackBar_Miktar_ValueChanged(object sender, EventArgs e)
		{
			numericUpDown_Miktar.Value = (decimal)(trackBar_Miktar.Value) / 10;
		}

		private void trackBar_Kirlilik_ValueChanged(object sender, EventArgs e)
		{
			numericUpDown_Kirlilik.Value = (decimal)(trackBar_Kirlilik.Value) / 10;
		}

		private void numericUpDown_Hassaslik_ValueChanged(object sender, EventArgs e)
		{
			double hassaslik = (double)numericUpDown_Hassaslik.Value;
			trackBar_Hassaslik.Value = (int)(hassaslik * 10);
			Giris.Default.hassasl�k = hassaslik;

			string a = "";
			if (hassaslik >= 0 && hassaslik <= 4)
			{
				a = "Sa�lam,";
			}
			if (hassaslik >= 3 && hassaslik <= 7)
			{
				a += "Orta,";
			}
			if (hassaslik >= 5.5 && hassaslik <= 10)
			{
				a += "Hassas";
			}

			Bulan�kDe�erH = a.TrimEnd(',').Split(',');
			lb_Hassalik.Text = a.TrimEnd(',');

			Islem();
		}

		private void numericUpDown_Miktar_ValueChanged(object sender, EventArgs e)
		{
			double miktar = (double)numericUpDown_Miktar.Value;
			trackBar_Miktar.Value = (int)(miktar * 10);
			Giris.Default.miktar = miktar;

			string a = "";
			if (miktar >= 0 && miktar <= 4)
			{
				a = "K���k,";
			}
			if (miktar >= 3 && miktar <= 7)
			{
				a += "Orta,";
			}
			if (miktar >= 5.5 && miktar <= 10)
			{
				a += "B�y�k";
			}
			Bulan�kDe�erM = a.TrimEnd(',').Split(',');
			lb_Miktar.Text = a.TrimEnd(',');

			Islem();
		}

		private void numericUpDown_Kirlilik_ValueChanged(object sender, EventArgs e)
		{
			double kirlilik = (double)numericUpDown_Kirlilik.Value;
			trackBar_Kirlilik.Value = (int)(kirlilik * 10);
			Giris.Default.kirlilik = kirlilik;

			string a = "";
			if (kirlilik >= 0 && kirlilik <= 4.5)
			{
				a = "K���k,";
			}
			if (kirlilik >= 3 && kirlilik <= 7)
			{
				a += "Orta,";
			}
			if (kirlilik >= 5.5 && kirlilik <= 10)
			{
				a += "B�y�k";
			}
			Bulan�kDe�erK = a.TrimEnd(',').Split(',');
			lb_Kirlilik.Text = a.TrimEnd(',');

			Islem();
		}

		public void GirdiYenile()
		{
			pictureBox1.Invalidate();
			pictureBox2.Invalidate();
			pictureBox3.Invalidate();
		}
		public void CiktiYenile()
		{
			pictureBox5.Invalidate();
			pictureBox6.Invalidate();
			pictureBox7.Invalidate();
		}

		public void FiltreleVeSec(string[] BulanikH, string[] BulanikM, string[] BulanikK, DataGridView dgv, out DataSet ds)
		{
			
			string sorgu = "SELECT * FROM Kurallar WHERE ";

			sorgu += "(";
			for (int i = 0; i < BulanikH.Length; i++)
			{
				sorgu += $"hassaslik='{BulanikH[i]}'";
				if (i != BulanikH.Length - 1)
					sorgu += " OR ";
			}
			sorgu += ") AND ";

			sorgu += "(";
			for (int i = 0; i < BulanikM.Length; i++)
			{
				sorgu += $"miktar='{BulanikM[i]}'";
				if (i != BulanikM.Length - 1)
					sorgu += " OR ";
			}
			sorgu += ") AND ";

			sorgu += "(";
			for (int i = 0; i < BulanikK.Length; i++)
			{
				sorgu += $"kirlilik='{BulanikK[i]}'";
				if (i != BulanikK.Length - 1)
					sorgu += " OR ";
			}
			sorgu += ")";

			
			ds = new DataSet();
			try
			{
				con.Open();
				SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
				da.Fill(ds);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Hata: " + ex.Message);
			}
			finally
			{
				con.Close();
			}

			dgv.ClearSelection(); 
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				int rowIndex = Convert.ToInt32(ds.Tables[0].Rows[i][0]) - 1;
				if (rowIndex >= 0 && rowIndex < dgv.Rows.Count)
				{
					dgv.Rows[rowIndex].Selected = true;
				}
			}
		}

		private DataSet ds;
		public void Islem()
		{
			GirdiYenile();
			
			FiltreleVeSec(Bulan�kDe�erH, Bulan�kDe�erM, Bulan�kDe�erK, dataGridView1, out ds);

			mamdani.Islem(ds.Tables[0].Rows, listBox1);
			mamdani.max_bul(ds.Tables[0].Rows, out max_d�n��H�z�, out max_s�re, out max_deterjan);

			var sonuc = agirlikliOrtalama.Islem(max_d�n��H�z�, max_s�re, max_deterjan);
			
			label18.Text = sonuc.label18; 
			label16.Text = sonuc.label16; 
			label15.Text = sonuc.label15;

			var cikti = centroid.Hesapla(max_d�n��H�z�, max_s�re, max_deterjan);

			label24.Text = cikti.DonusH�z�;
			label20.Text = cikti.Deterjan;
			label22.Text = cikti.Sure;

			CiktiYenile();
		}
		PointF[] points = new PointF[4];
		private void pictureBox5_Paint(object sender, PaintEventArgs e)
		{

			pen.Width = 1.5f;

			if (max_d�n��H�z� != null)
			{
				noktalar.Nokta(0.1f, 0.1f, 0.5f, 1.5f, (float)max_d�n��H�z�[0], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(0.5f, 2.75f, 5f, (float)max_d�n��H�z�[1], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(2.75f, 5f, 7.25f, (float)max_d�n��H�z�[2], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(5f, 7.25f, 9.5f, (float)max_d�n��H�z�[3], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(8.5f, 9.5f, 10f, 10f, (float)max_d�n��H�z�[4], brush, points, sifir, bir, olcek, e);
			}

			pen.Color = Color.Blue;
			e.Graphics.DrawString("HASSAS", font, brush, 2 * olcek - 33, bir - 30);
			e.Graphics.DrawLine(pen, 18, bir, 18 + 0.5f * olcek, bir);
			e.Graphics.DrawLine(pen, 18 + 0.5f * olcek, bir, 18 + 1.5f * olcek, sifir);

			pen.Color = Color.DarkGreen;
			e.Graphics.DrawString("Normal-Hassas", font, brush, 2.75f * olcek - 22, bir - 15);
			e.Graphics.DrawLine(pen, 18 + 0.5f * olcek, sifir, 18 + 2.75f * olcek, bir);
			e.Graphics.DrawLine(pen, 18 + 2.75f * olcek, bir, 18 + 5 * olcek, sifir);

			pen.Color = Color.DarkGoldenrod;
			e.Graphics.DrawString("ORTA", font, brush, 5 * olcek, bir - 30);
			e.Graphics.DrawLine(pen, 18 + 2.75f * olcek, sifir, 18 + 5 * olcek, bir);
			e.Graphics.DrawLine(pen, 18 + 5 * olcek, bir, 18 + 7.25f * olcek, sifir);

			pen.Color = Color.Tomato;
			e.Graphics.DrawString("Normal-G��l�", font, brush, 7.25f * olcek - 22, bir - 15);
			e.Graphics.DrawLine(pen, 18 + 5 * olcek, sifir, 18 + 7.25f * olcek, bir);
			e.Graphics.DrawLine(pen, 18 + 7.25f * olcek, bir, 18 + 9.5f * olcek, sifir);

			pen.Color = Color.DarkCyan;
			e.Graphics.DrawString("G��L�", font, brush, 9.5f * olcek + 10, bir - 30);
			e.Graphics.DrawLine(pen, 18 + 8.5f * olcek, sifir, 18 + 9.5f * olcek, bir);
			e.Graphics.DrawLine(pen, 18 + 9.5f * olcek, bir, 18 + 10 * olcek, bir);

		}

		private void pictureBox6_Paint(object sender, PaintEventArgs e)
		{
			sifir = 88;
			bir = 35;

			if (max_deterjan != null)
			{
				noktalar.Nokta(0.1f, 0.1f, 0.66f, 2.83f, (float)max_deterjan[0], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(0.66f, 2.83f, 5f, (float)max_deterjan[1], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(2.83f, 5f, 7.16f, (float)max_deterjan[2], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(5f, 7.16f, 9.33f, (float)max_deterjan[3], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(7.16f, 9.33f, 10f, 10f, (float)max_deterjan[4], brush, points, sifir, bir, olcek, e);
			}

			pen.Color = Color.Blue;
			e.Graphics.DrawString("�OK AZ", font, brush, 23, bir - 15);
			e.Graphics.DrawLine(pen, 18, bir, 18 + 20 * olcek / 30, bir);
			e.Graphics.DrawLine(pen, 18 + 20 * olcek / 30, bir, 18 + 85 * olcek / 30, sifir);

			pen.Color = Color.DarkGreen;
			e.Graphics.DrawString("AZ", font, brush, 88, bir - 15);
			e.Graphics.DrawLine(pen, 18 + 20 * olcek / 30, sifir, 18 + 85 * olcek / 30, bir);
			e.Graphics.DrawLine(pen, 18 + 85 * olcek / 30, bir, 18 + 150 * olcek / 30, sifir);

			pen.Color = Color.DarkGoldenrod;
			e.Graphics.DrawString("ORTA", font, brush, 137, bir - 15);
			e.Graphics.DrawLine(pen, 18 + 85 * olcek / 30, sifir, 18 + 150 * olcek / 30, bir);
			e.Graphics.DrawLine(pen, 18 + 150 * olcek / 30, bir, 18 + 215 * olcek / 30, sifir);

			pen.Color = Color.Tomato;
			e.Graphics.DrawString("FAZLA", font, brush, 197, bir - 15);
			e.Graphics.DrawLine(pen, 18 + 150 * olcek / 30, sifir, 18 + 215 * olcek / 30, bir);
			e.Graphics.DrawLine(pen, 18 + 215 * olcek / 30, bir, 18 + 280 * olcek / 30, sifir);

			pen.Color = Color.DarkCyan;
			e.Graphics.DrawString("�OK FAZLA", font, brush, 255, bir - 15);
			e.Graphics.DrawLine(pen, 18 + 215 * olcek / 30, sifir, 18 + 280 * olcek / 30, bir);
			e.Graphics.DrawLine(pen, 18 + 280 * olcek / 30, bir, 18 + 300 * olcek / 30, bir);

			sifir = 120;
			bir = 50;
		}

		private void pictureBox7_Paint(object sender, PaintEventArgs e)
		{
			pen.Width = 1.5f;

			if (max_s�re != null)
			{
				noktalar.Nokta(0.1f, 0.1f, 2.23f, 3.99f, (float)max_s�re[0], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(2.23f, 3.99f, 5.75f, (float)max_s�re[1], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(3.99f, 5.75f, 7.51f, (float)max_s�re[2], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(5.75f, 7.51f, 9.27f, (float)max_s�re[3], brush, points, sifir, bir, olcek, e);
				noktalar.Nokta(7.5f, 9.27f, 10f, 10f, (float)max_s�re[4], brush, points, sifir, bir, olcek, e);
			}

			pen.Color = Color.Blue;
			e.Graphics.DrawString("KISA", font, brush, 2 * olcek - 33, bir - 30);
			e.Graphics.DrawLine(pen, 18, bir, 18 + 22.3f * olcek / 10, bir);
			e.Graphics.DrawLine(pen, 18 + 22.3f * olcek / 10, bir, 18 + 39.9f * olcek / 10, sifir);

			pen.Color = Color.DarkGreen;
			e.Graphics.DrawString("Normal-K�sa", font, brush, 2.75f * olcek + 15, bir - 15);
			e.Graphics.DrawLine(pen, 18 + 22.3f * olcek / 10, sifir, 18 + 39.9f * olcek / 10, bir);
			e.Graphics.DrawLine(pen, 18 + 39.9f * olcek / 10, bir, 18 + 57.5f * olcek / 10, sifir);

			pen.Color = Color.DarkGoldenrod;
			e.Graphics.DrawString("ORTA", font, brush, 22 + 5 * olcek, bir - 30);
			e.Graphics.DrawLine(pen, 18 + 39.9f * olcek / 10, sifir, 18 + 57.5f * olcek / 10, bir);
			e.Graphics.DrawLine(pen, 18 + 57.5f * olcek / 10, bir, 18 + 75.1f * olcek / 10, sifir);

			pen.Color = Color.Tomato;
			e.Graphics.DrawString("Normal-Uzun", font, brush, 7.25f * olcek - 13, bir - 15);
			e.Graphics.DrawLine(pen, 18 + 57.5f * olcek / 10, sifir, 18 + 75.1f * olcek / 10, bir);
			e.Graphics.DrawLine(pen, 18 + 75.1f * olcek / 10, bir, 18 + 92.7f * olcek / 10, sifir);

			pen.Color = Color.DarkCyan;
			e.Graphics.DrawString("UZUN", font, brush, 9.5f * olcek + 10, bir - 30);
			e.Graphics.DrawLine(pen, 18 + 75 * olcek / 10, sifir, 18 + 92.7f * olcek / 10, bir);
			e.Graphics.DrawLine(pen, 18 + 92.7f * olcek / 10, bir, 18 + 100 * olcek / 10, bir);
		}

		

		private void label3_Click(object sender, EventArgs e)
		{

		}


	}
}
