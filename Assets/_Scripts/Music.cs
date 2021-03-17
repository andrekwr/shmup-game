using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class Music : MonoBehaviour
 {
     private AudioSource _audioSource;
     void Start()
    {
         GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();  
        
    }
     private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         _audioSource = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
 }