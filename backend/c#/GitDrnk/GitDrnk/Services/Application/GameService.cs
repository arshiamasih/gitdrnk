using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitDrnk.Services
{
    public class GameService
    {
        private readonly ILogger _logger;

        public GameService(ILogger logger)
        {
            this._logger = logger;
        }
    }
}
