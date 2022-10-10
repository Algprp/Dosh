using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    float G;
    public float speed;
    public Game Game;
    public float IncreaseSpeed;
    public Rigidbody rb;
    private void FixedUpdate()
    {
        speed += IncreaseSpeed;
        transform.position += transform.forward * speed * Time.deltaTime;

        G = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.right * G * speed * Time.deltaTime);
    }
    

    public void ReachFinish()
    {
        Game.OnPlayerReachFinish();
        rb.velocity = Vector3.zero;
    }
}
