using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // penting!

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image buttonImage;

    [SerializeField] Sprite[] buttonSprites;

    // Dipanggil saat mouse masuk ke area button
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse Hover ON: " + gameObject.name);
        // contoh: ubah warna button
        buttonImage.sprite = buttonSprites[1];
    }

    // Dipanggil saat mouse keluar dari area button
    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonSprites.Length == 4)
        {
            if (alurTutorial.alur[3] && !alurTutorial.alur[4]) buttonSprites[0] = buttonSprites[3];
        }
        buttonImage.sprite = buttonSprites[0];
    }

    private void Update()
    {
        if (buttonSprites.Length != 4) return;
        if (buttonSprites[0] == buttonSprites[1]) return;
        if (alurTutorial.alur[3] && !alurTutorial.alur[4])
        {
            if (buttonSprites[0] != buttonSprites[3])
            {
                buttonSprites[0] = buttonSprites[3];
                buttonImage.sprite = buttonSprites[0];
            }
        }
        else if(buttonSprites[0] != buttonSprites[2]) buttonSprites[0] = buttonSprites[2];
    }
}
