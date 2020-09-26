using com.on.relax.your.eyes.logic;
using com.on.relax.your.eyes.xam.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace com.on.relax.your.eyes.xam
{
    public class StateToStringConverter : IValueConverter
    {
        readonly Dictionary<State, string> _stateMap;

        public StateToStringConverter()
        {
            _stateMap = new Dictionary<State, string>()
            {
                { State.Off, Strings.Off },
                { State.On, Strings.On },
                { State.Pause, Strings.Pause },
                { State.ExerciseSuggested, Strings.ExerciseSuggested },
                { State.Exercise, Strings.Exercise },
                { State.Unknown, Strings.Unknown }
            };
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _stateMap[(State)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("should not be used"); // needs a reverse dictionary
        }
    }
}