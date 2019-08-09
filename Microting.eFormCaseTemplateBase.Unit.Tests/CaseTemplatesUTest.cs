using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CaseTemplates_Create_DoesCreate()
        {
            //Arrange
            
            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;
            
            CaseTemplate caseTemplate = new CaseTemplate();
            caseTemplate.Approvable = randomBool;
            caseTemplate.Body = Guid.NewGuid().ToString();
            caseTemplate.Title = Guid.NewGuid().ToString();
            caseTemplate.AlwaysShow = randomBool;
            caseTemplate.EndAt = DateTime.Now;
            caseTemplate.PdfTitle = Guid.NewGuid().ToString();
            caseTemplate.StartAt = DateTime.Now;
            caseTemplate.DescriptionFolderId = rnd.Next(1, 200);
            caseTemplate.RetractIfApproved = randomBool;
            
            //Act
            
            caseTemplate.Create(DbContext);
            

            List<CaseTemplate> dbCaseTemplates = DbContext.CaseTemplates.AsNoTracking().ToList();
            List<CaseTemplateVersion> dbCaseTemplateVersions = DbContext.CaseTemplateVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbCaseTemplates);
            Assert.NotNull(dbCaseTemplateVersions);
            
            Assert.AreEqual(1, dbCaseTemplates.Count);
            Assert.AreEqual(1, dbCaseTemplateVersions.Count);
            
            
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplates[0].Id);
            Assert.AreEqual(caseTemplate.Version, dbCaseTemplates[0].Version);
            Assert.AreEqual(caseTemplate.CreatedAt, dbCaseTemplates[0].CreatedAt);
            Assert.AreEqual(caseTemplate.UpdatedAt, dbCaseTemplates[0].UpdatedAt);
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplates[0].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplates[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplates[0].WorkflowState);
            Assert.AreEqual(caseTemplate.Approvable, dbCaseTemplates[0].Approvable);
            Assert.AreEqual(caseTemplate.Body, dbCaseTemplates[0].Body);
            Assert.AreEqual(caseTemplate.Title, dbCaseTemplates[0].Title);
            Assert.AreEqual(caseTemplate.AlwaysShow, dbCaseTemplates[0].AlwaysShow);
            Assert.AreEqual(caseTemplate.EndAt, dbCaseTemplates[0].EndAt);
            Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplates[0].PdfTitle);
            Assert.AreEqual(caseTemplate.StartAt, dbCaseTemplates[0].StartAt);
            Assert.AreEqual(caseTemplate.DescriptionFolderId, dbCaseTemplates[0].DescriptionFolderId);
            Assert.AreEqual(caseTemplate.RetractIfApproved, dbCaseTemplates[0].RetractIfApproved);

            //Versions
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateVersions[0].Id);
            Assert.AreEqual(caseTemplate.Version, dbCaseTemplateVersions[0].Version);
            Assert.AreEqual(caseTemplate.CreatedAt, dbCaseTemplateVersions[0].CreatedAt);
            Assert.AreEqual(caseTemplate.UpdatedAt, dbCaseTemplateVersions[0].UpdatedAt);
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplateVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplateVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplate.Approvable, dbCaseTemplateVersions[0].Approvable);
            Assert.AreEqual(caseTemplate.Body, dbCaseTemplateVersions[0].Body);
            Assert.AreEqual(caseTemplate.Title, dbCaseTemplateVersions[0].Title);
            Assert.AreEqual(caseTemplate.AlwaysShow, dbCaseTemplateVersions[0].AlwaysShow);
            Assert.AreEqual(caseTemplate.EndAt, dbCaseTemplateVersions[0].EndAt);
            Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplateVersions[0].PdfTitle);
            Assert.AreEqual(caseTemplate.StartAt, dbCaseTemplateVersions[0].StartAt);
            Assert.AreEqual(caseTemplate.DescriptionFolderId, dbCaseTemplateVersions[0].DescriptionFolderId);
            Assert.AreEqual(caseTemplate.RetractIfApproved, dbCaseTemplateVersions[0].RetractIfApproved);
        }
    }
}