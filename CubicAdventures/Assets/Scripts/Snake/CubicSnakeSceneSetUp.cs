using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicSnakeSceneSetUp : MonoBehaviour {

    [SerializeField] private Camera myCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject upperController;
    [SerializeField] private GameObject[] walls;
    [SerializeField] private float wallsMargins = 30;

    private float pixelsInUnit;
    private static Vector3[] fieldInUnit;



    // Start is called before the first frame update
    void Start() {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;


        Vector3[] upperControllerCorners = new Vector3[4];
        upperController.GetComponent<RectTransform>().GetWorldCorners(upperControllerCorners);
        Vector3 cubeCenter = player.GetComponent<Renderer>().bounds.center;

        float controllerHeight = upperControllerCorners[1].y;
        float fieldHeight = screenHeight - controllerHeight;

        myCamera.transform.rotation = Quaternion.Euler(90, 0, 0);

        //upper and down wall length is screenWidth - wallsMargins*2 (x coordinate)
        //left and right wall length is fieldHeight - wallsMargins*2 (y coordinate)

        //define how many pixels are in one unit
        Vector3 wallMin = walls[0].GetComponent<Renderer>().bounds.min;
        Vector3 wallMax = walls[0].GetComponent<Renderer>().bounds.max;
        Vector3 toScreenMin = myCamera.WorldToScreenPoint(wallMin);
        Vector3 toScreenMax = myCamera.WorldToScreenPoint(wallMax);

        //how many pixels are in 1 unit measurement
        //x and y are the same and equal 1 if someone has't changed the scene

        pixelsInUnit = toScreenMax.x - toScreenMin.x;

        myCamera.transform.position = new Vector3(cubeCenter.x, 30f, cubeCenter.z-controllerHeight/(2*pixelsInUnit));




        float targetWallWidth = screenWidth - wallsMargins * 2;
        float targetWallHeight = fieldHeight - wallsMargins * 2;

        float multiplierX = targetWallWidth / pixelsInUnit;
        float multiplierY = targetWallHeight / pixelsInUnit;

        walls[0].transform.localScale = new Vector3(multiplierX, 1f, 1f);
        walls[1].transform.localScale = new Vector3(multiplierX, 1f, 1f);
        walls[2].transform.localScale = new Vector3(multiplierY, 1f, 1f);
        walls[3].transform.localScale = new Vector3(multiplierY, 1f, 1f);

        //how many units in magrin
        float marginVertical = (fieldHeight/2 - wallsMargins - pixelsInUnit/2) / pixelsInUnit;
        float marginHorizontal = (screenWidth/2 - wallsMargins- pixelsInUnit/2) / pixelsInUnit;


        walls[0].transform.position = new Vector3(0f, 0f, marginVertical);
        walls[1].transform.position = new Vector3(0f, 0f, -marginVertical);
        walls[2].transform.position = new Vector3(-marginHorizontal, 0f, 0f);
        walls[3].transform.position = new Vector3(marginHorizontal, 0f, 0f);

        //assign values of world coordinates of fields corners
        fieldInUnit = new Vector3[4];
        fieldInUnit[0] = new Vector3(-(screenWidth / 2 - wallsMargins - pixelsInUnit) / pixelsInUnit, 0f, (fieldHeight / 2 - wallsMargins - pixelsInUnit) / pixelsInUnit);
        fieldInUnit[1] = new Vector3((screenWidth / 2 - wallsMargins - pixelsInUnit) / pixelsInUnit, 0f, (fieldHeight / 2 - wallsMargins - pixelsInUnit) / pixelsInUnit);
        fieldInUnit[2] = new Vector3((screenWidth / 2 - wallsMargins - pixelsInUnit) / pixelsInUnit, 0f, -(fieldHeight / 2 - wallsMargins - pixelsInUnit) / pixelsInUnit);
        fieldInUnit[3] = new Vector3(-(screenWidth / 2 - wallsMargins - pixelsInUnit) / pixelsInUnit, 0f, -(fieldHeight / 2 - wallsMargins - pixelsInUnit) / pixelsInUnit);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  float getPixelsInOneUnit() {
        return pixelsInUnit;
    }
    public static Vector3[] getFieldInUnits() {
        return fieldInUnit;
    }


}
