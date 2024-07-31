using System.Collections.Generic;

public static class TDMU
{
	public static void S(int a, int b, int c, int d, TD[,] e)
	{
		var f = e[a, b];
		e[a, b] = e[c, d];
		e[c, d] = f;
	}

	public static (TD[], TD[]) G(int a, int b, TD[,] c)
	{
		var d = c[a, b];
		var e = c.GetLength(0);
		var f = c.GetLength(1);
		var g = new List<TD>();
		var h = new List<TD>();

		for (var i = a - 1; i >= 0; i--)
		{
			var j = c[i, b];
			if (j.TypeId != d.TypeId)
			{
				break;
			}
			g.Add(j);
		}

		for (var i = a + 1; i < e; i++)
		{
			var j = c[i, b];
			if (j.TypeId != d.TypeId)
			{
				break;
			}
			g.Add(j);
		}

		for (var k = b - 1; k >= 0; k--)
		{
			var j = c[a, k];
			if (j.TypeId != d.TypeId)
			{
				break;
			}
			h.Add(j);
		}

		for (var k = b + 1; k < f; k++)
		{
			var j = c[a, k];
			if (j.TypeId != d.TypeId)
			{
				break;
			}
			h.Add(j);
		}

		return (g.ToArray(), h.ToArray());
	}

	public static M F(TD[,] a)
	{
		var b = default(M);

		for (var c = 0; c < a.GetLength(1); c++)
		{
			for (var d = 0; d < a.GetLength(0); d++)
			{
				var e = a[d, c];
				var (f, g) = G(d, c, a);
				var h = new M(e, f, g);
				if (h.b < 0) continue;
				if (b == null)
				{
					b = h;
				}
				else if (h.b > b.b) b = h;
			}
		}
		return b;
	}

	public static List<M> FAM(TD[,] a)
	{
		var b = new List<M>();

		for (var c = 0; c < a.GetLength(1); c++)
		{
			for (var d = 0; d < a.GetLength(0); d++)
			{
				var e = a[d, c];
				var (f, g) = G(d, c, a);
				var h = new M(e, f, g);
				if (h.b > -1) b.Add(h);
			}
		}

		return b;
	}

	private static (int, int) G(byte a) => a switch
	{
		0 => (-1, 0),
		1 => (0, -1),
		2 => (1, 0),
		3 => (0, 1),
		_ => (0, 0),
	};


	public static MO FM(TD[,] a)
	{
		var b = (TD[,])a.Clone();

		var c = b.GetLength(0);
		var d = b.GetLength(1);

		for (var e = 0; e < d; e++)
		{
			for (var f = 0; f < c; f++)
			{
				for (byte g = 0; g <= 3; g++)
				{
					var (h, i) = G(g);
					var j = f + h;
					var k = e + i;
					if (j < 0 || j > c - 1 || k < 0 || k > d - 1) continue;
					S(f, e, j, k, b);
					if (F(b) != null) return new MO(f, e, j, k);
					S(j, k, f, e, b);
				}
			}
		}
		return null;
	}


	public static MO FBM(TD[,] a)
	{
		var b = (TD[,])a.Clone();
		var c = b.GetLength(0);
		var d = b.GetLength(1);
		var e = int.MinValue;
		var f = default(MO);

		for (var g = 0; g < d; g++)
		{
			for (var h = 0; h < c; h++)
			{
				for (byte i = 0; i <= 3; i++)
				{
					var (j, k) = G(i);
					var l = h + j;
					var m = g + k;
					if (l < 0 || l > c - 1 || m < 0 || m > d - 1) continue;
					S(h, g, l, m, b);
					var n = F(b);
					if (n != null && n.b > e)
					{
						f = new MO(h, g, l, m);
						e = n.b;
					}
					S(h, g, l, m, b);
				}
			}
		}
		return f;
	}
}