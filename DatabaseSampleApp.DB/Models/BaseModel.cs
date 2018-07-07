using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DatabaseSampleApp.DB.Models
{
    public abstract class BaseModel : IHasServerId, INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int? _serverId;

        public int? ServerId
        {
            get => _serverId;
            set => SetProperty(ref _serverId, value);
        }

        public abstract int GetScopeId();

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected bool SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, value)) return false;

            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
            member = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
