using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    // Start is called before the first frame update

    const float DISTANCE_FROM_EARTH = 3;

    Location spawn_location = new Location(0, DISTANCE_FROM_EARTH);

    float angle = 10;

    void Start()
    {
        setPosition(spawn_location);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        float posX = Mathf.Cos(angle);
        float posY = Mathf.Sin(angle);
        this.transform.position = new Vector2(posX, posY) * DISTANCE_FROM_EARTH;
        angle = angle + Time.deltaTime;
        angle = angle % 360f;
    }

    private void setPosition(Location new_Location)
    {
        this.transform.position = new Vector2(new_Location.getX(), new_Location.getY());
    }
}
