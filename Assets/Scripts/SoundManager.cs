using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SoundManager : MonoBehaviour
{
    [SerializeField] StudioEventEmitter buttonSound;
    [SerializeField] StudioEventEmitter photoSound;

    public void OnButtonClick()
    {
        buttonSound.Play();
    }

    public void OnPhotoButtonClick()
    {
        photoSound.Play();
    }
}
