using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageFeedback : MonoBehaviour
{
    [SerializeField] private Text amountText;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float lifetime = 1.5f;
    [SerializeField] private float riseSpeed = 0.5f;

    public void Initialize(int amount)
    {
        if (amountText != null)
            amountText.text = amount.ToString();

        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsed = 0f;

        while (elapsed < lifetime)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsed / lifetime);

            if (canvasGroup != null)
                canvasGroup.alpha = 1f - normalizedTime;

            transform.position += Vector3.up * (riseSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
    }
}
