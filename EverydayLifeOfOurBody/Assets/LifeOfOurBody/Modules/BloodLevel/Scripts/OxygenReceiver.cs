using UnityEngine;

public class OxygenReceiver : MonoBehaviour
{
    [SerializeField] private Transform _escapePoint;

    public Vector3 GetEscapePoint()
    {
        return _escapePoint.position;
    }
}
