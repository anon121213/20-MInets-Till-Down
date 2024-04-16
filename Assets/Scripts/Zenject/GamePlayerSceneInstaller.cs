using UnityEngine;
using Zenject;

public class GamePlayerSceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject _player;
    [SerializeField] private HealthBar _healthBar;
    
    public override void InstallBindings()
    {
        Container.Bind<GameObject>().FromInstance(_player).AsSingle();
        Container.Bind<HealthBar>().FromInstance(_healthBar).AsSingle();
    }
}
