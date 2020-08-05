using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    Orchestrator orchestrator;

    void Start() {
        orchestrator = GameObject.Find("Orchestrator").GetComponent<Orchestrator>();
    }

    //picks up gold
    private void OnMouseDown() {
        int num = Random.Range(0, 6);
        orchestrator.addToGoldCount(num);
        Destroy(this.gameObject);
    }
}
