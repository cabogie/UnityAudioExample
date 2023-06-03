# Unity Audio Example
I added comments to the scripts to explain some Unity stuff.

Should be able to get an idea of C# features too, it's pretty readable and self explanatory.

There are 4 scripts:
 - Wave
     - This is a component that creates an audio clip
 - DataSeedRandomFilter
     - example of an audio filter    
 - WaveMath
     - some simple math functions for generating audio
 - RRandom
     - my own simple pseudo random generating code (and some useful helpers)

# AudioListeners and AudioSources
I have the scene setup with the camera behind the objects. 

![image](https://github.com/cabogie/UnityAudioExample/assets/8726619/45d19ff2-7120-4699-a1c1-6b15774d1657)

The blue cube is like the "head" with ears, it contains the AudioListener component. This listens to AudioSources.

The red and green spheres both have AudioSources which play audio. I set the spacial blend on them to max so they play relative to where they are to the AudioListener (blue cube). You can adjust all these settings in script or in the editor (inspector) of the AudioSource.

I added the Wave script (component) to them which generates a sound based on the type you select.

# Filters
You can add filters to AudioListener or AudioSource objects. The DataSeedRandomFilter just makes ugly noise, but there are some built in unity filters too.

![image](https://github.com/cabogie/UnityAudioExample/assets/8726619/2f143e5f-9ef1-4270-b2b0-1fc1d6558aff)

# Generating Audio
You can procedurally generate audio either with a filter or with the method I did in the Wave script (creating a clip).
You can also just add a file for the audio clip to play .wav file or something.

