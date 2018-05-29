using System.Timers;
using UnityEngine;

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

    private AudioSource _bgAudioSource;
    private AudioSource _normalAudioSource;

    public override void OnInit()
    {
        GameObject audioSourcesGo = new GameObject("AudioSource(GameObject)");
        _bgAudioSource = audioSourcesGo.AddComponent<AudioSource>();
        _normalAudioSource = audioSourcesGo.AddComponent<AudioSource>();

        PlaySound(_bgAudioSource, LoadSound(SoundBg_Moderate), true);
    }


    public void PlayBgSound(string soundName)
    {
        PlaySound(_bgAudioSource, LoadSound(soundName), true);
    }

    public void PlayNormalSound(string soundName)
    {
        PlaySound(_normalAudioSource, LoadSound(soundName), false, 1f);
    }

    private void PlaySound(AudioSource audioSource, AudioClip audioClip, bool loop = false, float volume = 0.1f)
    {
        audioSource.volume = volume;
        audioSource.clip = audioClip;
        audioSource.loop = loop;
        audioSource.Play();
    }


    private AudioClip LoadSound(string soundName)
    {
        return Resources.Load<AudioClip>(Path_Prefix + soundName);
    }
}