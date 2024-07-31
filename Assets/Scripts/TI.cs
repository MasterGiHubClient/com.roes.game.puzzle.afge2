using UnityEngine;
using UnityEngine.UI;

public sealed class TI : MonoBehaviour
{
	public int x;
	public int y;
	public Image icon;
	public Button button;
	private TTA _type;

	public TTA Type
	{
		get => _type;

		set
		{
			if (_type == value) return;

			_type = value;

			icon.sprite = _type.c;
		}
	}

	public TD Data => new TD(x, y, _type.a);
}