using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    float disappearAt = 12;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (transform.position.y > disappearAt)
        {
            gameObject.SetActive(false);
        }
    }

    public void Fire(Vector3 origin)
    {
        transform.position = origin;
        gameObject.SetActive(true);
    }
}
