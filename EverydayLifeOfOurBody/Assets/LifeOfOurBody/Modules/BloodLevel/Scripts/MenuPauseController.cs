using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPauseController : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Button mainMenuButton;

    private bool isPaused = false;
    private bool isGameOver = false;

    public enum MenuStatus
    {
        Pause = 1,
        Win = 2,
        Lose = 3
    }

    private void Start()
    {
        menuUI.SetActive(false);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            OpenMenu(MenuStatus.Pause);
        }
    }

    public void OpenMenu(MenuStatus status)
    {
        switch (status)
        {
            case MenuStatus.Pause:
                if (!isGameOver)
                {
                    statusText.text = "Pause";
                    TogglePauseMenu();
                }
                break;
            case MenuStatus.Win:
                isGameOver = true;
                statusText.text = "You so good";
                ShowMenu();
                break;
            case MenuStatus.Lose:
                isGameOver = true;
                statusText.text = "Bruh, go next";
                ShowMenu();
                break;
        }
    }

    private void TogglePauseMenu()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            ShowMenu();
            Time.timeScale = 0f;
        }
        else
        {
            HideMenu();
            Time.timeScale = 1f;
        }
    }

    private void ShowMenu()
    {
        menuUI.SetActive(true);
    }

    private void HideMenu()
    {
        menuUI.SetActive(false);
    }

    private void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
}
