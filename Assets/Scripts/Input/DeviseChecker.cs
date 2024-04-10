using YG;

public static class DeviceCheck
{
    public static bool DeviseChecker()
    {
        return YandexGame.EnvironmentData.isMobile;
    }
}