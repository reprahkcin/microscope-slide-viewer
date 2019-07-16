using UnityEngine;

public class SlideDeck : MonoBehaviour
{
    public Slide[] slides;

    public int activeSlide;

    void Start()
    {
        activeSlide = 0;
    }

    public void StepForwardSlide()
    {
        activeSlide++;
        if (activeSlide > slides.Length - 1)
        {
            activeSlide = 0;
        }
        DisplaySlide(activeSlide);
        slides[activeSlide].GetComponentInChildren<Slide>().ChangeTitle();
    }

    public void StepBackwardSlide()
    {
        activeSlide--;
        if (activeSlide < 0)
        {
            activeSlide = slides.Length - 1;
        }
        DisplaySlide(activeSlide);
        slides[activeSlide].GetComponentInChildren<Slide>().ChangeTitle();
    }

    public void DisplaySlide(int i)
    {
        foreach (Slide slide in slides)
        {
            slide.gameObject.SetActive(false);
        }
        slides[activeSlide].gameObject.SetActive(true);
    }

    public void StepForwardZoom()
    {
        slides[activeSlide].StepForward();
    }

    public void StepBackwardZoom()
    {
        slides[activeSlide].StepBackward();
    }
}
