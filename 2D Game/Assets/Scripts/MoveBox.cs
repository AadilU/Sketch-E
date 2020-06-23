using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public float p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p = Input.GetAxisRaw("Horizontal");
        transform.position = new Vector3(p * 50 * Time.deltaTime, 0f, 0f);
    }
}
