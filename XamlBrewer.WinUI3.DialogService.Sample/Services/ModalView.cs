using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace XamlBrewer.WinUI3.Services
{
    /// <summary>
    /// Provides elementary Modal View services: display message, request confirmation, request input.
    /// </summary>
    public static class ModalView
    {
        public static async Task MessageDialogAsync(this FrameworkElement element, string title, string message)
        {
            await MessageDialogAsync(element, title, message, "OK");
        }

        public static async Task MessageDialogAsync(this FrameworkElement element, string title, string message, string buttonText)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = buttonText,
                XamlRoot = element.XamlRoot,
                RequestedTheme = element.ActualTheme
            };

            await dialog.ShowAsync();
        }
        public static async Task<bool?> ConfirmationDialogAsync(this FrameworkElement element, string title)
        {
            return await ConfirmationDialogAsync(element, title, "OK", string.Empty, "Cancel");
        }

        public static async Task<bool> ConfirmationDialogAsync(this FrameworkElement element, string title, string yesButtonText, string noButtonText)
        {
            return (await ConfirmationDialogAsync(element, title, yesButtonText, noButtonText, string.Empty)).Value;
        }

        public static async Task<bool?> ConfirmationDialogAsync(this FrameworkElement element, string title, string yesButtonText, string noButtonText, string cancelButtonText)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                PrimaryButtonText = yesButtonText,
                SecondaryButtonText = noButtonText,
                CloseButtonText = cancelButtonText,
                XamlRoot = element.XamlRoot,
                RequestedTheme = element.ActualTheme
            };
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.None)
            {
                return null;
            }

            return (result == ContentDialogResult.Primary);
        }

        public static async Task<string> InputStringDialogAsync(this FrameworkElement element, string title)
        {
            return await element.InputStringDialogAsync(title, string.Empty);
        }

        public static async Task<string> InputStringDialogAsync(this FrameworkElement element, string title, string defaultText)
        {
            return await element.InputStringDialogAsync(title, defaultText, "OK", "Cancel");
        }

        public static async Task<string> InputStringDialogAsync(this FrameworkElement element, string title, string defaultText, string okButtonText, string cancelButtonText)
        {
            var inputTextBox = new TextBox
            {
                AcceptsReturn = false,
                Height = 32,
                Text = defaultText,
                SelectionStart = defaultText.Length
            };
            var dialog = new ContentDialog
            {
                Content = inputTextBox,
                Title = title,
                IsSecondaryButtonEnabled = true,
                PrimaryButtonText = okButtonText,
                SecondaryButtonText = cancelButtonText,
                XamlRoot = element.XamlRoot,
                RequestedTheme = element.ActualTheme
            };

            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
            {
                return inputTextBox.Text;
            }
            else
            {
                return string.Empty;
            }
        }

        public static async Task<string> InputTextDialogAsync(this FrameworkElement element, string title)
        {
            return await element.InputTextDialogAsync(title, string.Empty);
        }

        public static async Task<string> InputTextDialogAsync(this FrameworkElement element, string title, string defaultText)
        {
            var inputTextBox = new TextBox
            {
                AcceptsReturn = true,
                Height = 32 * 6,
                Text = defaultText,
                TextWrapping = TextWrapping.Wrap,
                SelectionStart = defaultText.Length
            };
            var dialog = new ContentDialog
            {
                Content = inputTextBox,
                Title = title,
                IsSecondaryButtonEnabled = true,
                PrimaryButtonText = "Ok",
                SecondaryButtonText = "Cancel",
                XamlRoot = element.XamlRoot,
                RequestedTheme = element.ActualTheme
            };

            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
            {
                return inputTextBox.Text;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
