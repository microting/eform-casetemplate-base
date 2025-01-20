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
            Assert.That(dbCaseTemplates, Is.Not.Null);
            Assert.That(dbCaseTemplateVersions, Is.Not.Null);

            Assert.That(dbCaseTemplates.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplateVersions.Count, Is.EqualTo(1));


            Assert.That(dbCaseTemplates[0].Id, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplates[0].Version, Is.EqualTo(document.Version));
            Assert.That(dbCaseTemplates[0].CreatedAt.ToString(), Is.EqualTo(document.CreatedAt.ToString()));
            Assert.That(dbCaseTemplates[0].UpdatedAt.ToString(), Is.EqualTo(document.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplates[0].CreatedByUserId, Is.EqualTo(document.CreatedByUserId));
            Assert.That(dbCaseTemplates[0].UpdatedByUserId, Is.EqualTo(document.UpdatedByUserId));
            Assert.That(dbCaseTemplates[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplates[0].Approvable, Is.EqualTo(document.Approvable));
            // Assert.That(dbCaseTemplates[0].Body, Is.EqualTo(caseTemplate.Body));
            // Assert.That(dbCaseTemplates[0].Title, Is.EqualTo(caseTemplate.Title));
            Assert.That(dbCaseTemplates[0].AlwaysShow, Is.EqualTo(document.AlwaysShow));
            Assert.That(dbCaseTemplates[0].EndAt.ToString(), Is.EqualTo(document.EndAt.ToString()));
            // Assert.That(dbCaseTemplates[0].PdfTitle, Is.EqualTo(caseTemplate.PdfTitle));
            Assert.That(dbCaseTemplates[0].StartAt.ToString(), Is.EqualTo(document.StartAt.ToString()));
            Assert.That(dbCaseTemplates[0].FolderId, Is.EqualTo(document.FolderId));
            Assert.That(dbCaseTemplates[0].RetractIfApproved, Is.EqualTo(document.RetractIfApproved));

            //Versions
            Assert.That(dbCaseTemplateVersions[0].Id, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateVersions[0].Version, Is.EqualTo(document.Version));
            Assert.That(dbCaseTemplateVersions[0].CreatedAt.ToString(), Is.EqualTo(document.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[0].UpdatedAt.ToString(), Is.EqualTo(document.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[0].CreatedByUserId, Is.EqualTo(document.CreatedByUserId));
            Assert.That(dbCaseTemplateVersions[0].UpdatedByUserId, Is.EqualTo(document.UpdatedByUserId));
            Assert.That(dbCaseTemplateVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateVersions[0].Approvable, Is.EqualTo(document.Approvable));
            // Assert.That(dbCaseTemplateVersions[0].Body, Is.EqualTo(caseTemplate.Body));
            // Assert.That(dbCaseTemplateVersions[0].Title, Is.EqualTo(caseTemplate.Title));
            Assert.That(dbCaseTemplateVersions[0].AlwaysShow, Is.EqualTo(document.AlwaysShow));
            Assert.That(dbCaseTemplateVersions[0].EndAt.ToString(), Is.EqualTo(document.EndAt.ToString()));
            // Assert.That(dbCaseTemplateVersions[0].PdfTitle, Is.EqualTo(caseTemplate.PdfTitle));
            Assert.That(dbCaseTemplateVersions[0].StartAt.ToString(), Is.EqualTo(document.StartAt.ToString()));
            Assert.That(dbCaseTemplateVersions[0].FolderId, Is.EqualTo(document.FolderId));
            Assert.That(dbCaseTemplateVersions[0].RetractIfApproved, Is.EqualTo(document.RetractIfApproved));
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
            Assert.That(dbCaseTemplates, Is.Not.Null);
            Assert.That(dbCaseTemplateVersions, Is.Not.Null);

            Assert.That(dbCaseTemplates.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplateVersions.Count, Is.EqualTo(2));


            Assert.That(dbCaseTemplates[0].Id, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplates[0].Version, Is.EqualTo(document.Version));
            Assert.That(dbCaseTemplates[0].CreatedAt.ToString(), Is.EqualTo(document.CreatedAt.ToString()));
            Assert.That(dbCaseTemplates[0].UpdatedAt.ToString(), Is.EqualTo(document.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplates[0].CreatedByUserId, Is.EqualTo(document.CreatedByUserId));
            Assert.That(dbCaseTemplates[0].UpdatedByUserId, Is.EqualTo(document.UpdatedByUserId));
            Assert.That(dbCaseTemplates[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplates[0].Approvable, Is.EqualTo(document.Approvable));
            // Assert.That(dbCaseTemplates[0].Body, Is.EqualTo(caseTemplate.Body));
            // Assert.That(dbCaseTemplates[0].Title, Is.EqualTo(caseTemplate.Title));
            Assert.That(dbCaseTemplates[0].AlwaysShow, Is.EqualTo(document.AlwaysShow));
            Assert.That(dbCaseTemplates[0].EndAt.ToString(), Is.EqualTo(document.EndAt.ToString()));
            // Assert.That(dbCaseTemplates[0].PdfTitle, Is.EqualTo(caseTemplate.PdfTitle));
            Assert.That(dbCaseTemplates[0].StartAt.ToString(), Is.EqualTo(document.StartAt.ToString()));
            Assert.That(dbCaseTemplates[0].FolderId, Is.EqualTo(document.FolderId));
            Assert.That(dbCaseTemplates[0].RetractIfApproved, Is.EqualTo(document.RetractIfApproved));

            //Old Version
            Assert.That(dbCaseTemplateVersions[0].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateVersions[0].Version, Is.EqualTo(1));
            Assert.That(dbCaseTemplateVersions[0].CreatedAt.ToString(), Is.EqualTo(document.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[0].CreatedByUserId, Is.EqualTo(document.CreatedByUserId));
            Assert.That(dbCaseTemplateVersions[0].UpdatedByUserId, Is.EqualTo(document.UpdatedByUserId));
            Assert.That(dbCaseTemplateVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateVersions[0].Approvable, Is.EqualTo(oldApprovable));
            // Assert.That(dbCaseTemplateVersions[0].Body, Is.EqualTo(oldBody));
            // Assert.That(dbCaseTemplateVersions[0].Title, Is.EqualTo(oldTitle));
            Assert.That(dbCaseTemplateVersions[0].AlwaysShow, Is.EqualTo(oldAlwaysShow));
            Assert.That(dbCaseTemplateVersions[0].EndAt.ToString(), Is.EqualTo(oldEndAt.ToString()));
            // Assert.That(dbCaseTemplateVersions[0].PdfTitle, Is.EqualTo(oldPdfTitle));
            Assert.That(dbCaseTemplateVersions[0].StartAt.ToString(), Is.EqualTo(oldStartAt.ToString()));
            Assert.That(dbCaseTemplateVersions[0].FolderId, Is.EqualTo(oldFolderId));
            Assert.That(dbCaseTemplateVersions[0].RetractIfApproved, Is.EqualTo(oldRetractIfApproved));

            //New Version
            Assert.That(dbCaseTemplateVersions[1].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateVersions[1].Version, Is.EqualTo(2));
            Assert.That(dbCaseTemplateVersions[1].CreatedAt.ToString(), Is.EqualTo(document.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[1].UpdatedAt.ToString(), Is.EqualTo(document.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[1].CreatedByUserId, Is.EqualTo(document.CreatedByUserId));
            Assert.That(dbCaseTemplateVersions[1].UpdatedByUserId, Is.EqualTo(document.UpdatedByUserId));
            Assert.That(dbCaseTemplateVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateVersions[1].Approvable, Is.EqualTo(document.Approvable));
            // Assert.That(dbCaseTemplateVersions[1].Body, Is.EqualTo(caseTemplate.Body));
            // Assert.That(dbCaseTemplateVersions[1].Title, Is.EqualTo(caseTemplate.Title));
            Assert.That(dbCaseTemplateVersions[1].AlwaysShow, Is.EqualTo(document.AlwaysShow));
            Assert.That(dbCaseTemplateVersions[1].EndAt.ToString(), Is.EqualTo(document.EndAt.ToString()));
            // Assert.That(dbCaseTemplateVersions[1].PdfTitle, Is.EqualTo(caseTemplate.PdfTitle));
            Assert.That(dbCaseTemplateVersions[1].StartAt.ToString(), Is.EqualTo(document.StartAt.ToString()));
            Assert.That(dbCaseTemplateVersions[1].FolderId, Is.EqualTo(document.FolderId));
            Assert.That(dbCaseTemplateVersions[1].RetractIfApproved, Is.EqualTo(document.RetractIfApproved));
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
            Assert.That(dbCaseTemplates, Is.Not.Null);
            Assert.That(dbCaseTemplateVersions, Is.Not.Null);

            Assert.That(dbCaseTemplates.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplateVersions.Count, Is.EqualTo(2));


            Assert.That(dbCaseTemplates[0].Id, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplates[0].Version, Is.EqualTo(document.Version));
            Assert.That(dbCaseTemplates[0].CreatedAt.ToString(), Is.EqualTo(document.CreatedAt.ToString()));
            Assert.That(dbCaseTemplates[0].UpdatedAt.ToString(), Is.EqualTo(document.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplates[0].CreatedByUserId, Is.EqualTo(document.CreatedByUserId));
            Assert.That(dbCaseTemplates[0].UpdatedByUserId, Is.EqualTo(document.UpdatedByUserId));
            Assert.That(dbCaseTemplates[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbCaseTemplates[0].Approvable, Is.EqualTo(document.Approvable));
            // Assert.That(dbCaseTemplates[0].Body, Is.EqualTo(caseTemplate.Body));
            // Assert.That(dbCaseTemplates[0].Title, Is.EqualTo(caseTemplate.Title));
            Assert.That(dbCaseTemplates[0].AlwaysShow, Is.EqualTo(document.AlwaysShow));
            Assert.That(dbCaseTemplates[0].EndAt.ToString(), Is.EqualTo(document.EndAt.ToString()));
            // Assert.That(dbCaseTemplates[0].PdfTitle, Is.EqualTo(caseTemplate.PdfTitle));
            Assert.That(dbCaseTemplates[0].StartAt.ToString(), Is.EqualTo(document.StartAt.ToString()));
            Assert.That(dbCaseTemplates[0].FolderId, Is.EqualTo(document.FolderId));
            Assert.That(dbCaseTemplates[0].RetractIfApproved, Is.EqualTo(document.RetractIfApproved));

            //Old Version
            Assert.That(dbCaseTemplateVersions[0].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateVersions[0].Version, Is.EqualTo(1));
            Assert.That(dbCaseTemplateVersions[0].CreatedAt.ToString(), Is.EqualTo(document.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[0].CreatedByUserId, Is.EqualTo(document.CreatedByUserId));
            Assert.That(dbCaseTemplateVersions[0].UpdatedByUserId, Is.EqualTo(document.UpdatedByUserId));
            Assert.That(dbCaseTemplateVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateVersions[0].Approvable, Is.EqualTo(document.Approvable));
            // Assert.That(dbCaseTemplateVersions[0].Body, Is.EqualTo(caseTemplate.Body));
            // Assert.That(dbCaseTemplateVersions[0].Title, Is.EqualTo(caseTemplate.Title));
            Assert.That(dbCaseTemplateVersions[0].AlwaysShow, Is.EqualTo(document.AlwaysShow));
            Assert.That(dbCaseTemplateVersions[0].EndAt.ToString(), Is.EqualTo(document.EndAt.ToString()));
            // Assert.That(dbCaseTemplateVersions[0].PdfTitle, Is.EqualTo(caseTemplate.PdfTitle));
            Assert.That(dbCaseTemplateVersions[0].StartAt.ToString(), Is.EqualTo(document.StartAt.ToString()));
            Assert.That(dbCaseTemplateVersions[0].FolderId, Is.EqualTo(document.FolderId));
            Assert.That(dbCaseTemplateVersions[0].RetractIfApproved, Is.EqualTo(document.RetractIfApproved));

            //New Version
            Assert.That(dbCaseTemplateVersions[1].DocumentId, Is.EqualTo(document.Id));
            Assert.That(dbCaseTemplateVersions[1].Version, Is.EqualTo(2));
            Assert.That(dbCaseTemplateVersions[1].CreatedAt.ToString(), Is.EqualTo(document.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[1].UpdatedAt.ToString(), Is.EqualTo(document.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateVersions[1].CreatedByUserId, Is.EqualTo(document.CreatedByUserId));
            Assert.That(dbCaseTemplateVersions[1].UpdatedByUserId, Is.EqualTo(document.UpdatedByUserId));
            Assert.That(dbCaseTemplateVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbCaseTemplateVersions[1].Approvable, Is.EqualTo(document.Approvable));
            // Assert.That(dbCaseTemplateVersions[1].Body, Is.EqualTo(caseTemplate.Body));
            // Assert.That(dbCaseTemplateVersions[1].Title, Is.EqualTo(caseTemplate.Title));
            Assert.That(dbCaseTemplateVersions[1].AlwaysShow, Is.EqualTo(document.AlwaysShow));
            Assert.That(dbCaseTemplateVersions[1].EndAt.ToString(), Is.EqualTo(document.EndAt.ToString()));
            // Assert.That(dbCaseTemplateVersions[1].PdfTitle, Is.EqualTo(caseTemplate.PdfTitle));
            Assert.That(dbCaseTemplateVersions[1].StartAt.ToString(), Is.EqualTo(document.StartAt.ToString()));
            Assert.That(dbCaseTemplateVersions[1].FolderId, Is.EqualTo(document.FolderId));
            Assert.That(dbCaseTemplateVersions[1].RetractIfApproved, Is.EqualTo(document.RetractIfApproved));
        }
    }
}