using UnityEngine;

public class SkipDayAnimation : UiAnimation
{
    [SerializeField] GameObject blackScreen;
    [SerializeField] GameObject text;

    public void SkipDay()
    {
        blackScreen.SetActive(true);
        text.SetActive(true);
    }
}
