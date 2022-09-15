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

            CaseTemplate caseTemplate = new CaseTemplate
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                DescriptionFolderId = rnd.Next(1, 200),
                RetractIfApproved = randomBool
            };

            //Act

            await caseTemplate.Create(DbContext);


            List<CaseTemplate> dbCaseTemplates = DbContext.CaseTemplates.AsNoTracking().ToList();
            List<CaseTemplateVersion> dbCaseTemplateVersions = DbContext.CaseTemplateVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplates);
            Assert.NotNull(dbCaseTemplateVersions);

            Assert.AreEqual(1, dbCaseTemplates.Count);
            Assert.AreEqual(1, dbCaseTemplateVersions.Count);


            Assert.AreEqual(caseTemplate.Id, dbCaseTemplates[0].Id);
            Assert.AreEqual(caseTemplate.Version, dbCaseTemplates[0].Version);
            Assert.AreEqual(caseTemplate.CreatedAt.ToString(), dbCaseTemplates[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplate.UpdatedAt.ToString(), dbCaseTemplates[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplates[0].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplates[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplates[0].WorkflowState);
            Assert.AreEqual(caseTemplate.Approvable, dbCaseTemplates[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplates[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplates[0].Title);
            Assert.AreEqual(caseTemplate.AlwaysShow, dbCaseTemplates[0].AlwaysShow);
            Assert.AreEqual(caseTemplate.EndAt.ToString(), dbCaseTemplates[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplates[0].PdfTitle);
            Assert.AreEqual(caseTemplate.StartAt.ToString(), dbCaseTemplates[0].StartAt.ToString());
            Assert.AreEqual(caseTemplate.DescriptionFolderId, dbCaseTemplates[0].DescriptionFolderId);
            Assert.AreEqual(caseTemplate.RetractIfApproved, dbCaseTemplates[0].RetractIfApproved);

            //Versions
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateVersions[0].Id);
            Assert.AreEqual(caseTemplate.Version, dbCaseTemplateVersions[0].Version);
            Assert.AreEqual(caseTemplate.CreatedAt.ToString(), dbCaseTemplateVersions[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplate.UpdatedAt.ToString(), dbCaseTemplateVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplateVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplateVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplate.Approvable, dbCaseTemplateVersions[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplateVersions[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplateVersions[0].Title);
            Assert.AreEqual(caseTemplate.AlwaysShow, dbCaseTemplateVersions[0].AlwaysShow);
            Assert.AreEqual(caseTemplate.EndAt.ToString(), dbCaseTemplateVersions[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplateVersions[0].PdfTitle);
            Assert.AreEqual(caseTemplate.StartAt.ToString(), dbCaseTemplateVersions[0].StartAt.ToString());
            Assert.AreEqual(caseTemplate.DescriptionFolderId, dbCaseTemplateVersions[0].DescriptionFolderId);
            Assert.AreEqual(caseTemplate.RetractIfApproved, dbCaseTemplateVersions[0].RetractIfApproved);
        }

        [Test]
        public async Task CaseTemplates_Update_DoesUpdate()
        {
            //Arrange

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            CaseTemplate caseTemplate = new CaseTemplate
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                DescriptionFolderId = rnd.Next(1, 200),
                RetractIfApproved = randomBool
            };
            await caseTemplate.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = caseTemplate.UpdatedAt;
            bool oldApprovable = caseTemplate.Approvable;
            // string oldBody = caseTemplate.Body;
            // string oldTitle = caseTemplate.Title;
            bool oldAlwaysShow = caseTemplate.AlwaysShow;
            DateTime oldEndAt = caseTemplate.EndAt;
            // string oldPdfTitle = caseTemplate.PdfTitle;
            DateTime oldStartAt = caseTemplate.StartAt;
            int oldDescriptionFolderId = caseTemplate.DescriptionFolderId;
            bool oldRetractIfApproved = caseTemplate.RetractIfApproved;

            caseTemplate.Approvable = randomBool;
            // caseTemplate.Body = Guid.NewGuid().ToString();
            // caseTemplate.Title = Guid.NewGuid().ToString();
            caseTemplate.AlwaysShow = randomBool;
            caseTemplate.EndAt = DateTime.Now;
            // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
            caseTemplate.StartAt = DateTime.Now;
            caseTemplate.DescriptionFolderId = rnd.Next(1, 200);
            caseTemplate.RetractIfApproved = randomBool;

            await caseTemplate.Update(DbContext);

            List<CaseTemplate> dbCaseTemplates = DbContext.CaseTemplates.AsNoTracking().ToList();
            List<CaseTemplateVersion> dbCaseTemplateVersions = DbContext.CaseTemplateVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplates);
            Assert.NotNull(dbCaseTemplateVersions);

            Assert.AreEqual(1, dbCaseTemplates.Count);
            Assert.AreEqual(2, dbCaseTemplateVersions.Count);


            Assert.AreEqual(caseTemplate.Id, dbCaseTemplates[0].Id);
            Assert.AreEqual(caseTemplate.Version, dbCaseTemplates[0].Version);
            Assert.AreEqual(caseTemplate.CreatedAt.ToString(), dbCaseTemplates[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplate.UpdatedAt.ToString(), dbCaseTemplates[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplates[0].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplates[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplates[0].WorkflowState);
            Assert.AreEqual(caseTemplate.Approvable, dbCaseTemplates[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplates[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplates[0].Title);
            Assert.AreEqual(caseTemplate.AlwaysShow, dbCaseTemplates[0].AlwaysShow);
            Assert.AreEqual(caseTemplate.EndAt.ToString(), dbCaseTemplates[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplates[0].PdfTitle);
            Assert.AreEqual(caseTemplate.StartAt.ToString(), dbCaseTemplates[0].StartAt.ToString());
            Assert.AreEqual(caseTemplate.DescriptionFolderId, dbCaseTemplates[0].DescriptionFolderId);
            Assert.AreEqual(caseTemplate.RetractIfApproved, dbCaseTemplates[0].RetractIfApproved);

            //Old Version
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateVersions[0].CaseTemplateId);
            Assert.AreEqual(1, dbCaseTemplateVersions[0].Version);
            Assert.AreEqual(caseTemplate.CreatedAt.ToString(), dbCaseTemplateVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplateVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplateVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateVersions[0].WorkflowState);
            Assert.AreEqual(oldApprovable, dbCaseTemplateVersions[0].Approvable);
            // Assert.AreEqual(oldBody, dbCaseTemplateVersions[0].Body);
            // Assert.AreEqual(oldTitle, dbCaseTemplateVersions[0].Title);
            Assert.AreEqual(oldAlwaysShow, dbCaseTemplateVersions[0].AlwaysShow);
            Assert.AreEqual(oldEndAt.ToString(), dbCaseTemplateVersions[0].EndAt.ToString());
            // Assert.AreEqual(oldPdfTitle, dbCaseTemplateVersions[0].PdfTitle);
            Assert.AreEqual(oldStartAt.ToString(), dbCaseTemplateVersions[0].StartAt.ToString());
            Assert.AreEqual(oldDescriptionFolderId, dbCaseTemplateVersions[0].DescriptionFolderId);
            Assert.AreEqual(oldRetractIfApproved, dbCaseTemplateVersions[0].RetractIfApproved);

            //New Version
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateVersions[1].CaseTemplateId);
            Assert.AreEqual(2, dbCaseTemplateVersions[1].Version);
            Assert.AreEqual(caseTemplate.CreatedAt.ToString(), dbCaseTemplateVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplate.UpdatedAt.ToString(), dbCaseTemplateVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplateVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplateVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplate.Approvable, dbCaseTemplateVersions[1].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplateVersions[1].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplateVersions[1].Title);
            Assert.AreEqual(caseTemplate.AlwaysShow, dbCaseTemplateVersions[1].AlwaysShow);
            Assert.AreEqual(caseTemplate.EndAt.ToString(), dbCaseTemplateVersions[1].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplateVersions[1].PdfTitle);
            Assert.AreEqual(caseTemplate.StartAt.ToString(), dbCaseTemplateVersions[1].StartAt.ToString());
            Assert.AreEqual(caseTemplate.DescriptionFolderId, dbCaseTemplateVersions[1].DescriptionFolderId);
            Assert.AreEqual(caseTemplate.RetractIfApproved, dbCaseTemplateVersions[1].RetractIfApproved);
        }

        [Test]
        public async Task CaseTemplates_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

            Random rnd = new Random();
            bool randomBool = rnd.Next(0, 2) > 0;

            CaseTemplate caseTemplate = new CaseTemplate
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                DescriptionFolderId = rnd.Next(1, 200),
                RetractIfApproved = randomBool
            };
            await caseTemplate.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = caseTemplate.UpdatedAt;

            await caseTemplate.Delete(DbContext);

            List<CaseTemplate> dbCaseTemplates = DbContext.CaseTemplates.AsNoTracking().ToList();
            List<CaseTemplateVersion> dbCaseTemplateVersions = DbContext.CaseTemplateVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCaseTemplates);
            Assert.NotNull(dbCaseTemplateVersions);

            Assert.AreEqual(1, dbCaseTemplates.Count);
            Assert.AreEqual(2, dbCaseTemplateVersions.Count);


            Assert.AreEqual(caseTemplate.Id, dbCaseTemplates[0].Id);
            Assert.AreEqual(caseTemplate.Version, dbCaseTemplates[0].Version);
            Assert.AreEqual(caseTemplate.CreatedAt.ToString(), dbCaseTemplates[0].CreatedAt.ToString());
            Assert.AreEqual(caseTemplate.UpdatedAt.ToString(), dbCaseTemplates[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplates[0].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplates[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplates[0].WorkflowState);
            Assert.AreEqual(caseTemplate.Approvable, dbCaseTemplates[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplates[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplates[0].Title);
            Assert.AreEqual(caseTemplate.AlwaysShow, dbCaseTemplates[0].AlwaysShow);
            Assert.AreEqual(caseTemplate.EndAt.ToString(), dbCaseTemplates[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplates[0].PdfTitle);
            Assert.AreEqual(caseTemplate.StartAt.ToString(), dbCaseTemplates[0].StartAt.ToString());
            Assert.AreEqual(caseTemplate.DescriptionFolderId, dbCaseTemplates[0].DescriptionFolderId);
            Assert.AreEqual(caseTemplate.RetractIfApproved, dbCaseTemplates[0].RetractIfApproved);

            //Old Version
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateVersions[0].CaseTemplateId);
            Assert.AreEqual(1, dbCaseTemplateVersions[0].Version);
            Assert.AreEqual(caseTemplate.CreatedAt.ToString(), dbCaseTemplateVersions[0].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseTemplateVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplateVersions[0].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplateVersions[0].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseTemplateVersions[0].WorkflowState);
            Assert.AreEqual(caseTemplate.Approvable, dbCaseTemplateVersions[0].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplateVersions[0].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplateVersions[0].Title);
            Assert.AreEqual(caseTemplate.AlwaysShow, dbCaseTemplateVersions[0].AlwaysShow);
            Assert.AreEqual(caseTemplate.EndAt.ToString(), dbCaseTemplateVersions[0].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplateVersions[0].PdfTitle);
            Assert.AreEqual(caseTemplate.StartAt.ToString(), dbCaseTemplateVersions[0].StartAt.ToString());
            Assert.AreEqual(caseTemplate.DescriptionFolderId, dbCaseTemplateVersions[0].DescriptionFolderId);
            Assert.AreEqual(caseTemplate.RetractIfApproved, dbCaseTemplateVersions[0].RetractIfApproved);

            //New Version
            Assert.AreEqual(caseTemplate.Id, dbCaseTemplateVersions[1].CaseTemplateId);
            Assert.AreEqual(2, dbCaseTemplateVersions[1].Version);
            Assert.AreEqual(caseTemplate.CreatedAt.ToString(), dbCaseTemplateVersions[1].CreatedAt.ToString());
            Assert.AreEqual(caseTemplate.UpdatedAt.ToString(), dbCaseTemplateVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(caseTemplate.CreatedByUserId, dbCaseTemplateVersions[1].CreatedByUserId);
            Assert.AreEqual(caseTemplate.UpdatedByUserId, dbCaseTemplateVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseTemplateVersions[1].WorkflowState);
            Assert.AreEqual(caseTemplate.Approvable, dbCaseTemplateVersions[1].Approvable);
            // Assert.AreEqual(caseTemplate.Body, dbCaseTemplateVersions[1].Body);
            // Assert.AreEqual(caseTemplate.Title, dbCaseTemplateVersions[1].Title);
            Assert.AreEqual(caseTemplate.AlwaysShow, dbCaseTemplateVersions[1].AlwaysShow);
            Assert.AreEqual(caseTemplate.EndAt.ToString(), dbCaseTemplateVersions[1].EndAt.ToString());
            // Assert.AreEqual(caseTemplate.PdfTitle, dbCaseTemplateVersions[1].PdfTitle);
            Assert.AreEqual(caseTemplate.StartAt.ToString(), dbCaseTemplateVersions[1].StartAt.ToString());
            Assert.AreEqual(caseTemplate.DescriptionFolderId, dbCaseTemplateVersions[1].DescriptionFolderId);
            Assert.AreEqual(caseTemplate.RetractIfApproved, dbCaseTemplateVersions[1].RetractIfApproved);
        }
    }
}