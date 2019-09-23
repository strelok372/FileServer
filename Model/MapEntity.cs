using System.ComponentModel.DataAnnotations;

public class MapEntity : IBaseFileEntity
{
    [Key]
    public string name { get; set; }
    public int size { get; set; }
    public string description { get; set; }
    public string picturePath { get; set; }
}