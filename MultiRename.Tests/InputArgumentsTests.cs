using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MultiRename.Tests
{
    [TestClass]
    public class InputArgumentsTests
    {
        private string _currentDirectory;
        private string _validDirectory;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestSetup()
        {
            _currentDirectory = @"c:\testing";
            _validDirectory = TestContext.TestDir;
            AppTools.FileSystem = Mock.Of<IFileSystem>();
            Mock.Get(AppTools.FileSystem).Setup(x => x.GetCurrentDirectory()).Returns(_currentDirectory);
            Mock.Get(AppTools.FileSystem).Setup(x => x.DirectoryExists(It.IsAny<string>()))
                .Returns((string d) => Directory.Exists(d));
        }

        [TestMethod]
        public void EmptyArgumentList()
        {
            var expected = _currentDirectory;
            var args= new InputArguments(new string[]{});

            Assert.AreEqual(expected, args.SourceDirectory);
        }

        [TestMethod]
        public void NonExistingDirectoryAsArgument()
        {
            var expected = _currentDirectory;
            var args= new InputArguments(new string[]{@"c:\this\do\not\exists"});

            Assert.AreEqual(expected, args.SourceDirectory);
        }

        [TestMethod]
        public void MoreThanOneArgument()
        {
            var expected = _currentDirectory;
            var args= new InputArguments(new string[]{_validDirectory, "other"});

            Assert.AreEqual(expected, args.SourceDirectory);
        }

        [TestMethod]
        public void ValidDirectoryAsSingleArgument()
        {
            var expected = _validDirectory;
            var args= new InputArguments(new string[]{_validDirectory});

            Assert.AreEqual(expected, args.SourceDirectory);
        }
    }
}
