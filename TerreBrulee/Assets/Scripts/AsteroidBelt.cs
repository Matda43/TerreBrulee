using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{

    public GameObject comet;

    const float TIME_BETWEEN_SPAWN = 2;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < TIME_BETWEEN_SPAWN)
            time += Time.deltaTime;
        else
        {
            Vector2 origin = new Vector2(0, 0);
            Vector2 posComet = RandomPointInAnnulus(origin, 10, 14);
            Instantiate(comet, posComet, Quaternion.identity, this.transform);
            time = 0;
        }
    }

    Vector2 RandomPointInAnnulus(Vector2 origin, float minRadius, float maxRadius)
    {
        var randomDirection = Random.insideUnitCircle.normalized;
        var randomDistance = Random.Range(minRadius, maxRadius);
        var point = origin + randomDirection * randomDistance;
        return point;
    }
}
