using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cham.Droid.Toolkit;

namespace Cham.Droid.ToolkitX.Binding
{
    public interface IChamValidationBinding
    {
        IChamValidation ChamValidation { get; }
    }
}