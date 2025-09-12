using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] GameManager gameManager;
    [SerializeField] Button characterButton;
    [SerializeField] GameObject mysterySprite, challengingSprite, defeatedSprite, currentSprite;
    [SerializeField] Sprite enemyStatPanelSprite;
    [SerializeField] Image enemyStatPanelImage;
    public int enemyIndex;
    private void OnEnable()
    {
        if (enemyIndex > enemyScript.enemyEncounter)
        {
            ChangeSprite(mysterySprite);
        }
        else if (enemyIndex == enemyScript.enemyEncounter)
        {
            if (enemyIndex == 0 && gameManager.day < 11)
            {
                //characterButton.enabled = false;
                ChangeSprite(mysterySprite);
                return;
            }
            enemyStatPanelImage.sprite = enemyStatPanelSprite;
            ChangeSprite(challengingSprite);
        }
        else
        {
            ChangeSprite(defeatedSprite);
        }
    }

    public void ChangeSprite(GameObject sprite)
    {
        currentSprite.SetActive(false);
        currentSprite = sprite;
        currentSprite.SetActive(true);
        if(currentSprite == challengingSprite)
        {
            characterButton.enabled = true;
        }
        else
        {
            characterButton.enabled = false;
        }
    }
}
