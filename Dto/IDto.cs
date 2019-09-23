using System.IO;

public interface IDTO{
    string Title{get; set;}
    string Description{get; set;}
    string Type{get; set;}
    Stream file{get; set;}
    Stream image{get; set;}

    IBaseFileEntity toEntity();
    void fromEntity(IBaseFileEntity e);
}