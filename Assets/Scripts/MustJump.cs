using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustJump : MonoBehaviour
{

    private bool canJump;
    private bool emptySpaceJump;
    private bool madeMove;
    private bool blueTurn;
    // private bool jumpedNE;
    // private bool jumpedNW;
    // private bool jumpedSE;
    // private bool jumpedSW;
    private bool checkerInSpace;
    private bool checkerInSpace1;
    private bool checkerInSpaceNE;
    private bool checkerInSpaceNW;
    private bool checkerInSpaceSE;
    private bool checkerInSpaceSW;
    private bool checkerInSpaceNE1;
    private bool checkerInSpaceNW1;
    private bool checkerInSpaceSE1;
    private bool checkerInSpaceSW1;
    private GameObject SetChecker;

    public float snapDistance;  
    public List<Transform> nodes = new List<Transform>();
    
    private Vector3 targetPosition;
    // private Vector3 targetStartPosition;
    private Vector3 startPosition;


    public LayerMask RaycastLayers;

    public GameObject RedChecker0;
    public GameObject RedChecker1;
    public GameObject RedChecker2;
    public GameObject RedChecker3;
    public GameObject RedChecker4;
    public GameObject RedChecker5;
    public GameObject RedChecker6;
    public GameObject RedChecker7;
    public GameObject RedChecker8;
    public GameObject RedChecker9;
    public GameObject RedChecker10;
    public GameObject RedChecker11;
    
    public GameObject BlueChecker0;
    public GameObject BlueChecker1;
    public GameObject BlueChecker2;
    public GameObject BlueChecker3;
    public GameObject BlueChecker4;
    public GameObject BlueChecker5;
    public GameObject BlueChecker6;
    public GameObject BlueChecker7;
    public GameObject BlueChecker8;
    public GameObject BlueChecker9;
    public GameObject BlueChecker10;
    public GameObject BlueChecker11;

    public GameObject BlueTurn;

    public GameObject StartPositionRay;
    public GameObject StartPositionRayNE;
    public GameObject StartPositionRayNW;
    public GameObject StartPositionRaySE;
    public GameObject StartPositionRaySW;

    public GameObject CompassNorth;
    public GameObject CompassSouth;
    public GameObject CompassEast;
    public GameObject CompassWest;
    public GameObject CompassNE;
    public GameObject CompassNW;
    public GameObject CompassSE;
    public GameObject CompassSW;
    public GameObject CompassCenter;

    // Start is called before the first frame update
    void Start()
    {
        madeMove = false;

        // jumpedNE = false;
        // jumpedNW = false;
        // jumpedSE = false;
        // jumpedSW = false;

        Vector3 dirNE = (CompassCenter.transform.position - CompassNE.transform.position);
        Vector3 dirNW = (CompassCenter.transform.position - CompassNW.transform.position);
        Vector3 dirSE = (CompassCenter.transform.position - CompassSE.transform.position);
        Vector3 dirSW = (CompassCenter.transform.position - CompassSW.transform.position);

        PlaceCheckers();
    }

    void PlaceCheckers() {

        

        Vector3 dirWest = (CompassCenter.transform.position - CompassWest.transform.position);

        RaycastHit hitChecker;

        RaycastHit hitChecker1;
        
        foreach (Transform node in nodes)
        {

            StartPositionRay.transform.position = node.position + new Vector3(-85.0f, 0.0f, 0.0f);



            Ray ray = new Ray(StartPositionRay.transform.position, dirWest);

            checkerInSpace = Physics.Raycast(ray, out hitChecker, 80, ((1<<6)));

            checkerInSpace1 = Physics.Raycast(ray, out hitChecker1, 80, ((1<<7)));

            if (checkerInSpace) {
                SetChecker = hitChecker.transform.gameObject;
            
                SetChecker.transform.position = node.position;

                checkerInSpace = false;
            } else if (checkerInSpace1) {
                SetChecker = hitChecker1.transform.gameObject;
            
                SetChecker.transform.position = node.position;

                checkerInSpace1 = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MustJumpMethod() {
        Vector3 compass = (CompassSouth.transform.position - CompassNorth.transform.position);

        Vector3 dirNE = (CompassCenter.transform.position - CompassNE.transform.position);
        Vector3 dirNW = (CompassCenter.transform.position - CompassNW.transform.position);
        Vector3 dirSE = (CompassCenter.transform.position - CompassSE.transform.position);
        Vector3 dirSW = (CompassCenter.transform.position - CompassSW.transform.position);

        blueTurn = BlueTurn.GetComponent<ColorTurn>().GetBlueTurn();

        RaycastHit[] hits0;
        RaycastHit[] hits1;
        RaycastHit[] hits2;
        RaycastHit[] hits3;
        RaycastHit[] hits4;
        RaycastHit[] hits5;
        RaycastHit[] hits6;
        RaycastHit[] hits7;

        // bool nearCheckerColor;
        // bool farCheckerColor;

        foreach (Transform node in nodes)
        {
            
            StartPositionRayNE.transform.position = node.position + new Vector3(85.0f, 85.0f, 0.0f);
            StartPositionRayNW.transform.position = node.position + new Vector3(-85.0f, 85.0f, 0.0f);
            StartPositionRaySE.transform.position = node.position + new Vector3(85.0f, -85.0f, 0.0f);
            StartPositionRaySW.transform.position = node.position + new Vector3(-85.0f, -85.0f, 0.0f);

            RaycastHit hitChecker;
            RaycastHit hitChecker1;
            RaycastHit hitChecker2;
            RaycastHit hitChecker3;
            RaycastHit hitChecker4;
            RaycastHit hitChecker5;
            RaycastHit hitChecker6;
            RaycastHit hitChecker7;

            GameObject hitCheckerGO;
            GameObject hitCheckerGO1;
            GameObject hitCheckerGO2;
            GameObject hitCheckerGO3;

            GameObject hitCheckerGO4;
            GameObject hitCheckerGO5;
            GameObject hitCheckerGO6;
            GameObject hitCheckerGO7;


            Ray rayNE = new Ray(StartPositionRayNE.transform.position, dirSW);
            Ray rayNW = new Ray(StartPositionRayNW.transform.position, dirSE);
            Ray raySE = new Ray(StartPositionRaySE.transform.position, dirNW);
            Ray raySW = new Ray(StartPositionRaySW.transform.position, dirNE);

            Ray rayClear = new Ray(CompassCenter.transform.position, dirNE);

            Debug.Log("foreach ran");

            if (blueTurn) {
                
                hits0 = Physics.RaycastAll(rayNE, 385);
                hits1 = Physics.RaycastAll(rayNW, 385);
                hits2 = Physics.RaycastAll(raySE, 385);
                hits3 = Physics.RaycastAll(raySW, 300);

                hits4 = Physics.RaycastAll(rayNE, 120);
                hits5 = Physics.RaycastAll(rayNW, 120);
                hits6 = Physics.RaycastAll(raySE, 120);
                hits7 = Physics.RaycastAll(raySW, 120);

                // hitChecker = hits4[0];
                // hitChecker1 = hits5[0];
                // hitChecker2 = hits6[0];
                // hitChecker3 = hits7[0];

                // hitChecker4 = hits4[1];
                // hitChecker5 = hits5[1];
                // hitChecker6 = hits6[1];
                // hitChecker7 = hits7[1];

                hitCheckerGO = hits4[0].transform.gameObject;
                hitCheckerGO1 = hits5[0].transform.gameObject;
                hitCheckerGO2 = hits6[0].transform.gameObject;
                hitCheckerGO3 = hits7[0].transform.gameObject;

                hitCheckerGO4 = hits4[1].transform.gameObject;
                hitCheckerGO5 = hits5[1].transform.gameObject;
                hitCheckerGO6 = hits6[1].transform.gameObject;
                hitCheckerGO7 = hits7[1].transform.gameObject;

                

                if ((hitCheckerGO.GetComponent<LayerMask>() == (1<<7) && (hits4.Length == 2) && hitCheckerGO4.GetComponent<LayerMask>() == (1<<6)) ||
                    (hitCheckerGO1.GetComponent<LayerMask>() == (1<<7) && (hits5.Length == 2) && hitCheckerGO5.GetComponent<LayerMask>() == (1<<6)) ||
                    (hitCheckerGO2.GetComponent<LayerMask>() == (1<<7) && (hits6.Length == 2) && hitCheckerGO6.GetComponent<LayerMask>() == (1<<6)) ||
                    (hitCheckerGO3.GetComponent<LayerMask>() == (1<<7) && (hits7.Length == 2) && hitCheckerGO7.GetComponent<LayerMask>() == (1<<6))) 
                    {
                        emptySpaceJump = true;

                        hits0 = Physics.RaycastAll(rayClear, 385);
                        hits1 = Physics.RaycastAll(rayClear, 385);
                        hits2 = Physics.RaycastAll(rayClear, 385);
                        hits3 = Physics.RaycastAll(rayClear, 385);

                        hits4 = Physics.RaycastAll(rayClear, 385);
                        hits5 = Physics.RaycastAll(rayClear, 385);
                        hits6 = Physics.RaycastAll(rayClear, 385);
                        hits7 = Physics.RaycastAll(rayClear, 385);
                    }
            
            } else if (!blueTurn) {
                
                hits0 = Physics.RaycastAll(rayNE, 385);
                hits1 = Physics.RaycastAll(rayNW, 385);
                hits2 = Physics.RaycastAll(raySE, 385);
                hits3 = Physics.RaycastAll(raySW, 300);

                hits4 = Physics.RaycastAll(rayNE, 120);
                hits5 = Physics.RaycastAll(rayNW, 120);
                hits6 = Physics.RaycastAll(raySE, 120);
                hits7 = Physics.RaycastAll(raySW, 120);

                // hitChecker = hits4[0];
                // hitChecker1 = hits5[0];
                // hitChecker2 = hits6[0];
                // hitChecker3 = hits7[0];

                // hitChecker4 = hits4[1];
                // hitChecker5 = hits5[1];
                // hitChecker6 = hits6[1];
                // hitChecker7 = hits7[1];

                // if (hits4[0] != null) {
                //     hitCheckerGO = hits4[0].transform.gameObject;
                // } else if (hits5[0] != null) {
                //     hitCheckerGO1 = hits5[0].transform.gameObject;
                // } else if (hits6[0] != null) {
                //     hitCheckerGO2 = hits6[0].transform.gameObject;
                // } else if (hits7[0] != null) {
                //     hitCheckerGO3 = hits7[0].transform.gameObject;
                // } 
                
                // if (hits4[1] != null) {
                //     hitCheckerGO4 = hits4[1].transform.gameObject;
                // } else if (hits5[1] != null) {
                //     hitCheckerGO5 = hits5[1].transform.gameObject;
                // } else if (hits6[1] != null) {
                //     hitCheckerGO6 = hits6[1].transform.gameObject;
                // } else if (hits7[1] != null) {
                //     hitCheckerGO7 = hits7[1].transform.gameObject;
                // } 

                // if ((hitCheckerGO.GetComponent<LayerMask>() == (1<<7) && (hits4.Length == 2) && hitCheckerGO4.GetComponent<LayerMask>() == (1<<6)) ||
                //     (hitCheckerGO1.GetComponent<LayerMask>() == (1<<7) && (hits5.Length == 2) && hitCheckerGO5.GetComponent<LayerMask>() == (1<<6)) ||
                //     (hitCheckerGO2.GetComponent<LayerMask>() == (1<<7) && (hits6.Length == 2) && hitCheckerGO6.GetComponent<LayerMask>() == (1<<6)) ||
                //     (hitCheckerGO3.GetComponent<LayerMask>() == (1<<7) && (hits7.Length == 2) && hitCheckerGO7.GetComponent<LayerMask>() == (1<<6))) 
                //     {
                //         emptySpaceJump = true;

                //         hits0 = Physics.RaycastAll(rayClear, 385);
                //         hits1 = Physics.RaycastAll(rayClear, 385);
                //         hits2 = Physics.RaycastAll(rayClear, 385);
                //         hits3 = Physics.RaycastAll(rayClear, 385);

                //         hits4 = Physics.RaycastAll(rayClear, 385);
                //         hits5 = Physics.RaycastAll(rayClear, 385);
                //         hits6 = Physics.RaycastAll(rayClear, 385);
                //         hits7 = Physics.RaycastAll(rayClear, 385);
                //     }


            }

        }

    }


        
    
    

    public void SetMadeMove(bool madeMoveChecker) {

        madeMove = madeMoveChecker;
    }

    public bool GetMadeMove() {
        return madeMove;
    }

    public void SetEmptySpace(bool emptySpaceChecker) {

        emptySpaceJump = emptySpaceChecker;
    }

    public bool GetEmptySpace() {
        return emptySpaceJump;
    }

    public void SetCanJump(bool canJumpChecker) {

        canJump = canJumpChecker;
    }

    public bool GetCanJump() {
        return canJump;
    }
}
