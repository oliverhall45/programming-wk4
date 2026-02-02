using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    private AudioSource audioSource;


    private void Awake()
    {
        instance = FindFirstObjectByType<AudioManager>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayOnShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
