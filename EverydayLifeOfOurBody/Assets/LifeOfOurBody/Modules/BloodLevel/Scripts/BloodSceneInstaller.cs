using UnityEngine;
using Zenject;

public class BloodSceneInstaller : MonoInstaller
{
    [SerializeField] private QECanvasAnimAndHandler _animAndHandler;
    public override void InstallBindings()
    {
        Container.Bind<QECanvasAnimAndHandler>().FromInstance(_animAndHandler);
    }
}
