using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    public void PlaySoundEffect(AudioClip audioClip,Transform transform, float volume){
        AudioSource audioSource = Instantiate(soundFXObject,transform.position,Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject,clipLength);
    }

}
