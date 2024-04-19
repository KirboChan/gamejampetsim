using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] randomAudioClips;
    public static AudioManager instance;
    float minTime;
    float maxTime;
    float timeToWait;
    IEnumerator PlayRandomSound()
    {
        audioSource.clip = randomAudioClips[Random.Range(0, randomAudioClips.Length)];
        audioSource.Play();
        timeToWait = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeToWait);
        StartCoroutine(PlayRandomSound());
    }

    public void PlaySFX(AudioSource audiosource, AudioClip[] sfxArray, int index)
    {
        audioSource.clip = sfxArray[index];
        audioSource.Play();
    }
    public void Start()
    {

    }
}
