using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target; //target of the enemy
    public float speed; //speed of the enemy
       
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //find the target object
    }

    void Update()
    {
        //if the distance between the target and the enemy is over 3 then move towards the target
        if (Vector3.Distance(transform.position, target.position) > 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        //if the distance between the target and the enemy is less than 3 then move away from the target
        if (Vector3.Distance(transform.position, target.position) < 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }
}
