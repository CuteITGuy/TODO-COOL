using System;
using CB.Data;


namespace Todos
{
    public class Todo: ObservableObject
    {
        #region Fields
        private const int IN_PROGRESS_HOURS = 2,
                          APPROACHING_HOURS = 24;

        private string _content = "Task 1";
        private DateTime _deadline = DateTime.Now;
        private bool _isDone;

        [NonSerialized]
        private WarningLevel _warningLevel;
        #endregion


        #region  Properties & Indexers
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        public DateTime Deadline
        {
            get { return _deadline; }
            set
            {
                SetProperty(ref _deadline, value);
                SetWarningLevel();
            }
        }

        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                SetProperty(ref _isDone, value);
                SetWarningLevel();
            }
        }

        public int Priority { get; set; } = 1;

        public WarningLevel WarningLevel => _warningLevel;
        #endregion


        #region Implementation
        private void SetWarningLevel()
        {
            var hoursToDeadline = (Deadline - DateTime.Now).TotalHours;
            var warningLevel = IsDone
                                   ? WarningLevel.None
                                   : hoursToDeadline < 0
                                         ? WarningLevel.Overdue
                                         : hoursToDeadline < IN_PROGRESS_HOURS
                                               ? WarningLevel.InProgress
                                               : hoursToDeadline < APPROACHING_HOURS
                                                     ? WarningLevel.Approaching : WarningLevel.Normal;

            // ReSharper disable once ExplicitCallerInfoArgument
            SetProperty(ref _warningLevel, warningLevel, nameof(WarningLevel));
        }
        #endregion
    }

    public enum WarningLevel
    {
        Overdue,
        InProgress,
        Approaching,
        Normal,
        None,
    }
}