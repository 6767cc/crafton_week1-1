using System.Collections;
using UnityEngine;

public class TileDestroyCheck : MonoBehaviour
{
    Rigidbody2D rb;
    ConstantForce2D cf;
    float h;

    public void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        cf = transform.GetComponent<ConstantForce2D>();
        h = Screen.height;
    }

    public void Update()
    {
        if (transform.position.y > h)
        {
            transform.position = new Vector2(transform.position.x, h);
        }
        else if (transform.position.y < -h/5)
        {
            Destroy(gameObject);
        }
    }

    public void StartDestroyEffect()
    {
        StartCoroutine(DestroyEffect());
    }

    IEnumerator DestroyEffect()
    {
        //cf�� force�� �ִ� ��� rb �ӵ��� x���� �ٲٴ� ����� ����
        rb.linearVelocity = new Vector2(0, 3500f);
        cf.force = new Vector2(Random.Range(-5000f, 5000f), 0);
        
        cf.torque = Random.Range(-100f, 100f);

        yield return new WaitForSecondsRealtime(0.05f);

        rb.gravityScale = Random.Range(2000f, 3000f);
    }
}
