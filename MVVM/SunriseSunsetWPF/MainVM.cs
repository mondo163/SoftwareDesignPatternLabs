using SunriseSunsetLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SunriseSunsetWPF
{
    public class MainVM : INotifyPropertyChanged
    {
        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyProperty ([CallerMemberName]string propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private MainModel model = new MainModel();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public  DateTime Date  { get; set; }
        public MainVM()
        {
            Latitude = 45.321725;
            Longitude = -122.766723;
            Date = new DateTime(2020,11,7);

            CalculateCommand = new RelayCommand(DoCalculate);
            MainSaveCommand = new RelayCommand(DoMainSave);
            SmallSaveCommand = new RelayCommand(DoSmallSave);
        }

        private string sunrise;
        public string Sunrise
        {
            get { return sunrise; }
            set { sunrise = value; NotifyProperty(); }
        }
        private string sunset;
        public string Sunset
        {
            get { return sunset; }
            set { sunset = value; NotifyProperty(); }
        }
        private string solarnoon;
        public string Solarnoon
        {
            get { return solarnoon; }
            set { solarnoon = value; NotifyProperty(); }
        }
        private string daylength;
        public string Daylength
        {
            get { return daylength; }
            set { daylength = value; NotifyProperty(); }
        }
        private string civiltwilightbegin;
        public string CivilTwilightBegin
        {
            get { return civiltwilightbegin; }
            set { civiltwilightbegin = value; NotifyProperty(); }
        }
        private string civiltwilightend;
        public string CivilTwilightEnd
        {
            get { return civiltwilightend; }
            set { civiltwilightend = value; NotifyProperty(); }
        }
        private string nauticaltwilightbegin;
        public string NauticalTwilightBegin
        {
            get { return nauticaltwilightbegin; }
            set { nauticaltwilightbegin = value; NotifyProperty(); }
        }
        private string nauticaltwilightend;
        public string NauticalTwilightEnd
        {
            get { return nauticaltwilightend; }
            set { nauticaltwilightend = value; NotifyProperty(); }
        }
        private string astronomicaltwilightbegin;
        public string AstronomicalTwilightBegin
        {
            get { return astronomicaltwilightbegin; }
            set { astronomicaltwilightbegin = value; NotifyProperty(); }
        }
        private string astronomicaltwilightend;
        public string AstronomicalTwilightEnd
        {
            get { return astronomicaltwilightend; }
            set { astronomicaltwilightend = value; NotifyProperty(); }
        }
        public ICommand CalculateCommand { get; set; }
        private void DoCalculate()
        {
            SunriseSunsetResults results = model.GetData(Latitude, Longitude, Date);
            int seconds, minutes, hours;

            Sunrise = results.sunrise.ToString();
            Sunset = results.sunset.ToString();
            Solarnoon = results.solar_noon.ToString();

            seconds = results.day_length % 60;
            minutes = results.day_length / 60;
            hours = minutes / 60;
            minutes %= 60;
            Daylength = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();

            CivilTwilightBegin = results.civil_twilight_begin.ToString();
            CivilTwilightEnd = results.civil_twilight_end.ToString();
            NauticalTwilightBegin = results.nautical_twilight_begin.ToString();
            NauticalTwilightEnd = results.nautical_twilight_end.ToString();
            AstronomicalTwilightBegin = results.astronomical_twilight_begin.ToString();
            AstronomicalTwilightEnd = results.astronomical_twilight_end.ToString();
        }

        public ICommand MainSaveCommand { get; set; }

        private void DoMainSave()
        {
            string fileName = "FullWeatherData";
            StreamWriter writer = new StreamWriter(fileName, true);

            writer.WriteLine("Date: {0}", Date.ToString());
            writer.WriteLine("Latitude: {0}", Latitude);
            writer.WriteLine("Longitude: {0} \n", Longitude);
            writer.WriteLine("Sunrise: {0}", Sunrise);
            writer.WriteLine("Sunset: {0}", Sunset);
            writer.WriteLine("Solar Noon: {0}", Solarnoon);
            writer.WriteLine("Civil Twilight Start: {0}", CivilTwilightBegin);
            writer.WriteLine("Civil Twilight End: {0}", CivilTwilightEnd);
            writer.WriteLine("Nautical Twilight Start: {0}", NauticalTwilightBegin);
            writer.WriteLine("Nautical Twilight End: {0}", NauticalTwilightEnd);
            writer.WriteLine("Astronomical Twilight Start: {0}", AstronomicalTwilightBegin); 
            writer.WriteLine("Astronomical Twilight End: {0}", AstronomicalTwilightEnd);

            writer.Close();
        }
        public ICommand SmallSaveCommand { get; set; }

        private void DoSmallSave()
        {
            string fileName = "ShortenedWeatherData";
            StreamWriter writer = new StreamWriter(fileName, true);

            writer.WriteLine("Date: {0}", Date.ToString());
            writer.WriteLine("Latitude: {0}", Latitude);
            writer.WriteLine("Longitude: {0} \n", Longitude);
            writer.WriteLine("Sunrise: {0}", Sunrise);
            writer.WriteLine("Sunset: {0}", Sunset);
            

            writer.Close();
        }



    }
}
