using System.IO;

public class FileDTO : IDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public Stream file { get; set; }
    public Stream image { get; set; }

    public void fromEntity(IBaseFileEntity e)
    {

    }

    public IBaseFileEntity toEntity()
    {
        
    }
}