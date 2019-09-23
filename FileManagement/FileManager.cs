using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

public class FileManager
{
    public FileManager()
    {
    }

    async void CleanFolder(string path)
    {
        var temp = Directory.GetFiles(path).ToList();

        foreach (var f in temp)
        {
            if (!f.EndsWith(".zip"))
            {
                await Task.Run(() =>
                {
                    File.Delete(f);
                });
            }
        }
        if (!Directory.Exists(path + "/Images"))
            Directory.CreateDirectory("Images");
    }


    public List<FileEntity> GetFiles(string path)
    {
        CleanFolder(path);
        var files = new List<FileEntity>();
        DirectoryInfo di = new DirectoryInfo(path);
        var fs = di.GetFiles();

        foreach (var item in fs)
        {
            FileEntity temp = new FileEntity();

            string picpath = path + item.Name.Split('.')[0] + "jpg";
            if (File.Exists(picpath))
                temp.picturePath = picpath;

            var zf = ZipFile.OpenRead(path + item.Name);
            var entry = zf.GetEntry("description.txt");
            if (entry != null)
            {
                using (StreamReader sr = new StreamReader(entry.Open()))
                {
                    temp.description = sr.ReadToEnd();
                }
            }
            temp.size = (item.Length / 1024);
            temp.name = item.Name;
            temp.filePath = item.FullName;

            files.Add(temp);
        }
        return files;
    }

    byte[] GetPicture(string path)
    {
        return File.ReadAllBytes(path);
    }

    //returns file in byte array if file exists else checking folder for updates
    public byte[] GetFileIfExist(string s)
    {
        if (File.Exists(s))
        {
            return File.ReadAllBytes(s);
        }
        else return null;
    }

    //add choosed file in browser by admin
    public IBaseFileEntity AddFile(IBaseFileEntity entity)
    {
        return null;
    }
    //update choosed file in browser by admin
    public IBaseFileEntity UpdateFile(IBaseFileEntity entity)
    {
        return null;
    }
    //delete choosed file in browser by admin
    public IBaseFileEntity DeleteFile(IBaseFileEntity entity)
    {
        return null;
    }
}