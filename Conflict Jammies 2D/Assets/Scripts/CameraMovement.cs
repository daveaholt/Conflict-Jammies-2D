using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update () 
    {
        transform.position = new Vector3 (player.position.x, player.position.y, -1); // Camera follows the player but 6 to the right
    }

}
