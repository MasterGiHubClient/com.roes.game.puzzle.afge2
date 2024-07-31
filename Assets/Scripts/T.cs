using TMPro;
using UnityEngine;

public class T : MonoBehaviour
{
    [SerializeField] private float a;
    [SerializeField] private GC c;
    [SerializeField] private TextMeshProUGUI f;
    private float b;
    private bool d;
    public bool e;

    public void G(int h)
    {
        a = h;
    }

    public void I()
    {
        b = a;
        d = true;
        e = false;
    }

    public void J()
    {
        d = false;
    }

    public void K()
    {
        d = true;
    }

    public bool L()
    {
        return d;
    }

    void Update()
    {
        if (d)
        {
            if (b > 0)
            {
                b -= Time.deltaTime;
            }
            else
            {
                b = 0;
                d = false;
                e = true;
                c.SWW();
            }
            M(b);
        }
    }

    private void M(float n)
    {
        if (n < 0)
        {
            n = 0;
        }
        float o = Mathf.FloorToInt(n / 60);
        float p = Mathf.FloorToInt(n % 60);
        f.text = $"TIMES: {string.Format("{0:00}:{1:00}", o, p)}";
    }
}
