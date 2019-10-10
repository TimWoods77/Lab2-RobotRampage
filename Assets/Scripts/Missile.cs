using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 30f;// how fast missile travels
    public int damage = 10;//how much damage missile causes when hits the player

    //1 
    void Start()
    {
        StartCoroutine("deathTimer");// allows the computer to do multiple things at once (threading) deathTimer will be the coroutine that will be going on
    }
    
    // 2
    void Update()
    {   transform.Translate(Vector3.forward * speed * Time.deltaTime);//moves missile forward by multiplying speed by the time between frames
    }
    
    // 3
    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);   Destroy(gameObject);// once the 10 seconds have passed it will continue after the yeild statement if the missile doesn't hit the player it will self-destruct.
    }
}
