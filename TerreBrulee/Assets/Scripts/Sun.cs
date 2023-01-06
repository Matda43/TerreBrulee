using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update

    Location[] locations_available_spawn = new Location[] { new Location(-13, 9), new Location(13, 9), new Location(-13, -9), new Location(13, -9) };

    Location[] locations_available = new Location[] { new Location(-9, 5), new Location(9, 5), new Location(-9, -5), new Location(9, -5) };

    int index_choosen = -1;

    private float speed = 3;

    bool moveForward = true;

    void Start()
    {
        Location location_choosen = chooseARandomLocation();
        setPosition(location_choosen);
    }

    // Update is called once per frame
    void Update()
    {
        if (index_choosen >= 0)
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
        }else if (transform.position.x != locations_available_spawn[index_choosen].getX() && transform.position.y != locations_available_spawn[index_choosen].getY())
        {
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
}
