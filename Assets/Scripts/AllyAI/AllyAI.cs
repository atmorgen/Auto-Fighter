using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAI : MonoBehaviour
{
    //utility
    UtilityScripts utilityScripts;

    //stats
    public int health;
    public int range = 10;
    public int speed = 1;

    //target
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        utilityScripts = GameObject.Find("UtilityScripts").GetComponent<UtilityScripts>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            whatShouldIDoToTarget();
        }
    }

    void whatShouldIDoToTarget() {
        if (utilityScripts.inRange(target.transform.position,transform.position,range)) {
            attackTarget();
        } else {
            moveToTarget();
        }
    }

    void moveToTarget() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    void attackTarget() {
        Debug.Log("attacking!");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        target = collision.gameObject;
    }
}
