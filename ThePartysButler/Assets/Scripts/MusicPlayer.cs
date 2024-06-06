using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicPlayer : MonoBehaviour
{
    private AudioSource musicSource;
    [SerializeField] private KeyValuePairObject<AudioClip, KeyValuePairObject<bool,int>>[] musicQueue;
    [SerializeField] private bool loopQueue;
    private int queueCounter = 0;
    [SerializeField] private int individualLoopCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (musicSource.isPlaying || queueCounter >= musicQueue.Length) { return; }

        musicSource.clip = musicQueue[queueCounter++].Key;
        musicSource.Play();

        if (musicQueue[queueCounter - 1].Value.Key
            && musicQueue[queueCounter - 1].Value.Value > individualLoopCount++)
        {
            queueCounter--;
        }
        else { individualLoopCount = 0; }

        if (loopQueue) { queueCounter %= musicQueue.Length; }
    }
}
