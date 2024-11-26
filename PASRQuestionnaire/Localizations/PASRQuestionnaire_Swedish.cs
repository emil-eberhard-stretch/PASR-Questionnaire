using Blaappen.FormDefinitions.Api.Documents.Localization;
using Blaappen.FormDefinitions.Localization;
using Blaappen.Logic.Questionnaires.PASR;

namespace Blaappen.Logic.Questionnaires.PASR
{
    internal class PASRQuestionnaire_Swedish : LocalizedQuestionnaireDefinition
    {
        public PASRQuestionnaire_Swedish(PASRQuestionnaire definition)
            : base(definition, SupportedContentCulture.Swedish)
        {
            var swedishType = DefineType(definition.Type, t =>
            {
                t.Name(displayName: "PASR", fullName: "Preschool Anxiety Scale Revised");
                t.Description(shortDescription: "Vårdnadshavarkattning av ångest och rädslor hos barn i förskoleåldern", staffShortDescription: "Vårdnadshavarkattning av ångest och rädslor hos barn i förskoleåldern");
                t.ShortScoreDescription("Kan användas som ett stöd i bedömningen av möjlig ångestproblematik hos barn i förskoleåldern. Normer och cutoff-poäng saknas.");
                t.Copyright("© Macquarie University, Sydney, Australia");
            });

            // Analysis group
            var analysisGroup = DefineAnalysisGroup(swedishType, definition.AnalysisGroup, ag =>
            {
                ag.DisplayName("PASR");
                ag.AnalysisGroupDimension(
                    new LocalizedAnalysisGroupDimension(PASRQuestionnaire.ScoreName.TotalScore, "Totalpoäng"),
                    new LocalizedAnalysisGroupDimension(PASRQuestionnaire.ScoreName.GeneralisedAnxiety, "Generaliserad ångest"),
                    new LocalizedAnalysisGroupDimension(PASRQuestionnaire.ScoreName.SocialAnxiety, "Social ångest"),
                    new LocalizedAnalysisGroupDimension(PASRQuestionnaire.ScoreName.SeperationAnxiety, "Separationsångest"),
                    new LocalizedAnalysisGroupDimension(PASRQuestionnaire.ScoreName.SpecificFears, "Specifika fobier"));
            });

            // Caretaker variant
            DefineVariantVersion(swedishType, definition.CaretakerVariantVersion, vv => vv.AnalysisGroup(analysisGroup));
        }
    }
}
