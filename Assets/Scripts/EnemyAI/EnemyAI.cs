using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //utility scripts
    UtilityScripts utilityScripts;
    string targetTag = "Ally";

    //lootbag
    public GameObject lootBag;

    //flag
    GameObject flag;

    //target information
    public GameObject target;
    AllyAI targetAI;
    FlagAI flagAI;

    //this information
    Vector3 enemyPosition;

    //stats
    Unit unit;
    public float currentHealth;
    float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>().getUnit();
        Debug.Log(unit.speed);
        flag = GameObject.Find("Flag");
        target = flag;
        utilityScripts = GameObject.Find("UtilityScripts").GetComponent<UtilityScripts>();
        lootBag = GameObject.Find("LootBag");
        currentHealth = unit.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag != null) {
            searchForTarget();
        }
        if(target != null) {
            whatShouldIDoToTarget();
        }
    }

    void searchForTarget() {
        GameObject potentialTarget = utilityScripts.FindClosestTarget(target,transform.position, targetTag);
        bool potentialTargetInRange = potentialTarget != null ?
            utilityScripts.inRange(potentialTarget.transform.position, transform.position, unit.aggroRange) : false;
        if (potentialTargetInRange) {
            setTarget(potentialTarget);
        } else {
            setTarget(flag);
        }
    }

    void whatShouldIDoToTarget() {
        if (utilityScripts.inRange(target.transform.position, transform.position, unit.attackRange)) {
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
            if(target == flag) {
                flagAI.didIDie(unit.damage);
            } else if (targetAI.didIDie(unit.damage)) {
                searchForTarget();
            }
            elapsedTime = Time.time + unit.attackSpeed;
        }
    }

    private void setTarget(GameObject newTarget) {
        target = newTarget;
        if(target == flag) {
            flagAI = target.GetComponent<FlagAI>();
        } else {
            targetAI = target.GetComponent<AllyAI>();
        }
    }

    public bool didIDie(int damage) {
        currentHealth -= damage;
        if(currentHealth <= 0) {
            Instantiate(lootBag, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}
