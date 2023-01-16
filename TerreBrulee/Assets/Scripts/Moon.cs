using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    // Start is called before the first frame update

    const float DISTANCE_FROM_EARTH = 2.25f;
    Vector2 spawn_location = new Vector2(DISTANCE_FROM_EARTH, 0);

    void Start()
    {
        this.transform.position = spawn_location;
    }

    // Update is called once per frame
    void Update()
    {

    }


    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.gameObject.name);
        Destroy(collision.gameObject);
    }

}
