using System.Collections.Generic;
using System.Linq;
using RecommendationSystem.Entities;
using RecommendationSystem.Prediction;
using RecommendationSystem.Recommendations;

namespace RecommendationSystem.Naive.MedianRating
{
    public class MedianRatingRecommender : IRecommender<IMedianRatingModel>
    {
        public IPredictor<IMedianRatingModel> Predictor { get; set; }

        public MedianRatingRecommender()
        {
            Predictor = new MedianRatingPredictor();
        }

        public IEnumerable<IRecommendation> GenerateRecommendations(IUser user, IMedianRatingModel model, List<IArtist> artists)
        {
            var indices = user.Ratings.Select(rating => rating.ArtistIndex).ToList();
            return indices.Select(index => new Recommendation(artists[index], model.MedianRating)).Cast<IRecommendation>().ToList();
        }

        public float PredictRatingForArtist(IUser user, IMedianRatingModel model, List<IArtist> artists, int artistIndex)
        {
            return Predictor.PredictRatingForArtist(user, model, artists, artistIndex);
        }
    }
}