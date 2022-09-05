using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerMovement1 : MonoBehaviour
{
    public GameObject Sprite;
    public GameObject ColorTurn;
    public GameObject Graveyard;
    public Sprite kingSprite;

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

    public float snapDistance;
    public List<Transform> nodes = new List<Transform>();
    
    private Vector3 targetPosition;
    private Vector3 targetStartPosition;
    private Vector3 startPosition;
    private int nodeInt;
    private int nodeInt1;

    private bool jumped;
    private bool blueTurn;
    private bool blueCheck;
    private bool king;
    private bool travelForward;
    private bool canJump;
    private bool mustJump;
    private bool madeMove;
    private bool emptySpaceChecker;
    private bool checkerInSpace;

    public LayerMask RaycastLayers;
    private RaycastHit hit;

    public GameObject CompassNorth;
    public GameObject CompassSouth;
    
    public GameObject MustJumpGO;


    void Start() {
        king = false;
    }

    
    void OnMouseDrag() {
        
        
        targetPosition = Input.mousePosition;
        transform.position = targetPosition;

        
     }

    void OnMouseDown() {

        targetStartPosition = Sprite.transform.position;
        blueTurn = ColorTurn.GetComponent<ColorTurn>().GetBlueTurn();
        
        


        if (Sprite.layer == 7) {
            blueCheck = true;
        } else if (Sprite.layer == 6) {
            blueCheck = false;
        }

        
    }

        

                
   

    void OnMouseUp()
    {


        MustJumpGO.GetComponent<MustJump>().MustJumpMethod();

        emptySpaceChecker = MustJumpGO.GetComponent<MustJump>().GetEmptySpace();

        // Debug.Log(Vector3.Distance(targetStartPosition, targetPosition));

        Vector3 compass = (CompassSouth.transform.position - CompassNorth.transform.position);
        targetPosition = Input.mousePosition;

        RaycastHit hitChecker;

        jumped = Physics.Linecast(targetStartPosition, targetPosition, out hitChecker, RaycastLayers);

        Vector3 dir = (targetStartPosition - targetPosition);
        
        float dirAngle = Vector3.Angle(dir, compass);

        Debug.Log(blueCheck + " : " + blueTurn + " : " + dirAngle);
        

        if (blueCheck) {
            RaycastLayers = (1 << 6);
        } else {
            RaycastLayers = (1 << 7);
        }
        float smallestDistance = snapDistance;

        

        if (blueCheck && blueTurn && dirAngle > 90) {
            travelForward = true;
        } else if (!blueCheck && !blueTurn && dirAngle < 90) {
            travelForward = true;
        } else {
            travelForward = false;
        }

        if ((blueCheck && blueTurn && travelForward) || (!blueCheck && !blueTurn && travelForward)
            || (blueCheck && blueTurn && king) || (!blueCheck && !blueTurn && king)) {

            foreach (Transform node in nodes)
        {
            nodeInt++;

            
                if ( !emptySpaceChecker && Vector3.Distance(node.position, targetPosition) < smallestDistance &&
                    Vector3.Distance(targetStartPosition, targetPosition) < 140.0f
                    && Vector3.Distance(targetStartPosition, targetPosition) > 70.0f
                    )
                {
                    if (((dirAngle >= 22.5 && dirAngle <= 77.5)
                        || (dirAngle >= 112.5 && dirAngle <= 157.5)))
                        {

                        if (emptySpaceChecker) {
                            // Debug.Log("If canJump " + canJump);
                            transform.position = targetStartPosition;
                            Debug.Log("else if final ---1");
                            break;
                        } 

                        transform.position = node.position;

                        if ((!blueCheck && ((node.position == nodes[0].transform.position) || 
                                    (node.position == nodes[4].transform.position) || 
                                    (node.position == nodes[8].transform.position) || 
                                    (node.position == nodes[12].transform.position)))
                                    ||
                                    (blueCheck && ((node.position == nodes[31].transform.position) || 
                                    (node.position == nodes[27].transform.position) || 
                                    (node.position == nodes[23].transform.position) || 
                                    (node.position == nodes[19].transform.position)))) {
                                        king = true;
                                        Sprite.GetComponent<SpriteRenderer>().sprite = kingSprite;
                                    }

                        if (blueTurn == true) {
                            ColorTurn.GetComponent<ColorTurn>().blueTurn = false;
                        } else {
                            ColorTurn.GetComponent<ColorTurn>().blueTurn = true;
                        }
                        Debug.Log("else if final --2");
                        Debug.Log(node.transform.gameObject);
                        break;
                    } else {
                        transform.position = targetStartPosition;
                        Debug.Log("else if final --1");
                        break;
                    }
                } 
                else if (Vector3.Distance(node.position, targetPosition) < smallestDistance
                            && Vector3.Distance(targetStartPosition, targetPosition) >= smallestDistance * 2.7f 
                            && Vector3.Distance(targetStartPosition, targetPosition) <= 240)
                            {
                        emptySpaceChecker = MustJumpGO.GetComponent<MustJump>().GetEmptySpace();
                        if ((dirAngle >= 22.5 && dirAngle <= 77.5)
                            || (dirAngle >= 112.5 && dirAngle <= 157.5)) {
                            if (emptySpaceChecker && jumped && 
                                Vector3.Distance(node.position, targetPosition) < smallestDistance) {
                                GameObject destroy = hitChecker.transform.gameObject;
                                destroy.transform.position = Graveyard.transform.position;
                                destroy.SetActive(false);
                                transform.position = node.position;
                                if ((!blueCheck && ((node.position == nodes[0].transform.position) || 
                                    (node.position == nodes[4].transform.position) || 
                                    (node.position == nodes[8].transform.position) || 
                                    (node.position == nodes[12].transform.position)))
                                    ||
                                    (blueCheck && ((node.position == nodes[31].transform.position) || 
                                    (node.position == nodes[27].transform.position) || 
                                    (node.position == nodes[23].transform.position) || 
                                    (node.position == nodes[19].transform.position)))) {
                                        king = true;
                                        Sprite.GetComponent<SpriteRenderer>().sprite = kingSprite;
                                    }
                                jumped = false;
                                if (blueTurn == true) {
                                    ColorTurn.GetComponent<ColorTurn>().blueTurn = false;
                                } else {
                                    ColorTurn.GetComponent<ColorTurn>().blueTurn = true;
                                }
                                Debug.Log("else if final -3");
                                break;
                            } 
                            else if (!jumped && Vector3.Distance(node.position, targetPosition) < smallestDistance) {
                                transform.position = targetStartPosition;
                                Debug.Log("else if final -2");
                                break;
                            } else if (!jumped && Vector3.Distance(node.position, targetPosition) > smallestDistance) {
                                transform.position = targetStartPosition;
                                Debug.Log("else if final -1");
                                break;
                            }
                        } else {
                            transform.position = targetStartPosition;
                            Debug.Log("else final");
                            break;
                        }
                        
                    
                    
                } 
                    else if (Vector3.Distance(targetStartPosition, targetPosition) > 240){
                    transform.position = targetStartPosition;
                    Debug.Log("else if final");
                    break;

                }

                
            }

            


        } else {
            transform.position = targetStartPosition;
        }

    }

}