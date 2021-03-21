using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Student : MonoBehaviour
{
    public Animator animator;
    public Slider staminabar;
    public int stamina_max=30,student_tired_stamina=5;

    void Start(){
        Debug.Log("Student");
        animator = GetComponent<Animator>();
        staminabar.value=stamina_max;
    }

    public void reset()
    {
        animator.SetBool("sleep",false);
    }
    public void setStamina(int stamin)
    {
        staminabar.value=stamin;
        if(stamin<=student_tired_stamina)animator.SetBool("tired",true);
        else animator.SetBool("tired",false);
    }
    public void StudentSleep(bool sleep)
    {
        animator.SetBool("sleep",sleep);
    }
    public void StudentAlert(bool alert)
    {
        animator.SetBool("alert",alert);
    }
    public void StudentHappy()
    {
        animator.SetBool("happy",true);
    }

    void Update(){

    }
}