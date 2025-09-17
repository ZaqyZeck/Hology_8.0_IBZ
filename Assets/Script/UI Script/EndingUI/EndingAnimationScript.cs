using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndingAnimationScript : MonoBehaviour
{
    [SerializeField] private Image ilustrationSprite; // pastikan ini adalah UI Image
    [SerializeField] private GameObject MainMenuButton;
    public float duration = 2f;

    private void Start()
    {
        MainMenuButton.SetActive(false); // sembunyikan tombol dulu
        StartCoroutine(FadeInSprite());
    }

    private IEnumerator FadeInSprite()
    {

        float elapsed = 0f;

        Color color = ilustrationSprite.color;
        color.a = 0f; // mulai dari transparan
        ilustrationSprite.color = color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / duration);
            color.a = alpha;
            ilustrationSprite.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(6f);
        // setelah fade in selesai, tampilkan tombol
        MainMenuButton.SetActive(true);
    }
}
