﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UtilityScripts : MonoBehaviour
{
    //checks whether two objects are within 'range'
    public bool inRange(Vector3 target, Vector3 me, int range) {
        return Vector2.Distance(target, me) <= range ? true : false;
    }

    //finds closest enemy...
    public GameObject FindClosestTarget(GameObject previousTarget, string tag) {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        gos = gos.Where(go => go != previousTarget).ToArray();
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
