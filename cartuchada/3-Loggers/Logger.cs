using _2_Services.Interfaces;
using _3_Data.Models.Management_Models;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Loggers
{
    public class Logger : ILogger
    {
        private readonly AppDbContext _context;

        public Logger(AppDbContext context)
        {
            _context = context;
        }

        public async Task WriteLogEntryAsync(string logEntry)
        {
            var logModel = new LogModel
            {
                Date = DateTime.Now,
                Entry = logEntry
            };

            await _context.Logs.AddAsync(logModel);

            await ManageDeleteLogEntriesAsync();
        }

        public async Task ManageDeleteLogEntriesAsync()
        {
            var logs = await _context.Logs.ToListAsync();

            var _LOG_MAX_ENTRIES = LoggerConstants._LOG_MAX_ENTRIES;
            var _NUMBER_OF_ENTRIES_TO_DELETE = LoggerConstants._LOG_NUMBER_OF_ENTRIES_TO_DELETE_WHEN_MAX_REACHED;

            if (logs.Count >= _LOG_MAX_ENTRIES)
            {
                var logsToDelete = logs.OrderBy(log => log.Date)
                                       .Take(_NUMBER_OF_ENTRIES_TO_DELETE);

                _context.Logs.RemoveRange(logsToDelete);
            }
        }
    }
}
