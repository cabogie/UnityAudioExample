using UnityEngine;

// Tells unity editor that in order to create this component, we need an audiosource component attached to it.
[RequireComponent(typeof(AudioSource))]
public class Wave : MonoBehaviour {

    public enum Type {
        Sin, Cos, Tan, Saw, Triangle, Noise
    }

    public int position = 0;

    // SerializeField serializes and shows properties in the inspector. Public fields also show up in the inspector (unity editor)
    [SerializeField]
    private float _sampleRate = 44.1f; // in kHz

    // Convert rate to Hz
    private int sampleRateHz { get => (int) ((_sampleRate) * 1000); }
    
    // This is the pattern I use for public interfacing code that will need running code on change set / get properties
    [SerializeField]
    private float _frequency = 440;
    public float frequency {
        get => _frequency;
        set {
            _frequency = value;
            CreateClip();
        }
    }

    [SerializeField]
    private Type _type = Type.Sin;
    public Type type {
        get => _type;
        set {
            _type = value;
            CreateClip();
        }
    }

    // https://docs.unity3d.com/ScriptReference/AudioClip.Create.html

    private void CreateClip() {
        AudioSource audioSrc = GetComponent<AudioSource>();
        AudioClip clip = AudioClip.Create("Wave", sampleRateHz, 1, sampleRateHz, true, OnAudioRead, OnAudioSetPosition);
        audioSrc.clip = clip;
        audioSrc.Play();

        // Could also grab the component like this (safer but will fail silently - useful if you wanna do things with an optional component or something)
        if(GetComponent<AudioSource>() is AudioSource audioSource) {}
    }

    // When the game object is done being create and started running
    // private void Start() {}
    
    // Run every frame
    // private void Update() {}

    // Run after all updates are called
    // private void LateUpdate() {}
    
    // Run at a fixed interval
    // private void FixedUpdate() {}

    // When this component is first created 
    void Awake() {
        CreateClip();
    }

    // Called in editor only, any time some data changes or when run is pressed and stuff
    private void OnValidate() {            
        // Reset the audio clip if we play with the values in the editor (only while the game is running)
        if(Application.isPlaying) CreateClip();
    }

    // Read the audio clip into data (set during clip creation).
    // You can also omit this function and use clip.SetData(dataArray), or you can load actual audio files as clips, but this is a procedural example
    void OnAudioRead(float[] data) {
        int count = 0;
        while (count < data.Length) {
            var p = (frequency * position / sampleRateHz);

            var value = 0.0f;
            switch(this.type) {
                case Type.Sin: value = WaveMath.Sin(p); break;
                case Type.Cos: value = WaveMath.Cos(p); break;
                case Type.Tan: value = WaveMath.Tan(p); break;
                case Type.Saw: value = WaveMath.Saw(p); break;
                case Type.Triangle: value = WaveMath.Triangle(p); break;
                case Type.Noise: value = WaveMath.TimeNoise(p); break;
            }

            data[count] = value;

            position++; 
            count++;
        }
    }

    // Read the audio position (set during clip creation)
    void OnAudioSetPosition(int newPosition) {
        position = newPosition;
    }

}
