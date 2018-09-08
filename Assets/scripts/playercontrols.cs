using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playercontrols : MonoBehaviour
{

    Vector3 waypoint;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ground") waypoint = hit.point;
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "container")
            {
                waypoint = hit.collider.gameObject.GetComponent<container_script>().reach_container(hit.collider.gameObject.GetComponent<container_script>().position_to_open);
            }
            GetComponent<NavMeshAgent>().destination = waypoint;
        }
    }



}