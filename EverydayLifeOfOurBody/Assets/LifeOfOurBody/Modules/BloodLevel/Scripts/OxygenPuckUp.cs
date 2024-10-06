using UnityEngine;
using Zenject;

public class OxygenPuckUp : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _oxygenSP;
    [SerializeField] private UnitSelect _unit;

    [Inject] 
    private QECanvasAnimAndHandler _qeCanvas;
    [SerializeField] private bool _isOxygen;

    private void OnValidate()
    {
        if (_oxygenSP == null)
            _oxygenSP = transform.GetComponent<SpriteRenderer>();
        if (_unit == null)
            _unit = transform.GetComponent<UnitSelect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IsOxygen oxygen))
        {
            if (_isOxygen)
                return;
            Debug.Log($"Cool {oxygen.name}");


            Destroy(oxygen.gameObject);
            _oxygenSP.enabled = true;
            _isOxygen = true;
            return;
        }
        if (collision.TryGetComponent(out OxygenReceiver oxygenReciver))
        {
            if (_isOxygen == false)
                return;
            Debug.Log($"Awesome {oxygenReciver.name}");
            _unit.MoveTo(oxygenReciver.GetEscapePoint());
            oxygenReciver.GetComponent<TimerScoreController>().GetNewBlood();
            _unit.DestroyObj();
            return;
        }
        if (collision.TryGetComponent(out IsStoppingObject stoppingObject))
        {
            _unit.MoveTo(_unit.transform.position);

            switch (stoppingObject.GetStoppingObjectType())
            {
                case IsStoppingObject.StoppingObjectType.Tromb:
                    _qeCanvas.CanvasOn();
                    _qeCanvas.SetStoppingObject(stoppingObject);
                    break;
                default:
                    break;
            }

            return;
        }
    }
}
