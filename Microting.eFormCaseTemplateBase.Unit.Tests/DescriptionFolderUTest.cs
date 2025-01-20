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
                // Name = Guid.NewGuid().ToString(),
                // SdkFolderId = rnd.Next(1, 255)
            };
            await parentFolder.Create(DbContext);

            Folder folder = new Folder
            {
                // Name = Guid.NewGuid().ToString(),
                // SdkFolderId = rnd.Next(1, 255),
                ParentId = parentFolder.Id
            };

            //Act

            await folder.Create(DbContext);

            List<Folder> dbDescriptionFolders = DbContext.Folders.AsNoTracking().ToList();
            List<FolderVersion> dbDescriptionFolderVersions = DbContext.FolderVersions.AsNoTracking().ToList();

            //Assert
            Assert.That(dbDescriptionFolders, Is.Not.Null);
            Assert.That(dbDescriptionFolderVersions, Is.Not.Null);

            Assert.That(dbDescriptionFolders.Count, Is.EqualTo(2));
            Assert.That(dbDescriptionFolderVersions.Count, Is.EqualTo(2));


            Assert.That(dbDescriptionFolders[1].Id, Is.EqualTo(folder.Id));
            Assert.That(dbDescriptionFolders[1].Version, Is.EqualTo(folder.Version));
            Assert.That(dbDescriptionFolders[1].CreatedAt.ToString(), Is.EqualTo(folder.CreatedAt.ToString()));
            Assert.That(dbDescriptionFolders[1].UpdatedAt.ToString(), Is.EqualTo(folder.UpdatedAt.ToString()));
            Assert.That(dbDescriptionFolders[1].CreatedByUserId, Is.EqualTo(folder.CreatedByUserId));
            Assert.That(dbDescriptionFolders[1].UpdatedByUserId, Is.EqualTo(folder.UpdatedByUserId));
            Assert.That(dbDescriptionFolders[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            // Assert.That(dbDescriptionFolders[1].Name, Is.EqualTo(folder.Name));
            Assert.That(dbDescriptionFolders[1].ParentId, Is.EqualTo(parentFolder.Id));
            // Assert.That(dbDescriptionFolders[1].SdkFolderId, Is.EqualTo(folder.SdkFolderId));

            //Versions
            Assert.That(dbDescriptionFolderVersions[1].Id, Is.EqualTo(folder.Id));
            Assert.That(dbDescriptionFolderVersions[1].Version, Is.EqualTo(1));
            Assert.That(dbDescriptionFolderVersions[1].CreatedAt.ToString(), Is.EqualTo(folder.CreatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[1].UpdatedAt.ToString(), Is.EqualTo(folder.UpdatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[1].CreatedByUserId, Is.EqualTo(folder.CreatedByUserId));
            Assert.That(dbDescriptionFolderVersions[1].UpdatedByUserId, Is.EqualTo(folder.UpdatedByUserId));
            Assert.That(dbDescriptionFolderVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            // Assert.That(dbDescriptionFolderVersions[1].Name, Is.EqualTo(folder.Name));
            Assert.That(dbDescriptionFolderVersions[1].ParentId, Is.EqualTo(parentFolder.Id));
            // Assert.That(dbDescriptionFolderVersions[1].SdkFolderId, Is.EqualTo(folder.SdkFolderId));
        }

        [Test]
        public async Task DescriptionFolder_Update_DoesUpdate()
        {
             //Arrange

            Random rnd = new Random();

            Folder parentFolder = new Folder
            {
                // Name = Guid.NewGuid().ToString(),
                // SdkFolderId = rnd.Next(1, 255)
            };
            await parentFolder.Create(DbContext);

            Folder folder = new Folder();
            // folder.Name = Guid.NewGuid().ToString();
            // folder.SdkFolderId = rnd.Next(1, 255);
            folder.ParentId = parentFolder.Id;
            await folder.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = folder.UpdatedAt;
            // string oldName = folder.Name;
            // int oldSdkFolderId = folder.SdkFolderId;

            // folder.Name = Guid.NewGuid().ToString();
            // folder.SdkFolderId = rnd.Next(1, 255);

            await folder.Update(DbContext);

            List<Folder> dbDescriptionFolders = DbContext.Folders.AsNoTracking().ToList();
            List<FolderVersion> dbDescriptionFolderVersions = DbContext.FolderVersions.AsNoTracking().ToList();

            //Assert
            //Assert
            Assert.That(dbDescriptionFolders, Is.Not.Null);
            Assert.That(dbDescriptionFolderVersions, Is.Not.Null);

            Assert.That(dbDescriptionFolders.Count, Is.EqualTo(2));
            Assert.That(dbDescriptionFolderVersions.Count, Is.EqualTo(2));
            // Assert.That(dbDescriptionFolderVersions.Count, Is.EqualTo(3));


            Assert.That(dbDescriptionFolders[1].Id, Is.EqualTo(folder.Id));
            Assert.That(dbDescriptionFolders[1].Version, Is.EqualTo(folder.Version));
            Assert.That(dbDescriptionFolders[1].CreatedAt.ToString(), Is.EqualTo(folder.CreatedAt.ToString()));
            Assert.That(dbDescriptionFolders[1].UpdatedAt.ToString(), Is.EqualTo(folder.UpdatedAt.ToString()));
            Assert.That(dbDescriptionFolders[1].CreatedByUserId, Is.EqualTo(folder.CreatedByUserId));
            Assert.That(dbDescriptionFolders[1].UpdatedByUserId, Is.EqualTo(folder.UpdatedByUserId));
            Assert.That(dbDescriptionFolders[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            // Assert.That(dbDescriptionFolders[1].Name, Is.EqualTo(folder.Name));
            Assert.That(dbDescriptionFolders[1].ParentId, Is.EqualTo(parentFolder.Id));
            // Assert.That(dbDescriptionFolders[1].SdkFolderId, Is.EqualTo(folder.SdkFolderId));

            //Old Version
            // Assert.That(dbDescriptionFolderVersions[1].DescriptionFolderId, Is.EqualTo(folder.Id));
            Assert.That(dbDescriptionFolderVersions[1].Version, Is.EqualTo(1));
            Assert.That(dbDescriptionFolderVersions[1].CreatedAt.ToString(), Is.EqualTo(folder.CreatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[1].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[1].CreatedByUserId, Is.EqualTo(folder.CreatedByUserId));
            Assert.That(dbDescriptionFolderVersions[1].UpdatedByUserId, Is.EqualTo(folder.UpdatedByUserId));
            Assert.That(dbDescriptionFolderVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            // Assert.That(dbDescriptionFolderVersions[1].Name, Is.EqualTo(oldName));
            Assert.That(dbDescriptionFolderVersions[1].ParentId, Is.EqualTo(parentFolder.Id));
            // Assert.That(dbDescriptionFolderVersions[1].SdkFolderId, Is.EqualTo(oldSdkFolderId));

            //New Version
            // Assert.That(dbDescriptionFolderVersions[2].DescriptionFolderId, Is.EqualTo(folder.Id));
            // Assert.That(dbDescriptionFolderVersions[2].Version, Is.EqualTo(2));
            // Assert.That(dbDescriptionFolderVersions[2].Version, Is.EqualTo(2));
            Assert.That(dbDescriptionFolderVersions[1].Version, Is.EqualTo(1));
            // Assert.That(dbDescriptionFolderVersions[2].CreatedAt.ToString(), Is.EqualTo(folder.CreatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[1].CreatedAt.ToString(), Is.EqualTo(folder.CreatedAt.ToString()));
            // Assert.That(dbDescriptionFolderVersions[2].UpdatedAt.ToString(), Is.EqualTo(folder.UpdatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[1].UpdatedAt.ToString(), Is.EqualTo(folder.UpdatedAt.ToString()));
            // Assert.That(dbDescriptionFolderVersions[2].CreatedByUserId, Is.EqualTo(folder.CreatedByUserId));
            Assert.That(dbDescriptionFolderVersions[1].CreatedByUserId, Is.EqualTo(folder.CreatedByUserId));
            // Assert.That(dbDescriptionFolderVersions[2].UpdatedByUserId, Is.EqualTo(folder.UpdatedByUserId));
            Assert.That(dbDescriptionFolderVersions[1].UpdatedByUserId, Is.EqualTo(folder.UpdatedByUserId));
            // Assert.That(dbDescriptionFolderVersions[2].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dbDescriptionFolderVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            // Assert.That(dbDescriptionFolderVersions[2].Name, Is.EqualTo(folder.Name));
            // Assert.That(dbDescriptionFolderVersions[2].ParentId, Is.EqualTo(parentFolder.Id));
            Assert.That(dbDescriptionFolderVersions[1].ParentId, Is.EqualTo(parentFolder.Id));
            // Assert.That(dbDescriptionFolderVersions[2].SdkFolderId, Is.EqualTo(folder.SdkFolderId));
        }

        [Test]
        public async Task DescriptionFolder_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

            Random rnd = new Random();

            Folder parentFolder = new Folder
            {
                // Name = Guid.NewGuid().ToString(),
                // SdkFolderId = rnd.Next(1, 255)
            };
            await parentFolder.Create(DbContext);

            Folder folder = new Folder
            {
                // Name = Guid.NewGuid().ToString(),
                // SdkFolderId = rnd.Next(1, 255),
                ParentId = parentFolder.Id
            };
            await folder.Create(DbContext);


            //Act

            DateTime? oldUpdatedAt = folder.UpdatedAt;

            await folder.Delete(DbContext);

            List<Folder> dbDescriptionFolders = DbContext.Folders.AsNoTracking().ToList();
            List<FolderVersion> dbDescriptionFolderVersions = DbContext.FolderVersions.AsNoTracking().ToList();

            //Assert
            Assert.That(dbDescriptionFolders, Is.Not.Null);
            Assert.That(dbDescriptionFolderVersions, Is.Not.Null);

            Assert.That(dbDescriptionFolders.Count, Is.EqualTo(2));
            Assert.That(dbDescriptionFolderVersions.Count, Is.EqualTo(3));


            Assert.That(dbDescriptionFolders[1].Id, Is.EqualTo(folder.Id));
            Assert.That(dbDescriptionFolders[1].Version, Is.EqualTo(folder.Version));
            Assert.That(dbDescriptionFolders[1].CreatedAt.ToString(), Is.EqualTo(folder.CreatedAt.ToString()));
            Assert.That(dbDescriptionFolders[1].UpdatedAt.ToString(), Is.EqualTo(folder.UpdatedAt.ToString()));
            Assert.That(dbDescriptionFolders[1].CreatedByUserId, Is.EqualTo(folder.CreatedByUserId));
            Assert.That(dbDescriptionFolders[1].UpdatedByUserId, Is.EqualTo(folder.UpdatedByUserId));
            Assert.That(dbDescriptionFolders[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            // Assert.That(dbDescriptionFolders[1].Name, Is.EqualTo(folder.Name));
            Assert.That(dbDescriptionFolders[1].ParentId, Is.EqualTo(parentFolder.Id));
            // Assert.That(dbDescriptionFolders[1].SdkFolderId, Is.EqualTo(folder.SdkFolderId));

            //Old Version
            // Assert.That(dbDescriptionFolderVersions[1].DescriptionFolderId, Is.EqualTo(folder.Id));
            Assert.That(dbDescriptionFolderVersions[1].Version, Is.EqualTo(1));
            Assert.That(dbDescriptionFolderVersions[1].CreatedAt.ToString(), Is.EqualTo(folder.CreatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[1].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[1].CreatedByUserId, Is.EqualTo(folder.CreatedByUserId));
            Assert.That(dbDescriptionFolderVersions[1].UpdatedByUserId, Is.EqualTo(folder.UpdatedByUserId));
            Assert.That(dbDescriptionFolderVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            // Assert.That(dbDescriptionFolderVersions[1].Name, Is.EqualTo(folder.Name));
            Assert.That(dbDescriptionFolderVersions[1].ParentId, Is.EqualTo(parentFolder.Id));
            // Assert.That(dbDescriptionFolderVersions[1].SdkFolderId, Is.EqualTo(folder.SdkFolderId));

            //New Version
            // Assert.That(dbDescriptionFolderVersions[2].DescriptionFolderId, Is.EqualTo(folder.Id));
            Assert.That(dbDescriptionFolderVersions[2].Version, Is.EqualTo(2));
            Assert.That(dbDescriptionFolderVersions[2].CreatedAt.ToString(), Is.EqualTo(folder.CreatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[2].UpdatedAt.ToString(), Is.EqualTo(folder.UpdatedAt.ToString()));
            Assert.That(dbDescriptionFolderVersions[2].CreatedByUserId, Is.EqualTo(folder.CreatedByUserId));
            Assert.That(dbDescriptionFolderVersions[2].UpdatedByUserId, Is.EqualTo(folder.UpdatedByUserId));
            Assert.That(dbDescriptionFolderVersions[2].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            // Assert.That(dbDescriptionFolderVersions[2].Name, Is.EqualTo(folder.Name));
            Assert.That(dbDescriptionFolderVersions[2].ParentId, Is.EqualTo(parentFolder.Id));
            // Assert.That(dbDescriptionFolderVersions[2].SdkFolderId, Is.EqualTo(folder.SdkFolderId));
        }
    }
}