using UnityEngine;

namespace _Project.Runtime.Scripts.Utilities
{
    public static class CameraUtilities
    {
        private static Camera Cam => Camera.main;
        
        public static Rect GetCamWorldBoundingBox()
        {
            Vector2 min = Cam.ScreenToWorldPoint(Vector2.zero);
            Vector2 max = Cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            Vector2 size = max - min;
            
            return new Rect(min, size);
        }

        public static bool IsInsideCamWorldBoundingBox(Rect rect)
        {
            Rect camWorldRect = GetCamWorldBoundingBox();

            return rect.Overlaps(camWorldRect);
        }
    }
}
