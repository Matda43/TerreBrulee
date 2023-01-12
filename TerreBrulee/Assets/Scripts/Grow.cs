using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    // Start is called before the first frame update

    bool isGrowing = true;
    bool isWaiting = true;
    const int TIMER_FIXED = 1000;
    int timer = 0;

    float coef = 0.025f;

    float speed = 5f;
    float angle = 10f;
    float angleRotation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting && !isGrowing && this.transform.localScale.x > 7.5)
        {
            ungrow();
        }
        else if(!isWaiting && isGrowing && this.transform.localScale.x < 18)
        {
            grow();
        }
        else if (!isWaiting && this.transform.localScale.x >= 18)
        {
            isWaiting = true;
            timer = TIMER_FIXED;
            chooseAngle();
            StartCoroutine(ExecuteWaiting(3));
        }
        else if(!isWaiting && this.transform.localScale.x <= 7.5)
        {
            Debug.Log("cc");
            isWaiting = true;
            timer = TIMER_FIXED;
            chooseAngle();
            StartCoroutine(ExecuteWaiting(3));
        }
        else if(isWaiting && timer <= 0)
        {
            Debug.Log("hello");
            isWaiting = false;
            isGrowing = !isGrowing;
            StartCoroutine(ExecuteRotation(3));
        }
    }

    private void grow()
    {
        Vector3 new_scale = this.transform.localScale;
        new_scale += Vector3.one * coef;
        this.transform.localScale = new_scale;
    }

    private void ungrow()
    {
        Vector3 new_scale = this.transform.localScale;
        new_scale -= Vector3.one * coef;
        this.transform.localScale = new_scale;
    }

    private void move()
    {
        Quaternion rotation = Quaternion.AngleAxis(angleRotation, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    IEnumerator ExecuteWaiting(float time)
    {
        yield return new WaitForSeconds(time);

        Debug.Log("timer");
        timer--;
    }

    IEnumerator ExecuteRotation(float time)
    {
        yield return new WaitForSeconds(time);
        
        move();
    }

    private void chooseAngle()
    {
        float value = Random.value;
        angleRotation = angle;
        if (value < 0.5)
            angleRotation *= -1;
    }

}
