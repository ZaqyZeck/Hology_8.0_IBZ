using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RedBlackHoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Text UiText;
    [SerializeField] Image BgText;
    public void OnPointerEnter(PointerEventData eventData)
    {

        UiText.color = Color.red;
        BgText.color = Color.black;

    }

    // Dipanggil saat mouse keluar dari area button
    public void OnPointerExit(PointerEventData eventData)
    {

        UiText.color = Color.black;
        BgText.color = Color.red;

    }

    public void OnEnable()
    {

        UiText.color = Color.black;
        BgText.color = Color.red;

    }
}
