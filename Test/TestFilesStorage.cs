using System;
using NUnit.Framework;
using SongGame.Settings;
using SongGame.Storage;
using System.Collections.Generic;
using Shouldly;
using System.Linq;
using Moq;

namespace Test
{
    [TestFixture]
    public class TestFilesStorage
    {
        [Test]
        public void TestRandomPath()
        {
            SettingsContainer sc = new SettingsContainer();
            sc.LoadFromFile(Properties.Settings.Default.configPath);

            var m = new Mock<FilesStorage>(sc)
            {
                CallBase = true
            };
            m.Setup(x => x.validatePath(It.IsAny<string>())).Returns(true);
            var st = m.Object;
            
            Fill(st, "E1", 120);
            Fill(st, "E2", 5);
            Fill(st, "E3", 4);

            ISet<string> files = st.getRandomFiles(4);
            files.Count.ShouldBe(4);
        }

        [Test]
        public void TestRandomPathMoreEntries()
        {
            SettingsContainer sc = new SettingsContainer();
            sc.LoadFromFile(Properties.Settings.Default.configPath);

            FilesStorage st = new FilesStorage(sc);

            Fill(st, "E1", 3);
            Fill(st, "E2", 5);
            Fill(st, "E3", 4);

            st.findPath(0).ShouldBe(st.files["E1"][0]);
            st.findPath(2).ShouldBe(st.files["E2"][2]);
            st.findPath(3).ShouldBe(st.files["E2"][0]);
            st.findPath(6).ShouldBe(st.files["E2"][3]);
            st.findPath(7).ShouldBe(st.files["E2"][4]);

            st.findPath(8).ShouldBe(st.files["E3"][0]);
            st.findPath(11).ShouldBe(st.files["E2"][3]);
            Should.Throw<ArgumentOutOfRangeException>(() => st.findPath(-1));
            Should.Throw<ArgumentOutOfRangeException>(() => st.findPath(12));
            Should.Throw<ArgumentOutOfRangeException>(() => st.findPath(20));
        }

        private void Fill(FilesStorage d, string k, int vc)
        {
            d.registerEntries(k, Enumerable.Range(1, vc).Select(i => $"V{i}").ToList());
        }
    }
}
