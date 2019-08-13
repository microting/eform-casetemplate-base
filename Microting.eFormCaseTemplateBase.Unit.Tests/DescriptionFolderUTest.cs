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
    public class DescriptionFolderUTest : DbTestFixture
    {
        [Test]
        public void DescriptionFolder_Create_DoesCreate()
        {
            //Arrange
            
            Random rnd = new Random();
            
            DescriptionFolder parentDescriptionFolder = new DescriptionFolder();
            parentDescriptionFolder.Name = Guid.NewGuid().ToString();
            parentDescriptionFolder.SdkFolderId = rnd.Next(1, 255);
            parentDescriptionFolder.Create(DbContext);
            
            DescriptionFolder descriptionFolder = new DescriptionFolder();
            descriptionFolder.Name = Guid.NewGuid().ToString();
            descriptionFolder.SdkFolderId = rnd.Next(1, 255);
            descriptionFolder.ParentId = parentDescriptionFolder.Id;
            
            //Act
            
            descriptionFolder.Create(DbContext);
            
            List<DescriptionFolder> dbDescriptionFolders = DbContext.DescriptionFolders.AsNoTracking().ToList();
            List<DescriptionFolderVersion> dbDescriptionFolderVersions = DbContext.DescriptionFolderVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbDescriptionFolders);
            Assert.NotNull(dbDescriptionFolderVersions);
            
            Assert.AreEqual(2, dbDescriptionFolders.Count);
            Assert.AreEqual(2, dbDescriptionFolderVersions.Count);
            
            
            Assert.AreEqual(descriptionFolder.Id, dbDescriptionFolders[1].Id);
            Assert.AreEqual(descriptionFolder.Version, dbDescriptionFolders[1].Version);
            Assert.AreEqual(descriptionFolder.CreatedAt.ToString(), dbDescriptionFolders[1].CreatedAt.ToString());
            Assert.AreEqual(descriptionFolder.UpdatedAt.ToString(), dbDescriptionFolders[1].UpdatedAt.ToString());
            Assert.AreEqual(descriptionFolder.CreatedByUserId, dbDescriptionFolders[1].CreatedByUserId);
            Assert.AreEqual(descriptionFolder.UpdatedByUserId, dbDescriptionFolders[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolders[1].WorkflowState);
            Assert.AreEqual(descriptionFolder.Name, dbDescriptionFolders[1].Name);
            Assert.AreEqual(parentDescriptionFolder.Id, dbDescriptionFolders[1].ParentId);
            Assert.AreEqual(descriptionFolder.SdkFolderId, dbDescriptionFolders[1].SdkFolderId);

            //Versions
            Assert.AreEqual(descriptionFolder.Id, dbDescriptionFolderVersions[1].Id);
            Assert.AreEqual(1, dbDescriptionFolderVersions[1].Version);
            Assert.AreEqual(descriptionFolder.CreatedAt.ToString(), dbDescriptionFolderVersions[1].CreatedAt.ToString());
            Assert.AreEqual(descriptionFolder.UpdatedAt.ToString(), dbDescriptionFolderVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(descriptionFolder.CreatedByUserId, dbDescriptionFolderVersions[1].CreatedByUserId);
            Assert.AreEqual(descriptionFolder.UpdatedByUserId, dbDescriptionFolderVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolderVersions[1].WorkflowState);
            Assert.AreEqual(descriptionFolder.Name, dbDescriptionFolderVersions[1].Name);
            Assert.AreEqual(parentDescriptionFolder.Id, dbDescriptionFolderVersions[1].ParentId);
            Assert.AreEqual(descriptionFolder.SdkFolderId, dbDescriptionFolderVersions[1].SdkFolderId);
        }

        [Test]
        public void DescriptionFolder_Update_DoesUpdate()
        {
             //Arrange
            
            Random rnd = new Random();
            
            DescriptionFolder parentDescriptionFolder = new DescriptionFolder();
            parentDescriptionFolder.Name = Guid.NewGuid().ToString();
            parentDescriptionFolder.SdkFolderId = rnd.Next(1, 255);
            parentDescriptionFolder.Create(DbContext);
            
            DescriptionFolder descriptionFolder = new DescriptionFolder();
            descriptionFolder.Name = Guid.NewGuid().ToString();
            descriptionFolder.SdkFolderId = rnd.Next(1, 255);
            descriptionFolder.ParentId = parentDescriptionFolder.Id;
            descriptionFolder.Create(DbContext);

            
            //Act

            DateTime? oldUpdatedAt = descriptionFolder.UpdatedAt;
            string oldName = descriptionFolder.Name;
            int oldSdkFolderId = descriptionFolder.SdkFolderId;
            
            descriptionFolder.Name = Guid.NewGuid().ToString();
            descriptionFolder.SdkFolderId = rnd.Next(1, 255);

            descriptionFolder.Update(DbContext);
            
            List<DescriptionFolder> dbDescriptionFolders = DbContext.DescriptionFolders.AsNoTracking().ToList();
            List<DescriptionFolderVersion> dbDescriptionFolderVersions = DbContext.DescriptionFolderVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbDescriptionFolders);
            Assert.NotNull(dbDescriptionFolderVersions);
            
            Assert.AreEqual(2, dbDescriptionFolders.Count);
            Assert.AreEqual(3, dbDescriptionFolderVersions.Count);
            
            
            Assert.AreEqual(descriptionFolder.Id, dbDescriptionFolders[1].Id);
            Assert.AreEqual(descriptionFolder.Version, dbDescriptionFolders[1].Version);
            Assert.AreEqual(descriptionFolder.CreatedAt.ToString(), dbDescriptionFolders[1].CreatedAt.ToString());
            Assert.AreEqual(descriptionFolder.UpdatedAt.ToString(), dbDescriptionFolders[1].UpdatedAt.ToString());
            Assert.AreEqual(descriptionFolder.CreatedByUserId, dbDescriptionFolders[1].CreatedByUserId);
            Assert.AreEqual(descriptionFolder.UpdatedByUserId, dbDescriptionFolders[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolders[1].WorkflowState);
            Assert.AreEqual(descriptionFolder.Name, dbDescriptionFolders[1].Name);
            Assert.AreEqual(parentDescriptionFolder.Id, dbDescriptionFolders[1].ParentId);
            Assert.AreEqual(descriptionFolder.SdkFolderId, dbDescriptionFolders[1].SdkFolderId);

            //Old Version
            Assert.AreEqual(descriptionFolder.Id, dbDescriptionFolderVersions[1].DescriptionFolderId);
            Assert.AreEqual(1, dbDescriptionFolderVersions[1].Version);
            Assert.AreEqual(descriptionFolder.CreatedAt.ToString(), dbDescriptionFolderVersions[1].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbDescriptionFolderVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(descriptionFolder.CreatedByUserId, dbDescriptionFolderVersions[1].CreatedByUserId);
            Assert.AreEqual(descriptionFolder.UpdatedByUserId, dbDescriptionFolderVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolderVersions[1].WorkflowState);
            Assert.AreEqual(oldName, dbDescriptionFolderVersions[1].Name);
            Assert.AreEqual(parentDescriptionFolder.Id, dbDescriptionFolderVersions[1].ParentId);
            Assert.AreEqual(oldSdkFolderId, dbDescriptionFolderVersions[1].SdkFolderId);
            
            //New Version
            Assert.AreEqual(descriptionFolder.Id, dbDescriptionFolderVersions[2].DescriptionFolderId);
            Assert.AreEqual(2, dbDescriptionFolderVersions[2].Version);
            Assert.AreEqual(descriptionFolder.CreatedAt.ToString(), dbDescriptionFolderVersions[2].CreatedAt.ToString());
            Assert.AreEqual(descriptionFolder.UpdatedAt.ToString(), dbDescriptionFolderVersions[2].UpdatedAt.ToString());
            Assert.AreEqual(descriptionFolder.CreatedByUserId, dbDescriptionFolderVersions[2].CreatedByUserId);
            Assert.AreEqual(descriptionFolder.UpdatedByUserId, dbDescriptionFolderVersions[2].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolderVersions[2].WorkflowState);
            Assert.AreEqual(descriptionFolder.Name, dbDescriptionFolderVersions[2].Name);
            Assert.AreEqual(parentDescriptionFolder.Id, dbDescriptionFolderVersions[2].ParentId);
            Assert.AreEqual(descriptionFolder.SdkFolderId, dbDescriptionFolderVersions[2].SdkFolderId);
        }

        [Test]
        public void DescriptionFolder_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange
            
            Random rnd = new Random();
            
            DescriptionFolder parentDescriptionFolder = new DescriptionFolder();
            parentDescriptionFolder.Name = Guid.NewGuid().ToString();
            parentDescriptionFolder.SdkFolderId = rnd.Next(1, 255);
            parentDescriptionFolder.Create(DbContext);
            
            DescriptionFolder descriptionFolder = new DescriptionFolder();
            descriptionFolder.Name = Guid.NewGuid().ToString();
            descriptionFolder.SdkFolderId = rnd.Next(1, 255);
            descriptionFolder.ParentId = parentDescriptionFolder.Id;
            descriptionFolder.Create(DbContext);

            
            //Act

            DateTime? oldUpdatedAt = descriptionFolder.UpdatedAt;
            
            descriptionFolder.Delete(DbContext);
            
            List<DescriptionFolder> dbDescriptionFolders = DbContext.DescriptionFolders.AsNoTracking().ToList();
            List<DescriptionFolderVersion> dbDescriptionFolderVersions = DbContext.DescriptionFolderVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbDescriptionFolders);
            Assert.NotNull(dbDescriptionFolderVersions);
            
            Assert.AreEqual(2, dbDescriptionFolders.Count);
            Assert.AreEqual(3, dbDescriptionFolderVersions.Count);
            
            
            Assert.AreEqual(descriptionFolder.Id, dbDescriptionFolders[1].Id);
            Assert.AreEqual(descriptionFolder.Version, dbDescriptionFolders[1].Version);
            Assert.AreEqual(descriptionFolder.CreatedAt.ToString(), dbDescriptionFolders[1].CreatedAt.ToString());
            Assert.AreEqual(descriptionFolder.UpdatedAt.ToString(), dbDescriptionFolders[1].UpdatedAt.ToString());
            Assert.AreEqual(descriptionFolder.CreatedByUserId, dbDescriptionFolders[1].CreatedByUserId);
            Assert.AreEqual(descriptionFolder.UpdatedByUserId, dbDescriptionFolders[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbDescriptionFolders[1].WorkflowState);
            Assert.AreEqual(descriptionFolder.Name, dbDescriptionFolders[1].Name);
            Assert.AreEqual(parentDescriptionFolder.Id, dbDescriptionFolders[1].ParentId);
            Assert.AreEqual(descriptionFolder.SdkFolderId, dbDescriptionFolders[1].SdkFolderId);

            //Old Version
            Assert.AreEqual(descriptionFolder.Id, dbDescriptionFolderVersions[1].DescriptionFolderId);
            Assert.AreEqual(1, dbDescriptionFolderVersions[1].Version);
            Assert.AreEqual(descriptionFolder.CreatedAt.ToString(), dbDescriptionFolderVersions[1].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbDescriptionFolderVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(descriptionFolder.CreatedByUserId, dbDescriptionFolderVersions[1].CreatedByUserId);
            Assert.AreEqual(descriptionFolder.UpdatedByUserId, dbDescriptionFolderVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolderVersions[1].WorkflowState);
            Assert.AreEqual(descriptionFolder.Name, dbDescriptionFolderVersions[1].Name);
            Assert.AreEqual(parentDescriptionFolder.Id, dbDescriptionFolderVersions[1].ParentId);
            Assert.AreEqual(descriptionFolder.SdkFolderId, dbDescriptionFolderVersions[1].SdkFolderId);
            
            //New Version
            Assert.AreEqual(descriptionFolder.Id, dbDescriptionFolderVersions[2].DescriptionFolderId);
            Assert.AreEqual(2, dbDescriptionFolderVersions[2].Version);
            Assert.AreEqual(descriptionFolder.CreatedAt.ToString(), dbDescriptionFolderVersions[2].CreatedAt.ToString());
            Assert.AreEqual(descriptionFolder.UpdatedAt.ToString(), dbDescriptionFolderVersions[2].UpdatedAt.ToString());
            Assert.AreEqual(descriptionFolder.CreatedByUserId, dbDescriptionFolderVersions[2].CreatedByUserId);
            Assert.AreEqual(descriptionFolder.UpdatedByUserId, dbDescriptionFolderVersions[2].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbDescriptionFolderVersions[2].WorkflowState);
            Assert.AreEqual(descriptionFolder.Name, dbDescriptionFolderVersions[2].Name);
            Assert.AreEqual(parentDescriptionFolder.Id, dbDescriptionFolderVersions[2].ParentId);
            Assert.AreEqual(descriptionFolder.SdkFolderId, dbDescriptionFolderVersions[2].SdkFolderId);
        }
    }
}