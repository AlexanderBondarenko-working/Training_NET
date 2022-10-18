using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_1
{
    public class TrainingLesson : Entity, IVersionable, ICloneable
    {
        private Version _version;

        public TrainingMaterial[] TrainingMaterials { get; private set; }
        
        public TrainingLesson(TrainingMaterial[] trainingMaterials)
        {
            TrainingMaterials = new TrainingMaterial[trainingMaterials.Length];
            Array.Copy(trainingMaterials, TrainingMaterials, TrainingMaterials.Length);
        }

        public LESSON_TYPE LessonType() 
        {
            foreach(var material in TrainingMaterials)
            {
                if(material is VideoMaterial)
                {
                    return LESSON_TYPE.VideoLesson;
                }
            }
            return LESSON_TYPE.TextLesson;
        }

        public Version GetVersion()
        {
            _version ??= new Version();
            return _version;
        }

        public void SetVersion(string version)
        {
            _version = new Version(version);
        }

        public object Clone()
        {
            var trainingLesson = new TrainingLesson(TrainingMaterials);
            trainingLesson.SetVersion(this.GetVersion().ToString());
            return trainingLesson;
        }
    }
}
