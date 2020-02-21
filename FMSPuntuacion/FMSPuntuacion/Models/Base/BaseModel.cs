using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace FMSPuntuacion.Models.Base
{
    public abstract class BaseModel: ExtendedBindableObject
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public virtual Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task UnloadAsync()
        {
            return Task.CompletedTask;
        }

    }
}
