using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

namespace Yunst.UGUI.Extension
{
    public static class TMPExtensions
    {
        
        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="text">The text to display.</param>
        public static void SetTMPText(this TextMeshProUGUI textMeshPro, string text)
        {
            if (textMeshPro == null) return;
            textMeshPro.SetText(text);
        }
        
        /// <summary>
        /// Sets the text and font size.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fontSize">The font size to set.</param>
        public static void SetTMPText(this TextMeshProUGUI textMeshPro, string text, float fontSize)
        {
            if (textMeshPro == null) return;
            textMeshPro.SetText(text);
            textMeshPro.fontSize = fontSize;
        }
        
        /// <summary>
        /// Sets the text and rich text option.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="richText">Whether to enable rich text.</param>
        public static void SetTMPText(this TextMeshProUGUI textMeshPro, string text, bool richText)
        {
            if (textMeshPro == null) return;
            textMeshPro.SetText(text);
            textMeshPro.richText = richText;
        }
        
        /// <summary>
        /// Sets the text, font size, and rich text option.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fontSize">The font size to set.</param>
        /// <param name="richText">Whether to enable rich text.</param>
        public static void SetTMPText(this TextMeshProUGUI textMeshPro, string text, float fontSize, bool richText)
        {
            if (textMeshPro == null) return;
            textMeshPro.SetText(text);
            textMeshPro.fontSize = fontSize;
            textMeshPro.richText = richText;
        }



        /// <summary>
        /// Sets the color of the text.
        /// </summary>
        /// <param name="color">The color to set.</param>
        public static void SetColor(this TextMeshProUGUI textMeshPro, Color color)


        {
            if (textMeshPro == null) return;
            textMeshPro.color = color;
        }

        /// <summary>
        /// Sets the alpha of the text.
        /// </summary>
        /// <param name="alpha">The alpha value to set.</param>
        public static void SetAlpha(this TextMeshProUGUI textMeshPro, float alpha)

        {
            if (textMeshPro == null) return;
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;
        }
        /// <summary>
        /// Sets the text and color.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="color">The color to set.</param>
        public static void SetTextWithColor(this TextMeshProUGUI textMeshPro, string message, Color color)
        {
            if (textMeshPro == null) return;
            textMeshPro.SetText(message);
            textMeshPro.color = color;
        }

        /// <summary>
        /// Sets the text, color, and font size.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="color">The color to set.</param>
        /// <param name="fontSize">The font size to set.</param>
        public static void SetTextWithColor(this TextMeshProUGUI textMeshPro, string message, Color color, float fontSize)
        {
            if (textMeshPro == null) return;
            textMeshPro.SetText(message);
            textMeshPro.color = color;
            textMeshPro.fontSize = fontSize;
        }

        /// <summary>
        /// Sets the text, color, and rich text option.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="color">The color to set.</param>
        /// <param name="richText">Whether to enable rich text.</param>
        public static void SetTextWithColor(this TextMeshProUGUI textMeshPro, string message, Color color, bool richText)
        {
            if (textMeshPro == null) return;
            textMeshPro.SetText(message);
            textMeshPro.color = color;
            textMeshPro.richText = richText;
        }

        /// <summary>
        /// Sets the text, color, font size, and rich text option.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="color">The color to set.</param>
        /// <param name="fontSize">The font size to set.</param>
        /// <param name="richText">Whether to enable rich text.</param>
        public static void SetTextWithColor(this TextMeshProUGUI textMeshPro, string message, Color color, float fontSize, bool richText)
        {
            if (textMeshPro == null) return;
            textMeshPro.SetText(message);
            textMeshPro.color = color;
            textMeshPro.fontSize = fontSize;
            textMeshPro.richText = richText;
        }
        



        /// <summary>
        /// Smoothly changes the color to the target color over the given duration.
        /// </summary>
        /// <param name="targetColor">The target color.</param>
        /// <param name="duration">Duration of the transition in seconds.</param>
        public static void SetToColorInGivenTime(this TextMeshProUGUI textMeshPro, Color targetColor, float duration)


        {
            if (textMeshPro == null) return;
            textMeshPro.StartCoroutine(ChangeColorCoroutine(textMeshPro, targetColor, duration));
        }

