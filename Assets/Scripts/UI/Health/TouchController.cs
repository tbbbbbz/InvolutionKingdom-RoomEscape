using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public HealthBarController healthBarCtrl;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Evil"))
        {
            healthBarCtrl.onTakeDamage(25);
        }
    }

    /*
    public void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Evil")
        {
            if (healthBarCtrl)
            {
                healthBarCtrl.onTakeDamage(25);
            }
        }
    }
    */
}
