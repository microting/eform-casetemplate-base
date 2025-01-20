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
            Assert.That(dbCaseTemplateUploadedDatas, Is.Not.Null);
            Assert.That(dbCaseTemplateUploadedDataVersions, Is.Not.Null);

            Assert.That(dbCaseTemplateUploadedDatas.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplateUploadedDataVersions.Count, Is.EqualTo(1));


            Assert.That(dbCaseTemplateUploadedDatas[0].Id, Is.EqualTo(documentUploadedData.Id));
            Assert.That(dbCaseTemplateUploadedDatas[0].Version, Is.EqualTo(documentUploadedData.Version));
            Assert.That(dbCaseTemplateUploadedDatas[0].CreatedAt.ToString(), Is.EqualTo(documentUploadedData.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDatas[0].UpdatedAt.ToString(), Is.EqualTo(documentUploadedData.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDatas[0].CreatedByUserId, Is.EqualTo(documentUploadedData.CreatedByUserId));
            Assert.That(dbCaseTemplateUploadedDatas[0].UpdatedByUserId, Is.EqualTo(documentUploadedData.UpdatedByUserId));
            Assert.That(dbCaseTemplateUploadedDatas[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateUploadedDatas[0].Approvable, Is.EqualTo(documentUploadedData.Approvable));
            Assert.That(dbCaseTemplateUploadedDatas[0].Name, Is.EqualTo(documentUploadedData.Name));
            Assert.That(dbCaseTemplateUploadedDatas[0].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateUploadedDatas[0].RetractIfApproved, Is.EqualTo(documentUploadedData.RetractIfApproved));

            //Versions
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Id, Is.EqualTo(documentUploadedData.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Version, Is.EqualTo(1));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].CreatedAt.ToString(), Is.EqualTo(documentUploadedData.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].UpdatedAt.ToString(), Is.EqualTo(documentUploadedData.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].CreatedByUserId, Is.EqualTo(documentUploadedData.CreatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].UpdatedByUserId, Is.EqualTo(documentUploadedData.UpdatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Approvable, Is.EqualTo(documentUploadedData.Approvable));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Name, Is.EqualTo(documentUploadedData.Name));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].RetractIfApproved, Is.EqualTo(documentUploadedData.RetractIfApproved));
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
            Assert.That(dbCaseTemplateUploadedDatas, Is.Not.Null);
            Assert.That(dbCaseTemplateUploadedDataVersions, Is.Not.Null);

            Assert.That(dbCaseTemplateUploadedDatas.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplateUploadedDataVersions.Count, Is.EqualTo(2));


            Assert.That(dbCaseTemplateUploadedDatas[0].Id, Is.EqualTo(documentUploadedData.Id));
            Assert.That(dbCaseTemplateUploadedDatas[0].Version, Is.EqualTo(documentUploadedData.Version));
            Assert.That(dbCaseTemplateUploadedDatas[0].CreatedAt.ToString(), Is.EqualTo(documentUploadedData.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDatas[0].UpdatedAt.ToString(), Is.EqualTo(documentUploadedData.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDatas[0].CreatedByUserId, Is.EqualTo(documentUploadedData.CreatedByUserId));
            Assert.That(dbCaseTemplateUploadedDatas[0].UpdatedByUserId, Is.EqualTo(documentUploadedData.UpdatedByUserId));
            Assert.That(dbCaseTemplateUploadedDatas[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateUploadedDatas[0].Approvable, Is.EqualTo(documentUploadedData.Approvable));
            Assert.That(dbCaseTemplateUploadedDatas[0].Name, Is.EqualTo(documentUploadedData.Name));
            Assert.That(dbCaseTemplateUploadedDatas[0].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateUploadedDatas[0].RetractIfApproved, Is.EqualTo(documentUploadedData.RetractIfApproved));

            //Old Version
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Id, Is.EqualTo(documentUploadedData.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Version, Is.EqualTo(1));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].CreatedAt.ToString(), Is.EqualTo(documentUploadedData.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].CreatedByUserId, Is.EqualTo(documentUploadedData.CreatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].UpdatedByUserId, Is.EqualTo(documentUploadedData.UpdatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Approvable, Is.EqualTo(oldApprovable));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Name, Is.EqualTo(oldName));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].RetractIfApproved, Is.EqualTo(oldRetractIfApproved));

            //New Version
            Assert.That(dbCaseTemplateUploadedDataVersions[1].DocumentUploadedDataId, Is.EqualTo(documentUploadedData.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].Version, Is.EqualTo(2));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].CreatedAt.ToString(), Is.EqualTo(documentUploadedData.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].UpdatedAt.ToString(), Is.EqualTo(documentUploadedData.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].CreatedByUserId, Is.EqualTo(documentUploadedData.CreatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].UpdatedByUserId, Is.EqualTo(documentUploadedData.UpdatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].Approvable, Is.EqualTo(documentUploadedData.Approvable));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].Name, Is.EqualTo(documentUploadedData.Name));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].RetractIfApproved, Is.EqualTo(documentUploadedData.RetractIfApproved));
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
            Assert.That(dbCaseTemplateUploadedDatas, Is.Not.Null);
            Assert.That(dbCaseTemplateUploadedDataVersions, Is.Not.Null);

            Assert.That(dbCaseTemplateUploadedDatas.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplateUploadedDataVersions.Count, Is.EqualTo(2));


            Assert.That(dbCaseTemplateUploadedDatas[0].Id, Is.EqualTo(documentUploadedData.Id));
            Assert.That(dbCaseTemplateUploadedDatas[0].Version, Is.EqualTo(documentUploadedData.Version));
            Assert.That(dbCaseTemplateUploadedDatas[0].CreatedAt.ToString(), Is.EqualTo(documentUploadedData.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDatas[0].UpdatedAt.ToString(), Is.EqualTo(documentUploadedData.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDatas[0].CreatedByUserId, Is.EqualTo(documentUploadedData.CreatedByUserId));
            Assert.That(dbCaseTemplateUploadedDatas[0].UpdatedByUserId, Is.EqualTo(documentUploadedData.UpdatedByUserId));
            Assert.That(dbCaseTemplateUploadedDatas[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbCaseTemplateUploadedDatas[0].Approvable, Is.EqualTo(documentUploadedData.Approvable));
            Assert.That(dbCaseTemplateUploadedDatas[0].Name, Is.EqualTo(documentUploadedData.Name));
            Assert.That(dbCaseTemplateUploadedDatas[0].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateUploadedDatas[0].RetractIfApproved, Is.EqualTo(documentUploadedData.RetractIfApproved));

            //Old Version
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Id, Is.EqualTo(documentUploadedData.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Version, Is.EqualTo(1));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].CreatedAt.ToString(), Is.EqualTo(documentUploadedData.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].CreatedByUserId, Is.EqualTo(documentUploadedData.CreatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].UpdatedByUserId, Is.EqualTo(documentUploadedData.UpdatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Approvable, Is.EqualTo(documentUploadedData.Approvable));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].Name, Is.EqualTo(documentUploadedData.Name));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[0].RetractIfApproved, Is.EqualTo(documentUploadedData.RetractIfApproved));

            //New Version
            Assert.That(dbCaseTemplateUploadedDataVersions[1].DocumentUploadedDataId, Is.EqualTo(documentUploadedData.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].Version, Is.EqualTo(2));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].CreatedAt.ToString(), Is.EqualTo(documentUploadedData.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].UpdatedAt.ToString(), Is.EqualTo(documentUploadedData.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].CreatedByUserId, Is.EqualTo(documentUploadedData.CreatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].UpdatedByUserId, Is.EqualTo(documentUploadedData.UpdatedByUserId));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].Approvable, Is.EqualTo(documentUploadedData.Approvable));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].Name, Is.EqualTo(documentUploadedData.Name));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateUploadedDataVersions[1].RetractIfApproved, Is.EqualTo(documentUploadedData.RetractIfApproved));
        }
    }
}