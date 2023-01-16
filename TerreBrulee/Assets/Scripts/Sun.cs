using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update

    Location[] locations_available_spawn = new Location[] { new Location(-13, 9), new Location(13, 9), new Location(-13, -9), new Location(13, -9) };

    Location[] locations_available = new Location[] { new Location(-9, 5), new Location(9, 5), new Location(-9, -5), new Location(9, -5) };

    int index_choosen = -1;

    private float speed = 3;

    bool moveForward = true;

    bool waiting = false;
    bool can_wait = false;

    const float TIME_TO_WAIT = 3;
    float time = 0;

    void Start()
    {
        Location location_choosen = chooseARandomLocation();
        setPosition(location_choosen);
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            move();
        }
        else
        {
            wait(Time.deltaTime);
        }
    }

    private void move()
    {
        if (moveForward && transform.position.x != locations_available[index_choosen].getX() && transform.position.y != locations_available[index_choosen].getY())
        {
            Location locationToReach = locations_available[index_choosen];
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(locationToReach.getX(), locationToReach.getY()), speed * Time.deltaTime);
            can_wait = true;
        }
        else if (transform.position.x != locations_available_spawn[index_choosen].getX() && transform.position.y != locations_available_spawn[index_choosen].getY())
        {
            if (can_wait)
            {
                waiting = true;
                can_wait = false;
            }
            Location locationToReach = locations_available_spawn[index_choosen];
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(locationToReach.getX(), locationToReach.getY()), speed * Time.deltaTime);
            moveForward = false;
        }
        else
        {
            Location location_choosen = chooseARandomLocation();
            setPosition(location_choosen);
            moveForward = true;
        }
    }

    private Location chooseARandomLocation()
    {
        System.Random random = new System.Random();
        int indice = random.Next(0, locations_available_spawn.Length);
        index_choosen = indice;
        return locations_available_spawn[index_choosen];
    }

    private void setPosition(Location new_Location)
    {
        this.transform.position = new Vector2(new_Location.getX(), new_Location.getY());
    }

    private void wait(float time_to_add)
    {
        if (timerShouldBeReset())
        {
            resetTimer();
            waiting = false;
        }
        else
        {
            incTimer(time_to_add);
        }
    }

    private void resetTimer()
    {
        time = 0;
    }

    private bool timerShouldBeReset()
    {
        return time >= TIME_TO_WAIT;
    }

    private void incTimer(float time_to_add)
    {
        time += time_to_add;
    }
}
