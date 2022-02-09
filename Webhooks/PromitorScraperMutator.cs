using PromitorOperator.Entities;
using KubeOps.Operator.Webhooks;

namespace PromitorOperator.Webhooks
{
    public class PromitorScraperMutator : IMutationWebhook<PromitorScraperEntity>
    {
        public AdmissionOperations Operations => AdmissionOperations.Create;

        public MutationResult Create(PromitorScraperEntity newEntity, bool dryRun)
        {
            newEntity.Spec.Name = "not foobar";
            return MutationResult.Modified(newEntity);
        }
    }
}
