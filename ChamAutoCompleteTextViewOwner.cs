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
	public class ChamAutoCompleteTextViewOwner : ChamEditTextOwner
	{
		#region Fields

		private AutoCompleteTextView AutoCompleteTextView;

		#endregion

		#region Contructor

		public ChamAutoCompleteTextViewOwner (TextView headerTextView, AutoCompleteTextView autoCompleteTextView, IAttributeSet attrs, int defStyle)
			: base (headerTextView, autoCompleteTextView, attrs, defStyle)
		{
			AutoCompleteTextView = autoCompleteTextView;

		}

		#endregion

		#region Properties

		#endregion

		#region Methods

		#endregion
	}
}