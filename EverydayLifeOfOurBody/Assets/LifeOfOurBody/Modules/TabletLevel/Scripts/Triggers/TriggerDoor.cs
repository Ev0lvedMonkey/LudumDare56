using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject doorFinal;
    public PlayerMove playerMove;
    public GameObject particalEffect;
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (particalEffect != null)
            {
                particalEffect.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            particalEffect.SetActive(false);
            StartCoroutine(WaitASec());
        }
    }

    private IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(1);
        playerMove.enabled = true;
        door.SetActive(true);
        doorFinal.SetActive(true);
    }
}
