using UnityEngine;
using System.Collections;

public class UiAnimation : MonoBehaviour
{
    public int indexAnimation;

    [Header("Movement Settings")]
    public Vector3 startingPosition;
    public Vector3 targetPosition;
    public float moveDuration = 1f;

    [Header("Blink Settings")]
    public float blinkInterval = 0.5f; // waktu berkedip
    private bool isBlinking = false;

    [Header("Fade Settings")]
    public float fadeDuration = 1f;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        // Tambahkan CanvasGroup jika belum ada
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        // Set posisi awal
        //transform.position = startingPosition;
    }

    private void OnEnable()
    {
        //transform.localPosition = startingPosition;
        switch (indexAnimation)
        {
            case 1: 
                MoveToTarget();
                break;
            case 2:
                MoveToTarget();
                MoveToStart();
                break;
            case 3:
                StartBlink();
                break;
            case 4:
                FadeIn(); 
                break;
        }
    }

    // ---------------- MOVE ----------------
    public void MoveToTarget()
    {
        StopAllCoroutines();
        StartCoroutine(MoveCoroutine(startingPosition, targetPosition, moveDuration));
    }

    public void MoveToStart()
    {
        StopAllCoroutines();
        StartCoroutine(MoveCoroutine(targetPosition, startingPosition, moveDuration));
    }

    private IEnumerator MoveCoroutine(Vector3 from, Vector3 to, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            transform.localPosition = Vector3.Lerp(from, to, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = to;
    }

    // ---------------- BLINK ----------------
    public void StartBlink()
    {
        if (!isBlinking)
        {
            isBlinking = true;
            StartCoroutine(BlinkCoroutine());
        }
    }

    public void StopBlink()
    {
        isBlinking = false;
        StopCoroutine(BlinkCoroutine());
        canvasGroup.alpha = 1f; // pastikan tetap terlihat
    }

    private IEnumerator BlinkCoroutine()
    {
        while (isBlinking)
        {
            canvasGroup.alpha = (canvasGroup.alpha == 1f) ? 0f : 1f;
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    // ---------------- FADE ----------------
    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeCoroutine(0f, 1f, fadeDuration));
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeCoroutine(1f, 0f, fadeDuration));
    }

    private IEnumerator FadeCoroutine(float from, float to, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = to;
    }

    // ---------------- MOVE + FADE ----------------
    public void MoveAndFadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(MoveAndFadeCoroutine(startingPosition, targetPosition, 0f, 1f, Mathf.Max(moveDuration, fadeDuration)));
    }

    public void MoveAndFadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(MoveAndFadeCoroutine(targetPosition, startingPosition, 1f, 0f, Mathf.Max(moveDuration, fadeDuration)));
    }

    private IEnumerator MoveAndFadeCoroutine(Vector3 from, Vector3 to, float alphaFrom, float alphaTo, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            float t = time / duration;
            transform.localPosition = Vector3.Lerp(from, to, t);
            canvasGroup.alpha = Mathf.Lerp(alphaFrom, alphaTo, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = to;
        canvasGroup.alpha = alphaTo;
    }
}
