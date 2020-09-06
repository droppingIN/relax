using System;

namespace com.on.relax.your.eyes.logic
{
    public class Exercise
    {
        public string PathToResource;
        public string Description;
        public string Comment;
        public TimeSpan Duration;

        public Exercise(string pathToResource, string description, string comment, TimeSpan duration)
        {
            PathToResource = pathToResource;
            Description = description;
            Comment = comment;
            Duration = duration;
        }
    }
}
