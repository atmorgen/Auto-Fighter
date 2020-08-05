using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
	Orchestrator orchestrator;

	// Start is called before the first frame update
	void Start() {
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		orchestrator = GameObject.Find("Orchestrator").GetComponent<Orchestrator>();
	}

	void TaskOnClick() {
		orchestrator.startRound();
	}
}
