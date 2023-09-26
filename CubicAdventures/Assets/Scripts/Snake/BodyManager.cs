using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    public class Body {
        public Vector3 position;
        public Quaternion rotation;

        public Body(Vector3 pos, Quaternion rot) { 
            position = pos;
            rotation = rot;
        }

    }
    public List <Body> bodyTransformList = new List<Body>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBodyTransformList();
    }

    public void UpdateBodyTransformList() {
        bodyTransformList.Add(new Body(transform.position, transform.rotation));
    }
    public void ClearBodyTransformList() {
        bodyTransformList.Clear();
        bodyTransformList.Add(new Body(transform.position, transform.rotation));
    }

}
