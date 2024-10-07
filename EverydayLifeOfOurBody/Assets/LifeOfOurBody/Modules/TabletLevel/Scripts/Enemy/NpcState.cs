using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class NpcState : MonoBehaviour
{
    [SerializeField]public static int LevelNpc = 0;
    public static float countMass = 0;
    
    void Start()
    {
        StateNpc(LevelNpc);
    }

    public void StateNpc(int level)
    {
        if(level == 0)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            countMass = 0.025f;
        }
        else if(level == 1)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            countMass = 0.025f;
        }
        else if(level == 2)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            countMass = 0.04f;
        }
        else if (level == 3)
        {
            transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
            countMass = 0.05f;
        }
        else if (level == 4)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            countMass = 0.07f;
        }
        else if (level == 5)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            countMass = 0.1f;
        }
    }
}
