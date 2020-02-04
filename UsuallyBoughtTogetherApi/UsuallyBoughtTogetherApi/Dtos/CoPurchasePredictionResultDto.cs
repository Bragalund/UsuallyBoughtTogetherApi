using System;

namespace UsuallyBoughtTogetherApi.Dtos
{
    public class CoPurchasePredictionResultDto : IComparable<CoPurchasePredictionResultDto>
    {
        
        public CoPurchasePredictionResultDto(float score, int vareId)
        {
            CoPurchasePredictionDto = new CoPurchasePredictionDto(score);
            this.vareId = vareId;
        }

        private CoPurchasePredictionDto CoPurchasePredictionDto { get; set; }
        private int vareId { get; set; }

        public int CompareTo(CoPurchasePredictionResultDto other)
        {
            return this.CoPurchasePredictionDto.Score.CompareTo(other.CoPurchasePredictionDto.Score);
        }
    }
}