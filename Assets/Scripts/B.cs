using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class B : MonoBehaviour
{
	[SerializeField] private TTA[] tt;
	[SerializeField] private R[] r;
	[SerializeField] private float td;
	[SerializeField] private Transform so;
	[SerializeField] private bool ensm;
	[SerializeField] private GC gc;
	private readonly List<TI> s = new List<TI>();
	private bool iss;
	private bool ism;
	private bool issh;
	public event Action<TTA, int> om;

	private TD[,] M
	{
		get
		{
			var w = r.Max(row => row.tiles.Length);
			var h = r.Length;
			var d = new TD[w, h];
			for (var y = 0; y < h; y++)
			{
				for (var x = 0; x < w; x++)
				{
					d[x, y] = GT(x, y).Data;
				}
			}
			return d;
		}
	}

	public void UB()
	{
		S();
		StartCoroutine(ENSM());
	}

	private void Start()
	{
		for (var y = 0; y < r.Length; y++)
		{
			for (var x = 0; x < r.Max(row => row.tiles.Length); x++)
			{
				var t = GT(x, y);
				t.x = x;
				t.y = y;
				t.Type = tt[Random.Range(0, tt.Length)];
				t.button.onClick.AddListener(() => ST(t));
			}
		}

		if (ensm) StartCoroutine(ENSM());
		om += (type, count) => gc.UP(count, type.a);
	}

	public void S()
	{
		issh = true;
		foreach (var row in r)
		{
			foreach (var tile in row.tiles)
			{
				tile.Type = tt[Random.Range(0, tt.Length)];
			}
		}
		issh = false;
	}

	private async Task<bool> TMA()
	{
		var dm = false;
		ism = true;
		var m = TDMU.F(M);

		while (m != null)
		{
			dm = true;
			var t = GT(m.c);
			var ds = DOTween.Sequence();
			foreach (var tile in t)
			{
				ds.Join(tile.icon.transform.DOScale(Vector3.zero, td).SetEase(Ease.InBack));
			}
			gc.CS1();
			await ds.Play()
								 .AsyncWaitForCompletion();
			var isq = DOTween.Sequence();
			foreach (var tile in t)
			{
				tile.Type = tt[Random.Range(0, tt.Length)];
				isq.Join(tile.icon.transform.DOScale(new Vector2(0.8f, 0.8f), td).SetEase(Ease.OutBack));
			}
			await isq.Play()
								 .AsyncWaitForCompletion();
			om?.Invoke(Array.Find(tt, tileType => tileType.a == m.a), m.c.Length);
			m = TDMU.F(M);
		}
		ism = false;
		return dm;
	}

	private async void ST(TI tile)
	{
		if (iss || ism || issh)
		{
			return;
		}
		if (!s.Contains(tile))
		{
			if (s.Count > 0)
			{
				if (Math.Abs(tile.x - s[0].x) == 1 && Math.Abs(tile.y - s[0].y) == 0
					|| Math.Abs(tile.y - s[0].y) == 1 && Math.Abs(tile.x - s[0].x) == 0)
				{
					s.Add(tile);
				}
			}
			else
			{
				s.Add(tile);
			}
		}

		if (s.Count < 2)
		{
			return;
		}
		await SA(s[0], s[1]);
		if (!await TMA())
		{
			await SA(s[0], s[1]);
		}
		var matrix = M;
		while (TDMU.FBM(matrix) == null || TDMU.F(matrix) != null)
		{
			S();
			matrix = M;
		}
		s.Clear();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			var bm = TDMU.FBM(M);
			if (bm != null)
			{
				ST(GT(bm.a, bm.b));
				ST(GT(bm.c, bm.d));
			}
		}
	}

	private IEnumerator ENSM()
	{
		var w = new WaitForEndOfFrame();
		while (TDMU.F(M) != null)
		{
			S();
			yield return w;
		}
	}

	private TI GT(int x, int y) => r[y].tiles[x];

	private TI[] GT(IList<TD> tileData)
	{
		var length = tileData.Count;
		var tiles = new TI[length];
		for (var i = 0; i < length; i++)
		{
			tiles[i] = GT(tileData[i].X, tileData[i].Y);
		}
		return tiles;
	}

	private async Task SA(TI t1, TI t2)
	{
		iss = true;
		var i1 = t1.icon;
		var i2 = t2.icon;
		var i1t = i1.transform;
		var i2t = i2.transform;
		i1t.SetParent(so);
		i2t.SetParent(so);
		i1t.SetAsLastSibling();
		i2t.SetAsLastSibling();
		var sequence = DOTween.Sequence();
		sequence.Join(i1t.DOMove(i2t.position, td).SetEase(Ease.OutBack))
				.Join(i2t.DOMove(i1t.position, td).SetEase(Ease.OutBack));
		await sequence.Play()
					  .AsyncWaitForCompletion();
		i1t.SetParent(t2.transform);
		i2t.SetParent(t1.transform);
		t1.icon = i2;
		t2.icon = i1;
		var tile1Item = t1.Type;
		t1.Type = t2.Type;
		t2.Type = tile1Item;
		iss = false;
	}
}