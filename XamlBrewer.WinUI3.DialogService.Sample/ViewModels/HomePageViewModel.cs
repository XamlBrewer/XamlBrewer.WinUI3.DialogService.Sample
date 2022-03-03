using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamlBrewer.WinUI3.Services;

namespace XamlBrewer.WinUI3.DialogService.Sample.ViewModels
{
    public class HomePageViewModel: ObservableObject
    {
        public ICommand ConfirmationCommandYesNo => new AsyncRelayCommand(ConfirmationYesNo_Executed);

        public ICommand ConfirmationCommandYesNoCancel => new AsyncRelayCommand(ConfirmationYesNoCancel_Executed);

        public ICommand InputStringCommand => new AsyncRelayCommand(InputString_Executed);

        public async void InputText_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Opening Text Input Dialog.");
            var inputText = await App.MainRoot.InputTextDialogAsync(
                "What whas your point actually?",
                "I just wanted to criticize the existing view of quantum mechanics by explaining how one could, in principle, create a superposition in a large-scale system by making it dependent on a quantum particle that was in a superposition, and end up in an ridiculous state.\n\nAnd I hate cats anyway..."
                );
            Debug.WriteLine(string.Format("Text Input Dialog was closed with {0}.", inputText));
        }

        private async Task ConfirmationYesNo_Executed()
        {
            Debug.WriteLine("2-State Confirmation Dialog will be opened.");
            var confirmed = await App.MainRoot.ConfirmationDialogAsync(
                    "Are you planning to open the box?",
                    "Sure",
                    "No, thanks"
                );
            Debug.WriteLine("2-State Confirmation Dialog was closed with {0}.", confirmed);
        }

        private async Task ConfirmationYesNoCancel_Executed()
        {
            Debug.WriteLine("3-State Confirmation Dialog will be opened.");
            var confirmed = await App.MainRoot.ConfirmationDialogAsync(
                    "So, what's the status of the cat?\nHint: use Quantum Mechanics.",
                    "It's alive",
                    "It's dead",
                    "It's both"
                );
            Debug.WriteLine("3-State Confirmation Dialog was closed with {0}.", confirmed);
        }

        private async Task InputString_Executed()
        {
            Debug.WriteLine("Opening String Input Dialog.");
            var inputString = await App.MainRoot.InputStringDialogAsync(
                "How do you want to call this phenomenon?",
                "Verschränkung",
                "Claim",
                "Forget it"
                );
            Debug.WriteLine(string.Format("String Input Dialog was closed with {0}.", inputString));
        }
    }
}
