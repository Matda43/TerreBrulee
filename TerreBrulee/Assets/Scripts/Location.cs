using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{
    private float x;
    private float y;

    public Location(float x, float y)
    {
        setLocation(x, y);
    }

    public float getX()
    {
        return this.x;
    }

    public float getY()
    {
        return this.y;
    }

    public void setLocation(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}
