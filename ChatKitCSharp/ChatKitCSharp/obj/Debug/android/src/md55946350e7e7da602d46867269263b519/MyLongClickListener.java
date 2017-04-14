package md55946350e7e7da602d46867269263b519;


public class MyLongClickListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnLongClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLongClick:(Landroid/view/View;)Z:GetOnLongClick_Landroid_view_View_Handler:Android.Views.View/IOnLongClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("ChatKitCSharp.Dialogs.MyLongClickListener, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyLongClickListener.class, __md_methods);
	}


	public MyLongClickListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyLongClickListener.class)
			mono.android.TypeManager.Activate ("ChatKitCSharp.Dialogs.MyLongClickListener, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onLongClick (android.view.View p0)
	{
		return n_onLongClick (p0);
	}

	private native boolean n_onLongClick (android.view.View p0);

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
