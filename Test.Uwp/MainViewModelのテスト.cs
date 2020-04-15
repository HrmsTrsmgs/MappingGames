
using System;
using FluentAssertions;
using Marimo.MappingGames.Uwp.ViewModels;
using Xunit;

namespace Test.Uwp
{
    public class MainViewModelのテスト
    {
        MainViewModel テスト対象 = new MainViewModel();
        [Fact]
        public void 元画像倍率パーセントの初期値は100です()
        {
            テスト対象.元画像倍率パーセント.Should().Be(100);
        }
    }
}
