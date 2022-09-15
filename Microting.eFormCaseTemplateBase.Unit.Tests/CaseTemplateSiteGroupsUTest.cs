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
            CaseTemplateSiteTag caseTemplateSiteTag = new CaseTemplateSiteTag
            {
                CaseTemplateId = rnd.Next(1, 255),
                SdkSiteTagId = rnd.Next(1, 255)
            };

            //Act

            await caseTemplateSiteTag.Create(DbContext);

            List<CaseTemplateSiteTag> dbCaseTemplateSiteTags =
                DbContext.CaseTemplateSiteTags.AsNoTracking().ToList();

            List<CaseTemplateSiteTagVersion> dbCaseTemplateSiteTagVersions =
                DbContext.CaseTemplateSiteTagVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateSiteTags);
            Assert.NotNull(dbCaseTemplateSiteTagVersions);

            Assert.AreEqual(1, dbCaseTemplateSiteTags.Count);
            Assert.AreEqual(1, dbCaseTemplateSiteTagVersions.Count);

            Assert.AreEqual(caseTemplateSiteTag.Id, dbCaseTemplateSiteTags[0].Id);
            Assert.AreEqual(caseTemplateSiteTag.Version, dbCaseTemplateSiteTags[0].Version);
            Assert.AreEqual(caseTemplateSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTags[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTags[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.CreatedByUserId, dbCaseTemplateSiteTags[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteTag.UpdatedByUserId, dbCaseTemplateSiteTags[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTags[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteTag.CaseTemplateId, dbCaseTemplateSiteTags[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteTag.SdkSiteTagId, dbCaseTemplateSiteTags[0].SdkSiteTagId);

            //Versions
            Assert.AreEqual(caseTemplateSiteTag.Id, dbCaseTemplateSiteTagVersions[0].CaseTemplateSiteTagId);
            Assert.AreEqual(caseTemplateSiteTag.Version, dbCaseTemplateSiteTagVersions[0].Version);
            Assert.AreEqual(caseTemplateSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTagVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteTag.CaseTemplateId, dbCaseTemplateSiteTagVersions[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteTag.SdkSiteTagId, dbCaseTemplateSiteTagVersions[0].SdkSiteTagId);
        }

        [Test]
        public async Task CaseTemplateSiteTags_Update_DoesUpdate()
        {
             //Arrange

            Random rnd = new Random();
            CaseTemplateSiteTag caseTemplateSiteTag = new CaseTemplateSiteTag
            {
                CaseTemplateId = rnd.Next(1, 255),
                SdkSiteTagId = rnd.Next(1, 255)
            };
            await caseTemplateSiteTag.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = caseTemplateSiteTag.UpdatedAt;
            int oldCaseTemplateId = caseTemplateSiteTag.CaseTemplateId;
            int oldSdkSiteTagId = caseTemplateSiteTag.SdkSiteTagId;

            caseTemplateSiteTag.CaseTemplateId = rnd.Next(1, 255);
            caseTemplateSiteTag.SdkSiteTagId = rnd.Next(1, 255);

            await caseTemplateSiteTag.Update(DbContext);

            List<CaseTemplateSiteTag> dbCaseTemplateSiteTags =
                DbContext.CaseTemplateSiteTags.AsNoTracking().ToList();

            List<CaseTemplateSiteTagVersion> dbCaseTemplateSiteTagVersions =
                DbContext.CaseTemplateSiteTagVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateSiteTags);
            Assert.NotNull(dbCaseTemplateSiteTagVersions);

            Assert.AreEqual(1, dbCaseTemplateSiteTags.Count);
            Assert.AreEqual(2, dbCaseTemplateSiteTagVersions.Count);

            Assert.AreEqual(caseTemplateSiteTag.Id, dbCaseTemplateSiteTags[0].Id);
            Assert.AreEqual(caseTemplateSiteTag.Version, dbCaseTemplateSiteTags[0].Version);
            Assert.AreEqual(caseTemplateSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTags[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTags[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.CreatedByUserId, dbCaseTemplateSiteTags[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteTag.UpdatedByUserId, dbCaseTemplateSiteTags[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTags[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteTag.CaseTemplateId, dbCaseTemplateSiteTags[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteTag.SdkSiteTagId, dbCaseTemplateSiteTags[0].SdkSiteTagId);

            //Old Version
            Assert.AreEqual(caseTemplateSiteTag.Id, dbCaseTemplateSiteTagVersions[0].CaseTemplateSiteTagId);
            Assert.AreEqual(1, dbCaseTemplateSiteTagVersions[0].Version);
            Assert.AreEqual(caseTemplateSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTagVersions[0].WorkflowState);
            Assert.AreEqual(oldCaseTemplateId, dbCaseTemplateSiteTagVersions[0].CaseTemplateId);
            Assert.AreEqual(oldSdkSiteTagId, dbCaseTemplateSiteTagVersions[0].SdkSiteTagId);

            //New Version
            Assert.AreEqual(caseTemplateSiteTag.Id, dbCaseTemplateSiteTagVersions[1].CaseTemplateSiteTagId);
            Assert.AreEqual(2, dbCaseTemplateSiteTagVersions[1].Version);
            Assert.AreEqual(caseTemplateSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTagVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplateSiteTag.CaseTemplateId, dbCaseTemplateSiteTagVersions[1].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteTag.SdkSiteTagId, dbCaseTemplateSiteTagVersions[1].SdkSiteTagId);
        }

        [Test]
        public async Task CaseTemplateSiteTags_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

             //Arrange

            Random rnd = new Random();
            CaseTemplateSiteTag caseTemplateSiteTag = new CaseTemplateSiteTag
            {
                CaseTemplateId = rnd.Next(1, 255),
                SdkSiteTagId = rnd.Next(1, 255)
            };
            await caseTemplateSiteTag.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = caseTemplateSiteTag.UpdatedAt;

            await caseTemplateSiteTag.Delete(DbContext);

            List<CaseTemplateSiteTag> dbCaseTemplateSiteTags =
                DbContext.CaseTemplateSiteTags.AsNoTracking().ToList();

            List<CaseTemplateSiteTagVersion> dbCaseTemplateSiteTagVersions =
                DbContext.CaseTemplateSiteTagVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplateSiteTags);
            Assert.NotNull(dbCaseTemplateSiteTagVersions);

            Assert.AreEqual(1, dbCaseTemplateSiteTags.Count);
            Assert.AreEqual(2, dbCaseTemplateSiteTagVersions.Count);

            Assert.AreEqual(caseTemplateSiteTag.Id, dbCaseTemplateSiteTags[0].Id);
            Assert.AreEqual(caseTemplateSiteTag.Version, dbCaseTemplateSiteTags[0].Version);
            Assert.AreEqual(caseTemplateSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTags[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTags[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.CreatedByUserId, dbCaseTemplateSiteTags[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteTag.UpdatedByUserId, dbCaseTemplateSiteTags[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateSiteTags[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteTag.CaseTemplateId, dbCaseTemplateSiteTags[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteTag.SdkSiteTagId, dbCaseTemplateSiteTags[0].SdkSiteTagId);

            //Old Version
            Assert.AreEqual(caseTemplateSiteTag.Id, dbCaseTemplateSiteTagVersions[0].CaseTemplateSiteTagId);
            Assert.AreEqual(1, dbCaseTemplateSiteTagVersions[0].Version);
            Assert.AreEqual(caseTemplateSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteTagVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteTag.CaseTemplateId, dbCaseTemplateSiteTagVersions[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteTag.SdkSiteTagId, dbCaseTemplateSiteTagVersions[0].SdkSiteTagId);

            //New Version
            Assert.AreEqual(caseTemplateSiteTag.Id, dbCaseTemplateSiteTagVersions[1].CaseTemplateSiteTagId);
            Assert.AreEqual(2, dbCaseTemplateSiteTagVersions[1].Version);
            Assert.AreEqual(caseTemplateSiteTag.CreatedAt.ToString(), dbCaseTemplateSiteTagVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.UpdatedAt.ToString(), dbCaseTemplateSiteTagVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteTag.CreatedByUserId, dbCaseTemplateSiteTagVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteTag.UpdatedByUserId, dbCaseTemplateSiteTagVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateSiteTagVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplateSiteTag.CaseTemplateId, dbCaseTemplateSiteTagVersions[1].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteTag.SdkSiteTagId, dbCaseTemplateSiteTagVersions[1].SdkSiteTagId);
        }
    }
}