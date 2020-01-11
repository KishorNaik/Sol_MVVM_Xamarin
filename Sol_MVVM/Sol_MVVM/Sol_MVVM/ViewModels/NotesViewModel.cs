using Sol_MVVM.Models;
using Sol_MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sol_MVVM.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {

        public NotesViewModel()
        {
            NotesM = new NotesModel();
            NotesList = new ObservableCollection<string>();

            OnClear();

            OnAdd();

            OnListClear();
        }


        #region INotify Property Chnaged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion 

        #region Property
        private NotesModel notesM;
        public NotesModel NotesM
        {
            get => notesM;
            set
            {
                notesM = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NotesM)));
            }
        }

        public ObservableCollection<string> NotesList { get; set; }

        #endregion

        #region Command
        public Command OnAddCommand { get; set; }

        public Command OnClearCommand { get; set; }

        public Command OnListClearCommand { get; set; }
        #endregion

        #region Private Method

        private async Task OnFocus(ContentPage content)
        {
            await Task.Run(() => {

                NotesM.Notes = String.Empty;

                Editor editorObj = content.FindByName<Editor>("txtNotes");
                editorObj.Focus();

            });
        }

        private void OnAdd()
        {
            OnAddCommand = new Command<ContentPage>(async (contentObj) =>
            {
                NotesList.Add(NotesM.Notes);

                await this.OnFocus(contentObj);
            });
        }

        private void OnClear()
        {
            OnClearCommand = new Command<ContentPage>(async (contentObj) => {

                await this.OnFocus(contentObj);
            });
        }

        private void OnListClear()
        {
            OnListClearCommand = new Command<ContentPage>(async (contentPageObj) => {

                NotesList.Clear();
                await this.OnFocus(contentPageObj);

               
            });
        }
        #endregion 





    }
}
