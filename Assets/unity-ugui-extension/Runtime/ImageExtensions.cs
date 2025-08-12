using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Yunst.UGUI.Extension
{
    public static class ImageExtensions
    {
    /// <summary>
    /// Sets the color of the image instantly.
    /// </summary>
    /// <param name="image">The image to set the color for.</param>
    /// <param name="color">The color to set.</param>
    public static void SetColor(this Image image, Color color)
        {
            if (image == null) return;
            image.color = color;
        }

    /// <summary>
    /// Sets the alpha of the image instantly.
    /// </summary>
    /// <param name="image">The image to set the alpha for.</param>
    /// <param name="alpha">The alpha value to set.</param>
    public static void SetAlpha(this Image image, float alpha)
        {
            if (image == null) return;
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }


    /// <summary>
    /// Smoothly changes the image color to the target color over the given duration.
    /// </summary>
    /// <param name="targetColor">Target color.</param>
    /// <param name="duration">Duration of the transition in seconds.</param>
    public static void SetToColorInGivenTime(this Image image, Color targetColor, float duration)
        {
            if (image == null) return;
            image.StartCoroutine(ChangeColorCoroutine(image, targetColor, duration));
        }

    /// <summary>
    /// Smoothly changes the image color to the specified RGBA values over the given duration.
    /// </summary>
    /// <param name="r">Red component.</param>
    /// <param name="g">Green component.</param>
    /// <param name="b">Blue component.</param>
    /// <param name="a">Alpha component.</param>
    /// <param name="duration">Duration of the transition in seconds.</param>
    public static void SetToColorInGivenTime(this Image image, float r, float g, float b, float a, float duration)
        {
            if (image == null) return;
            Color targetColor = new Color(r, g, b, a);
            image.StartCoroutine(ChangeColorCoroutine(image, targetColor, duration));
        }

    /// <summary>
    /// Smoothly changes the image color to the target color and alpha over the given duration.
    /// </summary>
    /// <param name="targetColor">Target color.</param>
    /// <param name="alpha">Alpha value.</param>
    /// <param name="duration">Duration of the transition in seconds.</param>
    public static void SetToColorInGivenTime(this Image image, Color targetColor, float alpha, float duration)
        {
            if (image == null) return;
            Color newTargetColor = new Color(targetColor.r, targetColor.g, targetColor.b, alpha);
            image.StartCoroutine(ChangeColorCoroutine(image, newTargetColor, duration));
        }


        private static IEnumerator ChangeColorCoroutine(Image image, Color targetColor, float duration)
        {
            Color startColor = image.color;
            float time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                float t = Mathf.Clamp01(time / duration);
                image.color = Color.Lerp(startColor, targetColor, t);
                yield return null;
            }
            image.color = targetColor;
        }

        /// <summary>
        /// Smoothly changes the Image alpha to the target alpha over the given duration.
        /// Do not call at the same time as SetToColorInGivenTime, as they will conflict.
        /// </summary>
        /// <param name="targetAlpha">Target alpha.</param>
        /// <param name="duration">Duration of the transition.</param>
        public static void SetToAlphaInGivenTime(this Image image, float targetAlpha, float duration)
        {
            if (image == null) return;
            image.StartCoroutine(ChangeAlphaCoroutine(image, targetAlpha, duration));
        }

        private static IEnumerator ChangeAlphaCoroutine(Image image, float targetAlpha, float duration)
        {
            Color startColor = image.color;
            float time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                float t = Mathf.Clamp01(time / duration);
                image.color = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, targetAlpha), t);
                yield return null;
            }
            image.color = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);
        }

        /// <summary>
        /// Makes the image blink by changing its alpha over the given duration.
        /// <br/>Overloads:
        /// <br/>BlinkingAlpha(float duration, int blinkCount)
        /// <br/>BlinkingAlpha(float duration) // Default blink count is 3
        /// </summary>
        /// <param name="duration">Duration of the blink.</param>
        /// <param name="blinkCount">Number of blinks.</param>
        public static void BlinkingAlpha(this Image image, float duration, int blinkCount)
        {
            if (image == null) return;
            image.StartCoroutine(BlinkingAlphaCoroutine(image, duration, blinkCount));
        }

        public static void BlinkingAlpha(this MonoBehaviour monoBehaviour, Image image, float duration)
        {
            BlinkingAlpha(image, duration, 3); // Default blink count is 3
        }

        private static IEnumerator BlinkingAlphaCoroutine(Image image, float duration, int blinkCount)
        {
            float halfDuration = duration / (blinkCount * 2);
            for (int i = 0; i < blinkCount; i++)
            {
                // Fade out
                yield return ChangeAlphaCoroutine(image, 0f, halfDuration);
                // Fade in
                yield return ChangeAlphaCoroutine(image, 1f, halfDuration);
            }
        }

        /// <summary>
        /// Fills the image over the given duration.
        /// </summary>
        /// <param name="fillMethod">Fill method to use.</param>
        /// <param name="duration">Duration of the fill.</param>
        public static void FillImageInGivenTime(this Image image, Image.FillMethod fillMethod, float duration)
        {
            if (image == null) return;
            if (image.type != Image.Type.Filled)
            {
                Debug.LogWarning("Image type must be 'Filled' to use FillImageInGivenTime.");
                return;
            }
            image.StartCoroutine(FillImageCoroutine(image, fillMethod, duration));
        }

        private static IEnumerator FillImageCoroutine(Image image, Image.FillMethod fillMethod, float duration)
        {
            if (image == null) yield break;

            float time = 0f;
            float startFillAmount = image.fillAmount;
            float targetFillAmount = fillMethod == Image.FillMethod.Horizontal ? 1f : 0f;

            while (time < duration)
            {
                time += Time.deltaTime;
                float t = Mathf.Clamp01(time / duration);
                image.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, t);
                yield return null;
            }

            image.fillAmount = targetFillAmount;
        }
    }
}
