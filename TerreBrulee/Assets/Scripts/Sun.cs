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

    bool waitingT1 = false;
    bool can_waitT1 = false;

    const float TIME_TO_WAIT_T1 = 3;
    float timeT1 = 0;

    const float TIME_TO_WAIT_T2 = 5;
    float timeT2 = 0;

    bool waitingT2 = false;


    void Start()
    {
        Location location_choosen = chooseARandomLocation();
        setPosition(location_choosen);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(waitingT1)
        {
            waitT1(Time.deltaTime);
        }
        else if (waitingT2)
        {
            waitT2(Time.deltaTime);
        }
        else
        {
            move();
        }
    }

    private void move()
    {
        if (moveForward && transform.position.x != locations_available[index_choosen].getX() && transform.position.y != locations_available[index_choosen].getY())
        {
            Location locationToReach = locations_available[index_choosen];
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(locationToReach.getX(), locationToReach.getY()), speed * Time.deltaTime);
            can_waitT1 = true;
        }
        else if (transform.position.x != locations_available_spawn[index_choosen].getX() && transform.position.y != locations_available_spawn[index_choosen].getY())
        {
            if (can_waitT1)
            {
                waitingT1 = true;
                can_waitT1 = false;
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
            waitingT2 = true;
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

    private void waitT1(float time_to_add)
    {
        if (timerShouldBeResetT1())
        {
            resetTimerT1();
            waitingT1 = false;
        }
        else
        {
            incTimerT1(time_to_add);
        }
    }

    private void resetTimerT1()
    {
        timeT1 = 0;
    }

    private bool timerShouldBeResetT1()
    {
        return timeT1 >= TIME_TO_WAIT_T1;
    }

    private void incTimerT1(float time_to_add)
    {
        timeT1 += time_to_add;
    }


    private void waitT2(float time_to_add)
    {
        if (timerShouldBeResetT2())
        {
            resetTimerT2();
            waitingT2 = false;
        }
        else
        {
            incTimerT2(time_to_add);
        }
    }

    private void resetTimerT2()
    {
        timeT2 = 0;
    }

    private bool timerShouldBeResetT2()
    {
        return timeT2 >= TIME_TO_WAIT_T2;
    }

    private void incTimerT2(float time_to_add)
    {
        timeT2 += time_to_add;
    }
}
