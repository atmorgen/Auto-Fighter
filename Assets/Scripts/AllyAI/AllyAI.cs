using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAI : MonoBehaviour
{
    //utility
    UtilityScripts utilityScripts;
    HealthBarScript healthBarScript;
    Orchestrator orchestrator;
    string targetTag = "Enemy";

    //stats
    Unit unit;
    public float currentHealth;
    Vector3 mostRecentPosition;
    float elapsedTime = 0;

    //target
    public GameObject target;
    EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>().getUnit();
        orchestrator = GameObject.Find("Orchestrator").GetComponent<Orchestrator>();
        utilityScripts = GameObject.Find("UtilityScripts").GetComponent<UtilityScripts>();
        healthBarScript = this.transform.Find("HealthBar").GetComponent<HealthBarScript>();
        currentHealth = unit.maxHealth;
        mostRecentPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        searchForTarget();
        if (target != null) {
            whatShouldIDoToTarget();
        }
    }

    void searchForTarget() {
        GameObject potentialTarget = utilityScripts.FindClosestTarget(target,transform.position, targetTag);
        if(potentialTarget != null) {
            setTarget(utilityScripts.inRange(potentialTarget.transform.position, transform.position, unit.aggroRange) ?
                potentialTarget : null);
        } else {
            setUnitToStartingPosition();
        }
    }


    void whatShouldIDoToTarget() {
        if (utilityScripts.inRange(target.transform.position,transform.position, unit.attackRange)) {
            attackTarget();
        } else {
            moveToTarget();
        }
    }

    void moveToTarget() {
        float step = unit.speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    void attackTarget() {
        if (Time.time > elapsedTime) {
            if (enemyAI.didIDie(unit.damage)) {
                orchestrator.addToKillCount();
                searchForTarget();
                orchestrator.checkAllEnemiesDead();
            }
            elapsedTime = Time.time + unit.attackSpeed;
        }
    }

    void setUnitToStartingPosition() {
        transform.position = mostRecentPosition;
    }

    private void setTarget(GameObject newTarget) {
        target = newTarget;
        enemyAI = newTarget != null ? target.GetComponent<EnemyAI>() : null;
    }

    public bool didIDie(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Destroy(this.gameObject);
            return true;
        }
        healthBarScript.updateHealthBar(currentHealth, unit.maxHealth);
        return false;
    }
}
