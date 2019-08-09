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
        }
    }
}