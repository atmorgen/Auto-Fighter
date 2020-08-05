using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    public bool isMouseInBattlefield;

    private void OnMouseEnter() {
        isMouseInBattlefield = true;
    }

    private void OnMouseExit() {
        isMouseInBattlefield = false;
    }
}
