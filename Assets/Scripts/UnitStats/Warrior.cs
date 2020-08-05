using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Unit {
    public override Unit getUnit() {
        return new Warrior();
    }

    public Warrior() {
        maxHealth = 150;
        damage = 20;
        attackSpeed = 5;
        attackRange = 5;
        aggroRange = 15;
        speed = 75;
    }
}
