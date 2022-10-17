using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_1
{
    public class TrainingLesson : Entity
    {
        public TrainingMaterial[] TrainingMaterials;
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
    }
}
