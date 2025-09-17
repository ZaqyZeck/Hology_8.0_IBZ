using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public float musicVolume, sfxVolume;
    public AudioSource musicSource, sfxSource;

    [Header("Music Audio Source")]
    public AudioClip ambience;
    public AudioClip Music1;
    public AudioClip Music2;
    public AudioClip MusicMainMenu;

    [Header("SFX Audio Source")]
    public AudioClip placeGenerator;
    public AudioClip uiClicked;
    public AudioClip upgrade;
    public AudioClip cutPlant;
    public AudioClip placeplant;
    public AudioClip harvestPlant;



    private AudioClip[] musicPlaylist;
    private int currentTrack = 0;

    [Header("Slider UI setiap Scene")]
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    void Start()
    {
        // Load volume dari PlayerPrefs
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 1f);

        if (musicVolumeSlider != null) musicVolumeSlider.value = musicVolume;
        if (sfxVolumeSlider != null) sfxVolumeSlider.value = sfxVolume;

        if (Music1 != null && Music2 != null)
        {
            musicPlaylist = new AudioClip[] { Music1, Music2 };
            currentTrack = Random.Range(0, musicPlaylist.Length);
            PlayNextMusic();
        }
    }

    void Update()
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            PlayNextMusic();
        }
    }

    private void PlayNextMusic()
    {
        if (musicPlaylist == null || musicPlaylist.Length == 0) return;

        musicSource.clip = musicPlaylist[currentTrack];
        musicSource.volume = musicVolume;
        musicSource.loop = false; // biar bisa ganti track
        musicSource.Play();

        currentTrack = (currentTrack + 1) % musicPlaylist.Length;
    }

    public void PlaySFX(AudioClip SFX)
    {
        if (sfxSource != null && SFX != null)
            sfxSource.PlayOneShot(SFX, sfxVolume);
    }

    public void PlayUiClicked()
    {
        PlaySFX(uiClicked);
    }

    public void ChangeMusicVolume()
    {
        if (musicVolumeSlider == null) return;
        musicVolume = musicVolumeSlider.value;
        if (musicSource != null) musicSource.volume = musicVolume;

        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void ChangeSFXVolume()
    {
        if (sfxVolumeSlider == null) return;
        sfxVolume = sfxVolumeSlider.value;

        if (sfxSource != null) sfxSource.volume = sfxVolume;

        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.Save();
    }
}
