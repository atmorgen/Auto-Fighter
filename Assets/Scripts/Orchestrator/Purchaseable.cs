using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchaseable : MonoBehaviour
{
    public GameObject purchasedObject;
    Battlefield battleField;
    Orchestrator orchestrator;

    Vector3 originalPosition;
    Vector3 curPosition;
    Vector3 screenPoint;
    Vector3 offset;

    Unit unit;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>().getUnit();
        originalPosition = transform.position;
        orchestrator = GameObject.Find("Orchestrator").GetComponent<Orchestrator>();
        battleField = GameObject.Find("Battlefield").GetComponent<Battlefield>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown() {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag() {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp() {
        this.transform.position = originalPosition;
        if (battleField.isMouseInBattlefield) {
            if(orchestrator.getGoldCount() >= unit.cost) {
                orchestrator.subtractFromGoldCount(unit.cost);
                GameObject go = Instantiate(purchasedObject, curPosition, Quaternion.identity);
                go.SetActive(true);
            } else {
                Debug.Log("not enough gold");
            }
        }
    }
}
