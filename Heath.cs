using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heath : MonoBehaviour
{
    public Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public void reset()
    {
        animator.SetBool("heath_lost",false);
    }
    public void heath_lost()
    {
        animator.SetBool("heath_lost",true);
    }
}