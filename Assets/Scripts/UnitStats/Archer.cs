using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{

    public override Unit getUnit() {
        return new Archer();
    }

    public Archer() {
        cost = 5;
        maxHealth = 100;
        damage = 5;
        attackSpeed = 5;
        attackRange = 10;
        aggroRange = 15;
        speed = 50;
    }
}
