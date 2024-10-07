using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class IsFood : MonoBehaviour
{
    public enum FoodStates
    {
        SimpleFood,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
    }


    [SerializeField] public Transform _parentTransfom;
    [SerializeField] public FoodStates foodLevel;
    private float _countMass = 0;

    private void OnValidate()
    {
        if (_parentTransfom == null)
            _parentTransfom = transform.parent.transform;
    }

    private void Start()
    {
        StateNpc();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EatingFood player))
        {
            if (_countMass > player.GetCountMass())
            {
                player.RemovePlayer();
                Debug.Log($"{player.name} removed");
            }
            else
            {
                player.ScaleUp(_countMass);
                Destroy(_parentTransfom.gameObject);
                Debug.Log($"{_parentTransfom.gameObject.name} removed");
            }

        }
    }


    public void StateNpc()
    {
        switch (foodLevel)
        {
            case FoodStates.SimpleFood:
                _parentTransfom.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                _countMass = 0.025f;
                break;
            case FoodStates.Level1:
                _parentTransfom.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                _countMass = 0.025f;
                break;
            case FoodStates.Level2:
                _parentTransfom.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                _countMass = 0.04f;
                break;
            case FoodStates.Level3:
                _parentTransfom.localScale = new Vector3(0.55f, 0.55f, 0.55f);
                _countMass = 0.05f;
                break;
            case FoodStates.Level4:
                _parentTransfom.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                _countMass = 0.07f;
                break;
            case FoodStates.Level5:
                _parentTransfom.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                _countMass = 0.1f;
                break;
            default:
                break;

        }
    }
}
