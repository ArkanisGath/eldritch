using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container_script : MonoBehaviour
{
    [SerializeField]
    bool locked;
    [SerializeField]
    public Transform position_to_open;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public Vector3 reach_container(Transform position_to_open)
    {
        return position_to_open.position;
    }

    public void open_container()
    {
        locked = false;
    }
}