using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.ViewModels
{
    internal class IsIndexOverZeroConverter: IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            
            if(value is int index && targetType.IsAssignableTo(typeof(Boolean)))
            {
                if (index >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
