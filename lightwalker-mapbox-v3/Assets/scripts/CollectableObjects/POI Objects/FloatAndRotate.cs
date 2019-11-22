using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50;
    [SerializeField] private float floatAmplitate = 2.0f;
    [SerializeField] private float floatFrequency = 0.5f;

    private Vector3 startPos;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 5.0f, transform.position.z);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        Vector3 temPos = startPos;
        temPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency) * floatAmplitate;
        transform.position = temPos;
    }
}
