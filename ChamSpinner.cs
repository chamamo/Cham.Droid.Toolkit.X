using Android.App;
using Android.Content;
using Android.Util;
using Android.Widget;
using Cham.Droid.Toolkit;
using Cirrious.MvvmCross.Binding.Attributes;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;
using System;
using System.Collections;
using System.Windows.Input;
using Android.Views.InputMethods;

namespace Cham.Droid.ToolkitX
{
    public class ChamSpinner : LinearLayout, IChamSpinner
	{
		public EventHandler<AdapterView.ItemSelectedEventArgs> ItemSelected;

		public ChamSpinner (Context context, IAttributeSet attrs)
			: this (context, attrs, Resource.Attribute.ChamSpinnerStyle)
		{		
		}

        public ChamSpinner(Context context, IAttributeSet attrs, int defStyle)
            : this(context, attrs, defStyle, new ChamSpinnerAdapter(context))
        {
        }

	    public ChamSpinner(Context context, IAttributeSet attrs, int defStyle, IMvxAdapter adapter) : base(context, attrs, defStyle)
	    {
	        ((IMvxBindingContextOwner) Context).BindingInflate(Resource.Layout.ChamSpinnerLayout, this);
	        Spinner = FindViewById<Spinner>(Resource.Id.ChamSpinnerSpinner);
	        int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
	        int dropDownItemTemplateId = MvxAttributeHelpers.ReadDropDownListItemTemplateId(context, attrs);
	        adapter.ItemTemplateId = itemTemplateId;
	        adapter.DropDownItemTemplateId = dropDownItemTemplateId;
	        Adapter = adapter;
	        SetupHandleItemSelected();

            var textView = FindViewById<TextView>(Resource.Id.Cham_TextView);
            var fooEditText = FindViewById<EditText>(Resource.Id.FooEditText);
            fooEditText.InputType = global::Android.Text.InputTypes.Null;

            Owner = new ChamSpinnerOwner(textView, fooEditText, attrs, defStyle);
            
            Spinner.Touch += Spinner_Touch;
	    }

        public string Header
        {
            get { return Owner.Header; }
            set { Owner.Header = value; }
        }

        public ChamSpinnerOwner Owner { get; set; }

        public Spinner Spinner{ get; private set; }

		public IMvxAdapter Adapter
		{
			get { return Spinner.Adapter as IMvxAdapter; }
			set
			{
				var existing = Adapter;
				if (existing == value)
					return;

				if (existing != null && value != null)
				{
					value.ItemsSource = existing.ItemsSource;
					value.ItemTemplateId = existing.ItemTemplateId;
				}

				Spinner.Adapter = value;
			}
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

		public int DropDownItemTemplateId
		{
			get { return Adapter.DropDownItemTemplateId; }
			set { Adapter.DropDownItemTemplateId = value; }
		}

		public ICommand HandleItemSelected { get; set; }

		private void SetupHandleItemSelected ()
		{
			Spinner.ItemSelected += (sender, args) =>
			{
				var position = args.Position;
				HandleSelected (position);
				if (ItemSelected != null)
					ItemSelected (sender, args);
			    Error = null;
			};
		}

        private void Spinner_Touch(object sender, global::Android.Widget.AdapterView.TouchEventArgs e)
        {
            if (!string.IsNullOrEmpty(Owner.FooEditText.Error))
            {
                Spinner.RequestFocus();
                var imm = (InputMethodManager)Context.GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(Owner.FooEditText.WindowToken, 0);
                //Owner.FooEditText.RequestFocus();
            }
        }

		protected virtual void HandleSelected (int position)
		{
			var item = Adapter.GetRawItem (position);
			if (this.HandleItemSelected == null
			    || item == null
			    || !this.HandleItemSelected.CanExecute (item))
				return;

			this.HandleItemSelected.Execute (item);

		}

		public string Error
		{
            set { Owner.Error = value; }
		}

		public bool Required
		{
            get { return Owner.Required; }
            set { Owner.Required = value; }
		}
	}
}

