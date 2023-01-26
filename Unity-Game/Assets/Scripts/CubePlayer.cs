using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : MonoBehaviour
{
    public float speed;
    float h;
    float v;
    Vector3 moveVec;

void Start(){
    
}

    void Update(){
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(h, 0, v).normalized;
        transform.position += moveVec * speed * Time.deltaTime;

        transform.LookAt(transform.position + moveVec);
    }
}
