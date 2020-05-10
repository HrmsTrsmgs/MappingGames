
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
using static Marimo.MappingGames.Uwp.ViewModels.MainViewModel;

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

        [Fact]
        public void 元画像サイズの初期値は0_0です()
        {
            テスト対象.元画像サイズ.Should().Be(new Size(0, 0));
        }

        [Fact]
        public void 元画像サイズは変更できます()
        {
            テスト対象.元画像サイズ = new Size(10, 10);
            テスト対象.元画像サイズ.Should().Be(new Size(10, 10));
        }

        [Fact]
        public void 元画像サイズの変更は通知されます()
        {
            テスト対象.元画像サイズ = new Size(10, 10);
            変更済みプロパティ.Should().Contain(nameof(テスト対象.元画像サイズ));
        }

        [Fact]
        public void 元画像サイズの変更による画像サイズの変更は通知されます()
        {
            テスト対象.元画像サイズ = new Size(10, 10);
            変更済みプロパティ.Should().Contain(nameof(テスト対象.画像サイズ));
        }

        [Fact]
        public void 元画像サイズの変更による分割領域表示の左上の変更は通知されます()
        {
            テスト対象.元画像サイズ = new Size(10, 10);
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示の左上));
        }

        [Fact]
        public void 元画像サイズの変更による分割領域表示のサイズの変更は通知されます()
        {
            テスト対象.元画像サイズ = new Size(10, 10);
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示のサイズ));
        }

        [Fact]
        public void 元画像サイズの変更による格子の変更は通知されます()
        {
            テスト対象.元画像サイズ = new Size(10, 10);
            変更済みプロパティ.Should().Contain(nameof(テスト対象.格子));
        }

        [Fact]
        public void 分割領域の上限の初期値は0です()
        {
            テスト対象.分割領域の上限.Should().Be(0);
        }

        [Fact]
        public void 分割領域の上限は変更できます()
        {
            テスト対象.分割領域の上限 = 100;
            テスト対象.分割領域の上限.Should().Be(100);
        }

        [Fact]
        public void 分割領域の上限の変更は通知されます()
        {
            テスト対象.分割領域の上限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域の上限));
        }

        [Fact]
        public void 分割領域の上限の変更による分割領域のサイズは通知されます()
        {
            テスト対象.分割領域の上限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域のサイズ));
        }

        [Fact]
        public void 分割領域の上限の変更による分割領域表示の左上は通知されます()
        {
            テスト対象.分割領域の上限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示の左上));
        }

        [Fact]
        public void 分割領域の上限の変更による分割領域表示のサイズは通知されます()
        {
            テスト対象.分割領域の上限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示のサイズ));
        }
        [Fact]
        public void 分割領域の上限の変更による格子は通知されます()
        {
            テスト対象.分割領域の上限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.格子));
        }

        [Fact]
        public void 分割領域の下限の初期値は0です()
        {
            テスト対象.分割領域の下限.Should().Be(0);
        }

        [Fact]
        public void 分割領域の下限は変更できます()
        {
            テスト対象.分割領域の下限 = 100;
            テスト対象.分割領域の下限.Should().Be(100);
        }

        [Fact]
        public void 分割領域の下限の変更は通知されます()
        {
            テスト対象.分割領域の下限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域の下限));
        }

        [Fact]
        public void 分割領域の下限の変更による分割領域のサイズは通知されます()
        {
            テスト対象.分割領域の下限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域のサイズ));
        }

        [Fact]
        public void 分割領域の下限の変更による分割領域表示の左上は通知されます()
        {
            テスト対象.分割領域の下限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示の左上));
        }

        [Fact]
        public void 分割領域の下限の変更による分割領域表示のサイズは通知されます()
        {
            テスト対象.分割領域の下限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示のサイズ));
        }
        [Fact]
        public void 分割領域の下限の変更による格子は通知されます()
        {
            テスト対象.分割領域の下限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.格子));
        }

        [Fact]
        public void 分割領域の左限の初期値は0です()
        {
            テスト対象.分割領域の左限.Should().Be(0);
        }

        [Fact]
        public void 分割領域の左限は変更できます()
        {
            テスト対象.分割領域の左限 = 100;
            テスト対象.分割領域の左限.Should().Be(100);
        }

        [Fact]
        public void 分割領域の左限の変更は通知されます()
        {
            テスト対象.分割領域の左限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域の左限));
        }

        [Fact]
        public void 分割領域の左限の変更による分割領域のサイズは通知されます()
        {
            テスト対象.分割領域の左限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域のサイズ));
        }

        [Fact]
        public void 分割領域の左限の変更による分割領域表示の左上は通知されます()
        {
            テスト対象.分割領域の左限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示の左上));
        }

        [Fact]
        public void 分割領域の左限の変更による分割領域表示のサイズは通知されます()
        {
            テスト対象.分割領域の左限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示のサイズ));
        }
        [Fact]
        public void 分割領域の左限の変更による格子は通知されます()
        {
            テスト対象.分割領域の左限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.格子));
        }

        [Fact]
        public void 分割領域の右限の初期値は0です()
        {
            テスト対象.分割領域の右限.Should().Be(0);
        }

        [Fact]
        public void 分割領域の右限は変更できます()
        {
            テスト対象.分割領域の右限 = 100;
            テスト対象.分割領域の右限.Should().Be(100);
        }

        [Fact]
        public void 分割領域の右限の変更は通知されます()
        {
            テスト対象.分割領域の右限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域の右限));
        }

        [Fact]
        public void 分割領域の右限の変更による分割領域のサイズは通知されます()
        {
            テスト対象.分割領域の右限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域のサイズ));
        }

        [Fact]
        public void 分割領域の右限の変更による分割領域表示の左上は通知されます()
        {
            テスト対象.分割領域の右限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示の左上));
        }

        [Fact]
        public void 分割領域の右限の変更による分割領域表示のサイズは通知されます()
        {
            テスト対象.分割領域の右限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.分割領域表示のサイズ));
        }
        [Fact]
        public void 分割領域の右限の変更による格子は通知されます()
        {
            テスト対象.分割領域の右限 = 100;
            変更済みプロパティ.Should().Contain(nameof(テスト対象.格子));
        }

        [Fact]
        public void 格子は初期状態は0項目です()
        {
            テスト対象.格子.Should().BeEmpty();
        }

        [Fact]
        public async Task 格子は取得できます()
        {
            テスト対象.元画像 = await NewWriteableBitmap();
            テスト対象.分割領域の左限 = 0;
            テスト対象.分割領域の右限 = 99;
            テスト対象.分割領域の上限 = 0;
            テスト対象.分割領域の下限 = 99;
            テスト対象.分割サイズの幅 = 100;
            テスト対象.分割サイズの高さ = 100;
            テスト対象.元画像倍率パーセント = 100;
            テスト対象.格子.Should().HaveCount(2);
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 99, 0));
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 0, 99));
        }
        [Fact]
        public void 格子は元画像がなければ取得できます()
        {
            テスト対象.分割領域の左限 = 0;
            テスト対象.分割領域の右限 = 99;
            テスト対象.分割領域の上限 = 0;
            テスト対象.分割領域の下限 = 99;
            テスト対象.分割サイズの幅 = 100;
            テスト対象.分割サイズの高さ = 100;
            テスト対象.元画像倍率パーセント = 100;
            テスト対象.格子.Should().BeEmpty();
        }

        [Fact]
        public async Task 格子は分割領域が左右に広がれば増えます()
        {
            テスト対象.元画像 = await NewWriteableBitmap();
            テスト対象.分割領域の左限 = 0;
            テスト対象.分割領域の右限 = 198;
            テスト対象.分割領域の上限 = 0;
            テスト対象.分割領域の下限 = 99;
            テスト対象.分割サイズの幅 = 100;
            テスト対象.分割サイズの高さ = 100;
            テスト対象.元画像倍率パーセント = 100;
            テスト対象.格子.Should().HaveCount(3);
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 198, 0));
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 0, 99));
            テスト対象.格子.Should().Contain(new LineViewModel(100, 0, 100, 99));
        }

        [Fact]
        public async Task 格子は分割領域が上下に広がれば増えます()
        {
            テスト対象.元画像 = await NewWriteableBitmap();
            テスト対象.分割領域の左限 = 0;
            テスト対象.分割領域の右限 = 99;
            テスト対象.分割領域の上限 = 0;
            テスト対象.分割領域の下限 = 198;
            テスト対象.分割サイズの幅 = 100;
            テスト対象.分割サイズの高さ = 100;
            テスト対象.格子.Should().HaveCount(3);
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 99, 0));
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 0, 198));
            テスト対象.格子.Should().Contain(new LineViewModel(0, 100, 99, 100));
        }

        [Fact]
        public async Task 格子は元画像倍率が変化すれば比例して変化します()
        {
            テスト対象.元画像 = await NewWriteableBitmap();
            テスト対象.分割領域の左限 = 0;
            テスト対象.分割領域の右限 = 99;
            テスト対象.分割領域の上限 = 0;
            テスト対象.分割領域の下限 = 99;
            テスト対象.分割サイズの幅 = 100;
            テスト対象.分割サイズの高さ = 100;
            テスト対象.元画像倍率パーセント = 200;
            テスト対象.格子.Should().HaveCount(2);
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 198, 0));
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 0, 198));
        }

        [Fact]
        public async Task 格子は分割領域が左右に移動すればそれに伴い移動します()
        {
            テスト対象.元画像 = await NewWriteableBitmap();
            テスト対象.分割領域の左限 = 100;
            テスト対象.分割領域の右限 = 199;
            テスト対象.分割領域の上限 = 0;
            テスト対象.分割領域の下限 = 99;
            テスト対象.分割サイズの幅 = 100;
            テスト対象.分割サイズの高さ = 100;
            テスト対象.元画像倍率パーセント = 100;
            テスト対象.格子.Should().HaveCount(2);
            テスト対象.格子.Should().Contain(new LineViewModel(100, 0, 199, 0));
            テスト対象.格子.Should().Contain(new LineViewModel(100, 0, 100, 99));
        }

        [Fact]
        public async Task 格子は分割領域が上下に移動すればそれに伴い移動します()
        {
            テスト対象.元画像 = await NewWriteableBitmap();
            テスト対象.分割領域の左限 = 0;
            テスト対象.分割領域の右限 = 99;
            テスト対象.分割領域の上限 = 100;
            テスト対象.分割領域の下限 = 199;
            テスト対象.分割サイズの幅 = 100;
            テスト対象.分割サイズの高さ = 100;
            テスト対象.元画像倍率パーセント = 100;
            テスト対象.格子.Should().HaveCount(2);
            テスト対象.格子.Should().Contain(new LineViewModel(0, 100, 99, 100));
            テスト対象.格子.Should().Contain(new LineViewModel(0, 100, 0, 199));
        }

        [Fact]
        public async Task 格子は幅に合わせた分割サイズで取得できます()
        {
            テスト対象.元画像 = await NewWriteableBitmap();
            テスト対象.分割領域の左限 = 0;
            テスト対象.分割領域の右限 = 99;
            テスト対象.分割領域の上限 = 0;
            テスト対象.分割領域の下限 = 99;
            テスト対象.分割サイズの幅 = 50;
            テスト対象.分割サイズの高さ = 100;
            テスト対象.元画像倍率パーセント = 100;
            テスト対象.格子.Should().HaveCount(3);
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 99, 0));
            テスト対象.格子.Should().Contain(new LineViewModel(50, 0, 50, 99));
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 0, 99));
        }
        [Fact]
        public async Task 格子は高さに合わせた分割サイズで取得できます()
        {
            テスト対象.元画像 = await NewWriteableBitmap();
            テスト対象.分割領域の左限 = 0;
            テスト対象.分割領域の右限 = 99;
            テスト対象.分割領域の上限 = 0;
            テスト対象.分割領域の下限 = 99;
            テスト対象.分割サイズの幅 = 100;
            テスト対象.分割サイズの高さ = 50;
            テスト対象.元画像倍率パーセント = 100;
            テスト対象.格子.Should().HaveCount(3);
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 99, 0));
            テスト対象.格子.Should().Contain(new LineViewModel(0, 0, 0, 99));
            テスト対象.格子.Should().Contain(new LineViewModel(0, 50, 99, 50));
        }
    }
}
