using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.eFormCaseTemplateCase.Unit.Tests
{
    [TestFixture]
    public class CasesUTest : DbTestFixture
    {
        [Test]
        public async Task Cases_Create_DoesCreate()
        {
            #region Arrange
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
                DescriptionFolderId = rnd.Next(0, 255),
                RetractIfApproved = randomBool
            };

            await caseTemplate.Create(DbContext);

            Case @case = new Case
            {
                Status = rnd.Next(0, 255),
                Type = Guid.NewGuid().ToString(),
                DoneAt = DateTime.Now,
                eFormId = rnd.Next(0, 255),
                SiteId = rnd.Next(0, 255),
                UnitId = rnd.Next(0, 255),
                WorkerId = rnd.Next(0, 255),
                CaseTemplateId = caseTemplate.Id,
                FetchedByTablet = randomBool,
                FetchedByTabletAt = DateTime.Now,
                ReceiptRetrievedFromUser = randomBool,
                ReceiptRetrievedFromUserAt = DateTime.Now
            };

            #endregion


            //Act
            await @case.Create(DbContext);

            List<Case> dbCases = DbContext.Cases.AsNoTracking().ToList();
            List<CaseVersion> dbCaseVersions = DbContext.CaseVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbCases);
            Assert.NotNull(dbCaseVersions);

            Assert.AreEqual(1, dbCases.Count);
            Assert.AreEqual(1, dbCaseVersions.Count);

            Assert.AreEqual(@case.Status, dbCases[0].Status);
            Assert.AreEqual(@case.Type, dbCases[0].Type);
            Assert.AreEqual(@case.DoneAt.ToString(), dbCases[0].DoneAt.ToString());
            Assert.AreEqual(@case.eFormId, dbCases[0].eFormId);
            Assert.AreEqual(@case.SiteId, dbCases[0].SiteId);
            Assert.AreEqual(@case.UnitId, dbCases[0].UnitId);
            Assert.AreEqual(@case.WorkerId, dbCases[0].WorkerId);
            Assert.AreEqual(@case.CaseTemplateId, dbCases[0].CaseTemplateId);
            Assert.AreEqual(@case.FetchedByTablet, dbCases[0].FetchedByTablet);
            Assert.AreEqual(@case.FetchedByTabletAt.ToString(), dbCases[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(@case.ReceiptRetrievedFromUser, dbCases[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(@case.ReceiptRetrievedFromUserAt.ToString(), dbCases[0].ReceiptRetrievedFromUserAt.ToString());
        }

        [Test]
        public async Task Cases_Update_DoesUpdate()
        {
            #region Arrange
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
                DescriptionFolderId = rnd.Next(0, 255),
                RetractIfApproved = randomBool
            };

            await caseTemplate.Create(DbContext);

            Case @case = new Case
            {
                Status = rnd.Next(0, 255),
                Type = Guid.NewGuid().ToString(),
                DoneAt = DateTime.Now,
                eFormId = rnd.Next(0, 255),
                SiteId = rnd.Next(0, 255),
                UnitId = rnd.Next(0, 255),
                WorkerId = rnd.Next(0, 255),
                CaseTemplateId = caseTemplate.Id,
                FetchedByTablet = randomBool,
                FetchedByTabletAt = DateTime.Now,
                ReceiptRetrievedFromUser = randomBool,
                ReceiptRetrievedFromUserAt = DateTime.Now
            };
            await @case.Create(DbContext);
            #endregion

            //Act

            DateTime? oldUpdatedAt = @case.UpdatedAt;
            DateTime? oldDoneAt = @case.DoneAt;
            int? oldStatus = @case.Status;
            string oldType = @case.Type;
            int? oldeFormId = @case.eFormId;
            int? oldSiteId = @case.SiteId;
            int? oldUnitId = @case.UnitId;
            int? oldWorkerId = @case.WorkerId;
            bool oldFetchedByTablet = @case.FetchedByTablet;
            bool oldReceiptRetrievedFromUser = @case.ReceiptRetrievedFromUser;
            DateTime? oldFetchedByTabletAt = @case.FetchedByTabletAt;
            DateTime? oldReceiptRetrievedFromUserAt = @case.ReceiptRetrievedFromUserAt;


            @case.Status = rnd.Next(0, 255);
            @case.Type = Guid.NewGuid().ToString();
            @case.DoneAt = DateTime.Now;
            @case.eFormId = rnd.Next(0, 255);
            @case.SiteId = rnd.Next(0, 255);
            @case.UnitId = rnd.Next(0, 255);
            @case.WorkerId = rnd.Next(0, 255);
            @case.FetchedByTablet = randomBool;
            @case.FetchedByTabletAt = DateTime.Now.AddDays(1);
            @case.ReceiptRetrievedFromUser = randomBool;
            @case.ReceiptRetrievedFromUserAt = DateTime.Now.AddDays(1);

            await @case.Update(DbContext);

            List<Case> dbCases = DbContext.Cases.AsNoTracking().ToList();
            List<CaseVersion> dbCaseVersions = DbContext.CaseVersions.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(dbCases);
            Assert.NotNull(dbCaseVersions);

            Assert.AreEqual(1, dbCases.Count);
            Assert.AreEqual(2, dbCaseVersions.Count);

            Assert.AreEqual(@case.Status, dbCases[0].Status);
            Assert.AreEqual(@case.Type, dbCases[0].Type);
            Assert.AreEqual(@case.DoneAt.ToString(), dbCases[0].DoneAt.ToString());
            Assert.AreEqual(@case.eFormId, dbCases[0].eFormId);
            Assert.AreEqual(@case.SiteId, dbCases[0].SiteId);
            Assert.AreEqual(@case.UnitId, dbCases[0].UnitId);
            Assert.AreEqual(@case.WorkerId, dbCases[0].WorkerId);
            Assert.AreEqual(caseTemplate.Id, dbCases[0].CaseTemplateId);
            Assert.AreEqual(@case.FetchedByTablet, dbCases[0].FetchedByTablet);
            Assert.AreEqual(@case.FetchedByTabletAt.ToString(), dbCases[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(@case.ReceiptRetrievedFromUser, dbCases[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(@case.ReceiptRetrievedFromUserAt.ToString(), dbCases[0].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCases[0].WorkflowState);


            //Old version
            Assert.AreEqual(oldStatus, dbCaseVersions[0].Status);
            Assert.AreEqual(oldType, dbCaseVersions[0].Type);
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(@case.DoneAt.ToString(), dbCaseVersions[0].DoneAt.ToString());
            Assert.AreEqual(oldeFormId, dbCaseVersions[0].eFormId);
            Assert.AreEqual(oldSiteId, dbCaseVersions[0].SiteId);
            Assert.AreEqual(oldUnitId, dbCaseVersions[0].UnitId);
            Assert.AreEqual(oldWorkerId, dbCaseVersions[0].WorkerId);
            Assert.AreEqual(caseTemplate.Id, dbCaseVersions[0].CaseTemplateId);
            Assert.AreEqual(oldFetchedByTablet, dbCaseVersions[0].FetchedByTablet);
            Assert.AreEqual(oldFetchedByTabletAt.ToString(), dbCaseVersions[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(oldReceiptRetrievedFromUser, dbCaseVersions[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(oldReceiptRetrievedFromUserAt.ToString(), dbCaseVersions[0].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseVersions[0].WorkflowState);


            //New Version
            Assert.AreEqual(@case.Status, dbCaseVersions[1].Status);
            Assert.AreEqual(@case.Type, dbCaseVersions[1].Type);
            Assert.AreEqual(@case.UpdatedAt.ToString(), dbCaseVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(@case.DoneAt.ToString(), dbCaseVersions[1].DoneAt.ToString());
            Assert.AreEqual(@case.eFormId, dbCaseVersions[1].eFormId);
            Assert.AreEqual(@case.SiteId, dbCaseVersions[1].SiteId);
            Assert.AreEqual(@case.UnitId, dbCaseVersions[1].UnitId);
            Assert.AreEqual(@case.WorkerId, dbCaseVersions[1].WorkerId);
            Assert.AreEqual(caseTemplate.Id, dbCaseVersions[1].CaseTemplateId);
            Assert.AreEqual(@case.FetchedByTablet, dbCaseVersions[1].FetchedByTablet);
            Assert.AreEqual(@case.FetchedByTabletAt.ToString(), dbCaseVersions[1].FetchedByTabletAt.ToString());
            Assert.AreEqual(@case.ReceiptRetrievedFromUser, dbCaseVersions[1].ReceiptRetrievedFromUser);
            Assert.AreEqual(@case.ReceiptRetrievedFromUserAt.ToString(), dbCaseVersions[1].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseVersions[1].WorkflowState);
        }

        [Test]
        public async Task Cases_Delete_DoesSetWorkflowStateToRemoved()
        {
             #region Arrange
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
                DescriptionFolderId = rnd.Next(0, 255),
                RetractIfApproved = randomBool
            };

            await caseTemplate.Create(DbContext);

            Case @case = new Case
            {
                Status = rnd.Next(0, 255),
                Type = Guid.NewGuid().ToString(),
                DoneAt = DateTime.Now,
                eFormId = rnd.Next(0, 255),
                SiteId = rnd.Next(0, 255),
                UnitId = rnd.Next(0, 255),
                WorkerId = rnd.Next(0, 255),
                CaseTemplateId = caseTemplate.Id,
                FetchedByTablet = randomBool,
                FetchedByTabletAt = DateTime.Now,
                ReceiptRetrievedFromUser = randomBool,
                ReceiptRetrievedFromUserAt = DateTime.Now
            };
            await @case.Create(DbContext);
            #endregion

            //Act

            DateTime? oldUpdatedAt = @case.UpdatedAt;

            await @case.Delete(DbContext);

            List<Case> dbCases = DbContext.Cases.AsNoTracking().ToList();
            List<CaseVersion> dbCaseVersions = DbContext.CaseVersions.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(dbCases);
            Assert.NotNull(dbCaseVersions);

            Assert.AreEqual(1, dbCases.Count);
            Assert.AreEqual(2, dbCaseVersions.Count);

            Assert.AreEqual(@case.Status, dbCases[0].Status);
            Assert.AreEqual(@case.Type, dbCases[0].Type);
            Assert.AreEqual(@case.UpdatedAt.ToString(), dbCases[0].UpdatedAt.ToString());
            Assert.AreEqual(@case.DoneAt.ToString(), dbCases[0].DoneAt.ToString());
            Assert.AreEqual(@case.eFormId, dbCases[0].eFormId);
            Assert.AreEqual(@case.SiteId, dbCases[0].SiteId);
            Assert.AreEqual(@case.UnitId, dbCases[0].UnitId);
            Assert.AreEqual(@case.WorkerId, dbCases[0].WorkerId);
            Assert.AreEqual(caseTemplate.Id, dbCases[0].CaseTemplateId);
            Assert.AreEqual(@case.FetchedByTablet, dbCases[0].FetchedByTablet);
            Assert.AreEqual(@case.FetchedByTabletAt.ToString(), dbCases[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(@case.ReceiptRetrievedFromUser, dbCases[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(@case.ReceiptRetrievedFromUserAt.ToString(), dbCases[0].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCases[0].WorkflowState);


            //Old Version
            Assert.AreEqual(@case.Status, dbCaseVersions[0].Status);
            Assert.AreEqual(@case.Type, dbCaseVersions[0].Type);
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(@case.DoneAt.ToString(), dbCaseVersions[0].DoneAt.ToString());
            Assert.AreEqual(@case.eFormId, dbCaseVersions[0].eFormId);
            Assert.AreEqual(@case.SiteId, dbCaseVersions[0].SiteId);
            Assert.AreEqual(@case.UnitId, dbCaseVersions[0].UnitId);
            Assert.AreEqual(@case.WorkerId, dbCaseVersions[0].WorkerId);
            Assert.AreEqual(caseTemplate.Id, dbCaseVersions[0].CaseTemplateId);
            Assert.AreEqual(@case.FetchedByTablet, dbCaseVersions[0].FetchedByTablet);
            Assert.AreEqual(@case.FetchedByTabletAt.ToString(), dbCaseVersions[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(@case.ReceiptRetrievedFromUser, dbCaseVersions[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(@case.ReceiptRetrievedFromUserAt.ToString(), dbCaseVersions[0].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseVersions[0].WorkflowState);

            //New Version
            Assert.AreEqual(@case.Status, dbCaseVersions[1].Status);
            Assert.AreEqual(@case.Type, dbCaseVersions[1].Type);
            Assert.AreEqual(@case.UpdatedAt.ToString(), dbCaseVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(@case.DoneAt.ToString(), dbCaseVersions[1].DoneAt.ToString());
            Assert.AreEqual(@case.eFormId, dbCaseVersions[1].eFormId);
            Assert.AreEqual(@case.SiteId, dbCaseVersions[1].SiteId);
            Assert.AreEqual(@case.UnitId, dbCaseVersions[1].UnitId);
            Assert.AreEqual(@case.WorkerId, dbCaseVersions[1].WorkerId);
            Assert.AreEqual(caseTemplate.Id, dbCaseVersions[1].CaseTemplateId);
            Assert.AreEqual(@case.FetchedByTablet, dbCaseVersions[1].FetchedByTablet);
            Assert.AreEqual(@case.FetchedByTabletAt.ToString(), dbCaseVersions[1].FetchedByTabletAt.ToString());
            Assert.AreEqual(@case.ReceiptRetrievedFromUser, dbCaseVersions[1].ReceiptRetrievedFromUser);
            Assert.AreEqual(@case.ReceiptRetrievedFromUserAt.ToString(), dbCaseVersions[1].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseVersions[1].WorkflowState);
        }

    }
}