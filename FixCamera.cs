using System.Collections.Generic;
using UnityEngine;

public class FixCamera : MonoBehaviour
{

    [SerializeField] GameObject fixTarget = null;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - fixTarget.transform.position;
    }
    void Update()
    {
        transform.position = fixTarget.transform.position + offset;
    }
}