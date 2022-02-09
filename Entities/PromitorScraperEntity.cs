using k8s.Models;
using KubeOps.Operator.Entities;

namespace PromitorOperator.Entities
{
    [KubernetesEntity(Group = "locmai.dev", ApiVersion = "v1alpha1", Kind = "PromitorScraper")]
    public class PromitorScraperEntity : CustomKubernetesEntity<PromitorScraperEntity.PromitorScraperSpec, PromitorScraperEntity.PromitorScraperStatus>
    {
        public class PromitorScraperSpec
        {
            public string Name { get; set; } = string.Empty;
        }

        public class PromitorScraperStatus
        {
            public string ScraperStatus { get; set; } = string.Empty;
        }
    }
}
