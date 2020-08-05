using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public float healthPercentage;
    Vector3 startingSize;

    private void Start() {
        startingSize = transform.localScale;
        healthPercentage = 100;
    }

    public void updateHealthBar(float currentHealth, float totalHealth) {
        healthPercentage = currentHealth / totalHealth;
        transform.localScale = new Vector3(startingSize.x * healthPercentage, startingSize.y, startingSize.z);
    }
}
