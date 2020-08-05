using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int cost;
    public float maxHealth;
    public int damage;
    public int attackSpeed;
    public int attackRange;
    public int aggroRange;
    public int speed;

    public virtual Unit getUnit() { return null; }
}
