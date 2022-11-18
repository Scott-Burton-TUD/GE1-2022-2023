using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Quaternion start;
    private Quaternion end;

    public Transform player;

    public GameObject bullet;
    public Transform spawnPoint;


    private float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        Quaternion quart;

        Vector3 toTarget = player.position - transform.position;
        toTarget.Normalize();
        float dot = Vector3.Dot(toTarget, transform.forward);
        float theta = Mathf.Acos(dot);

        quart = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.up);

        start = quart;

        end = Quaternion.LookRotation(player.position - transform.position);

        t = 0;

        transform.rotation = start;
    }

    // Update is called once per frame
    void Update()
    {

        end = Quaternion.LookRotation(player.position - transform.position);

        Quaternion quart = Quaternion.Slerp(start, end, t);
        transform.rotation = Quaternion.Slerp(transform.rotation, end, Time.deltaTime);
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(0.5f);

        Instantiate(bullet, spawnPoint.position, transform.rotation);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(shoot());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(shoot());
        }
    }
}