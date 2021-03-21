using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GamePlay : MonoBehaviour
{
    public Animator animator;
    public static int student_max_stamina=30,Success_max_time=100,student_tired_stamina=5,max_heath=3;
    public int teacher_at_x,teacher_at_y,teacher_view_x,teacher_view_y,teacherDirection=0,scold_Time=3,scoldTimer,SuccessTimer,heath;
    public int[] student_stamina;
    public int[,] gameMap;
    private bool scold,gameEnd,Lost;
    private bool Pause;
    public bool[] student;
    public float currentTime = 0f,startingTime = 120f;
    public Slider Successbar;
    public Student s1,s2,s3,s4,s5,s6;
    public Teacher teacher;
    public Heath h1,h2,h3;
    public System.Random rnd = new System.Random();
    public Text timerText;
    public GameObject resultscore;
    public GameObject gameover;
    public GameObject timeout;
    public GameObject success;
    float current = 0f;
    float starting = 3.5f;
    public GameObject Open;
    float current2 = 0f;
    float starting2 = 1.5f;


    [SerializeField] Text t1;
    [SerializeField] Text t2;
    [SerializeField] Text t3;
    [SerializeField] Text t4;
    [SerializeField] Text t5;


    void Start(){
        teacher_at_x=teacher_at_y = teacher_view_x=teacher_view_y=1;
        animator = GetComponent<Animator>();
        SuccessTimer = 0;
        heath = max_heath;
        current = starting;
        Lost=false;  
        Pause = false;
        resetGame();
        InvokeRepeating("DirectionOfEnemy", 0f, 1f);
        InvokeRepeating("studentStaminaRegression", 0f, 1f);
        currentTime = startingTime;
        gamePause();
    }
    public void resetGame()
    {
        student=new bool[7];
        gameMap=new int[7,9];
        student_stamina=new int[7];
        for(int i=1;i<7;i++){
            student_stamina[i]=student_max_stamina+1;
        }
        scold=false;
    }
    public void reset()
    {
        student=new bool[7];
        gameMap=new int[7,9];
        scold=false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }


    //Ai Teacher start

    public void DirectionOfEnemy()
    {
        if(!Pause&&!Lost){
            teacher_view_x=teacher_at_x;
            teacher_view_y=teacher_at_y;

            if(!scold){
                //Debug.Log("Teacher position "+teacher_at_x+","+teacher_at_y);

                //จำกัดทิศทางของ teacher
                if(teacher_at_x==1&&teacher_at_y==1){ // (1,1)
                    teacherDirection  = rnd.Next(1,3);
                    if(teacherDirection==1)teacherDirection=1;
                    else if(teacherDirection==2)teacherDirection=4;
                }
                else if(teacher_at_x==1&&teacher_at_y==7){ // (1,7)
                    teacherDirection  = rnd.Next(1,3);
                    if(teacherDirection==1)teacherDirection=2;
                    else if(teacherDirection==2)teacherDirection=4;
                }
                else if(teacher_at_x==5&&teacher_at_y==1){ // (5,1)
                    teacherDirection  = rnd.Next(1,3);
                    if(teacherDirection==1)teacherDirection=1;
                    else if(teacherDirection==2)teacherDirection=3;
                }
                else if(teacher_at_x==5&&teacher_at_y==7){ // (5,7)
                    teacherDirection  = rnd.Next(1,3);
                    if(teacherDirection==1)teacherDirection=2;
                    else if(teacherDirection==2)teacherDirection=3;
                }
                else if((teacher_at_x==1&&teacher_at_y==2)||(teacher_at_x==1&&teacher_at_y==4)||(teacher_at_x==1&&teacher_at_y==6)||(teacher_at_x==3&&teacher_at_y==2)||(teacher_at_x==3&&teacher_at_y==4)||(teacher_at_x==3&&teacher_at_y==6)||(teacher_at_x==5&&teacher_at_y==2)||(teacher_at_x==5&&teacher_at_y==4)||(teacher_at_x==5&&teacher_at_y==6)){
                    /*teacherDirection  = rnd.Next(1,3);
                    if(teacherDirection==1)teacherDirection=1;
                    else if(teacherDirection==2)teacherDirection=2;*/
                }
                else if((teacher_at_x==2&&teacher_at_y==1)||(teacher_at_x==2&&teacher_at_y==3)||(teacher_at_x==2&&teacher_at_y==5)||(teacher_at_x==2&&teacher_at_y==7)||(teacher_at_x==4&&teacher_at_y==1)||(teacher_at_x==4&&teacher_at_y==3)||(teacher_at_x==4&&teacher_at_y==5)||(teacher_at_x==4&&teacher_at_y==7)){
                    /*teacherDirection  = rnd.Next(1,3);
                    if(teacherDirection==1)teacherDirection=3;
                    else if(teacherDirection==2)teacherDirection=4;*/
                }
                else if(teacher_at_x==3&&teacher_at_y==1){ // (3,1)
                    teacherDirection  = rnd.Next(1,4);
                    if(teacherDirection==1)teacherDirection=1;
                    else if(teacherDirection==2)teacherDirection=3;
                    else if(teacherDirection==3)teacherDirection=4;
                }
                else if(teacher_at_x==3&&teacher_at_y==7){ // (3,7)
                    teacherDirection  = rnd.Next(1,4);
                    if(teacherDirection==1)teacherDirection=2;
                    else if(teacherDirection==2)teacherDirection=3;
                    else if(teacherDirection==3)teacherDirection=4;
                }
                else if((teacher_at_x==1&&teacher_at_y==3)||(teacher_at_x==1&&teacher_at_y==5)){ // (1,3),(1,5)
                    teacherDirection  = rnd.Next(1,4);
                    if(teacherDirection==1)teacherDirection=1;
                    else if(teacherDirection==2)teacherDirection=2;
                    else if(teacherDirection==3)teacherDirection=4;
                }
                else if((teacher_at_x==3&&teacher_at_y==3)||(teacher_at_x==3&&teacher_at_y==5)){ // (3,3),(3,5)
                    teacherDirection  = rnd.Next(1,5);
                    if(teacherDirection==1)teacherDirection=1;
                    else if(teacherDirection==2)teacherDirection=2;
                    else if(teacherDirection==3)teacherDirection=3;
                    else if(teacherDirection==4)teacherDirection=4;
                }
                else if((teacher_at_x==5&&teacher_at_y==3)||(teacher_at_x==5&&teacher_at_y==5)){ // (5,3),5,5)
                    teacherDirection  = rnd.Next(1,4);
                    if(teacherDirection==1)teacherDirection=1;
                    else if(teacherDirection==2)teacherDirection=2;
                    else if(teacherDirection==3)teacherDirection=3;
                }

                //Direction of teacher
                if(teacherDirection==1){ 
                    teacher_at_y++;
                    teacher.setDirection(1,1,0); //ไปทางขวา
                }
                else if(teacherDirection==2){
                    teacher_at_y--;
                    teacher.setDirection(2,-1,0); //ไปทางซ้าย
                }
                else if(teacherDirection==3){
                    teacher_at_x--;
                    teacher.setDirection(3,0,1); //ไปทางด้านบน
                }
                else if(teacherDirection==4){
                    teacher_at_x++;
                    teacher.setDirection(4,0,-1); //ไปทางด้านล่าง
                }
                else{
                    teacher.setDirection(0,0,0); //อยู่กับที่
                }
            }
            else if(scold){
                teacher.setDirection(0,0,0);
                teacher.angry(true);
                studentAlert(true);
                //Debug.Log("Resume in "+scoldTimer+"s");
                if(scoldTimer<=0){
                    reset();
                    teacher.angry(scold);
                    studentAlert(false);
                    //Debug.Log("Resume");
                }
                if(!Lost)scoldTimer--;
            }
        }
        else{
            teacher.setDirection(0,0,0);
        }
        
    }

    public void Looking(){
        int i,j;
        if(teacherDirection==1){
            for(i=-1;i<=1;i++){
                for(j=0;j<=1;j++){
                    if(gameMap[teacher_view_x+i,teacher_view_y+j]==1){
                        teacherScold();
                        break;
                    }
                }
            }
        }
        else if(teacherDirection==2){
            for(i=-1;i<=1;i++){
                for(j=-1;j<=0;j++){
                    if(gameMap[teacher_view_x+i,teacher_view_y+j]==1){
                        teacherScold();
                        break;
                    }
                }
            }
        }
        else if(teacherDirection==3){
            for(i=-1;i<=0;i++){
                for(j=-1;j<=1;j++){
                    if(gameMap[teacher_view_x+i,teacher_view_y+j]==1){
                        teacherScold();
                        break;
                    }
                }
            }
        }
        else if(teacherDirection==4){
            for(i=0;i<=1;i++){
                for(j=-1;j<=1;j++){
                    if(gameMap[teacher_view_x+i,teacher_view_y+j]==1){
                        teacherScold();
                        break;
                    }
                }
            }
        }
    }
    public void teacherScold(){
        if(!scold){
            heath--;
            if(heath==2)h3.heath_lost();
            else if(heath==1)h2.heath_lost();
            else if(heath<=0){
                h1.heath_lost();
                gameLost2();
            }
        }
        scold=true;
        scoldTimer=scold_Time;
    }

    //Ai Teacher end

    //Student start

    public void studentStaminaRegression(){
        if(!scold&&!Pause&&!Lost){
            for(int i=1;i<7;i++){
                if(student[i]){
                    if(student_stamina[i]<student_max_stamina){
                        student_stamina[i]+=2;
                        if(student_stamina[i]>student_max_stamina)student_stamina[i]=student_max_stamina;
                    }
                    if(!scold){
                        SuccessTimer+=1;
                        if(SuccessTimer>=Success_max_time)gameFinish();
                    }
                }
                else student_stamina[i]--;
            }
            s1.setStamina(student_stamina[1]);
            s2.setStamina(student_stamina[2]);
            s3.setStamina(student_stamina[3]);
            s4.setStamina(student_stamina[4]);
            s5.setStamina(student_stamina[5]);
            s6.setStamina(student_stamina[6]);
            if(student_stamina[1]<=0){
                student[1]=true;
                gameMap[2,2]=1;
                s1.StudentSleep(true);
            }
            if(student_stamina[2]<=0){
                student[2]=true;
                gameMap[2,4]=1;
                s1.StudentSleep(true);
            }
            if(student_stamina[3]<=0){
                student[3]=true;
                gameMap[2,6]=1;
                s1.StudentSleep(true);
            }
            if(student_stamina[4]<=0){
                student[4]=true;
                gameMap[4,2]=1;
                s1.StudentSleep(true);
            }
            if(student_stamina[5]<=0){
                student[5]=true;
                gameMap[4,4]=1;
                s1.StudentSleep(true);
            }
            if(student_stamina[6]<=0){
                student[6]=true;
                gameMap[4,6]=1;
                s1.StudentSleep(true);
            }    
        }
    }
    public void student1()
    {
        student[1]=!student[1];
        if(student[1])gameMap[2,2]=1;
        else gameMap[2,2]=0;
        s1.StudentSleep(student[1]);
    }
    public void student2()
    {
        student[2]=!student[2];
        if(student[2])gameMap[2,4]=1;
        else gameMap[2,4]=0;
        s2.StudentSleep(student[2]);
    }
    public void student3()
    {
        student[3]=!student[3];
        if(student[3])gameMap[2,6]=1;
        else gameMap[2,6]=0;
        s3.StudentSleep(student[3]);
    }
    public void student4()
    {
        student[4]=!student[4];
        if(student[4])gameMap[4,2]=1;
        else gameMap[4,2]=0;
        s4.StudentSleep(student[4]);
    }
    public void student5()
    {
        student[5]=!student[5];
        if(student[5])gameMap[4,4]=1;
        else gameMap[4,4]=0;
        s5.StudentSleep(student[5]);
    }
    public void student6()
    {
        student[6]=!student[6];
        if(student[6])gameMap[4,6]=1;
        else gameMap[4,6]=0;
        s6.StudentSleep(student[6]);
    }
    public void studentAlert(bool alert)
    {
        gameMap[2,2]=0;
        gameMap[2,4]=0;
        gameMap[2,6]=0;
        gameMap[4,2]=0;
        gameMap[4,4]=0;
        gameMap[4,6]=0;
        s1.reset();
        s2.reset();
        s3.reset();
        s4.reset();
        s5.reset();
        s6.reset();
        s1.StudentAlert(alert);
        s2.StudentAlert(alert);
        s3.StudentAlert(alert);
        s4.StudentAlert(alert);
        s5.StudentAlert(alert);
        s6.StudentAlert(alert);
        for(int i=1;i<7;i++){
            if(student_stamina[i]<student_max_stamina/2)student_stamina[i]=student_max_stamina/2;
        }
    }

    //Student end

    //GamePlay Start

    public void gameFinish(){
        Lost=true;
        s1.StudentHappy();
        s2.StudentHappy();
        s3.StudentHappy();
        s4.StudentHappy();
        s5.StudentHappy();
        s6.StudentHappy();
        Successbar.value=SuccessTimer;
        success.SetActive(true);
        current2 = starting2;
        t1.text = getScore().ToString();
        t2.text = getHeath().ToString();
        t3.text = getTimeLeft().ToString();
        t4.text = getSuccessPercent().ToString();
        t5.text = getScore().ToString();
    }
    
    public void gameLost1(){
        Lost=true;
        timeout.SetActive(true);
        current2 = starting2;
        t1.text = getScore().ToString();
        t2.text = getHeath().ToString();
        t3.text = getTimeLeft().ToString();
        t4.text = getSuccessPercent().ToString();
        t5.text = getScore().ToString();

    }
    public void gameLost2(){
        Lost=true;
        gameover.SetActive(true);
        current2 = starting2;
        t1.text = getScore().ToString();
        t2.text = getHeath().ToString();
        t3.text = getTimeLeft().ToString();
        t4.text = getSuccessPercent().ToString();
        t5.text = getScore().ToString();
        
    }
        
    public void gamePause(){
        Pause=true;
    }
    public void gameResume(){
        Pause=false;
    }
    public int getHeath(){ // จำนวนหัวใจที่เหลือ
        return heath;
    }
    public int getTimeLeft(){ // เวลาที่เหลือ
        return (int)currentTime;
    }
    public int getSuccessPercent(){ // %ความสำเร็จ
        return SuccessTimer;
    }
    public int getScore(){ // คะแนน
        return getHeath()*3000+ getTimeLeft()*100+getSuccessPercent()*100;
    }

    //GamePlay End

    //update is call once per frame
    void Update(){
        
        current -= 1 * Time.deltaTime;
        if(current <= 0)
        {
            gameResume();
            Open.SetActive(false);
        }
        
        if(Lost||gameEnd)
        {
            current2 -= 1 * Time.deltaTime;
            if(current2 <= 0)
            {
                resultscore.SetActive(true);

            }
        }
        
        if(!Pause&&!Lost){
            Looking();
            Successbar.value=SuccessTimer;
            if(currentTime>0)currentTime -= 1*Time.deltaTime;
            timerText.text=((int)(currentTime/60)).ToString("0")+":"+((int)currentTime%60).ToString("00");
            if(currentTime<=0)gameLost1();    
        }
        
    }


}