        private static IEnumerator ChangeColorCoroutine(TextMeshProUGUI textMeshPro, Color targetColor, float duration)
        {
            if (textMeshPro == null) yield break;

            Color initialColor = textMeshPro.color;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                textMeshPro.color = Color.Lerp(initialColor, targetColor, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            textMeshPro.color = targetColor;
        }

        /// <summary>
        /// Shows the text for a given duration, then hides it.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="duration">Duration to show the text in seconds.</param>
        public static void SetTextAppearanceWithDuration(this TextMeshProUGUI textMeshPro, string message, float duration = 2f)

        {
            if (textMeshPro == null) return;
            textMeshPro.text = message;
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.StartCoroutine(HideAfterDuration(textMeshPro, duration));
        }

        private static IEnumerator HideAfterDuration(TextMeshProUGUI textMeshPro, float duration)
        {
            yield return new WaitForSeconds(duration);
            textMeshPro.gameObject.SetActive(false);
        }
        /// <summary>
        /// Animates the text to appear one character at a time, like a typing effect.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="delay">Delay between each character in seconds.</param>
        public static void TypingCharacterAnim(this TextMeshProUGUI textMeshPro, string message, float delay = 0.1f)
        {
            if (textMeshPro == null) return;
            textMeshPro.text = string.Empty;
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.StartCoroutine(TypeText(textMeshPro, message, delay));
        }

        /// <summary>
        /// Animates the text to appear one character at a time, with rich text option.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="delay">Delay between each character in seconds.</param>
        /// <param name="richText">Whether the text is rich text.</param>
        public static void TypingCharacterAnim(this TextMeshProUGUI textMeshPro, string message, float delay, bool richText)
        {
            if (textMeshPro == null) return;
            textMeshPro.text = string.Empty;
            textMeshPro.richText = richText;
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.StartCoroutine(TypeText(textMeshPro, message, delay));
        }

        /// <summary>
        /// Adds a typing character animation to the text.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="delay">Delay between each character in seconds.</param>
        public static void AddingTypingCharacterAnim(this TextMeshProUGUI textMeshPro, string message, float delay)
        {
            if (textMeshPro == null) return;
            textMeshPro.StartCoroutine(TypeText(textMeshPro, message, delay));
        }

        /// <summary>
        /// Adds a typing character animation to the text, with rich text option.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="delay">Delay between each character in seconds.</param>
        /// <param name="richText">Whether the text is rich text.</param>
        public static void AddingTypingCharacterAnim(this TextMeshProUGUI textMeshPro, string message, float delay, bool richText)
        {
            if (textMeshPro == null) return;
            textMeshPro.richText = richText;
            textMeshPro.StartCoroutine(TypeText(textMeshPro, message, delay));
        }

        /// <summary>
        /// Skips the current typing character animation and shows the full message.
        /// </summary>
        /// <param name="message">The text to display.</param>
        public static void SkippingCurrentTypingCharacterAnim(this TextMeshProUGUI textMeshPro, string message)
        {
            if (textMeshPro == null) return;
            var textmeshProCoroutine = textMeshPro.GetComponent<MonoBehaviour>();
            if (textmeshProCoroutine != null)
            {
                textmeshProCoroutine.StopAllCoroutines();
            }
            textMeshPro.text = message; 
        }

        private static IEnumerator TypeText(TextMeshProUGUI textMeshPro, string message, float delay)
        {
            for (int i = 0; i < message.Length; i++)
            {
                textMeshPro.text += message[i];
                yield return new WaitForSeconds(delay);
            }
        }

        /// <summary>
        /// Makes the text blink by changing its alpha over the given duration and blink count.
        /// </summary>
        /// <param name="duration">Duration of the blink in seconds.</param>
        /// <param name="blinkCount">Number of blinks.</param>
        public static void BlinkText(this TextMeshProUGUI textMeshPro, float duration, int blinkCount = 5)

        {
            if (textMeshPro == null) return;
            textMeshPro.StartCoroutine(BlinkCoroutine(textMeshPro, duration, blinkCount));
        }
        
        /// <summary>
        /// Makes the text blink by changing its alpha over the given duration. Default blink count is 3.
        /// </summary>
        /// <param name="duration">Duration of the blink in seconds.</param>
        public static void BlinkText(this TextMeshProUGUI textMeshPro, float duration)

        {
            BlinkText(textMeshPro, duration, 3);
        }

        /// <summary>
        /// Sets the text and makes it blink for the given duration and blink count.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="duration">Duration of the blink in seconds.</param>
        /// <param name="blinkCount">Number of blinks.</param>
        public static void SetTextWithBlinkingEffect(this TextMeshProUGUI textMeshPro, string message, float duration, int blinkCount = 5)

        {
            if (textMeshPro == null) return;
            textMeshPro.text = message;
            textMeshPro.BlinkText(duration, blinkCount);
        }
        
        /// <summary>
        /// Sets the text and makes it blink for the given duration. Default blink count is 3.
        /// </summary>
        /// <param name="message">The text to display.</param>
        /// <param name="duration">Duration of the blink in seconds.</param>
        public static void SetTextWithBlinkingEffect(this TextMeshProUGUI textMeshPro, string message, float duration)

        {
            SetTextWithBlinkingEffect(textMeshPro, message, duration, 3); // Default blink count is 3
        }

        private static IEnumerator BlinkCoroutine(TextMeshProUGUI textMeshPro, float duration, int blinkCount)
        {
            float halfDuration = duration / (blinkCount * 2);
            for (int i = 0; i < blinkCount; i++)
            {
                // Fade out
                yield return ChangeAlphaCoroutine(textMeshPro, 0f, halfDuration);
                // Fade in
                yield return ChangeAlphaCoroutine(textMeshPro, 1f, halfDuration);
            }
        }

        private static IEnumerator ChangeAlphaCoroutine(TextMeshProUGUI textMeshPro, float targetAlpha, float duration)
        {
            if (textMeshPro == null) yield break;

            Color initialColor = textMeshPro.color;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                textMeshPro.color = Color.Lerp(initialColor, new Color(initialColor.r, initialColor.g, initialColor.b, targetAlpha), elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            textMeshPro.color = new Color(initialColor.r, initialColor.g, initialColor.b, targetAlpha);
        }

         /// <summary>
        /// Sets the font face material properties for color, softness, and dilation.
        /// </summary>
        /// <param name="faceColor">Face color to set.</param>
        /// <param name="softness">Outline softness value (0-1).</param>
        /// <param name="dilate">Face dilation value (-1 to 1).</param>
        public static void SetFontFaceMaterial(this TextMeshProUGUI textMeshPro, Color faceColor, float softness, float dilate)


        {
            if (textMeshPro == null) return;
            softness = Mathf.Clamp01(softness);
            dilate = Mathf.Clamp(dilate, -1f, 1f);
            var newRuntimeMaterial = Object.Instantiate(textMeshPro.fontMaterial);
            newRuntimeMaterial.SetColor("_FaceColor", faceColor);
            newRuntimeMaterial.SetFloat("_OutlineSoftness", softness);
            newRuntimeMaterial.SetFloat("_FaceDilate", dilate);
            textMeshPro.fontMaterial = newRuntimeMaterial;
        }

        /// <summary>
        /// Sets the font face material properties for color and softness.
        /// </summary>
        /// <param name="faceColor">Face color to set.</param>
        /// <param name="softness">Outline softness value (0-1).</param>
        public static void SetFontFaceMaterial(this TextMeshProUGUI textMeshPro, Color faceColor, float softness)
        {
            SetFontFaceMaterial(textMeshPro, faceColor, softness, 0f); // Default dilate is 0
        }

        /// <summary>
        /// Sets the font face material property for color only.
        /// </summary>
        /// <param name="faceColor">Face color to set.</param>
        public static void SetFontFaceMaterial(this TextMeshProUGUI textMeshPro, Color faceColor)
        {
            SetFontFaceMaterial(textMeshPro, faceColor, 0f, 0f); // Default softness and dilate are 0
        }

        /// <summary>
        /// Sets the font outline material properties for color and width.
        /// </summary>
        /// <param name="outlineColor">Outline color to set.</param>
        /// <param name="outlineWidth">Outline width value.</param>
        public static void SetFontOutlineMaterial(this TextMeshProUGUI textMeshPro, Color outlineColor, float outlineWidth)
        {
            if (textMeshPro == null) return;

            var newRuntimeMaterial = Object.Instantiate(textMeshPro.fontMaterial);
            newRuntimeMaterial.EnableKeyword("OUTLINE_ON");
            newRuntimeMaterial.SetColor("_OutlineColor", outlineColor);
            newRuntimeMaterial.SetFloat("_OutlineWidth", outlineWidth);
            textMeshPro.fontMaterial = newRuntimeMaterial;
        }

        /// <summary>
        /// Adds a ContentSizeFitter to the RectTransform to automatically fit its content size.
        /// </summary>
        public static void ContentWidthFitter(this TextMeshProUGUI textMeshPro)
        {
            if (textMeshPro == null) return;

            var rectTransform = textMeshPro.GetComponent<RectTransform>();
            if (rectTransform == null) return;

            var preferedWidth = textMeshPro.preferredWidth;
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, preferedWidth);
        }
    }
}
