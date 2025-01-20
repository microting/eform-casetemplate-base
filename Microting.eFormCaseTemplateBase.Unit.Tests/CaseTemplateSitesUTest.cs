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
    public class CaseTemplateSitesUTest : DbTestFixture
    {
        [Test]
        public async Task CaseTemplatesSites_Create_DoesCreate()
        {
            //Arrange

            Random rnd = new Random();

            Document document = new Document()
            {

            };

            await document.Create(DbContext);
            DocumentSite documentSite = new DocumentSite
            {
                DocumentId = document.Id,
                SdkSiteId = rnd.Next(1, 255),
                SdkCaseId = rnd.Next(1, 255)
            };

            //Act

            await documentSite.Create(DbContext);

            List<DocumentSite> dbCaseTemplatesSite = DbContext.DocumentSites.AsNoTracking().ToList();
            List<DocumentSiteVersion> dbCaseTemplatesSiteVersions= DbContext.DocumentSiteVersions.AsNoTracking().ToList();

            //Assert
            Assert.That(dbCaseTemplatesSite, Is.Not.Null);
            Assert.That(dbCaseTemplatesSiteVersions, Is.Not.Null);

            Assert.That(dbCaseTemplatesSite.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplatesSiteVersions.Count, Is.EqualTo(1));

            Assert.That(dbCaseTemplatesSite[0].Id, Is.EqualTo(documentSite.Id));
            Assert.That(dbCaseTemplatesSite[0].Version, Is.EqualTo(documentSite.Version));
            Assert.That(dbCaseTemplatesSite[0].CreatedAt.ToString(), Is.EqualTo(documentSite.CreatedAt.ToString()));
            Assert.That(dbCaseTemplatesSite[0].UpdatedAt.ToString(), Is.EqualTo(documentSite.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplatesSite[0].CreatedByUserId, Is.EqualTo(documentSite.CreatedByUserId));
            Assert.That(dbCaseTemplatesSite[0].UpdatedByUserId, Is.EqualTo(documentSite.UpdatedByUserId));
            Assert.That(dbCaseTemplatesSite[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplatesSite[0].DocumentId, Is.EqualTo(documentSite.DocumentId));
            Assert.That(dbCaseTemplatesSite[0].SdkSiteId, Is.EqualTo(documentSite.SdkSiteId));
            Assert.That(dbCaseTemplatesSite[0].SdkCaseId, Is.EqualTo(documentSite.SdkCaseId));

            //Versions
            Assert.That(dbCaseTemplatesSiteVersions[0].DocumentSiteId, Is.EqualTo(documentSite.Id));
            Assert.That(dbCaseTemplatesSiteVersions[0].Version, Is.EqualTo(documentSite.Version));
            Assert.That(dbCaseTemplatesSiteVersions[0].CreatedAt.ToString(), Is.EqualTo(documentSite.CreatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[0].UpdatedAt.ToString(), Is.EqualTo(documentSite.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[0].CreatedByUserId, Is.EqualTo(documentSite.CreatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[0].UpdatedByUserId, Is.EqualTo(documentSite.UpdatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplatesSiteVersions[0].DocumentId, Is.EqualTo(documentSite.DocumentId));
            Assert.That(dbCaseTemplatesSiteVersions[0].SdkSiteId, Is.EqualTo(documentSite.SdkSiteId));
            Assert.That(dbCaseTemplatesSiteVersions[0].SdkCaseId, Is.EqualTo(documentSite.SdkCaseId));
        }

        [Test]
        public async Task CaseTemplateSitesUTest_Update_DoesUpdate()
        {
             //Arrange

            Random rnd = new Random();

            Document document = new Document()
            {

            };

            await document.Create(DbContext);
            DocumentSite documentSite = new DocumentSite
            {
                DocumentId = document.Id,
                SdkSiteId = rnd.Next(1, 255),
                SdkCaseId = rnd.Next(1, 255)
            };
            await documentSite.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = documentSite.UpdatedAt;
            int oldCaseTemplateId = documentSite.DocumentId;
            int oldSdkSiteId = documentSite.SdkSiteId;
            int oldSdkCaseId = documentSite.SdkCaseId;


            Document NewDocument = new Document()
            {

            };

            await NewDocument.Create(DbContext);
            documentSite.DocumentId = NewDocument.Id;
            documentSite.SdkSiteId = rnd.Next(1, 255);
            documentSite.SdkCaseId = rnd.Next(1, 255);

            await documentSite.Update(DbContext);

            List<DocumentSite> dbCaseTemplatesSite = DbContext.DocumentSites.AsNoTracking().ToList();
            List<DocumentSiteVersion> dbCaseTemplatesSiteVersions= DbContext.DocumentSiteVersions.AsNoTracking().ToList();

            //Assert
            Assert.That(dbCaseTemplatesSite, Is.Not.Null);
            Assert.That(dbCaseTemplatesSiteVersions, Is.Not.Null);

            Assert.That(dbCaseTemplatesSite.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplatesSiteVersions.Count, Is.EqualTo(2));

            Assert.That(dbCaseTemplatesSite[0].Id, Is.EqualTo(documentSite.Id));
            Assert.That(dbCaseTemplatesSite[0].Version, Is.EqualTo(documentSite.Version));
            Assert.That(dbCaseTemplatesSite[0].CreatedAt.ToString(), Is.EqualTo(documentSite.CreatedAt.ToString()));
            Assert.That(dbCaseTemplatesSite[0].UpdatedAt.ToString(), Is.EqualTo(documentSite.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplatesSite[0].CreatedByUserId, Is.EqualTo(documentSite.CreatedByUserId));
            Assert.That(dbCaseTemplatesSite[0].UpdatedByUserId, Is.EqualTo(documentSite.UpdatedByUserId));
            Assert.That(dbCaseTemplatesSite[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplatesSite[0].DocumentId, Is.EqualTo(documentSite.DocumentId));
            Assert.That(dbCaseTemplatesSite[0].SdkSiteId, Is.EqualTo(documentSite.SdkSiteId));
            Assert.That(dbCaseTemplatesSite[0].SdkCaseId, Is.EqualTo(documentSite.SdkCaseId));

            //Old Version
            Assert.That(dbCaseTemplatesSiteVersions[0].DocumentSiteId, Is.EqualTo(documentSite.Id));
            Assert.That(dbCaseTemplatesSiteVersions[0].Version, Is.EqualTo(1));
            Assert.That(dbCaseTemplatesSiteVersions[0].CreatedAt.ToString(), Is.EqualTo(documentSite.CreatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[0].CreatedByUserId, Is.EqualTo(documentSite.CreatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[0].UpdatedByUserId, Is.EqualTo(documentSite.UpdatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplatesSiteVersions[0].DocumentId, Is.EqualTo(oldCaseTemplateId));
            Assert.That(dbCaseTemplatesSiteVersions[0].SdkSiteId, Is.EqualTo(oldSdkSiteId));
            Assert.That(dbCaseTemplatesSiteVersions[0].SdkCaseId, Is.EqualTo(oldSdkCaseId));

            //New Version
            Assert.That(dbCaseTemplatesSiteVersions[1].DocumentSiteId, Is.EqualTo(documentSite.Id));
            Assert.That(dbCaseTemplatesSiteVersions[1].Version, Is.EqualTo(2));
            Assert.That(dbCaseTemplatesSiteVersions[1].CreatedAt.ToString(), Is.EqualTo(documentSite.CreatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[1].UpdatedAt.ToString(), Is.EqualTo(documentSite.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[1].CreatedByUserId, Is.EqualTo(documentSite.CreatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[1].UpdatedByUserId, Is.EqualTo(documentSite.UpdatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplatesSiteVersions[1].DocumentId, Is.EqualTo(documentSite.DocumentId));
            Assert.That(dbCaseTemplatesSiteVersions[1].SdkSiteId, Is.EqualTo(documentSite.SdkSiteId));
            Assert.That(dbCaseTemplatesSiteVersions[1].SdkCaseId, Is.EqualTo(documentSite.SdkCaseId));


        }

        [Test]
        public async Task CaseTemplateSites_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

            Random rnd = new Random();

            Document document = new Document()
            {

            };

            await document.Create(DbContext);

            DocumentSite documentSite = new DocumentSite
            {
                DocumentId = document.Id,
                SdkSiteId = rnd.Next(1, 255),
                SdkCaseId = rnd.Next(1, 255)
            };
            await documentSite.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = documentSite.UpdatedAt;

            await documentSite.Delete(DbContext);

            List<DocumentSite> dbCaseTemplatesSite = DbContext.DocumentSites.AsNoTracking().ToList();
            List<DocumentSiteVersion> dbCaseTemplatesSiteVersions= DbContext.DocumentSiteVersions.AsNoTracking().ToList();

            //Assert
            Assert.That(dbCaseTemplatesSite, Is.Not.Null);
            Assert.That(dbCaseTemplatesSiteVersions, Is.Not.Null);

            Assert.That(dbCaseTemplatesSite.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplatesSiteVersions.Count, Is.EqualTo(2));

            Assert.That(dbCaseTemplatesSite[0].Id, Is.EqualTo(documentSite.Id));
            Assert.That(dbCaseTemplatesSite[0].Version, Is.EqualTo(documentSite.Version));
            Assert.That(dbCaseTemplatesSite[0].CreatedAt.ToString(), Is.EqualTo(documentSite.CreatedAt.ToString()));
            Assert.That(dbCaseTemplatesSite[0].UpdatedAt.ToString(), Is.EqualTo(documentSite.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplatesSite[0].CreatedByUserId, Is.EqualTo(documentSite.CreatedByUserId));
            Assert.That(dbCaseTemplatesSite[0].UpdatedByUserId, Is.EqualTo(documentSite.UpdatedByUserId));
            Assert.That(dbCaseTemplatesSite[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbCaseTemplatesSite[0].DocumentId, Is.EqualTo(documentSite.DocumentId));
            Assert.That(dbCaseTemplatesSite[0].SdkSiteId, Is.EqualTo(documentSite.SdkSiteId));
            Assert.That(dbCaseTemplatesSite[0].SdkCaseId, Is.EqualTo(documentSite.SdkCaseId));

            //Old Version
            Assert.That(dbCaseTemplatesSiteVersions[0].DocumentSiteId, Is.EqualTo(documentSite.Id));
            Assert.That(dbCaseTemplatesSiteVersions[0].Version, Is.EqualTo(1));
            Assert.That(dbCaseTemplatesSiteVersions[0].CreatedAt.ToString(), Is.EqualTo(documentSite.CreatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[0].CreatedByUserId, Is.EqualTo(documentSite.CreatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[0].UpdatedByUserId, Is.EqualTo(documentSite.UpdatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplatesSiteVersions[0].DocumentId, Is.EqualTo(documentSite.DocumentId));
            Assert.That(dbCaseTemplatesSiteVersions[0].SdkSiteId, Is.EqualTo(documentSite.SdkSiteId));
            Assert.That(dbCaseTemplatesSiteVersions[0].SdkCaseId, Is.EqualTo(documentSite.SdkCaseId));

            //New Version
            Assert.That(dbCaseTemplatesSiteVersions[1].DocumentSiteId, Is.EqualTo(documentSite.Id));
            Assert.That(dbCaseTemplatesSiteVersions[1].Version, Is.EqualTo(2));
            Assert.That(dbCaseTemplatesSiteVersions[1].CreatedAt.ToString(), Is.EqualTo(documentSite.CreatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[1].UpdatedAt.ToString(), Is.EqualTo(documentSite.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplatesSiteVersions[1].CreatedByUserId, Is.EqualTo(documentSite.CreatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[1].UpdatedByUserId, Is.EqualTo(documentSite.UpdatedByUserId));
            Assert.That(dbCaseTemplatesSiteVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbCaseTemplatesSiteVersions[1].DocumentId, Is.EqualTo(documentSite.DocumentId));
            Assert.That(dbCaseTemplatesSiteVersions[1].SdkSiteId, Is.EqualTo(documentSite.SdkSiteId));
        }
    }
}