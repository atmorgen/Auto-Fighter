using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityScripts : MonoBehaviour
{
    //checks whether two objects are within 'range'
    public bool inRange(Vector3 target, Vector3 me, int range) {
        return Vector2.Distance(target, me) <= range ? true : false;
    }
}
