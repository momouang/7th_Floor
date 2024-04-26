using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour
{
    public Image fadePanel; // ָ������ϵ�Image���������
    public float fadeDuration = 1.0f; // �����ܳ���ʱ�䣬��λΪ��

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

        fadePanel.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0); // ȷ����ȫ͸��
        fadePanel.gameObject.SetActive(false); // ����ѡ�����������������
    }
}