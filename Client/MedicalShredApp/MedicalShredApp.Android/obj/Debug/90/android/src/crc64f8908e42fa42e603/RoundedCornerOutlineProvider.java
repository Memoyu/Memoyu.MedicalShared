package crc64f8908e42fa42e603;


public class RoundedCornerOutlineProvider
	extends android.view.ViewOutlineProvider
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getOutline:(Landroid/view/View;Landroid/graphics/Outline;)V:GetGetOutline_Landroid_view_View_Landroid_graphics_Outline_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.PancakeView.Droid.RoundedCornerOutlineProvider, Xamarin.Forms.PancakeView", RoundedCornerOutlineProvider.class, __md_methods);
	}


	public RoundedCornerOutlineProvider ()
	{
		super ();
		if (getClass () == RoundedCornerOutlineProvider.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.PancakeView.Droid.RoundedCornerOutlineProvider, Xamarin.Forms.PancakeView", "", this, new java.lang.Object[] {  });
	}


	public void getOutline (android.view.View p0, android.graphics.Outline p1)
	{
		n_getOutline (p0, p1);
	}

	private native void n_getOutline (android.view.View p0, android.graphics.Outline p1);

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
