using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour
{
    public Image fadePanel; // 指向面板上的Image组件的引用
    public float fadeDuration = 1.0f; // 淡出总持续时间，单位为秒

    void Start()
    {
        Invoke("startnow", 1);
    }

     void startnow()
    {
        StartCoroutine(FadeOutEffect());
    }

    IEnumerator FadeOutEffect()
    {
        float currentTime = 0f;
        Color originalColor = fadePanel.color;

        while (currentTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, currentTime / fadeDuration);
            fadePanel.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }

        fadePanel.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0); // 确保完全透明
        fadePanel.gameObject.SetActive(false); // 可以选择禁用面板以提高性能
    }
}