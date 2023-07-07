using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    float disappearAt = -12;

    bool isFiring = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        if (transform.position.y < disappearAt)
        {
            isFiring = false;
            gameObject.SetActive(false);
        }
    }

    public bool IsFiring => isFiring;

    public void Fire(Vector3 origin)
    {
        transform.position = origin;
        isFiring = true;
        gameObject.SetActive(true);
    }
}
