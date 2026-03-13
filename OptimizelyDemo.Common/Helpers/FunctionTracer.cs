using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Serilog;

namespace OptimizelyDemo.Common.Helpers
{
    public class FunctionTracer : IDisposable
    {
        private readonly string _functionName;
        private readonly Stopwatch _stopwatch;

        public FunctionTracer([CallerMemberName] string functionName = "")
        {
            _functionName = functionName;
            _stopwatch = Stopwatch.StartNew();
            Log.Information("Entering {FunctionName}", _functionName);
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            Log.Information("Exiting {FunctionName}. Execution time: {ElapsedMilliseconds}ms", _functionName, _stopwatch.ElapsedMilliseconds);
        }
    }
}
