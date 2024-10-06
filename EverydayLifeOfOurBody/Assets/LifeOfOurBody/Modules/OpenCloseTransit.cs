using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class OpenCloseTransit : MonoBehaviour
{
    [SerializeField] private Image transitionImage;
    [SerializeField] private TransitionType transitionType;

    public enum TransitionType
    {
        BloodLevelScene,
        MackScene,
        MainScene,
        TabletLvlScene
    }

    public void StartTransition(bool isOpening)
    {
        if (isOpening)
        {
            StartCoroutine(OpenTransition());
        }
        else
        {
            StartCoroutine(CloseTransition());
        }
    }

    private IEnumerator OpenTransition()
    {
        float fillAmount = 0;
        while (fillAmount < 1)
        {
            fillAmount += Time.deltaTime; // Увеличиваем заполнение
            transitionImage.fillAmount = fillAmount;
            yield return null;
        }
    }

    private IEnumerator CloseTransition()
    {
        float fillAmount = 1;
        while (fillAmount > 0)
        {
            fillAmount -= Time.deltaTime; // Уменьшаем заполнение
            transitionImage.fillAmount = fillAmount;
            yield return null;
        }

        LoadSelectedScene();
    }

    private void LoadSelectedScene()
    {
        SceneManager.LoadScene(transitionType.ToString());
    }
}

