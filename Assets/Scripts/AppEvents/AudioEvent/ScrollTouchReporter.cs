using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTouchReporter : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision c)
    {

        if (c.impulse.magnitude > 0.25f)
        {
            //we'll just use the first contact point for simplicity
            EventManager.TriggerEvent<TouchScrollEvent, GameObject>(c.gameObject);
        }


        //				foreach (ContactPoint contact in c.contacts) {
        //
        //						if (c.impulse.magnitude > 0.5f)
        //								EventManager.TriggerEvent<AudioEventManager.CollideDeskChairEvent, Vector3> (contact.point);
        //						
        //				}
    }
}
