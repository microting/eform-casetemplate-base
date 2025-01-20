using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities;
using NUnit.Framework;
using Document = Microting.eFormCaseTemplateBase.Infrastructure.Data.Entities.Document;

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

            Document document = new Document
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                FolderId = rnd.Next(0, 255),
                RetractIfApproved = randomBool
            };

            await document.Create(DbContext);

            Case @case = new Case
            {
                Status = rnd.Next(0, 255),
                Type = Guid.NewGuid().ToString(),
                DoneAt = DateTime.Now,
                eFormId = rnd.Next(0, 255),
                SiteId = rnd.Next(0, 255),
                UnitId = rnd.Next(0, 255),
                WorkerId = rnd.Next(0, 255),
                CaseTemplateId = document.Id,
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
            Assert.That(dbCases, Is.Not.Null);
            Assert.That(dbCaseVersions, Is.Not.Null);

            Assert.That(dbCases.Count, Is.EqualTo(1));
            Assert.That(dbCaseVersions.Count, Is.EqualTo(1));

            Assert.That(dbCases[0].Status, Is.EqualTo(@case.Status));
            Assert.That(dbCases[0].Type, Is.EqualTo(@case.Type));
            Assert.That(dbCases[0].DoneAt.ToString(), Is.EqualTo(@case.DoneAt.ToString()));
            Assert.That(dbCases[0].eFormId, Is.EqualTo(@case.eFormId));
            Assert.That(dbCases[0].SiteId, Is.EqualTo(@case.SiteId));
            Assert.That(dbCases[0].UnitId, Is.EqualTo(@case.UnitId));
            Assert.That(dbCases[0].WorkerId, Is.EqualTo(@case.WorkerId));
            Assert.That(dbCases[0].CaseTemplateId, Is.EqualTo(@case.CaseTemplateId));
            Assert.That(dbCases[0].FetchedByTablet, Is.EqualTo(@case.FetchedByTablet));
            Assert.That(dbCases[0].FetchedByTabletAt.ToString(), Is.EqualTo(@case.FetchedByTabletAt.ToString()));
            Assert.That(dbCases[0].ReceiptRetrievedFromUser, Is.EqualTo(@case.ReceiptRetrievedFromUser));
            Assert.That(dbCases[0].ReceiptRetrievedFromUserAt.ToString(), Is.EqualTo(@case.ReceiptRetrievedFromUserAt.ToString()));
        }

        [Test]
        public async Task Cases_Update_DoesUpdate()
        {
            #region Arrange
            Random rnd = new Random();

            bool randomBool = rnd.Next(0, 2) > 0;

            Document document = new Document
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                FolderId = rnd.Next(0, 255),
                RetractIfApproved = randomBool
            };

            await document.Create(DbContext);

            Case @case = new Case
            {
                Status = rnd.Next(0, 255),
                Type = Guid.NewGuid().ToString(),
                DoneAt = DateTime.Now,
                eFormId = rnd.Next(0, 255),
                SiteId = rnd.Next(0, 255),
                UnitId = rnd.Next(0, 255),
                WorkerId = rnd.Next(0, 255),
                CaseTemplateId = document.Id,
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

            Assert.That(dbCases, Is.Not.Null);
            Assert.That(dbCaseVersions, Is.Not.Null);

            Assert.That(dbCases.Count, Is.EqualTo(1));
            Assert.That(dbCaseVersions.Count, Is.EqualTo(2));

            Assert.That(dbCases[0].Status, Is.EqualTo(@case.Status));
            Assert.That(dbCases[0].Type, Is.EqualTo(@case.Type));
            Assert.That(dbCases[0].DoneAt.ToString(), Is.EqualTo(@case.DoneAt.ToString()));
            Assert.That(dbCases[0].eFormId, Is.EqualTo(@case.eFormId));
            Assert.That(dbCases[0].SiteId, Is.EqualTo(@case.SiteId));
            Assert.That(dbCases[0].UnitId, Is.EqualTo(@case.UnitId));
            Assert.That(dbCases[0].WorkerId, Is.EqualTo(@case.WorkerId));
            Assert.That(dbCases[0].CaseTemplateId, Is.EqualTo(document.Id));
            Assert.That(dbCases[0].FetchedByTablet, Is.EqualTo(@case.FetchedByTablet));
            Assert.That(dbCases[0].FetchedByTabletAt.ToString(), Is.EqualTo(@case.FetchedByTabletAt.ToString()));
            Assert.That(dbCases[0].ReceiptRetrievedFromUser, Is.EqualTo(@case.ReceiptRetrievedFromUser));
            Assert.That(dbCases[0].ReceiptRetrievedFromUserAt.ToString(), Is.EqualTo(@case.ReceiptRetrievedFromUserAt.ToString()));
            Assert.That(dbCases[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));


            //Old version
            Assert.That(dbCaseVersions[0].Status, Is.EqualTo(oldStatus));
            Assert.That(dbCaseVersions[0].Type, Is.EqualTo(oldType));
            Assert.That(dbCaseVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseVersions[0].DoneAt.ToString(), Is.EqualTo(@case.DoneAt.ToString()));
            Assert.That(dbCaseVersions[0].eFormId, Is.EqualTo(oldeFormId));
            Assert.That(dbCaseVersions[0].SiteId, Is.EqualTo(oldSiteId));
            Assert.That(dbCaseVersions[0].UnitId, Is.EqualTo(oldUnitId));
            Assert.That(dbCaseVersions[0].WorkerId, Is.EqualTo(oldWorkerId));
            Assert.That(dbCaseVersions[0].CaseTemplateId, Is.EqualTo(document.Id));
            Assert.That(dbCaseVersions[0].FetchedByTablet, Is.EqualTo(oldFetchedByTablet));
            Assert.That(dbCaseVersions[0].FetchedByTabletAt.ToString(), Is.EqualTo(oldFetchedByTabletAt.ToString()));
            Assert.That(dbCaseVersions[0].ReceiptRetrievedFromUser, Is.EqualTo(oldReceiptRetrievedFromUser));
            Assert.That(dbCaseVersions[0].ReceiptRetrievedFromUserAt.ToString(), Is.EqualTo(oldReceiptRetrievedFromUserAt.ToString()));
            Assert.That(dbCaseVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));


            //New Version
            Assert.That(dbCaseVersions[1].Status, Is.EqualTo(@case.Status));
            Assert.That(dbCaseVersions[1].Type, Is.EqualTo(@case.Type));
            Assert.That(dbCaseVersions[1].UpdatedAt.ToString(), Is.EqualTo(@case.UpdatedAt.ToString()));
            Assert.That(dbCaseVersions[1].DoneAt.ToString(), Is.EqualTo(@case.DoneAt.ToString()));
            Assert.That(dbCaseVersions[1].eFormId, Is.EqualTo(@case.eFormId));
            Assert.That(dbCaseVersions[1].SiteId, Is.EqualTo(@case.SiteId));
            Assert.That(dbCaseVersions[1].UnitId, Is.EqualTo(@case.UnitId));
            Assert.That(dbCaseVersions[1].WorkerId, Is.EqualTo(@case.WorkerId));
            Assert.That(dbCaseVersions[1].CaseTemplateId, Is.EqualTo(document.Id));
            Assert.That(dbCaseVersions[1].FetchedByTablet, Is.EqualTo(@case.FetchedByTablet));
            Assert.That(dbCaseVersions[1].FetchedByTabletAt.ToString(), Is.EqualTo(@case.FetchedByTabletAt.ToString()));
            Assert.That(dbCaseVersions[1].ReceiptRetrievedFromUser, Is.EqualTo(@case.ReceiptRetrievedFromUser));
            Assert.That(dbCaseVersions[1].ReceiptRetrievedFromUserAt.ToString(), Is.EqualTo(@case.ReceiptRetrievedFromUserAt.ToString()));
            Assert.That(dbCaseVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
        }

        [Test]
        public async Task Cases_Delete_DoesSetWorkflowStateToRemoved()
        {
             #region Arrange
            Random rnd = new Random();

            bool randomBool = rnd.Next(0, 2) > 0;

            Document document = new Document
            {
                Approvable = randomBool,
                // caseTemplate.Title = Guid.NewGuid().ToString();
                // caseTemplate.Body = Guid.NewGuid().ToString();
                AlwaysShow = randomBool,
                EndAt = DateTime.Now,
                // caseTemplate.PdfTitle = Guid.NewGuid().ToString();
                StartAt = DateTime.Now,
                FolderId = rnd.Next(0, 255),
                RetractIfApproved = randomBool
            };

            await document.Create(DbContext);

            Case @case = new Case
            {
                Status = rnd.Next(0, 255),
                Type = Guid.NewGuid().ToString(),
                DoneAt = DateTime.Now,
                eFormId = rnd.Next(0, 255),
                SiteId = rnd.Next(0, 255),
                UnitId = rnd.Next(0, 255),
                WorkerId = rnd.Next(0, 255),
                CaseTemplateId = document.Id,
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

            Assert.That(dbCases, Is.Not.Null);
            Assert.That(dbCaseVersions, Is.Not.Null);

            Assert.That(dbCases.Count, Is.EqualTo(1));
            Assert.That(dbCaseVersions.Count, Is.EqualTo(2));

            Assert.That(dbCases[0].Status, Is.EqualTo(@case.Status));
            Assert.That(dbCases[0].Type, Is.EqualTo(@case.Type));
            Assert.That(dbCases[0].UpdatedAt.ToString(), Is.EqualTo(@case.UpdatedAt.ToString()));
            Assert.That(dbCases[0].DoneAt.ToString(), Is.EqualTo(@case.DoneAt.ToString()));
            Assert.That(dbCases[0].eFormId, Is.EqualTo(@case.eFormId));
            Assert.That(dbCases[0].SiteId, Is.EqualTo(@case.SiteId));
            Assert.That(dbCases[0].UnitId, Is.EqualTo(@case.UnitId));
            Assert.That(dbCases[0].WorkerId, Is.EqualTo(@case.WorkerId));
            Assert.That(dbCases[0].CaseTemplateId, Is.EqualTo(document.Id));
            Assert.That(dbCases[0].FetchedByTablet, Is.EqualTo(@case.FetchedByTablet));
            Assert.That(dbCases[0].FetchedByTabletAt.ToString(), Is.EqualTo(@case.FetchedByTabletAt.ToString()));
            Assert.That(dbCases[0].ReceiptRetrievedFromUser, Is.EqualTo(@case.ReceiptRetrievedFromUser));
            Assert.That(dbCases[0].ReceiptRetrievedFromUserAt.ToString(), Is.EqualTo(@case.ReceiptRetrievedFromUserAt.ToString()));
            Assert.That(dbCases[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));


            //Old Version
            Assert.That(dbCaseVersions[0].Status, Is.EqualTo(@case.Status));
            Assert.That(dbCaseVersions[0].Type, Is.EqualTo(@case.Type));
            Assert.That(dbCaseVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbCaseVersions[0].DoneAt.ToString(), Is.EqualTo(@case.DoneAt.ToString()));
            Assert.That(dbCaseVersions[0].eFormId, Is.EqualTo(@case.eFormId));
            Assert.That(dbCaseVersions[0].SiteId, Is.EqualTo(@case.SiteId));
            Assert.That(dbCaseVersions[0].UnitId, Is.EqualTo(@case.UnitId));
            Assert.That(dbCaseVersions[0].WorkerId, Is.EqualTo(@case.WorkerId));
            Assert.That(dbCaseVersions[0].CaseTemplateId, Is.EqualTo(document.Id));
            Assert.That(dbCaseVersions[0].FetchedByTablet, Is.EqualTo(@case.FetchedByTablet));
            Assert.That(dbCaseVersions[0].FetchedByTabletAt.ToString(), Is.EqualTo(@case.FetchedByTabletAt.ToString()));
            Assert.That(dbCaseVersions[0].ReceiptRetrievedFromUser, Is.EqualTo(@case.ReceiptRetrievedFromUser));
            Assert.That(dbCaseVersions[0].ReceiptRetrievedFromUserAt.ToString(), Is.EqualTo(@case.ReceiptRetrievedFromUserAt.ToString()));
            Assert.That(dbCaseVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));

            //New Version
            Assert.That(dbCaseVersions[1].Status, Is.EqualTo(@case.Status));
            Assert.That(dbCaseVersions[1].Type, Is.EqualTo(@case.Type));
            Assert.That(dbCaseVersions[1].UpdatedAt.ToString(), Is.EqualTo(@case.UpdatedAt.ToString()));
            Assert.That(dbCaseVersions[1].DoneAt.ToString(), Is.EqualTo(@case.DoneAt.ToString()));
            Assert.That(dbCaseVersions[1].eFormId, Is.EqualTo(@case.eFormId));
            Assert.That(dbCaseVersions[1].SiteId, Is.EqualTo(@case.SiteId));
            Assert.That(dbCaseVersions[1].UnitId, Is.EqualTo(@case.UnitId));
            Assert.That(dbCaseVersions[1].WorkerId, Is.EqualTo(@case.WorkerId));
            Assert.That(dbCaseVersions[1].CaseTemplateId, Is.EqualTo(document.Id));
            Assert.That(dbCaseVersions[1].FetchedByTablet, Is.EqualTo(@case.FetchedByTablet));
            Assert.That(dbCaseVersions[1].FetchedByTabletAt.ToString(), Is.EqualTo(@case.FetchedByTabletAt.ToString()));
            Assert.That(dbCaseVersions[1].ReceiptRetrievedFromUser, Is.EqualTo(@case.ReceiptRetrievedFromUser));
            Assert.That(dbCaseVersions[1].ReceiptRetrievedFromUserAt.ToString(), Is.EqualTo(@case.ReceiptRetrievedFromUserAt.ToString()));
            Assert.That(dbCaseVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        }

    }
}