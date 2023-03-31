using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Image fadeOutPanel;
    [SerializeField] private float fadeDuration = 1f;

    public void FadeToLevel(string levelName)
    {
        StartCoroutine(FadeOutAndLoad(levelName));
    }

    private IEnumerator FadeOutAndLoad(string levelName)
    {
        float elapsed = 0f;
        Color panelColor = fadeOutPanel.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            panelColor.a = Mathf.Clamp01(elapsed / fadeDuration);
            fadeOutPanel.color = panelColor;
            yield return null;
        }

        SceneManager.LoadScene(levelName);
    }
}