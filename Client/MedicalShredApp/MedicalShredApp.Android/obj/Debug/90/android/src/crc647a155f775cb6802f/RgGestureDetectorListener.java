package crc647a155f775cb6802f;


public class RgGestureDetectorListener
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSingleTapUp:(Landroid/view/MotionEvent;)Z:GetOnSingleTapUp_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Rg.Plugins.Popup.Droid.Gestures.RgGestureDetectorListener, Rg.Plugins.Popup.Droid", RgGestureDetectorListener.class, __md_methods);
	}


	public RgGestureDetectorListener ()
	{
		super ();
		if (getClass () == RgGestureDetectorListener.class)
			mono.android.TypeManager.Activate ("Rg.Plugins.Popup.Droid.Gestures.RgGestureDetectorListener, Rg.Plugins.Popup.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean onSingleTapUp (android.view.MotionEvent p0)
	{
		return n_onSingleTapUp (p0);
	}

	private native boolean n_onSingleTapUp (android.view.MotionEvent p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
