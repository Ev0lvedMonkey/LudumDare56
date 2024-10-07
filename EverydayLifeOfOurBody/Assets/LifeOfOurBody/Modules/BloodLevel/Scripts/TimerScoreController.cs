using TMPro;
using UnityEngine;

public class TimerScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private OpenCloseTransit _openCloseCanvas;
    [SerializeField] private MenuPauseController _menuPauseController;
    [SerializeField] private int MaxScore = 100;
    [SerializeField] private float gameDuration = 60f;
    [SerializeField] private bool isEnemyMode = false;
    [SerializeField] private int totalEnemies = 3;

    private float _timer;
    private int _score;
    private int _remainingEnemies;
    private bool _gameOver;

    private void Start()
    {
        _score = 0;
        _remainingEnemies = totalEnemies;
        _gameOver = false;
        _timer = 1000;
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

    public void StartTimer()
    {
        _timer = gameDuration;
        UpdateTimerText();
    }

    public void GetNewBlood()
    {
        if (!isEnemyMode)
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
    }

    public void RemoveEnemy()
    {
        if (isEnemyMode && !_gameOver)
        {
            _remainingEnemies--;

            UpdateScoreText();

            if (_remainingEnemies <= 0)
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
        if (!isEnemyMode)
        {
            _scoreText.text = $"{_score}/{MaxScore} oxygen";
        }
        else
        {
            _scoreText.text = $"Enemies left: {_remainingEnemies}";
        }
    }

    private void EndGame(bool isWin)
    {
        _gameOver = true;

        if (isWin)
        {
            Debug.Log("You win!");
            _openCloseCanvas.StartTransition(false);
            _menuPauseController.OpenMenu(MenuPauseController.MenuStatus.Win);
        }
        else
        {
            Debug.Log("Game over!");
            _openCloseCanvas.StartTransition(false);
            _menuPauseController.OpenMenu(MenuPauseController.MenuStatus.Lose);
        }
    }
}
