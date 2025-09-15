using UnityEngine;
using UnityEngine.UI;

public class EnemyDuelSpriteControl : MonoBehaviour
{
    [SerializeField] Sprite[] enemySprites;
    [SerializeField] Image enemyImage;
    [SerializeField] RectTransform rt;
    [SerializeField] UiAnimation enemySpriteAnimation;
    [SerializeField] EnemyScript enemyScript;

    private void OnEnable()
    {
        enemyImage.sprite = enemySprites[enemyScript.enemyEncounter];

        switch (enemyScript.enemyEncounter)
        {
            case 0:
                enemySpriteAnimation.targetPosition = new Vector3(378, -132, 0);
                rt.sizeDelta = new Vector2(700f, 1150f);
                rt.rotation = new Quaternion(0f, 0f, 0f, 0f);
                break;
            case 1:
                enemySpriteAnimation.targetPosition = new Vector3(300, -132, 0);
                rt.sizeDelta = new Vector2(490f, 1100f);
                rt.rotation = new Quaternion(0f, 0f, 0f, 0f);
                break;
            case 2:
                enemySpriteAnimation.targetPosition = new Vector3(378, -132, 0);
                rt.sizeDelta = new Vector2(550f, 1100f);
                rt.rotation = new Quaternion(0f, 180f, 0f, 0f);
                break;
            case 3:
                enemySpriteAnimation.targetPosition = new Vector3(378, -132, 0);
                rt.sizeDelta = new Vector2(550f, 1100f);
                rt.rotation = new Quaternion(0f, 0f, 0f, 0f);
                break;
        }
    }

}
