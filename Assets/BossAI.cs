using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BossAI : MonoBehaviour
{
    public Transform pof;
    public Transform target;
    public float speed = 3f;
    public float nextWayPointDistance = 1f;
    public SpriteRenderer sr;
    public GameObject egg;
    public Animator ac;
    Path path;    
    int currentWaypoint = 0;
    bool reachedEOP = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath",0f,0.2f); 
        InvokeRepeating("LayEgg",0f,5f); 

    }
    void LayEgg(){
        float distance = Vector2.Distance(rb.position, target.position);
        if(distance >= 1f){
            Instantiate(egg, rb.position, Quaternion.identity);
        }
    }
    void UpdatePath(){
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete (Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0; 
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null){
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count){
            reachedEOP = true;
            return;
        } else {
            reachedEOP = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint]- rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        if(force.magnitude > 0){
            ac.SetBool("move", true);
        } else {
            ac.SetBool("move", true);
        }
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        rb.AddForce(force);
        if(distance < nextWayPointDistance){
            currentWaypoint++;
        }
          if (direction.x < 0)
            {
                sr.flipX = true;
            }
            else if (direction.x > 0)
            {
                sr.flipX = false  ;
            }
       
    }


}
