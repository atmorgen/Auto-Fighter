using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //utility scripts
    UtilityScripts utilityScripts;
    string targetTag = "Ally";

    //flag
    GameObject flag;

    //target information
    public GameObject target;
    AllyAI targetAI;

    //this information
    Vector3 enemyPosition;

    //stats
    public int health = 50;
    public int damage = 10;
    public int attackSpeed = 5;
    public int speed = 1;
    public int attackRange = 1;
    public int aggroRange = 10;
    float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.Find("Flag");
        target = flag;
        utilityScripts = GameObject.Find("UtilityScripts").GetComponent<UtilityScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == flag) {
            searchForTarget();
        }
        whatShouldIDoToTarget();
    }

    void searchForTarget() {
        GameObject potentialTarget = utilityScripts.FindClosestTarget(target, targetTag);
        bool potentialTargetInRange = potentialTarget != null ?
            utilityScripts.inRange(potentialTarget.transform.position, transform.position, aggroRange) : false;
        if (potentialTargetInRange) {
            setTarget(potentialTarget);
        } else {
            setTarget(flag);
        }
    }

    void whatShouldIDoToTarget() {
        if (utilityScripts.inRange(target.transform.position, transform.position, attackRange)) {
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
        if (Time.time > elapsedTime) {
            if (targetAI.didIDie(damage)) {
                searchForTarget();
            }
            elapsedTime = Time.time + attackSpeed;
        }
    }

    private void setTarget(GameObject newTarget) {
        target = newTarget;
        targetAI = target == flag ? null : target.GetComponent<AllyAI>();
    }

    public bool didIDie(int damage) {
        health -= damage;
        if(health <= 0) {
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}
