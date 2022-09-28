using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreBoard;

    Renderer rend;
    Color oldColor;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        rend = GetComponent<Renderer>();
        oldColor = rend.material.color;
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }

    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.SetParent(GameObject.FindGameObjectWithTag("SpawnAtRuntime").transform);
        scoreBoard.IncreaseScore(scorePerHit);
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints--;
        StartCoroutine(ChangeColorToRed());
    }

    IEnumerator ChangeColorToRed()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = oldColor;
        yield return null;
    }
}
