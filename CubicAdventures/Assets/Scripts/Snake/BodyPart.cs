using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {
    public static List<GameObject> bodyPartList = new List<GameObject>();
    public static void UpdateBodyPartList(GameObject gameObject) {
        bodyPartList.Add(gameObject);
    }
    public class BodyPos {
        public Vector3 position;
        public Quaternion rotation;

        public BodyPos(Vector3 pos, Quaternion rot) {
            position = pos;
            rotation = rot;
        }

    } 
    public static List <BodyPos> bodyPosList = new List<BodyPos>();
    public static void ClearPositions() { 
        bodyPosList.Clear();
    }
    public static void ClearBodies() {

        bodyPartList.Clear();
    }
    public static void AddPosition(Vector3 pos, Quaternion rot) {
        bodyPosList.Add(new BodyPos(pos, rot));
    }    
    public static void AddPosition(BodyPos body) {
        bodyPosList.Add(new BodyPos(body.position, body.rotation));
    }
    public static BodyPos GetPosition(int i) {
        return new BodyPos(bodyPartList[i].transform.position, bodyPartList[i].transform.rotation);
    }



}
