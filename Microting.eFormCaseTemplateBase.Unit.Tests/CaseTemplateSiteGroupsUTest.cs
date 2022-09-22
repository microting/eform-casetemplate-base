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
    public class CaseTemplateSiteTagsUTest : DbTestFixture
    {
        [Test]
        public async Task CaseTemplatesSiteTags_Create_DoesCreate()
        {
            //Arrange

            Random rnd = new Random();
            DocumentSiteTag documentSiteTag = new DocumentSiteTag
            {
                DocumentId = rnd.Next(1, 255),
                SdkSiteTagId = rnd.Next(1, 255)
            };

            //Act

            await documentSiteTag.Create(DbContext);

            List<DocumentSiteTag> dbCaseTemplateSiteTags =
                DbContext.DocumentSiteTags.AsNoTracking().ToList();

            List<DocumentSiteTagVersion> dbCaseTemplateSiteTagVersions =
                DbContext.DocumentSiteTagVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateSiteTags);
            Assert.NotNull(dbCaseTemplateSiteTagVersions);

            Assert.AreEqual(1, dbCaseTemplateSiteTags.Count);
            Assert.AreEqual(1, dbCaseTemplateSiteTagVersions.Count);

            Assert.AreEqual(documentSiteTag.Id, dbCaseTemplateSiteTags[0].Id);
            Assert.AreEqual(documentSiteTag.Version, dbCaseTemplateSiteTags[0].Version);
            Assert.AreEqual(documentSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTags[0].CreatedAt.ToString());
            Assert.AreEqual(documentSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTags[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSiteTag.CreatedByUserId, dbCaseTemplateSiteTags[0].CreatedByUserId);
            Assert.AreEqual(documentSiteTag.UpdatedByUserId, dbCaseTemplateSiteTags[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTags[0].WorkflowState);
            Assert.AreEqual(documentSiteTag.DocumentId, dbCaseTemplateSiteTags[0].DocumentId);
            Assert.AreEqual(documentSiteTag.SdkSiteTagId, dbCaseTemplateSiteTags[0].SdkSiteTagId);

            //Versions
            Assert.AreEqual(documentSiteTag.Id, dbCaseTemplateSiteTagVersions[0].DocumentSiteTagId);
            Assert.AreEqual(documentSiteTag.Version, dbCaseTemplateSiteTagVersions[0].Version);
            Assert.AreEqual(documentSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].CreatedAt.ToString());
            Assert.AreEqual(documentSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[0].CreatedByUserId);
            Assert.AreEqual(documentSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTagVersions[0].WorkflowState);
            Assert.AreEqual(documentSiteTag.DocumentId, dbCaseTemplateSiteTagVersions[0].DocumentId);
            Assert.AreEqual(documentSiteTag.SdkSiteTagId, dbCaseTemplateSiteTagVersions[0].SdkSiteTagId);
        }

        [Test]
        public async Task CaseTemplateSiteTags_Update_DoesUpdate()
        {
             //Arrange

            Random rnd = new Random();
            DocumentSiteTag documentSiteTag = new DocumentSiteTag
            {
                DocumentId = rnd.Next(1, 255),
                SdkSiteTagId = rnd.Next(1, 255)
            };
            await documentSiteTag.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = documentSiteTag.UpdatedAt;
            int oldCaseTemplateId = documentSiteTag.DocumentId;
            int oldSdkSiteTagId = documentSiteTag.SdkSiteTagId;

            documentSiteTag.DocumentId = rnd.Next(1, 255);
            documentSiteTag.SdkSiteTagId = rnd.Next(1, 255);

            await documentSiteTag.Update(DbContext);

            List<DocumentSiteTag> dbCaseTemplateSiteTags =
                DbContext.DocumentSiteTags.AsNoTracking().ToList();

            List<DocumentSiteTagVersion> dbCaseTemplateSiteTagVersions =
                DbContext.DocumentSiteTagVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateSiteTags);
            Assert.NotNull(dbCaseTemplateSiteTagVersions);

            Assert.AreEqual(1, dbCaseTemplateSiteTags.Count);
            Assert.AreEqual(2, dbCaseTemplateSiteTagVersions.Count);

            Assert.AreEqual(documentSiteTag.Id, dbCaseTemplateSiteTags[0].Id);
            Assert.AreEqual(documentSiteTag.Version, dbCaseTemplateSiteTags[0].Version);
            Assert.AreEqual(documentSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTags[0].CreatedAt.ToString());
            Assert.AreEqual(documentSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTags[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSiteTag.CreatedByUserId, dbCaseTemplateSiteTags[0].CreatedByUserId);
            Assert.AreEqual(documentSiteTag.UpdatedByUserId, dbCaseTemplateSiteTags[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTags[0].WorkflowState);
            Assert.AreEqual(documentSiteTag.DocumentId, dbCaseTemplateSiteTags[0].DocumentId);
            Assert.AreEqual(documentSiteTag.SdkSiteTagId, dbCaseTemplateSiteTags[0].SdkSiteTagId);

            //Old Version
            Assert.AreEqual(documentSiteTag.Id, dbCaseTemplateSiteTagVersions[0].DocumentSiteTagId);
            Assert.AreEqual(1, dbCaseTemplateSiteTagVersions[0].Version);
            Assert.AreEqual(documentSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[0].CreatedByUserId);
            Assert.AreEqual(documentSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTagVersions[0].WorkflowState);
            Assert.AreEqual(oldCaseTemplateId, dbCaseTemplateSiteTagVersions[0].DocumentId);
            Assert.AreEqual(oldSdkSiteTagId, dbCaseTemplateSiteTagVersions[0].SdkSiteTagId);

            //New Version
            Assert.AreEqual(documentSiteTag.Id, dbCaseTemplateSiteTagVersions[1].DocumentSiteTagId);
            Assert.AreEqual(2, dbCaseTemplateSiteTagVersions[1].Version);
            Assert.AreEqual(documentSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[1].CreatedAt.ToString());
            Assert.AreEqual(documentSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(documentSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[1].CreatedByUserId);
            Assert.AreEqual(documentSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTagVersions[1].WorkflowState);
            Assert.AreEqual(documentSiteTag.DocumentId, dbCaseTemplateSiteTagVersions[1].DocumentId);
            Assert.AreEqual(documentSiteTag.SdkSiteTagId, dbCaseTemplateSiteTagVersions[1].SdkSiteTagId);
        }

        [Test]
        public async Task CaseTemplateSiteTags_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

             //Arrange

            Random rnd = new Random();
            DocumentSiteTag documentSiteTag = new DocumentSiteTag
            {
                // DocumentId = rnd.Next(1, 255),
                SdkSiteTagId = rnd.Next(1, 255)
            };
            await documentSiteTag.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = documentSiteTag.UpdatedAt;

            await documentSiteTag.Delete(DbContext);

            List<DocumentSiteTag> dbCaseTemplateSiteTags =
                DbContext.DocumentSiteTags.AsNoTracking().ToList();

            List<DocumentSiteTagVersion> dbCaseTemplateSiteTagVersions =
                DbContext.DocumentSiteTagVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateSiteTags);
            Assert.NotNull(dbCaseTemplateSiteTagVersions);

            Assert.AreEqual(1, dbCaseTemplateSiteTags.Count);
            Assert.AreEqual(2, dbCaseTemplateSiteTagVersions.Count);

            Assert.AreEqual(documentSiteTag.Id, dbCaseTemplateSiteTags[0].Id);
            Assert.AreEqual(documentSiteTag.Version, dbCaseTemplateSiteTags[0].Version);
            Assert.AreEqual(documentSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTags[0].CreatedAt.ToString());
            Assert.AreEqual(documentSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTags[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSiteTag.CreatedByUserId, dbCaseTemplateSiteTags[0].CreatedByUserId);
            Assert.AreEqual(documentSiteTag.UpdatedByUserId, dbCaseTemplateSiteTags[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateSiteTags[0].WorkflowState);
            Assert.AreEqual(documentSiteTag.DocumentId, dbCaseTemplateSiteTags[0].DocumentId);
            Assert.AreEqual(documentSiteTag.SdkSiteTagId, dbCaseTemplateSiteTags[0].SdkSiteTagId);

            //Old Version
            Assert.AreEqual(documentSiteTag.Id, dbCaseTemplateSiteTagVersions[0].DocumentSiteTagId);
            Assert.AreEqual(1, dbCaseTemplateSiteTagVersions[0].Version);
            Assert.AreEqual(documentSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(documentSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[0].CreatedByUserId);
            Assert.AreEqual(documentSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTagVersions[0].WorkflowState);
            Assert.AreEqual(documentSiteTag.DocumentId, dbCaseTemplateSiteTagVersions[0].DocumentId);
            Assert.AreEqual(documentSiteTag.SdkSiteTagId, dbCaseTemplateSiteTagVersions[0].SdkSiteTagId);

            //New Version
            Assert.AreEqual(documentSiteTag.Id, dbCaseTemplateSiteTagVersions[1].DocumentSiteTagId);
            Assert.AreEqual(2, dbCaseTemplateSiteTagVersions[1].Version);
            Assert.AreEqual(documentSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[1].CreatedAt.ToString());
            Assert.AreEqual(documentSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(documentSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[1].CreatedByUserId);
            Assert.AreEqual(documentSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateSiteTagVersions[1].WorkflowState);
            Assert.AreEqual(documentSiteTag.DocumentId, dbCaseTemplateSiteTagVersions[1].DocumentId);
            Assert.AreEqual(documentSiteTag.SdkSiteTagId, dbCaseTemplateSiteTagVersions[1].SdkSiteTagId);
        }
    }
}