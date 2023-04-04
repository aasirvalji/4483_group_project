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
    public GameObject bolt;
    public Animator ac;
    Path path;    
    int currentWaypoint = 0;
    bool reachedEOP = false;
    bool canMove = true;
    Seeker seeker;
    Rigidbody2D rb;
    private Vector2 dir;
    private float initSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initSpeed = speed;
        ac = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath",0f,0.2f); 
        InvokeRepeating("LayEgg",2f,6f); 
        InvokeRepeating("ShootPlayer",2f, 6f); 


    }
    void ShootPlayer(){
        float distance = Vector2.Distance(rb.position, target.position);
        if(distance < 1f){
            for(int i = 0 ;i<3; i++){
                GameObject ammo = Instantiate(bolt, pof.position, Quaternion.AngleAxis(Vector2.Angle(transform.forward, dir), Vector3.forward));
                Destroy(ammo, 3);
                Rigidbody2D ammoRigidbody = ammo.GetComponent<Rigidbody2D>();
                ammoRigidbody.AddForce(dir * 100f);
            }
        }
    }
    void LayEgg(){
        float distance = Vector2.Distance(rb.position, target.position);
        if(distance >= 0.5f){
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
        float curSpeed = speed;
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < 0.3f && distance > 0.01f){
            curSpeed = initSpeed *10;
        } else{
            curSpeed = initSpeed;
        }
        
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint]- rb.position).normalized;
        dir = direction;
        Vector2 force = direction * curSpeed * Time.deltaTime;
        if(force.magnitude > 0){
            ac.SetBool("move", true);
        } else {
            ac.SetBool("move", true);
        }
        rb.AddForce(force);
        if(distance < nextWayPointDistance){
            currentWaypoint++;
        }
          if (force.x < 0)
            {
                sr.flipX = true;
            }
            else if (force.x > 0)
            {
                sr.flipX = false  ;
            }
       if(path == null){
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count){
            reachedEOP = true;
            return;
        } else {
            reachedEOP = false;
        }
      
    }



}
