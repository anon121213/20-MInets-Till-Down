using Zenject;

public class GamePlayerSceneInstaller : MonoInstaller
{
    public PCInput pcInput;
    
    public override void InstallBindings()
    {
        if (DeviceCheck.DeviseChecker())
        {
            Container.Bind<IInput>().To<MobileInput>().FromNew().AsSingle();
        }
        else
        {
            Container.Bind<IInput>().FromInstance(pcInput).AsSingle();
        }

        Container.Bind<CharacterMove>().FromNew().AsSingle().NonLazy();
    }
}
