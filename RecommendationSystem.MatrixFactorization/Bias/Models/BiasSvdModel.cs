using RecommendationSystem.MatrixFactorization.Training;

namespace RecommendationSystem.MatrixFactorization.Bias.Models
{
    public class BiasSvdModel : IBiasSvdModel
    {
        public float[,] UserFeatures { get; set; }
        public float[,] ArtistFeatures { get; set; }

        public int FeatureCount
        {
            get { return UserFeatures.GetUpperBound(0) + 1; }
        }

        public float GlobalAverage { get; set; }
        public float[] UserBias { get; set; }
        public float[] ArtistBias { get; set; }

        internal BiasSvdModel()
        {}

        public BiasSvdModel(float[,] userFeatures, float[,] artistFeatures, float globalAverage, float[] userBias, float[] artistBias, TrainingParameters trainingParameters)
        {
            UserFeatures = userFeatures;
            ArtistFeatures = artistFeatures;
            GlobalAverage = globalAverage;
            UserBias = userBias;
            ArtistBias = artistBias;
        }

        public BiasSvdModel(float globalAverage, float[] userBias, float[] artistBias)
        {
            GlobalAverage = globalAverage;
            UserBias = userBias;
            ArtistBias = artistBias;
        }
    }
}