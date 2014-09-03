using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Attributes;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cham.Droid.Toolkit;

namespace Cham.Droid.ToolkitX
{
	public class ChamAutoCompleteTextView : LinearLayout, IChamEditText
	{
		public EventHandler AfterTextChanged;


		public ChamAutoCompleteTextView (Context context) : base (context)
		{

		}

		public ChamAutoCompleteTextView (Context context, IAttributeSet attrs)
			: this (context, attrs, Resource.Attribute.ChamAutoCompleteTextViewStyle)
		{
		}

		public ChamAutoCompleteTextView (Context context, IAttributeSet attrs, int defStyle)
			: this (context, attrs, defStyle, new ChamFilteringAdapter (context))
		{
		}

		public ChamAutoCompleteTextView (Context context, IAttributeSet attrs, int defStyle, ChamFilteringAdapter adapter)
            : base (context, attrs)
		{
			((IMvxBindingContextOwner)Context).BindingInflate (LayoutId, this);
			var itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId (context, attrs);
			adapter.ItemTemplateId = itemTemplateId;
			AutoCompleteTextView = FindViewById<AutoCompleteTextView> (Resource.Id.AutoCompleteTextView);
			Adapter = adapter;

			AutoCompleteTextView.ItemClick += OnItemClick;

			var textView = FindViewById<TextView> (Resource.Id.ChamHeader);
			var autoCompleteView = FindViewById<AutoCompleteTextView> (Resource.Id.AutoCompleteTextView);
			autoCompleteView.AfterTextChanged += EditTextAfterTextChanged;
			Owner = new ChamAutoCompleteTextViewOwner (textView, autoCompleteView, attrs, defStyle);
		}

		protected virtual int LayoutId { get { return Resource.Layout.ChamAutoCompleteTextViewLayout; } }

		public string Error
		{
			set
			{
				Owner.Error = value;
			}
		}

		public bool Required
		{
			get { return Owner.Required; }
			set { Owner.Required = value; }
		}

		public string Text
		{
			get { return Owner.Text; }
			set { Owner.Text = value; }
		}

		public string Header
		{
			get { return Owner.Header; }
			set { Owner.Header = value; }
		}

		private ChamAutoCompleteTextViewOwner Owner { get; set; }

		private void OnItemClick (object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
		{
			OnItemClick (itemClickEventArgs.Position);
		}

		private void OnItemSelected (object sender, AdapterView.ItemSelectedEventArgs itemSelectedEventArgs)
		{
			OnItemSelected (itemSelectedEventArgs.Position);
		}

		protected virtual void OnItemClick (int position)
		{
			var selectedObject = Adapter.GetRawItem (position);
			SelectedObject = selectedObject;
		}

		protected virtual void OnItemSelected (int position)
		{
			var selectedObject = Adapter.GetRawItem (position);
			SelectedObject = selectedObject;
		}

		public override bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
				AutoCompleteTextView.Enabled = value;
			}
		}

		public AutoCompleteTextView AutoCompleteTextView { get; private set; }

		public ChamFilteringAdapter Adapter
		{
			get { return AutoCompleteTextView.Adapter as ChamFilteringAdapter; }
			set
			{
				var existing = Adapter;
				if (existing == value)
					return;

				if (existing != null)
					existing.PartialTextChanged -= AdapterOnPartialTextChanged;

				if (existing != null && value != null)
				{
					value.ItemsSource = existing.ItemsSource;
					value.ItemTemplateId = existing.ItemTemplateId;
				}

				if (value != null)
					value.PartialTextChanged += AdapterOnPartialTextChanged;

				AutoCompleteTextView.Adapter = value;
			}
		}

		private void AdapterOnPartialTextChanged (object sender, EventArgs eventArgs)
		{
			FireChanged (PartialTextChanged);
		}

		[MvxSetToNullAfterBinding]
		public IEnumerable ItemsSource
		{
			get { return Adapter.ItemsSource; }
			set { Adapter.ItemsSource = value; }
		}

		public int ItemTemplateId
		{
			get { return Adapter.ItemTemplateId; }
			set { Adapter.ItemTemplateId = value; }
		}

		public string PartialText
		{
			get { return Adapter.PartialText; }
		}

		private object _selectedObject;

		public object SelectedObject
		{
			get { return _selectedObject; }
			private set
			{
				if (_selectedObject == value)
					return;

				_selectedObject = value;
				FireChanged (SelectedObjectChanged);
			}
		}

		public event EventHandler SelectedObjectChanged;
		public event EventHandler PartialTextChanged;

		private void OnAfterTextChanged ()
		{
			if (AfterTextChanged != null)
				AfterTextChanged (this, EventArgs.Empty);
		}

		private void FireChanged (EventHandler eventHandler)
		{
			var handler = eventHandler;
			if (handler != null)
			{
				handler (this, EventArgs.Empty);
			}
		}

		private void EditTextAfterTextChanged (object sender, EventArgs e)
		{
			OnAfterTextChanged ();
		}

		public new bool RequestFocus()
		{
			return Owner.RequestFocus ();
		}
	}
}