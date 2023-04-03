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

    Path path;    
    int currentWaypoint = 0;
    bool reachedEOP = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath",0f,0.6f); 
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
    void Update()
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
        print(direction);
        Vector2 force = direction * speed * Time.deltaTime;
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        rb.AddForce(force);
        if(distance < nextWayPointDistance){
            currentWaypoint++;
        }
        if(distance > 1f && distance < 1.001f){

        }
    }


}
