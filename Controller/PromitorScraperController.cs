using System;
using System.Threading.Tasks;
using PromitorOperator.Entities;
using PromitorOperator.Finalizer;
using k8s.Models;
using KubeOps.Operator.Controller;
using KubeOps.Operator.Controller.Results;
using KubeOps.Operator.Finalizer;
using KubeOps.Operator.Rbac;
using Microsoft.Extensions.Logging;

namespace PromitorOperator.Controller
{
    [EntityRbac(typeof(PromitorScraperEntity), Verbs = RbacVerb.All)]
    public class PromitorScraperController : IResourceController<PromitorScraperEntity>
    {
        private readonly ILogger<PromitorScraperController> _logger;
        private readonly IFinalizerManager<PromitorScraperEntity> _finalizerManager;

        public PromitorScraperController(ILogger<PromitorScraperController> logger, IFinalizerManager<PromitorScraperEntity> finalizerManager)
        {
            _logger = logger;
            _finalizerManager = finalizerManager;
        }

        public async Task<ResourceControllerResult?> CreatedAsync(PromitorScraperEntity entity)
        {
            _logger.LogInformation($"entity {entity.Name()} called {nameof(CreatedAsync)}.");
            await _finalizerManager.RegisterFinalizerAsync<PromitorScraperFinalizer>(entity);

            return ResourceControllerResult.RequeueEvent(TimeSpan.FromSeconds(5));
        }

        public Task<ResourceControllerResult?> UpdatedAsync(PromitorScraperEntity entity)
        {
            _logger.LogInformation($"entity {entity.Name()} called {nameof(UpdatedAsync)}.");

            return Task.FromResult<ResourceControllerResult?>(
                ResourceControllerResult.RequeueEvent(TimeSpan.FromSeconds(5)));
        }

        public Task<ResourceControllerResult?> NotModifiedAsync(PromitorScraperEntity entity)
        {
            _logger.LogInformation($"entity {entity.Name()} called {nameof(NotModifiedAsync)}.");

            return Task.FromResult<ResourceControllerResult?>(
                ResourceControllerResult.RequeueEvent(TimeSpan.FromSeconds(5)));
        }

        public Task StatusModifiedAsync(PromitorScraperEntity entity)
        {
            _logger.LogInformation($"entity {entity.Name()} called {nameof(StatusModifiedAsync)}.");

            return Task.CompletedTask;
        }

        public Task DeletedAsync(PromitorScraperEntity entity)
        {
            _logger.LogInformation($"entity {entity.Name()} called {nameof(DeletedAsync)}.");

            return Task.CompletedTask;
        }
    }
}
