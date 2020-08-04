using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAI : MonoBehaviour
{
    //utility
    UtilityScripts utilityScripts;
    string targetTag = "Enemy";

    //stats
    public int health = 100;
    public int damage = 5;
    public int attackSpeed = 5;
    public int attackRange = 10;
    public int aggroRange = 10;
    public int speed = 1;
    float elapsedTime = 0;

    //target
    public GameObject target;
    EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        utilityScripts = GameObject.Find("UtilityScripts").GetComponent<UtilityScripts>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            searchForTarget();
        } else {
            whatShouldIDoToTarget();
        }
    }

    void searchForTarget() {
        GameObject potentialTarget = utilityScripts.FindClosestTarget(target, targetTag);
        if(potentialTarget != null) {
            setTarget(utilityScripts.inRange(potentialTarget.transform.position, transform.position, aggroRange) ?
                potentialTarget : null);
        }
    }


    void whatShouldIDoToTarget() {
        if (utilityScripts.inRange(target.transform.position,transform.position, attackRange)) {
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
            if (enemyAI.didIDie(damage)) {
                searchForTarget();
            }
            elapsedTime = Time.time + attackSpeed;
        }
    }

    private void setTarget(GameObject newTarget) {
        target = newTarget;
        enemyAI = newTarget != null ? target.GetComponent<EnemyAI>() : null;
    }

    public bool didIDie(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}
