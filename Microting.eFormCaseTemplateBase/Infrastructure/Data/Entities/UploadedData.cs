using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class UploadedData : BaseEntity
    {
        [StringLength(255)]
        public string Checksum { get; set; }
        
        [StringLength(255)]
        public string Extension { get; set; }

        [StringLength(255)]
        public string CurrentFile { get; set; }

        [StringLength(255)]
        public string UploaderType { get; set; }

        [StringLength(255)]
        public string FileLocation { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public short? Local { get; set; }
        
        public string OriginalFileName { get; set; }


        public void Create(CaseTemplatePnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.UploadedDatas.Add(this);
            dbContext.SaveChanges();

            dbContext.UploadedDataVersions.Add(MapVersion(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CaseTemplatePnDbContext dbContext)
        {
            UploadedData uploadedData = dbContext.UploadedDatas.FirstOrDefault(x => x.Id == Id);

            if (uploadedData == null)
            {
                throw new NullReferenceException($"Could not find Uploaded Data with ID {Id}");
            }

            uploadedData.Checksum = Checksum;
            uploadedData.Extension = Extension;
            uploadedData.CurrentFile = CurrentFile;
            uploadedData.UploaderType = UploaderType;
            uploadedData.FileLocation = FileLocation;
            uploadedData.FileName = FileName;
            uploadedData.ExpirationDate = ExpirationDate;
            uploadedData.Local = Local;
            uploadedData.OriginalFileName = OriginalFileName;

            if (dbContext.ChangeTracker.HasChanges())
            {
                uploadedData.UpdatedAt = DateTime.Now;
                uploadedData.Version += 1;
                
                dbContext.UploadedDataVersions.Add(MapVersion(dbContext, uploadedData));
                dbContext.SaveChanges();
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            UploadedData uploadedData = dbContext.UploadedDatas.FirstOrDefault(x => x.Id == Id);

            if (uploadedData == null)
            {
                throw new NullReferenceException($"Could not find Uploaded Data with ID {Id}");
            }


            uploadedData.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                uploadedData.UpdatedAt = DateTime.Now;
                uploadedData.Version += 1;
                
                dbContext.UploadedDataVersions.Add(MapVersion(dbContext, uploadedData));
                dbContext.SaveChanges();
            }
        }

        public UploadedDataVersion MapVersion(CaseTemplatePnDbContext dbContext, UploadedData uploadedData)
        {
            UploadedDataVersion uploadedDataVersion = new UploadedDataVersion();

            uploadedDataVersion.Checksum = uploadedData.Checksum;
            uploadedDataVersion.Extension = uploadedData.Extension;
            uploadedDataVersion.CurrentFile = uploadedData.CurrentFile;
            uploadedDataVersion.UploaderType = uploadedData.UploaderType;
            uploadedDataVersion.FileLocation = uploadedData.FileLocation;
            uploadedDataVersion.FileName = uploadedData.FileName;
            uploadedDataVersion.ExpirationDate = uploadedData.ExpirationDate;
            uploadedDataVersion.Local = uploadedData.Local;
            uploadedDataVersion.OriginalFileName = uploadedData.OriginalFileName;

            uploadedDataVersion.Version = uploadedData.Version;
            uploadedDataVersion.CreatedAt = uploadedData.CreatedAt;
            uploadedDataVersion.UpdatedAt = uploadedData.UpdatedAt;
            uploadedDataVersion.CreatedByUserId = uploadedData.CreatedByUserId;
            uploadedDataVersion.UpdatedByUserId = uploadedData.UpdatedByUserId;
            uploadedDataVersion.WorkflowState = uploadedData.WorkflowState;

            uploadedDataVersion.UploadedDataId = uploadedData.Id;

            return uploadedDataVersion;
        }
        
    }
}