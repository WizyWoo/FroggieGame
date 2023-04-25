using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilliPadPlatform : MonoBehaviour
{

    public float PlatformSped, Lemings;
    [SerializeField]
    private ParticleSystem splashParticle;
    private bool isSatOn;
    private float croakTimer;

    private void FixedUpdate()
    {

        if(isSatOn)
            return;

        croakTimer += ((PlatformSped * Time.fixedDeltaTime) / Lemings);

        transform.position = new Vector2((Mathf.PingPong(croakTimer, 2) - 1) * Lemings, transform.position.y);

    }

    public void HelloLeaf()
    {

        isSatOn = true;
        splashParticle.Play();

    }

    public void GoodByeLeaf()
    {

        isSatOn = false;

    }

}
