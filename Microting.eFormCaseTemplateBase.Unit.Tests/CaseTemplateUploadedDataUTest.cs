using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.eFormCaseTemplateCase.Unit.Tests
{
    [TestFixture]
    public class CaseTemplateUploadedDataUTest : DbTestFixture
    {
        [Test]
        public async Task CaseTemplateUploadedData_Create_DoesCreate()
        {
            //Arrange

            short shortMin = Int16.MinValue;
            short shortMax = Int16.MaxValue;

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            CaseTemplate caseTemplate = new CaseTemplate
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                DescriptionFolderId = rnd.Next(1, 200),
                RetractIfApproved = randomBool
            };
            await caseTemplate.Create(DbContext);

            UploadedData uploadedData = new UploadedData();
            uploadedData.Checksum = Guid.NewGuid().ToString();
            uploadedData.Extension = Guid.NewGuid().ToString();
            uploadedData.Local = (short)rnd.Next(shortMin, shortMax);
            uploadedData.CurrentFile = Guid.NewGuid().ToString();
            uploadedData.ExpirationDate = DateTime.Now;
            uploadedData.FileLocation = Guid.NewGuid().ToString();
            uploadedData.FileName = Guid.NewGuid().ToString();
            uploadedData.UploaderType = Guid.NewGuid().ToString();
            uploadedData.OriginalFileName = Guid.NewGuid().ToString();
            await uploadedData.Create(DbContext);

            CaseTemplateUploadedData caseTemplateUploadedData = new CaseTemplateUploadedData();
            caseTemplateUploadedData.Approvable = randomBool;
            caseTemplateUploadedData.Title = Guid.NewGuid().ToString();
            caseTemplateUploadedData.CaseTemplateId = caseTemplate.Id;
            caseTemplateUploadedData.RetractIfApproved = randomBool;
            caseTemplateUploadedData.UploadedDataId = uploadedData.Id;

            //Act

            await caseTemplateUploadedData.Create(DbContext);

            List<CaseTemplateUploadedData> dbCaseTemplateUploadedDatas = DbContext.CaseTemplateUploadedDatas.AsNoTracking().ToList();
            List<CaseTemplateUploadedDataVersion> dbCaseTemplateUploadedDataVersions = DbContext.CaseTemplateUploadedDataVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateUploadedDatas);
            Assert.NotNull(dbCaseTemplateUploadedDataVersions);

            Assert.AreEqual(1, dbCaseTemplateUploadedDatas.Count);
            Assert.AreEqual(1, dbCaseTemplateUploadedDataVersions.Count);


            Assert.AreEqual(caseTemplateUploadedData.Id, dbCaseTemplateUploadedDatas[0].Id);
            Assert.AreEqual(caseTemplateUploadedData.Version, dbCaseTemplateUploadedDatas[0].Version);
            Assert.AreEqual(caseTemplateUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDatas[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDatas[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.CreatedByUserId, dbCaseTemplateUploadedDatas[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDatas[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDatas[0].WorkflowState);
            Assert.AreEqual(caseTemplateUploadedData.Approvable, dbCaseTemplateUploadedDatas[0].Approvable);
            Assert.AreEqual(caseTemplateUploadedData.Title, dbCaseTemplateUploadedDatas[0].Title);
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateUploadedDatas[0].CaseTemplateId);
            Assert.AreEqual(uploadedData.Id, dbCaseTemplateUploadedDatas[0].UploadedDataId);
            Assert.AreEqual(caseTemplateUploadedData.RetractIfApproved, dbCaseTemplateUploadedDatas[0].RetractIfApproved);

            //Versions
            Assert.AreEqual(caseTemplateUploadedData.Id, dbCaseTemplateUploadedDataVersions[0].Id);
            Assert.AreEqual(1, dbCaseTemplateUploadedDataVersions[0].Version);
            Assert.AreEqual(caseTemplateUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDataVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplateUploadedData.Approvable, dbCaseTemplateUploadedDataVersions[0].Approvable);
            Assert.AreEqual(caseTemplateUploadedData.Title, dbCaseTemplateUploadedDataVersions[0].Title);
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateUploadedDataVersions[0].CaseTemplateId);
            Assert.AreEqual(uploadedData.Id, dbCaseTemplateUploadedDataVersions[0].UploadedDataId);
            Assert.AreEqual(caseTemplateUploadedData.RetractIfApproved, dbCaseTemplateUploadedDataVersions[0].RetractIfApproved);
        }

        [Test]
        public async Task CaseTemplateUploadedData_Update_DoesUpdate()
        {
            //Arrange

            short shortMin = Int16.MinValue;
            short shortMax = Int16.MaxValue;

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            CaseTemplate caseTemplate = new CaseTemplate();
            caseTemplate.Approvable = randomBool;
            // caseTemplate.Body = Guid.NewGuid().ToString();
            // caseTemplate.Title = Guid.NewGuid().ToString();
            caseTemplate.AlwaysShow = randomBool;
            caseTemplate.EndAt = DateTime.Now;
            // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
            caseTemplate.StartAt = DateTime.Now;
            caseTemplate.DescriptionFolderId = rnd.Next(1, 200);
            caseTemplate.RetractIfApproved = randomBool;
            await caseTemplate.Create(DbContext);

            UploadedData uploadedData = new UploadedData();
            uploadedData.Checksum = Guid.NewGuid().ToString();
            uploadedData.Extension = Guid.NewGuid().ToString();
            uploadedData.Local = (short)rnd.Next(shortMin, shortMax);
            uploadedData.CurrentFile = Guid.NewGuid().ToString();
            uploadedData.ExpirationDate = DateTime.Now;
            uploadedData.FileLocation = Guid.NewGuid().ToString();
            uploadedData.FileName = Guid.NewGuid().ToString();
            uploadedData.UploaderType = Guid.NewGuid().ToString();
            uploadedData.OriginalFileName = Guid.NewGuid().ToString();
            await uploadedData.Create(DbContext);

            CaseTemplateUploadedData caseTemplateUploadedData = new CaseTemplateUploadedData();
            caseTemplateUploadedData.Approvable = randomBool;
            caseTemplateUploadedData.Title = Guid.NewGuid().ToString();
            caseTemplateUploadedData.CaseTemplateId = caseTemplate.Id;
            caseTemplateUploadedData.RetractIfApproved = randomBool;
            caseTemplateUploadedData.UploadedDataId = uploadedData.Id;
            await caseTemplateUploadedData.Create(DbContext);

            //Act

            DateTime? oldUpdatedAt = caseTemplateUploadedData.UpdatedAt;
            bool oldApprovable = caseTemplateUploadedData.Approvable;
            string oldTitle = caseTemplateUploadedData.Title;
            bool oldRetractIfApproved = caseTemplateUploadedData.RetractIfApproved;

            caseTemplateUploadedData.Approvable = randomBool;
            caseTemplateUploadedData.Title = Guid.NewGuid().ToString();
            caseTemplateUploadedData.RetractIfApproved = randomBool;

            await caseTemplateUploadedData.Update(DbContext);

            List<CaseTemplateUploadedData> dbCaseTemplateUploadedDatas = DbContext.CaseTemplateUploadedDatas.AsNoTracking().ToList();
            List<CaseTemplateUploadedDataVersion> dbCaseTemplateUploadedDataVersions = DbContext.CaseTemplateUploadedDataVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateUploadedDatas);
            Assert.NotNull(dbCaseTemplateUploadedDataVersions);

            Assert.AreEqual(1, dbCaseTemplateUploadedDatas.Count);
            Assert.AreEqual(2, dbCaseTemplateUploadedDataVersions.Count);


            Assert.AreEqual(caseTemplateUploadedData.Id, dbCaseTemplateUploadedDatas[0].Id);
            Assert.AreEqual(caseTemplateUploadedData.Version, dbCaseTemplateUploadedDatas[0].Version);
            Assert.AreEqual(caseTemplateUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDatas[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDatas[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.CreatedByUserId, dbCaseTemplateUploadedDatas[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDatas[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDatas[0].WorkflowState);
            Assert.AreEqual(caseTemplateUploadedData.Approvable, dbCaseTemplateUploadedDatas[0].Approvable);
            Assert.AreEqual(caseTemplateUploadedData.Title, dbCaseTemplateUploadedDatas[0].Title);
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateUploadedDatas[0].CaseTemplateId);
            Assert.AreEqual(uploadedData.Id, dbCaseTemplateUploadedDatas[0].UploadedDataId);
            Assert.AreEqual(caseTemplateUploadedData.RetractIfApproved, dbCaseTemplateUploadedDatas[0].RetractIfApproved);

            //Old Version
            Assert.AreEqual(caseTemplateUploadedData.Id, dbCaseTemplateUploadedDataVersions[0].Id);
            Assert.AreEqual(1, dbCaseTemplateUploadedDataVersions[0].Version);
            Assert.AreEqual(caseTemplateUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDataVersions[0].WorkflowState);
            Assert.AreEqual(oldApprovable, dbCaseTemplateUploadedDataVersions[0].Approvable);
            Assert.AreEqual(oldTitle, dbCaseTemplateUploadedDataVersions[0].Title);
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateUploadedDataVersions[0].CaseTemplateId);
            Assert.AreEqual(uploadedData.Id, dbCaseTemplateUploadedDataVersions[0].UploadedDataId);
            Assert.AreEqual(oldRetractIfApproved, dbCaseTemplateUploadedDataVersions[0].RetractIfApproved);

            //New Version
            Assert.AreEqual(caseTemplateUploadedData.Id, dbCaseTemplateUploadedDataVersions[1].CaseTemplateUploadedDataId);
            Assert.AreEqual(2, dbCaseTemplateUploadedDataVersions[1].Version);
            Assert.AreEqual(caseTemplateUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplateUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDataVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplateUploadedData.Approvable, dbCaseTemplateUploadedDataVersions[1].Approvable);
            Assert.AreEqual(caseTemplateUploadedData.Title, dbCaseTemplateUploadedDataVersions[1].Title);
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateUploadedDataVersions[1].CaseTemplateId);
            Assert.AreEqual(uploadedData.Id, dbCaseTemplateUploadedDataVersions[1].UploadedDataId);
            Assert.AreEqual(caseTemplateUploadedData.RetractIfApproved, dbCaseTemplateUploadedDataVersions[1].RetractIfApproved);
        }

        [Test]
        public async Task CaseTemplateUploadedData_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

            short shortMin = Int16.MinValue;
            short shortMax = Int16.MaxValue;

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            CaseTemplate caseTemplate = new CaseTemplate();
            caseTemplate.Approvable = randomBool;
            // caseTemplate.Body = Guid.NewGuid().ToString();
            // caseTemplate.Title = Guid.NewGuid().ToString();
            caseTemplate.AlwaysShow = randomBool;
            caseTemplate.EndAt = DateTime.Now;
            // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
            caseTemplate.StartAt = DateTime.Now;
            caseTemplate.DescriptionFolderId = rnd.Next(1, 200);
            caseTemplate.RetractIfApproved = randomBool;
            await caseTemplate.Create(DbContext);

            UploadedData uploadedData = new UploadedData();
            uploadedData.Checksum = Guid.NewGuid().ToString();
            uploadedData.Extension = Guid.NewGuid().ToString();
            uploadedData.Local = (short)rnd.Next(shortMin, shortMax);
            uploadedData.CurrentFile = Guid.NewGuid().ToString();
            uploadedData.ExpirationDate = DateTime.Now;
            uploadedData.FileLocation = Guid.NewGuid().ToString();
            uploadedData.FileName = Guid.NewGuid().ToString();
            uploadedData.UploaderType = Guid.NewGuid().ToString();
            uploadedData.OriginalFileName = Guid.NewGuid().ToString();
            await uploadedData.Create(DbContext);

            CaseTemplateUploadedData caseTemplateUploadedData = new CaseTemplateUploadedData();
            caseTemplateUploadedData.Approvable = randomBool;
            caseTemplateUploadedData.Title = Guid.NewGuid().ToString();
            caseTemplateUploadedData.CaseTemplateId = caseTemplate.Id;
            caseTemplateUploadedData.RetractIfApproved = randomBool;
            caseTemplateUploadedData.UploadedDataId = uploadedData.Id;
            await caseTemplateUploadedData.Create(DbContext);

            //Act

            DateTime? oldUpdatedAt = caseTemplateUploadedData.UpdatedAt;

            await caseTemplateUploadedData.Delete(DbContext);

            List<CaseTemplateUploadedData> dbCaseTemplateUploadedDatas = DbContext.CaseTemplateUploadedDatas.AsNoTracking().ToList();
            List<CaseTemplateUploadedDataVersion> dbCaseTemplateUploadedDataVersions = DbContext.CaseTemplateUploadedDataVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateUploadedDatas);
            Assert.NotNull(dbCaseTemplateUploadedDataVersions);

            Assert.AreEqual(1, dbCaseTemplateUploadedDatas.Count);
            Assert.AreEqual(2, dbCaseTemplateUploadedDataVersions.Count);


            Assert.AreEqual(caseTemplateUploadedData.Id, dbCaseTemplateUploadedDatas[0].Id);
            Assert.AreEqual(caseTemplateUploadedData.Version, dbCaseTemplateUploadedDatas[0].Version);
            Assert.AreEqual(caseTemplateUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDatas[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDatas[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.CreatedByUserId, dbCaseTemplateUploadedDatas[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDatas[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateUploadedDatas[0].WorkflowState);
            Assert.AreEqual(caseTemplateUploadedData.Approvable, dbCaseTemplateUploadedDatas[0].Approvable);
            Assert.AreEqual(caseTemplateUploadedData.Title, dbCaseTemplateUploadedDatas[0].Title);
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateUploadedDatas[0].CaseTemplateId);
            Assert.AreEqual(uploadedData.Id, dbCaseTemplateUploadedDatas[0].UploadedDataId);
            Assert.AreEqual(caseTemplateUploadedData.RetractIfApproved, dbCaseTemplateUploadedDatas[0].RetractIfApproved);

            //Old Version
            Assert.AreEqual(caseTemplateUploadedData.Id, dbCaseTemplateUploadedDataVersions[0].Id);
            Assert.AreEqual(1, dbCaseTemplateUploadedDataVersions[0].Version);
            Assert.AreEqual(caseTemplateUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDataVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplateUploadedData.Approvable, dbCaseTemplateUploadedDataVersions[0].Approvable);
            Assert.AreEqual(caseTemplateUploadedData.Title, dbCaseTemplateUploadedDataVersions[0].Title);
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateUploadedDataVersions[0].CaseTemplateId);
            Assert.AreEqual(uploadedData.Id, dbCaseTemplateUploadedDataVersions[0].UploadedDataId);
            Assert.AreEqual(caseTemplateUploadedData.RetractIfApproved, dbCaseTemplateUploadedDataVersions[0].RetractIfApproved);

            //New Version
            Assert.AreEqual(caseTemplateUploadedData.Id, dbCaseTemplateUploadedDataVersions[1].CaseTemplateUploadedDataId);
            Assert.AreEqual(2, dbCaseTemplateUploadedDataVersions[1].Version);
            Assert.AreEqual(caseTemplateUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplateUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateUploadedDataVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplateUploadedData.Approvable, dbCaseTemplateUploadedDataVersions[1].Approvable);
            Assert.AreEqual(caseTemplateUploadedData.Title, dbCaseTemplateUploadedDataVersions[1].Title);
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateUploadedDataVersions[1].CaseTemplateId);
            Assert.AreEqual(uploadedData.Id, dbCaseTemplateUploadedDataVersions[1].UploadedDataId);
            Assert.AreEqual(caseTemplateUploadedData.RetractIfApproved, dbCaseTemplateUploadedDataVersions[1].RetractIfApproved);
        }
    }
}