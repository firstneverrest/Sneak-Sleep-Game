using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teacher : MonoBehaviour
{
    public float speed = 200f;
    public Animator animator;
    public int movement_x,movement_y;
    
    void Start(){
        movement_y=movement_y=0;
        Debug.Log("Teacher");
        animator = GetComponent<Animator>();
        InvokeRepeating("move", 0f, 0.05f);
    }
    public void setDirection(int teacherDirection,int x,int y){
        movement_x=x;
        movement_y=y;

        //Set animation of teacher
        animator.SetInteger("direction",teacherDirection);
    }
    public void move(){
        
        transform.Translate(speed*movement_x*1.9f,speed*movement_y*1.3f,0);
    }
    public void angry(bool in1){
        animator.SetBool("angry",in1);
    }
    
    //update is call once per frame
    void Update(){

    }
}