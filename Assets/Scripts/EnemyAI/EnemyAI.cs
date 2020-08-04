using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //utility scripts
    UtilityScripts utilityScripts;

    //flag
    GameObject flag;

    //target information
    GameObject target;

    //this information
    Vector3 enemyPosition;

    public int speed = 1;
    public int range = 1;

    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.Find("Flag");
        utilityScripts = GameObject.Find("UtilityScripts").GetComponent<UtilityScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        shouldITargetFlag();
        whatShouldIDoToTarget();
    }

    void shouldITargetFlag() {
        if(target == null) {
            target = flag;
        }
    }


    void whatShouldIDoToTarget() {
        if (utilityScripts.inRange(target.transform.position, transform.position, range)) {
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
