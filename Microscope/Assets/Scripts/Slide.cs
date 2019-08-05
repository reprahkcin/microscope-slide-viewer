using UnityEngine;

public class Slide : MonoBehaviour
{
    public string title;
    public Sprite[] Magnifications;
    public string[] MagBtnLabels;

    public int activeMagnification;

    void Start()
    {
        activeMagnification = 0;
    }

    public void LoadMagnification(int magIndex)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Magnifications[magIndex];
        activeMagnification = magIndex;
    }


    public void StepForwardMagnification()
    {
        activeMagnification++;
        if (activeMagnification > Magnifications.Length - 1)
        {
            activeMagnification = 0;
        }
        DisplayMagnification(activeMagnification);
    }

    public void StepBackwardMagnification()
    {
        activeMagnification--;
        if (activeMagnification < 0)
        {
            activeMagnification = Magnifications.Length - 1;
        }
        DisplayMagnification(activeMagnification);
    }

    public void DisplayMagnification(int i)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Magnifications[i];
        activeMagnification = i;
    }

}
