using UnityEngine;

public class OutlineObserver : MonoBehaviour
{
    private IOutlineObject currentOutlineObject;
    [SerializeField]
    private Camera camera;

    private void Update()
    {
        if (currentOutlineObject != null)
        {
            currentOutlineObject.SetOutlineEnabled(false);
        }

        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = camera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            IOutlineObject newOutlineObject = hit.collider.gameObject.GetComponent<IOutlineObject>();
            if (newOutlineObject != null)
            {
                newOutlineObject.SetOutlineEnabled(true);
                currentOutlineObject = newOutlineObject;
            }
        }
    }
}

