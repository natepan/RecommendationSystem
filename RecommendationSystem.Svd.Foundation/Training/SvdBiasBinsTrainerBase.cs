using System.Collections.Generic;
using RecommendationSystem.Data;
using RecommendationSystem.Entities;
using RecommendationSystem.Models;
using RecommendationSystem.Svd.Foundation.Models;
using RecommendationSystem.Training;

namespace RecommendationSystem.Svd.Foundation.Training
{
    public abstract class SvdBiasBinsTrainerBase<TBiasBinsSvdModel> : SvdTrainerBase<TBiasBinsSvdModel>, ISvdBiasBinsTrainer<TBiasBinsSvdModel>
        where TBiasBinsSvdModel : ISvdBiasBinsModel
    {
        public IBiasBinsCalculator<TBiasBinsSvdModel> BiasBinsCalculator { get; set; }

        protected SvdBiasBinsTrainerBase(IBiasBinsCalculator<TBiasBinsSvdModel> biasBinsCalculator)
        {
            BiasBinsCalculator = biasBinsCalculator;
            ModelSaver.ModelPartSavers.Add(new BiasBinsModelPartSaver());
        }

        public new TBiasBinsSvdModel TrainModel(List<IUser> trainUsers, List<IArtist> artists, List<IRating> trainRatings, TrainingParameters trainingParameters)
        {
            var model = TrainModel(trainUsers.GetLookupTable(), artists.GetLookupTable(), trainRatings, trainingParameters);
            BiasBinsCalculator.CalculateBiasBins(model, trainRatings, trainUsers, artists, trainingParameters.BiasBinCount);
            return model;
        }
    }
}