using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities
{
    public class UploadedDatas : BaseEntity
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
            UploadedDatas uploadedDatas = dbContext.UploadedDatas.FirstOrDefault(x => x.Id == Id);

            if (uploadedDatas == null)
            {
                throw new NullReferenceException($"Could not find Uploaded Data with ID {Id}");
            }

            uploadedDatas.Checksum = Checksum;
            uploadedDatas.Extension = Extension;
            uploadedDatas.CurrentFile = CurrentFile;
            uploadedDatas.UploaderType = UploaderType;
            uploadedDatas.FileLocation = FileLocation;
            uploadedDatas.FileName = FileName;
            uploadedDatas.ExpirationDate = ExpirationDate;
            uploadedDatas.Local = Local;
            uploadedDatas.OriginalFileName = OriginalFileName;

            if (dbContext.ChangeTracker.HasChanges())
            {
                uploadedDatas.UpdatedAt = DateTime.Now;
                uploadedDatas.Version += 1;
                
                dbContext.UploadedDataVersions.Add(MapVersion(dbContext, uploadedDatas));
                dbContext.SaveChanges();
            }
        }

        public void Delete(CaseTemplatePnDbContext dbContext)
        {
            UploadedDatas uploadedDatas = dbContext.UploadedDatas.FirstOrDefault(x => x.Id == Id);

            if (uploadedDatas == null)
            {
                throw new NullReferenceException($"Could not find Uploaded Data with ID {Id}");
            }


            uploadedDatas.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                uploadedDatas.UpdatedAt = DateTime.Now;
                uploadedDatas.Version += 1;
                
                dbContext.UploadedDataVersions.Add(MapVersion(dbContext, uploadedDatas));
                dbContext.SaveChanges();
            }
        }

        public UploadedDataVersions MapVersion(CaseTemplatePnDbContext dbContext, UploadedDatas uploadedDatas)
        {
            UploadedDataVersions uploadedDataVersions = new UploadedDataVersions();

            uploadedDataVersions.Checksum = uploadedDatas.Checksum;
            uploadedDataVersions.Extension = uploadedDatas.Extension;
            uploadedDataVersions.CurrentFile = uploadedDatas.CurrentFile;
            uploadedDataVersions.UploaderType = uploadedDatas.UploaderType;
            uploadedDataVersions.FileLocation = uploadedDatas.FileLocation;
            uploadedDataVersions.FileName = uploadedDatas.FileName;
            uploadedDataVersions.ExpirationDate = uploadedDatas.ExpirationDate;
            uploadedDataVersions.Local = uploadedDatas.Local;
            uploadedDataVersions.OriginalFileName = uploadedDatas.OriginalFileName;

            uploadedDataVersions.Version = uploadedDatas.Version;
            uploadedDataVersions.CreatedAt = uploadedDatas.CreatedAt;
            uploadedDataVersions.UpdatedAt = uploadedDatas.UpdatedAt;
            uploadedDataVersions.CreatedByUserId = uploadedDatas.CreatedByUserId;
            uploadedDataVersions.UpdatedByUserId = uploadedDatas.UpdatedByUserId;
            uploadedDataVersions.WorkflowState = uploadedDatas.WorkflowState;

            uploadedDataVersions.UploadedDataId = uploadedDatas.Id;

            return uploadedDataVersions;
        }
        
    }
}