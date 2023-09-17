using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GetCameraColor : MonoBehaviour
{
    public Camera cameraToUse; // The camera you want to get the image from
    private Texture2D imageTexture; // Texture to store the camera image

    [SerializeField] private Image panel;

    private void Start()
    {
        // Create the texture with the size of the screen
        imageTexture = new Texture2D(Screen.width, Screen.height);
    }

    private Color GetMiddlePixelColor()
    {
        int middleX = imageTexture.width / 2;
        int middleY = imageTexture.height / 2;
        return imageTexture.GetPixel(middleX, middleY);
    }

    public Color ChangeColor()
    {
        Color currentColor = Color.white;
        // Get the camera image
        if (cameraToUse.isActiveAndEnabled)
        {
            cameraToUse.Render();
            RenderTexture.active = cameraToUse.targetTexture;
            imageTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            imageTexture.Apply();

            // Get the color of the middle pixel
            currentColor = GetMiddlePixelColor();

            // Use the middle pixel color as you like

            //panel.color = middlePixelColor;
            // ...
            return currentColor;
        }else
        {
            currentColor = Color.blue;
        }

        return currentColor;
    }

}