using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed;
    private float panDetect = 15f;

    public GameObject selectedObject;
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
                if (selectedObject != null) selectedInfo.isSelected = false;
                selectedObject = null;                
                Debug.Log("Deselected");
            }
            else if(hit.collider.tag == "Selectable")
            {
                selectedObject = hit.collider.gameObject;
                selectedInfo = selectedObject.GetComponent<ObjectInfo>();

                selectedInfo.isSelected = true;
                Debug.Log("Unit Selected");

            }
        }
    }
}
