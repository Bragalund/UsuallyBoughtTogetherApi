namespace UsuallyBoughtTogetherApi.Dtos
{
    public class CoPurchasePredictionDto
    {
        public CoPurchasePredictionDto()
        {
            // empty for ML.Net library
        }

        public CoPurchasePredictionDto(float score)
        {
            Score = score;
        }

        public float Score { get; set; }
    }
}