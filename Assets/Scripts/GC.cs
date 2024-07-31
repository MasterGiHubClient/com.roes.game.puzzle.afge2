using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GC : MonoBehaviour
{
    [SerializeField] private GameObject mm;
    [SerializeField] private GameObject gm;
    [SerializeField] private GameObject om;
    [SerializeField] private GameObject em;
    [SerializeField] private GameObject wm;
    [SerializeField] private GameObject sm;
    [SerializeField] private B b;
    [SerializeField] private TextMeshProUGUI pt;
    [SerializeField] private TextMeshProUGUI mt;
    [SerializeField] private T t;
    [SerializeField] private Slider ms;
    [SerializeField] private Slider ss;
    [SerializeField] private AudioSource ass;
    [SerializeField] private AudioSource asm;
    [SerializeField] private AudioClip cc;
    [SerializeField] private AudioClip mc1;
    [SerializeField] private AudioClip bc;
    [SerializeField] private TextMeshProUGUI fht;
    [SerializeField] private TextMeshProUGUI ftht;
    [SerializeField] private GameObject s;
    [SerializeField] private TextMeshProUGUI fst;
    [SerializeField] private TextMeshProUGUI i1ct;
    [SerializeField] private TextMeshProUGUI i2ct;
    [SerializeField] private TextMeshProUGUI i3ct;
    [SerializeField] private TextMeshProUGUI i4ct;
    [SerializeField] private TextMeshProUGUI i5ct;
    private int pc;
    private int mc;
    private float mv;
    private float sv;
    private int i1c;
    private int i2c;
    private int i3c;
    private int i4c;
    private int i5c;

    private void Start()
    {
        Application.targetFrameRate = 60;
        sm.SetActive(true);
        mm.SetActive(false);
        gm.SetActive(false);
        om.SetActive(false);
        wm.SetActive(false);
        em.SetActive(false);

        sv = PlayerPrefs.GetFloat("soundVolume", 1);
        mv = PlayerPrefs.GetInt("musicVolume", 1);
        ms.value = mv;
        ss.value = sv;
        ass.volume = sv;
        asm.volume = mv;

        asm.clip = bc;
        asm.Play();
    }

    private void CS()
    {
        ass.PlayOneShot(cc, 1f);
    }

    public void CS1()
    {
        ass.PlayOneShot(mc1, 1f);
    }

    public void FSTMM()
    {
        CS();
        sm.SetActive(false);
        mm.SetActive(true);
    }

    public void OSS()
    {
        sv = ss.value;
        ass.volume = sv;
    }

    public void OSM()
    {
        mv = ms.value;
        asm.volume = mv;
    }

    public void UP(int x, int id)
    {
        if (t.L())
        {
            pc = 25 * x;
            pt.text = $"{pc}";

            if (id == 0)
            {
                i1c++;
                i1ct.text = $"{i1c}/3";
            }
            if (id == 1)
            {
                i2c++;
                i2ct.text = $"{i2c}/3";
            }
            if (id == 2)
            {
                i3c++;
                i3ct.text = $"{i3c}/3";
            }
            if (id == 3)
            {
                i4c++;
                i4ct.text = $"{i4c}/3";
            }

            if (id == 4)
            {
                i5c++;
                i5ct.text = $"{i5c}/3";
            }

            if (i1c >= 3 && i2c >= 3
                && i3c >= 3 && i4c >= 3 && i5c >= 3)
            {
                t.J();
                SWW();
            }

            mc--;
            mt.text = $"MOVES: {mc}";

            if (mc == 0)
            {
                SWW();
            }
        }
    }

    public void SGM()
    {
        CS();
        i1c = 0;
        i2c = 0;
        i3c = 0;
        i4c = 0;
        i5c = 0;
        i1ct.text = $"{i1c}/3";
        i2ct.text = $"{i2c}/3";
        i3ct.text = $"{i3c}/3";
        i4ct.text = $"{i4c}/3";
        i5ct.text = $"{i5c}/3";

        mc = 50;
        mt.text = $"MOVES: {mc}";

        mm.SetActive(false);
        pc = 0;
        pt.text = $"{pc}";
        t.gameObject.SetActive(true);
        t.I();
        b.gameObject.SetActive(true);
        gm.SetActive(true);
        b.UB();
    }

    public void FGMM()
    {
        CS();
        gm.SetActive(false);
        t.J();
        wm.SetActive(false);
        mm.SetActive(true);
        b.gameObject.SetActive(true);
    }

    public void SWW()
    {
        gm.SetActive(false);
        wm.SetActive(true);
        t.J();
        if (t.e || mc <= 0)
        {
            fht.text = "LOSE";
            ftht.text = "LOSER!";
            fst.text = $"{pc}";
            s.gameObject.SetActive(false);
        }
        else
        {
            fht.text = "YOU WIN";
            ftht.text = "WINNER!";
            fst.text = $"{pc}";
            s.gameObject.SetActive(true);
        }
    }

    public void AE()
    {
        CS();
        Application.Quit();
    }

    public void FMMOM()
    {
        CS();
        mm.SetActive(false);
        om.SetActive(true);
    }

    public void FOMMM()
    {
        CS();
        om.SetActive(false);
        mm.SetActive(true);

        PlayerPrefs.SetFloat("soundVolume", sv);
        PlayerPrefs.SetFloat("musicVolume", mv);
    }

    public void SEM()
    {
        CS();
        mm.SetActive(false);
        em.SetActive(true);
    }

    public void CEM()
    {
        CS();
        em.SetActive(false);
        mm.SetActive(true);
    }

    public void FWM()
    {
        CS();
        wm.SetActive(false);
        mm.SetActive(true);
    }
}