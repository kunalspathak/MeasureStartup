using System;
using System.Diagnostics;
using System.Threading;

public class Program
{

    public static int Main(string[] args)
    {
        if (args.Length != 4)
        {
            Console.WriteLine("MeasureStartup.exe <path_to_exe> <args_to_exe> <iterations> <delay_in_secs>");
            return 1;
        }

        string path = args[0];
        string arguments = args[1];
        int numIterations = int.Parse(args[2]);
        int delayInSecs = int.Parse(args[3]);

        Console.WriteLine($"Launching '{path} {arguments}' {numIterations} times with wait time before exit set to {delayInSecs} secs.");
        for (int i = 0; i < numIterations; i++)
        {
            StartProcess(i,  delayInSecs, path, arguments);
        }
        return 0;
    }


    public static void StartProcess(int iteration, int delayInSecs, string path, string args = "")
    {
        var psi = new ProcessStartInfo(path);
        psi.Arguments = args;
        psi.UseShellExecute = false;

        try
        {
            var process = new Process();
            process.StartInfo = psi;
            process.EnableRaisingEvents = true; //? TODO: Needed?
            process.Start();
            AppEventSource.Log.AppLaunched(iteration);
            Console.WriteLine($"{iteration} Process '{process.Id}' launched");
            Thread.Sleep(delayInSecs * 1000);
            process.Kill();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to start new app instance: {ex}");
        }
    }
}