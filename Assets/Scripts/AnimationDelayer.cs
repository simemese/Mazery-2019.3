using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelayer : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartAnimation();
    }

    public void StartAnimation()
    {
        float cycleOffset = Random.Range(0, 100);
        float speedMultiplier = (float)Random.Range(8, 15) / 10;
        animator.SetFloat("CycleOffset", cycleOffset);
        animator.SetFloat("SpeedMultiplier", speedMultiplier);
        animator.SetBool("isAnimating", true);
    }
}
