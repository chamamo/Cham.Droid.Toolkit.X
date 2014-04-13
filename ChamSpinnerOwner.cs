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
using Android.Util;

namespace Cham.Droid.ToolkitX
{
    public class ChamSpinnerOwner : ChamHeaderOwner, IChamSpinner
    {
        #region Fields

        public readonly EditText FooEditText;

        #endregion

        #region Contructor

        public ChamSpinnerOwner(TextView headerTextView, EditText fooEditText, IAttributeSet attrs, int defStyle)
            : base(headerTextView, attrs, defStyle)
        {
            FooEditText = fooEditText;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        #endregion


        public string Error
        {
            set { FooEditText.Error = value; }
        }
    }
}