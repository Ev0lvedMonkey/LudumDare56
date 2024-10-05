using UnityEngine;
using UnityEngine.UI;

public class QECanvasAnimAndHandler : MonoBehaviour
{
    [SerializeField] private Image button1;
    [SerializeField] private Image button2;
    [SerializeField] private float minScale = 0.8f;
    [SerializeField] private float maxScale = 1.2f;
    [SerializeField] private float pulseSpeed = 1f;

    private bool scalingUp1 = true;
    private bool scalingUp2 = false;

    private IsStoppingObject _stoppingObject;

    void Start()
    {
        button1.rectTransform.localScale = new Vector3(maxScale, maxScale, 1f);
        button2.rectTransform.localScale = new Vector3(minScale, minScale, 1f);
    }

    void Update()
    {
        AnimateButton(button1, ref scalingUp1);

        AnimateButton(button2, ref scalingUp2);

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            ScaleDown();
    }

    public void CanvasOn()=>
        gameObject.SetActive(true);

    public void CanvasOff() =>
    gameObject.SetActive(false);


    public void SetStoppingObject(IsStoppingObject stoppingObject)
    {
        if (_stoppingObject != null)
            return;
        _stoppingObject = stoppingObject;
        Debug.Log("transit obj succsess");
    }

    private void AnimateButton(Image button, ref bool scalingUp)
    {
        float currentScale = button.rectTransform.localScale.x;

        if (scalingUp)
        {
            currentScale += pulseSpeed * Time.deltaTime;
            if (currentScale >= maxScale)
                scalingUp = false;
        }
        else
        {
            currentScale -= pulseSpeed * Time.deltaTime;
            if (currentScale <= minScale)
                scalingUp = true;
        }

        button.rectTransform.localScale = new Vector3(currentScale, currentScale, 1f);
    }

    private void ScaleDown()
    {
        if (_stoppingObject == null)
            return;

        Vector3 currentScale = _stoppingObject.transform.localScale;

        currentScale.x -= 0.1f;

        if (currentScale.x < 0.15f)
        {
            Destroy(_stoppingObject.gameObject);
            CanvasOff();
        }
        else
            _stoppingObject.transform.localScale = new Vector3(currentScale.x, currentScale.y, 1f);
    }
}
