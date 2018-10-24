using AutoMapper;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using WebExperience.Test.Models;

namespace WebExperience.Test.Bussines_Logic
{
    public class FilesManager : DbContext
    {
        public static bool Update(FileModel model)
        {
            try
            {
                using (Grafik_MasterEntities db = new Grafik_MasterEntities())
                {
                    var record = db.Files.FirstOrDefault(x => x.Id == model.Id);
                    record.FileName = model.FileName;
                    record.MimeType = model.MimeType;
                    record.Email = model.Email;
                    record.Description = model.Description;
                    record.CreatedBy = model.CreatedBy;
                    record.Country = model.Country;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Delete(Guid id)
        {
            try
            {
                using (Grafik_MasterEntities db = new Grafik_MasterEntities())
                {
                    var record = db.Files.FirstOrDefault(x => x.Id == id);
                    db.Files.Remove(record);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Create(FileModel model)
        {
            try
            {
                using (Grafik_MasterEntities db = new Grafik_MasterEntities())
                {
                    var record = new Files()
                    {
                        Id = new Guid(),
                        FileName = model.FileName,
                        MimeType = model.MimeType,
                        Country = model.Country,
                        CreatedBy = model.CreatedBy,
                        Description = model.Description,
                        Email = model.Email
                    };
                    db.Files.Add(record);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<FileModel> GetFilesList()
        {
            try
            {
                using (Grafik_MasterEntities db = new Grafik_MasterEntities())
                {
                    var fileList = db.Files.ToList();
                    var result = new List<FileModel>();
                    foreach(var item in fileList)
                    {
                        var model = new FileModel()
                        {
                            Id = item.Id,
                            FileName = item.FileName,
                            MimeType = item.MimeType,
                            Country = item.Country,
                            CreatedBy = item.CreatedBy,
                            Description = item.Description,
                            Email = item.Email
                        };
                        result.Add(model);

                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FileModel GetById(Guid id)
        {
            try
            {
                using (Grafik_MasterEntities db = new Grafik_MasterEntities())
                {
                    var record = db.Files.FirstOrDefault(x=>x.Id == id);
                    var model = new FileModel()
                    {
                        Id = record.Id,
                        FileName = record.FileName,
                        MimeType = record.MimeType,
                        Country = record.Country,
                        CreatedBy = record.CreatedBy,
                        Description = record.Description,
                        Email = record.Email
                    };
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string SaveFileToDatabase()
        {
            try
            {
                using (Grafik_MasterEntities db = new Grafik_MasterEntities())
                {
                    var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
                    var filePath = basePath.Replace("WebExperience.Test\\", "GeneralKnowledge.Test\\Resources\\AssetImport.csv");


                    var stream = new StreamReader(filePath);

                    var excelSheat = new List<string>();

                    var databaseCount = db.Files.Count();
                    if(databaseCount > 0)
                    {
                        return "The Data Base is already completed";
                    }
                    else
                    {
                        while (!stream.EndOfStream)
                        {
                            excelSheat.Add(stream.ReadLine());
                        }
                        foreach (var record in excelSheat.Skip(4))
                        {
                            var value = record.Split(',');
                            var file = new Files();
                            file.Id = new Guid(value[0]);
                            file.FileName = value[1];
                            file.MimeType = value[2];
                            file.CreatedBy = value[3];
                            file.Email = value[4];
                            file.Country = value[5];
                            file.Description = value[6];

                            db.Files.Add(file);
                            db.SaveChanges();

                        }
                        return "Success";
                    }
                }

            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
    }
}