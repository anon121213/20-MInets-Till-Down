using UnityEngine;
using Zenject;

public class GamePlayerSceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject _player;
    
    public override void InstallBindings()
    {
        Container.Bind<GameObject>().FromInstance(_player).AsSingle();
    }
}
