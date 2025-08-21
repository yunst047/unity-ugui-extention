using UnityEngine;
using UnityEngine.UI;
namespace Yunst.UGUI.Extension
{
    public static class RectTransformExtensions
    {
        public static void SetAnchorMinMax(this RectTransform rectTransform, Vector2 anchorMin, Vector2 anchorMax)
        {
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }

        public static void SetSize(this RectTransform rectTransform, Vector2 size)
        {
            rectTransform.sizeDelta = size;
        }

        public static void SetPivot(this RectTransform rectTransform, Vector2 pivot)
        {
            rectTransform.pivot = pivot;
        }

        public static void SetAnchoredPosition(this RectTransform rectTransform, Vector2 position)
        {
            rectTransform.anchoredPosition = position;
        }

        public static void SetPosition(this RectTransform rectTransform, Vector3 position)
        {
            rectTransform.position = position;
        }

        public static void SetLocalPosition(this RectTransform rectTransform, Vector3 localPosition)
        {
            rectTransform.localPosition = localPosition;
        }

        public static void SetLocalScale(this RectTransform rectTransform, Vector3 localScale)
        {
            rectTransform.localScale = localScale;
        }
        
        public static void SetLocalScale(this RectTransform rectTransform, float scale)
        {
            rectTransform.localScale = new Vector3(scale, scale, scale);
        }

        public static void SetLocalScale(this RectTransform rectTransform, Vector3 localScale, bool preserveAspect)
        {
            if (preserveAspect)
            {
                float aspectRatio = rectTransform.rect.width / rectTransform.rect.height;
                localScale.y = localScale.x / aspectRatio;
            }

            rectTransform.localScale = localScale;
        }

        public static void SetRotation(this RectTransform rectTransform, Quaternion rotation)
        {
            rectTransform.rotation = rotation;
        }

        public static void SetWidth(this RectTransform rectTransform, float width)
        {
            rectTransform.SetSize(new Vector2(width, rectTransform.sizeDelta.y));
        }

        public static void SetHeight(this RectTransform rectTransform, float height)
        {
            rectTransform.SetSize(new Vector2(rectTransform.sizeDelta.x, height));
        }



    }
}
