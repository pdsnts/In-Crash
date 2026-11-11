using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;

    public enum Events
    {
        AnimIdle,
        AnimIdleLoja,
        AnimIdleArmazem
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
    }

    public void PlayAnimIdle()
    {
        if (anim != null) 
        {
            anim.SetTrigger("Idle");
        }
        else
        {
            Debug.LogError("Animator não encontrado no NPC!");
        }
        StartCoroutine(DestroyInSeconds(0.3f));
    }

    public void PlayAnimIdleLoja()
    {
        if (anim != null) 
        {
            anim.SetTrigger("Idle");
        }
        else
        {
            Debug.LogError("Animator não encontrado no NPC!");
        }
        StartCoroutine(DestroyInSeconds(0.15f));
    }

        public void PlayAnimIdleArmazem()
    {
        if (anim != null) 
        {
            anim.SetTrigger("Idle");
        }
        else
        {
            Debug.LogError("Animator não encontrado no NPC!");
        }
        StartCoroutine(DestroyInSeconds(0.3f));
    }

    private IEnumerator DestroyInSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}