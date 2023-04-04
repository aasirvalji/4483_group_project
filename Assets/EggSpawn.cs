using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawn : MonoBehaviour
{
    public GameObject slime;
    bool hit = false;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(this.gameObject,3);
        
    }
    private void OnDestroy() {
        if(hit==false){
            Instantiate(slime, this.gameObject.transform.position, Quaternion.identity);
            }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
