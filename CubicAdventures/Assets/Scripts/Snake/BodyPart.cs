using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public static List<GameObject> bodyPartList = new List<GameObject>();
    public static void UpdateBodyPartList(GameObject gameObject) {
        bodyPartList.Add(gameObject);
    }
}
