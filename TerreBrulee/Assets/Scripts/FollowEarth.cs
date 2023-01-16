using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEarth
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Quaternion lookEarth(GameObject earth, GameObject objet, int anglePlus)
    {
        Vector3 targ = earth.transform.position;
        targ.z = 0f;

        Vector3 objectPos = objet.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle + anglePlus));
    }
}
