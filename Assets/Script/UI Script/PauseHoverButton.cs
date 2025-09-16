using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // penting!

public class PauseHoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] Text UiText;
    [SerializeField] Image BgText;
    public int buttonIndex;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonIndex == 0)
        {
            UiText.color = Color.white;
            BgText.color = new Color(0f, 0f, 0f, 255f);
        }
        else
        {
            UiText.color = Color.white;
            BgText.color = Color.black;
        }
    }

    // Dipanggil saat mouse keluar dari area button
    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonIndex == 0)
        {
            UiText.color = Color.black;
            BgText.color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            UiText.color = Color.black;
            BgText.color = Color.white;
        }
    }

    public void OnEnable()
    {
        if (buttonIndex == 0)
        {
            UiText.color = Color.black;
            BgText.color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            UiText.color = Color.black;
            BgText.color = Color.white;
        }
    }
}
