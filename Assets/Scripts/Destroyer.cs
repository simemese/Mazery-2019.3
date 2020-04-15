using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] GameObject deathVfx;
    [SerializeField] float durationOfExplosion = 0.1f;
    [SerializeField] AudioClip deathSound;
    // Start is called before the first frame update
    public void Disappear()
    {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVfx, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
    }

}
