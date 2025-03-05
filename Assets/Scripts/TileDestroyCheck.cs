using System.Collections;
using UnityEngine;

public class TileDestroyCheck : MonoBehaviour
{
    Rigidbody2D rb;
    ConstantForce2D cf;

    public void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        cf = transform.GetComponent<ConstantForce2D>();

        //�ʱ�ȭ�� �ȵ�, ������ Ÿ�Ͽ����� �ȹ߻��ϴ� ���׷� ����
        rb.gravityScale = 0f;
        cf.force = Vector2.zero;
        cf.torque = 0f;
    }

    public void Update()
    {
        if (transform.position.y < -500)
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
