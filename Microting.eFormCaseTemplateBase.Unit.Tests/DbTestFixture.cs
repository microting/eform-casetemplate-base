/*
The MIT License (MIT)
Copyright (c) 2007 - 2019 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microting.eFormCaseTemplateBase.Infrastructure.Data;
using Microting.eFormCaseTemplateBase.Infrastructure.Data.Factories;
using NUnit.Framework;

namespace Microting.eFormCaseTemplateCase.Unit.Tests
{
    [TestFixture]
    public abstract class DbTestFixture
    {
        protected CaseTemplatePnDbContext DbContext;
        private string _connectionString;
        private const string DatabaseName = "eform-case-template-base-tests";

        private void GetContext(string connectionStr)
        {
            CaseTemplatePnContextFactory contextFactory = new CaseTemplatePnContextFactory();
            DbContext = contextFactory.CreateDbContext(new[] {connectionStr});

            DbContext.Database.Migrate();
            DbContext.Database.EnsureCreated();
        }

        [SetUp]
        public void Setup()
        {

            _connectionString =
                @$"Server = localhost; port = 3306; Database = {DatabaseName}; user = root; password = secretpassword; Convert Zero Datetime = true;";

            GetContext(_connectionString);

            DbContext.Database.SetCommandTimeout(300);

            try
            {
                ClearDb();
            }
            catch
            {
                DbContext.Database.Migrate();
            }

            DoSetup();
        }

        [TearDown]
        public void TearDown()
        {
            ClearDb();

            DbContext.Dispose();
        }

        private void ClearDb()
        {
            List<string> modelNames = new List<string>();
            modelNames.Add("PluginConfigurationValueVersions");
            modelNames.Add("PluginConfigurationValues");
            modelNames.Add("CaseTemplateSiteVersions");
            modelNames.Add("CaseTemplateSites");
            modelNames.Add("CaseTemplateSiteTagVersions");
            modelNames.Add("CaseTemplateSiteTags");
            modelNames.Add("CaseVersions");
            modelNames.Add("Cases");
            modelNames.Add("CaseTemplateUploadedDatas");
            modelNames.Add("CaseTemplateUploadedDataVersions");
            modelNames.Add("CaseTemplateVersions");
            modelNames.Add("CaseTemplates");
            modelNames.Add("DescriptionFolderVersions");
            modelNames.Add("DescriptionFolders");
            modelNames.Add("UploadedDataVersions");
            modelNames.Add("UploadedDatas");

            var firstRunNotDone = true;
            foreach (var modelName in modelNames)
            {
                try
                {
                    if (firstRunNotDone)
                    {
                        DbContext.Database.ExecuteSqlRaw(
                            $"SET FOREIGN_KEY_CHECKS = 0;TRUNCATE `{DatabaseName}`.`{modelName}`");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == $"Unknown database '{DatabaseName}'")
                    {
                        firstRunNotDone = false;
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        protected virtual void DoSetup() { }
    }
}