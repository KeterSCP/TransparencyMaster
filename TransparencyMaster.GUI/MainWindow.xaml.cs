using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TransparencyMaster.Core;
using TransparencyMaster.GUI.Annotations;

namespace TransparencyMaster.GUI
{
    public sealed partial class MainWindow : INotifyPropertyChanged
    {
        private string _capturedContextLabel = string.Empty;
        private IntPtr _capturedWindowHandle = IntPtr.Zero;
        
        public MainWindow()
        {
            InitializeComponent();
            EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyUpEvent, new KeyEventHandler(OnCtrlKeyup), true);
        }

        private void OnCtrlKeyup(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.LeftCtrl) return;

            var mousePosition = ManagedProxy.GetCursorPosition();
            var windowHandle = ManagedProxy.GetWindowFromPoint(mousePosition);

            var processId = ManagedProxy.GetProcessIdFromWindowHandle(windowHandle);
            var process = Process.GetProcessById((int)processId);

            _capturedWindowHandle = process.MainWindowHandle;
            CapturedContentLabelText = $"Captured window name: {process.ProcessName}";
        }

        public string CapturedContentLabelText
        {
            get => _capturedContextLabel;
            private set 
            {
                _capturedContextLabel = value; 
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TransparencyValue_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_capturedWindowHandle != IntPtr.Zero)
            {
                ManagedProxy.SetWindowTransparency(_capturedWindowHandle, (byte)e.NewValue);
            }
        }
    }
}
