using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    
    [SerializeField]
    private Camera GameCamera;

    private Animal m_Selected = null;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            HandleSelection();
        }
    }

    void HandleSelection(){
        Ray ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            if (hit.collider.gameObject.GetComponent<Animal>()){
                //hit.collider.gameObject.GetComponent<A>().Select();
                SelectedAnimal=hit.collider.gameObject.GetComponent<Animal>();
                
            }
        }
    }

    private Animal SelectedAnimal{
        get{
            return m_Selected;
        }
        set{
            if (m_Selected!=value){
                if (m_Selected!=null){
                    m_Selected.isSelected=false;
                }
                m_Selected=value;
                if (m_Selected!=null){
                    m_Selected.isSelected=true;
                }
            }
        }
    }
}
