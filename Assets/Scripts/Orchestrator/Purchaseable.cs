using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchaseable : MonoBehaviour
{
    public GameObject purchasedObject;
    Battlefield battleField;

    Vector3 originalPosition;
    Vector3 screenPoint;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
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
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp() {
        this.transform.position = originalPosition;
        if (battleField.isMouseInBattlefield) {
            Debug.Log("Create Unit");
        }
    }
}
