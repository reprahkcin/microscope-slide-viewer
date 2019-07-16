using TMPro;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public string title;
    public string description;
    public Sprite[] zooms;
    public string[] magnificationLevels;
    private GameObject slideTitle;
    private GameObject slideTitleShadow;

    public int activeZoom;

    void Start()
    {
        activeZoom = 0;
        DisplayZoom(activeZoom);
        ChangeTitle();
    }

    public void DisplayZoom(int i)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = zooms[i];
    }

    public void ChangeTitle()
    {
        slideTitle = GameObject.Find("Slide Title");
        slideTitleShadow = GameObject.Find("Slide Title Shadow");
        slideTitle.GetComponent<TextMeshProUGUI>().text = title;
        slideTitleShadow.GetComponent<TextMeshProUGUI>().text = title;
    }

    public void StepForward()
    {
        activeZoom++;
        if (activeZoom > zooms.Length-1)
        {
            activeZoom = 0;
        }
        DisplayZoom(activeZoom);
        ChangeTitle();
    }

    public void StepBackward()
    {
        activeZoom--;
        if (activeZoom < 0)
        {
            activeZoom = zooms.Length-1;
        }
        DisplayZoom(activeZoom);
        ChangeTitle();
    }

}
