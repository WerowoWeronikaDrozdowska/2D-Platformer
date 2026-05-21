using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour

{
   
    public GameObject Destination;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.position+" "+Destination.transform.position);
       collision.transform.position = Destination.transform.position;
       

    }
}
