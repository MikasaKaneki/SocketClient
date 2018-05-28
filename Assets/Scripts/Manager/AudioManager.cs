using System.Timers;

public class AudioManager : BaseManager
{
    public AudioManager(GameFacade facade) : base(facade)
    {
    }

    private const string Path_Prefix = "Sounds/";
    public const string Alert = "Alert";

    public const string SoundArrowSgoot = "ArrowShoot";
    public const string SoundBg_Fast = "BG(fast)";
    public const string SoundBg_Moderate = "Bg(moderate)";
    public const string SoundButtonClick = "ButtonClick";
    public const string SoundMiss = "Miss";
    public const string SoundShootPerson = "ShootPerson";
    public const string SoundTimer = "Timer";
}