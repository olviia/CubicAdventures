using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicSnakeSceneSetUp : MonoBehaviour {

    [SerializeField] private Camera myCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject upperController;
    [SerializeField] private float cubeSize = 0.05f;



    // Start is called before the first frame update
    void Start()
    {
          float screenWidth = Screen.width;
          float screenHeight = Screen.height;


        Vector3[] upperControllerCorners = new Vector3[4];
        upperController.GetComponent<RectTransform>().GetWorldCorners(upperControllerCorners);
        Vector3 cubeCenter = player.GetComponent<Renderer>().bounds.center;

        float fieldHeight = screenHeight - upperControllerCorners[0].y;
        float desiredCubeSize = cubeSize * fieldHeight;

        myCamera.transform.rotation = Quaternion.Euler(90, 0, 0);
        myCamera.transform.position = new Vector3(cubeCenter.x, 30f, cubeCenter.z);
        //myCamera.GetComponent<Transform>.rotation
          PositionCamera();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PositionCamera() { 

    }
}
