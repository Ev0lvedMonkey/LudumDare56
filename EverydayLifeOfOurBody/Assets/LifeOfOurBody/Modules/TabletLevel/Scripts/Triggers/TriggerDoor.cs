using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public GameObject door;
    public PlayerMove playerMove;
    void Start()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerMove.enabled = true;
            StartCoroutine(WaitASec());
        }
    }

    private IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(1);
        door.SetActive(true);
    }
}
