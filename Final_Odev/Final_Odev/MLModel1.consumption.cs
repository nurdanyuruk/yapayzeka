﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace Final_Odev
{
    public partial class MLModel1
    {
        /// <summary>
        /// model input class for MLModel1.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"HomeTeam")]
            public string HomeTeam { get; set; }

            [ColumnName(@"AwayTeam")]
            public string AwayTeam { get; set; }

            [ColumnName(@"FTHomeGol")]
            public float FTHomeGol { get; set; }

            [ColumnName(@"FTAwayGol")]
            public float FTAwayGol { get; set; }

            [ColumnName(@"HomeShot")]
            public float HomeShot { get; set; }

            [ColumnName(@"AwayShot")]
            public float AwayShot { get; set; }

            [ColumnName(@"HomeCorner")]
            public float HomeCorner { get; set; }

            [ColumnName(@"AwayCorner")]
            public float AwayCorner { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for MLModel1.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"HomeTeam")]
            public float[] HomeTeam { get; set; }

            [ColumnName(@"AwayTeam")]
            public float[] AwayTeam { get; set; }

            [ColumnName(@"FTHomeGol")]
            public float FTHomeGol { get; set; }

            [ColumnName(@"FTAwayGol")]
            public float FTAwayGol { get; set; }

            [ColumnName(@"HomeShot")]
            public float HomeShot { get; set; }

            [ColumnName(@"AwayShot")]
            public float AwayShot { get; set; }

            [ColumnName(@"HomeCorner")]
            public float HomeCorner { get; set; }

            [ColumnName(@"AwayCorner")]
            public float AwayCorner { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("MLModel1.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}