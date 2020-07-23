using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSound : MonoBehaviour {

    public AudioClip reloadSoundStep1;
    public AudioClip reloadSoundStep2;
    public AudioClip reloadSoundStep3;
    public AudioSource audioS;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void ReloadSound1() {

        audioS.PlayOneShot(reloadSoundStep1);
    }

    void ReloadSound2()
    {

        audioS.PlayOneShot(reloadSoundStep2);
    }

    void ReloadSound3()
    {

        audioS.PlayOneShot(reloadSoundStep3);
    }

}
