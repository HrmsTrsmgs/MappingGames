
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Marimo.MappingGames.Uwp.ViewModels;
using Moq;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Xunit;

namespace Test.Uwp
{
    public class MainViewModelのテスト
    {
        MainViewModel テスト対象;
        List<string> 変更済みプロパティ = new List<string>();

        private async Task<WriteableBitmap> NewWriteableBitmap()
        {
            WriteableBitmap 新画像 = null;
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                新画像 = new WriteableBitmap(1, 1);
            });
            return 新画像;
        }

        public MainViewModelのテスト()
        {
            テスト対象 = new MainViewModel();
            テスト対象.PropertyChanged += (sender, e) =>
            {
                変更済みプロパティ.Add(e.PropertyName);
            };
        }
        [Fact]
        public void 元画像倍率パーセントの初期値は100です()
        {
            テスト対象.元画像倍率パーセント.Should().Be(100);
        }

        [Fact]
        public void 元画像倍率パーセントは変更できます()
        {
            テスト対象.元画像倍率パーセント = 50;
            テスト対象.元画像倍率パーセント.Should().Be(50);
        }

        [Fact]
        public void 元画像倍率パーセントの変更は通知されます()
        {
            テスト対象.元画像倍率パーセント = 50;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.元画像倍率パーセント));
        }

        [Fact]
        public void 元画像倍率パーセントの変更による分割領域表示の左上の変更は通知されます()
        {
            テスト対象.元画像倍率パーセント = 50;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示の左上));
        }

        [Fact]
        public void 元画像倍率パーセントの変更による分割領域表示のサイズの変更は通知されます()
        {
            テスト対象.元画像倍率パーセント = 50;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示のサイズ));
        }

        [Fact]
        public void 元画像倍率パーセントの変更による格子の変更は通知されます()
        {
            テスト対象.元画像倍率パーセント = 50;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.格子));
        }
        [Fact]
        public void 分割サイズの幅の初期値は32です()
        {
            テスト対象.分割サイズの幅.Should().Be(32);
        }

        [Fact]
        public void 分割サイズの幅は変更できます()
        {
            テスト対象.分割サイズの幅 = 48;
            テスト対象.分割サイズの幅.Should().Be(48);
        }

        [Fact]
        public void 分割サイズの幅の変更は通知されます()
        {
            テスト対象.分割サイズの幅 = 48;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割サイズの幅));
        }

        [Fact]
        public void 分割サイズの幅による格子の変更は通知されます()
        {
            テスト対象.分割サイズの幅 = 48;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.格子));
        }

        [Fact]
        public void 分割サイズの高さの初期値は32です()
        {
            テスト対象.分割サイズの高さ.Should().Be(32);
        }

        [Fact]
        public void 分割サイズの高さは変更できます()
        {
            テスト対象.分割サイズの高さ = 48;
            テスト対象.分割サイズの高さ.Should().Be(48);
        }

        [Fact]
        public void 分割サイズの高さの変更は通知されます()
        {
            テスト対象.分割サイズの高さ = 48;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割サイズの高さ));
        }

        [Fact]
        public void 分割サイズの高さによる格子の変更は通知されます()
        {
            テスト対象.分割サイズの高さ = 48;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.格子));
        }

        [Fact]
        public void 元画像の初期値はnullです()
        {
            テスト対象.元画像.Should().BeNull();
        }

        [Fact]
        public async Task 元画像は変更できます()
        {
            var 新画像 = await NewWriteableBitmap();

            テスト対象.元画像 = 新画像;
            テスト対象.元画像.Should().BeSameAs(新画像);
        }

        [Fact]
        public async Task 元画像の変更は通知されます()
        {
            テスト対象.元画像 = await NewWriteableBitmap();
            変更済みプロパティ.Should().Contain(nameof(テスト対象.元画像));
        }
    }
}
