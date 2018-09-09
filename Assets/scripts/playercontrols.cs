using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playercontrols : MonoBehaviour
{

    Vector3 waypoint;
    [SerializeField]
    string state;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AnimationHandler();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ground")
            {
                state = "walking";
                waypoint = hit.point;
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "container")
            {
                waypoint = hit.collider.gameObject.GetComponent<container_script>().reach_container(hit.collider.gameObject.GetComponent<container_script>().position_to_open);
            }
            GetComponent<NavMeshAgent>().destination = waypoint;
        }

        
    }


    void AnimationHandler()
    {
        if (state == "walking") GetComponent<Animator>().SetInteger("state", 1);
        if (GetComponent<NavMeshAgent>().remainingDistance <= 0.01f) state = "idle";
        if (state=="idle") GetComponent<Animator>().SetInteger("state", 0);
    }
}