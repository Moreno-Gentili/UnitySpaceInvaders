using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float limitAt = 20;

    [SerializeField, Range(1, 100)]
    float speed = 1;

    PlayerBulletMovement playerBulletMovement;
    Vector3 playerBulletOrigin;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerBullet = GameObject.FindWithTag("PlayerBullet");
        playerBulletOrigin = playerBullet.transform.position;
        playerBulletMovement = playerBullet.GetComponent<PlayerBulletMovement>();
        playerBullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        Vector3 currentPosition = gameObject.transform.position;

        float thrust = Time.deltaTime * speed * Input.GetAxis("Horizontal");
        float x = Mathf.Clamp(thrust + currentPosition.x, -limitAt, limitAt);
        transform.position = new Vector3(x, currentPosition.y, currentPosition.z);
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBulletMovement.Fire(new Vector3(transform.position.x, playerBulletOrigin.y, playerBulletOrigin.z));
        }
    }
}
