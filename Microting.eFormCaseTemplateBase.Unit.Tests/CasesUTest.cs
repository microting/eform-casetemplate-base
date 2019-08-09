using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            Assert.AreEqual(cases.CaseTemplateId, dbCases[0].CaseTemplateId);
            Assert.AreEqual(cases.FetchedByTablet, dbCases[0].FetchedByTablet);
            Assert.AreEqual(cases.FetchedByTabletAt.ToString(), dbCases[0].FetchedByTabletAt.ToString());
            Assert.AreEqual(cases.ReceiptRetrievedFromUser, dbCases[0].ReceiptRetrievedFromUser);
            Assert.AreEqual(cases.ReceiptRetrievedFromUserAt.ToString(), dbCases[0].ReceiptRetrievedFromUserAt.ToString());

        }
        
    }
}