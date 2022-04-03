using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ViewingVolume : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float sceneWidth = 10f;

    private void Awake()
    {
        float unitsPerPixel = sceneWidth / Screen.width;
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
        camera.orthographicSize = desiredHalfHeight;
    }
}