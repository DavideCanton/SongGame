using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using SongGame.Storage;
using SongGame.Settings;

namespace Test
{
    [TestClass]
    public class TestFilesStorage
    {
        [TestMethod]
        public void TestRandomPath()
        {
            SettingsContainer sc = new SettingsContainer();
            sc.loadFromFile("config.json");

            FilesStorage st = new FilesStorage(sc);
            st.reload();

            ISet<string> files = st.getRandomFiles(4);
            
            Assert.IsTrue(files.Count() == 4);
        }
    }
}
