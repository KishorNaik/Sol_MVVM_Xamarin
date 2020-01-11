using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sol_MVVM.Models
{
    public class NotesModel : INotifyPropertyChanged
    {

        #region INotify Property Changed  
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property
        private string notes;

        public string Notes
        {
            get => notes;
            set
            {
                notes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Notes)));
            }
        }

        #endregion 


    }
}
