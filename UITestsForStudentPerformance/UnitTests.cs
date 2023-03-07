using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace UITestsForStudentPerformance
{
    public class UnitTests
    {
        [Fact]
        public async void Test_AddStudent()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            var answer = "Victor";

            await Task.Delay(100);
            var textBoxFio = mainWindow.GetVisualDescendants().OfType<TextBox>().First();
            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonAdd");

            textBoxFio.Text = answer;
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);
            await Task.Delay(100);

            var textBlockFio = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(b => b.Text == answer);

            Assert.True(textBlockFio.Text == answer);
        }
        [Fact]
        public async void Test_DelStudent()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            

            await Task.Delay(100);
            var buttonDel = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonDel");
            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First();
            var answer = listBox.ItemCount - 1;

            listBox.SelectedIndex = answer;
            buttonDel.Command.Execute(buttonDel.CommandParameter);

            await Task.Delay(100);
            var result = listBox.ItemCount;

            Assert.True(result == answer);
        }
        [Fact]
        public async void Test_Save_and_Load()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();


            await Task.Delay(100);
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonSave");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonLoad");
            var buttonDel = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonDel");
            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First();
            var answer = listBox.ItemCount;

            listBox.SelectedIndex = answer-1;

            buttonSave.Command.Execute(buttonSave.CommandParameter);
            buttonDel.Command.Execute(buttonDel.CommandParameter);
            buttonLoad.Command.Execute(buttonLoad.CommandParameter);

            await Task.Delay(100);
            var result = listBox.ItemCount;

            Assert.True(result == answer);
        }
        [Fact]
        public async void Test_Red_Color()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();


            await Task.Delay(100);
            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();
            
            var listBoxItem = listBox.ToArray()[0];
            var redColor = (new SolidColorBrush(Colors.Red)).Color;
            var border = listBoxItem.GetVisualDescendants().OfType<Border>().First(b => b.Name == "ElecColor");
            var mark = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "ElecMark");
            await Task.Delay(100);
            var color = (border.Background as SolidColorBrush).Color;
            Assert.True(mark.Text.Equals("0"));
            Assert.True(color.Equals(redColor), color.ToString());
            
            border = listBoxItem.GetVisualDescendants().OfType<Border>().First(b => b.Name == "AverColor");
            mark = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "AverMark");
            color = (border.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(redColor), color.ToString());

        }
        [Fact]
        public async void Test_Yellow_Color()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();


            await Task.Delay(100);
            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();
            
            var listBoxItem = listBox.ToArray()[1];
            var yellowColor = (new SolidColorBrush(Colors.Yellow)).Color;
            var border = listBoxItem.GetVisualDescendants().OfType<Border>().First(b => b.Name == "ElecColor");
            var mark = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "ElecMark");
            var color = (border.Background as SolidColorBrush).Color;
            Assert.True(mark.Text.Equals("1"));
            Assert.True(color.Equals(yellowColor), color.ToString());
            
            border = listBoxItem.GetVisualDescendants().OfType<Border>().First(b => b.Name == "AverColor");
            mark = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "AverMark");
            color = (border.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(yellowColor), color.ToString());

        }
        [Fact]
        public async void Test_Green_Color()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();


            await Task.Delay(100);
            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var listBoxItem = listBox.ToArray()[2];
            var greenColor = (new SolidColorBrush(Colors.Green)).Color;
            var border = listBoxItem.GetVisualDescendants().OfType<Border>().First(b => b.Name == "ElecColor");
            var mark = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "ElecMark");
            var color = (border.Background as SolidColorBrush).Color;
            await Task.Delay(100);
            Assert.True(mark.Text.Equals("2"));
            Assert.True(color.Equals(greenColor), color.ToString());
            
            border = listBoxItem.GetVisualDescendants().OfType<Border>().First(b => b.Name == "AverColor");
            mark = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "AverMark");
            color = (border.Background as SolidColorBrush).Color;
            await Task.Delay(100);
            
            Assert.True(color.Equals(greenColor), color.ToString());
        }
    }
}