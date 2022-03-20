using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FileSystemVisitor.Lib.Models;
using FileSystemVisitor.Lib.Services;
using Moq;
using NUnit.Framework;

namespace FileSystemVisitor.Tests
{
    [TestFixture]
    public class FileSystemVisitorServiceTests
    {
        private const string TestDirectory = @"./TestFolder";
        private Func<FileSystemInfo, bool> _filter;

        [Test]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public void GetFileSystemInfo_EmptyRoot_ThrowsArgumentException(string rootDir)
        {
            const string emptyStringError =
                "Input string cannot be null, empty or consist only of whitespaces (Parameter \'rootDir\')";

            var fileSystemVisitorService = CreateTarget();

            var fileSystemInfo = fileSystemVisitorService.GetFileSystemInfo(rootDir, false);

            var actual = Assert.Throws<ArgumentException>(() =>
            {
                var fileSystemResult = fileSystemInfo.First();
            });

            Assert.AreEqual(emptyStringError, actual.Message);
        }

        [Test]
        public void GetFileSystemInfo_DirectoryNotExists_ThrowsDirectoryNotFoundException()
        {
            const string notExistingDirectory = @"./someDir";

            var fileSystemVisitorService = CreateTarget();

            var fileSystemInfo = fileSystemVisitorService.GetFileSystemInfo(notExistingDirectory, false);

            Assert.Throws<DirectoryNotFoundException>(() =>
            {
                var fileSystemResult = fileSystemInfo.First();
            });
        }

        [Test]
        public void GetFileSystemInfo_DirectoryExists_ReturnsListOfFileSystemResults()
        {
            var expectedResult = new List<string>()
            {
                "Folder1",
                "Folder2",
                "Folder1_File1.txt",
                "Folder1_File2.txt",
                "Folder2_File1.txt",
                "Folder2_File2.txt",
                "File1.txt",
                "File2.txt"
            };

            var fileSystemVisitorService = CreateTarget();

            var fileSystemResults = fileSystemVisitorService.GetFileSystemInfo(TestDirectory, false);

            CollectionAssert.AreEquivalent(expectedResult, fileSystemResults.Select(x => x.Name));
        }

        [Test]
        public void GetFileSystemInfo_NotNullFilter_ReturnsOnlyFiles()
        {
            var expectedResult = new List<string>()
            {
                "Folder1_File1.txt",
                "Folder1_File2.txt",
                "Folder2_File1.txt",
                "Folder2_File2.txt",
                "File1.txt",
                "File2.txt"
            };

            _filter += (x => x is FileInfo);

            var fileSystemVisitorService = CreateTarget();

            var fileSystemResults = fileSystemVisitorService.GetFileSystemInfo(TestDirectory, false);

            CollectionAssert.AreEquivalent(expectedResult, fileSystemResults.Select(x => x.Name));
        }

        [Test]
        public void GetFileSystemInfo_NotNullFilter_ReturnsOnlyDirectories()
        {
            var expectedResult = new List<string>()
            {
                "Folder1", "Folder2"
            };

            _filter += (x => x is DirectoryInfo);

            var fileSystemVisitorService = CreateTarget();

            var fileSystemResults = fileSystemVisitorService.GetFileSystemInfo(TestDirectory, false);

            CollectionAssert.AreEquivalent(expectedResult, fileSystemResults.Select(x => x.Name));
        }

        [Test]
        public void GetFileSystemInfo_NotNullFilter_ReturnsFileSystemObjectWith2InName()
        {
            var expectedResult = new List<string>()
            {
                "Folder2",
                "Folder1_File2.txt",
                "Folder2_File1.txt",
                "Folder2_File2.txt",
                "File2.txt"
            };

            _filter += (x => x.Name.Contains("2", StringComparison.OrdinalIgnoreCase));

            var fileSystemVisitorService = CreateTarget();

            var fileSystemResults = fileSystemVisitorService.GetFileSystemInfo(TestDirectory, false);

            CollectionAssert.AreEquivalent(expectedResult, fileSystemResults.Select(x => x.Name));
        }

        private FileSystemVisitorService CreateTarget()
        {
            return new FileSystemVisitorService(_filter);
        }
    }
}