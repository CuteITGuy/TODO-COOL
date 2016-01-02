using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Todos;


namespace MainForm
{
    public class WarningLevelToBrushConverter: IValueConverter
    {
        private readonly Color _startColor = Colors.White;
        private const double ANGLE = 90.002;


        #region Methods
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is WarningLevel)) return DependencyProperty.UnsetValue;
            var warningLevel = (WarningLevel)value;
            switch (warningLevel)
            {
                case WarningLevel.Overdue:
                    return new LinearGradientBrush(_startColor, Color.FromRgb(255, 147, 147), ANGLE);
                case WarningLevel.InProgress:
                    return new LinearGradientBrush(_startColor, Color.FromRgb(204, 148, 255), ANGLE);
                case WarningLevel.Approaching:
                    return new LinearGradientBrush(_startColor, Color.FromRgb(255, 242, 148), ANGLE);
                case WarningLevel.Normal:
                    return new LinearGradientBrush(_startColor, Color.FromRgb(149, 255, 160), ANGLE);
                case WarningLevel.None:
                    return new LinearGradientBrush(_startColor, Color.FromRgb(184, 184, 184), ANGLE);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
        #endregion
    }
}