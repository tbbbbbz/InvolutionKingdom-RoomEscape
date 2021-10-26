using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{
    public EventSound3D eventSound3DPrefab;

    public AudioClip victoryAudio;

    private UnityAction<Vector3> victoryEventListener;

    void Awake()
    {
        victoryEventListener = new UnityAction<Vector3>(victoryEventHandler);
    }

    void OnEnable()
    {
        EventManager.StartListening<VictoryEvent, Vector3>(victoryEventListener);
    }

    void OnDisable()
    {
        EventManager.StopListening<VictoryEvent, Vector3>(victoryEventListener);
    }

    void victoryEventHandler(Vector3 worldPos)
    {
        if (eventSound3DPrefab != null)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

            snd.audioSrc.clip = this.victoryAudio;

            snd.audioSrc.minDistance = 10f;
            snd.audioSrc.maxDistance = 500f;

            snd.audioSrc.Play();
        }
    }
}
