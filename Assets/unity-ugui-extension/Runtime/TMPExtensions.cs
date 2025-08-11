using UnityEngine;
using TMPro;
using System.Collections;

namespace Yunst.UGUI.Extension
{
    public static class TMPExtensions
    {

        public static void SetColor(this TextMeshProUGUI textMeshPro, Color color)
        {
            if (textMeshPro == null) return;
            textMeshPro.color = color;
        }

        public static void SetAlpha(this TextMeshProUGUI textMeshPro, float alpha)
        {
            if (textMeshPro == null) return;
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;
        }

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

        public static void DialogueText(this TextMeshProUGUI textMeshPro, string message, float duration = 2f)
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
    }
}
