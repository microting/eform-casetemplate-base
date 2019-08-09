using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.eFormCaseTemplateCase.Unit.Tests
{
    [TestFixture]
    public class UploadedDataUTest : DbTestFixture
    {
        [Test]
        public void UploadedData_Create_DoesCreate()
        {
            //Arrange
            
            Random rnd = new Random();
            
            short minValue = Int16.MinValue;
            short maxValue = Int16.MaxValue;
            
            UploadedData uploadedData = new UploadedData();
            uploadedData.Checksum = Guid.NewGuid().ToString();
            uploadedData.Extension = Guid.NewGuid().ToString();
            uploadedData.CurrentFile = Guid.NewGuid().ToString();
            uploadedData.FileLocation = Guid.NewGuid().ToString();
            uploadedData.FileName = Guid.NewGuid().ToString();
            uploadedData.UploaderType = Guid.NewGuid().ToString();
            uploadedData.Local = (short) rnd.Next(minValue, maxValue);
            uploadedData.ExpirationDate = DateTime.Now;
            uploadedData.OriginalFileName = Guid.NewGuid().ToString();

            //Act
            
            uploadedData.Create(DbContext);
            
            List<UploadedData> dbUploadedDatas = DbContext.UploadedDatas.AsNoTracking().ToList();
            List<UploadedDataVersion> dbUploadedDataVersions = DbContext.UploadedDataVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbUploadedDatas);
            Assert.NotNull(dbUploadedDataVersions);
            
            Assert.AreEqual(1, dbUploadedDatas.Count);
            Assert.AreEqual(1, dbUploadedDataVersions.Count);
            
            
            Assert.AreEqual(uploadedData.Id, dbUploadedDatas[0].Id);
            Assert.AreEqual(uploadedData.Version, dbUploadedDatas[0].Version);
            Assert.AreEqual(uploadedData.CreatedAt.ToString(), dbUploadedDatas[0].CreatedAt.ToString());
            Assert.AreEqual(uploadedData.UpdatedAt.ToString(), dbUploadedDatas[0].UpdatedAt.ToString());
            Assert.AreEqual(uploadedData.CreatedByUserId, dbUploadedDatas[0].CreatedByUserId);
            Assert.AreEqual(uploadedData.UpdatedByUserId, dbUploadedDatas[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbUploadedDatas[0].WorkflowState);
            Assert.AreEqual(uploadedData.Checksum, dbUploadedDatas[0].Checksum);
            Assert.AreEqual(uploadedData.Extension, dbUploadedDatas[0].Extension);
            Assert.AreEqual(uploadedData.Local, dbUploadedDatas[0].Local);
            Assert.AreEqual(uploadedData.CurrentFile, dbUploadedDatas[0].CurrentFile);
            Assert.AreEqual(uploadedData.ExpirationDate.ToString(), dbUploadedDatas[0].ExpirationDate.ToString());
            Assert.AreEqual(uploadedData.FileLocation, dbUploadedDatas[0].FileLocation);
            Assert.AreEqual(uploadedData.FileName, dbUploadedDatas[0].FileName);
            Assert.AreEqual(uploadedData.UploaderType, dbUploadedDatas[0].UploaderType);
            Assert.AreEqual(uploadedData.OriginalFileName, dbUploadedDatas[0].OriginalFileName);

            //Versions
            Assert.AreEqual(uploadedData.Id, dbUploadedDataVersions[0].UploadedDataId);
            Assert.AreEqual(1, dbUploadedDataVersions[0].Version);
            Assert.AreEqual(uploadedData.CreatedAt.ToString(), dbUploadedDataVersions[0].CreatedAt.ToString());
            Assert.AreEqual(uploadedData.UpdatedAt.ToString(), dbUploadedDataVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(uploadedData.CreatedByUserId, dbUploadedDataVersions[0].CreatedByUserId);
            Assert.AreEqual(uploadedData.UpdatedByUserId, dbUploadedDataVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbUploadedDataVersions[0].WorkflowState);
            Assert.AreEqual(uploadedData.Checksum, dbUploadedDataVersions[0].Checksum);
            Assert.AreEqual(uploadedData.Extension, dbUploadedDataVersions[0].Extension);
            Assert.AreEqual(uploadedData.Local, dbUploadedDataVersions[0].Local);
            Assert.AreEqual(uploadedData.CurrentFile, dbUploadedDataVersions[0].CurrentFile);
            Assert.AreEqual(uploadedData.ExpirationDate.ToString(), dbUploadedDataVersions[0].ExpirationDate.ToString());
            Assert.AreEqual(uploadedData.FileLocation, dbUploadedDataVersions[0].FileLocation);
            Assert.AreEqual(uploadedData.FileName, dbUploadedDataVersions[0].FileName);
            Assert.AreEqual(uploadedData.UploaderType, dbUploadedDataVersions[0].UploaderType);
            Assert.AreEqual(uploadedData.OriginalFileName, dbUploadedDatas[0].OriginalFileName);
        }

        [Test]
        public void UploadedData_Update_DoesUpdate()
        {
            //Arrange
            
            Random rnd = new Random();
            
            short minValue = Int16.MinValue;
            short maxValue = Int16.MaxValue;
            
            UploadedData uploadedData = new UploadedData();
            uploadedData.Checksum = Guid.NewGuid().ToString();
            uploadedData.Extension = Guid.NewGuid().ToString();
            uploadedData.CurrentFile = Guid.NewGuid().ToString();
            uploadedData.FileLocation = Guid.NewGuid().ToString();
            uploadedData.FileName = Guid.NewGuid().ToString();
            uploadedData.UploaderType = Guid.NewGuid().ToString();
            uploadedData.Local = (short) rnd.Next(minValue, maxValue);
            uploadedData.ExpirationDate = DateTime.Now;
            uploadedData.OriginalFileName = Guid.NewGuid().ToString();
            uploadedData.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = uploadedData.UpdatedAt;
            string oldChecksum = uploadedData.Checksum;
            string oldExtension = uploadedData.Extension;
            string oldCurrentFIle = uploadedData.CurrentFile;
            string oldFileLocation = uploadedData.FileLocation;
            string oldFileName = uploadedData.FileName;
            string oldUploaderType = uploadedData.UploaderType;
            int? oldLocal = uploadedData.Local;
            DateTime? oldExpirationDate = uploadedData.ExpirationDate;
            string oldOriginalFileName = uploadedData.OriginalFileName;
            
            uploadedData.Checksum = Guid.NewGuid().ToString();
            uploadedData.Extension = Guid.NewGuid().ToString();
            uploadedData.CurrentFile = Guid.NewGuid().ToString();
            uploadedData.FileLocation = Guid.NewGuid().ToString();
            uploadedData.FileName = Guid.NewGuid().ToString();
            uploadedData.UploaderType = Guid.NewGuid().ToString();
            uploadedData.Local = (short) rnd.Next(minValue, maxValue);
            uploadedData.ExpirationDate = DateTime.Now;
            uploadedData.OriginalFileName = Guid.NewGuid().ToString();

            uploadedData.Update(DbContext);
            
            List<UploadedData> dbUploadedDatas = DbContext.UploadedDatas.AsNoTracking().ToList();
            List<UploadedDataVersion> dbUploadedDataVersions = DbContext.UploadedDataVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbUploadedDatas);
            Assert.NotNull(dbUploadedDataVersions);
            
            Assert.AreEqual(1, dbUploadedDatas.Count);
            Assert.AreEqual(2, dbUploadedDataVersions.Count);
            
            
            Assert.AreEqual(uploadedData.Id, dbUploadedDatas[0].Id);
            Assert.AreEqual(uploadedData.Version, dbUploadedDatas[0].Version);
            Assert.AreEqual(uploadedData.CreatedAt.ToString(), dbUploadedDatas[0].CreatedAt.ToString());
            Assert.AreEqual(uploadedData.UpdatedAt.ToString(), dbUploadedDatas[0].UpdatedAt.ToString());
            Assert.AreEqual(uploadedData.CreatedByUserId, dbUploadedDatas[0].CreatedByUserId);
            Assert.AreEqual(uploadedData.UpdatedByUserId, dbUploadedDatas[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbUploadedDatas[0].WorkflowState);
            Assert.AreEqual(uploadedData.Checksum, dbUploadedDatas[0].Checksum);
            Assert.AreEqual(uploadedData.Extension, dbUploadedDatas[0].Extension);
            Assert.AreEqual(uploadedData.Local, dbUploadedDatas[0].Local);
            Assert.AreEqual(uploadedData.CurrentFile, dbUploadedDatas[0].CurrentFile);
            Assert.AreEqual(uploadedData.ExpirationDate.ToString(), dbUploadedDatas[0].ExpirationDate.ToString());
            Assert.AreEqual(uploadedData.FileLocation, dbUploadedDatas[0].FileLocation);
            Assert.AreEqual(uploadedData.FileName, dbUploadedDatas[0].FileName);
            Assert.AreEqual(uploadedData.UploaderType, dbUploadedDatas[0].UploaderType);
            Assert.AreEqual(uploadedData.OriginalFileName, dbUploadedDatas[0].OriginalFileName);

            //Old Version
            Assert.AreEqual(uploadedData.Id, dbUploadedDataVersions[0].UploadedDataId);
            Assert.AreEqual(1, dbUploadedDataVersions[0].Version);
            Assert.AreEqual(uploadedData.CreatedAt.ToString(), dbUploadedDataVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbUploadedDataVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(uploadedData.CreatedByUserId, dbUploadedDataVersions[0].CreatedByUserId);
            Assert.AreEqual(uploadedData.UpdatedByUserId, dbUploadedDataVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbUploadedDataVersions[0].WorkflowState);
            Assert.AreEqual(oldChecksum, dbUploadedDataVersions[0].Checksum);
            Assert.AreEqual(oldExtension, dbUploadedDataVersions[0].Extension);
            Assert.AreEqual(oldLocal, dbUploadedDataVersions[0].Local);
            Assert.AreEqual(oldCurrentFIle, dbUploadedDataVersions[0].CurrentFile);
            Assert.AreEqual(oldExpirationDate.ToString(), dbUploadedDataVersions[0].ExpirationDate.ToString());
            Assert.AreEqual(oldFileLocation, dbUploadedDataVersions[0].FileLocation);
            Assert.AreEqual(oldFileName, dbUploadedDataVersions[0].FileName);
            Assert.AreEqual(oldUploaderType, dbUploadedDataVersions[0].UploaderType);
            Assert.AreEqual(oldOriginalFileName, dbUploadedDataVersions[0].OriginalFileName);
            
            //New Version
            Assert.AreEqual(uploadedData.Id, dbUploadedDataVersions[1].UploadedDataId);
            Assert.AreEqual(2, dbUploadedDataVersions[1].Version);
            Assert.AreEqual(uploadedData.CreatedAt.ToString(), dbUploadedDataVersions[1].CreatedAt.ToString());
            Assert.AreEqual(uploadedData.UpdatedAt.ToString(), dbUploadedDataVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(uploadedData.CreatedByUserId, dbUploadedDataVersions[1].CreatedByUserId);
            Assert.AreEqual(uploadedData.UpdatedByUserId, dbUploadedDataVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbUploadedDataVersions[1].WorkflowState);
            Assert.AreEqual(uploadedData.Checksum, dbUploadedDataVersions[1].Checksum);
            Assert.AreEqual(uploadedData.Extension, dbUploadedDataVersions[1].Extension);
            Assert.AreEqual(uploadedData.Local, dbUploadedDataVersions[1].Local);
            Assert.AreEqual(uploadedData.CurrentFile, dbUploadedDataVersions[1].CurrentFile);
            Assert.AreEqual(uploadedData.ExpirationDate.ToString(), dbUploadedDataVersions[1].ExpirationDate.ToString());
            Assert.AreEqual(uploadedData.FileLocation, dbUploadedDataVersions[1].FileLocation);
            Assert.AreEqual(uploadedData.FileName, dbUploadedDataVersions[1].FileName);
            Assert.AreEqual(uploadedData.UploaderType, dbUploadedDataVersions[1].UploaderType);
            Assert.AreEqual(uploadedData.OriginalFileName, dbUploadedDataVersions[1].OriginalFileName);
        }

        [Test]
        public void UploadedData_Delete_DoesSetWorkflowStateToRemoved()
        {
             //Arrange
            
            Random rnd = new Random();
            
            short minValue = Int16.MinValue;
            short maxValue = Int16.MaxValue;
            
            UploadedData uploadedData = new UploadedData();
            uploadedData.Checksum = Guid.NewGuid().ToString();
            uploadedData.Extension = Guid.NewGuid().ToString();
            uploadedData.CurrentFile = Guid.NewGuid().ToString();
            uploadedData.FileLocation = Guid.NewGuid().ToString();
            uploadedData.FileName = Guid.NewGuid().ToString();
            uploadedData.UploaderType = Guid.NewGuid().ToString();
            uploadedData.Local = (short) rnd.Next(minValue, maxValue);
            uploadedData.ExpirationDate = DateTime.Now;
            uploadedData.OriginalFileName = Guid.NewGuid().ToString();
            uploadedData.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = uploadedData.UpdatedAt;

            uploadedData.Delete(DbContext);
            
            List<UploadedData> dbUploadedDatas = DbContext.UploadedDatas.AsNoTracking().ToList();
            List<UploadedDataVersion> dbUploadedDataVersions = DbContext.UploadedDataVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbUploadedDatas);
            Assert.NotNull(dbUploadedDataVersions);
            
            Assert.AreEqual(1, dbUploadedDatas.Count);
            Assert.AreEqual(2, dbUploadedDataVersions.Count);
            
            
            Assert.AreEqual(uploadedData.Id, dbUploadedDatas[0].Id);
            Assert.AreEqual(uploadedData.Version, dbUploadedDatas[0].Version);
            Assert.AreEqual(uploadedData.CreatedAt.ToString(), dbUploadedDatas[0].CreatedAt.ToString());
            Assert.AreEqual(uploadedData.UpdatedAt.ToString(), dbUploadedDatas[0].UpdatedAt.ToString());
            Assert.AreEqual(uploadedData.CreatedByUserId, dbUploadedDatas[0].CreatedByUserId);
            Assert.AreEqual(uploadedData.UpdatedByUserId, dbUploadedDatas[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbUploadedDatas[0].WorkflowState);
            Assert.AreEqual(uploadedData.Checksum, dbUploadedDatas[0].Checksum);
            Assert.AreEqual(uploadedData.Extension, dbUploadedDatas[0].Extension);
            Assert.AreEqual(uploadedData.Local, dbUploadedDatas[0].Local);
            Assert.AreEqual(uploadedData.CurrentFile, dbUploadedDatas[0].CurrentFile);
            Assert.AreEqual(uploadedData.ExpirationDate.ToString(), dbUploadedDatas[0].ExpirationDate.ToString());
            Assert.AreEqual(uploadedData.FileLocation, dbUploadedDatas[0].FileLocation);
            Assert.AreEqual(uploadedData.FileName, dbUploadedDatas[0].FileName);
            Assert.AreEqual(uploadedData.UploaderType, dbUploadedDatas[0].UploaderType);
            Assert.AreEqual(uploadedData.OriginalFileName, dbUploadedDatas[0].OriginalFileName);

            //Old Version
            Assert.AreEqual(uploadedData.Id, dbUploadedDataVersions[0].UploadedDataId);
            Assert.AreEqual(1, dbUploadedDataVersions[0].Version);
            Assert.AreEqual(uploadedData.CreatedAt.ToString(), dbUploadedDataVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbUploadedDataVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(uploadedData.CreatedByUserId, dbUploadedDataVersions[0].CreatedByUserId);
            Assert.AreEqual(uploadedData.UpdatedByUserId, dbUploadedDataVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbUploadedDataVersions[0].WorkflowState);
            Assert.AreEqual(uploadedData.Checksum, dbUploadedDataVersions[0].Checksum);
            Assert.AreEqual(uploadedData.Extension, dbUploadedDataVersions[0].Extension);
            Assert.AreEqual(uploadedData.Local, dbUploadedDataVersions[0].Local);
            Assert.AreEqual(uploadedData.CurrentFile, dbUploadedDataVersions[0].CurrentFile);
            Assert.AreEqual(uploadedData.ExpirationDate.ToString(), dbUploadedDataVersions[0].ExpirationDate.ToString());
            Assert.AreEqual(uploadedData.FileLocation, dbUploadedDataVersions[0].FileLocation);
            Assert.AreEqual(uploadedData.FileName, dbUploadedDataVersions[0].FileName);
            Assert.AreEqual(uploadedData.UploaderType, dbUploadedDataVersions[0].UploaderType);
            Assert.AreEqual(uploadedData.OriginalFileName, dbUploadedDatas[0].OriginalFileName);
            
            //New Version
            Assert.AreEqual(uploadedData.Id, dbUploadedDataVersions[1].UploadedDataId);
            Assert.AreEqual(2, dbUploadedDataVersions[1].Version);
            Assert.AreEqual(uploadedData.CreatedAt.ToString(), dbUploadedDataVersions[1].CreatedAt.ToString());
            Assert.AreEqual(uploadedData.UpdatedAt.ToString(), dbUploadedDataVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(uploadedData.CreatedByUserId, dbUploadedDataVersions[1].CreatedByUserId);
            Assert.AreEqual(uploadedData.UpdatedByUserId, dbUploadedDataVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbUploadedDataVersions[1].WorkflowState);
            Assert.AreEqual(uploadedData.Checksum, dbUploadedDataVersions[1].Checksum);
            Assert.AreEqual(uploadedData.Extension, dbUploadedDataVersions[1].Extension);
            Assert.AreEqual(uploadedData.Local, dbUploadedDataVersions[1].Local);
            Assert.AreEqual(uploadedData.CurrentFile, dbUploadedDataVersions[1].CurrentFile);
            Assert.AreEqual(uploadedData.ExpirationDate.ToString(), dbUploadedDataVersions[1].ExpirationDate.ToString());
            Assert.AreEqual(uploadedData.FileLocation, dbUploadedDataVersions[1].FileLocation);
            Assert.AreEqual(uploadedData.FileName, dbUploadedDataVersions[1].FileName);
            Assert.AreEqual(uploadedData.UploaderType, dbUploadedDataVersions[1].UploaderType);
            Assert.AreEqual(uploadedData.OriginalFileName, dbUploadedDataVersions[1].OriginalFileName);
        }
    }
}