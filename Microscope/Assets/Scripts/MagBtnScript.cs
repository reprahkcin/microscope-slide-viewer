using UnityEngine;
using UnityEngine.UI;

public class MagBtnScript : MonoBehaviour
{
    private int btnID;
    private Button btn;
    public Sprite btn_on;
    public Sprite btn_off;
    public void SetID(int i) => btnID = i;
    public bool isActive;
    private SlideDeck slideDeckScript;

    public int activeMag;

    private int aSlide;
    void Start()
    {
        slideDeckScript = GameObject.Find("SlideDeck").GetComponentInChildren<SlideDeck>();
        aSlide = slideDeckScript.activeSlide;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => slideDeckScript.slides[aSlide].LoadMagnification(btnID));

    }

    void Update()
    {
        aSlide = slideDeckScript.activeSlide;
        activeMag = slideDeckScript.slides[aSlide].activeMagnification;

        if (btnID == activeMag)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        if (isActive)
        {
            gameObject.GetComponent<Image>().sprite = btn_on;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = btn_off;
        }
    }


}
