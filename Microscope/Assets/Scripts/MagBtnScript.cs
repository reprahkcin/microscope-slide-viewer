using UnityEngine;
using UnityEngine.UI;

public class MagBtnScript : MonoBehaviour
{
    private int btnID;
    private Button btn;
    public void SetID(int i) => btnID = i;

    private SlideDeck slideDeckScript;
    private int aSlide;
    void Start()
    {
        slideDeckScript = GameObject.Find("SlideDeck").GetComponentInChildren<SlideDeck>();
        aSlide = slideDeckScript.activeSlide;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => slideDeckScript.slides[aSlide].LoadMagnification(btnID));
    }


}
