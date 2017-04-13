package md5edab455e1c4ad5afc37ce1de20c7f76e;


public abstract class DialogViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ChatKitCSharp.Commons.DialogViewHolder, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DialogViewHolder.class, __md_methods);
	}


	public DialogViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == DialogViewHolder.class)
			mono.android.TypeManager.Activate ("ChatKitCSharp.Commons.DialogViewHolder, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
