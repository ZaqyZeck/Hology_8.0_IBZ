using UnityEngine;

public class GlobarWarmingSystem : MonoBehaviour 
{
    public int startingLevel = 300;
    public int currentLevel;

    public int maxPower, currentPower;
    
    public int maxWater, currentWater;

    [SerializeField] private UnityEngine.UI.Image levelBarForeground, powerBarForeground, waterBarForeground;

    [SerializeField] private PowerStorage powerStorage;
    [SerializeField] private PlantSystem plantSystem;
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
        maxPower = powerStorage.maxPower;
        currentPower = powerStorage.totalPower;
        maxWater = (int) plantSystem._maxWater;
        currentWater = (int)plantSystem._water;

        levelBarForeground.fillAmount = (float)currentLevel / (float)startingLevel;
        if (maxPower <= 0) powerBarForeground.fillAmount = 0;
        else powerBarForeground.fillAmount = (float)currentPower / (float)maxPower;
        if (maxWater <= 0) waterBarForeground.fillAmount = 0;
        else waterBarForeground.fillAmount = (float)currentWater / (float)maxWater;
    } 


}
