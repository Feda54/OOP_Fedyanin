namespace OOP_Arkhitectura_LAB
{
    public interface IStorable
    {
        string FilePath { get; }
        void Save(string filePath);
    }
}
