using UnityEngine;

public class ValveRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 90f;
    [SerializeField] private float _cycleDuration = 6f;
    [SerializeField] private bool _isBottom;

    private int _direction;
    private float _initialRotationZ;  

    private void Awake()
    {
        _direction = _isBottom ? -1 : 1;
        _initialRotationZ = transform.rotation.eulerAngles.z; 
    }

    private void Update()
    {
        float timeInCycle = (Time.time % _cycleDuration) / _cycleDuration;

        float angle = Mathf.Sin(timeInCycle * 2 * Mathf.PI) * _rotationSpeed * _direction;

        transform.rotation = Quaternion.Euler(0, 0, _initialRotationZ + angle);
    }
}
