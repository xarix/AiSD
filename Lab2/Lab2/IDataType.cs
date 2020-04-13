namespace Lab2
{
    public interface IDataType
    {
        int MeasureInsertTime(int[] array);
        int MeasureSearchTime(int[] array);
        int MeasureDestroyTime();
    }
}