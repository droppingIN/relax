using System;
using System.ComponentModel;

namespace com.on.relax.your.eyes.logic
{
    public class ExerciseViewModel : Exercise, INotifyPropertyChanged
    {
        public ExerciseViewModel(string path, string description, string comment, TimeSpan duration)
            : base(path, description, comment, duration)
        {
        }

        public new string PathToResource 
        {
            get => base.PathToResource;
            set
            {
                if(base.PathToResource != value)
                {
                    base.PathToResource = value;
                    OnPropertyChanged(nameof(PathToResource));
                }
            }
        }

        public new string Description
        {
            get => base.Description;
            set
            {
                if (base.Description != value)
                {
                    base.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public new string Comment
        {
            get => base.Comment;
            set
            {
                if (base.Comment != value)
                {
                    base.Comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }

        public new TimeSpan Duration
        {
            get => base.Duration;
            set
            {
                if (base.Duration != value)
                {
                    base.Duration = value;
                    OnPropertyChanged(nameof(Duration));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}