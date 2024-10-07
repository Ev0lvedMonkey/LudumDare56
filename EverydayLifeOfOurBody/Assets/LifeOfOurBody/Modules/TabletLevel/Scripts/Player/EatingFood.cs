using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingFood : MonoBehaviour
{
    [SerializeField] private float _countMass;

    private void Start()
    {
        _countMass = 10.5f;
    }
    //Проигрыш игрока
    public void RemovePlayer()
    {
        Destroy(gameObject);
        Debug.Log("like a death");
    }

    public void ScaleUp(float countMass)
    {
        if(transform.localScale.x > 1.5f || transform.localScale.y > 1.5f)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 0);
            return;
        }
        transform.localScale = new Vector3(transform.localScale.x + countMass, transform.localScale.y + countMass, 0);
        _countMass += countMass;
    }

    public float GetCountMass()
    {
        return _countMass;
    }

}
