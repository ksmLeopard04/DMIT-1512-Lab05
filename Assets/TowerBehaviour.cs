using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField] Collider AttackRadius;
    private GameObject currentTarget;
    float FireRate;
    float TimeStamp;
    // Start is called before the first frame update
    void OnEnable()
    {
        TimeStamp = Time.time;
        FireRate = FireRate = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            transform.parent.LookAt(currentTarget.transform.position);
            if (TimeStamp + FireRate < Time.time)
            {
                TimeStamp = Time.time;
                GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(1);
                if(bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    bullet.SetActive(true);
                }
            }
        }
        if (currentTarget != null && !currentTarget.activeSelf)
        {
            currentTarget = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && other.gameObject.activeSelf)
        {
            currentTarget = other.gameObject;
        }
        if(other.gameObject.activeSelf == false)
        {
            currentTarget = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentTarget)
        {
            currentTarget = null;
        }
    }
}