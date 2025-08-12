using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Yunst.UGUI.Extension
{
    public static class ButtonExtensions
    {

    /// <summary>
    /// Makes the button clickable only once. After the first click, disables interactable and removes all listeners.
    /// </summary>
    /// <param name="button">The button to make clickable only once.</param>
        public static void SetClickableOnce(this Button button)
        {
            if (button == null) return;

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                button.interactable = false;
                button.onClick.RemoveAllListeners();
            });
        }

    /// <summary>
    /// Binds a method to the button so it is called only once, then unsubscribed after the first click.
    /// </summary>
    /// <param name="button">The button to bind the method to.</param>
    /// <param name="action">The method to invoke on click.</param>
        public static void BindMethodOnce(this Button button, Action action)
        {
            if (button == null || action == null) return;
            UnityEngine.Events.UnityAction wrapper = null;
            wrapper = () =>
            {
                action.Invoke();
                button.onClick.RemoveListener(wrapper);
            };
            button.onClick.AddListener(wrapper);
        }

    /// <summary>
    /// Deselects the button from the EventSystem after it is clicked, removing selection focus.
    /// </summary>
    /// <param name="button">The button to deselect after click.</param>
        public static void UnselectingAfterClick(this Button button)
        {
            if (button == null) return;
            button.onClick.AddListener(() =>
            {
                var eventSystem = UnityEngine.EventSystems.EventSystem.current;
                if (eventSystem != null && eventSystem.currentSelectedGameObject == button.gameObject)
                {
                    eventSystem.SetSelectedGameObject(null);
                }
            });
        }

    /// <summary>
    /// Sets the button label text using TextMeshProUGUI.
    /// </summary>
    /// <param name="button">The button to set the label for.</param>
    /// <param name="label">The label text.</param>
        public static void SetButtonLabel(this Button button, string label)
        {
            if (button == null) return;
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.SetTMPText(label);
            }
            else
            {
                Debug.LogWarning("Button does not have a TextMeshProUGUI component in its children to set the label.");
            }
        }

    /// <summary>
    /// Sets the button label text and font size using TextMeshProUGUI.
    /// </summary>
    /// <param name="button">The button to set the label for.</param>
    /// <param name="label">The label text.</param>
    /// <param name="fontSize">The font size.</param>
        public static void SetButtonLabel(this Button button, string label, float fontSize)
        {
            if (button == null) return;
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.SetTMPText(label, fontSize);
            }
            else
            {
                Debug.LogWarning("Button does not have a TextMeshProUGUI component in its children to set the label and font size.");
            }
        }

    /// <summary>
    /// Sets the button label text and rich text option using TextMeshProUGUI.
    /// </summary>
    /// <param name="button">The button to set the label for.</param>
    /// <param name="label">The label text.</param>
    /// <param name="richText">Whether to enable rich text.</param>
        public static void SetButtonLabel(this Button button, string label, bool richText)
        {
            if (button == null) return;
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.SetTMPText(label, richText);
            }
            else
            {
                Debug.LogWarning("Button does not have a TextMeshProUGUI component in its children to set the label with rich text.");
            }
        }

    /// <summary>
    /// Sets the button label text, font size, and rich text option using TextMeshProUGUI.
    /// </summary>
    /// <param name="button">The button to set the label for.</param>
    /// <param name="label">The label text.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="richText">Whether to enable rich text.</param>
        public static void SetButtonLabel(this Button button, string label, float fontSize, bool richText)
        {
            if (button == null) return;
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.SetTMPText(label, fontSize, richText);
            }
            else
            {
                Debug.LogWarning("Button does not have a TextMeshProUGUI component in its children to set the label, font size, and rich text.");
            }
        }
       



    /// <summary>
    /// Sets the button label text and color using TextMeshProUGUI.
    /// </summary>
    /// <param name="button">The button to set the label for.</param>
    /// <param name="label">The label text.</param>
    /// <param name="color">The text color.</param>
        public static void SetButtonLabel(this Button button, string label, Color color)
        {
            if (button == null) return;
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.SetTextWithColor(label, color);
            }
            else
            {
                Debug.LogWarning("Button does not have a TextMeshProUGUI component in its children to set the label and color.");
            }
        }

    /// <summary>
    /// Sets the button label text, color, and font size using TextMeshProUGUI.
    /// </summary>
    /// <param name="button">The button to set the label for.</param>
    /// <param name="label">The label text.</param>
    /// <param name="color">The text color.</param>
    /// <param name="fontSize">The font size.</param>
        public static void SetButtonLabel(this Button button, string label, Color color, float fontSize)
        {
            if (button == null) return;
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.SetTextWithColor(label, color, fontSize);
            }
            else
            {
                Debug.LogWarning("Button does not have a TextMeshProUGUI component in its children to set the label, color, and font size.");
            }
        }

    /// <summary>
    /// Sets the button label text, color, and rich text option using TextMeshProUGUI.
    /// </summary>
    /// <param name="button">The button to set the label for.</param>
    /// <param name="label">The label text.</param>
    /// <param name="color">The text color.</param>
    /// <param name="richText">Whether to enable rich text.</param>
        public static void SetButtonLabel(this Button button, string label, Color color, bool richText)
        {
            if (button == null) return;
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.SetTextWithColor(label, color, richText);
            }
            else
            {
                Debug.LogWarning("Button does not have a TextMeshProUGUI component in its children to set the label, color, and font size.");
            }
        }

    /// <summary>
    /// Sets the button label text, color, font size, and rich text option using TextMeshProUGUI.
    /// </summary>
    /// <param name="button">The button to set the label for.</param>
    /// <param name="label">The label text.</param>
    /// <param name="color">The text color.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="richText">Whether to enable rich text.</param>
        public static void SetButtonLabel(this Button button, string label, Color color, float fontSize, bool richText)
        {
            if (button == null) return;
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.SetTextWithColor(label, color, fontSize, richText);
            }
            else
            {
                Debug.LogWarning("Button does not have a TextMeshProUGUI component in its children to set the label, color, and font size.");
            }
        }

    }
}
