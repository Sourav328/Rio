using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource backGroundEffect;
    [SerializeField] private AudioSource sfxSource;
    [Header("Sound Clips")]
    [SerializeField] private List<SoundType> soundTypes;
    private Dictionary<Sound, AudioClip> soundDict;
    

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Build sound lookup dictionary
        soundDict = new Dictionary<Sound, AudioClip>();
        foreach (var sound in soundTypes)
        {
            if (!soundDict.ContainsKey(sound.soundType))
            {
                soundDict.Add(sound.soundType, sound.soundClip);
            }
        }
    }

    private void Start()
    {
        // Start background loop
        if (backGroundEffect != null && backGroundEffect.clip != null)
        {
            backGroundEffect.loop = true;
            backGroundEffect.Play();
        }
    }

    public void PlaySound(Sound sound)
    {
        if (soundDict.TryGetValue(sound, out AudioClip clip))
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Sound not found: " + sound);
        }
    }

    [System.Serializable]
    public class SoundType
    {
        public Sound soundType;
        public AudioClip soundClip;
    }
    public AudioClip GetClip(Sound sound)
    {
        if (soundDict.TryGetValue(sound, out AudioClip clip))
            return clip;

        Debug.LogWarning("Sound not found: " + sound);
        return null;
    }

}

public enum Sound
{
    ButtonClick,
    Jump,
    Walk,
    PickUP
    
}
