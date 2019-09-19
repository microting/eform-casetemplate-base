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
    public class CaseTemplateSitesUTest : DbTestFixture
    {
        [Test]
        public void CaseTemplatesSites_Create_DoesCreate()
        {
            //Arrange
            
            Random rnd = new Random();
            CaseTemplateSite caseTemplateSite = new CaseTemplateSite();
            caseTemplateSite.CaseTemplateId = rnd.Next(1, 255);
            caseTemplateSite.SdkSiteId = rnd.Next(1, 255);
            caseTemplateSite.SdkCaseId = rnd.Next(1, 255);
            
            //Act
            
            caseTemplateSite.Create(DbContext);
            
            List<CaseTemplateSite> dbCaseTemplatesSite = DbContext.CaseTemplateSites.AsNoTracking().ToList();
            List<CaseTemplateSiteVersion> dbCaseTemplatesSiteVersions= DbContext.CaseTemplateSiteVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbCaseTemplatesSite);
            Assert.NotNull(dbCaseTemplatesSiteVersions);
            
            Assert.AreEqual(1, dbCaseTemplatesSite.Count);
            Assert.AreEqual(1, dbCaseTemplatesSiteVersions.Count);
            
            Assert.AreEqual(caseTemplateSite.Id, dbCaseTemplatesSite[0].Id);
            Assert.AreEqual(caseTemplateSite.Version, dbCaseTemplatesSite[0].Version);
            Assert.AreEqual(caseTemplateSite.CreatedAt.ToString(), dbCaseTemplatesSite[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.UpdatedAt.ToString(), dbCaseTemplatesSite[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.CreatedByUserId, dbCaseTemplatesSite[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSite.UpdatedByUserId, dbCaseTemplatesSite[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSite[0].WorkflowState);
            Assert.AreEqual(caseTemplateSite.CaseTemplateId, dbCaseTemplatesSite[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSite.SdkSiteId, dbCaseTemplatesSite[0].SdkSiteId);
            Assert.AreEqual(caseTemplateSite.SdkCaseId, dbCaseTemplatesSite[0].SdkCaseId);

            //Versions
            Assert.AreEqual(caseTemplateSite.Id, dbCaseTemplatesSiteVersions[0].CaseTemplateSiteId);
            Assert.AreEqual(caseTemplateSite.Version, dbCaseTemplatesSiteVersions[0].Version);
            Assert.AreEqual(caseTemplateSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.UpdatedAt.ToString(), dbCaseTemplatesSiteVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.CreatedByUserId, dbCaseTemplatesSiteVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSiteVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplateSite.CaseTemplateId, dbCaseTemplatesSiteVersions[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSite.SdkSiteId, dbCaseTemplatesSiteVersions[0].SdkSiteId);
            Assert.AreEqual(caseTemplateSite.SdkCaseId, dbCaseTemplatesSiteVersions[0].SdkCaseId);
        }

        [Test]
        public void CaseTemplateSitesUTest_Update_DoesUpdate()
        {
             //Arrange
            
            Random rnd = new Random();
            CaseTemplateSite caseTemplateSite = new CaseTemplateSite();
            caseTemplateSite.CaseTemplateId = rnd.Next(1, 255);
            caseTemplateSite.SdkSiteId = rnd.Next(1, 255);
            caseTemplateSite.SdkCaseId = rnd.Next(1, 255);
            caseTemplateSite.Create(DbContext);

            
            //Act

            DateTime? oldUpdatedAt = caseTemplateSite.UpdatedAt;
            int oldCaseTemplateId = caseTemplateSite.CaseTemplateId;
            int oldSdkSiteId = caseTemplateSite.SdkSiteId;
            int oldSdkCaseId = caseTemplateSite.SdkCaseId;
            
            caseTemplateSite.CaseTemplateId = rnd.Next(1, 255);
            caseTemplateSite.SdkSiteId = rnd.Next(1, 255);
            caseTemplateSite.SdkCaseId = rnd.Next(1, 255);

            caseTemplateSite.Update(DbContext);

            List<CaseTemplateSite> dbCaseTemplatesSite = DbContext.CaseTemplateSites.AsNoTracking().ToList();
            List<CaseTemplateSiteVersion> dbCaseTemplatesSiteVersions= DbContext.CaseTemplateSiteVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbCaseTemplatesSite);
            Assert.NotNull(dbCaseTemplatesSiteVersions);
            
            Assert.AreEqual(1, dbCaseTemplatesSite.Count);
            Assert.AreEqual(2, dbCaseTemplatesSiteVersions.Count);
            
            Assert.AreEqual(caseTemplateSite.Id, dbCaseTemplatesSite[0].Id);
            Assert.AreEqual(caseTemplateSite.Version, dbCaseTemplatesSite[0].Version);
            Assert.AreEqual(caseTemplateSite.CreatedAt.ToString(), dbCaseTemplatesSite[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.UpdatedAt.ToString(), dbCaseTemplatesSite[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.CreatedByUserId, dbCaseTemplatesSite[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSite.UpdatedByUserId, dbCaseTemplatesSite[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSite[0].WorkflowState);
            Assert.AreEqual(caseTemplateSite.CaseTemplateId, dbCaseTemplatesSite[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSite.SdkSiteId, dbCaseTemplatesSite[0].SdkSiteId);
            Assert.AreEqual(caseTemplateSite.SdkCaseId, dbCaseTemplatesSite[0].SdkCaseId);

            //Old Version
            Assert.AreEqual(caseTemplateSite.Id, dbCaseTemplatesSiteVersions[0].CaseTemplateSiteId);
            Assert.AreEqual(1, dbCaseTemplatesSiteVersions[0].Version);
            Assert.AreEqual(caseTemplateSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplatesSiteVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.CreatedByUserId, dbCaseTemplatesSiteVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSiteVersions[0].WorkflowState);
            Assert.AreEqual(oldCaseTemplateId, dbCaseTemplatesSiteVersions[0].CaseTemplateId);
            Assert.AreEqual(oldSdkSiteId, dbCaseTemplatesSiteVersions[0].SdkSiteId);
            Assert.AreEqual(oldSdkCaseId, dbCaseTemplatesSiteVersions[0].SdkCaseId);

            //New Version
            Assert.AreEqual(caseTemplateSite.Id, dbCaseTemplatesSiteVersions[1].CaseTemplateSiteId);
            Assert.AreEqual(2, dbCaseTemplatesSiteVersions[1].Version);
            Assert.AreEqual(caseTemplateSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.UpdatedAt.ToString(), dbCaseTemplatesSiteVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.CreatedByUserId, dbCaseTemplatesSiteVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplateSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSiteVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplateSite.CaseTemplateId, dbCaseTemplatesSiteVersions[1].CaseTemplateId);
            Assert.AreEqual(caseTemplateSite.SdkSiteId, dbCaseTemplatesSiteVersions[1].SdkSiteId);
            Assert.AreEqual(caseTemplateSite.SdkCaseId, dbCaseTemplatesSiteVersions[1].SdkCaseId);
            

        }

        [Test]
        public void CaseTemplateSites_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange
            
            Random rnd = new Random();
            CaseTemplateSite caseTemplateSite = new CaseTemplateSite();
            caseTemplateSite.CaseTemplateId = rnd.Next(1, 255);
            caseTemplateSite.SdkSiteId = rnd.Next(1, 255);
            caseTemplateSite.SdkCaseId = rnd.Next(1, 255);
            caseTemplateSite.Create(DbContext);

            
            //Act

            DateTime? oldUpdatedAt = caseTemplateSite.UpdatedAt;

            caseTemplateSite.Delete(DbContext);

            List<CaseTemplateSite> dbCaseTemplatesSite = DbContext.CaseTemplateSites.AsNoTracking().ToList();
            List<CaseTemplateSiteVersion> dbCaseTemplatesSiteVersions= DbContext.CaseTemplateSiteVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbCaseTemplatesSite);
            Assert.NotNull(dbCaseTemplatesSiteVersions);
            
            Assert.AreEqual(1, dbCaseTemplatesSite.Count);
            Assert.AreEqual(2, dbCaseTemplatesSiteVersions.Count);
            
            Assert.AreEqual(caseTemplateSite.Id, dbCaseTemplatesSite[0].Id);
            Assert.AreEqual(caseTemplateSite.Version, dbCaseTemplatesSite[0].Version);
            Assert.AreEqual(caseTemplateSite.CreatedAt.ToString(), dbCaseTemplatesSite[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.UpdatedAt.ToString(), dbCaseTemplatesSite[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.CreatedByUserId, dbCaseTemplatesSite[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSite.UpdatedByUserId, dbCaseTemplatesSite[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplatesSite[0].WorkflowState);
            Assert.AreEqual(caseTemplateSite.CaseTemplateId, dbCaseTemplatesSite[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSite.SdkSiteId, dbCaseTemplatesSite[0].SdkSiteId);
            Assert.AreEqual(caseTemplateSite.SdkCaseId, dbCaseTemplatesSite[0].SdkCaseId);

            //Old Version
            Assert.AreEqual(caseTemplateSite.Id, dbCaseTemplatesSiteVersions[0].CaseTemplateSiteId);
            Assert.AreEqual(1, dbCaseTemplatesSiteVersions[0].Version);
            Assert.AreEqual(caseTemplateSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplatesSiteVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.CreatedByUserId, dbCaseTemplatesSiteVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplateSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplatesSiteVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplateSite.CaseTemplateId, dbCaseTemplatesSiteVersions[0].CaseTemplateId);
            Assert.AreEqual(caseTemplateSite.SdkSiteId, dbCaseTemplatesSiteVersions[0].SdkSiteId);
            Assert.AreEqual(caseTemplateSite.SdkCaseId, dbCaseTemplatesSiteVersions[0].SdkCaseId);

            //New Version
            Assert.AreEqual(caseTemplateSite.Id, dbCaseTemplatesSiteVersions[1].CaseTemplateSiteId);
            Assert.AreEqual(2, dbCaseTemplatesSiteVersions[1].Version);
            Assert.AreEqual(caseTemplateSite.CreatedAt.ToString(), dbCaseTemplatesSiteVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.UpdatedAt.ToString(), dbCaseTemplatesSiteVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplateSite.CreatedByUserId, dbCaseTemplatesSiteVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplateSite.UpdatedByUserId, dbCaseTemplatesSiteVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplatesSiteVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplateSite.CaseTemplateId, dbCaseTemplatesSiteVersions[1].CaseTemplateId);
            Assert.AreEqual(caseTemplateSite.SdkSiteId, dbCaseTemplatesSiteVersions[1].SdkSiteId);
        }
    }
}