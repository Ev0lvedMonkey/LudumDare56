using System.Collections.Generic;
using UnityEngine;

public class SelectUnits : MonoBehaviour
{
    [SerializeField] private Transform _selectionArea;

    private Vector3 _startPoint;
    private List<UnitSelect> _selectedUnits;

    private void Awake()
    {
        _selectedUnits = new List<UnitSelect>();
        HideSelectionArea();
    }

    private void Update()
    {
        SelectNewUnits();
        UnitsMoveTo();
    }

    private void UnitsMoveTo()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(Resources.Load("Prefabs/EmptyCircle"), GetMousePos(), Quaternion.identity);
            foreach (var unit in _selectedUnits)
            {
                if (_selectedUnits.Count <= 0)
                {
                    Debug.Log("Bad news");
                    return;
                }
                unit.MoveTo(GetMousePos());
            }

        }
    }

    private void SelectNewUnits()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _startPoint = GetMousePos();
            ShowSelectionArea();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 currentMousePos = GetMousePos();
            Vector3 lowerLeftCorner = new(
                Mathf.Min(_startPoint.x, currentMousePos.x),
                Mathf.Min(_startPoint.y, currentMousePos.y));
            Vector3 topRightCorner = new(
                Mathf.Max(_startPoint.x, currentMousePos.x),
                Mathf.Max(_startPoint.y, currentMousePos.y));

            _selectionArea.position = lowerLeftCorner;
            _selectionArea.localScale = topRightCorner - lowerLeftCorner;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            HideSelectionArea();
            Vector3 endPoint = GetMousePos();
            Collider2D[] collidersInArea = Physics2D.OverlapAreaAll(_startPoint, endPoint);
            foreach (var unit in _selectedUnits)
                unit.SetSelectedUnit(false);
            _selectedUnits?.Clear();

            foreach (var collider in collidersInArea)
            {
                UnitSelect unit;
                if (!collider.TryGetComponent(out UnitSelect selectedUnit))
                    continue;
                unit = selectedUnit;
                unit.SetSelectedUnit(true);
                _selectedUnits.Add(unit);
            }
        }
    }

    private Vector2 GetMousePos()
    {
        return 
            new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    private void HideSelectionArea() =>
        _selectionArea.gameObject.SetActive(false);

    private void ShowSelectionArea() =>
        _selectionArea.gameObject.SetActive(true);
}
