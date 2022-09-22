using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task DescriptionFolder_Create_DoesCreate()
        {
            //Arrange

            Random rnd = new Random();

            Folder parentFolder = new Folder
            {
                Name = Guid.NewGuid().ToString(),
                SdkFolderId = rnd.Next(1, 255)
            };
            await parentFolder.Create(DbContext);

            Folder folder = new Folder
            {
                Name = Guid.NewGuid().ToString(),
                SdkFolderId = rnd.Next(1, 255),
                ParentId = parentFolder.Id
            };

            //Act

            await folder.Create(DbContext);

            List<Folder> dbDescriptionFolders = DbContext.DescriptionFolders.AsNoTracking().ToList();
            List<FolderVersion> dbDescriptionFolderVersions = DbContext.DescriptionFolderVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbDescriptionFolders);
            Assert.NotNull(dbDescriptionFolderVersions);

            Assert.AreEqual(2, dbDescriptionFolders.Count);
            Assert.AreEqual(2, dbDescriptionFolderVersions.Count);


            Assert.AreEqual(folder.Id, dbDescriptionFolders[1].Id);
            Assert.AreEqual(folder.Version, dbDescriptionFolders[1].Version);
            Assert.AreEqual(folder.CreatedAt.ToString(), dbDescriptionFolders[1].CreatedAt.ToString());
            Assert.AreEqual(folder.UpdatedAt.ToString(), dbDescriptionFolders[1].UpdatedAt.ToString());
            Assert.AreEqual(folder.CreatedByUserId, dbDescriptionFolders[1].CreatedByUserId);
            Assert.AreEqual(folder.UpdatedByUserId, dbDescriptionFolders[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolders[1].WorkflowState);
            Assert.AreEqual(folder.Name, dbDescriptionFolders[1].Name);
            Assert.AreEqual(parentFolder.Id, dbDescriptionFolders[1].ParentId);
            Assert.AreEqual(folder.SdkFolderId, dbDescriptionFolders[1].SdkFolderId);

            //Versions
            Assert.AreEqual(folder.Id, dbDescriptionFolderVersions[1].Id);
            Assert.AreEqual(1, dbDescriptionFolderVersions[1].Version);
            Assert.AreEqual(folder.CreatedAt.ToString(), dbDescriptionFolderVersions[1].CreatedAt.ToString());
            Assert.AreEqual(folder.UpdatedAt.ToString(), dbDescriptionFolderVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(folder.CreatedByUserId, dbDescriptionFolderVersions[1].CreatedByUserId);
            Assert.AreEqual(folder.UpdatedByUserId, dbDescriptionFolderVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolderVersions[1].WorkflowState);
            Assert.AreEqual(folder.Name, dbDescriptionFolderVersions[1].Name);
            Assert.AreEqual(parentFolder.Id, dbDescriptionFolderVersions[1].ParentId);
            Assert.AreEqual(folder.SdkFolderId, dbDescriptionFolderVersions[1].SdkFolderId);
        }

        [Test]
        public async Task DescriptionFolder_Update_DoesUpdate()
        {
             //Arrange

            Random rnd = new Random();

            Folder parentFolder = new Folder
            {
                Name = Guid.NewGuid().ToString(),
                SdkFolderId = rnd.Next(1, 255)
            };
            await parentFolder.Create(DbContext);

            Folder folder = new Folder();
            folder.Name = Guid.NewGuid().ToString();
            folder.SdkFolderId = rnd.Next(1, 255);
            folder.ParentId = parentFolder.Id;
            await folder.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = folder.UpdatedAt;
            string oldName = folder.Name;
            int oldSdkFolderId = folder.SdkFolderId;

            folder.Name = Guid.NewGuid().ToString();
            folder.SdkFolderId = rnd.Next(1, 255);

            await folder.Update(DbContext);

            List<Folder> dbDescriptionFolders = DbContext.DescriptionFolders.AsNoTracking().ToList();
            List<FolderVersion> dbDescriptionFolderVersions = DbContext.DescriptionFolderVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbDescriptionFolders);
            Assert.NotNull(dbDescriptionFolderVersions);

            Assert.AreEqual(2, dbDescriptionFolders.Count);
            Assert.AreEqual(3, dbDescriptionFolderVersions.Count);


            Assert.AreEqual(folder.Id, dbDescriptionFolders[1].Id);
            Assert.AreEqual(folder.Version, dbDescriptionFolders[1].Version);
            Assert.AreEqual(folder.CreatedAt.ToString(), dbDescriptionFolders[1].CreatedAt.ToString());
            Assert.AreEqual(folder.UpdatedAt.ToString(), dbDescriptionFolders[1].UpdatedAt.ToString());
            Assert.AreEqual(folder.CreatedByUserId, dbDescriptionFolders[1].CreatedByUserId);
            Assert.AreEqual(folder.UpdatedByUserId, dbDescriptionFolders[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolders[1].WorkflowState);
            Assert.AreEqual(folder.Name, dbDescriptionFolders[1].Name);
            Assert.AreEqual(parentFolder.Id, dbDescriptionFolders[1].ParentId);
            Assert.AreEqual(folder.SdkFolderId, dbDescriptionFolders[1].SdkFolderId);

            //Old Version
            Assert.AreEqual(folder.Id, dbDescriptionFolderVersions[1].DescriptionFolderId);
            Assert.AreEqual(1, dbDescriptionFolderVersions[1].Version);
            Assert.AreEqual(folder.CreatedAt.ToString(), dbDescriptionFolderVersions[1].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbDescriptionFolderVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(folder.CreatedByUserId, dbDescriptionFolderVersions[1].CreatedByUserId);
            Assert.AreEqual(folder.UpdatedByUserId, dbDescriptionFolderVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolderVersions[1].WorkflowState);
            Assert.AreEqual(oldName, dbDescriptionFolderVersions[1].Name);
            Assert.AreEqual(parentFolder.Id, dbDescriptionFolderVersions[1].ParentId);
            Assert.AreEqual(oldSdkFolderId, dbDescriptionFolderVersions[1].SdkFolderId);

            //New Version
            Assert.AreEqual(folder.Id, dbDescriptionFolderVersions[2].DescriptionFolderId);
            Assert.AreEqual(2, dbDescriptionFolderVersions[2].Version);
            Assert.AreEqual(folder.CreatedAt.ToString(), dbDescriptionFolderVersions[2].CreatedAt.ToString());
            Assert.AreEqual(folder.UpdatedAt.ToString(), dbDescriptionFolderVersions[2].UpdatedAt.ToString());
            Assert.AreEqual(folder.CreatedByUserId, dbDescriptionFolderVersions[2].CreatedByUserId);
            Assert.AreEqual(folder.UpdatedByUserId, dbDescriptionFolderVersions[2].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolderVersions[2].WorkflowState);
            Assert.AreEqual(folder.Name, dbDescriptionFolderVersions[2].Name);
            Assert.AreEqual(parentFolder.Id, dbDescriptionFolderVersions[2].ParentId);
            Assert.AreEqual(folder.SdkFolderId, dbDescriptionFolderVersions[2].SdkFolderId);
        }

        [Test]
        public async Task DescriptionFolder_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

            Random rnd = new Random();

            Folder parentFolder = new Folder
            {
                Name = Guid.NewGuid().ToString(),
                SdkFolderId = rnd.Next(1, 255)
            };
            await parentFolder.Create(DbContext);

            Folder folder = new Folder
            {
                Name = Guid.NewGuid().ToString(),
                SdkFolderId = rnd.Next(1, 255),
                ParentId = parentFolder.Id
            };
            await folder.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = folder.UpdatedAt;

            await folder.Delete(DbContext);

            List<Folder> dbDescriptionFolders = DbContext.DescriptionFolders.AsNoTracking().ToList();
            List<FolderVersion> dbDescriptionFolderVersions = DbContext.DescriptionFolderVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbDescriptionFolders);
            Assert.NotNull(dbDescriptionFolderVersions);

            Assert.AreEqual(2, dbDescriptionFolders.Count);
            Assert.AreEqual(3, dbDescriptionFolderVersions.Count);


            Assert.AreEqual(folder.Id, dbDescriptionFolders[1].Id);
            Assert.AreEqual(folder.Version, dbDescriptionFolders[1].Version);
            Assert.AreEqual(folder.CreatedAt.ToString(), dbDescriptionFolders[1].CreatedAt.ToString());
            Assert.AreEqual(folder.UpdatedAt.ToString(), dbDescriptionFolders[1].UpdatedAt.ToString());
            Assert.AreEqual(folder.CreatedByUserId, dbDescriptionFolders[1].CreatedByUserId);
            Assert.AreEqual(folder.UpdatedByUserId, dbDescriptionFolders[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbDescriptionFolders[1].WorkflowState);
            Assert.AreEqual(folder.Name, dbDescriptionFolders[1].Name);
            Assert.AreEqual(parentFolder.Id, dbDescriptionFolders[1].ParentId);
            Assert.AreEqual(folder.SdkFolderId, dbDescriptionFolders[1].SdkFolderId);

            //Old Version
            Assert.AreEqual(folder.Id, dbDescriptionFolderVersions[1].DescriptionFolderId);
            Assert.AreEqual(1, dbDescriptionFolderVersions[1].Version);
            Assert.AreEqual(folder.CreatedAt.ToString(), dbDescriptionFolderVersions[1].CreatedAt.ToString());
            Assert.AreEqual(oldUpdatedAt.ToString(), dbDescriptionFolderVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(folder.CreatedByUserId, dbDescriptionFolderVersions[1].CreatedByUserId);
            Assert.AreEqual(folder.UpdatedByUserId, dbDescriptionFolderVersions[1].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Created, dbDescriptionFolderVersions[1].WorkflowState);
            Assert.AreEqual(folder.Name, dbDescriptionFolderVersions[1].Name);
            Assert.AreEqual(parentFolder.Id, dbDescriptionFolderVersions[1].ParentId);
            Assert.AreEqual(folder.SdkFolderId, dbDescriptionFolderVersions[1].SdkFolderId);

            //New Version
            Assert.AreEqual(folder.Id, dbDescriptionFolderVersions[2].DescriptionFolderId);
            Assert.AreEqual(2, dbDescriptionFolderVersions[2].Version);
            Assert.AreEqual(folder.CreatedAt.ToString(), dbDescriptionFolderVersions[2].CreatedAt.ToString());
            Assert.AreEqual(folder.UpdatedAt.ToString(), dbDescriptionFolderVersions[2].UpdatedAt.ToString());
            Assert.AreEqual(folder.CreatedByUserId, dbDescriptionFolderVersions[2].CreatedByUserId);
            Assert.AreEqual(folder.UpdatedByUserId, dbDescriptionFolderVersions[2].UpdatedByUserId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbDescriptionFolderVersions[2].WorkflowState);
            Assert.AreEqual(folder.Name, dbDescriptionFolderVersions[2].Name);
            Assert.AreEqual(parentFolder.Id, dbDescriptionFolderVersions[2].ParentId);
            Assert.AreEqual(folder.SdkFolderId, dbDescriptionFolderVersions[2].SdkFolderId);
        }
    }
}