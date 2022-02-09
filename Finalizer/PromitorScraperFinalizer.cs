using System.Threading.Tasks;
using PromitorOperator.Entities;
using k8s.Models;
using KubeOps.Operator.Finalizer;
using Microsoft.Extensions.Logging;

namespace PromitorOperator.Finalizer
{
    public class PromitorScraperFinalizer : IResourceFinalizer<PromitorScraperEntity>
    {
        private readonly ILogger<PromitorScraperFinalizer> _logger;

        public PromitorScraperFinalizer(ILogger<PromitorScraperFinalizer> logger)
        {
            _logger = logger;
        }

        public Task FinalizeAsync(PromitorScraperEntity entity)
        {
            _logger.LogInformation($"entity {entity.Name()} called {nameof(FinalizeAsync)}.");

            return Task.CompletedTask;
        }
    }
}
