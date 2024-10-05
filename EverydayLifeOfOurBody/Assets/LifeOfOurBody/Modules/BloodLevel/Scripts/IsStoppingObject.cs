using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsStoppingObject : MonoBehaviour
{
    public enum StoppingObjectType { 
        Tromb,
        �holesterol,
        Valve
    }

    [SerializeField] private StoppingObjectType _type;

    public StoppingObjectType GetStoppingObjectType()
    {
        return _type;
    }
}
