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
            DocumentSite documentSite = new DocumentSite
            {
                DocumentId = rnd.Next(1, 255),
                SdkSiteId = rnd.Next(1, 255),
                SdkCaseId = rnd.Next(1, 255)
            };

            //Act

            await documentSite.Create(DbContext);

            List<DocumentSite> dbCaseTemplatesSite = DbContext.DocumentSites.AsNoTracking().ToList();
            List<DocumentSiteVersion> dbCaseTemplatesSiteVersions= DbContext.DocumentSiteVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplatesSite);
            Assert.NotNull(dbCaseTemplatesSiteVersions);

            Assert.AreEqual(1, dbCaseTemplatesSite.Count);
            Assert.AreEqual(1, dbCaseTemplatesSiteVersions.Count);

            Assert.AreEqual(documentSite.Id, dbCaseTemplatesSite[0].Id);
            Assert.AreEqual(documentSite.Version, dbCaseTemplatesSite[0].Version);
            Assert.AreEqual(documentSite.CreatedAt.ToString(), dbCaseTemplatesSite[0].CreatedAt.ToString());
            Assert.AreEqual(documentSite.UpdatedAt.ToString(), dbCaseTemplatesSite[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSite.CreatedByUserId, dbCaseTemplatesSite[0].CreatedByUserId);
            Assert.AreEqual(documentSite.UpdatedByUserId, dbCaseTemplatesSite[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSite[0].WorkflowState);
            Assert.AreEqual(documentSite.DocumentId, dbCaseTemplatesSite[0].DocumentId);
            Assert.AreEqual(documentSite.SdkSiteId, dbCaseTemplatesSite[0].SdkSiteId);
            Assert.AreEqual(documentSite.SdkCaseId, dbCaseTemplatesSite[0].SdkCaseId);

            //Versions
            Assert.AreEqual(documentSite.Id, dbCaseTemplatesSiteVersions[0].DocumentSiteId);
            Assert.AreEqual(documentSite.Version, dbCaseTemplatesSiteVersions[0].Version);
            Assert.AreEqual(documentSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[0].CreatedAt.ToString());
            Assert.AreEqual(documentSite.UpdatedAt.ToString(), dbCaseTemplatesSiteVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSite.CreatedByUserId, dbCaseTemplatesSiteVersions[0].CreatedByUserId);
            Assert.AreEqual(documentSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSiteVersions[0].WorkflowState);
            Assert.AreEqual(documentSite.DocumentId, dbCaseTemplatesSiteVersions[0].DocumentId);
            Assert.AreEqual(documentSite.SdkSiteId, dbCaseTemplatesSiteVersions[0].SdkSiteId);
            Assert.AreEqual(documentSite.SdkCaseId, dbCaseTemplatesSiteVersions[0].SdkCaseId);
        }

        [Test]
        public async Task CaseTemplateSitesUTest_Update_DoesUpdate()
        {
             //Arrange

            Random rnd = new Random();
            DocumentSite documentSite = new DocumentSite
            {
                DocumentId = rnd.Next(1, 255),
                SdkSiteId = rnd.Next(1, 255),
                SdkCaseId = rnd.Next(1, 255)
            };
            await documentSite.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = documentSite.UpdatedAt;
            int oldCaseTemplateId = documentSite.DocumentId;
            int oldSdkSiteId = documentSite.SdkSiteId;
            int oldSdkCaseId = documentSite.SdkCaseId;

            documentSite.DocumentId = rnd.Next(1, 255);
            documentSite.SdkSiteId = rnd.Next(1, 255);
            documentSite.SdkCaseId = rnd.Next(1, 255);

            await documentSite.Update(DbContext);

            List<DocumentSite> dbCaseTemplatesSite = DbContext.DocumentSites.AsNoTracking().ToList();
            List<DocumentSiteVersion> dbCaseTemplatesSiteVersions= DbContext.DocumentSiteVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplatesSite);
            Assert.NotNull(dbCaseTemplatesSiteVersions);

            Assert.AreEqual(1, dbCaseTemplatesSite.Count);
            Assert.AreEqual(2, dbCaseTemplatesSiteVersions.Count);

            Assert.AreEqual(documentSite.Id, dbCaseTemplatesSite[0].Id);
            Assert.AreEqual(documentSite.Version, dbCaseTemplatesSite[0].Version);
            Assert.AreEqual(documentSite.CreatedAt.ToString(), dbCaseTemplatesSite[0].CreatedAt.ToString());
            Assert.AreEqual(documentSite.UpdatedAt.ToString(), dbCaseTemplatesSite[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSite.CreatedByUserId, dbCaseTemplatesSite[0].CreatedByUserId);
            Assert.AreEqual(documentSite.UpdatedByUserId, dbCaseTemplatesSite[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSite[0].WorkflowState);
            Assert.AreEqual(documentSite.DocumentId, dbCaseTemplatesSite[0].DocumentId);
            Assert.AreEqual(documentSite.SdkSiteId, dbCaseTemplatesSite[0].SdkSiteId);
            Assert.AreEqual(documentSite.SdkCaseId, dbCaseTemplatesSite[0].SdkCaseId);

            //Old Version
            Assert.AreEqual(documentSite.Id, dbCaseTemplatesSiteVersions[0].DocumentSiteId);
            Assert.AreEqual(1, dbCaseTemplatesSiteVersions[0].Version);
            Assert.AreEqual(documentSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplatesSiteVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSite.CreatedByUserId, dbCaseTemplatesSiteVersions[0].CreatedByUserId);
            Assert.AreEqual(documentSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSiteVersions[0].WorkflowState);
            Assert.AreEqual(oldCaseTemplateId, dbCaseTemplatesSiteVersions[0].DocumentId);
            Assert.AreEqual(oldSdkSiteId, dbCaseTemplatesSiteVersions[0].SdkSiteId);
            Assert.AreEqual(oldSdkCaseId, dbCaseTemplatesSiteVersions[0].SdkCaseId);

            //New Version
            Assert.AreEqual(documentSite.Id, dbCaseTemplatesSiteVersions[1].DocumentSiteId);
            Assert.AreEqual(2, dbCaseTemplatesSiteVersions[1].Version);
            Assert.AreEqual(documentSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[1].CreatedAt.ToString());
            Assert.AreEqual(documentSite.UpdatedAt.ToString(), dbCaseTemplatesSiteVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(documentSite.CreatedByUserId, dbCaseTemplatesSiteVersions[1].CreatedByUserId);
            Assert.AreEqual(documentSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSiteVersions[1].WorkflowState);
            Assert.AreEqual(documentSite.DocumentId, dbCaseTemplatesSiteVersions[1].DocumentId);
            Assert.AreEqual(documentSite.SdkSiteId, dbCaseTemplatesSiteVersions[1].SdkSiteId);
            Assert.AreEqual(documentSite.SdkCaseId, dbCaseTemplatesSiteVersions[1].SdkCaseId);


        }

        [Test]
        public async Task CaseTemplateSites_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

            Random rnd = new Random();
            DocumentSite documentSite = new DocumentSite
            {
                DocumentId = rnd.Next(1, 255),
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
            Assert.NotNull(dbCaseTemplatesSite);
            Assert.NotNull(dbCaseTemplatesSiteVersions);

            Assert.AreEqual(1, dbCaseTemplatesSite.Count);
            Assert.AreEqual(2, dbCaseTemplatesSiteVersions.Count);

            Assert.AreEqual(documentSite.Id, dbCaseTemplatesSite[0].Id);
            Assert.AreEqual(documentSite.Version, dbCaseTemplatesSite[0].Version);
            Assert.AreEqual(documentSite.CreatedAt.ToString(), dbCaseTemplatesSite[0].CreatedAt.ToString());
            Assert.AreEqual(documentSite.UpdatedAt.ToString(), dbCaseTemplatesSite[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSite.CreatedByUserId, dbCaseTemplatesSite[0].CreatedByUserId);
            Assert.AreEqual(documentSite.UpdatedByUserId, dbCaseTemplatesSite[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplatesSite[0].WorkflowState);
            Assert.AreEqual(documentSite.DocumentId, dbCaseTemplatesSite[0].DocumentId);
            Assert.AreEqual(documentSite.SdkSiteId, dbCaseTemplatesSite[0].SdkSiteId);
            Assert.AreEqual(documentSite.SdkCaseId, dbCaseTemplatesSite[0].SdkCaseId);

            //Old Version
            Assert.AreEqual(documentSite.Id, dbCaseTemplatesSiteVersions[0].DocumentSiteId);
            Assert.AreEqual(1, dbCaseTemplatesSiteVersions[0].Version);
            Assert.AreEqual(documentSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplatesSiteVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSite.CreatedByUserId, dbCaseTemplatesSiteVersions[0].CreatedByUserId);
            Assert.AreEqual(documentSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSiteVersions[0].WorkflowState);
            Assert.AreEqual(documentSite.DocumentId, dbCaseTemplatesSiteVersions[0].DocumentId);
            Assert.AreEqual(documentSite.SdkSiteId, dbCaseTemplatesSiteVersions[0].SdkSiteId);
            Assert.AreEqual(documentSite.SdkCaseId, dbCaseTemplatesSiteVersions[0].SdkCaseId);

            //New Version
            Assert.AreEqual(documentSite.Id, dbCaseTemplatesSiteVersions[1].DocumentSiteId);
            Assert.AreEqual(2, dbCaseTemplatesSiteVersions[1].Version);
            Assert.AreEqual(documentSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[1].CreatedAt.ToString());
            Assert.AreEqual(documentSite.UpdatedAt.ToString(), dbCaseTemplatesSiteVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(documentSite.CreatedByUserId, dbCaseTemplatesSiteVersions[1].CreatedByUserId);
            Assert.AreEqual(documentSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplatesSiteVersions[1].WorkflowState);
            Assert.AreEqual(documentSite.DocumentId, dbCaseTemplatesSiteVersions[1].DocumentId);
            Assert.AreEqual(documentSite.SdkSiteId, dbCaseTemplatesSiteVersions[1].SdkSiteId);
        }
    }
}