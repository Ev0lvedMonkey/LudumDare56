using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class OpenCloseTransit : MonoBehaviour
{
    [SerializeField] private Image transitionImage;
    [SerializeField] private Image customTransitionImage;
    [SerializeField] private TransitionType transitionType;
    [SerializeField] private UnityEvent _openEvent;
    [SerializeField] private UnityEvent _closeEvent;
    [SerializeField] private bool immediateTransition;
    [SerializeField] private bool _useCustomImage;

    private Image activeImage;
    private bool isFirstPress = true;

    public enum TransitionType
    {
        BloodLevelScene,
        MackScene,
        MainScene,
        TabletLvlScene
    }

    private void Awake()
    {
        CheckActiveImage(_useCustomImage);
        //UpdateImagesState(false);        
    }

    private void Start()
    {
        if (immediateTransition)
        {
            StartTransition(true);
        }
    }

    public void CheckActiveImage(bool useCustomImage)
    {
        _useCustomImage = useCustomImage;
        activeImage = useCustomImage ? customTransitionImage : transitionImage;
    }

    public void UpdateImagesState()
    {
        transitionImage.gameObject.SetActive(!_useCustomImage);
        customTransitionImage.gameObject.SetActive(_useCustomImage);
    }
    public void UpdateImagesState(bool acitveImage)
    {
        transitionImage.gameObject.SetActive(acitveImage);
        customTransitionImage.gameObject.SetActive(acitveImage);
    }

    private void Update()
    {
        if (!immediateTransition && Input.anyKeyDown && isFirstPress)
        {
            StartTransition(true);
            isFirstPress = false;
        }
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
        UpdateImagesState();
        float fillAmount = 1;
        while (fillAmount > 0)
        {
            fillAmount -= Time.deltaTime;
            activeImage.fillAmount = fillAmount;
            yield return null;
        }
        _openEvent?.Invoke();
    }

    private IEnumerator CloseTransition()
    {
        float fillAmount = 0;
        while (fillAmount < 1)
        {
            fillAmount += Time.deltaTime;
            activeImage.fillAmount = fillAmount;
            yield return null;
        }
        _closeEvent?.Invoke();
    }

    private void LoadSelectedScene()
    {
        SceneManager.LoadScene(transitionType.ToString());
    }
}
