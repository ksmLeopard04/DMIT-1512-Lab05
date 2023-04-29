using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float Velocity;
    Rigidbody rb;
    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Velocity;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if(collision.gameObject.CompareTag("OutofBounds"))
        {
            gameObject.SetActive(false);
        }
    }
}
