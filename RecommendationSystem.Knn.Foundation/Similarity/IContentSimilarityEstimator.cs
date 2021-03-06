using RecommendationSystem.Entities;

namespace RecommendationSystem.Knn.Foundation.Similarity
{
    public interface IContentSimilarityEstimator
    {
        float GenderWeight { get; set; }
        float CountryWeight { get; set; }
        float AgeWeight { get; set; }

        float GetSimilarity(IUser first, IUser second);
    }
}