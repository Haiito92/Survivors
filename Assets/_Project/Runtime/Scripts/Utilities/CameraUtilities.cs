using UnityEngine;

public static class CameraUtilities
{
    public static Rect GetCamWorldBoundingBox()
    {
        Camera cam = Camera.main;

        Vector2 min = cam.ScreenToWorldPoint(Vector2.zero);
        Vector2 max = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Vector2 size = max - min;

        return new Rect(min, size);
    }
}
