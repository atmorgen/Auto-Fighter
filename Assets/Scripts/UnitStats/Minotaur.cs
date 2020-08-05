using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Unit
{
    public override Unit getUnit() {
        return new Minotaur();
    }

    public Minotaur() {
        maxHealth = 50;
        damage = 10;
        attackSpeed = 5;
        attackRange = 10;
        aggroRange = 15;
        speed = 50;
    }
}
