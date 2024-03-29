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

            Document document = new Document
            {
                Approvable = randomBool,
                // caseTemplate.Name = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfName = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                FolderId = rnd.Next(1, 200),
                RetractIfApproved = randomBool
            };
            await document.Create(DbContext);

            DocumentUploadedData documentUploadedData = new DocumentUploadedData();
            documentUploadedData.Approvable = randomBool;
            documentUploadedData.Name = Guid.NewGuid().ToString();
            documentUploadedData.DocumentId = document.Id;
            documentUploadedData.RetractIfApproved = randomBool;

            //Act

            await documentUploadedData.Create(DbContext);

            List<DocumentUploadedData> dbCaseTemplateUploadedDatas = DbContext.DocumentUploadedDatas.AsNoTracking().ToList();
            List<DocumentUploadedDataVersion> dbCaseTemplateUploadedDataVersions = DbContext.DocumentUploadedDataVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateUploadedDatas);
            Assert.NotNull(dbCaseTemplateUploadedDataVersions);

            Assert.AreEqual(1, dbCaseTemplateUploadedDatas.Count);
            Assert.AreEqual(1, dbCaseTemplateUploadedDataVersions.Count);


            Assert.AreEqual(documentUploadedData.Id, dbCaseTemplateUploadedDatas[0].Id);
            Assert.AreEqual(documentUploadedData.Version, dbCaseTemplateUploadedDatas[0].Version);
            Assert.AreEqual(documentUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDatas[0].CreatedAt.ToString());
            Assert.AreEqual(documentUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDatas[0].UpdatedAt.ToString());
            Assert.AreEqual(documentUploadedData.CreatedByUserId, dbCaseTemplateUploadedDatas[0].CreatedByUserId);
            Assert.AreEqual(documentUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDatas[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDatas[0].WorkflowState);
            Assert.AreEqual(documentUploadedData.Approvable, dbCaseTemplateUploadedDatas[0].Approvable);
            Assert.AreEqual(documentUploadedData.Name, dbCaseTemplateUploadedDatas[0].Name);
            Assert.AreEqual(document.Id, dbCaseTemplateUploadedDatas[0].DocumentId);
            Assert.AreEqual(documentUploadedData.RetractIfApproved, dbCaseTemplateUploadedDatas[0].RetractIfApproved);

            //Versions
            Assert.AreEqual(documentUploadedData.Id, dbCaseTemplateUploadedDataVersions[0].Id);
            Assert.AreEqual(1, dbCaseTemplateUploadedDataVersions[0].Version);
            Assert.AreEqual(documentUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].CreatedAt.ToString());
            Assert.AreEqual(documentUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(documentUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[0].CreatedByUserId);
            Assert.AreEqual(documentUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDataVersions[0].WorkflowState);
            Assert.AreEqual(documentUploadedData.Approvable, dbCaseTemplateUploadedDataVersions[0].Approvable);
            Assert.AreEqual(documentUploadedData.Name, dbCaseTemplateUploadedDataVersions[0].Name);
            Assert.AreEqual(document.Id, dbCaseTemplateUploadedDataVersions[0].DocumentId);
            Assert.AreEqual(documentUploadedData.RetractIfApproved, dbCaseTemplateUploadedDataVersions[0].RetractIfApproved);
        }

        [Test]
        public async Task CaseTemplateUploadedData_Update_DoesUpdate()
        {
            //Arrange

            short shortMin = Int16.MinValue;
            short shortMax = Int16.MaxValue;

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            Document document = new Document();
            document.Approvable = randomBool;
            // caseTemplate.Body = Guid.NewGuid().ToString();
            // caseTemplate.Name = Guid.NewGuid().ToString();
            document.AlwaysShow = randomBool;
            document.EndAt = DateTime.Now;
            // caseTemplate.PdfName = Guid.NewGuid().ToString();
            document.StartAt = DateTime.Now;
            document.FolderId = rnd.Next(1, 200);
            document.RetractIfApproved = randomBool;
            await document.Create(DbContext);

            DocumentUploadedData documentUploadedData = new DocumentUploadedData();
            documentUploadedData.Approvable = randomBool;
            documentUploadedData.Name = Guid.NewGuid().ToString();
            documentUploadedData.DocumentId = document.Id;
            documentUploadedData.RetractIfApproved = randomBool;
            await documentUploadedData.Create(DbContext);

            //Act

            DateTime? oldUpdatedAt = documentUploadedData.UpdatedAt;
            bool oldApprovable = documentUploadedData.Approvable;
            string oldName = documentUploadedData.Name;
            bool oldRetractIfApproved = documentUploadedData.RetractIfApproved;

            documentUploadedData.Approvable = randomBool;
            documentUploadedData.Name = Guid.NewGuid().ToString();
            documentUploadedData.RetractIfApproved = randomBool;

            await documentUploadedData.Update(DbContext);

            List<DocumentUploadedData> dbCaseTemplateUploadedDatas = DbContext.DocumentUploadedDatas.AsNoTracking().ToList();
            List<DocumentUploadedDataVersion> dbCaseTemplateUploadedDataVersions = DbContext.DocumentUploadedDataVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateUploadedDatas);
            Assert.NotNull(dbCaseTemplateUploadedDataVersions);

            Assert.AreEqual(1, dbCaseTemplateUploadedDatas.Count);
            Assert.AreEqual(2, dbCaseTemplateUploadedDataVersions.Count);


            Assert.AreEqual(documentUploadedData.Id, dbCaseTemplateUploadedDatas[0].Id);
            Assert.AreEqual(documentUploadedData.Version, dbCaseTemplateUploadedDatas[0].Version);
            Assert.AreEqual(documentUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDatas[0].CreatedAt.ToString());
            Assert.AreEqual(documentUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDatas[0].UpdatedAt.ToString());
            Assert.AreEqual(documentUploadedData.CreatedByUserId, dbCaseTemplateUploadedDatas[0].CreatedByUserId);
            Assert.AreEqual(documentUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDatas[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDatas[0].WorkflowState);
            Assert.AreEqual(documentUploadedData.Approvable, dbCaseTemplateUploadedDatas[0].Approvable);
            Assert.AreEqual(documentUploadedData.Name, dbCaseTemplateUploadedDatas[0].Name);
            Assert.AreEqual(document.Id, dbCaseTemplateUploadedDatas[0].DocumentId);
            Assert.AreEqual(documentUploadedData.RetractIfApproved, dbCaseTemplateUploadedDatas[0].RetractIfApproved);

            //Old Version
            Assert.AreEqual(documentUploadedData.Id, dbCaseTemplateUploadedDataVersions[0].Id);
            Assert.AreEqual(1, dbCaseTemplateUploadedDataVersions[0].Version);
            Assert.AreEqual(documentUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(documentUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[0].CreatedByUserId);
            Assert.AreEqual(documentUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDataVersions[0].WorkflowState);
            Assert.AreEqual(oldApprovable, dbCaseTemplateUploadedDataVersions[0].Approvable);
            Assert.AreEqual(oldName, dbCaseTemplateUploadedDataVersions[0].Name);
            Assert.AreEqual(document.Id, dbCaseTemplateUploadedDataVersions[0].DocumentId);
            Assert.AreEqual(oldRetractIfApproved, dbCaseTemplateUploadedDataVersions[0].RetractIfApproved);

            //New Version
            Assert.AreEqual(documentUploadedData.Id, dbCaseTemplateUploadedDataVersions[1].DocumentUploadedDataId);
            Assert.AreEqual(2, dbCaseTemplateUploadedDataVersions[1].Version);
            Assert.AreEqual(documentUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[1].CreatedAt.ToString());
            Assert.AreEqual(documentUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(documentUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[1].CreatedByUserId);
            Assert.AreEqual(documentUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDataVersions[1].WorkflowState);
            Assert.AreEqual(documentUploadedData.Approvable, dbCaseTemplateUploadedDataVersions[1].Approvable);
            Assert.AreEqual(documentUploadedData.Name, dbCaseTemplateUploadedDataVersions[1].Name);
            Assert.AreEqual(document.Id, dbCaseTemplateUploadedDataVersions[1].DocumentId);
            Assert.AreEqual(documentUploadedData.RetractIfApproved, dbCaseTemplateUploadedDataVersions[1].RetractIfApproved);
        }

        [Test]
        public async Task CaseTemplateUploadedData_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

            short shortMin = Int16.MinValue;
            short shortMax = Int16.MaxValue;

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            Document document = new Document();
            document.Approvable = randomBool;
            // caseTemplate.Body = Guid.NewGuid().ToString();
            // caseTemplate.Name = Guid.NewGuid().ToString();
            document.AlwaysShow = randomBool;
            document.EndAt = DateTime.Now;
            // caseTemplate.PdfName = Guid.NewGuid().ToString();
            document.StartAt = DateTime.Now;
            document.FolderId = rnd.Next(1, 200);
            document.RetractIfApproved = randomBool;
            await document.Create(DbContext);



            DocumentUploadedData documentUploadedData = new DocumentUploadedData();
            documentUploadedData.Approvable = randomBool;
            documentUploadedData.Name = Guid.NewGuid().ToString();
            documentUploadedData.DocumentId = document.Id;
            documentUploadedData.RetractIfApproved = randomBool;
            await documentUploadedData.Create(DbContext);

            //Act

            DateTime? oldUpdatedAt = documentUploadedData.UpdatedAt;

            await documentUploadedData.Delete(DbContext);

            List<DocumentUploadedData> dbCaseTemplateUploadedDatas = DbContext.DocumentUploadedDatas.AsNoTracking().ToList();
            List<DocumentUploadedDataVersion> dbCaseTemplateUploadedDataVersions = DbContext.DocumentUploadedDataVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateUploadedDatas);
            Assert.NotNull(dbCaseTemplateUploadedDataVersions);

            Assert.AreEqual(1, dbCaseTemplateUploadedDatas.Count);
            Assert.AreEqual(2, dbCaseTemplateUploadedDataVersions.Count);


            Assert.AreEqual(documentUploadedData.Id, dbCaseTemplateUploadedDatas[0].Id);
            Assert.AreEqual(documentUploadedData.Version, dbCaseTemplateUploadedDatas[0].Version);
            Assert.AreEqual(documentUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDatas[0].CreatedAt.ToString());
            Assert.AreEqual(documentUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDatas[0].UpdatedAt.ToString());
            Assert.AreEqual(documentUploadedData.CreatedByUserId, dbCaseTemplateUploadedDatas[0].CreatedByUserId);
            Assert.AreEqual(documentUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDatas[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateUploadedDatas[0].WorkflowState);
            Assert.AreEqual(documentUploadedData.Approvable, dbCaseTemplateUploadedDatas[0].Approvable);
            Assert.AreEqual(documentUploadedData.Name, dbCaseTemplateUploadedDatas[0].Name);
            Assert.AreEqual(document.Id, dbCaseTemplateUploadedDatas[0].DocumentId);
            Assert.AreEqual(documentUploadedData.RetractIfApproved, dbCaseTemplateUploadedDatas[0].RetractIfApproved);

            //Old Version
            Assert.AreEqual(documentUploadedData.Id, dbCaseTemplateUploadedDataVersions[0].Id);
            Assert.AreEqual(1, dbCaseTemplateUploadedDataVersions[0].Version);
            Assert.AreEqual(documentUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(documentUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[0].CreatedByUserId);
            Assert.AreEqual(documentUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateUploadedDataVersions[0].WorkflowState);
            Assert.AreEqual(documentUploadedData.Approvable, dbCaseTemplateUploadedDataVersions[0].Approvable);
            Assert.AreEqual(documentUploadedData.Name, dbCaseTemplateUploadedDataVersions[0].Name);
            Assert.AreEqual(document.Id, dbCaseTemplateUploadedDataVersions[0].DocumentId);
            Assert.AreEqual(documentUploadedData.RetractIfApproved, dbCaseTemplateUploadedDataVersions[0].RetractIfApproved);

            //New Version
            Assert.AreEqual(documentUploadedData.Id, dbCaseTemplateUploadedDataVersions[1].DocumentUploadedDataId);
            Assert.AreEqual(2, dbCaseTemplateUploadedDataVersions[1].Version);
            Assert.AreEqual(documentUploadedData.CreatedAt.ToString(), dbCaseTemplateUploadedDataVersions[1].CreatedAt.ToString());
            Assert.AreEqual(documentUploadedData.UpdatedAt.ToString(), dbCaseTemplateUploadedDataVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(documentUploadedData.CreatedByUserId, dbCaseTemplateUploadedDataVersions[1].CreatedByUserId);
            Assert.AreEqual(documentUploadedData.UpdatedByUserId, dbCaseTemplateUploadedDataVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateUploadedDataVersions[1].WorkflowState);
            Assert.AreEqual(documentUploadedData.Approvable, dbCaseTemplateUploadedDataVersions[1].Approvable);
            Assert.AreEqual(documentUploadedData.Name, dbCaseTemplateUploadedDataVersions[1].Name);
            Assert.AreEqual(document.Id, dbCaseTemplateUploadedDataVersions[1].DocumentId);
            Assert.AreEqual(documentUploadedData.RetractIfApproved, dbCaseTemplateUploadedDataVersions[1].RetractIfApproved);
        }
    }
}