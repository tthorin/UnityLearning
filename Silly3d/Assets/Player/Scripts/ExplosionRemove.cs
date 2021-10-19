using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRemove : MonoBehaviour
{
    
    int birth;
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        birth = Time.frameCount;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.frameCount - birth) > 40)
        {
            Destroy(gameObject);
        }
    }
}
