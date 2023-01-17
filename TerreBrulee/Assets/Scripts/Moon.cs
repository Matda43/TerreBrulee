using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    // Start is called before the first frame update

    const float DISTANCE_FROM_EARTH = 2.25f;
    Vector2 spawn_location = new Vector2(DISTANCE_FROM_EARTH, 0);

    public AudioClip comet;
    public AudioClip eruption;

    AudioSource audiosource;

    void Start()
    {
        this.transform.position = spawn_location;
        audiosource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Comet")
        {
            audiosource.clip = comet;
            audiosource.volume = 0.1f;
            audiosource.Play();
        }
        else
        {
            audiosource.clip = eruption;
            audiosource.volume = 0.7f;
            audiosource.Play();
        }
        Destroy(other.gameObject);
    }

}
