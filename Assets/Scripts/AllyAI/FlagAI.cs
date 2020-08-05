using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAI : MonoBehaviour
{
    Orchestrator orchestrator;
    public float health = 1;

    // Start is called before the first frame update
    void Start()
    {
        orchestrator = GameObject.Find("Orchestrator").GetComponent<Orchestrator>();
    }

    public bool didIDie(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(this.gameObject);
            orchestrator.gameOver();
            return true;
        }
        return false;
    }
}
