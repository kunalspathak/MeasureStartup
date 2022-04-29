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

    // The numbers passed to WriteEvent and EventAttribute
    // must increment with each logging method.
    [Event(2)]
    public void AppStarted() { WriteEvent(2, ""); }

    [Event(3)]
    public void AppReady() { WriteEvent(3, ""); }

    [Event(4)]
    public void AppIdle()
    {
        if (firstIdleLogged)
        {
            return;
        }
        WriteEvent(4, "");
        firstIdleLogged = true;
    }
}