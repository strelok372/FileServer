public interface IBaseFileEntity
{
    string name { get; set; }
    int size { get; set; }
    string description { get; set; }
    string picturePath { get; set; }
}