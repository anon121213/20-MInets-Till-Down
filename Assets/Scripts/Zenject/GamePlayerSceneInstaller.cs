using UnityEngine;
using Zenject;

public class GamePlayerSceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject _player;
    [SerializeField] private WinSystem _winSystem;
    
    public override void InstallBindings()
    {
        Container.Bind<GameObject>().FromInstance(_player).AsSingle().NonLazy();
        Container.Bind<WinSystem>().FromInstance(_winSystem).AsSingle().NonLazy();
    }
}
