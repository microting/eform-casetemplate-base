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
            Assert.That(dbCaseTemplateSiteTags, Is.Not.Null);
            Assert.That(dbCaseTemplateSiteTagVersions, Is.Not.Null);

            Assert.That(dbCaseTemplateSiteTags.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplateSiteTagVersions.Count, Is.EqualTo(1));

            Assert.That(dbCaseTemplateSiteTags[0].Id, Is.EqualTo(documentSiteTag.Id));
            Assert.That(dbCaseTemplateSiteTags[0].Version, Is.EqualTo(documentSiteTag.Version));
            Assert.That(dbCaseTemplateSiteTags[0].CreatedAt.ToString(), Is.EqualTo(documentSiteTag.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTags[0].UpdatedAt.ToString(), Is.EqualTo(documentSiteTag.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTags[0].CreatedByUserId, Is.EqualTo(documentSiteTag.CreatedByUserId));
            Assert.That(dbCaseTemplateSiteTags[0].UpdatedByUserId, Is.EqualTo(documentSiteTag.UpdatedByUserId));
            Assert.That(dbCaseTemplateSiteTags[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateSiteTags[0].DocumentId, Is.EqualTo(documentSiteTag.DocumentId));
            Assert.That(dbCaseTemplateSiteTags[0].SdkSiteTagId, Is.EqualTo(documentSiteTag.SdkSiteTagId));

            //Versions
            Assert.That(dbCaseTemplateSiteTagVersions[0].DocumentSiteTagId, Is.EqualTo(documentSiteTag.Id));
            Assert.That(dbCaseTemplateSiteTagVersions[0].Version, Is.EqualTo(documentSiteTag.Version));
            Assert.That(dbCaseTemplateSiteTagVersions[0].CreatedAt.ToString(), Is.EqualTo(documentSiteTag.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[0].UpdatedAt.ToString(), Is.EqualTo(documentSiteTag.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[0].CreatedByUserId, Is.EqualTo(documentSiteTag.CreatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[0].UpdatedByUserId, Is.EqualTo(documentSiteTag.UpdatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateSiteTagVersions[0].DocumentId, Is.EqualTo(documentSiteTag.DocumentId));
            Assert.That(dbCaseTemplateSiteTagVersions[0].SdkSiteTagId, Is.EqualTo(documentSiteTag.SdkSiteTagId));
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
            Assert.That(dbCaseTemplateSiteTags, Is.Not.Null);
            Assert.That(dbCaseTemplateSiteTagVersions, Is.Not.Null);

            Assert.That(dbCaseTemplateSiteTags.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplateSiteTagVersions.Count, Is.EqualTo(2));

            Assert.That(dbCaseTemplateSiteTags[0].Id, Is.EqualTo(documentSiteTag.Id));
            Assert.That(dbCaseTemplateSiteTags[0].Version, Is.EqualTo(documentSiteTag.Version));
            Assert.That(dbCaseTemplateSiteTags[0].CreatedAt.ToString(), Is.EqualTo(documentSiteTag.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTags[0].UpdatedAt.ToString(), Is.EqualTo(documentSiteTag.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTags[0].CreatedByUserId, Is.EqualTo(documentSiteTag.CreatedByUserId));
            Assert.That(dbCaseTemplateSiteTags[0].UpdatedByUserId, Is.EqualTo(documentSiteTag.UpdatedByUserId));
            Assert.That(dbCaseTemplateSiteTags[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateSiteTags[0].DocumentId, Is.EqualTo(documentSiteTag.DocumentId));
            Assert.That(dbCaseTemplateSiteTags[0].SdkSiteTagId, Is.EqualTo(documentSiteTag.SdkSiteTagId));

            //Old Version
            Assert.That(dbCaseTemplateSiteTagVersions[0].DocumentSiteTagId, Is.EqualTo(documentSiteTag.Id));
            Assert.That(dbCaseTemplateSiteTagVersions[0].Version, Is.EqualTo(1));
            Assert.That(dbCaseTemplateSiteTagVersions[0].CreatedAt.ToString(), Is.EqualTo(documentSiteTag.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[0].CreatedByUserId, Is.EqualTo(documentSiteTag.CreatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[0].UpdatedByUserId, Is.EqualTo(documentSiteTag.UpdatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateSiteTagVersions[0].DocumentId, Is.EqualTo(oldCaseTemplateId));
            Assert.That(dbCaseTemplateSiteTagVersions[0].SdkSiteTagId, Is.EqualTo(oldSdkSiteTagId));

            //New Version
            Assert.That(dbCaseTemplateSiteTagVersions[1].DocumentSiteTagId, Is.EqualTo(documentSiteTag.Id));
            Assert.That(dbCaseTemplateSiteTagVersions[1].Version, Is.EqualTo(2));
            Assert.That(dbCaseTemplateSiteTagVersions[1].CreatedAt.ToString(), Is.EqualTo(documentSiteTag.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[1].UpdatedAt.ToString(), Is.EqualTo(documentSiteTag.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[1].CreatedByUserId, Is.EqualTo(documentSiteTag.CreatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[1].UpdatedByUserId, Is.EqualTo(documentSiteTag.UpdatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateSiteTagVersions[1].DocumentId, Is.EqualTo(documentSiteTag.DocumentId));
            Assert.That(dbCaseTemplateSiteTagVersions[1].SdkSiteTagId, Is.EqualTo(documentSiteTag.SdkSiteTagId));
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
            Assert.That(dbCaseTemplateSiteTags, Is.Not.Null);
            Assert.That(dbCaseTemplateSiteTagVersions, Is.Not.Null);

            Assert.That(dbCaseTemplateSiteTags.Count, Is.EqualTo(1));
            Assert.That(dbCaseTemplateSiteTagVersions.Count, Is.EqualTo(2));

            Assert.That(dbCaseTemplateSiteTags[0].Id, Is.EqualTo(documentSiteTag.Id));
            Assert.That(dbCaseTemplateSiteTags[0].Version, Is.EqualTo(documentSiteTag.Version));
            Assert.That(dbCaseTemplateSiteTags[0].CreatedAt.ToString(), Is.EqualTo(documentSiteTag.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTags[0].UpdatedAt.ToString(), Is.EqualTo(documentSiteTag.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTags[0].CreatedByUserId, Is.EqualTo(documentSiteTag.CreatedByUserId));
            Assert.That(dbCaseTemplateSiteTags[0].UpdatedByUserId, Is.EqualTo(documentSiteTag.UpdatedByUserId));
            Assert.That(dbCaseTemplateSiteTags[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbCaseTemplateSiteTags[0].DocumentId, Is.EqualTo(documentSiteTag.DocumentId));
            Assert.That(dbCaseTemplateSiteTags[0].SdkSiteTagId, Is.EqualTo(documentSiteTag.SdkSiteTagId));

            //Old Version
            Assert.That(dbCaseTemplateSiteTagVersions[0].DocumentSiteTagId, Is.EqualTo(documentSiteTag.Id));
            Assert.That(dbCaseTemplateSiteTagVersions[0].Version, Is.EqualTo(1));
            Assert.That(dbCaseTemplateSiteTagVersions[0].CreatedAt.ToString(), Is.EqualTo(documentSiteTag.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[0].CreatedByUserId, Is.EqualTo(documentSiteTag.CreatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[0].UpdatedByUserId, Is.EqualTo(documentSiteTag.UpdatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbCaseTemplateSiteTagVersions[0].DocumentId, Is.EqualTo(documentSiteTag.DocumentId));
            Assert.That(dbCaseTemplateSiteTagVersions[0].SdkSiteTagId, Is.EqualTo(documentSiteTag.SdkSiteTagId));

            //New Version
            Assert.That(dbCaseTemplateSiteTagVersions[1].DocumentSiteTagId, Is.EqualTo(documentSiteTag.Id));
            Assert.That(dbCaseTemplateSiteTagVersions[1].Version, Is.EqualTo(2));
            Assert.That(dbCaseTemplateSiteTagVersions[1].CreatedAt.ToString(), Is.EqualTo(documentSiteTag.CreatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[1].UpdatedAt.ToString(), Is.EqualTo(documentSiteTag.UpdatedAt.ToString()));
            Assert.That(dbCaseTemplateSiteTagVersions[1].CreatedByUserId, Is.EqualTo(documentSiteTag.CreatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[1].UpdatedByUserId, Is.EqualTo(documentSiteTag.UpdatedByUserId));
            Assert.That(dbCaseTemplateSiteTagVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbCaseTemplateSiteTagVersions[1].DocumentId, Is.EqualTo(documentSiteTag.DocumentId));
            Assert.That(dbCaseTemplateSiteTagVersions[1].SdkSiteTagId, Is.EqualTo(documentSiteTag.SdkSiteTagId));
        }
    }
}