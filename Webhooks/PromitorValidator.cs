using PromitorOperator.Entities;
using KubeOps.Operator.Webhooks;
using Microsoft.AspNetCore.Http;

namespace PromitorOperator.Webhooks
{
    public class PromitorValidator : IValidationWebhook<PromitorScraperEntity>
    {
        public AdmissionOperations Operations => AdmissionOperations.Create;

        public ValidationResult Create(PromitorScraperEntity newEntity, bool dryRun)
            => newEntity.Spec.Name == "forbiddenName"
                ? ValidationResult.Fail(StatusCodes.Status400BadRequest, "The specified name is forbidden")
                : ValidationResult.Success();
    }
}
