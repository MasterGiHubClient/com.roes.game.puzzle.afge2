public sealed class M
{
	public readonly int a;
	public readonly int b;
	public readonly TD[] c;

	public M(TD d, TD[] e, TD[] f)
	{
		a = d.TypeId;
		if (e.Length >= 2 && f.Length >= 2)
		{
			c = new TD[e.Length + f.Length + 1];
			c[0] = d;
			e.CopyTo(c, 1);
			f.CopyTo(c, e.Length + 1);
		}
		else if (e.Length >= 2)
		{
			c = new TD[e.Length + 1];
			c[0] = d;
			e.CopyTo(c, 1);
		}
		else if (f.Length >= 2)
		{
			c = new TD[f.Length + 1];
			c[0] = d;
			f.CopyTo(c, 1);
		}
		else c = null;
		b = c?.Length ?? -1;
	}
}