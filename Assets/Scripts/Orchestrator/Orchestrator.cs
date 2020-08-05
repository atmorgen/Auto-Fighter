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
        pauseGame();
    }

    public bool checkAllEnemiesDead() {
        Debug.Log("checking for all dead enemies");
        if (utilityScripts.areAllEnemiesDead()) {
            StartCoroutine(finishRound());
            return true;
        }
        return false;
    }

    public int getGoldCount() {
        return stats.gold;
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

    void pauseGame() {
        Time.timeScale = 0;
    }

    public void startRound() {
        Time.timeScale = 1;
    }

    IEnumerator finishRound() {
        Debug.Log("Round Finished");
        stats.increaseRound();
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }

    public void gameOver() {
        mainOverlay.text = "Game Over";
        utilityScripts.clearAll();
        Time.timeScale = 0;
    }
}
