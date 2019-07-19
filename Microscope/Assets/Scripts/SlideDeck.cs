using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideDeck : MonoBehaviour
{
    public GameObject buttonPrefab;
    private GameObject[] buttons;

    public GameObject header;

    public GameObject slideTitle;
    public GameObject slideTitleShadow;

    public Slide[] slides;


    public int activeSlide;

    void Start()
    {
        LoadSlide(0);
    }

    public void LoadSlide(int slideIndex)
    {
        DisplaySlide(slideIndex);
        BuildButtons(slideIndex);
        ChangeTitle(slideIndex);
    }

    public void UnloadSlide()
    {
        foreach (Slide slide in slides)
        {
            slide.gameObject.SetActive(false);
        }

        string slideTitleText = "Please Load a Slide";
        slideTitle.GetComponentInChildren<TextMeshProUGUI>().text = slideTitleText;
        slideTitleShadow.GetComponentInChildren<TextMeshProUGUI>().text = slideTitleText;

        RemoveButtons();
    }

    public void StepForwardSlide()
    {
        activeSlide++;
        if (activeSlide > slides.Length - 1)
        {
            activeSlide = 0;
        }
        UnloadSlide();
        LoadSlide(activeSlide);
    }

    public void StepBackwardSlide()
    {
        activeSlide--;
        if (activeSlide < 0)
        {
            activeSlide = slides.Length - 1;
        }
        UnloadSlide();
        LoadSlide(activeSlide);
    }

    public void StepForwardMagnification() => slides[activeSlide].GetComponent<Slide>().StepForwardMagnification();
    public void StepBackwardMagnification() => slides[activeSlide].GetComponent<Slide>().StepBackwardMagnification();

    public void DisplaySlide(int slideIndex)
    {
        foreach (Slide slide in slides)
        {
            slide.gameObject.SetActive(false);
        }
        slides[slideIndex].gameObject.SetActive(true);
    }
    public void ChangeTitle(int slideIndex)
    {
        string slideTitleText = slides[slideIndex].GetComponent<Slide>().title;
        slideTitle.GetComponent<TextMeshProUGUI>().text = slideTitleText;
        slideTitleShadow.GetComponent<TextMeshProUGUI>().text = slideTitleText;
    }

    public void BuildButtons(int slideIndex)
    {
        int howMany = slides[slideIndex].GetComponentInChildren<Slide>().Magnifications.Length;
        buttons = new GameObject[howMany];
        for (int i = 0; i < howMany; i++)
        {
            GameObject btn = Instantiate(buttonPrefab, header.transform);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = slides[slideIndex].MagBtnLabels[i];
            btn.AddComponent<MagBtnScript>();
            btn.GetComponent<MagBtnScript>().SetID(i);
            buttons[i] = btn;
        }
    }

    public void RemoveButtons()
    {
        if (buttons != null)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                Destroy(buttons[i].gameObject);
            }
        }
    }

}
