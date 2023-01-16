using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update

    float speed = 5f;

    public GameObject webcam;
    public GameObject point;

    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        CameraCapture cc = webcam.GetComponent<CameraCapture>();

        point.transform.position = cc.pointDetected;
        Vector2 direction = Camera.main.ScreenToWorldPoint(cc.pointDetected) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
