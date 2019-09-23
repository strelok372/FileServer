using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class DoomRepo
{
    DBC _db;
    FileManager _fm;

    public DoomRepo(DBC dBC, FileManager fm)
    {
        _db = dBC;
        _fm = fm;
    }

    //Обновить базу данных по состоянию файлов в папках
    public void UpdateDb()
    {
        _db.Database.ExecuteSqlCommand("delete from Maps; delete from Mods;");

        var mods = _fm.GetFiles("Mods");
        var maps = _fm.GetFiles("Maps");

        maps.ForEach(map => _db.Add((MapEntity)map));
        mods.ForEach(mod => _db.Add((ModEntity)mod));

        _db.SaveChanges();
    }

    public void Add(IBaseFileEntity e)
    {
        _db.Add(e);
    }

    public void Delete(IBaseFileEntity e)
    {

    }

    public void Update(IBaseFileEntity e)
    {

    }

    public List<string> GetFilesInfo()
    {

    }

    public byte[] GetPicture<T>(string name) where T : IBaseFileEntity
    {
        var tRecord = (IBaseFileEntity)_db.Find(typeof(T), name);
        if (tRecord != null)
        {
            return _fm.GetPicture(tRecord.picturePath);
        }
        return null;
    }

    //Получить файл по названию из контроллера
    public byte[] GetFile<T>(string name) where T : IBaseFileEntity
    {
        var tRecord = (IBaseFileEntity)_db.Find(typeof(T), name);
        if (tRecord != null)
        {
            return _fm.GetFileIfExist(tRecord.filePath);
        }
        return null;
    }

}