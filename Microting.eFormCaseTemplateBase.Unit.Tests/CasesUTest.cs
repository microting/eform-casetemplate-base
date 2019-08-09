using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public void Cases_Create_DoesCreate()
        {
            #region Arrange
            Random rnd = new Random();
            
            bool randomBool = rnd.Next(0, 2) > 0;
            
            CaseTemplates caseTemplates = new CaseTemplates();
            caseTemplates.Approvable = randomBool;
            caseTemplates.Body = Guid.NewGuid().ToString();
            caseTemplates.Title = Guid.NewGuid().ToString();
            caseTemplates.AlwaysShow = randomBool;
            caseTemplates.EndAt = DateTime.Now;
            caseTemplates.PdfTitle = Guid.NewGuid().ToString();
            caseTemplates.StartAt = DateTime.Now;
            caseTemplates.DescriptionFolderId = rnd.Next(0, 255);
            caseTemplates.RetractIfApproved = randomBool;

            caseTemplates.Create(DbContext);
            
            Cases cases = new Cases();
            cases.Status = rnd.Next(0, 255);
            cases.Type = Guid.NewGuid().ToString();
            cases.DoneAt = DateTime.Now;
            cases.eFormId = rnd.Next(0, 255);
            cases.SiteId = rnd.Next(0, 255);
            cases.UnitId = rnd.Next(0, 255);
            cases.WorkerId = rnd.Next(0, 255);
            cases.CaseTemplateId = caseTemplates.Id;
            cases.FetchedByTablet = randomBool;
            cases.FetchedByTabletAt = DateTime.Now;
            cases.ReceiptRetrievedFromUser = randomBool;
            cases.ReceiptRetrievedFromUserAt = DateTime.Now;

            #endregion
           
            
            //Act
            cases.Create(DbContext);

            List<Cases> dbCases = DbContext.Cases.AsNoTracking().ToList();
            List<CaseVersions> dbCaseVersions = DbContext.CaseVersionses.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbCases);
            Assert.NotNull(dbCaseVersions);
            
            Assert.AreEqual(1, dbCases.Count);
            Assert.AreEqual(1, dbCaseVersions.Count);
            
            Assert.AreEqual(cases.Status, dbCases[0].Status);
            Assert.AreEqual(cases.Type, dbCases[0].Type);
            Assert.AreEqual(cases.DoneAt.ToString(), dbCases[0].DoneAt.ToString());
            Assert.AreEqual(cases.eFormId, dbCases[0].eFormId);
            Assert.AreEqual(cases.SiteId, dbCases[0].SiteId);
            Assert.AreEqual(cases.UnitId, dbCases[0].UnitId);
            Assert.AreEqual(cases.WorkerId, dbCases[0].WorkerId);
            Assert.AreEqual(cases.CaseTemplateId, dbCases[0].CaseTemplateId);
            Assert.AreEqual(cases.FetchedByTablet, dbCases[0].FetchedByTablet);
            Assert.AreEqual(cases.FetchedByTabletAt.ToString(), dbCases[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(cases.ReceiptRetrievedFromUser, dbCases[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(cases.ReceiptRetrievedFromUserAt.ToString(), dbCases[0].ReceiptRetrievedFromUserAt.ToString());
        }

        [Test]
        public void Cases_Update_DoesUpdate()
        {
            #region Arrange
            Random rnd = new Random();
            
            bool randomBool = rnd.Next(0, 2) > 0;
            
            CaseTemplates caseTemplates = new CaseTemplates();
            caseTemplates.Approvable = randomBool;
            caseTemplates.Body = Guid.NewGuid().ToString();
            caseTemplates.Title = Guid.NewGuid().ToString();
            caseTemplates.AlwaysShow = randomBool;
            caseTemplates.EndAt = DateTime.Now;
            caseTemplates.PdfTitle = Guid.NewGuid().ToString();
            caseTemplates.StartAt = DateTime.Now;
            caseTemplates.DescriptionFolderId = rnd.Next(0, 255);
            caseTemplates.RetractIfApproved = randomBool;

            caseTemplates.Create(DbContext);
            
            Cases cases = new Cases();
            cases.Status = rnd.Next(0, 255);
            cases.Type = Guid.NewGuid().ToString();
            cases.DoneAt = DateTime.Now;
            cases.eFormId = rnd.Next(0, 255);
            cases.SiteId = rnd.Next(0, 255);
            cases.UnitId = rnd.Next(0, 255);
            cases.WorkerId = rnd.Next(0, 255);
            cases.CaseTemplateId = caseTemplates.Id;
            cases.FetchedByTablet = randomBool;
            cases.FetchedByTabletAt = DateTime.Now;
            cases.ReceiptRetrievedFromUser = randomBool;
            cases.ReceiptRetrievedFromUserAt = DateTime.Now;
            cases.Create(DbContext);
            #endregion
            
            //Act

            DateTime? oldUpdatedAt = cases.UpdatedAt;
            DateTime? oldDoneAt = cases.DoneAt;
            int? oldStatus = cases.Status;
            string oldType = cases.Type;
            int? oldeFormId = cases.eFormId;
            int? oldSiteId = cases.SiteId;
            int? oldUnitId = cases.UnitId;
            int? oldWorkerId = cases.WorkerId;
            bool oldFetchedByTablet = cases.FetchedByTablet;
            bool oldReceiptRetrievedFromUser = cases.ReceiptRetrievedFromUser;
            DateTime? oldFetchedByTabletAt = cases.FetchedByTabletAt;
            DateTime? oldReceiptRetrievedFromUserAt = cases.ReceiptRetrievedFromUserAt;
            
            
            cases.Status = rnd.Next(0, 255);
            cases.Type = Guid.NewGuid().ToString();
            cases.DoneAt = DateTime.Now;
            cases.eFormId = rnd.Next(0, 255);
            cases.SiteId = rnd.Next(0, 255);
            cases.UnitId = rnd.Next(0, 255);
            cases.WorkerId = rnd.Next(0, 255);
            cases.FetchedByTablet = randomBool;
            cases.FetchedByTabletAt = DateTime.Now.AddDays(1);
            cases.ReceiptRetrievedFromUser = randomBool;
            cases.ReceiptRetrievedFromUserAt = DateTime.Now.AddDays(1);
            
            cases.Update(DbContext);
            
            List<Cases> dbCases = DbContext.Cases.AsNoTracking().ToList();
            List<CaseVersions> dbCaseVersions = DbContext.CaseVersionses.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbCases);
            Assert.NotNull(dbCaseVersions);
            
            Assert.AreEqual(1, dbCases.Count);
            Assert.AreEqual(2, dbCaseVersions.Count);

            Assert.AreEqual(cases.Status, dbCases[0].Status);
            Assert.AreEqual(cases.Type, dbCases[0].Type);
            Assert.AreEqual(cases.DoneAt.ToString(), dbCases[0].DoneAt.ToString());
            Assert.AreEqual(cases.eFormId, dbCases[0].eFormId);
            Assert.AreEqual(cases.SiteId, dbCases[0].SiteId);
            Assert.AreEqual(cases.UnitId, dbCases[0].UnitId);
            Assert.AreEqual(cases.WorkerId, dbCases[0].WorkerId);
            Assert.AreEqual(caseTemplates.Id, dbCases[0].CaseTemplateId);
            Assert.AreEqual(cases.FetchedByTablet, dbCases[0].FetchedByTablet);
            Assert.AreEqual(cases.FetchedByTabletAt.ToString(), dbCases[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(cases.ReceiptRetrievedFromUser, dbCases[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(cases.ReceiptRetrievedFromUserAt.ToString(), dbCases[0].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCases[0].WorkflowState);

            
            //Old version
            Assert.AreEqual(oldStatus, dbCaseVersions[0].Status);
            Assert.AreEqual(oldType, dbCaseVersions[0].Type);
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(cases.DoneAt.ToString(), dbCaseVersions[0].DoneAt.ToString());
            Assert.AreEqual(oldeFormId, dbCaseVersions[0].eFormId);
            Assert.AreEqual(oldSiteId, dbCaseVersions[0].SiteId);
            Assert.AreEqual(oldUnitId, dbCaseVersions[0].UnitId);
            Assert.AreEqual(oldWorkerId, dbCaseVersions[0].WorkerId);
            Assert.AreEqual(caseTemplates.Id, dbCaseVersions[0].CaseTemplateId);
            Assert.AreEqual(oldFetchedByTablet, dbCaseVersions[0].FetchedByTablet);
            Assert.AreEqual(oldFetchedByTabletAt.ToString(), dbCaseVersions[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(oldReceiptRetrievedFromUser, dbCaseVersions[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(oldReceiptRetrievedFromUserAt.ToString(), dbCaseVersions[0].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseVersions[0].WorkflowState);

            
            //New Version
            Assert.AreEqual(cases.Status, dbCaseVersions[1].Status);
            Assert.AreEqual(cases.Type, dbCaseVersions[1].Type);
            Assert.AreEqual(cases.UpdatedAt.ToString(), dbCaseVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(cases.DoneAt.ToString(), dbCaseVersions[1].DoneAt.ToString());
            Assert.AreEqual(cases.eFormId, dbCaseVersions[1].eFormId);
            Assert.AreEqual(cases.SiteId, dbCaseVersions[1].SiteId);
            Assert.AreEqual(cases.UnitId, dbCaseVersions[1].UnitId);
            Assert.AreEqual(cases.WorkerId, dbCaseVersions[1].WorkerId);
            Assert.AreEqual(caseTemplates.Id, dbCaseVersions[1].CaseTemplateId);
            Assert.AreEqual(cases.FetchedByTablet, dbCaseVersions[1].FetchedByTablet);
            Assert.AreEqual(cases.FetchedByTabletAt.ToString(), dbCaseVersions[1].FetchedByTabletAt.ToString());
            Assert.AreEqual(cases.ReceiptRetrievedFromUser, dbCaseVersions[1].ReceiptRetrievedFromUser);
            Assert.AreEqual(cases.ReceiptRetrievedFromUserAt.ToString(), dbCaseVersions[1].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseVersions[1].WorkflowState);
        }

        [Test]
        public void Cases_Delete_DoesSetWorkflowStateToRemoved()
        {
             #region Arrange
            Random rnd = new Random();
            
            bool randomBool = rnd.Next(0, 2) > 0;
            
            CaseTemplates caseTemplates = new CaseTemplates();
            caseTemplates.Approvable = randomBool;
            caseTemplates.Body = Guid.NewGuid().ToString();
            caseTemplates.Title = Guid.NewGuid().ToString();
            caseTemplates.AlwaysShow = randomBool;
            caseTemplates.EndAt = DateTime.Now;
            caseTemplates.PdfTitle = Guid.NewGuid().ToString();
            caseTemplates.StartAt = DateTime.Now;
            caseTemplates.DescriptionFolderId = rnd.Next(0, 255);
            caseTemplates.RetractIfApproved = randomBool;

            caseTemplates.Create(DbContext);
            
            Cases cases = new Cases();
            cases.Status = rnd.Next(0, 255);
            cases.Type = Guid.NewGuid().ToString();
            cases.DoneAt = DateTime.Now;
            cases.eFormId = rnd.Next(0, 255);
            cases.SiteId = rnd.Next(0, 255);
            cases.UnitId = rnd.Next(0, 255);
            cases.WorkerId = rnd.Next(0, 255);
            cases.CaseTemplateId = caseTemplates.Id;
            cases.FetchedByTablet = randomBool;
            cases.FetchedByTabletAt = DateTime.Now;
            cases.ReceiptRetrievedFromUser = randomBool;
            cases.ReceiptRetrievedFromUserAt = DateTime.Now;
            cases.Create(DbContext);
            #endregion
            
            //Act

            DateTime? oldUpdatedAt = cases.UpdatedAt;

            cases.Delete(DbContext);
            
            List<Cases> dbCases = DbContext.Cases.AsNoTracking().ToList();
            List<CaseVersions> dbCaseVersions = DbContext.CaseVersionses.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbCases);
            Assert.NotNull(dbCaseVersions);
            
            Assert.AreEqual(1, dbCases.Count);
            Assert.AreEqual(2, dbCaseVersions.Count);

            Assert.AreEqual(cases.Status, dbCases[0].Status);
            Assert.AreEqual(cases.Type, dbCases[0].Type);
            Assert.AreEqual(cases.UpdatedAt.ToString(), dbCases[0].UpdatedAt.ToString());
            Assert.AreEqual(cases.DoneAt.ToString(), dbCases[0].DoneAt.ToString());
            Assert.AreEqual(cases.eFormId, dbCases[0].eFormId);
            Assert.AreEqual(cases.SiteId, dbCases[0].SiteId);
            Assert.AreEqual(cases.UnitId, dbCases[0].UnitId);
            Assert.AreEqual(cases.WorkerId, dbCases[0].WorkerId);
            Assert.AreEqual(caseTemplates.Id, dbCases[0].CaseTemplateId);
            Assert.AreEqual(cases.FetchedByTablet, dbCases[0].FetchedByTablet);
            Assert.AreEqual(cases.FetchedByTabletAt.ToString(), dbCases[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(cases.ReceiptRetrievedFromUser, dbCases[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(cases.ReceiptRetrievedFromUserAt.ToString(), dbCases[0].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCases[0].WorkflowState);
            
            
            //Old Version
            Assert.AreEqual(cases.Status, dbCaseVersions[0].Status);
            Assert.AreEqual(cases.Type, dbCaseVersions[0].Type);
            Assert.AreEqual(oldUpdatedAt.ToString(), dbCaseVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(cases.DoneAt.ToString(), dbCaseVersions[0].DoneAt.ToString());
            Assert.AreEqual(cases.eFormId, dbCaseVersions[0].eFormId);
            Assert.AreEqual(cases.SiteId, dbCaseVersions[0].SiteId);
            Assert.AreEqual(cases.UnitId, dbCaseVersions[0].UnitId);
            Assert.AreEqual(cases.WorkerId, dbCaseVersions[0].WorkerId);
            Assert.AreEqual(caseTemplates.Id, dbCaseVersions[0].CaseTemplateId);
            Assert.AreEqual(cases.FetchedByTablet, dbCaseVersions[0].FetchedByTablet);
            Assert.AreEqual(cases.FetchedByTabletAt.ToString(), dbCaseVersions[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(cases.ReceiptRetrievedFromUser, dbCaseVersions[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(cases.ReceiptRetrievedFromUserAt.ToString(), dbCaseVersions[0].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Created, dbCaseVersions[0].WorkflowState);
            
            //New Version
            Assert.AreEqual(cases.Status, dbCaseVersions[1].Status);
            Assert.AreEqual(cases.Type, dbCaseVersions[1].Type);
            Assert.AreEqual(cases.UpdatedAt.ToString(), dbCaseVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(cases.DoneAt.ToString(), dbCaseVersions[1].DoneAt.ToString());
            Assert.AreEqual(cases.eFormId, dbCaseVersions[1].eFormId);
            Assert.AreEqual(cases.SiteId, dbCaseVersions[1].SiteId);
            Assert.AreEqual(cases.UnitId, dbCaseVersions[1].UnitId);
            Assert.AreEqual(cases.WorkerId, dbCaseVersions[1].WorkerId);
            Assert.AreEqual(caseTemplates.Id, dbCaseVersions[1].CaseTemplateId);
            Assert.AreEqual(cases.FetchedByTablet, dbCaseVersions[1].FetchedByTablet);
            Assert.AreEqual(cases.FetchedByTabletAt.ToString(), dbCaseVersions[1].FetchedByTabletAt.ToString());
            Assert.AreEqual(cases.ReceiptRetrievedFromUser, dbCaseVersions[1].ReceiptRetrievedFromUser);
            Assert.AreEqual(cases.ReceiptRetrievedFromUserAt.ToString(), dbCaseVersions[1].ReceiptRetrievedFromUserAt.ToString());
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbCaseVersions[1].WorkflowState);
        }
        
    }
}