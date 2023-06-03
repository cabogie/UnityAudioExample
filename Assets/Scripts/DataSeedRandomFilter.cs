using UnityEngine;

// OnAudioFilterRead only works on game objects that have an audio source or listener, so force that in the editor.
[RequireComponent(typeof(AudioBehaviour))]
public class DataSeedRandomFilter : MonoBehaviour {

    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnAudioFilterRead.html 

    // This is used as a filter modifying the audio that's playing. 
    // It's run in the order that it is stacked in the inspector (editor).
    // This can also be used to procedurally generate audio (if there is no clip attached to the audio source, it's treated as the source).
    private void OnAudioFilterRead(float[] data, int channels) {
        int count = 0;
        while (count < data.Length) {
            // Idk lol, just modifying the data by seeding it with itself...
            data[count] = RRandom.Range((long)(data[count] * 100), -1, 1);
            count++;
        }
    }

    private void Update() {
        // this is run every frame, so maybe you can use it for filter calculations, idk... 
    }

    // Run after all updates are called
    // private void LateUpdate() {}
    
    // Run at a fixed interval
    // private void FixedUpdate() {}
}
