﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace MLModel1_ConsoleApp1
{
    public partial class MLModel1
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
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
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"FTHomeGol", @"FTHomeGol"),new InputOutputColumnPair(@"FTAwayGol", @"FTAwayGol"),new InputOutputColumnPair(@"HomeShot", @"HomeShot"),new InputOutputColumnPair(@"AwayShot", @"AwayShot"),new InputOutputColumnPair(@"AwayCorner", @"AwayCorner")})      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"HomeTeam",outputColumnName:@"HomeTeam"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"AwayTeam",outputColumnName:@"AwayTeam"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"FTHomeGol",@"FTAwayGol",@"HomeShot",@"AwayShot",@"AwayCorner",@"HomeTeam",@"AwayTeam"}))      
                                    .Append(mlContext.Regression.Trainers.FastForest(new FastForestRegressionTrainer.Options(){NumberOfTrees=4,NumberOfLeaves=4,FeatureFraction=1F,LabelColumnName=@"HomeCorner",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
}
