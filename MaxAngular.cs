using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAngular : MonoBehaviour
{
    [SerializeField] float maxAngular = default;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngular;
    }
}
