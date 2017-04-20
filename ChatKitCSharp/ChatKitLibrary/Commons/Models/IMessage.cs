using Java.Util;
using System;

namespace ChatKitLibrary.Commons.Models
{
    public interface IMessage
    {
        string Id { get; }
        string Text { get; }
        IUser User { get; }
        Date CreatedAt { get; }
    }
}