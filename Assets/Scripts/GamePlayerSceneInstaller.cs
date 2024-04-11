using Zenject;

public class GamePlayerSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInput>().To<PCInput>().FromNew().AsSingle();
        
        /*if (DeviceCheck.DeviseChecker())
        {
            Container.Bind<IInput>().To<MobileInput>().FromNew().AsSingle();
        }
        else
        {
            Container.Bind<IInput>().To<PCInput>().FromNew().AsSingle();
        }*/
    }
}
