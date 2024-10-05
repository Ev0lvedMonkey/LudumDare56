using UnityEngine;

public class DestroyMySelf : MonoBehaviour
{
    [SerializeField, Range(0.1f, 5f)] private float _destroyTime;
    private void OnEnable()
    {
        Destroy(gameObject, _destroyTime);
    }
}
