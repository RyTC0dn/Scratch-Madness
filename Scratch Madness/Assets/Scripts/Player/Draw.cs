using UnityEngine;
using UnityEngine.InputSystem;

public class Draw : MonoBehaviour
{

    public Camera cam;
    public GameObject brush;

    private LineRenderer lineRenderer;

    Vector2 lastPos;

    private void Update(){
        DrawMechanic();
    }

    private void DrawMechanic(){
        NewControls();
    }

    private void NewControls(){
        if(Mouse.current.leftButton.wasPressedThisFrame){
            CreateBrush();
            Debug.Log("Mouse button pressed");
        }
        if(Mouse.current.leftButton.isPressed){
            Vector2 mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            if(mousePos != lastPos){
                AddAPoint(mousePos);
            }
            lastPos = mousePos;
            Debug.Log("Point added");
        }
        else{
            lineRenderer = null;
        }
    }

    private void LegacyControls(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            CreateBrush();
            Debug.Log("Mouse button pressed");
        }
        if(Input.GetKey(KeyCode.Mouse0)){
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos != lastPos){
                AddAPoint(mousePos);
                lastPos = mousePos;
                Debug.Log("Point added");
            }          
            
        }
        else{
            lineRenderer = null;
        }
    }

    private void CreateBrush(){

        GameObject brushInstance = Instantiate(brush);
        lineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //sets the position of the line renderer to the mouse position
        lineRenderer.SetPosition(0, mousePos);
        lineRenderer.SetPosition(1, mousePos);

        if(lineRenderer != null){
            Debug.Log("Line renderer created");
        }else{
            Debug.Log("Line renderer not created");
        }
    }

    private void AddAPoint(Vector2 pointPos){
        //adds a point to the line renderer
        lineRenderer.positionCount++;
        int positionIndex = lineRenderer.positionCount - 1;
        lineRenderer.SetPosition(positionIndex, pointPos);
    }
}
