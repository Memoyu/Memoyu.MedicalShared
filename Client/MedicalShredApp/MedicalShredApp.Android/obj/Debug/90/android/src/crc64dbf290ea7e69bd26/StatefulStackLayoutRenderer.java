package crc64dbf290ea7e69bd26;


public class StatefulStackLayoutRenderer
	extends crc643f46942d9dd1fff9.VisualElementRenderer_1
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnTouchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onTouch:(Landroid/view/View;Landroid/view/MotionEvent;)Z:GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Plugin.InputKit.Platforms.Droid.StatefulStackLayoutRenderer, Plugin.InputKit", StatefulStackLayoutRenderer.class, __md_methods);
	}


	public StatefulStackLayoutRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == StatefulStackLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.StatefulStackLayoutRenderer, Plugin.InputKit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public StatefulStackLayoutRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == StatefulStackLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.StatefulStackLayoutRenderer, Plugin.InputKit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public StatefulStackLayoutRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == StatefulStackLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.StatefulStackLayoutRenderer, Plugin.InputKit", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);


	public boolean onTouch (android.view.View p0, android.view.MotionEvent p1)
	{
		return n_onTouch (p0, p1);
	}

	private native boolean n_onTouch (android.view.View p0, android.view.MotionEvent p1);

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
