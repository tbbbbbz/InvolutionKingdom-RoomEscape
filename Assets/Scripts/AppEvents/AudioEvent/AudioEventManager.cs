using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{
    public EventSound3D eventSound3DPrefab;

    public AudioClip victoryAudio;
    public AudioClip openDoorAudio;
    public AudioClip openCabinetAudio;
    public AudioClip openBoxAudio;
    public AudioClip collideBasketAudio;
    public AudioClip collideBarrelAudio;
    public AudioClip collideBedAudio;
    public AudioClip collideDeskChairAudio;
    public AudioClip collideWallAudio;
    public AudioClip potCollidesGroundAudio;
    public AudioClip touchNotebookAudio;
    public AudioClip touchScrollAudio;
    public AudioClip touchCatAudio;
    public AudioClip touchZombieAudio;

    private UnityAction<Vector3> victoryEventListener;
    private UnityAction<Vector3> openDoorEventListener;
    private UnityAction<Vector3> openCabinetEventListener;
    private UnityAction<Vector3> openBoxEventListener;
    private UnityAction<Vector3, float> collideBasketEventListener;
    private UnityAction<Vector3, float> collideBarrelEventListener;
    private UnityAction<Vector3, float> collideBedEventListener;
    private UnityAction<Vector3, float> collideDeskChairEventListener;
    private UnityAction<Vector3, float> collideWallEventListener;
    private UnityAction<Vector3, float> potCollidesGroundEventListener;
    private UnityAction<GameObject> touchNotebookEventListener;
    private UnityAction<GameObject> touchScrollEventListener;
    private UnityAction<GameObject> touchCatEventListener;
    private UnityAction<GameObject> touchZombieEventListener;



    void Awake()
    {
        victoryEventListener = new UnityAction<Vector3>(victoryEventHandler);
        openDoorEventListener = new UnityAction<Vector3>(openDoorEventHandler);
        openCabinetEventListener = new UnityAction<Vector3>(openCabinetEventHandler);
        openBoxEventListener = new UnityAction<Vector3>(openBoxEventHandler);

        collideBasketEventListener = new UnityAction<Vector3, float>(collideBasketEventHandler);
        collideBarrelEventListener = new UnityAction<Vector3, float>(collideBarrelEventHandler);
        collideBedEventListener = new UnityAction<Vector3, float>(collideBedEventHandler);
        collideDeskChairEventListener = new UnityAction<Vector3, float>(collideDeskChairEventHandler);
        collideWallEventListener = new UnityAction<Vector3, float>(collideWallEventHandler);
        potCollidesGroundEventListener = new UnityAction<Vector3, float>(potCollidesGroundEventHandler);
        touchNotebookEventListener = new UnityAction<GameObject>(touchNotebookEventHandler);
        touchScrollEventListener = new UnityAction<GameObject>(touchScrollEventHandler);
        touchCatEventListener = new UnityAction<GameObject>(touchCatEventHandler);
        touchZombieEventListener = new UnityAction<GameObject>(touchZombieEventHandler);
    }

    void OnEnable()
    {
        EventManager.StartListening<VictoryEvent, Vector3>(victoryEventListener);
        EventManager.StartListening<OpenDoorEvent, Vector3>(openDoorEventListener);
        EventManager.StartListening<OpenCabinetEvent, Vector3>(openCabinetEventListener);
        EventManager.StartListening<OpenBoxEvent, Vector3>(openBoxEventListener);
        EventManager.StartListening<CollideBasketEvent, Vector3, float>(collideBasketEventListener);
        EventManager.StartListening<CollideBarrelEvent, Vector3, float>(collideBarrelEventListener);
        EventManager.StartListening<CollideBedEvent, Vector3, float>(collideBedEventListener);
        EventManager.StartListening<CollideDeskChairEvent, Vector3, float>(collideDeskChairEventListener);
        EventManager.StartListening<CollideWallEvent, Vector3, float>(collideWallEventListener);
        EventManager.StartListening<PotCollidesGroundEvent, Vector3, float>(potCollidesGroundEventListener);
        EventManager.StartListening<TouchNotebookEvent, GameObject>(touchNotebookEventListener);
        EventManager.StartListening<TouchScrollEvent, GameObject>(touchScrollEventListener);
        EventManager.StartListening<TouchCatEvent, GameObject>(touchCatEventListener);
        EventManager.StartListening<TouchZombieEvent, GameObject>(touchZombieEventListener);
    }

    void OnDisable()
    {
        EventManager.StopListening<VictoryEvent, Vector3>(victoryEventListener);
        EventManager.StopListening<OpenDoorEvent, Vector3>(openDoorEventListener);
        EventManager.StopListening<OpenCabinetEvent, Vector3>(openCabinetEventListener);
        EventManager.StopListening<OpenBoxEvent, Vector3>(openBoxEventListener);

        EventManager.StopListening<CollideBasketEvent, Vector3, float>(collideBasketEventListener);
        EventManager.StopListening<CollideBarrelEvent, Vector3, float>(collideBarrelEventListener);
        EventManager.StopListening<CollideBedEvent, Vector3, float>(collideBedEventListener);
        EventManager.StopListening<CollideDeskChairEvent, Vector3, float>(collideDeskChairEventListener);
        EventManager.StopListening<CollideWallEvent, Vector3, float>(collideWallEventListener);
        EventManager.StopListening<PotCollidesGroundEvent, Vector3, float>(potCollidesGroundEventListener);
        EventManager.StopListening<TouchNotebookEvent, GameObject>(touchNotebookEventListener);
        EventManager.StopListening<TouchScrollEvent, GameObject>(touchScrollEventListener);
        EventManager.StopListening<TouchCatEvent, GameObject>(touchCatEventListener);
        EventManager.StopListening<TouchZombieEvent, GameObject>(touchZombieEventListener);
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

    void openDoorEventHandler(Vector3 worldPos)
    {
        if (eventSound3DPrefab != null)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

            snd.audioSrc.clip = this.openDoorAudio;

            snd.audioSrc.minDistance = 10f;
            snd.audioSrc.maxDistance = 500f;

            snd.audioSrc.Play();
        }
    }

    void openCabinetEventHandler(Vector3 worldPos)
    {
        if (eventSound3DPrefab != null)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

            snd.audioSrc.clip = this.openCabinetAudio;

            snd.audioSrc.minDistance = 10f;
            snd.audioSrc.maxDistance = 500f;

            snd.audioSrc.Play();
        }
    }

    void openBoxEventHandler(Vector3 worldPos)
    {
        if (eventSound3DPrefab != null)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

            snd.audioSrc.clip = this.openBoxAudio;

            snd.audioSrc.minDistance = 10f;
            snd.audioSrc.maxDistance = 500f;

            snd.audioSrc.Play();
        }
    }

    void collideBasketEventHandler(Vector3 worldPos, float impactForce)
    {
        //AudioSource.PlayClipAtPoint(this.collideBasketAudio, worldPos);

        const float halfSpeedRange = 0.2f;

        EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

        snd.audioSrc.clip = this.collideBasketAudio;

        snd.audioSrc.pitch = Random.Range(1f - halfSpeedRange, 1f + halfSpeedRange);

        snd.audioSrc.minDistance = Mathf.Lerp(1f, 8f, impactForce / 200f);
        snd.audioSrc.maxDistance = 100f;

        snd.audioSrc.Play();
    }

    void collideBarrelEventHandler(Vector3 worldPos, float impactForce)
    {
        //AudioSource.PlayClipAtPoint(this.collideBarrelAudio, worldPos);

        const float halfSpeedRange = 0.2f;

        EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

        snd.audioSrc.clip = this.collideBarrelAudio;

        snd.audioSrc.pitch = Random.Range(1f - halfSpeedRange, 1f + halfSpeedRange);

        snd.audioSrc.minDistance = Mathf.Lerp(1f, 8f, impactForce / 200f);
        snd.audioSrc.maxDistance = 100f;

        snd.audioSrc.Play();
    }

    void collideBedEventHandler(Vector3 worldPos, float impactForce)
    {
        //AudioSource.PlayClipAtPoint(this.collideBedAudio, worldPos);

        const float halfSpeedRange = 0.2f;

        EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

        snd.audioSrc.clip = this.collideBedAudio;

        snd.audioSrc.pitch = Random.Range(1f - halfSpeedRange, 1f + halfSpeedRange);

        snd.audioSrc.minDistance = Mathf.Lerp(1f, 8f, impactForce / 200f);
        snd.audioSrc.maxDistance = 100f;

        snd.audioSrc.Play();
    }

    void collideDeskChairEventHandler(Vector3 worldPos, float impactForce)
    {
        //AudioSource.PlayClipAtPoint(this.collideDeskChairAudio, worldPos);

        const float halfSpeedRange = 0.2f;

        EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

        snd.audioSrc.clip = this.collideDeskChairAudio;

        snd.audioSrc.pitch = Random.Range(1f - halfSpeedRange, 1f + halfSpeedRange);

        snd.audioSrc.minDistance = Mathf.Lerp(1f, 8f, impactForce / 200f);
        snd.audioSrc.maxDistance = 100f;

        snd.audioSrc.Play();
    }

    void collideWallEventHandler(Vector3 worldPos, float impactForce)
    {
        //AudioSource.PlayClipAtPoint(this.collideWallAudio, worldPos);

        const float halfSpeedRange = 0.2f;

        EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

        snd.audioSrc.clip = this.collideWallAudio;

        snd.audioSrc.pitch = Random.Range(1f - halfSpeedRange, 1f + halfSpeedRange);

        snd.audioSrc.minDistance = Mathf.Lerp(1f, 8f, impactForce / 200f);
        snd.audioSrc.maxDistance = 100f;

        snd.audioSrc.Play();
    }

    void potCollidesGroundEventHandler(Vector3 worldPos, float collisionMagnitude)
    {
        //AudioSource.PlayClipAtPoint(this.potCollidesGroundAudio, worldPos, 1f);

        if (eventSound3DPrefab)
        {
            if (collisionMagnitude > 300f)
            {

                EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

                snd.audioSrc.clip = this.potCollidesGroundAudio;

                snd.audioSrc.minDistance = 5f;
                snd.audioSrc.maxDistance = 100f;

                snd.audioSrc.Play();

                if (collisionMagnitude > 500f)
                {

                    EventSound3D snd2 = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

                    snd2.audioSrc.clip = this.potCollidesGroundAudio;

                    snd2.audioSrc.minDistance = 5f;
                    snd2.audioSrc.maxDistance = 100f;

                    snd2.audioSrc.Play();
                }
            }


        }
    }

    void touchNotebookEventHandler(GameObject go)
    {
        //AudioSource.PlayClipAtPoint(this.touchNotebookAudio, worldPos, 1f);

        if (eventSound3DPrefab)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, go.transform);

            snd.audioSrc.clip = this.touchNotebookAudio;

            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;

            snd.audioSrc.Play();
        }
    }

    void touchScrollEventHandler(GameObject go)
    {
        //AudioSource.PlayClipAtPoint(this.touchScrollAudio, worldPos, 1f);

        if (eventSound3DPrefab)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, go.transform);

            snd.audioSrc.clip = this.touchScrollAudio;

            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;

            snd.audioSrc.Play();
        }
    }

    void touchCatEventHandler(GameObject go)
    {
        //AudioSource.PlayClipAtPoint(this.touchCatAudio, worldPos, 1f);

        if (eventSound3DPrefab)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, go.transform);

            snd.audioSrc.clip = this.touchCatAudio;

            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;

            snd.audioSrc.Play();
        }
    }

    void touchZombieEventHandler(GameObject go)
    {
        //AudioSource.PlayClipAtPoint(this.touchZombieAudio, worldPos, 1f);

        if (eventSound3DPrefab)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, go.transform);

            snd.audioSrc.clip = this.touchZombieAudio;

            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;

            snd.audioSrc.Play();
        }
    }
}
