using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour
{
    public float radius = 10;
    public int numWaypoints = 6;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;
    GameObject cube = null;

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            float theta = Mathf.PI * 2.0f / (float)numWaypoints;

            for (int i = 0; i < numWaypoints; i++)
            {
                Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
                pos = transform.TransformPoint(pos);
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(pos, 1);
            }
        }
    }

    void Awake()
    {
        float theta = Mathf.PI * 2.0f / (float)numWaypoints;

        for (int i = 0; i < numWaypoints; i++)
        {
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos);
        }
    }

    void Update()
    {
        Vector3 AItankPos = transform.position;
        Vector3 AItankNew = waypoints[current] - AItankPos;

        if (cube == null)
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = AItankNew;
        }
        Debug.Log(AItankNew);
        Destroy(cube);

        float dist = AItankNew.magnitude;
        if (dist < 1)
        {
            current = (current + 1) % waypoints.Count;
        }

        Vector3 direction = AItankNew / dist;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current], Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(AItankNew, Vector3.up), 180 * Time.deltaTime);

        Vector3 Player = player.position - transform.position;
        float dot = Vector3.Dot(transform.forward, Player);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (dot > 0)
        {
            Debug.Log("in front of tank");
        }
        else
        {
            Debug.Log("behind tank");
        }

        if (angle > 30 && 0 < dot && dot < 15)
        {
            Debug.Log("inside field of view");
            Debug.Log("in range");
        }
    }
}
