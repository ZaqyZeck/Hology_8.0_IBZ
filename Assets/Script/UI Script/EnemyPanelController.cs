using UnityEngine;
using UnityEngine.UI;

public class EnemyPanelController : MonoBehaviour
{
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] Sprite[] enemySprites;
    [SerializeField] Image enemyImage;

    private void OnEnable()
    {
        enemyImage.sprite = enemySprites[enemyScript.enemyEncounter];
    }
}
