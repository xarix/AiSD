namespace Lab4
{
    public class Results
    {
        public int MaxShipLoad { get; set; }

        public int GreedyAllRandomTime { get; set; }
        public int DynamicAllRandomTime { get; set; }
        public int GreedyRandomValueStaticWeightTime { get; set; }
        public int DynamicRandomValueStaticWeightTime { get; set; }
        public int GreedyStaticValueRandomWeightTime { get; set; }
        public int DynamicStaticValueRandomWeightTime { get; set; }
        public int GreedyAllRandomQuality { get; set; }
        public int DynamicAllRandomQuality { get; set; }
        public int GreedyRandomValueStaticWeightQuality { get; set; }
        public int DynamicRandomValueStaticWeightQuality { get; set; }
        public int GreedyStaticValueRandomWeightQuality { get; set; }
        public int DynamicStaticValueRandomWeightQuality { get; set; }

        public int RelativeErrorAllRandom { get; set; }
        public int RelativeErrorRandomValueStaticWeight { get; set; }
        public int RelativeErrorStaticValueRandomWeight { get; set; }
    }
}