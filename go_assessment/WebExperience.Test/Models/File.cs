using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public FileModel() { }

        public FileModel(Files model)
        {
            Id = model.Id;
            FileName = model.FileName;
            MimeType = model.MimeType;
            CreatedBy = model.CreatedBy;
            Email = model.Email;
            Country = model.Country;
            Description = model.Description;
        }

        public FileModel(Guid id, string fileName, string createdBy, string mimeType, string country, string description, string email)
        {
            Id = id;
            FileName = fileName;
            MimeType = mimeType;
            CreatedBy = createdBy;
            Email = email;
            Country = country;
            Description = description;
        }

    }
}