﻿using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    //Internal Methods
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if (otherCollider.tag == "ObstaclePart") {
            DestroyObstacle(otherCollider.gameObject);
        }
    }

    private void DestroyObstacle(GameObject obstacleObject) {
        obstacleObject.SetActive(false);
        StartCoroutine(ExpireShield());
    }

    private IEnumerator ExpireShield() {
        yield return null;
        Destroy(gameObject);
    }

    //Public Methods
    public void DestroyShield() {
        StartCoroutine(ExpireShield());
    }
}
