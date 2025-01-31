using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("------------- Audio Source -------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("------------- Audio Clips -------------")]
    public AudioClip hover;
    public AudioClip click;
    public AudioClip Bounce;
    public AudioClip Score;
    public AudioClip GameOver;
    public AudioClip BGM;

    private static AudioManager instance;

    private void Start()
    {
        musicSource.clip = BGM;
        musicSource.Play();
    }



    public void PlaySfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
