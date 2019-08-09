using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.eFormCaseTemplateCase.Unit.Tests
{
    [TestFixture]
    public class CaseTemplateSiteGroupsUTest : DbTestFixture
    {
        [Test]
        public void CaseTemplatesSiteGroups_Create_DoesCreate()
        {
            //Arrange
            
            Random rnd = new Random();
            CaseTemplateSiteGroup caseTemplateSiteGroup = new CaseTemplateSiteGroup();
            caseTemplateSiteGroup.CaseTemplateId = rnd.Next(1, 255);
            caseTemplateSiteGroup.SdkSiteGroupId = rnd.Next(1, 255);
            
            //Act

            caseTemplateSiteGroup.Create(DbContext);

            List<CaseTemplateSiteGroup> dbCaseTemplateSiteGroups =
                DbContext.CaseTemplateSiteGroups.AsNoTracking().ToList();

            List<CaseTemplateSiteGroupVersion> dbCaseTemplateSiteGroupVersions =
                DbContext.CaseTemplateSiteGroupVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbCaseTemplateSiteGroups);
            Assert.NotNull(dbCaseTemplateSiteGroupVersions);
            
            Assert.AreEqual(1, dbCaseTemplateSiteGroups.Count);
            Assert.AreEqual(1, dbCaseTemplateSiteGroupVersions.Count);
            
            Assert.AreEqual(caseTemplateSiteGroup.Id, dbCaseTemplateSiteGroups[0].Id);
            Assert.AreEqual(caseTemplateSiteGroup.Version, dbCaseTemplateSiteGroups[0].Version);
            Assert.AreEqual(caseTemplateSiteGroup.CreatedAt.ToString(), dbCaseTemplateSiteGroups[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedAt.ToString(), dbCaseTemplateSiteGroups[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.CreatedByUserId, dbCaseTemplateSiteGroups[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedByUserId, dbCaseTemplateSiteGroups[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteGroups[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteGroup.CaseTemplateId, dbCaseTemplateSiteGroups[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteGroup.SdkSiteGroupId, dbCaseTemplateSiteGroups[0].SdkSiteGroupId);

            //Versions
            Assert.AreEqual(caseTemplateSiteGroup.Id, dbCaseTemplateSiteGroupVersions[0].CaseTemplateSiteGroupId);
            Assert.AreEqual(caseTemplateSiteGroup.Version, dbCaseTemplateSiteGroupVersions[0].Version);
            Assert.AreEqual(caseTemplateSiteGroup.CreatedAt.ToString(), dbCaseTemplateSiteGroupVersions[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedAt.ToString(), dbCaseTemplateSiteGroupVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.CreatedByUserId, dbCaseTemplateSiteGroupVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedByUserId, dbCaseTemplateSiteGroupVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteGroupVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteGroup.CaseTemplateId, dbCaseTemplateSiteGroupVersions[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteGroup.SdkSiteGroupId, dbCaseTemplateSiteGroupVersions[0].SdkSiteGroupId);
        }

        [Test]
        public void CaseTemplateSiteGroups_Update_DoesUpdate()
        {
             //Arrange
            
            Random rnd = new Random();
            CaseTemplateSiteGroup caseTemplateSiteGroup = new CaseTemplateSiteGroup();
            caseTemplateSiteGroup.CaseTemplateId = rnd.Next(1, 255);
            caseTemplateSiteGroup.SdkSiteGroupId = rnd.Next(1, 255);
            caseTemplateSiteGroup.Create(DbContext);

            
            //Act

            DateTime? oldUpdatedAt = caseTemplateSiteGroup.UpdatedAt;
            int oldCaseTemplateId = caseTemplateSiteGroup.CaseTemplateId;
            int oldSdkSiteGroupId = caseTemplateSiteGroup.SdkSiteGroupId;

            caseTemplateSiteGroup.CaseTemplateId = rnd.Next(1, 255);
            caseTemplateSiteGroup.SdkSiteGroupId = rnd.Next(1, 255);

            caseTemplateSiteGroup.Update(DbContext);

            List<CaseTemplateSiteGroup> dbCaseTemplateSiteGroups =
                DbContext.CaseTemplateSiteGroups.AsNoTracking().ToList();

            List<CaseTemplateSiteGroupVersion> dbCaseTemplateSiteGroupVersions =
                DbContext.CaseTemplateSiteGroupVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbCaseTemplateSiteGroups);
            Assert.NotNull(dbCaseTemplateSiteGroupVersions);
            
            Assert.AreEqual(1, dbCaseTemplateSiteGroups.Count);
            Assert.AreEqual(2, dbCaseTemplateSiteGroupVersions.Count);
            
            Assert.AreEqual(caseTemplateSiteGroup.Id, dbCaseTemplateSiteGroups[0].Id);
            Assert.AreEqual(caseTemplateSiteGroup.Version, dbCaseTemplateSiteGroups[0].Version);
            Assert.AreEqual(caseTemplateSiteGroup.CreatedAt.ToString(), dbCaseTemplateSiteGroups[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedAt.ToString(), dbCaseTemplateSiteGroups[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.CreatedByUserId, dbCaseTemplateSiteGroups[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedByUserId, dbCaseTemplateSiteGroups[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteGroups[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteGroup.CaseTemplateId, dbCaseTemplateSiteGroups[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteGroup.SdkSiteGroupId, dbCaseTemplateSiteGroups[0].SdkSiteGroupId);

            //Old Version
            Assert.AreEqual(caseTemplateSiteGroup.Id, dbCaseTemplateSiteGroupVersions[0].CaseTemplateSiteGroupId);
            Assert.AreEqual(1, dbCaseTemplateSiteGroupVersions[0].Version);
            Assert.AreEqual(caseTemplateSiteGroup.CreatedAt.ToString(), dbCaseTemplateSiteGroupVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateSiteGroupVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.CreatedByUserId, dbCaseTemplateSiteGroupVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedByUserId, dbCaseTemplateSiteGroupVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteGroupVersions[0].WorkflowState);
            Assert.AreEqual(oldCaseTemplateId, dbCaseTemplateSiteGroupVersions[0].CaseTemplateId);
            Assert.AreEqual(oldSdkSiteGroupId, dbCaseTemplateSiteGroupVersions[0].SdkSiteGroupId);
            
            //New Version
            Assert.AreEqual(caseTemplateSiteGroup.Id, dbCaseTemplateSiteGroupVersions[1].CaseTemplateSiteGroupId);
            Assert.AreEqual(2, dbCaseTemplateSiteGroupVersions[1].Version);
            Assert.AreEqual(caseTemplateSiteGroup.CreatedAt.ToString(), dbCaseTemplateSiteGroupVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedAt.ToString(), dbCaseTemplateSiteGroupVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.CreatedByUserId, dbCaseTemplateSiteGroupVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedByUserId, dbCaseTemplateSiteGroupVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteGroupVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplateSiteGroup.CaseTemplateId, dbCaseTemplateSiteGroupVersions[1].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteGroup.SdkSiteGroupId, dbCaseTemplateSiteGroupVersions[1].SdkSiteGroupId);
        }

        [Test]
        public void CaseTemplateSiteGroups_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange
            
             //Arrange
            
            Random rnd = new Random();
            CaseTemplateSiteGroup caseTemplateSiteGroup = new CaseTemplateSiteGroup();
            caseTemplateSiteGroup.CaseTemplateId = rnd.Next(1, 255);
            caseTemplateSiteGroup.SdkSiteGroupId = rnd.Next(1, 255);
            caseTemplateSiteGroup.Create(DbContext);

            
            //Act

            DateTime? oldUpdatedAt = caseTemplateSiteGroup.UpdatedAt;

            caseTemplateSiteGroup.Delete(DbContext);

            List<CaseTemplateSiteGroup> dbCaseTemplateSiteGroups =
                DbContext.CaseTemplateSiteGroups.AsNoTracking().ToList();

            List<CaseTemplateSiteGroupVersion> dbCaseTemplateSiteGroupVersions =
                DbContext.CaseTemplateSiteGroupVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbCaseTemplateSiteGroups);
            Assert.NotNull(dbCaseTemplateSiteGroupVersions);
            
            Assert.AreEqual(1, dbCaseTemplateSiteGroups.Count);
            Assert.AreEqual(2, dbCaseTemplateSiteGroupVersions.Count);
            
            Assert.AreEqual(caseTemplateSiteGroup.Id, dbCaseTemplateSiteGroups[0].Id);
            Assert.AreEqual(caseTemplateSiteGroup.Version, dbCaseTemplateSiteGroups[0].Version);
            Assert.AreEqual(caseTemplateSiteGroup.CreatedAt.ToString(), dbCaseTemplateSiteGroups[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedAt.ToString(), dbCaseTemplateSiteGroups[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.CreatedByUserId, dbCaseTemplateSiteGroups[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedByUserId, dbCaseTemplateSiteGroups[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateSiteGroups[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteGroup.CaseTemplateId, dbCaseTemplateSiteGroups[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteGroup.SdkSiteGroupId, dbCaseTemplateSiteGroups[0].SdkSiteGroupId);

            //Old Version
            Assert.AreEqual(caseTemplateSiteGroup.Id, dbCaseTemplateSiteGroupVersions[0].CaseTemplateSiteGroupId);
            Assert.AreEqual(1, dbCaseTemplateSiteGroupVersions[0].Version);
            Assert.AreEqual(caseTemplateSiteGroup.CreatedAt.ToString(), dbCaseTemplateSiteGroupVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateSiteGroupVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.CreatedByUserId, dbCaseTemplateSiteGroupVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedByUserId, dbCaseTemplateSiteGroupVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateSiteGroupVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplateSiteGroup.CaseTemplateId, dbCaseTemplateSiteGroupVersions[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteGroup.SdkSiteGroupId, dbCaseTemplateSiteGroupVersions[0].SdkSiteGroupId);
            
            //New Version
            Assert.AreEqual(caseTemplateSiteGroup.Id, dbCaseTemplateSiteGroupVersions[1].CaseTemplateSiteGroupId);
            Assert.AreEqual(2, dbCaseTemplateSiteGroupVersions[1].Version);
            Assert.AreEqual(caseTemplateSiteGroup.CreatedAt.ToString(), dbCaseTemplateSiteGroupVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedAt.ToString(), dbCaseTemplateSiteGroupVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSiteGroup.CreatedByUserId, dbCaseTemplateSiteGroupVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplateSiteGroup.UpdatedByUserId, dbCaseTemplateSiteGroupVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateSiteGroupVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplateSiteGroup.CaseTemplateId, dbCaseTemplateSiteGroupVersions[1].CaseTemplateId);
            Assert.AreEqual(caseTemplateSiteGroup.SdkSiteGroupId, dbCaseTemplateSiteGroupVersions[1].SdkSiteGroupId);
        }
    }
}