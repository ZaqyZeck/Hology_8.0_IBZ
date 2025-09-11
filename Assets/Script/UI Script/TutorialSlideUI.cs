using UnityEngine;

public class TutorialSlideUI : MonoBehaviour
{
    [SerializeField] GameObject[] slidesTutorial;
    public int currentSlide, maxSlide;
    public GameObject slide;

    public GameObject SkipDayButton;
    public void NextSlide()
    {
        if (currentSlide == maxSlide) currentSlide = 0;
        else currentSlide++;

        ChangeSlide(slidesTutorial[currentSlide]);
    }

    public void PreviousSlide()
    {
        if (currentSlide == 0) currentSlide = maxSlide;
        else currentSlide--;

        ChangeSlide(slidesTutorial[currentSlide]);
    }

    public void SetSlideBy(int slideIndex)
    {
        ChangeSlide(slidesTutorial[slideIndex]);
    }

    public void ChangeSlide(GameObject nextSlide)
    {
        slide.SetActive(false);
        slide = nextSlide;
        slide.SetActive(true);
    }

    private void OnEnable()
    {
        if(alurTutorial.alur[3] && !alurTutorial.alur[4])
        {
            alurTutorial.alur[4] = true;
            SkipDayButton.SetActive(true);
        }
    }
}
