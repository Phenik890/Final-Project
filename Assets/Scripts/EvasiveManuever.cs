using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManuever : MonoBehaviour
{
    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 manueverTime;
    public Vector2 manueverWait;
    public Boundary bd;

    private float targetManuever;
    private float currentSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManuever = Random.Range(1, dodge) * -Mathf.Sign (transform.position.x);
            yield return new WaitForSeconds (Random.Range (manueverTime.x, manueverTime.y));
            targetManuever = 0;
            yield return new WaitForSeconds(Random.Range (manueverWait.x, manueverWait.y));
        }
    }

    void FixedUpdate()
    {
        float newManuever = Mathf.MoveTowards(rb.velocity.x, targetManuever, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManuever, 0.0f, currentSpeed);
        rb.position = new Vector3
            (
                Mathf.Clamp (rb.position.x, bd.xMin, bd.xMax),
                0.0f,
                Mathf.Clamp (rb.position.z, bd.zMin, bd.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
