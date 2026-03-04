using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // Agrupa en el inspector las fuentes de audio
    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    // Agrupa en el inspector los clips de sonido
    [Header("Clips")]
    public AudioClip munch1;
    public AudioClip munch2;
    public AudioClip powerPellet;
    public AudioClip death;
    public AudioClip gameMusic;

    // Variable que permite alternar entre los dos sonidos de "munch"
    private bool toggleMunch;

    void Awake()
    {
        // Evitar que existan varios AudioManager
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        PlayMusic();
    }

    public void PlayMunch()
    {
        // Alterna entre dos sonidos diferentes al recoger puntos
        if (toggleMunch)
            sfxSource.PlayOneShot(munch1);
        else
            sfxSource.PlayOneShot(munch2);

        // Cambia el valor para que el siguiente sonido sea el otro
        toggleMunch = !toggleMunch;
    }

    public void PlayPowerPellet()
    {
        sfxSource.PlayOneShot(powerPellet);
    }

    public void PlayDeath()
    {
        sfxSource.PlayOneShot(death);
    }

    void PlayMusic()
    {
        musicSource.clip = gameMusic;
        // Hace que la música se repita continuamente
        musicSource.loop = true;
        musicSource.Play();
    }
}
