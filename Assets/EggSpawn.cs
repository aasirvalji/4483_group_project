using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawn : MonoBehaviour
{
    public GameObject slime;
    bool hit = false;
    Collider2D  col;
    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<Collider2D>();
        Destroy(this.gameObject,4);
    }
    private void OnDestroy() {
        if(hit==false){
            Instantiate(slime, this.gameObject.transform.position, Quaternion.identity);
            }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword" || other.tag == "Ranged" || other.tag == "Bomb")
        {
            hit = true;
            Destroy(this.gameObject);
        }
    }
}
