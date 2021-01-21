using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Selection : MonoBehaviour
{
   //обьявляем переменную для луча
    RaycastHit hit;
    Ray MyRay;
    string Object_Tag;
    GameObject Object;
    public GameObject Cube;
    public GameObject Sphere;
    public GameObject Capsule;
    GameObject New_Element;

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            MyRay=Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(MyRay.origin, MyRay.direction*10,Color.yellow);
            if(Physics.Raycast(MyRay, out hit,100))
            {
                Object_Tag = hit.collider.tag;
                if (Object_Tag == "obj1")
                {                   
                Object = hit.collider.gameObject; 
                Debug.Log(hit.collider.name);          
                }
            }

        }
        

    }
    
    void OnClick_Color(GameObject obj, Color col){
        obj.GetComponent<Renderer>().material.color = col;
    }
    public void OnClick_Red(){
        OnClick_Color(Object, Color.red);
    }
    public void OnClick_Green(){
        OnClick_Color(Object, Color.green);
    }
    public void OnClick_Blue(){
        OnClick_Color(Object, Color.blue);
    }
    
    void OnClick_Transform(GameObject prefab){
            New_Element = (GameObject)Instantiate(prefab);
            New_Element.transform.parent = Object.transform.parent;
            New_Element.transform.position = Object.transform.position;
            New_Element.transform.localScale = Object.transform.localScale;
            New_Element.tag = Object_Tag;
            if (Object.GetComponent<Renderer>().material.color == Color.red)
                OnClick_Color(New_Element, Color.red);
            if (Object.GetComponent<Renderer>().material.color == Color.green)
                OnClick_Color(New_Element, Color.green);
            if (Object.GetComponent<Renderer>().material.color == Color.blue)
                OnClick_Color(New_Element, Color.blue);
            Destroy(Object);
            Object = New_Element;

    }
    public void OnClick_Cube(){
        OnClick_Transform(Cube);
    }
    public void OnClick_Sphere(){
        OnClick_Transform(Sphere);
    }
    public void OnClick_Capsule(){
        OnClick_Transform(Capsule);
    }
}

