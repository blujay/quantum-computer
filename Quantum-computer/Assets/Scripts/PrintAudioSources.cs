using System;
using UnityEngine;
 
 public class PrintAudioSources : MonoBehaviour
 {
 
 	AudioSource[] sources;
             
             void Start () {
             	Debug.Log("Logging all audio sources in the scene:");
                //Get every single audio sources in the scene.
		
                sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		Debug.Log("Number of audio sources:");
		Debug.Log(sources.Length);
		foreach(AudioSource audioSource in sources)
		{
			//Debug.Log("source: " + audioSource.name + "  parent: " + audioSource.transform.parent.name + "  root: " + audioSource.transform.root.name);
			if (audioSource.outputAudioMixerGroup != null) {
				Debug.Log("output: " + audioSource.outputAudioMixerGroup.name);
			} else {
				Debug.Log("No set output");
			}
		}
                 
             }
         
   
 }