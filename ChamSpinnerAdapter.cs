using System;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Android.Content;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.ExtensionMethods;

namespace Cham.Droid.ToolkitX
{
	public class ChamSpinnerAdapter : MvxAdapter
	{
		protected static int EXTRA = 1;

		public ChamSpinnerAdapter (Context context) : base (context)
		{
		}

        //protected View getNothingSelectedView (ViewGroup parent)
        //{
        //    return LayoutInflater.From (Context).Inflate (Resource.Layout.spinner_row_nothing_selected, parent, false);
        //}

	    public override View GetDropDownView(int position, View convertView, ViewGroup parent)
	    {
	        return base.GetDropDownView(position, convertView, parent);
	    }

	    /*
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (position == 0) {
				return getNothingSelectedView(parent);
			}

			return base.GetView(position - EXTRA, null, parent);
		}

		public override View GetDropDownView (int position, View convertView, ViewGroup parent)
		{
			if (position == 0) {
				return //nothingSelectedDropdownLayout == -1 ?
					new View (Context);
					//getNothingSelectedDropdownView(parent);
			}

			// Could re-use the convertView if possible, use setTag...
			return base.GetDropDownView(position - EXTRA, null, parent);
		}

		public override int Count {
			get {
				int count = base.Count;
				return count == 0 ? 0 : count + EXTRA;
			}
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return position == 0 ? null : base.GetItem(position - EXTRA);
		}

		public override int GetItemViewType (int position)
		{
			return position == 0 ?
				ViewTypeCount - EXTRA :
				base.GetItemViewType(position - EXTRA);
		}

		public override int ViewTypeCount {
			get {
				return base.ViewTypeCount + EXTRA;
			}
		}

		public void SetError(String errorMessage) {
            //if (null != mEmptyText) {
            //    mEmptyText.setError(errorMessage);
            //} else {
            //    Log.d(TAG, "mEmptyText is null");
            //}
		}

*/
	}
}

