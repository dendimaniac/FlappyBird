using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public Sound[] sounds;

    [Header("Volume")] [SerializeField] [Range(0.2f, 0.5f)]
    private float lowVolumeRange;

    [SerializeField] [Range(0.5f, 1f)] private float highVolumeRange;

    [Header("Pitch")] [SerializeField] [Range(0.2f, 0.5f)]
    private float lowPitchRange;

    [SerializeField] [Range(0.5f, 1f)] private float highPitchRange;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        GenerateSoundSource();

        PlayMusic("Music");
    }

    private void GenerateSoundSource()
    {
        foreach (var sound in sounds)
        {
            var newSound = new GameObject(sound.name);
            sound.source = newSound.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.playOnAwake = sound.playOnAwake;
            newSound.transform.parent = transform;
        }
    }

    private void PlayMusic(string soundName)
    {
        var sound = GetSound(soundName);

        sound?.source.Play();
    }

    public void PlaySound(string soundName)
    {
        var sound = GetSound(soundName);
        if (sound == null) return;

        sound.source.Stop();
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
        sound.source.volume *= GetRandomVolume();
        sound.source.pitch *= GetRandomPitch();
        sound.source.Play();
    }

    private Sound GetSound(string soundName)
    {
        foreach (var sound in sounds)
        {
            if (sound.name.Equals(soundName))
            {
                return sound;
            }
        }

        Debug.LogError($"Sound {soundName} not found");
        return null;
    }

    private float GetRandomVolume()
    {
        return Random.Range(lowVolumeRange, highVolumeRange);
    }

    private float GetRandomPitch()
    {
        return Random.Range(lowPitchRange, highPitchRange);
    }
}