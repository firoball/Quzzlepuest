﻿using UnityEngine;
using System.Collections.Generic;

namespace Game.Ambient
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {

        private static AudioManager s_singleton;

        [SerializeField]
        private List<NamedAudioClip> m_audioList;

        private AudioSource m_audioSource;

        void Start()
        {
            if (s_singleton == null)
            {
                s_singleton = this;
                m_audioSource = GetComponent<AudioSource>();
            }
            else
            {
                Debug.Log("AudioManager: Multiple instances detected. Destroying...");
                Destroy(this);
            }

        }

        public static void Play(string identifier)
        {
            if (s_singleton != null)
            {
                AudioClip clip;
                if (s_singleton.Find(identifier, out clip))
                {
                    s_singleton.m_audioSource.PlayOneShot(clip);
                }
                else
                {
                    Debug.LogWarning("AudioManager: clip not configured: " + identifier);
                }
            }
            else
            {
                Debug.LogWarning("AudioManager: no instance in scene");
            }
        }

        private bool Find(string identifier, out AudioClip clip)
        {
            bool found = false;
            clip = null;
            foreach (NamedAudioClip namedClip in m_audioList)
            {
                if (namedClip.Identifier == identifier)
                {
                    clip = namedClip.Clip;
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}