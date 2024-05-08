using System.Collections;
using UnityEngine;

public class PhotoCamera : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private GameObject photoPlane; // Reference to the 3D plane
    [SerializeField] private Camera photoCamera; // Reference to the separate camera
    [SerializeField] private Shader brightenShader; // Reference to the brighten shader

    private RenderTexture renderTexture;

    private void Start()
    {
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        photoCamera.targetTexture = renderTexture; // Set the render texture as the target texture for the separate camera
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CapturePhoto());
        }
    }

    private IEnumerator CapturePhoto()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture.active = renderTexture;
        Texture2D screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenCapture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenCapture.Apply();
        RenderTexture.active = null;

        ShowPhoto(screenCapture);
    }

    private void ShowPhoto(Texture2D texture)
    {
        // Create a new material with the brighten shader
        Material photoMaterial = new Material(brightenShader);
        photoMaterial.SetTexture("_MainTex", texture);
        photoMaterial.SetFloat("_Brightness", 1.5f); // Adjust brightness here

        // Assign the material to the photo plane's mesh renderer
        MeshRenderer planeRenderer = photoPlane.GetComponent<MeshRenderer>();
        planeRenderer.material = photoMaterial;
    }
}
