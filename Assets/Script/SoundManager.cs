using UnityEngine;

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
    void Start()
    {
        if (Music1 != null)
        {
            // isi playlist musik
            musicPlaylist = new AudioClip[] { Music1, Music2 };

            // mulai dari lagu random
            currentTrack = Random.Range(0, musicPlaylist.Length);
            PlayNextMusic();
        }
        //else
        //{
            
        //}
    }

    void Update()
    {
        // cek apakah musik sudah selesai, kalau selesai ganti ke track berikutnya
        if (!musicSource.isPlaying)
        {
            PlayNextMusic();
        }
    }

    private void PlayNextMusic()
    {
        // set clip & play
        musicSource.clip = musicPlaylist[currentTrack];
        musicSource.volume = musicVolume;
        musicSource.Play();

        // geser ke lagu berikutnya (looping)
        currentTrack = (currentTrack + 1) % musicPlaylist.Length;
    }

    public void PlaySFX(AudioClip SFX)
    {
        //SFX.volume = sfxVolume;
        sfxSource.PlayOneShot(SFX, sfxVolume);
    }

    public void PlayUiClicked()
    {
        sfxSource.PlayOneShot(uiClicked, sfxVolume);
    }
}
