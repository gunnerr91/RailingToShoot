using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int enemyHP = 5;


    ScoreBoard scoreBoard;

    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        gameObject.AddComponent<BoxCollider>().isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        UpdateScoreAndEnemyHP();
        if (enemyHP <= 0)
        {
            KillEnemy();
        }
    }

    private void UpdateScoreAndEnemyHP()
    {
        scoreBoard.UpdateScore(scorePerHit);
        enemyHP -= 1;
    }

    private void KillEnemy()
    {
        var gbExFx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        gbExFx.transform.parent = parent;
        Destroy(gameObject);
    }
}
