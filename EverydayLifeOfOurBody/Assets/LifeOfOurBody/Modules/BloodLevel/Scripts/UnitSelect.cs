using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _selectedSP;

    [SerializeField] private float _speed;
    private Vector3 _movePosition;

    private void OnValidate()
    {
        if (_selectedSP == null)
            _selectedSP = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        SetSelectedUnit(false);
    }

    private void Update()
    {
        Vector3 moveDir = (_movePosition - transform.position).normalized;
        moveDir.z = 0;
        if (Vector3.Distance(_movePosition, transform.position) < 0.5f)
        {
            moveDir = Vector3.zero;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _movePosition, _speed * Time.deltaTime);
        }
    }

    public void SetSelectedUnit(bool visibility) =>
        _selectedSP.enabled = visibility;

    public void MoveTo(Vector3 newMovePos)
    {
        _movePosition = newMovePos;
    }

}
