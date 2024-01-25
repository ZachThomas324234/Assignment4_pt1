using UnityEngine;

public class UIAudio : MonoBehaviour
   {
       static AudioSource audioSource;
       public void Play(AudioClip audioClip)
       {
           audioSource.PlayOneShot(audioClip);
       }
       void Awake()
       {
   if (!audioSource)
           {
               var go = new GameObject("UI Audio");
               audioSource = go.AddComponent<AudioSource>();
               DontDestroyOnLoad(go);
           }
       }
   }
