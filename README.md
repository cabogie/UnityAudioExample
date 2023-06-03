# Unity Audio Example
I added lots of comments to the scripts to explain stuff.

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

![image](https://github.com/cabogie/UnityAudioExample/assets/8726619/3c81d60c-51ca-489a-a009-5d54483bd452)

The blue cube is like the "head" with ears, it contains the AudioListener component. This listens to AudioSources.

The red and green spheres both have AudioSources which play audio. I set the spacial blend on them to max so they play relative to where they are to the AudioListener (blue cube). 
NOTE: You can adjust all these settings in script or in the editor (inspector) of the AudioSource.

I added the Wave script (component) to them which generates a sound based on the type you select. In the left speaker (red) you should hear a sin wave, and in the right speaker (green) you should hear some noise.

WARNING: you might want to turn your speakers down cuz idk how loud it'll be......

# Filters
You can add filters to AudioListener or AudioSource objects. The DataSeedRandomFilter just makes ugly noise, but there are some built in unity filters too.

![image](https://github.com/cabogie/UnityAudioExample/assets/8726619/2f143e5f-9ef1-4270-b2b0-1fc1d6558aff)

# Audio Clips
You can procedurally generate audio either with a filter script (implement the built in function OnAudioFilterRead - "If OnAudioFilterRead is implemented, Unity will insert a custom filter into the audio DSP chain") 
or 
using the method I did in the Wave script by creating an AudioClip using the reader and position callbacks.

I know almost nothing about audio stuff so I'm sure you'll be more at home with all the frequencies, rates, positions, etc.  

You can also just add a file for the audio clip to play .wav file or something.

# Unity Basics
Create GameObjects in the scene and attach components (scripts) to them.

# Rendering
Unity has multiple render pipelines, and I setup the project using URP (Universal Render Pipeline). 

In project settings you tell Unity what pipeline you're using with a pipeline asset. This asset is a bunch of settings for rendering, along with linking the renderers themselves.
So unity reads pipeline asset which tells it things about how lighting should work and which renderers to use. This is all very customizable and a little complicated, but you don't need to worry about it here.

