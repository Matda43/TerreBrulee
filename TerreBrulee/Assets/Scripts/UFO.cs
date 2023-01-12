using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject parent;

    void Start()
    {
        this.transform.position = new Vector2(parent.transform.localScale.x/1.4f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setPosition(Location new_Location)
    {
        this.transform.position = new Vector2(new_Location.getX(), new_Location.getY());
    }
}
