using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Miss Audio")]
    [SerializeField] AudioClip missClip;
    [SerializeField][Range(0f, 1f)] float missVolume;
    [Header("Hit Audio")]
    [SerializeField] AudioClip hitClip;
    [SerializeField][Range(0f, 1f)] float hitVolume;

    public void PlayHitClip()
    {
        PlayClip(hitClip, hitVolume);
    }
    public void PlayMissClip()
    {
        PlayClip(missClip, missVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector2 soundPos= transform.position;
            AudioSource.PlayClipAtPoint(clip,soundPos,volume);
        }
    }
}
