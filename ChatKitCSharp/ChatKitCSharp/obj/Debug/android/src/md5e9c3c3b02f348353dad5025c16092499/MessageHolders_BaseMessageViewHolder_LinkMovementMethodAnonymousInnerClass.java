package md5e9c3c3b02f348353dad5025c16092499;


public class MessageHolders_BaseMessageViewHolder_LinkMovementMethodAnonymousInnerClass
	extends android.text.method.LinkMovementMethod
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/widget/TextView;Landroid/text/Spannable;Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_widget_TextView_Landroid_text_Spannable_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("ChatKitCSharp.Messages.MessageHolders+BaseMessageViewHolder+LinkMovementMethodAnonymousInnerClass, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MessageHolders_BaseMessageViewHolder_LinkMovementMethodAnonymousInnerClass.class, __md_methods);
	}


	public MessageHolders_BaseMessageViewHolder_LinkMovementMethodAnonymousInnerClass () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MessageHolders_BaseMessageViewHolder_LinkMovementMethodAnonymousInnerClass.class)
			mono.android.TypeManager.Activate ("ChatKitCSharp.Messages.MessageHolders+BaseMessageViewHolder+LinkMovementMethodAnonymousInnerClass, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MessageHolders_BaseMessageViewHolder_LinkMovementMethodAnonymousInnerClass (md5e9c3c3b02f348353dad5025c16092499.MessageHolders_BaseMessageViewHolder p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MessageHolders_BaseMessageViewHolder_LinkMovementMethodAnonymousInnerClass.class)
			mono.android.TypeManager.Activate ("ChatKitCSharp.Messages.MessageHolders+BaseMessageViewHolder+LinkMovementMethodAnonymousInnerClass, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "ChatKitCSharp.Messages.MessageHolders+BaseMessageViewHolder, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public boolean onTouchEvent (android.widget.TextView p0, android.text.Spannable p1, android.view.MotionEvent p2)
	{
		return n_onTouchEvent (p0, p1, p2);
	}

	private native boolean n_onTouchEvent (android.widget.TextView p0, android.text.Spannable p1, android.view.MotionEvent p2);

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
