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
		public readonly Button Button;

        #endregion

        #region Contructor

		public ChamSpinnerOwner(TextView headerTextView, EditText fooEditText, Button button, IAttributeSet attrs, int defStyle)
            : base(headerTextView, attrs, defStyle)
        {
            FooEditText = fooEditText;
			Button = button;
			var a = FooEditText.Context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.ChamSpinner, defStyle, Resource.Style.ChamSpinner);
			try
			{
				for (var i = 0; i < a.IndexCount; i++)
				{
					var attr = a.GetIndex(i);
					if (attr == Resource.Styleable.ChamSpinner_ShowActionButton)
						Button.Visibility = a.GetBoolean(attr, false)? ViewStates.Visible : ViewStates.Gone;
					else if (attr == Resource.Styleable.ChamSpinner_ActionButtonbackground)
					{
						Button.SetBackgroundResource(a.GetResourceId(attr, Resource.Styleable.ChamSpinner_ActionButtonbackground));
					}
				}
			}
			finally
			{
				a.Recycle();
			}
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

		public bool RequestFocus()
		{
			return FooEditText.RequestFocus ();
		}
    }
}