using UnityEngine;

public class IsFood : MonoBehaviour
{
    private void Start()
    {
        float randomScaleX = Random.Range(0.19f, 1.23f);
        float randomScaleY = Random.Range(0.19f, 1.23f);
        transform.localScale = new Vector3(randomScaleX, randomScaleY, 1f);
    }
}
