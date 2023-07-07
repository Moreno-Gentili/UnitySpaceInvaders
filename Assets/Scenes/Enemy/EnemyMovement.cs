using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float delay = 0;

    [SerializeField]
    float fireRate = 0.02f;

    [SerializeField]
    float period = 90;

    const int sideSteps = 12;
    const int drops = 10;

    Vector3 originalPosition;
    static EnemyBulletMovement enemyBulletMovement;
    static Vector3 enemyBulletOrigin;

    void Start()
    {
        originalPosition = transform.position;
        if (enemyBulletMovement is null)
        {
            GameObject enemyBullet = GameObject.FindWithTag("EnemyBullet");
            if (enemyBullet != null)
            {
                enemyBulletOrigin = enemyBullet.transform.position;
                enemyBulletMovement = enemyBullet.GetComponent<EnemyBulletMovement>();
                enemyBullet.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        float time = Time.fixedTime;
        float delayedTime = time - delay;
        int x = GetX(delayedTime);
        int y = GetY(delayedTime);
        transform.position = originalPosition + new Vector3(x, -y, 0);
    }

    void Fire()
    {
        if (!enemyBulletMovement.IsFiring && UnityEngine.Random.Range(0f, 1f) < Time.deltaTime * fireRate)
        {
            enemyBulletMovement.Fire(new Vector3(transform.position.x, transform.position.y, enemyBulletOrigin.z));
        }
    }

    private int GetX(float time)
    {
        float dropPeriod = period / drops;
        float timeInDropPeriod = time % dropPeriod;
        int x = Mathf.FloorToInt(timeInDropPeriod / dropPeriod * (sideSteps + 1));
        bool isGoingLeft = Mathf.FloorToInt(time / dropPeriod) % 2 != 0;
        
        if (isGoingLeft)
        {
            x = sideSteps - x;
        }

        return x;
    }

    private int GetY(float time)
    {
        float timeInPeriod = time % period;
        int y = Mathf.FloorToInt(timeInPeriod / period * drops);
        return y;
    }
}
