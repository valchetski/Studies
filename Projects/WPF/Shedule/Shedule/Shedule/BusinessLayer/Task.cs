using System;
using System.Xml.Serialization;

namespace Shedule.BusinessLayer
{
    public class Task
    {
        public string SubjectName { get; set; }

        [XmlIgnore]
        private DateTime DeadLineTime { get; set; }

        public string DeadLineTimeString
        {
            get { return DeadLineTime.ToShortDateString(); }
            set { DeadLineTime = DateTime.Parse(value); }
        }
        public string TaskName { get; set; }

        public Task(string subjectName, DateTime deadLineTime, string taskName)
        {
            SubjectName = subjectName;
            DeadLineTimeString = deadLineTime.ToShortDateString();
            TaskName = taskName;
        }

        public Task() { }
    }

}
