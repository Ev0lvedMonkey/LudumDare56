using UnityEngine;
using UnityEngine.SceneManagement;
using static OpenCloseTransit;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] private TransitionType transitionType;
    public void LoadSelectedScene()
    {
        SceneManager.LoadScene(transitionType.ToString());
    }
}
