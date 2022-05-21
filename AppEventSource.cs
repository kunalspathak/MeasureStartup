using System;
using System.Diagnostics.Tracing;

[EventSource(Name = "PaintDotnetTrace")]
public sealed class AppEventSource : EventSource
{
    public static AppEventSource Log = new AppEventSource();

    // The numbers passed to WriteEvent and EventAttribute
    // must increment with each logging method.
    [Event(1)]
    public void AppLaunched(int iterNumber) { WriteEvent(1, $"Iter{iterNumber}"); }
}