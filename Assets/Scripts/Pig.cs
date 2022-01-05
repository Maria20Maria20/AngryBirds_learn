using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pig : MonoBehaviour
{
    public static int enemiesAlive = 0;

    [SerializeField] GameObject deathEffect; 

    private float health = 4f;

    private void Start()
    {
        enemiesAlive++;
    }
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            Debug.Log("“ы всех убил, можешь перейти на новый уровень!");
        }
        Destroy(gameObject);
    }
}
