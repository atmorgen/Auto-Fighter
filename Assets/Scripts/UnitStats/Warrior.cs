using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Unit {
    public override Unit getUnit() {
        return new Warrior();
    }

    public Warrior() {
        cost = 3;
        maxHealth = 150;
        damage = 20;
        attackSpeed = 5;
        attackRange = 25;
        aggroRange = 150;
        speed = 15;
    }
}
