using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometBehaviour : MonoBehaviour
{
    GameObject earth;
    int speed = 1;
    FollowEarth fe = new FollowEarth();

    // Start is called before the first frame update
    void Start()
    {

        earth = GameObject.Find("Earth");    
        transform.rotation = fe.lookEarth(earth, this.gameObject, 180);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, earth.transform.position, speed * Time.deltaTime);
    }
}
