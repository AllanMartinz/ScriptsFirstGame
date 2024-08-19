using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Frog : MonoBehaviour
{
    /// <summary>
    /// arrumar as hitbox
    /// da para criar duas hits uma que mata o player e outra que mata o frog
    /// arrumar as anicoes de morte
    /// </summary>

    private Animator Ani;

    public float speed;
    public float moveTime;

    public Transform topCol;

    private bool dirRight;
    private float timer;

    void Start()
    {
        Ani = GetComponent<Animator>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - topCol.position.y;
            if (height > 0)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector2.up * 5);
                Ani.SetTrigger("die");
                Destroy(gameObject, 1f);
            }
        }
    }
}
