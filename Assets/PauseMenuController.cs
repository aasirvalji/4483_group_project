using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Button pauseButton;
    public GameObject pausePanel;
    public Button resumeButton;
    private bool isPaused = false;

    void Start()
    {
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(TogglePause);
        pausePanel.SetActive(false);
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        pauseButton.gameObject.SetActive(!isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
