using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource soundFXObject;

   

    public void PlaySoundEffect(){
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

}
