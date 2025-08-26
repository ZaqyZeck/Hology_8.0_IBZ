using UnityEngine;

public class GlobarWarmingSystem : MonoBehaviour 
{
    public int startingLevel = 300;
    public int currentLevel;

    [SerializeField] private UnityEngine.UI.Image levelBarForeground;
    //[SerializeField] private AnimationCurve curve;

    private void Awake()
    {
        currentLevel = startingLevel;
    }
    public void lowerTheLevelBy(int subtract)
    {
        currentLevel -= subtract;
        levelBarForeground.fillAmount = (float)currentLevel / (float)startingLevel;
    } 
}
