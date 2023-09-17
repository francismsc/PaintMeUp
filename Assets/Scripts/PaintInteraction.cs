using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintInteraction : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    public bool Paint(Color currentColor)
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = camera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.CompareTag("Paintable"))
            {


                hit.transform.gameObject.GetComponent<Renderer>().material.color = currentColor;
                return true;
            }
        }else
        {
            return false;
        }
        return false;
    }
}
