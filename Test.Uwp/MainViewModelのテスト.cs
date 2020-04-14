
using System;
using Marimo.MappingGames.Uwp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Uwp
{
    [TestClass]
    public class MainViewModelのテスト
    {
        MainViewModel テスト対象 = new MainViewModel();
        [TestMethod]
        public void 元画像倍率パーセントの初期値は100です()
        {
            Assert.AreEqual(テスト対象.元画像倍率パーセント, 100);
        }
    }
}
