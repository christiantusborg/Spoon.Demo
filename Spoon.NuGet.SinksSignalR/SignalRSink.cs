namespace Spoon.NuGet.SinksSignalR;

using Microsoft.AspNet.SignalR;
using Serilog.Events;
using Serilog.Sinks.PeriodicBatching;

public class SignalRSink : PeriodicBatchingSink
{
    readonly IFormatProvider _formatProvider;
    readonly IHubContext _context;
    readonly string[] _groupNames;
    readonly string[] _userIds;
    readonly string[] _excludedConnectionIds;
    
    /// <summary>
    /// A reasonable default for the number of events posted in
    /// each batch.
    /// </summary>
    public const int DefaultBatchPostingLimit = 5;

    /// <summary>
    /// A reasonable default time to wait between checking for event batches.
    /// </summary>
    public static readonly TimeSpan DefaultPeriod = TimeSpan.FromSeconds(2);    
    
    public SignalRSink(IHubContext context, int batchPostingLimit, TimeSpan period, IFormatProvider formatProvider, string[] groupNames = null, string[] userIds = null, string[] excludedConnectionIds = null)
        : base(batchPostingLimit, period)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));
        _formatProvider = formatProvider;
        _context = context;
        _groupNames = groupNames;
        _userIds = userIds;
        _excludedConnectionIds = excludedConnectionIds ?? Array.Empty<string>();
    }
    
    protected override void EmitBatch(IEnumerable<LogEvent> events)
    {
        // This sink doesn't use batching to send events, instead only using
        // PeriodicBatchingSink to manage the worker thread; requires some consideration.

        foreach (var logEvent in events)
        {
            dynamic target;
            // target the specified clients while opting out the excluded connections
            if (_groupNames != null && _groupNames != Array.Empty<string>())
                target = _context.Clients.Groups(_groupNames, _excludedConnectionIds);
            else if (_userIds != null && _userIds != Array.Empty<string>())
                target = _context.Clients.Users(_userIds);
            else
                target = _context.Clients.AllExcept(_excludedConnectionIds);

            // send the broadcast to the targeted connections
            target.sendLogEvent(new LogMessageEvent(logEvent, logEvent.RenderMessage(_formatProvider)));
        }
    }   
}