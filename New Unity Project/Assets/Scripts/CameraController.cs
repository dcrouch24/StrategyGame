using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed;
    private float panDetect = 15f;

    public List<GameObject> selectedObjects = new List<GameObject>();
    public int selectedObjectsAmount = 0;
    private ObjectInfo selectedInfo;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();

        if(Input.GetMouseButtonDown(0))
        {
            LeftClick();
        }

        if(Input.GetMouseButtonDown(1))
        {
            
        }
    }

    void MoveCamera()
    {
        float moveX = gameObject.transform.position.x;
        float moveZ = gameObject.transform.position.z;
        float moveY = gameObject.transform.position.y;

        float xPos = Input.mousePosition.x;
        float yPos = Input.mousePosition.y;

        if(Input.GetKey(KeyCode.A) || xPos > 0 && xPos < panDetect)
        {
            moveX -= panSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || xPos < Screen.width && xPos > Screen.width - panDetect)
        {
            moveX += panSpeed;
        }

        if(Input.GetKey(KeyCode.W) || yPos < Screen.height && yPos > Screen.height - panDetect)
        {
            moveZ += panSpeed;
        }
        else if(Input.GetKey(KeyCode.S) || yPos > 0 && yPos < panDetect)
        {
            moveZ -= panSpeed;
        }

        Vector3 newPos = new Vector3(moveX, moveY, moveZ);

        Camera.main.transform.position = newPos;
    }

    public void LeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            
            if(hit.collider.tag == "Ground")
            {
                if (selectedObjectsAmount != 0)
                {
                    for (int i = 0; i < selectedObjects.Count; i++)
                    {
                        selectedInfo = selectedObjects[i].GetComponent<ObjectInfo>();
                        selectedInfo.isSelected = false;
                        selectedInfo.selectCircle.enabled = false;
                    }
                }
                selectedObjects.Clear();               
                Debug.Log("Deselected");
            }
            else if(hit.collider.tag == "Selectable")
            {
                if(selectedObjects.Contains(hit.collider.gameObject))
                {
                    return;
                }
                
                selectedObjects.Add(hit.collider.gameObject);
                selectedInfo = hit.collider.gameObject.GetComponent<ObjectInfo>();
                selectedObjectsAmount++;

                selectedInfo.isSelected = true;
                selectedInfo.selectCircle.enabled = true;
                Debug.Log("Unit Selected");

            }
        }
    }

    private bool findObject(GameObject[] objectList, GameObject target)
    {
        for(int i = 0; i < selectedObjectsAmount; i++)
        {
            if(objectList[i] == target)
            {
                return true;
            }
        }

        return false;
    }
}
