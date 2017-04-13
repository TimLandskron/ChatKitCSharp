using Java.Util;
using System;

namespace ChatKitCSharp.Commons.Models
{
    public interface IMessage
    {
        string Id { get; }
        string Text { get; }
        IUser User { get; }
        Date CreatedAt { get; }
    }
}