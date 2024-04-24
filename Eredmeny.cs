using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Autok
{
    internal class Eredmeny : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<Auto> _autok;
        private string _otAjtosokSzama;
        private string _toyotakSzama;
        private string _legfiatalabbAutok;
        private string _homokSzinuekAtlagkora;

        public string homokSzinuekAtlagkora
        {
            get { return _homokSzinuekAtlagkora; }
            set { _homokSzinuekAtlagkora = value; OnPropertyChanged(); }
        }

        public string legfiatalabbAutok
        {
            get { return _legfiatalabbAutok; }
            set { _legfiatalabbAutok = value; OnPropertyChanged(); }
        }

        public string toyotakSzama
        {
            get { return _toyotakSzama; }
            set { _toyotakSzama = value; OnPropertyChanged(); }
        }

        public string otAjtosokSzama
        {
            get { return _otAjtosokSzama; }
            set { _otAjtosokSzama = value; OnPropertyChanged(); }
        }


        public ObservableCollection<Auto> autok
        {
            get
            {
                return _autok;
            }
            set
            {
                _autok = value;
                OnPropertyChanged();
            }
        }
        public Eredmeny()
        {
            ReadFile("autok.txt");
            GetOtAjtosokSzama();
            GetToyotakSzama();
            GetLegfiatalabbAutok();
            GetHAvg();
        }

        //public void OnPropertyChanged([CallerMemberName] string? tulajdonsagnev = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagnev));
        //}

        public void OnPropertyChanged([CallerMemberName]string? tulajdonsagnev = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagnev));
        private void ReadFile(string path)
        {
            autok = new ObservableCollection<Auto>();
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                autok.Add(new Auto(sr.ReadLine()));
            }
            sr.Close();
        }
        private void GetOtAjtosokSzama()
        {
            otAjtosokSzama =
                $"Hány autónak van 5 ajtaja?\nEredmény: {autok.Count(x => x.AjtokSzama == 5)}";
            
        }
        private void GetToyotakSzama()
        {
            toyotakSzama =
                $"Hány Toyota márkájú autó van a fájlban?\nEredmény: {autok.Count(x => x.Tipus.Contains("Toyota"))}";
        }
        private void GetLegfiatalabbAutok()
        {
            legfiatalabbAutok =
                $"A legfiatalabb autó(k):\n{String.Join('\n', autok.Where(x => x.GyartasEv == autok.OrderByDescending(y => y.GyartasEv).First().GyartasEv))}";
        }
        private void GetHAvg()
        {
            homokSzinuekAtlagkora =
                $"Homok színű autók átlagéletkora: {Math.Round(autok.Where(x => x.Szin == "Homok").Average(x => DateTime.Now.Year - x.GyartasEv),2, MidpointRounding.AwayFromZero)}";
        }
    }
}
