using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace afw_project
{
    public class VM_Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Alerts the changing of property.
        /// </summary>
        /// <param name="propertyName">Name of calling property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
