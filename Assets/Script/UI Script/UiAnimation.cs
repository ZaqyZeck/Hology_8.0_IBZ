using UnityEngine;
using System.Collections;

public class UiAnimation : MonoBehaviour
{
    public int indexAnimation;
    public bool isMoving, isFadeIn;
    public float waitsDuration;

    [Header("Movement Settings")]
    public Vector3 startingPosition;
    public Vector3 targetPosition;
    public float moveDuration = 1f;

    [Header("Blink Settings")]
    public float blinkInterval = 0.5f; // waktu berkedip
    private bool isBlinking = false;

    [Header("Fade Settings")]
    public float fadeDuration = 1f;
    [SerializeField] private CanvasGroup canvasGroup;

    private void Awake()
    {
        // Tambahkan CanvasGroup jika belum ada
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        // Set posisi awal
        //transform.position = startingPosition;
        startingPosition = transform.localPosition;
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
            case 5:
                // apakah ini bagus?
                MoveAndFadeIn();
                break;
            case 6:
                MoveToTargetThenMoveAgain();
                break;
            case 7:
                MoveToTargetThenFade();
                break;
            case 8:
                FadeInThenWaitAndFadeOut();
                break;
            case 9:
                FadeInWait();
                break;
        }
    }

    //private IEnumerator SequenceFadeAndMove()
    //{
    //    // Fade in
    //    isMoving = true;
    //    yield return StartCoroutine(FadeCoroutine(0f, 1f, fadeDuration));

    //    isFadeIn = true;
    //    // Move ke target
    //    yield return StartCoroutine(MoveCoroutine(startingPosition, targetPosition, moveDuration));
    //    isFadeIn = false;

    //    // Tunggu 2 detik
    //    yield return new WaitForSeconds(2f);

    //    // Move lagi ke arah yang sama (misalnya double jarak)
    //    //Vector3 secondTarget = targetPosition + (targetPosition - startingPosition);
    //    //yield return StartCoroutine(MoveCoroutine(targetPosition, secondTarget, moveDuration));
    //}

    // ---------------- MOVE ----------------
    public void MoveToTarget()
    {
        StopAllCoroutines();
        StartCoroutine(MoveCoroutine(startingPosition, targetPosition, moveDuration));
    }

    public void MoveToTargetThenMoveAgain()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToTargetThenContinue());
    }

    public IEnumerator MoveToTargetThenContinue()
    {
        yield return MoveCoroutine(startingPosition, targetPosition, moveDuration);
        yield return new WaitForSeconds(1f);

        Vector3 secondTarget = targetPosition + (targetPosition - startingPosition);
        yield return MoveCoroutine(targetPosition, secondTarget, moveDuration);
        //gameObject.SetActive(false);
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

    public void FadeInWait()
    {
        canvasGroup.alpha = 0f;
        StopAllCoroutines();
        StartCoroutine(FadeCoroutineWait(0f, 1f, fadeDuration));
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

    private IEnumerator FadeCoroutineWait(float from, float to, float duration)
    {
        yield return new WaitForSeconds(waitsDuration);
        //if (waitsDuration > 6) yield return new WaitForSeconds(waitsDuration);
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

    // hjhjb

    public void MoveToTargetThenFade()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToTargetThenFadeCoroutine());
    }

    private IEnumerator MoveToTargetThenFadeCoroutine()
    {
        yield return new WaitForSeconds(fadeDuration);
        // --- MOVE ke target sambil FADE IN ---
        float time = 0f;
        while (time < moveDuration)
        {
            float t = time / moveDuration;
            transform.localPosition = Vector3.Lerp(startingPosition, targetPosition, t);
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPosition;
        canvasGroup.alpha = 1f;

        // Tunggu sebentar
        yield return new WaitForSeconds(waitsDuration);

        // --- MOVE lagi ke second target sambil FADE OUT ---
        Vector3 secondTarget = targetPosition + (targetPosition - startingPosition);
        time = 0f;
        while (time < moveDuration)
        {
            float t = time / moveDuration;
            transform.localPosition = Vector3.Lerp(targetPosition, secondTarget, t);
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = secondTarget;
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }


    // ---------------- FADE IN → WAIT → FADE OUT ----------------
    public void FadeInThenWaitAndFadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInThenWaitAndFadeOutCoroutine());
        
    }

    private IEnumerator FadeInThenWaitAndFadeOutCoroutine()
    {
        // Fade In
        float time = 0f;
        while (time < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        // Tunggu 2 detik
        yield return new WaitForSeconds(waitsDuration);

        // Fade Out
        time = 0f;
        while (time < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }
}
