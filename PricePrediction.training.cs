﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.LightGbm;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace CryptoPricePrediction
{
    public partial class PricePrediction
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(@"open", @"open")      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"open"}))      
                                    .Append(mlContext.Regression.Trainers.LightGbm(new LightGbmRegressionTrainer.Options(){NumberOfLeaves=456,NumberOfIterations=766,MinimumExampleCountPerLeaf=20,LearningRate=0.0980626822229509,LabelColumnName=@"high",FeatureColumnName=@"Features",ExampleWeightColumnName=null,Booster=new GradientBooster.Options(){SubsampleFraction=5.10303196633832E-06,FeatureFraction=0.865450326380649,L1Regularization=0.0165402011181371,L2Regularization=0.0003361292449329},MaximumBinCountPerFeature=1022}));

            return pipeline;
        }
    }
}
