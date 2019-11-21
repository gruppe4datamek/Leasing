using Leasing.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.ViewModel
{
    class OpretBilViewModel : INotifyPropertyChanged
    {
        private string bil_id;
        private string mærke;
        private string model;
        private int årgang;
        private int kilometertal;
        private string farve;
        private bool tilgængelig;


        public OpretBilViewModel()
        {
            //catalog = new StudentCatalog();
            //singleton = StudentCatalogSingleton.Instance;

            AddCommand = new RelayCommand(tilføjBil);

            //_newStudent = new Student();

           // _students = new ObservableCollection<Student>();

        }

        public RelayCommand AddCommand { get; set; }
        public void tilføjBil()
        {

        }
        public string BIL_ID
        {
            get { return bil_id; }
            set { bil_id = value; }
        }

        public string Mærke
        {
            get { return mærke; }
            set { mærke = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Årgang
        {
            get { return årgang; }
            set { årgang = value; }
        }
        public int Kilometertal
        {
            get { return kilometertal; }
            set { kilometertal = value; }
        }
        public string Farve
        {
            get { return farve; }
            set { farve = value; }
        }
        public bool Tilgængelig
        {
            get { return tilgængelig; }
            set { tilgængelig = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged
            ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }
    }
   
}
