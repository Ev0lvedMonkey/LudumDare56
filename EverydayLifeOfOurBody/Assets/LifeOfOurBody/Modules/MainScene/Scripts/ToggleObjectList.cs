using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToggleObjectList : MonoBehaviour
{
    [SerializeField] private Button toggleButton; 
    [SerializeField] private List<GameObject> objectsToToggle; 

    private bool isActive;

    private void Start()
    {
        toggleButton.onClick.AddListener(ToggleObjects);
        ToggleObjects();
    }

    private void ToggleObjects()
    {
        isActive = !isActive;
        foreach (var obj in objectsToToggle)
        {
            obj.SetActive(isActive);
        }
    }
}
