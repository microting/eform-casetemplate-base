using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eForm.Infrastructure.Data.Entities;
using Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.eFormCaseTemplateCase.Unit.Tests
{
    [TestFixture]
    public class CaseTemplatesUTest : DbTestFixture
    {
        [Test]
        public async Task CaseTemplates_Create_DoesCreate()
        {
            //Arrange

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            Document document = new Document
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                FolderId = rnd.Next(1, 200),
                RetractIfApproved = randomBool
            };

            //Act

            await document.Create(DbContext);


            List<Document> dbCaseTemplates = DbContext.Documents.AsNoTracking().ToList();
            List<DocumentVersion> dbCaseTemplateVersions = DbContext.DocumentVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplates);
            Assert.NotNull(dbCaseTemplateVersions);

            Assert.AreEqual(1, dbCaseTemplates.Count);
            Assert.AreEqual(1, dbCaseTemplateVersions.Count);


            Assert.AreEqual(document.Id, dbCaseTemplates[0].Id);
            Assert.AreEqual(document.Version, dbCaseTemplates[0].Version);
            Assert.AreEqual(document.CreatedAt.ToString(), dbCaseTemplates[0].CreatedAt.ToString());
            Assert.AreEqual(document.UpdatedAt.ToString(), dbCaseTemplates[0].UpdatedAt.ToString());
            Assert.AreEqual(document.CreatedByUserId, dbCaseTemplates[0].CreatedByUserId);
            Assert.AreEqual(document.UpdatedByUserId, dbCaseTemplates[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplates[0].WorkflowState);
            Assert.AreEqual(document.Approvable, dbCaseTemplates[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplates[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplates[0].Title);
            Assert.AreEqual(document.AlwaysShow, dbCaseTemplates[0].AlwaysShow);
            Assert.AreEqual(document.EndAt.ToString(), dbCaseTemplates[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplates[0].PdfTitle);
            Assert.AreEqual(document.StartAt.ToString(), dbCaseTemplates[0].StartAt.ToString());
            Assert.AreEqual(document.FolderId, dbCaseTemplates[0].FolderId);
            Assert.AreEqual(document.RetractIfApproved, dbCaseTemplates[0].RetractIfApproved);

            //Versions
            Assert.AreEqual(document.Id, dbCaseTemplateVersions[0].Id);
            Assert.AreEqual(document.Version, dbCaseTemplateVersions[0].Version);
            Assert.AreEqual(document.CreatedAt.ToString(), dbCaseTemplateVersions[0].CreatedAt.ToString());
            Assert.AreEqual(document.UpdatedAt.ToString(), dbCaseTemplateVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(document.CreatedByUserId, dbCaseTemplateVersions[0].CreatedByUserId);
            Assert.AreEqual(document.UpdatedByUserId, dbCaseTemplateVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateVersions[0].WorkflowState);
            Assert.AreEqual(document.Approvable, dbCaseTemplateVersions[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplateVersions[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplateVersions[0].Title);
            Assert.AreEqual(document.AlwaysShow, dbCaseTemplateVersions[0].AlwaysShow);
            Assert.AreEqual(document.EndAt.ToString(), dbCaseTemplateVersions[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplateVersions[0].PdfTitle);
            Assert.AreEqual(document.StartAt.ToString(), dbCaseTemplateVersions[0].StartAt.ToString());
            Assert.AreEqual(document.FolderId, dbCaseTemplateVersions[0].FolderId);
            Assert.AreEqual(document.RetractIfApproved, dbCaseTemplateVersions[0].RetractIfApproved);
        }

        [Test]
        public async Task CaseTemplates_Update_DoesUpdate()
        {
            //Arrange

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            Document document = new Document
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                FolderId = rnd.Next(1, 200),
                RetractIfApproved = randomBool
            };
            await document.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = document.UpdatedAt;
            bool oldApprovable = document.Approvable;
            // string oldBody = caseTemplate.Body;
            // string oldTitle = caseTemplate.Title;
            bool oldAlwaysShow = document.AlwaysShow;
            DateTime oldEndAt = document.EndAt;
            // string oldPdfTitle = caseTemplate.PdfTitle;
            DateTime oldStartAt = document.StartAt;
            int oldFolderId = document.FolderId;
            bool oldRetractIfApproved = document.RetractIfApproved;

            document.Approvable = randomBool;
            // caseTemplate.Body = Guid.NewGuid().ToString();
            // caseTemplate.Title = Guid.NewGuid().ToString();
            document.AlwaysShow = randomBool;
            document.EndAt = DateTime.Now;
            // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
            document.StartAt = DateTime.Now;
            document.FolderId = rnd.Next(1, 200);
            document.RetractIfApproved = randomBool;

            await document.Update(DbContext);

            List<Document> dbCaseTemplates = DbContext.Documents.AsNoTracking().ToList();
            List<DocumentVersion> dbCaseTemplateVersions = DbContext.DocumentVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplates);
            Assert.NotNull(dbCaseTemplateVersions);

            Assert.AreEqual(1, dbCaseTemplates.Count);
            Assert.AreEqual(2, dbCaseTemplateVersions.Count);


            Assert.AreEqual(document.Id, dbCaseTemplates[0].Id);
            Assert.AreEqual(document.Version, dbCaseTemplates[0].Version);
            Assert.AreEqual(document.CreatedAt.ToString(), dbCaseTemplates[0].CreatedAt.ToString());
            Assert.AreEqual(document.UpdatedAt.ToString(), dbCaseTemplates[0].UpdatedAt.ToString());
            Assert.AreEqual(document.CreatedByUserId, dbCaseTemplates[0].CreatedByUserId);
            Assert.AreEqual(document.UpdatedByUserId, dbCaseTemplates[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplates[0].WorkflowState);
            Assert.AreEqual(document.Approvable, dbCaseTemplates[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplates[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplates[0].Title);
            Assert.AreEqual(document.AlwaysShow, dbCaseTemplates[0].AlwaysShow);
            Assert.AreEqual(document.EndAt.ToString(), dbCaseTemplates[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplates[0].PdfTitle);
            Assert.AreEqual(document.StartAt.ToString(), dbCaseTemplates[0].StartAt.ToString());
            Assert.AreEqual(document.FolderId, dbCaseTemplates[0].FolderId);
            Assert.AreEqual(document.RetractIfApproved, dbCaseTemplates[0].RetractIfApproved);

            //Old Version
            Assert.AreEqual(document.Id, dbCaseTemplateVersions[0].DocumentId);
            Assert.AreEqual(1, dbCaseTemplateVersions[0].Version);
            Assert.AreEqual(document.CreatedAt.ToString(), dbCaseTemplateVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(document.CreatedByUserId, dbCaseTemplateVersions[0].CreatedByUserId);
            Assert.AreEqual(document.UpdatedByUserId, dbCaseTemplateVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateVersions[0].WorkflowState);
            Assert.AreEqual(oldApprovable, dbCaseTemplateVersions[0].Approvable);
            // Assert.AreEqual(oldBody, dbCaseTemplateVersions[0].Body);
            // Assert.AreEqual(oldTitle, dbCaseTemplateVersions[0].Title);
            Assert.AreEqual(oldAlwaysShow, dbCaseTemplateVersions[0].AlwaysShow);
            Assert.AreEqual(oldEndAt.ToString(), dbCaseTemplateVersions[0].EndAt.ToString());
            // Assert.AreEqual(oldPdfTitle, dbCaseTemplateVersions[0].PdfTitle);
            Assert.AreEqual(oldStartAt.ToString(), dbCaseTemplateVersions[0].StartAt.ToString());
            Assert.AreEqual(oldFolderId, dbCaseTemplateVersions[0].FolderId);
            Assert.AreEqual(oldRetractIfApproved, dbCaseTemplateVersions[0].RetractIfApproved);

            //New Version
            Assert.AreEqual(document.Id, dbCaseTemplateVersions[1].DocumentId);
            Assert.AreEqual(2, dbCaseTemplateVersions[1].Version);
            Assert.AreEqual(document.CreatedAt.ToString(), dbCaseTemplateVersions[1].CreatedAt.ToString());
            Assert.AreEqual(document.UpdatedAt.ToString(), dbCaseTemplateVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(document.CreatedByUserId, dbCaseTemplateVersions[1].CreatedByUserId);
            Assert.AreEqual(document.UpdatedByUserId, dbCaseTemplateVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateVersions[1].WorkflowState);
            Assert.AreEqual(document.Approvable, dbCaseTemplateVersions[1].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplateVersions[1].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplateVersions[1].Title);
            Assert.AreEqual(document.AlwaysShow, dbCaseTemplateVersions[1].AlwaysShow);
            Assert.AreEqual(document.EndAt.ToString(), dbCaseTemplateVersions[1].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplateVersions[1].PdfTitle);
            Assert.AreEqual(document.StartAt.ToString(), dbCaseTemplateVersions[1].StartAt.ToString());
            Assert.AreEqual(document.FolderId, dbCaseTemplateVersions[1].FolderId);
            Assert.AreEqual(document.RetractIfApproved, dbCaseTemplateVersions[1].RetractIfApproved);
        }

        [Test]
        public async Task CaseTemplates_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            Document document = new Document
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                FolderId = rnd.Next(1, 200),
                RetractIfApproved = randomBool
            };
            await document.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = document.UpdatedAt;

            await document.Delete(DbContext);

            List<Document> dbCaseTemplates = DbContext.Documents.AsNoTracking().ToList();
            List<DocumentVersion> dbCaseTemplateVersions = DbContext.DocumentVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplates);
            Assert.NotNull(dbCaseTemplateVersions);

            Assert.AreEqual(1, dbCaseTemplates.Count);
            Assert.AreEqual(2, dbCaseTemplateVersions.Count);


            Assert.AreEqual(document.Id, dbCaseTemplates[0].Id);
            Assert.AreEqual(document.Version, dbCaseTemplates[0].Version);
            Assert.AreEqual(document.CreatedAt.ToString(), dbCaseTemplates[0].CreatedAt.ToString());
            Assert.AreEqual(document.UpdatedAt.ToString(), dbCaseTemplates[0].UpdatedAt.ToString());
            Assert.AreEqual(document.CreatedByUserId, dbCaseTemplates[0].CreatedByUserId);
            Assert.AreEqual(document.UpdatedByUserId, dbCaseTemplates[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplates[0].WorkflowState);
            Assert.AreEqual(document.Approvable, dbCaseTemplates[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplates[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplates[0].Title);
            Assert.AreEqual(document.AlwaysShow, dbCaseTemplates[0].AlwaysShow);
            Assert.AreEqual(document.EndAt.ToString(), dbCaseTemplates[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplates[0].PdfTitle);
            Assert.AreEqual(document.StartAt.ToString(), dbCaseTemplates[0].StartAt.ToString());
            Assert.AreEqual(document.FolderId, dbCaseTemplates[0].FolderId);
            Assert.AreEqual(document.RetractIfApproved, dbCaseTemplates[0].RetractIfApproved);

            //Old Version
            Assert.AreEqual(document.Id, dbCaseTemplateVersions[0].DocumentId);
            Assert.AreEqual(1, dbCaseTemplateVersions[0].Version);
            Assert.AreEqual(document.CreatedAt.ToString(), dbCaseTemplateVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(document.CreatedByUserId, dbCaseTemplateVersions[0].CreatedByUserId);
            Assert.AreEqual(document.UpdatedByUserId, dbCaseTemplateVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateVersions[0].WorkflowState);
            Assert.AreEqual(document.Approvable, dbCaseTemplateVersions[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplateVersions[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplateVersions[0].Title);
            Assert.AreEqual(document.AlwaysShow, dbCaseTemplateVersions[0].AlwaysShow);
            Assert.AreEqual(document.EndAt.ToString(), dbCaseTemplateVersions[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplateVersions[0].PdfTitle);
            Assert.AreEqual(document.StartAt.ToString(), dbCaseTemplateVersions[0].StartAt.ToString());
            Assert.AreEqual(document.FolderId, dbCaseTemplateVersions[0].FolderId);
            Assert.AreEqual(document.RetractIfApproved, dbCaseTemplateVersions[0].RetractIfApproved);

            //New Version
            Assert.AreEqual(document.Id, dbCaseTemplateVersions[1].DocumentId);
            Assert.AreEqual(2, dbCaseTemplateVersions[1].Version);
            Assert.AreEqual(document.CreatedAt.ToString(), dbCaseTemplateVersions[1].CreatedAt.ToString());
            Assert.AreEqual(document.UpdatedAt.ToString(), dbCaseTemplateVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(document.CreatedByUserId, dbCaseTemplateVersions[1].CreatedByUserId);
            Assert.AreEqual(document.UpdatedByUserId, dbCaseTemplateVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateVersions[1].WorkflowState);
            Assert.AreEqual(document.Approvable, dbCaseTemplateVersions[1].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplateVersions[1].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplateVersions[1].Title);
            Assert.AreEqual(document.AlwaysShow, dbCaseTemplateVersions[1].AlwaysShow);
            Assert.AreEqual(document.EndAt.ToString(), dbCaseTemplateVersions[1].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplateVersions[1].PdfTitle);
            Assert.AreEqual(document.StartAt.ToString(), dbCaseTemplateVersions[1].StartAt.ToString());
            Assert.AreEqual(document.FolderId, dbCaseTemplateVersions[1].FolderId);
            Assert.AreEqual(document.RetractIfApproved, dbCaseTemplateVersions[1].RetractIfApproved);
        }
    }
}