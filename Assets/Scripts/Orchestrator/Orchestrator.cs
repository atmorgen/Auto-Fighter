using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orchestrator : MonoBehaviour
{
    Text mainOverlay;
    UtilityScripts utilityScripts;
    public Stats stats;

    // Start is called before the first frame update
    void Start()
    {

        stats = transform.Find("Stats").GetComponent<Stats>();
        mainOverlay = GameObject.Find("MainOverlay").GetComponent<Text>();
        utilityScripts = transform.Find("UtilityScripts").GetComponent<UtilityScripts>();
        finishRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToKillCount() {
        stats.addKill();
    }

    public void addToGoldCount(int add) {
        stats.addGold(add);
    }

    public void subtractFromGoldCount(int remove) {
        stats.removeGold(remove);
    }

    public void startRound() {
        Time.timeScale = 1;
    }

    void finishRound() {
        Time.timeScale = 0;
    }

    public void gameOver() {
        mainOverlay.text = "Game Over";
        utilityScripts.clearAll();
        Time.timeScale = 0;
    }
}
