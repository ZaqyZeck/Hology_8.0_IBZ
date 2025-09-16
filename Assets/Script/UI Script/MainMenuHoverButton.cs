using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuHoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Text UiText;
    [SerializeField] Image BgText;
    public int buttonIndex;
    public void OnPointerEnter(PointerEventData eventData)
    {
        UiText.color = Color.black;
        BgText.color = Color.white;
    }

    // Dipanggil saat mouse keluar dari area button
    public void OnPointerExit(PointerEventData eventData)
    {

        UiText.color = Color.white;
        BgText.color = new Color(1f, 1f, 1f, 0f);

    }

    public void OnEnable()
    {
        UiText.color = Color.white;
        BgText.color = new Color(1f, 1f, 1f, 0f);
    }
}
