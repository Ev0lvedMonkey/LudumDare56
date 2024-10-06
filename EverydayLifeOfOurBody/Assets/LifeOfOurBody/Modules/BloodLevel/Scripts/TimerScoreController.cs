using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private OpenCloseTransit _openCloseCanvas;
    [SerializeField] private MenuPauseController _menuPauseController;
    [SerializeField] private int MaxScore = 100;
    [SerializeField] private float gameDuration = 60f;

    private float _timer;
    private int _score;
    private bool _gameOver;

    private void Start()
    {
        _timer = gameDuration;
        _score = 0;
        _gameOver = false;     
        UpdateScoreText();
    }

    private void Update()
    {
        if (!_gameOver)  
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                _timer = 0;
                EndGame(false);  
            }
        }
    }

    public void GetNewBlood()
    {
        if (_score < MaxScore && !_gameOver)
        {
            _score++;
            UpdateScoreText();

            if (_score >= MaxScore)
            {
                EndGame(true);  
            }
        }
    }

    private void UpdateTimerText()
    {
        int secondsRemaining = Mathf.CeilToInt(_timer);
        _timerText.text = $"{secondsRemaining} sec";
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"{_score}/{MaxScore} oxygen";
    }

    private void EndGame(bool isWin)
    {
        _gameOver = true;  

        if (isWin)
        {
            Debug.Log("You win! Maximum oxygen collected.");
            _openCloseCanvas.StartTransition(false);
            _menuPauseController.OpenMenu(MenuPauseController.MenuStatus.Win);

        }
        else
        {
            Debug.Log("Game over! Time ran out.");
            _openCloseCanvas.StartTransition(false);
            _openCloseCanvas.CheckActiveImage(false);
            _openCloseCanvas.UpdateImagesState();
            _menuPauseController.OpenMenu(MenuPauseController.MenuStatus.Lose);
        }
    }
}
