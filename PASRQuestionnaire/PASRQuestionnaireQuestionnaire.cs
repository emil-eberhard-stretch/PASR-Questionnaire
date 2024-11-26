using System;
using System.Collections.Generic;
using Blaappen.FormDefinitions.Api.Documents.Questionnaires.ScoreDefinitions;
using Blaappen.FormDefinitions.Localization;
using Blaappen.Logic.Definitions.Questionnaires.ScoreCalculators;

namespace Blaappen.Logic.Questionnaires.PASR
{
    public class PASRQuestionnaire : Questionnaire
    {
        public PASRQuestionnaire()
        {
            // Define the questionnaire type
            Type = DefineType(t =>
            {
                t.Name("Pasr");
                t.Availability(AvailabilityStatus.Preview);
                t.CriteriaBehavior(FormCriteriaBehavior.Warn);
                t.ClinicalKeywords(new[] { "Ångest", "Rädslor", "Oro" });
            });

            // Define analysis group
            AnalysisGroup = DefineAnalysisGroup(Type, g =>
            {
                g.Name("PASR");
                g.DimensionAggregates(new DimensionAggregate<ScoreName>(ScoreName.TotalScore));
                g.Chart(
                    minValue: 0,
                    maxValue: 112,
                    stepSize: 10,
                    style: ChartStyle.BarChart,
                    comparativeStyle: ChartStyle.LineChartForDimension);
            });

            // Define caretaker variant
            CaretakerVariantVersion = DefineVariantVersion(Type, v =>
            {
                v.Name("PasrCaretaker");
                v.InformantAndAnswerMode(Informant.Caretaker);
                v.ContentComponentName("PASR");
                v.ContentSupportedLanguage(SupportedContentCulture.Swedish);
                v.AddCriteria(new AgeCriteria(from: 2, to: 7));
                v.Scoring<PASRScoreCalculator, ScoreName>(AnalysisGroup);
            });
        }

        public enum ScoreName
        {
            TotalScore,
            GeneralisedAnxiety,
            SocialAnxiety,
            SeperationAnxiety,
            SpecificFears,
        }

        public QuestionnaireType Type { get; }

        public AnalysisGroup AnalysisGroup { get; }

        public QuestionnaireVariantVersion CaretakerVariantVersion { get; }
    }
}
