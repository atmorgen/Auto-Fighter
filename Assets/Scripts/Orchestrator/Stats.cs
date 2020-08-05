using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int gold = 0;
    Text goldText;
    public int kills = 0;
    Text killsText;
    public int round = 1;
    Text roundText;

    private void Start() {
        goldText = GameObject.Find("Gold").GetComponent<Text>();
        killsText = GameObject.Find("Kills").GetComponent<Text>();
        roundText = GameObject.Find("Round").GetComponent<Text>();
        updateStatsPage();
    }

    public void addKill() {
        kills++;
        updateStatsPage();
    }

    public void addGold(int add) {
        gold += add;
        updateStatsPage();
    }

    public void removeGold(int remove) {
        gold -= remove;
        updateStatsPage();
    }

    public void increaseRound() {
        round++;
        updateStatsPage();
    }

    public void updateStatsPage() {
        goldText.text = "Gold: " + gold;
        killsText.text = "Kills: " + kills;
        roundText.text = "Round: " + round;
    }
}
