using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] GameObject deathVfx;
    [SerializeField] float durationOfExplosion = 0.1f;
    // Start is called before the first frame update
    public void Disappear()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVfx, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
    }

}
