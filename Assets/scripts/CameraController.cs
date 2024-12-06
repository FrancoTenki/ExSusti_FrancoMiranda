using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        player=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.transform.position.x ;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
