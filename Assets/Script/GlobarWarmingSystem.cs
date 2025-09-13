using UnityEngine;

public class GlobarWarmingSystem : MonoBehaviour 
{
    public int startingLevel = 300;
    public int currentLevel;

    public int maxPower, currentPower;
    
    public int maxWater, currentWater;

    [SerializeField] private UnityEngine.UI.Image levelBarForeground, powerBarForeground, waterBarForeground;
    //[SerializeField] private AnimationCurve curve;

    private void Awake()
    {
        currentLevel = startingLevel;
    }
    public void lowerTheLevelBy(int subtract)
    {
        currentLevel -= subtract;
        loadGWLevelUI();
    } 

    public void loadGWLevelUI()
    {
        levelBarForeground.fillAmount = (float)currentLevel / (float)startingLevel;
    } 


}
