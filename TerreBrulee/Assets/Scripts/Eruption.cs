using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eruption : MonoBehaviour
{
    float speed = 3f;

    GameObject earth;

    FollowEarth followEarth;

    void Start()
    {
        followEarth = new FollowEarth();
        earth = GameObject.Find("Earth");
        transform.rotation = followEarth.lookEarth(earth, this.gameObject, -90);
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
    }
}
